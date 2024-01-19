using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_I2G
{
    public partial class InputDialog : Form
    {
        public string UserInput { get; set; }
        public InputDialog(string prompt)
        {
            InitializeComponent();
            Dialog_Label.Text = prompt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            UserInput = InputTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
