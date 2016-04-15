using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

using HiCSControl.Control;
using HiCSControl.Model;

using HiCSCommonControl;
using HiCSCommonControl.Util;

namespace HiCSUserControl
{
    public partial class UserLoginModule : UserControl
    {
        public UserLoginModule()
        {
            InitializeComponent();
        }

        private void UserLoginModule_Load(object sender, EventArgs e)
        {
            dgvHelper.Init(this, dgvLoginUser, ViewConfig.ViewDefault.UserLoginModule_DGV);
        }

        public void Init()
        {
            dgvLoginUser.DataSource = control.LoginUsers;
            processes = control.GetProcess("P1");
            cbProcesses.DataSource = processes;
            cbProcesses.DisplayMember = "Name";
            cbProcesses.ValueMember = "ProcessId";
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
            string id = Convert.ToString(dgvLoginUser.Rows[index].Cells[1].Value);
            string name = Convert.ToString(dgvLoginUser.Rows[index].Cells[0].Value);
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(name))
            {
                return;
            }

            if (MsgBoxHelper.Confirm(string.Format("你确定要注销“{0}”吗？", name), "注销确认"))
            {
                control.Logout(id);
                dgvLoginUser.DataSource = control.LoginUsers;
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MsgBoxHelper.Confirm("注销所有用户会自动关闭最后未完成的任务，你确定要注销“{0}”吗？", "注销确认"))
            {
                control.Logout();
                dgvLoginUser.DataSource = control.LoginUsers;
            }
        }

        List<ProcessInfo> processes = null;

        UserLoginControl control = new UserLoginControl();
        DGViewHelper dgvHelper = new DGViewHelper();
    }
}
