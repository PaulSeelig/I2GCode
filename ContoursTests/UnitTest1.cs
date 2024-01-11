using Emgu.CV.Structure;
using Emgu.CV;
using GUI_I2G.Contures;
using System.Drawing;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace ContourTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Test authored by Leo
        [Test]
        public void KontourFindTest()
        {
            //Arrange
            Image<Gray, System.Byte> image = new Image<Gray, System.Byte>("TestBild.png");

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            //Act        
            double otsuSchwellenwert = CvInvoke.Threshold(image, image, 0, 255, ThresholdType.Otsu);
            
            CvInvoke.FindContours(image, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

            Point[][] konturen = contours.ToArrayOfArray();           
            //Assert
            Assert.AreEqual(new Point(0, 0), konturen[0][0]);
            Assert.AreEqual(new Point(430,382), konturen.Last().Last());
        }
    }
}