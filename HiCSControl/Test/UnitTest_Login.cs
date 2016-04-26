using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;

using HiCSControl;
using HiCSModel;

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
            string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;
Extended Properties=Excel 8.0;
data source=" + path + "/edqdb.xls";
            UserConfig.Init(2, conn, path + "/xmls");
            UserConfig.SetUri("http://localhost:49653");
        }

        ///// <summary>
        ///// 获得工序测试
        ///// </summary>
        //[TestMethod]
        //public void UserLoginControl_GetProcess()
        //{
        //    UserLoginControl control = new UserLoginControl();
        //    List<ProcessInfo> lst = control.GetProcess("P1");
        //    Assert.IsTrue(lst.Count > 0);
        //}

        /// <summary>
        /// 登录测试
        /// </summary>
        [TestMethod]
        public void UserLoginControl_Login_db()
        {
            UserConfig.SetUri("");
            UserLoginControl control = new UserLoginControl();
            Assert.IsTrue(control.Login("zhs", "zhs"));
            var lst = control.LoginUsers;
            Assert.IsTrue(lst.Count > 0);
        }

        [TestMethod]
        public void UserLoginControl_Login_rest()
        {
            UserConfig.SetUri("http://localhost:49653");
            UserLoginControl control = new UserLoginControl();
            Assert.IsTrue(control.Login("zhs", "zhs"));
            var lst = control.LoginUsers;
            Assert.IsTrue(lst.Count > 0);
        }

        [TestMethod]
        public void UserLoginControl_Rest()
        {
            // Create the web request
            HttpWebRequest request = WebRequest.Create("http://localhost:64021/client/?id=" + 3) as HttpWebRequest;

            // Get response
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output
                Console.WriteLine(reader.ReadToEnd());
            }

        }
    }
}
