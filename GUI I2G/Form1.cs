using Emgu.CV;
using Emgu.CV.Structure;
using GUI_I2G.Contures;
using GUI_I2G.GCodeclasses;
using GUI_I2G.Tests;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GUI_I2G
{
    public partial class I2Gcode : Form
    {
        private int zoomLevel = 100;
        private int a = 0;
        public string imagepfad;
        public I2Gcode()
        {            
            InitializeComponent();
            // ermöglicht Drag und Drop
            pB_DragDrop.AllowDrop = true;
            // Zuweisung für Eventhandler, wird benutzt, wenn man mit einem Bild über die PB hovert
            pB_DragDrop.DragEnter += new DragEventHandler(pB_DragDrop_DragEnter);
            // Zuweisung für EventHandler, wird benutzt, wenn ein Drag and Drop vorgang abgeschlossen ist
            pB_DragDrop.DragDrop += new DragEventHandler(pB_DragDrop_DragDrop);

            pB_DragDrop.MouseWheel += PB_DragDrop_MouseWheel;
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
        private void SetZoomLevel()
        {
            float zoomFactor = zoomLevel / 100f;
            int newWidth = (int)(pB_DragDrop.Image.Width * zoomFactor);
            int newHeight = (int)(pB_DragDrop.Image.Height * zoomFactor);

            // Setze die Größe der PictureBox neu und zentriere das Bild
            pB_DragDrop.Size = new Size(newWidth, newHeight);
            pB_DragDrop.Location = new Point((pB_DragDrop.Parent.Width - pB_DragDrop.Width) / 2, (pB_DragDrop.Parent.Height - pB_DragDrop.Height) / 2);
        }

        private void EingabenPrüfer(TextBox textBox, Label label, out double value)       // Methode für btn1
        {
            if (double.TryParse(textBox.Text, out value))
            {               
                GCodeTextBox();   //GCode in TB anzeigen
            }
            else
            {
                throw new FormatException("Ungültige Eingabe");
                // evtl Fenster neuladen, Programm neu starten, nichts machen? 
            }
        }
        private void GCodeTextBox()
        {
            GCodeGenerator gCode = new GCodeGenerator();
            tB_showGCode.Text = gCode.ToString();
            Parameter p = new Parameter();
            //tB_showGCode.Text = GCodeGenerator.GenerateGCode(,p);
        }

        public void button1_Click(object sender, EventArgs e)       //Button zum GCode generieren
        {
            try
            {
                EingabenPrüfer(tB_X, lbl_X, out double xkoo1);
                EingabenPrüfer(tB_Y, lbl_Y, out double ykoo1);
                EingabenPrüfer(tB_Z, lbl_Z, out double zkoo);
                EingabenPrüfer(tB_depth, lbl_depth, out double depth);

                MessageBox.Show("Ihre Eingaben, waren korrekt, Ihr G-Code wird nun generiert, dies könnte einige Zeit in Anspruch nehmen!");
                
                Image<Rgb, System.Byte> draw = new(imagepfad);
                CvInvoke.DrawContours(draw, Contour.Konturfinder(imagepfad), -1, new MCvScalar(200, 45, 45), 2);
                string[] imageteile = imagepfad.Split("//");
                string name = imageteile.Last();
                CvInvoke.Imwrite("drawtest.png", draw);//"draw"+name
                Image save = Image.FromFile("drawtest.png");
                pB_DragDrop.Image = save;
            }
            catch (FormatException)
            {
                MessageBox.Show("Ungültige Eingabe, bitte geben Sie die Koordinaten, eines Eckpunkts Ihres Werkstücks in mm ein.");
            }
            // oder hier Methode aufrufen & Koordinaten übergeben
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void I2Gcode_Load(object sender, EventArgs e)
        {

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
        private void pB_DragDrop_Click(object sender, EventArgs e)
        {

        }

        private void I2Gcode_Resize(object sender, EventArgs e)
        {
            pB_DragDrop_Scale();
        }

        private void I2Gcode_DragDrop(object sender, DragEventArgs e)
        {           
            if (e.Data != null)
            {
                string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files != null && files.Length > 0)
                {
                    imagepfad = files[0];
                    pB_DragDrop.Image = Image.FromFile(imagepfad);
                    pB_DragDrop_Scale();
                }
            }
        }
        private void I2Gcode_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lbl_Z_Click(object sender, EventArgs e)
        {

        }

        private void btn_DownloadGCode_Click(object sender, EventArgs e)
        {
            DownloadGcode();
            a++;
        }
        public void DownloadGcode() 
        {
            string GCodeVorschau = tB_showGCode.Text;
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, $"Gcode{a}.txt");
            File.WriteAllText(filePath, GCodeVorschau);
            Process.Start("explorer.exe", "/select," + filePath);
        }

        private void pB_DragDrop_SizeChanged(object sender, EventArgs e)
        {
            pB_DragDrop_Scale();
        }
    }
}