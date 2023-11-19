using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G
{
    internal class Curve : Conture
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
