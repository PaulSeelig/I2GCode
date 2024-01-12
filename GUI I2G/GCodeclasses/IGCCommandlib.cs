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

        static public string CutPath(Contour c, Parameter p) => c != null ? (c is Curve ? CutInCurve(c as Curve, p) : CutInLine(c, p)) : "";

        static public List<string> MoveTo(Point point, double pZ, Parameter p)
        {
            List<string> sl = new() 
            {
                "G0".IsOrSet(ref G0_3) + $"Z{(p.MaterialDepth + 2)}".IsOrSet(ref Z),
                ToXYPoint(point, p.MaterialDepth + 2, p),
                $"Z{pZ} ".IsOrSet(ref Z) 
            };
            sl.Remove("");
            return sl;
        }

        static private string ToXYPoint(Point point, double pZ, Parameter p)
        {
            return  $"X{(point.X * p.ScaleFactor + p.AddPosX)} ".IsOrSet(ref X) + 
                    $"Y{(point.Y * p.ScaleFactor + p.AddPosY)} ".IsOrSet(ref Y) + 
                    $"Z{pZ} ".IsOrSet(ref Z);
        }
        static private string CutInLine(Contour c, Parameter p) => "G1".IsOrSet(ref G0_3) + ToXYPoint(c.EndPoint, c.EndDepth, p);

        static private string CutInCurve(Curve c, Parameter p) => c.MDirect.IsOrSet(ref G0_3) + ToXYPoint(c.EndPoint, c.EndDepth, p) + $"R{c.Radius * p.ScaleFactor}"; 
      
        static public string End() => "G28 %";

        static public string CoolTime(double t) => "";

        public static NullReferenceException NullRefException => new();
    }
}

