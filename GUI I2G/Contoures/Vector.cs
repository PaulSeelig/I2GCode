using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    internal class Vector : Contour
    {
        public double Length { get; set; }

        public Vector(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }
    }
}
