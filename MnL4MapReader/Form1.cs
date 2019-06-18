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
using SPICA.WinForms;

namespace MnL4MapReader
{
    public partial class Form1 : Form
    {
        string folderPath = "";
        FrmMain spicaForm; //Yep, this code is directly relies on SPICA for a few things, so we need to have our own window of it
        List<ThingyItem> itemList = new List<ThingyItem>();
        int currentSelectedValue = 1;

        class ThingyItem //This class/struct doesn't represent any data in the game, just used for convinience
        {
            public string fileName;
            public string newFileName;
            public uint cgfxOffset;
            public uint cgfxLength;
            public byte[] cgfxData;
            public List<string> cgfxStrings;

            public ThingyItem(string fileName)
            {
                this.fileName = fileName;
                this.newFileName = "";
                this.cgfxOffset = 0x0;
                this.cgfxLength = 0x0;
                this.cgfxData = null;
                this.cgfxStrings = new List<string>();
            }

            public ThingyItem(string fileName, uint cgfxOffset, uint cgfxLength, byte[] cgfxData)
            {
                this.fileName = fileName;
                this.newFileName = fileName;
                this.cgfxOffset = cgfxOffset;
                this.cgfxLength = cgfxLength;
                this.cgfxData = cgfxData;
                this.cgfxStrings = new List<string>();
            }
        }

        public Form1()
        {
            InitializeComponent();
            spicaForm = new FrmMain(); //create an instance of SPICA
            spicaForm.Show(); //Fire up SPICA
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ookii.Dialogs.WinForms.VistaFolderBrowserDialog dlg = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog(); //Used a custom folder selection dialog, just because I didn't want to torture myself and other people using this code. (Microsoft, please make this an actual part of WinForms next time, not an ancient nugget package)
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Disable GUI, to prevent random exceptions and user intervention
                fileNameBox.Enabled = false;
                newFileNameBox.Enabled = false;
                cgfxStringsBox.Enabled = false;
                if (!Directory.Exists(dlg.SelectedPath)) return; //Just give up is the given path doesn't exist
                folderPath = dlg.SelectedPath; //Set global variable with current file path
                var files = Directory.GetFiles(folderPath, "*.mnlmap"); //Look for .mnlmap files, somehow I managed to get this tied to another one of my useless tools...
                foreach (var file in files) //Loop through all map files
                {
                    BinaryReader br = new BinaryReader(File.OpenRead(file)); //Open file
                    br.BaseStream.Position = 0x60; //Go to 0x60 immidialtely, since the rest is practically useless
                    uint cgfxOffset = br.ReadUInt32(); //Read start offset of CGFX data
                    uint cgfxLength = br.ReadUInt32(); //Read length of CGFX data
                    byte[] cgfxData = new byte[cgfxLength]; //Create a byte array to store this
                    br.BaseStream.Position = cgfxOffset; //Read the CGFX data into the array...only now, few years after I wrote this,
                    for (uint i = 0; i < cgfxLength; i++) cgfxData[i] = br.ReadByte(); //I realize how stupid this is: basically just trash the whole RAM with CGFX data...
                    itemList.Add(new ThingyItem(Path.GetFileNameWithoutExtension(file), cgfxOffset, cgfxLength, cgfxData)); //Add item to file list
                    br.Close(); //Close reader
                }
                foreach (var item in itemList) fileNameBox.Items.Add(item.fileName); //Now add those entries to the GUI list
                fileNameBox.SelectedIndex = 0; //Change selected intex to 0 to trigger an event
                //Re-enable the GUI
                fileNameBox.Enabled = true;
                newFileNameBox.Enabled = true;
                cgfxStringsBox.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); //A simple close thing
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This code actually applies all the name changes you've made in the program itself
            //The code below is self-explanatory, so I won't be commenting it
            foreach (var item in itemList)
            {
                if (item.fileName != item.newFileName)
                {
                    File.Move(folderPath + "\\" + item.fileName + ".mnlmap", folderPath + "\\" + item.newFileName + ".mnlmap");
                    fileNameBox.Items[fileNameBox.Items.IndexOf(item.fileName)] = item.newFileName;
                    item.fileName = item.newFileName;
                }
            }
        }

