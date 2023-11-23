using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Tests
{
    internal class Konturerkennung_Test_1
    {
        //Eigenschaften
        public int Schwellenwert { get; set; }//threshold
                                              //Methoden
        public VectorOfVectorOfPoint Konturen()
        {

            Mat img = CvInvoke.Imread("Bild.jpg", Emgu.CV.CvEnum.ImreadModes.Color);//um Objekt Matrix vom Bild zu erstellen

            Image<Gray, System.Byte> imggray = new Image<Gray, System.Byte>(img);//hier wird in Grayscale Format konvertiert
                                                                                 //System.Byte für die Tiefe (jeder Pixel hat 8Bit um eine graufrabe(die farbe habe ich vorher gennant) zu sein)
                                                                                 //Simple Thresholding wo man ein Threshold (Schwellenwert) angeben muss (eine Grenze)

            //imggray = imggray.ThresholdBinary(new Gray(Schwellenwert), new Gray(Schwellenwert + 1));
            //imggray = imggray.ThresholdBinaryInv(new Gray(Schwellenwert), new Gray(Schwellenwert + 1));<=ist gedreht

            //Adaptive Thresholding

            imggray = imggray.ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, 11, new Gray(2));//11 ist die kasten größe ist auch (ca.11-13)standart (bei bestimmten Bilder sollte man das anpassen können(oder selbstständig))
                                                                                                                                                                     //es gibt noch eine andere Variante

            //wie sieht es aus nach Thresholding
            //CvInvoke.Imshow("Bild.jpg", imggray);

            //detect the contours            
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();//wo die Lösung hin kommt

            CvInvoke.FindContours(imggray, contours, null, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            return contours;
        }
    }
}
