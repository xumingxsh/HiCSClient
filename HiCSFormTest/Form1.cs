using System;
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
