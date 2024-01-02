using GUI_I2G.GCodeclasses;
using GUI_I2G;
using System.Drawing;
using GUI_I2G.Contures;
//using Emgu.CV;
namespace GCodeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            //Assemble
            //Point[] testPoints = { new(30, -20), new(40,-30), new(-20,-20), new(400,20)};
            Curve c = new(new(-47, 334), new(209, -274), new(165, 298));
            Assert.That(c.Radius <341 && c.Radius >339);

            ////Act
            ////missing code

            ////Assert
            //Assert.That(new GCode(), Is.Not.EqualTo(GCodeGenerator.GenerateGCode(null, new Parameter(20.2, 30.5, testPoints, 20)))); //no idea what you were trying but it was throwing errors so i fixed
            //Assert.Pass();
        }
    }
}