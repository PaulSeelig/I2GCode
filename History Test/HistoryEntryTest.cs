using GUI_I2G;

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
            string projName = "TestName";
            var param = new Parameter();
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