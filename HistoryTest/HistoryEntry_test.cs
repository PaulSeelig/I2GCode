using GUI_I2G.History;
using System.Reflection.Metadata;

namespace HistoryTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //a smth idk
            string projectName = "test 2";
            Parameter parameter = new Parameter();
            string GcPath = "test Path";
            string ImgPath = "test Path";
            HistoryEntry entry = new HistoryEntry(projectName, parameter, GcPath, ImgPath);
        }

        [Test]
        public void History_projectName_exists()
        {
            
            //Act
            //Assert
            Assert.Pass();
        }

        [Test]
        public void History_projectName_notExist()
        {

        }

        [Test]
        public void History_parameter_exist()
        {

        }

        [Test]
        public void History_parameter_notExist()
        {

        }

        [Test]
        public void History_LastOpened_isToday()
        {

        }

        [Test]
        public void History_LastOpened_isNotToday()
        {

        }

        [Test]
        public void History_LastOpened_GCPath()
        {

        }

        [Test]
        public void History_LastOpened_notGCPath()
        {

        }

        [Test]
        public void History_LastOpened_ImgPath()
        {

        }


        [Test]
        public void History_LastOpened_NotImgPath()
        {

        }
    }
}