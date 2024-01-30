using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G
{
    public partial class I2Gcode : Form
    {
        private void ContourListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (sender == HistoryDisplayBox)
                    DeleteButton_Click(this, EventArgs.Empty);
                else
                    btn_ContLösch_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == HistoryDisplayBox)
                {
                    HistoryDisplayBox_Enter(sender, e);
                }
            }
        }
    }
}
