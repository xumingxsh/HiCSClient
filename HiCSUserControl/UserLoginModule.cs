using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

using HiCSControl;
using HiCSModel;

using HiCSUIHelper;
using HiCSProvider;

namespace HiCSUserControl
{
    /// <summary>
    /// 登录模块程序
    /// XuminRong 2016.04.15
    /// </summary>
    public partial class UserLoginModule : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserLoginModule()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化程序
        /// 注:设计到数据库之类的交互,不能放置在Load中,
        /// 因为可能导致自定义控件无法被使用(例如显示"路径形式不合法"),应该为CS2013的bug
        /// </summary>
        public void Init()
        {
            dgvLoginUser.DataSource = control.LoginUsers;
            DataTable processes = DBHelper.ExecuteQuery("ProductProvid.GetProductProcesses_parm1", "P1");
            cbProcesses.DataSource = processes;
            cbProcesses.DisplayMember = "Name";
            cbProcesses.ValueMember = "ProcessId";
        }

        /// <summary>
        /// 设置通知函数
        /// </summary>
        /// <param name="evt"></param>
        public void SetNotify(Action evt)
        {
            handle = evt;
        }

        private void UserLoginModule_Load(object sender, EventArgs e)
        {
            dgvHelper.Init(dgvLoginUser, ViewConfig.GetView("User.DGV_LoginUsers"));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin login = new UserLogin(control);
            login.ShowDialog();
            if (login.IsOK)
            {
                dgvLoginUser.DataSource = control.LoginUsers;
            }
        }

        private void dgvLoginUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            string id = dgvHelper.GetCellValue(index, "UserID");
            string name = dgvHelper.GetCellValue(index, "UserName");
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(name))
            {
                return;
            }

            string msg = null;
            if (control.UserCount == 1)
            {
                msg = string.Format("“{0}”是最后一个登录用户,注销后会自动关闭最后未完成的任务，你确定要注销吗？", name);
            }
            else
            {
                msg = string.Format("你确定要注销“{0}”吗？", name);
            }
            if (MsgBoxHelper.Confirm(msg, "注销确认"))
            {
                control.Logout(id);
                dgvLoginUser.DataSource = control.LoginUsers;

                if (control.UserCount < 1 && handle != null)
                {
                    handle();
                }
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MsgBoxHelper.Confirm("注销所有用户会自动关闭最后未完成的任务，你确定要注销“{0}”吗？", "注销确认"))
            {
                control.Logout();
                dgvLoginUser.DataSource = control.LoginUsers;

                if (control.UserCount < 1 && handle != null)
                {
                    handle();
                }
            }
        }

        UserLoginControl control = new UserLoginControl();
        DGViewHelper dgvHelper = new DGViewHelper();
        Action handle = null;
    }
}
