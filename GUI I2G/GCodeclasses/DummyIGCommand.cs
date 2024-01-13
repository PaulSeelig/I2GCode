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
    /// this class contains method overloading, normally put below the respective methods, but this is only dummymethods here. 
    /// It will be deactivated after the scaling is properly tested
    /// </summary>
    public static partial class GCodeGenerator
    {
        static private string ToXYPoint(Point P, string? pZ) => $"X{P.X}".IsOrSet(ref X) + $"Y{P.Y}".IsOrSet(ref Y) + pZ.IsOrSet(ref Z);

        [Obsolete("This method-overload is obsolete. Call CutPath(..) instead. ... only for testing... not scaling the frame of material", false)]
        static public string CutInLine(Contour c) => "G1".IsOrSet(ref G0_3) + ToXYPoint(c.EndPoint, $"Z{c.EndDepth}");

       
    }
}
