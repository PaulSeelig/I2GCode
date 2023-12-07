using GUI_I2G;
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
        private string privprojectName;
        public string projectName
        { 
            get
            {
                lastOpened = DateTime.Today;
                return privprojectName;
            }
            private set => privprojectName = value; 
        } //if not named set to current date
        //Might be needed in front end
        //public static string GCodeSavePath { get; private set; } = @".\HistoryEntries\";

        public DateTime lastOpened {  get; private set; } //updated after every openeing

        public Parameter parameter { get; private set; }

        public string gcodePath { get; private set; }

        public string imagePath { get; private set; }

        //DO we safe the contours aswell?

        //creating an instance of the historyentry with all the Data inside
        public HistoryEntry(string projectname, Parameter parameter, string gcodePath, string imagePath)
        {
            this.projectName = projectname;
            this.parameter = parameter;
            this.gcodePath = gcodePath;
            this.lastOpened = DateTime.Today;
            this.imagePath = imagePath;
        }
    }
}
