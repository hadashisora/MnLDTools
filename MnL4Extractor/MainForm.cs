using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MnL4Extractor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void radioBtnSelectionChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Name == "radioBtnAuto") offModeTabContainer.SelectedIndex = 0;
            else if (((RadioButton)sender).Name == "radioBtnManual") offModeTabContainer.SelectedIndex = 1;
            else throw new Exception("You've managed to somehow screw this up!"); //Just in case
        }

        private void label5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy; //This basically allows stuff to get drag-dropped onto the control
        }

        private void label5_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop); //Get all files provided by user
            if (files.Length != 1) throw new Exception("Please input one file at a time!!!"); //Can't do more than one file at a time, since it requires entering a different adress value
            Extract(files[0]);
        }
        private void Extract(string FilePath)
        {
            bool isAuto = radioBtnAuto.Checked;
            if (isAuto) return; //Automatic detection is not here and probably will never be...
            else if (!isAuto)
            {
                string hex = ""; //Temporary variable for storing hex value
                if (offModeManualTblStart.Text.StartsWith("0x")) hex = offModeManualTblStart.Text; //Check if text starts with hex prefix,
                else hex = "0x" + offModeManualTblStart.Text; //otherwise add it

                uint tbloffset = Convert.ToUInt32(hex, 16); //Convert hex string to an actual uint

                BinaryReader brC = new BinaryReader(File.OpenRead(textBoxCodePath.Text)); //Open code.bin or .cro
                brC.BaseStream.Position = tbloffset + 0x2; //Skip first two bytes, their purpose is unknown
                ushort fileCount = brC.ReadUInt16(); //Read file count
                brC.BaseStream.Position += 0xC; //Skip more unknown stuff
                BinaryReader brF = new BinaryReader(File.OpenRead(FilePath)); //Open the actual file
                string dir = Path.GetDirectoryName(FilePath) + "\\" + Path.GetFileNameWithoutExtension(FilePath) + "_extracted"; //Calculate path where to extract stuff
                Directory.CreateDirectory(dir); //Create output directory
                for (ushort i = 0; i < fileCount; i++) //Loop through all entries
                {
                    uint Start = brC.ReadUInt32(); //Read file start offset
                    uint LengthRaw = brC.ReadUInt32(); //Read file length as-is stored
                    if (Start == 0x00000000 && LengthRaw == 0x3FFFFFFF) //Sometimes there's a dummy entry like this, so we skip it
                    {
                        Start = brC.ReadUInt32();
                        LengthRaw = brC.ReadUInt32();
                    }
                    uint Length = LengthRaw;
                    if (BitConverter.GetBytes(LengthRaw)[3] == 0x40) Length = LengthRaw - 0x40000000; //Do some stuff to assign the proper length value
                    brF.BaseStream.Position = Start; //Go to file start offset
                    byte[] finalData; //Create a byte array to store data to
                    if (brF.ReadByte() == 0x11) //In case file is LZ11 compressed, decompress it
                    {
                        finalData = DecompressLZ11(brF);
                    }
                    else //Otherwise, just read the right number of bytes
                    {
                        brF.BaseStream.Position = Start;
                        finalData = brF.ReadBytes((int)Length);
                    }
                    string format = "{0:D5}";
                    if (chkBoxOutHexNum.Checked) format = "{0:X4}"; //Do some other stuff with string formatting to hanle "Hex numbering" checkbox
                    BinaryWriter bw = new BinaryWriter(File.Create(dir + "\\" + String.Format(format, i) + ReconFileFormat(finalData))); //Create the output file, also call a hacky function to attempt to guess file format
                    bw.Write(finalData); //Write data to file
                    bw.Close(); //Don't forget to close the writer
                }
                brF.Close(); //Close file reader
                brC.Close(); //Close code reader
            }
        }

        private string ReconFileFormat(byte[] input)
        {
            //This is a hacky function for trying to find out the file type
            try
            {
                //Read first four bytes
                byte[] Magic = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    Magic[i] = input[i];
                }

                if (System.Text.Encoding.ASCII.GetString(Magic) == "CGFX") return ".bcres";
                else if (BitConverter.ToUInt32(Magic, 0) == 0x00000068) return ".mnlmap"; //Note: .mnlmap extension doesn't actually exist, I made it up just to more easily spot map files among others
                switch (System.Text.Encoding.ASCII.GetString(Magic))
                {
                    case "CGFX":
                        return ".bcres";
                    default:
                        return ".bin";
                }
            }
            catch
            {
                return ".bin"; //In case this junk can't determine file type, just use .bin extension
            }
        }

        static byte[] DecompressLZ11(BinaryReader br)
        {
            br.BaseStream.Position -= 0x1;
            int decompSize = (int)((br.ReadUInt32() & 0xffffff00) >> 8);
            byte[] result = new byte[decompSize];
            int dstoffset = 0;

            while (true)
            {
                byte header = br.ReadByte();
                for (int i = 0; i < 8; i++)
                {
                    if ((header & 0x80) == 0) result[dstoffset++] = br.ReadByte();
                    else
                    {
                        byte a = br.ReadByte();
                        byte b = br.ReadByte();
                        int offset;
                        int length2;
                        if ((a >> 4) == 0)
                        {
                            byte c = br.ReadByte();
                            length2 = (((a & 0xF) << 4) | (b >> 4)) + 0x11;
                            offset = (((b & 0xF) << 8) | c) + 1;
                        }
                        else if ((a >> 4) == 1)
                        {
                            byte c = br.ReadByte();
                            byte d = br.ReadByte();
                            length2 = (((a & 0xF) << 12) | (b << 4) | (c >> 4)) + 0x111;
                            offset = (((c & 0xF) << 8) | d) + 1;
                        }
                        else
                        {
                            length2 = (a >> 4) + 1;
                            offset = (((a & 0xF) << 8) | b) + 1;
                        }

                        for (int j = 0; j < length2; j++)
                        {
                            result[dstoffset] = result[dstoffset - offset];
                            dstoffset++;
                        }
                    }

                    if (dstoffset >= decompSize)
                    {
                        return result;
                    }
                    header <<= 1;
                }
            }
        }
    }
}
