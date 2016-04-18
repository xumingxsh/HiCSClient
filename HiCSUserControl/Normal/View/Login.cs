using System;
using System.Windows.Forms;

using HiCSCommonControl;
using HiCSCommonControl.Util;

namespace HiCSUserControl
{
    partial class Login : Form
    {
        /// <summary>
        /// 用户管理对象
        /// </summary>
        public UserLoginImpl Control { set; get; }

        public bool IsOK { set; get; }

        public Login(UserLoginImpl ctrl)
        {
            InitializeComponent();
            Control = ctrl;
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
            catch (Exception ex)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsOK = false;
            this.Close();
        }

        FormWrap wrap = new FormWrap();

        private void Login_Load(object sender, EventArgs e)
        {
            IsOK = false;
            wrap.InitControlsInfo(this, ViewConfig.ViewDefault.UserLogin_ControlInfo);

        }
    }
}
