using Emgu.CV;
using Emgu.CV.Structure;
using GUI_I2G.Contures;
using GUI_I2G.GCodeclasses;
using GUI_I2G.Tests;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GUI_I2G
{
    public partial class I2Gcode : Form
    {
        // zoom level is needed for the SetZoomLevel Method, defines the speed of zooming
        private int zoomLevel = 100;
        // "a" is used to download the GCode, it represents the numbers of GCodes created
        private int a = 0;
        // this imagepath is the path of the image that gets dropped intp the PictureBox, its used to draw the contours in button1_Click
        private string imagepath;

        private Image<Rgb, System.Byte> rgbimage;

        private double depth;

        private History history = new History();

        private double epsilon = 3.4;

        public I2Gcode()
        {
            InitializeComponent();
            history.OpenHistoryFromFile(@".\History.json");
            // allows to drop pictures into the PictureBox 
            pB_DragDrop.AllowDrop = true;
            // this Eventhandler is used if one hovers over the PictureBox
            pB_DragDrop.DragEnter += new DragEventHandler(pB_DragDrop_DragEnter);
            // this Eventhandler is used after a Drag and drop process is complete
            pB_DragDrop.DragDrop += new DragEventHandler(pB_DragDrop_DragDrop);
            // this is needed bcs in VS2022 this event does not exist until its manually added
            pB_DragDrop.MouseWheel += PB_DragDrop_MouseWheel;
            //CreateHistoryList();


        }
        // sets the zoom level of the picture box 
        private void SetZoomLevel()
        {
            // zoom factor is calculated based on zoom level (100) 
            float zoomFactor = zoomLevel / 100f;
            // calculates the new width of the PictureBox after each Zoom
            int newWidth = (int)((pB_DragDrop.Image?.Width ?? 821) * zoomFactor);
            // calculates the new height of the PictureBox after each Zoom
            int newHeight = (int)(pB_DragDrop.Image?.Height ?? 201 * zoomFactor);

            // resize the PictureBox
            pB_DragDrop.Size = new Size(newWidth, newHeight);
            // centers the image in the PictureBox
            //pB_DragDrop.Location = new Point((pB_DragDrop.Image.Width - pB_DragDrop.Width) / 2, (pB_DragDrop.Image.Height - pB_DragDrop.Height) / 2);
        }
        // Checks if the input from the Coordinate TextBox gets parsed into double
        private void CheckInput(TextBox textBox, out double value)
        {
            if (double.TryParse(textBox.Text, out value))
            { }
            else
            {
                throw new FormatException("Ungültige Eingabe");
            }
        }
        private string[] GCodeTextBox(Parameter p)
        {
            GCode gCode = new GCode();
            gCode = GCodeGenerator.GenerateGCode(Contour.ContourExtractor(Contour.Konturfinder(rgbimage), epsilon), p);
            return gCode.GCodeLines;
        }

        // Downloads the GCode as .txt file to MyDocuments
        public void DownloadGcode()
        {
            // takes the GCode from the TextBox
            string GCodeVorschau = tB_showGCode.Text;
            // takes the folder path to MyDocuments
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // puts a file named "GCode .txt" at the destinaetd folderpath
            string filePath = Path.Combine(folderPath, $"Gcode{a}.txt");
            // writes the GCode into the file
            File.WriteAllText(filePath, GCodeVorschau);
            // opens the explorer and selects the saved file
            Process.Start("explorer.exe", "/select," + filePath);

            //Diplays History inside ViewBox
            UpdateHistory();
        }
        private void PB_DragDrop_MouseWheel(object? sender, MouseEventArgs e)
        {
            //if (e.Delta > 0 && zoomLevel < 200) // Zoom in
            //{
            //    zoomLevel += 10;
            //    pB_DragDrop.BringToFront();
            //}
            //else if (e.Delta < 0 && zoomLevel > 10) // Zoom out
            //{
            //    zoomLevel -= 10;
            //    pB_DragDrop.SendToBack();
            //}
            //SetZoomLevel();
        }
        //benenn die doch pls
        public void GCodeGenBtn_Click(object sender, EventArgs e)       //Button zum GCode generieren 
        {
            try
            {

                CheckInput(tB_X, out double xkoo1);
                CheckInput(tB_Y, out double ykoo1);
                CheckInput(tB_Z, out double zkoo1);
                CheckInput(tB_depth, out depth);
                CheckInput(tB_aproxy, out epsilon);
                Parameter p = new();
                p.Eckpunkt[0] = xkoo1;
                p.Eckpunkt[1] = ykoo1;
                p.Eckpunkt[2] = zkoo1;
                p.CuttingDepth = depth;

                //MessageBox.Show("Ihre Eingaben, waren korrekt, Ihr G-Code wird nun generiert, dies könnte einige Zeit in Anspruch nehmen!");

                rgbimage = new(imagepath); //hier wird das rgbimage erstellt
                string name = Path.GetFileName(imagepath); //damit man die Bilder speichern kann unter den namen

                CvInvoke.DrawContours(rgbimage, Contour.Konturfinder(rgbimage), -1, new MCvScalar(200, 45, 45), 2);//hier werden die konturen auf ein rgb bild gemalt

                CvInvoke.Imwrite("draw" + name, rgbimage);//um das Bild mit den Konturen zuspeichern + das konvertieren von emgu image zum draw image
                Image save = Image.FromFile("draw" + name);//keine schöne methode (fürs konvertieren) habe aber nichts auf die schnelle gefunden werde das nachträglich machen                

                pB_DragDrop.Image = save;

                tB_showGCode.Lines = GCodeTextBox(p);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ungültige Eingabe, bitte geben Sie die Koordinaten, eines Eckpunkts Ihres Werkstücks in mm ein.");
            }
        }
        private void pB_DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void pB_DragDrop_DragDrop(object sender, DragEventArgs e)
        {
            lbl_DragDrop.Visible = false;
            if (e.Data != null)
            {
                string files = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                if (files != null && files.Length > 0)
                {
                    pB_DragDrop.ImageLocation = files;
                    imagepath = files;
                }
            }
        }
        private void pB_DragDrop_Scale()
        {
            if (pB_DragDrop.Image != null)
            {
                pB_DragDrop.SizeMode = PictureBoxSizeMode.Zoom;
                //pB_DragDrop.Size = this.Size;
            }
        }
        private void I2Gcode_Resize(object sender, EventArgs e)
        {
            pB_DragDrop_Scale();
        }
        private void btn_DownloadGCode_Click(object sender, EventArgs e)
        {
            DownloadGcode();
            a++;
        }
        private void pB_DragDrop_SizeChanged(object sender, EventArgs e)
        {
            pB_DragDrop_Scale();
        }

        private void pB_DragDrop_DragOver(object sender, DragEventArgs e)
        {
            lbl_DragDrop.Visible = false;
        }

        private void pB_DragDrop_DragLeave(object sender, EventArgs e)
        {
            lbl_DragDrop.Visible = true;
        }

        private void lbl_DragDrop_Click(object sender, EventArgs e)
        {

        }

        private void tB_showGCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void pB_DragDrop_Click(object sender, EventArgs e)
        {

        }

        private void UpdateHistory()
        {
            HistoryDisplayBox.BeginUpdate();

            string[] names = new string[5];
            DateTime[] dates = new DateTime[5];
            int i = 0;

            history.GetLastOpened(names, dates);

            foreach (string name in names)
            {
                ListViewItem item = new ListViewItem(new[] { name, dates[i].ToString() });
                HistoryDisplayBox.Items.Add(item);
                i++;
            }
            HistoryDisplayBox.EndUpdate();
        }

        private void HistoryDisplayBox_Enter(object sender, EventArgs e)
        {

        }
    }
}