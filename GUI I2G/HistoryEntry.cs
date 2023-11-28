using GUI_I2G.GCodeclasses;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace GUI_I2G
{
    [Serializable]
    public class HistoryEntry
    {
        //An Object to save all the data, to serialize and deserialize using json

        //Project relevant date:
        public string ProjectName { get; private set; } = DateTime.Now.ToString(); //if not named set to current date
        //Might be needed in front end
        //public static string GCodeSavePath { get; private set; } = @".\HistoryEntries\";

        public Parameter Parameter { get; private set; }

        public GCode Gcodes { get; private set; }

        public Image? Image { get; private set; }

        //DO we safe the contours aswell?

        //creating an instance of the historyentry with all the Data inside
        public HistoryEntry(string projectname, Parameter parameter, GCode gcode, Image image)
        {
            ProjectName = projectname;
            Parameter = parameter;
            Gcodes = gcode;
            Image = image;
        }
    }
}
