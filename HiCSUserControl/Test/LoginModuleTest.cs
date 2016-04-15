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
    public partial class LoginModuleTest : Form
    {
        public LoginModuleTest()
        {
            InitializeComponent();
        }

        private void LoginModuleTest_Load(object sender, EventArgs e)
        {
            userLoginModule1.Init();
        }
    }
}
