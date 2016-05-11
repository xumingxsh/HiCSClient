using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTest
{
    public partial class KeyBoardForm : Form
    {
        public KeyBoardForm()
        {
            InitializeComponent();
        }

        private void KeyBoardForm_Load(object sender, EventArgs e)
        {
            this.keyBoardControl1.Visible = false;
        }

        private void txtOutPut_MouseEnter(object sender, EventArgs e)
        {
            if (this.keyBoardControl1.Visible == false)
            {
                this.keyBoardControl1.Visible = true;
            }
        }

        private void txtOutPut_MouseLeave(object sender, EventArgs e)
        {
            //this.uiKeyBoard1.Visible = false;
        }
    }
}
