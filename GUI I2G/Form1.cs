using System.Windows.Forms;

namespace GUI_I2G
{
    public partial class I2Gcode : Form
    {
        public I2Gcode()
        {
            InitializeComponent();
            // erm�glicht Drag und Drop
            pB_DragDrop.AllowDrop = true;
            // Zuweisung f�r Eventhandler, wird benutzt, wenn man mit einem Bild �ber die PB hovert
            pB_DragDrop.DragEnter += new DragEventHandler(pB_DragDrop_DragEnter);
            // Zuweisung f�r EventHandler, wird benutzt, wenn ein Drag and Drop vorgang abgeschlossen ist
            pB_DragDrop.DragDrop += new DragEventHandler(pB_DragDrop_DragDrop);
        }
        private void EingabenPr�fer(TextBox textBox, Label label, out double value)       // Methode f�r btn1
        {
            if (double.TryParse(textBox.Text, out value))
            {
                // entweder hier Methode aufrufen & Koordinaten �bergeben
            }
            else
            {
                throw new FormatException("Ung�ltige Eingabe");
                // evtl Fenster neuladen, Programm neu starten, nichts machen? 
            }
        }

        public void button1_Click(object sender, EventArgs e)       //Button zum GCode generieren
        {
            try
            {
                EingabenPr�fer(tB_X, lbl_X, out double xkoo1);
                EingabenPr�fer(tB_Y, lbl_Y, out double ykoo1);
                EingabenPr�fer(tB_Z, lbl_Z, out double zkoo);
                EingabenPr�fer(tB_depth, lbl_depth, out double depth);
                MessageBox.Show("Ihre Eingaben, waren korrekt, Ihr G-Code wird nun generiert, dies k�nnte einige Zeit in Anspruch nehmen!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Ung�ltige Eingabe, bitte geben Sie die Koordinaten, eines Eckpunkts Ihres Werkst�cks in mm ein.");
            }
            // oder hier Methode aufrufen & Koordinaten �bergeben
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
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    pB_DragDrop.ImageLocation = files[0];
                }
            }
        }
        private void pB_DragDrop_Scale()
        {
            if (pB_DragDrop.Image != null)
            {
                pB_DragDrop.SizeMode = PictureBoxSizeMode.Zoom;
                pB_DragDrop.Size = this.Size;
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                string imagePath = files[0];
                pB_DragDrop.Image = Image.FromFile(imagePath);
                pB_DragDrop_Scale();
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
    }
}