using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.GCodeclasses
{
    public partial class IGCCKomponent : Component
    {
        public IGCCKomponent()
        {
            InitializeComponent();
        }

        public IGCCKomponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
