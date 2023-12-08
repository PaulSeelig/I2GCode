using GUI_I2G;

namespace History_Test
{
    public class HistoryTest
    {
        private History history;
        [SetUp]
        public void Setup()
        {
            //Assemble
            history = new History();
            HistoryEntry project1 = new HistoryEntry("Lampe", new Parameter(), "TestValue", "image");
            HistoryEntry project2 = new HistoryEntry("Ständer", new Parameter(), "gcode", "image");
            HistoryEntry project3 = new HistoryEntry("Kabel", new Parameter(), "gcode", "image");
            HistoryEntry project4 = new HistoryEntry("Stecker", new Parameter(), "gcode", "image");
            HistoryEntry project5 = new HistoryEntry("Knopf", new Parameter(), "gcode", "image");

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
            HistoryEntry project6 = new HistoryEntry("Platte", new Parameter(), "gcode", "image");

            //Act
            history.SaveGcodeProject(project6);

            //Assert
            Assert.That(history.GetHistoryCount() == 6);
        }

        [Test]
        public void HistoryCount_All()
        {
            Assert.That(history.GetHistoryCount() == 5);
        }

        [Test]
        public void GetHistory_OrderByLastOpened()
        {
            //Act
            HistoryEntry entry = history.GetEntry("Stecker");
            history.SaveChangesToProject(entry);
            List<HistoryEntry> entries = history.GetHistoryByLast();

            //Assert
            Assert.That(history.GetHistoryCount(), Is.EqualTo(entries.Count));
            Assert.IsTrue(history.GetEntry("Knopf") == entries[0]);
        }

    }
}
