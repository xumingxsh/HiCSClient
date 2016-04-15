using System;
using System.Windows.Forms;

using HiCSControl.Control;
using HiCSCommonControl;
using HiCSCommonControl.Util;

namespace HiCSUserControl
{
    public partial class UserLogin : Form
    {
        public UserLoginControl Control { set; get; }

        public bool IsOK { set; get; }

        public UserLogin(UserLoginControl  ctrl)
        {
            InitializeComponent();
            Control = ctrl;
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            IsOK = false;
            wrap.InitControlsInfo(this, ViewConfig.ViewDefault.UserLogin_ControlInfo);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Control == null)
            {
                IsOK = false;
                this.Close();
                return;
            }
            try
            {
                wrap.Validite();
            }
            catch(Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
                return;
            }

            if (Control.Login(txtName.Text, txtPassword.Text))
            {
                IsOK = true;
                this.Close();
                return;
            }
            MsgBoxHelper.Error("登录失败，请重试！");
        }
        FormWrap wrap = new FormWrap();

    }
}
