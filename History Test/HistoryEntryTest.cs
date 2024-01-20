using GUI_I2G;
using GUI_I2G.GCodeclasses;
using System.Drawing;

//Authored by Paul Seelig s0578706
namespace History_Test
{
    public class HistoryEntryTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorTest_All_All()
        {
            //Assemble
            double[] testing = { 304, 34, 434 };
            string projName = "TestName";
            var param = new Parameter(10, 10, testing, 5, 5);
            var GCode = new GCode();
            var ImgPath = new string(string.Empty);

            //Act
            var entry = new HistoryEntry(projName,param,GCode,ImgPath);
            entry.UpdateLastOpened();

            //Assert
            Assert.AreEqual(projName, entry.projectName);
            Assert.AreEqual(param, entry.parameter);
            Assert.AreEqual(GCode, entry.Gcode);
            Assert.AreEqual(ImgPath, entry.imagePath);
            Assert.AreEqual(DateTime.Today, entry.lastOpened.Date);
        }
    }
}