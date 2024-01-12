using GUI_I2G.Contures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace GUI_I2G.GCodeclasses
{
    /// <summary>
    /// This is a partial Class, in the other part, I define Methods and public ints for CommandGroups. So the file is called IGCodeGroups.
    /// </summary>
    public static partial class GCodeGenerator
    {
        static private string? X;
        static private string? Y;
        static private string? Z; 

       
        
        static public List<string> Start() => new () { "%", "G17 G21 G90 G95" };

        static public string CutPath(Contour c) => c != null ? (c is Curve ? CutInCurve(c as Curve) : CutInLine(c)) : "";
        
        static public List<string> MoveTo(Point P, string? pZ) => new() { "G0".IsOrSet(ref G0_3) + "Z-1".IsOrSet(ref Z), ToXYPoint(P, Z), pZ.IsOrSet(ref Z) };

        static private string ToXYPoint(Point P, string? pZ ) => $"X{P.X}".IsOrSet(ref X) + $"Y{P.Y}".IsOrSet(ref Y) + pZ.IsOrSet(ref Z);
       
        static private string CutInLine(Contour c) => "G1".IsOrSet(ref G0_3) + ToXYPoint(c.EndPoint, $"Z{c.EndDepth}");

        static private string CutInCurve(Curve c) => c.MDirect.IsOrSet(ref G0_3) + ToXYPoint(c.EndPoint, $"Z{c.EndDepth}") + $"R{c.Radius}"; 
      
        static public string End() => "G28 %";

        static public string CoolTime(double t) => "";

        public static NullReferenceException NullRefException => new();
    }
}

