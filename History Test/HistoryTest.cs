using GUI_I2G;
using GUI_I2G.GCodeclasses;
using NuGet.Frameworks;
using System.Drawing;

//Allmost everything done by Paul Seelig s0578706 small part by Pierre Wiele
namespace History_Test
{
    public class HistoryTest
    {
        private History history;
        private readonly GCode allGcode =new GCode();
        [SetUp]
        public void Setup()
        {
            //Assemble
            double[] AllEckpunkte = { 203, 304, 407};
            double[] AllEckpunkte2 = { 203, 435, 455 };
            
            history = new History();
            HistoryEntry project1 = new("Lampe", new Parameter(7,10, AllEckpunkte,5,4), allGcode, "image");
            HistoryEntry project2 = new("Ständer", new Parameter(10,7, AllEckpunkte,4,5), allGcode, "image");
            HistoryEntry project3 = new("Kabel", new Parameter(7,5, AllEckpunkte,10,4), allGcode, "image");
            HistoryEntry project4 = new("Stecker", new Parameter(5,7, AllEckpunkte,4,10), allGcode, "image");
            HistoryEntry project5 = new("Knopf", new Parameter(5,4, AllEckpunkte2,10,7), allGcode, "image");

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
            //Assemble
            HistoryEntry entry = history.GetEntryByName("Lampe");

            //Assert
            Assert.That(entry.projectName == "Lampe");
            Assert.That(entry.parameter.CuttingDepth == 5);
            //Assert.That(entry.Gcode.GCodeLines[0] == allGcode.GCodeLines[0]);
            //Assert.That(entry.Gcode.GCodeLines[^1] == allGcode.GCodeLines[^1]);
            // Assert.That(entry.parameter.Eckpunkt[0] == new Point(2, 3));
        }

        [Test]
        public void SaveGcodeProject_Added_All()
        {
            //Assemble
            double[] AllEckpunkte = {232, 434, 767 };
            HistoryEntry project6 = new("Platte", new Parameter(4,5, AllEckpunkte,7,10), allGcode, "image");
            HistoryEntry project7 = new("Knopf", new Parameter(4, 5, AllEckpunkte, 7, 10), allGcode, "image");

            //Act
            history.SaveGcodeProject(project6);

            //Assert
            Assert.That(history.GetHistoryCount() == 6);
            Assert.That(history.GetEntryByName("Platte").parameter.TableWidth == 4);
            Assert.That(history.GetEntryByIndex(4).parameter.TableWidth, Is.EqualTo(5));
        }

        [Test]
        public void HistoryCount_All()
        {
            Assert.That(history.GetHistoryCount() == 5);
        }


        /// <summary>
        /// if this test fails its because the filepath is not user specific. 
        /// idk how to do that over git
        /// </summary>
        [Test]
        public void SaveProject_TestingSavedDate()
        {
            //Assemble
            string jsonFilePath = @".\History.json";

            //Act
            history.SaveHistoryToFile(jsonFilePath);
            history.OpenHistoryFromFile(jsonFilePath);     

            //Assert
            //Item Saving
            Assert.That(history.GetHistoryCount(), Is.EqualTo(5));
            //Test if GCode got saved properly
            //Assert.That(history.GetEntry("Lampe").Gcode.GCodeLines[0] == "%");
            //Assert.That(history.GetEntry("Lampe").Gcode.GCodeLines[^1] == "G28 %");
            //Assert.That(history.GetEntry("Lampe").Gcode.GCodeLines.Length == 44);
            //Test if Parameter object saved
            Assert.That(history.GetEntryByName("Stecker").parameter.Tool1.Diameter == 5);
            Assert.That(history.GetEntryByName("Knopf").parameter.Tool1.Name, Is.EqualTo("Tool1"));
            Assert.That(history.GetEntryByName("Knopf").parameter.Eckpunkt != null); 
            Assert.That(history.GetEntryByName("Knopf").parameter.CuttingDepth == 10); 
        }
    }
}
