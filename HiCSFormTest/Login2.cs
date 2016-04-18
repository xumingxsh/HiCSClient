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
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();
        }

        private void Login2_Load(object sender, EventArgs e)
        {
            loginModul1.Init();
            loginModul1.SetNotify(() =>
            {
                HiCSCommonControl.Util.MsgBoxHelper.Notiy("所有用户都注销了,需要关闭未完成的工序!");
            });
        }
    }
}
