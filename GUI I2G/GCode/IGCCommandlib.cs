using GUI_I2G.Contures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.GCode
{
    public class IGCCommandlib
    {
        static public double Z() => Parameter.DepthEngraving;
        static public string Start(Point p) => $"G00 X{p.X} Y{p.Y}";

        static public string MoveInLine(Contour v) => "";

        static public string MoveTo() => "";

        static public string MoveInCurve(Contour c) => "";

        static public string End(Point end) => "";

        static public string CoolTime() => "";


    }
}
