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
        //static public double Z() => Parameter.DepthEngraving;
        static public List<string> Start() => new () { "%", "G21 G90 G95" };

        static public string CutPath(Contour c) => c is Curve? CutInCurve(c as Curve) : CutInLine(c);

        static public string MoveTo(Point P) => "";

        static public string CutInLine(Contour c) => "";

        static public string CutInCurve(Curve c) => c.Direct == Direction.Glockwise? "G02" : "G03";

        static public string End() => "G28 %";

        static public string CoolTime(double t) => "";


    }
}

