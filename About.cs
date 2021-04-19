using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dothings = Tombala.DoThings;

namespace Tombala
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            DoThings dothings = new DoThings();
            surumLabel.Text = "E-Tombala v" + dothings.surum;
        }
    }
}
