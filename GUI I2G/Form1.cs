using System.Windows.Forms;

namespace GUI_I2G
{
    public partial class I2Gcode : Form
    {
        public I2Gcode()
        {
            InitializeComponent();
            pB_DragDrop.AllowDrop = true;
            pB_DragDrop.DragEnter += new DragEventHandler(pB_DragDrop_DragEnter);
            pB_DragDrop.DragDrop += new DragEventHandler(pB_DragDrop_DragDrop);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void I2Gcode_Load(object sender, EventArgs e)
        {

        }

        private void pB_DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                pB_DragDrop.ImageLocation = files[0];
            }
        }
        private void pB_DragDrop_Scale()
        {
            if (pB_DragDrop.Image != null)
            {
                pB_DragDrop.SizeMode = PictureBoxSizeMode.Zoom;
                pB_DragDrop.Size = this.ClientSize;
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
            if (files.Length > 0)
            {
                string imagePath = files[0];
                pB_DragDrop.Image = Image.FromFile(imagePath);
                pB_DragDrop_Scale();
            }
        }
    }
}