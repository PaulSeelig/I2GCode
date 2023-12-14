using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;

namespace GUI_I2G.Tests
{
    internal class Konturerkennung_Test_1
    {
        //Eigenschaften
        public int Schwellenwert { get; set; }//threshold
                                              //Methoden
        public VectorOfVectorOfPoint Konturen()
        {

            Mat img = CvInvoke.Imread("Bild.png", Emgu.CV.CvEnum.ImreadModes.Color);//um Objekt Matrix von Bild //man kann es auch hier schon Grayscalen mit ImreadModes.Grayscale                              

            Image<Gray, System.Byte> imggray = new Image<Gray, System.Byte>(img);//hier wird in Grayscale Format Image
            //System.Byte für die Tiefe (jeder Pixel hat 8Bit um eine graufrabe(die farbe habe ich vorher gennant) zu sein)
            Image<Gray, System.Byte> imageDraw = imggray.Copy();//auf dem werden die Konturen gemalt

            //Linien dicker machen
            Image<Gray, System.Byte> imageDilate = imggray.Copy();
            //CvInvoke.Dilate(imggray,imageDilate,);

            //Simple Thresholding wo man ein Threshold (Schwellenwert) angeben muss (eine Grenze)
            //imggray = imggray.ThresholdBinary(new Gray(254), new Gray(255));
            //imggray = imggray.ThresholdBinaryInv(new Gray(254), new Gray(255));//<=ist gedreht


            //Adaptive Thresholding
            //imggray = imggray.ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC,Emgu.CV.CvEnum.ThresholdType.Binary,11,new Gray(2));//11 ist die kasten größe ist auch (ca.11-13)standart (bei bestimmten Bilder sollte man das anpassen können(oder selbstständig))
            //imggray = imggray.ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary,11,new Gray(2));//MeanC => echt schlecht


            //Otsu Binarization
            //imggray = imggray.ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Otsu, 11, new Gray(2));//Emgu.CV.Util.CvException: "OpenCV: Unknown/unsupported threshold type"
            double otsuSchwellenwert = CvInvoke.Threshold(imggray, imggray, 0, 255, ThresholdType.Otsu);
            Console.WriteLine(otsuSchwellenwert);
            //imggray = imggray.ThresholdBinary(new Gray(otsuSchwellenwert), new Gray(255));


            //Zeig das binäre Bild
            //CvInvoke.NamedWindow("Bild");
            Image<Gray, System.Byte> imggray_resize = imggray.Copy();
            CvInvoke.Resize(imggray, imggray_resize, new Size(1024, (int)(((double)img.Height / img.Width) * 1024)));
            CvInvoke.Imshow("Bild_Binaer", imggray_resize);
            CvInvoke.WaitKey(0);//warten bis eine Taste gedrückt wird sonnst geht es nicht er wird unendlich laden
            CvInvoke.DestroyWindow("Bild_Binaer"); // macht das Fenster weg


            //detect the contours            
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();//wo die Lösung hin kommt
            CvInvoke.FindContours(imggray, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);//muss External noch verändern
            /* RetrType (Contour retrieval mode):
               External	0	Retrieve only the extreme outer contours
	           List	1	Retrieve all the contours and puts them in the list
	           Ccomp	2	Retrieve all the contours and organizes them into two-level hierarchy: top level are external boundaries of the components, second level are bounda boundaries of the holes
	           Tree	3	Retrieve all the contours and reconstructs the full hierarchy of nested contours
	           Floodfill	4	Flood fill type*/

            //Malle die Konturen
            CvInvoke.DrawContours(imageDraw, contours, -1, new MCvScalar(200, 45, 45), 2);
            //contourIdx: -1 bedeutet alle Konturen zeichenen
            //MCvScalar: in welcher Farbe gemalt werden soll
            //thickness: 2 This is the thickness of contour points


            /*//Zeig die imageDraw
            Image<Gray, System.Byte> imageDraw_resize = imageDraw.Copy();
            CvInvoke.Resize(imageDraw, imageDraw_resize, new Size(1024, (int)(((double)img.Height / img.Width) * 1024)));
            CvInvoke.Imshow("Bild_KonturenAufgemalt", imageDraw_resize);
            CvInvoke.DestroyWindow("Bild_KonturenAufgemalt");
            CvInvoke.WaitKey(0);
            */


            CvInvoke.Imwrite("DrawName.png", imageDraw);

            Point[][] ablage = contours.ToArrayOfArray();
            
            
            /*
            for (int i = 0; i < ablage.GetLength(0); i++)
            {
                if (ablage[i][0] == ablage[i + 1][0])
                {

                }
            }
            */
            return contours;
        }
    }
}
