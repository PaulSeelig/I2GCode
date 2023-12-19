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
            Curve testCurve = new Curve(new Point(10,0), new Point(0,10), 10, Direction.Glockwise);

            //Act
            testCurve.Length = 10; //this looks stupid but might do it

            //Assert
            Assert.AreEqual(31.416, testCurve.Length);
        }
    }
}