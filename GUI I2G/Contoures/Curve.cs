using GUI_I2G.GCodeclasses;
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
        /// <summary>
        /// defines a third Point on the Curve between Start- and EndPoint;
        /// It calculates the Radius, so I won't have to decide which one I use later on
        /// alternative to Radius, only one of them is required...
        /// for further explanation, this is my source for the calculation:... https://www.youtube.com/watch?v=ptqdguJGcg4
        /// </summary>
        public Point ThrdPOnCurve { set {
                Point avector = new(StartPoint.X - value.X, StartPoint.Y - value.Y);
                Point bvector = new(EndPoint.X - value.X, EndPoint.Y - value.Y);
                double aPow2 = Math.Pow(avector.X, 2) + Math.Pow(avector.Y, 2);
                double bPow2 = Math.Pow(bvector.X,2) + Math.Pow(bvector.Y, 2);
                double vecMulti = avector.X * bvector.X + avector.Y * bvector.Y;
                double radius = 1/2 * Math.Sqrt(aPow2 * bPow2 * (aPow2 + bPow2 - 2 * vecMulti) / (aPow2 * bPow2 - Math.Pow(aPow2, 2)));
                SetRadius(radius);} }
        /// <summary>
        /// defines the center of the circle, from which the curve is part of; 
        /// the Center calculates the Radius, so I later on, won't have to decide which to use;
        /// alternative to Radius, only one of the both of them is required...
        /// </summary>
        public Point Center { set => SetRadius(Math.Sqrt(Math.Pow(StartPoint.X - value.X, 2) + Math.Pow(StartPoint.Y - value.Y, 2)));}
        /// <summary>
        /// defines the radius of the curve; 
        /// alternative to Center, only one of the both of them is required... 
        /// </summary>
        public double Radius { get; private set; } //solten wir den nicht lieber errechnen lassen?  .....Pierre: Ja, der sollte besser errechnet werden. Ich bin mir aber zurzeit nicht sicher, was ich da tatsächlich von Leo zurückbekomme. Zwei Punkte reichen halt nich.
        public void SetRadius(double radius) // nur damit der Radius nicht zu klein erstellt wird, soll aber später noch andere Dinge testen..(Fehlersuchen)
        {
            Vector a = new(StartPoint, EndPoint);
            if (2 * radius < a.Length)
                throw new Exception();
            else
                Radius = radius;
        }
        /// <summary>
        /// The direction is needed, since the GCodeGenerator has to know, in which direction the radius takes effekt and therfor which Command to use
        /// </summary>a
        public Direction Direct { get; set; }
        public int MDirect { get => Direct == Direction.Glockwise ? 2 : 3; }
        /// <summary>
        /// The original looks like Pi*r*Asin(distancebetweenPoints/2r)/90, but Asin gives back radians, so I multiplied with 180/Math.Pi and shortend the equation
        /// </summary>
        public override double Length { get => Radius * Math.Asin(Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2)) / (2 * Radius)) * 2;}

        
        public Curve(Point start, Point end, double radius, Direction direx)
        {
            StartPoint = start;
            EndPoint = end;
            Direct = direx;
            SetRadius(radius);
        }
    }
}
