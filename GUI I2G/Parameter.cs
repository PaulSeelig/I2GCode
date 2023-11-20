using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G
{
    internal class Parameter
    {
        public static double DepthEngraving {  get; set; }

        public static double[] Eckpunkte { get; private set; }

        public static double TableWidth { get; set; }
       
        //public static double TableHeight { get; set;}

        public static double TableLength { get; set; }
    }
}
