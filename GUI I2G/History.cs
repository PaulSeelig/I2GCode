using GUI_I2G.GCodeclasses;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G
{
    interface IHistoryEntry
    {
        public void SaveGcodeProject()
        {

        }

    }

    internal class History
    {
        public string ProjectName { get; private set; } = DateTime.Now.ToString();
        public static string GCodeSavePath { get; private set; } = @".\HistoryEntries\";

        public Parameter Parameter { get; private set; }

        public GCode Gcodes { get; private set; }

        public Image? Image { get; private set; }
    }
}
