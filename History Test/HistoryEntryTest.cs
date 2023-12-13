using GUI_I2G;
using System.Drawing;

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
            Point[] testing = { new(444, 500), new(-59,-300), new(40, -50), new(-40,30) };
            string projName = "TestName";
            var param = new Parameter(10, 10, testing, 5, 5);
            var GPath = new string(string.Empty);
            var ImgPath = new string(string.Empty);

            //Act
            var entry = new HistoryEntry(projName,param,GPath,ImgPath);
            entry.UpdateLastOpened();

            //Assert
            Assert.AreEqual(projName, entry.projectName);
            Assert.AreEqual(param, entry.parameter);
            Assert.AreEqual(GPath, entry.gcodePath);
            Assert.AreEqual(ImgPath, entry.imagePath);
            Assert.AreEqual(DateTime.Today, entry.lastOpened);
        }
    }
}