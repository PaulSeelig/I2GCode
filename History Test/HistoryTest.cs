using GUI_I2G;
using NuGet.Frameworks;
using System.Drawing;

namespace History_Test
{
    public class HistoryTest
    {
        private History history;
        [SetUp]
        public void Setup()
        {
            //Assemble
            Point[] AllEckpunkte = { new(2,3), new(3,4), new(4,7)};
            Point[] AllEckpunkte2 = { new(2, 3), new(3, 5), new(5, 6) };
            history = new History();
            HistoryEntry project1 = new HistoryEntry("Lampe", new Parameter(7,10, ref AllEckpunkte,5,4), "TestValue", "image");
            HistoryEntry project2 = new HistoryEntry("Ständer", new Parameter(10,7, ref AllEckpunkte,4,5), "gcode", "image");
            HistoryEntry project3 = new HistoryEntry("Kabel", new Parameter(7,5, ref AllEckpunkte,10,4), "gcode", "image");
            HistoryEntry project4 = new HistoryEntry("Stecker", new Parameter(5,7, ref AllEckpunkte,4,10), "gcode", "image");
            HistoryEntry project5 = new HistoryEntry("Knopf", new Parameter(5,4, ref AllEckpunkte2,10,7), "gcode", "image");

            //Act
            history.SaveGcodeProject(project1);
            history.SaveGcodeProject(project2);
            history.SaveGcodeProject(project3);
            history.SaveGcodeProject(project4);
            history.SaveGcodeProject(project5);
        }

        [Test]
        public void GetEntry_Entry_All()
        {
            //Act
            HistoryEntry entry = history.GetEntry("Lampe");

            //Assert
            Assert.That(entry.gcodePath == "TestValue");
        }

        [Test]
        public void SaveGcodeProject_Added_All()
        {
            //Assemble
            Point[] AllEckpunkte = { new(2,3), new(2,4), new(4,6), new(2,6)};
            HistoryEntry project6 = new HistoryEntry("Platte", new Parameter(4,5,ref AllEckpunkte,7,10), "gcode", "image");

            //Act
            history.SaveGcodeProject(project6);

            //Assert
            Assert.That(history.GetHistoryCount() == 6);
            Assert.That(history.GetEntry("Platte").parameter.TableWidth == 4);
        }

        [Test]
        public void HistoryCount_All()
        {
            Assert.That(history.GetHistoryCount() == 5);
        }

        [Test]
        public void GetHistory_OrderByLastOpened_SaveCHanges()
        {
            //Act
            HistoryEntry entry = history.GetEntry("Stecker");
            entry.parameter.TableWidth = 4;
            history.SaveChangesToProject(entry);
            List<HistoryEntry> entries = history.GetHistoryByLast();

            //Assert
            Assert.That(history.GetHistoryCount(), Is.EqualTo(entries.Count));
            Assert.IsTrue(history.GetEntry("Stecker") == entries[0]);
            Assert.IsTrue(history.GetEntry("Stecker").parameter.TableWidth == 4);
        }

        /// <summary>
        /// if this test fails its because the filepath is not user specific. 
        /// idk how to do that over git
        /// </summary>
        [Test]
        public void SaveProject_TestingCount()
        {
            //Assemble
            string jsonFilePath = @".\History.json";
            //Act
            history.SaveHistoryToFile(jsonFilePath);
            history.OpenHistoryFromFile(jsonFilePath);

            //Assert
            Assert.That(history.GetHistoryCount(), Is.EqualTo(5));
            Assert.That(history.GetEntry("Stecker").parameter.Tool1.Diameter == 5);
        }
    }
}
