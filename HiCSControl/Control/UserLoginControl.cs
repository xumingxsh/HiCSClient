using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using HiCSModel;
using HiCSProvider;

namespace HiCSControl
{
    /// <summary>
    /// 登录模块接口
    /// XuminRong 2016.04.15
    /// </summary>
    public sealed class UserLoginControl
    {
        /// <summary>
        /// 工序编号
        /// </summary>
        public ProcessInfo CurProcess {set; get;}

        /// <summary>
        /// 取得所有登录当前客户端的用户
        /// </summary>
        public BindingList<UserInfo> LoginUsers
        {
            get
            {
                return users;
            }
        }

        /// <summary>
        /// 登录用户数量
        /// </summary>
        public int UserCount
        {
            get
            {
                return users.Count;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Login(string user, string pwd)
        {
            DataTable dt = DBHelper.ExecuteQuery("User.Login_param2", user, pwd);
            return OnLogin(dt);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public bool Login(string rfid)
        {
            DataTable dt = DBHelper.ExecuteQuery("User.Login_param1", rfid);
            return OnLogin(dt);
        }

        private bool OnLogin(DataTable dt)
        {
            if (dt == null || dt.Rows.Count != 1)
            {
                return false;
            }

            UserInfo info = new UserInfo();
            DataRow dr = dt.Rows[0];
            HiCSUtil.CBO.FillObject<UserInfo>(info, (string name) =>
            {
                if (name == "UserName")
                {
                    name = "Name";
                }
                if (!dr.Table.Columns.Contains(name))
                {
                    return null;
                }
                return dr[name];
            });

            info.LoginTime = DateTime.Now;

            foreach (UserInfo it in users)
            {
                if (it.UserID.Equals(info.UserID))
                {
                    return true;
                }
            }

            users.Add(info);
            return true;
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(string userId)
        {
            foreach (UserInfo it in users)
            {
                if (it.UserID.Equals(userId))
                {
                    users.Remove(it);
                    break;
                }
            }
        }

        /// <summary>
        /// 注销所有用户
        /// </summary>
        public void Logout()
        {
            users.Clear();
        }

        BindingList<UserInfo> users = new BindingList<UserInfo>();
    }
}
