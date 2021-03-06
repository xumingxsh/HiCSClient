﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCSModel
{
    /// <summary>
    /// 登录结果
    /// XuminRong 2016.04.15
    /// </summary>
    [Serializable]
    public sealed class LoginResult
    {
        /// <summary>
        /// 是否登录成功
        /// </summary>
        public bool IsOK { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 用户标志
        /// </summary>
        public string UserID { set;get;  }
    }
}
