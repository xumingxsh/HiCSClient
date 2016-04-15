using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Reflection;

using HiCSProvid;
using HiCSDB;
using HiCSCommonControl;
using HiCSControl.Control;

namespace HiCSUserControl.Test
{
    [TestClass]
    public class UnitTest_Login
    {
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
            ProvidConfig.DBType = DBOperate.OLEDB;
        }

        [TestMethod]
        public void FormWrap_InitControlsInfo()
        {
        string controlInfo = @"[{""ID"":""Name"",""CanNull"":""false"",""Reg"":"""",""Error"":""failed""},
{""ID"":""PWD"",""CanNull"":""false"",""Reg"":"""",""Error"":""failed""}]";
            FormWrap wrap = new FormWrap();

            LoginModuleTest test = new LoginModuleTest();
            wrap.InitControlsInfo(test, controlInfo);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoginModule_Init()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginModuleTest());
        }
        
        [TestMethod]
        public void LoginModule_Refactor()
        {
            HiCSCommonControl.Util.MsgBoxHelper info = Assembly.Load("HiCSCommonControl").CreateInstance("HiCSCommonControl.Util.MsgBoxHelper") as HiCSCommonControl.Util.MsgBoxHelper;
            Assert.IsNotNull(info);
        }

        [TestMethod]
        public void LoginModule_Refactor2()
        {
            int i = 0;

            Assembly bly = Assembly.Load("HiCSControl");
            object obj = bly.CreateInstance("HiCSControl.Control.UserLoginControl");

            HiCSControl.Control.UserLoginControl info =
                obj as HiCSControl.Control.UserLoginControl;

            Assert.IsNotNull(info);
        }
    }
}
