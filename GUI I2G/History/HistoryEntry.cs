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
using GUI_I2G.GCodeclasses;

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
                return privprojectName;
            }
            private set => privprojectName = value; 
        } 
        
        public DateTime lastOpened {  get; private set; } //updated after every openeing

        public Parameter parameter { get; private set; }

        public GCode Gcode { get; private set; }

        public string imagePath { get; private set; }

        //DO we safe the contours aswell?

        public void UpdateLastOpened()
        {
            lastOpened = DateTime.Now;
        }
        //creating an instance of the historyentry with all the Data inside
        /// <summary>
        /// Creates the History entry object setting lastOpened to today automatically
        /// </summary>
        /// <param name="projectname"></param>
        /// <param name="parameter"></param>
        /// <param name="gcode"></param>
        /// <param name="imagePath"></param>
        
        public HistoryEntry(string projectname, Parameter parameter, GCode gcode, string imagePath)
        {
            this.projectName = projectname;
            this.parameter = parameter;
            this.Gcode = gcode;
            this.lastOpened = DateTime.Now;
            this.imagePath = imagePath;
        }
    }
}
