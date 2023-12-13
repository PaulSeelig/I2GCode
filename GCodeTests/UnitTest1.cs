using GUI_I2G.GCodeclasses;
using GUI_I2G;
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
            Assert.That(new GCode(), Is.Not.EqualTo(GCodeGenerator.GenerateGCode(null, new Parameter())));
            Assert.Pass();
        }
    }
}