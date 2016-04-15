using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiCSFormTest
{
    public partial class ProcessMaterial : Form
    {
        public ProcessMaterial()
        {
            InitializeComponent();
        }

        private void ProcessMaterial_Load(object sender, EventArgs e)
        {
            processMaterial1.SetProcess("P1", "1");
        }
    }
}
