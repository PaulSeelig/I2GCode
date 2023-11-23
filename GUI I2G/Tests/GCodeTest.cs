using GUI_I2G.Contures;
using GUI_I2G.GCodeclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Tests
{
    internal class GCodeTest
    {
        public static void GCUnittest()
        {
            GCodeGenerator.GenerateGCode(Contour.ContourExtractor());

        }
    }
}
