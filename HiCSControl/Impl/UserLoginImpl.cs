using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

using HiCBO;

using HiCSModel;
using HiCSProvid;
using HiCSControl.Model;


namespace HiCSControl.Impl
{
    /// <summary>
    /// 用户登录接口实现
    /// </summary>
    sealed class UserLoginImpl
    {
        /// <summary>
        /// 当前所有用户
        /// </summary>
        public BindingList<UserInfo> Users
        {
            get
            {
                return users;
            }
        }

        /// <summary>
        /// 根据产品取得所有工序
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<ProcessInfo> GetProcess(string productID)
        {
            List<ProcessInfo> lst = new List<ProcessInfo>();
            DataTable dt = ProductProvid.GetProductProcesses(productID);
            foreach(DataRow dr in dt.Rows)
            {
                ProcessInfo info = new ProcessInfo();
                bool result = CBO.FillObject<ProcessInfo>(info,dr);
                if (result)
                {
                    lst.Add(info);
                }
            }
            return lst;
        }

        /// <summary>
        /// 用户登录总数
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
            LoginResult result = UserProvid.Login(user, pwd);
            return OnLogin(result);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public bool Login(string rfid)
        {
            LoginResult result = UserProvid.Login(rfid);
            return OnLogin(result);
        }

        /// <summary>
        /// 注销处理
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool OnLogin(LoginResult result)
        {
            if (!result.IsOK)
            {
                return false;
            }

            UserInfo info = new UserInfo();
            info.UserID = result.UserID;
            info.UserName = result.UserName;
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
        /// 全部注销
        /// </summary>
        public void Logout()
        {
            users.Clear();
        }

        BindingList<UserInfo> users = new BindingList<UserInfo>();
    }
}
