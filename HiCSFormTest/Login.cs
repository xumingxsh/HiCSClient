using System;
using System.Windows.Forms;

namespace HiCSFormTest
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            uiLogin.Init();
            uiLogin.SetNotify(() => {
                HiCSUIHelper.MsgBoxHelper.Notiy("所有用户都注销了,需要关闭未完成的工序!");
            });
        }
    }
}
