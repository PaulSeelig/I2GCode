using GUI_I2G.Contures;
using System.Drawing;
using GUI_I2G.GCodeclasses;

namespace TestProject1
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
            
        //}
        //private static GCode[] TestObjects()
        //{
        //    GCode[] objects = new GCode[5];
        //    objects[0].AllContours[0][0] = new Curve(new Point(2, 3), new Point(3, 6), 3);

        //    return objects;
        //}
        [Test]
        public void Test1()
        {
            Assert.AreEqual(new Curve(new(2,4), new(4,9), 4, Direction.Glockwise), new Curve(new(2,5), new(3,9), 4, Direction.Glockwise));
           // Assert.That(Is.EqualTo(3), Is.EqualTo(2));
            //Curve c = new(new(3, 4), new(4, 7), 4.3, Direction.CounterGlockwise);
            ////GCode[] g = TestObjects();
            //Console.WriteLine("Hallo");
            //Console.ReadKey();
            //Assert.Pass("Hello");

        }
    }
}