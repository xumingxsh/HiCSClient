using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;

using HiCSProvid;

using HiCSControl.Model;
using HiCSControl.Control;

namespace HiCSControl.Test
{
    /// <summary>
    /// 登录模块测试类
    /// </summary>
    [TestClass]
    public class UnitTest_Login
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UnitTest_Login()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo topDir = System.IO.Directory.GetParent(path);
            topDir = System.IO.Directory.GetParent(topDir.FullName);
            topDir = System.IO.Directory.GetParent(topDir.FullName);
            path = topDir.FullName + "/Excel"; 
            ProvidConfig.Conn = @"Provider=Microsoft.Jet.OLEDB.4.0;
Extended Properties=Excel 8.0;
data source=" + path + "/edqdb.xls";
            ProvidConfig.XMLFolder = path + "/xmls";
            ProvidConfig.DBType = 2;
        }

        /// <summary>
        /// 获得工序测试
        /// </summary>
        [TestMethod]
        public void UserLoginControl_GetProcess()
        {
            UserLoginControl control = new UserLoginControl();
            List<ProcessInfo> lst = control.GetProcess("P1");
            Assert.IsTrue(lst.Count > 0);
        }

        /// <summary>
        /// 登录测试
        /// </summary>
        [TestMethod]
        public void UserLoginControl_Login()
        {
            UserLoginControl control = new UserLoginControl();
            Assert.IsTrue(control.Login("zhs", "zhs"));
            var lst = control.LoginUsers;
            Assert.IsTrue(lst.Count > 0);
        }
    }
}
