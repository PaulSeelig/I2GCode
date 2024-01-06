using GUI_I2G.Contures;
using System.Drawing;

namespace ContourTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LengthTest()
        {
            //Assemble
            Curve testCurve = new(new Point(10,0), new Point(0,10), 10, Direction.Glockwise);
            //Assert
            Assert.AreEqual(15.708, testCurve.Length);
        }
    }
}