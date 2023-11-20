using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    internal class Curve : Contour
    {
        public double Radius { get; set; }

        public Curve(Point start, Point end, double radius)
        {
            StartPoint = start;
            EndPoint = end;
            Radius = radius;
        }
    }
}
