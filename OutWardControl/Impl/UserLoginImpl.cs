using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

using HiCBO;

using OutWardModel;
using OutWardProvid;
using OutWardControl.Model;


namespace OutWardControl.Impl
{
    sealed class UserLoginImpl
    {
        public BindingList<UserInfo> Users
        {
            get
            {
                return users;
            }
        }

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

        public int UserCount
        {
            get
            {
                return users.Count;
            }
        }

        public bool Login(string user, string pwd)
        {
            LoginResult result = UserProvid.Login(user, pwd);
            return OnLogin(result);
        }

        public bool Login(string rfid)
        {
            LoginResult result = UserProvid.Login(rfid);
            return OnLogin(result);
        }

        public bool OnLogin(LoginResult result)
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

        public void Logout()
        {
            users.Clear();
        }

        BindingList<UserInfo> users = new BindingList<UserInfo>();
        ProcessInfo curProcess;
    }
}
