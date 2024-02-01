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
        public InputDialog(string prompt, string? Currentprojectname)
        {
            InitializeComponent();
            Dialog_Label.Text = prompt;
            if (Currentprojectname != null)
            {
                InputTextBox.Text = Currentprojectname;
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            UserInput = InputTextBox.Text;
            if (UserInput == "")
                MessageBox.Show("Bitte einen Namen eingeben!");
            else if (UserInput.Length > 20)
                MessageBox.Show("Bitte Namen mit weniger Charakteren eingeben!");
            else if (UserInput.Any(Char.IsWhiteSpace))
                MessageBox.Show("Bitte Namen ohne Leerzeichen eingeben!");
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }
    }
}
