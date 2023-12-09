using Emgu.CV;
using GUI_I2G.GCodeclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    public abstract class Contour//wieso abstract (macht man doch nur wenn man auch abstract Methoden benutzt?(außerdem haben wir das damals schon abgequatscht?))
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double EndDepth { get; set; } // I'll need this   
        public abstract double Length { get; set; }


        /// <summary>
        /// Tests if the maschine can continue in rounds, or rather has to make an one eighty
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsClosed(Contour[] c) => c[0].StartPoint == c[^1].EndPoint; 

       
        /// <summary>
        /// The first Contour(s) are not finished (or all when the milingtool is to short) after the first go, so in order to finish it, this function reverse the toolpath
        /// </summary>
        /// <returns>reversed Contour</returns>
        public Contour Reversed()
        {
            (EndPoint, StartPoint) = (StartPoint, EndPoint); //changes the start and end- point with each other; important for open Contours ContourGroup.Start != ContourGroup.End;
            if (this is Curve)
                (this as Curve).Direct = (this as Curve).Direct == Direction.CounterGlockwise ? Direction.Glockwise : Direction.CounterGlockwise; // changes the direction of the Curve, so the toolpath stays the same
            return this;
        }
        /// <summary>
        /// Use only if the whole toolpath isn't finished, if just the start isn't finished -> use [0].Reversed
        /// </summary>
        /// <param name="contours"></param>
        /// <returns>A completly reversed array, in case that the milingtool is shorter than the Depth </returns>
        public static Contour[] Arreversed(Contour[] contours)
        {
            Contour[] ret = new Contour[contours.Length-1];
            for (int i = 0; i < contours.Length; i++)
            {
                ret[i] = contours[contours.Length - i - 1].Reversed();
            }
            return ret;
        }



        public static Contour[] ContourExtractor(Image image)
        {
            return ContourExtractor();
        }
        public static Contour[] ContourExtractor() //DummyFunktion
        {
            //bloss beispielhaft
            Contour[] result = new Contour[3];
            result[0] = new Vector(new Point(3, 5), new Point(2, -4));
            result[1] = new Curve(new Point(3, 5), new Point(3, 6), 5, Direction.Glockwise);
            result[2] = new Vector(new Point(4, 5), new Point(7, 4));

            return result;
        }

        public static List <Contour[]> ContourGroup(Contour[] CList) // The GCodeGenerator has to know, which Contoures in the Array belong together
        {
            return new List <Contour[]>();
        }
        public void WriteOutContures(Contour[] contures)
        {
            foreach (Contour conture in contures)
            {
                Console.WriteLine(conture.StartPoint.ToString() + " : " + conture.EndPoint.ToString());
                if (conture.GetType() == typeof(Curve))
                    Console.Write(" : " + (conture as Curve).Radius.ToString());
                if (conture is Vector)
                    Console.WriteLine((conture as Vector).Length.ToString());
            }
        }
    }




}
