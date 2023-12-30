using GUI_I2G.Contures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.GCodeclasses
{
    /// <summary>
    /// This is a partial Class, in the other part, I define Methods and public ints for CommandGroups. So the file is called IGCodeGroups.
    /// </summary>
    public abstract partial class IGCCommandlib 
    {
        //static public double Z() => Parameter.DepthEngraving;
        static public List<string> Start() => new () { "%", "G21 G90 G95" };

        static public string CutPath(Contour c) => c is Curve ? CutInCurve(c as Curve) : CutInLine(c);
        
        static public string MoveTo(Point P) => (G0_3.IsOrSet(0) ? "" : "G0 ") + $"X{P.X} Y{P.Y}";

        static public string CutInLine(Contour c) => (G0_3.IsOrSet(1)? "" : "G1 ") + $"X{c.EndPoint.X} Y{c.EndPoint.Y}";

        static public string CutInCurve(Curve c) => (G0_3.IsOrSet(c.MDirect) ? "" : $"G{c.MDirect} ") + $"X{c.EndPoint.X} Y{c.EndPoint.Y} R{c.Radius}"; 
        static public string End() => "G28 %";

        static public string CoolTime(double t) => "";
    }
}

