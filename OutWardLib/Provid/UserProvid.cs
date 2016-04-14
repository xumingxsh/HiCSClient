using System;
using System.Data;

using OutWardModel;
using OutWardProvid.Util;

namespace OutWardProvid
{
    /// <summary>
    /// 用户数据提供类
    /// </summary>
    public sealed class UserProvid
    {
        //登录
        public static LoginResult Login(string user, string pwd)
        {
            DataTable dt = DBHelper.ExecuteQuery("User.Login_param2", user, pwd);
            return OnLogin(dt);
        }

        //登录
        public static LoginResult Login(string rfID)
        {
            DataTable dt = DBHelper.ExecuteQuery("User.Login_param1", rfID);
            return OnLogin(dt);
        }

        private static LoginResult OnLogin(DataTable dt)
        {
            LoginResult result = new LoginResult();
            if (dt.Rows.Count < 1)
            {
                result.IsOK = false;
                return result;
            }
            result.IsOK = true;
            result.UserName = Convert.ToString(dt.Rows[0]["Name"]);
            result.UserID = Convert.ToString(dt.Rows[0]["UserID"]);
            return result;
        }
    }
}
