using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using GUI_I2G.GCodeclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    public abstract class Contour
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public double EndDepth { get; set; } = 0;
        public abstract double Length { get;}

        public static double GetArrLength(Contour[] cArr)
        {
            double erg = 0;
            foreach(Contour c in cArr)
                erg += c.Length;
            return erg;
        }
        /// <summary>
        /// Tests if the maschine can continue in rounds, or rather has to make an one eighty
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsClosed(Contour[] c) => c[0].StartPoint == c[^1].EndPoint; 

       
        /// <summary>
        /// The first Contour(s) are not finished (or all when the millingtool is to short) after the first go, so in order to finish it, this function reverse the toolpath
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
        /// <returns>A completly reversed array, in case that the millingtool is shorter than the Depth </returns>
        public static Contour[] ArrayReversed(Contour[] contours)
        {
            Contour[] ret = new Contour[contours.Length];
            for (int i = 0; i < contours.Length; i++)
            {
                ret[i] = contours[contours.Length - i - 1].Reversed();
            }
            return ret;
        }
        public static VectorOfVectorOfPoint Konturfinder (Image<Rgb, System.Byte> rgbimage)
        {
            Image<Gray, System.Byte> imggray = rgbimage.Convert<Gray,System.Byte>();            

            CvInvoke.Threshold(imggray, imggray, 0, 255, ThresholdType.Otsu);

            VectorOfVectorOfPoint contours = new();

            CvInvoke.FindContours(imggray, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

            return contours;
        }

        
        public static List<Contour[]> ContourExtractor(VectorOfVectorOfPoint KonturenArray, double epsilon)
        {            

            Point[][] konturen = KonturenArray.ToArrayOfArray();

            List <Contour[]> contours = new();
            
            for(int i = 0; i < konturen.Length; i++)
            {
                VectorOfPoint aprox = new();
                aprox.Push(konturen[i]);
                for (int n = 0; n < KonturenArray.Length; n++)
                    CvInvoke.ApproxPolyDP(aprox, aprox, epsilon, false);
                konturen[i]=aprox.ToArray();

                List<Contour> contour = new();
                for (int j = 0; j < konturen[i].Length - 1; j++)
                {
                    //if (contour.Count > 0 && OnVector((Line)contour.Last(), konturen[i][j + 1]))
                    //{
                    //    contour.Last().EndPoint = konturen[i][j + 1];
                    //}
                    if (konturen[i].Length > 1)
                    {

                        Line line = new(konturen[i][j], konturen[i][j + 1]);
                        contour.Add(line);
                    }
                }
                if (contour.Count > 0)
                {
                    Line lin = new(contour[0].StartPoint, contour[^1].EndPoint);
                    if (lin.Length < GetArrLength(contour.ToArray()) * 0.02)
                    {
                        int px = (contour[0].StartPoint.X + contour[^1].EndPoint.X) / 2;
                        int py = (contour[0].StartPoint.Y + contour[^1].EndPoint.Y) / 2;
                        contour[0].StartPoint = new(px, py);
                        contour[^1].EndPoint = new(px, py);
                    }
                    contours.Add(contour.ToArray());
                }
            }    
            if(contours.Last().Length != 4)
            {
                throw BorderException();
            }
            return contours;
        }
        private static Exception BorderException()
        {
            return new Exception("Border is touched by other Contours!");
        }

        [Obsolete("Old, we Prob'll not need it")]
        private static bool OnVector(Line l, Point p)
        {
            if (l.StartPoint.X == l.EndPoint.X)
            {
                return (p.X <= l.StartPoint.X + 0.235) && p.X >= l.StartPoint.X - 0.235;
            }
            double incline = (l.StartPoint.Y - l.EndPoint.Y) / (l.StartPoint.X - l.EndPoint.X);
            double expY = l.EndPoint.Y + (l.EndPoint.X - p.X) * incline;
            if (expY <= (p.Y + 0.235) && expY >= (p.Y - 0.235))
                return true;
            else 
                return false;
        }
        /// <summary>
        /// currently Dummy Class, hopefully Leonardos Code soon
        /// </summary>
        /// <returns>returns the Image through a hirarchy of Contours</returns>
        public static Contour[] ContourExtractor() 
        {
            //bloss beispielhaft
            Contour[] result = new Contour[3];
            result[0] = new Line(new Point(3, 5), new Point(2, -4));
            result[1] = new Curve(new Point(3, 5), new Point(3, 6), 5, Direction.Glockwise);
            result[2] = new Line(new Point(4, 5), new Point(7, 4));

            return result;
        }
        public static List<Contour[]> ContourGroup(List<Contour> CList)
        {
            return ContourGroup(CList.ToArray());
        }
        public static List <Contour[]> ContourGroup(Contour[] CList) // The GCodeGenerator has to know, which Contoures in the Array belong together
        {

            return new List <Contour[]>();
        }
    }
}
