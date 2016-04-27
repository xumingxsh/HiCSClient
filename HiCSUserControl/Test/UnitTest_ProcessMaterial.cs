using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HiCSUserControl;

namespace HiCSUserControl.Test
{
    /// <summary>
    /// 进程物料界面测试程序
    /// 注:当前还不掌握UI测试技术,故该类尚未实现,放置在此处占位置
    /// XuminRong 2016.04.15
    /// </summary>
    [TestClass]
    public class UnitTest_ProcessMaterial
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UnitTest_ProcessMaterial()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo topDir = System.IO.Directory.GetParent(path);
            topDir = System.IO.Directory.GetParent(topDir.FullName);
            topDir = System.IO.Directory.GetParent(topDir.FullName);
            path = topDir.FullName + "/Excel";
            string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;
Extended Properties=Excel 8.0;
data source=" + path + "/edqdb.xls";

            HiCSProvider.UserConfig.Init(2, conn, path + "/xmls");
        }
    }
}
