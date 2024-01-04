using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;
using static System.Windows.Forms.LinkLabel;

namespace GUI_I2G.Tests
{
    internal class Konturerkennung_Test_1
    {
        //Eigenschaften
        public int Schwellenwert { get; set; }//threshold
                                              //Methoden
        public void Konturen()
        {
            Mat img = CvInvoke.Imread("Bild.png", Emgu.CV.CvEnum.ImreadModes.Color);

            Image<Gray, System.Byte> imggray = new Image<Gray, System.Byte>(img);

            Image<Gray, System.Byte> imageDraw = imggray.Copy();//auf dem werden die lKonturen gemalt            

            double otsuSchwellenwert = CvInvoke.Threshold(imggray, imggray, 0, 255, ThresholdType.Otsu);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(imggray, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

            CvInvoke.DrawContours(imageDraw, contours, -1, new MCvScalar(200, 45, 45), 2);

            CvInvoke.Imwrite("DrawlName.png", imageDraw);

            //Bogen erkennung

            Point[][] konturen = contours.ToArrayOfArray();
            List<Point> konturen_ = new List<Point>();
            for (int i = 0; i < konturen.Length; i++)
            {
                for (int j = 0; j < konturen[i].Length; j++)
                {
                    konturen_.Add(konturen[i][j]);
                }
            }
            Point[] konturen__ = konturen_.ToArray();

            VectorOfPoint approxK = new VectorOfPoint();
            VectorOfPoint preapproxKurve = new VectorOfPoint();
            preapproxKurve.Push(konturen__);

            CvInvoke.ApproxPolyDP(preapproxKurve, approxK, 0.5, false);
            Point[] approxKurve = approxK.ToArray();

            for (int i = 0; i < approxKurve.Length; i++)
            {
                if (i + 3 == approxKurve.Length)
                    break;
                Point mP = Mittelpunktrechner(approxKurve[i], approxKurve[i + 1], approxKurve[i + 2]);//Gleichung kontrolieren
                //Abstand
                double radius = Math.Sqrt(Math.Pow(mP.X - approxKurve[i].X, 2) + Math.Pow(mP.Y - approxKurve[i].Y, 2));
                double p4Abstand = Math.Sqrt(Math.Pow(mP.X - approxKurve[i + 3].X, 2) + Math.Pow(mP.Y - approxKurve[i + 3].Y, 2));
                //muss noch wegen Vorzeichen anpassen
                if (radius == p4Abstand)
                {
                    //hier wurde ein Bogen erkannt
                }
            }
        }
       
        public void kKonturen(List<Linie> a)
        {
            for (int i = 0; i < a.Count; i++)
            {

            }
        }
        protected Point Mittelpunktrechner(Point p1, Point p2, Point p3)
        {
            Point mP = new Point();
            double xZähler = ((Math.Pow(p1.X, 2) - Math.Pow(p2.X, 2)) * (p2.Y - p3.Y) - (Math.Pow(p2.X, 2) - Math.Pow(p3.X, 2)) * (p1.Y - p2.Y) + (p1.Y - p2.Y) * (p1.Y - p3.Y) * (p2.Y - p3.Y));
            double xNenner = 2 * ((p1.X - p2.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p2.Y));
            double x = xZähler / xNenner;//könnte hier am Typcasten scheitern
            int y = (int)((1 / 2 * (p1.Y - p2.Y)) * (Math.Pow(p1.X, 2) - Math.Pow(p2.X, 2) + Math.Pow(p1.Y, 2) - Math.Pow(p2.Y, 2) - (2 * x) * (p1.X - p2.X)));//könnte hier am Typcasten scheitern
            mP.X = (int)x;
            mP.Y = y;
            return mP;
        }


    }
}
