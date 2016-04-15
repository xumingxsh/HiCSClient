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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessMaterial form = new ProcessMaterial();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessMaterial_DBClick form = new ProcessMaterial_DBClick();
            form.Show();
        }
    }
}
