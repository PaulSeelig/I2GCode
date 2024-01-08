using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using GUI_I2G.GCodeclasses;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public VectorOfVectorOfPoint Konturfinder (string pfad)
        {
            Mat img = CvInvoke.Imread(pfad, Emgu.CV.CvEnum.ImreadModes.Color);

            Image<Gray, System.Byte> imggray = new Image<Gray, System.Byte>(img);                

            double otsuSchwellenwert = CvInvoke.Threshold(imggray, imggray, 0, 255, ThresholdType.Otsu);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(imggray, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

            return contours;
        }


        public static List<Contour[]> ContourExtractor(VectorOfVectorOfPoint KonturenArray)
        {
            Point[][] konturen = KonturenArray.ToArrayOfArray();
            List <Contour[]> contours = new List<Contour[]>();
            for(int i = 0; i < konturen.Length; i++)
            {
                Contour[] contour = new Contour[konturen[i].Length];
                for (int j = 0; j < konturen[i].Length; j++)
                {
                    if (j + 1 == konturen[i].Length)
                        break;
                    Line line = new Line();
                    line.StartPoint = konturen[i][j];                   
                    line.EndPoint = konturen[i][j+1];
                    contour[j] = line;
                }
                contours.Add(contour);
            }            
            return contours;
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
        public void WriteOutContures(Contour[] contures)
        {
            foreach (Contour conture in contures)
            {
                Console.WriteLine(conture.StartPoint.ToString() + " : " + conture.EndPoint.ToString());
                if (conture.GetType() == typeof(Curve))
                    Console.Write(" : " + (conture as Curve).Radius.ToString());
                if (conture is Line)
                    Console.WriteLine((conture as Line).Length.ToString());
            }
        }
    }
}
