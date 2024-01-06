using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    public class Line : Contour
    {
        [JsonConstructor]
        public Line(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public Line()
        {

        }
        public override double Length { get => Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2)); }
        
    }
}
