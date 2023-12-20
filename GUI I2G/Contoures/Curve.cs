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
        public double Radius { get; set; } //solten wir den nicht lieber errechnen lassen?  .....Pierre: Ja, der sollte besser errechnet werden. Ich bin mir aber zurzeit nicht sicher, was ich da tatsächlich von Leo zurückbekomme. Zwei Punkte reichen halt nich.
        public void SetRadius(double radius) // nur damit der Radius nicht zu klein erstellt wird
        {
            Vector a = new(StartPoint, EndPoint);
            if (2 * radius < a.Length)
                throw new Exception();
            else
                Radius = radius;
        }
        /// <summary>
        /// The direction is needed, since the GCodeGenerator has to know, in which direction the radius takes effekt and therfor which Command to use
        /// </summary>
        public Direction Direct { get; set; }
        public override void SetLength()
        {
            Length = Radius * Math.Asin(Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2)) / (2 * Radius)) * 2;
        }   // The original looks like Pi*r*Asin(distancebetweenPoints/2r)/90, but Asin gives back radians, so I multiplied with 180/Math.Pi and shortend the equation
        
        public Curve(Point start, Point end, double radius, Direction direx)
        {
            StartPoint = start;
            EndPoint = end;
            Direct = direx;
            SetRadius(radius);
            SetLength();
        }
    }
}
