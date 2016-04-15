using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

using HiCSProvid;
using HiCSProvid.Util;
using HiCSModel;

using HiCSDB;

namespace HiCSProvid.Test
{
    /// <summary>
    /// 用户测试类
    /// </summary>
    [TestClass]
    public class UnitTest_User
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UnitTest_User()
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
            ProvidConfig.DBType = DBOperate.OLEDB;
        }

        /// <summary>
        /// 测试登录
        /// </summary>
        [TestMethod]
        public void Login_Param2_excel()
        {
            LoginResult result = UserProvid.Login("zhs", "zhs");
            Assert.IsTrue(result.IsOK);
        }

        /// <summary>
        /// 测试登录
        /// </summary>
        [TestMethod]
        public void Login_Param1_excel()
        {
            LoginResult result = UserProvid.Login("10001");
            Assert.IsTrue(result.IsOK);
        }
    }
}
