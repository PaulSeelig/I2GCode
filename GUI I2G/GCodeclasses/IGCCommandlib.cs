using GUI_I2G.Contures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.GCodeclasses
{
    public abstract class IGCCommandlib
    {
        static public double Z() => Parameter.DepthEngraving;
        static public string Start() => "%";

        static public string CutPath(Contour c) => c is Curve? CutInCurve(c) : CutInLine(c);

        static public string MoveTo(Point P) => "";

        static public string CutInLine(Contour c) => "";

        static public string CutInCurve(Contour c) => "";

        static public string End() => "%";

        static public string CoolTime(double t) => "";


    }
}

