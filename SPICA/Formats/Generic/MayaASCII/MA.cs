using SPICA.Formats.Common;
using SPICA.Formats.CtrH3D;
using SPICA.Formats.CtrH3D.Animation;
using SPICA.Formats.CtrH3D.Model;
using SPICA.Formats.CtrH3D.Model.Material;
using SPICA.Formats.CtrH3D.Model.Mesh;
using SPICA.Formats.CtrH3D.Texture;
using SPICA.Math3D;
using SPICA.PICA.Commands;
using SPICA.PICA.Converters;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Serialization;

namespace SPICA.Formats.Generic.MayaASCII
{
    public class MA
    {
        public MA()
        {

        }

        public void Save(String FileName)
        {
            StringBuilder SB = new StringBuilder();

            //Write Maya ASCII header
            SB.AppendLine("//Maya ASCII 2013 scene");
            SB.AppendLine("//Name testscene.ma"); //TODO: Change this later to reflect the scene name
            //Screw writing last modified date. I'll maybe add it later
            SB.AppendLine("//Codeset: 1252");
            SB.AppendLine("requires maya \"2013\";");
            SB.AppendLine("currentUnit -l cm -a deg -t film;"); //Use metric units because imperial units suck
            SB.AppendLine("fileInfo \"application\" \"spica\";");
            SB.AppendLine("fileInfo \"product\" \"SPICA\";");
            SB.AppendLine("fileInfo \"version\" \"whoevencares\";");
            SB.AppendLine("fileInfo \"cutIdentifier\" \"201606150345\";"); //TODO: Remove placeholder value
            SB.AppendLine("fileInfo \"osv\" \"Microsoft Windows\\n\";"); //TODO: Also replce the placeholder text


            SB.AppendLine("");
        }
    }
}
