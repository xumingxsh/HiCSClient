using System;
using System.Collections.Generic;
using System.ComponentModel;

using HiCSModel;

using HiCSControl.Model;

using HiCSControl.Impl;

namespace HiCSControl.Control
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
        /// 产品的所有进程
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<ProcessInfo> GetProcess(string productID)
        {
            return impl.GetProcess(productID);
        }

        /// <summary>
        /// 取得所有登录当前客户端的用户
        /// </summary>
        public BindingList<UserInfo> LoginUsers
        {
            get
            {
                return impl.Users;
            }
        }

        /// <summary>
        /// 登录用户数量
        /// </summary>
        public int UserCount
        {
            get
            {
                return impl.UserCount;
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
            return impl.Login(user, pwd);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public bool Login(string rfid)
        {
            return impl.Login(rfid);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(string userId)
        {
            impl.Logout(userId);
        }

        /// <summary>
        /// 注销所有用户
        /// </summary>
        public void Logout()
        {
            impl.Logout();
        }

        UserLoginImpl impl = new UserLoginImpl();
    }
}
