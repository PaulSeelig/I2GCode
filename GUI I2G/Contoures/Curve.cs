using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    public enum Direction
    {
        Glockwise,
        CounterGlockwise
    }
    public class Curve : Contour
    {

        public double Radius { get; set; }
        
        /// <summary>
        /// The direction is needed, since the GCodeGenerator has to know, in which direction the radius takes effekt and therfor which Command to use
        /// </summary>
        public Direction Direct { get; set; }
        private double SaveLength {  get; set; }
        public override double Length { get => SaveLength;
            set 
            { SaveLength = Math.PI * Radius * Math.Asin(Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2)) / 2 * Radius) / 90; } }// Idk, but think this works

        public Curve(Point start, Point end, double radius, Direction direx)
        {
            StartPoint = start;
            EndPoint = end;
            Radius = radius;
            Direct = direx;
        }
    }
}
