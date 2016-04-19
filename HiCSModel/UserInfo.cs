using System;

namespace HiCSModel
{
    /// <summary>
    /// 用户信息
    /// XuminRong 2016.04.15
    /// </summary>
    public sealed class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 用户标志
        /// </summary>
        public string UserID { set; get; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { set; get; }
    }
}
