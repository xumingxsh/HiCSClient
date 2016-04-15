using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiCSUserControl.Test
{
    public partial class ProcessMaterialTest1 : Form
    {
        public ProcessMaterialTest1()
        {
            InitializeComponent();
        }

        private void ProcessMaterialTest1_Load(object sender, EventArgs e)
        {
            uiProcessMaterial.SetProcess("P1", "1");
        }
    }
}
