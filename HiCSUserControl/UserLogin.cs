using System;
using System.Windows.Forms;

using HiCSControl;
using HiCSUIHelper;

namespace HiCSUserControl
{
    /// <summary>
    /// 用户登录界面
    /// </summary>
    partial class UserLogin : Form
    {
        /// <summary>
        /// 用户管理对象
        /// </summary>
        public UserLoginControl Control { set; get; }

        /// <summary>
        /// 是否登录成功
        /// </summary>
        public bool IsOK { set; get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ctrl"></param>
        public UserLogin(UserLoginControl  ctrl)
        {
            InitializeComponent();
            Control = ctrl;
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            IsOK = false;
            wrap.InitControlsInfo(this, ViewConfig.GetView("User.UserLogin_ControlInfo"));
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
