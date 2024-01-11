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

        private double depth; 
        public I2Gcode()
        {
            InitializeComponent();
            // allows to drop pictures into the PictureBox 
            pB_DragDrop.AllowDrop = true;
            // this Eventhandler is used if one hovers over the PictureBox
            pB_DragDrop.DragEnter += new DragEventHandler(pB_DragDrop_DragEnter);
            // this Eventhandler is used after a Drag and drop process is complete
            pB_DragDrop.DragDrop += new DragEventHandler(pB_DragDrop_DragDrop);
            // this is needed bcs in VS2022 this event does not exist until its manually added
            pB_DragDrop.MouseWheel += PB_DragDrop_MouseWheel;
        }
        // sets the zoom level of the picture box 
        private void SetZoomLevel()
        {
            // zoom factor is calculated based on zoom level (100) 
            float zoomFactor = zoomLevel / 100f;
            // calculates the new width of the PictureBox after each Zoom
            int newWidth = (int)(pB_DragDrop.Image.Width * zoomFactor);
            // calculates the new height of the PictureBox after each Zoom
            int newHeight = (int)(pB_DragDrop.Image.Height * zoomFactor);

            // resize the PictureBox
            pB_DragDrop.Size = new Size(newWidth, newHeight);
            // centers the image in the PictureBox
            pB_DragDrop.Location = new Point((pB_DragDrop.Parent.Width - pB_DragDrop.Width) / 2, (pB_DragDrop.Parent.Height - pB_DragDrop.Height) / 2);
        }
        // Checks if the input from the Coordinate TextBox gets parsed into double
        private void CheckInput(TextBox textBox, out double value)       
        {
            if (double.TryParse(textBox.Text, out value))
            {
                // if parsing succees,generate g code 
                GCodeTextBox(); 
            }
            else
            {
                // if parsing succees,generate g code 
                throw new FormatException("Ungültige Eingabe");
            }
        }
        private void GCodeTextBox()
        {
            Parameter p = new Parameter();
            p.CuttingDepth = depth-1;
            GCodeGenerator.GenerateGCode(Contour.ContourExtractor(Contour.Konturfinder(imagepath)),p);
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
        }
        private void PB_DragDrop_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && zoomLevel < 200) // Zoom in
            {
                zoomLevel += 10;
                pB_DragDrop.BringToFront();
            }
            else if (e.Delta < 0 && zoomLevel > 10) // Zoom out
            {
                zoomLevel -= 10;
                pB_DragDrop.SendToBack();
            }
            SetZoomLevel();
        }
        public void button1_Click(object sender, EventArgs e)       //Button zum GCode generieren
        {
            try
            {
                CheckInput(tB_X, out double xkoo1);
                CheckInput(tB_Y, out double ykoo1);
                CheckInput(tB_Z, out double zkoo);
                CheckInput(tB_depth, out double depth);

                MessageBox.Show("Ihre Eingaben, waren korrekt, Ihr G-Code wird nun generiert, dies könnte einige Zeit in Anspruch nehmen!");

                Image<Rgb, System.Byte> draw = new(imagepath);
                CvInvoke.DrawContours(draw, Contour.Konturfinder(imagepath), -1, new MCvScalar(200, 45, 45), 2);
                CvInvoke.Imwrite("drawtest.png", draw);//"draw"+name
                Image save = Image.FromFile("drawtest.png");
                pB_DragDrop.Image = save;
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
    }
}