        private void fileNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Event for when user clicks on another entry in the list
            //Disable GUI
            fileNameBox.Enabled = false;
            newFileNameBox.Enabled = false;
            cgfxStringsBox.Enabled = false;
            if (fileNameBox.SelectedIndex != -1 && fileNameBox.SelectedIndex != currentSelectedValue) //Make sure that an entry is actually selected and that the user clicked onto another item, not the one that's already selected
            {
                newFileNameBox.Text = itemList[fileNameBox.SelectedIndex].newFileName; //Put the current file name into the text entry box
                spicaForm.OpenFromBytearray(itemList[fileNameBox.SelectedIndex].cgfxData); //Call a bodge function I added to SPICA to load a file from byte array...basically waste even more RAM
                cgfxStringsBox.Items.Clear(); //Clear out the name "suggestions"
                foreach (var thing in spicaForm.Scene.Models) cgfxStringsBox.Items.Add(thing.Name); //Add all model names to the list
                foreach (var thing in spicaForm.Scene.Lights) cgfxStringsBox.Items.Add(thing.Name); //Add all light names to the list, because some files are identical except for lights
                currentSelectedValue = fileNameBox.SelectedIndex; //Set the last selected value to the current one
            }
            else if (fileNameBox.SelectedIndex == -1) //In case the user deselected all items by clicking into blank space
            {
                fileNameBox.SelectedIndex = currentSelectedValue; //Set the value back to what it was
            }
            //Re-enable the GUI
            fileNameBox.Enabled = true;
            newFileNameBox.Enabled = true;
            cgfxStringsBox.Enabled = true;
        }

        private void newFileNameBox_TextChanged(object sender, EventArgs e)
        {
            itemList[fileNameBox.SelectedIndex].newFileName = newFileNameBox.Text;
        }

        private void cgfxStringsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            newFileNameBox.Text = (string)cgfxStringsBox.SelectedItem;
        }

        private void mnlmapToCgfxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //As NOT noted by the GUI in any way, this function is standalone. Refer to openToolStripMenuItem_Click() commentary for info, since this is basically the same, just saves CGFX to file
            List<ThingyItem> tempList = new List<ThingyItem>();
            Ookii.Dialogs.WinForms.VistaFolderBrowserDialog dlg = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileNameBox.Enabled = false;
                newFileNameBox.Enabled = false;
                cgfxStringsBox.Enabled = false;
                if (!Directory.Exists(dlg.SelectedPath)) return;
                folderPath = dlg.SelectedPath;
                var files = Directory.GetFiles(folderPath, "*.mnlmap");
                foreach (var file in files)
                {
                    BinaryReader br = new BinaryReader(File.OpenRead(file));
                    br.BaseStream.Position = 0x60;
                    uint cgfxOffset = br.ReadUInt32();
                    uint cgfxLength = br.ReadUInt32();
                    byte[] cgfxData = new byte[cgfxLength];
                    br.BaseStream.Position = cgfxOffset;
                    for (uint i = 0; i < cgfxLength; i++) cgfxData[i] = br.ReadByte();
                    tempList.Add(new ThingyItem(Path.GetFileNameWithoutExtension(file), cgfxOffset, cgfxLength, cgfxData));
                    br.Close();
                }
                Directory.CreateDirectory(folderPath + "\\to_bcres");
                foreach (var item in tempList)
                {
                    BinaryWriter bw = new BinaryWriter(File.Create(folderPath + "\\to_bcres\\" + item.fileName + ".bcres"));
                    bw.Write(item.cgfxData);
                    bw.Close();
                }
            }
        }
    }
}
