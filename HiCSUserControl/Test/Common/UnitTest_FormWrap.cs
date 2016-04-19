using System;
using System.Windows.Forms;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using HiCSUserControl.Common;

namespace HiCSUserControl.Test
{
    /// <summary>
    /// FormWrap单元测试类
    /// XuminRong 2016.04.15
    /// </summary>
    [TestClass]
    public class UnitTest_FormWrap
    {
        /// <summary>
        /// 控件初始化测试
        /// </summary>
        [TestMethod]
        public void FormWrap_InitControlsInfo()
        {
            string controlInfo = @"[{""ID"":""Name"",""CanNull"":""false"",""Reg"":"""",""Error"":""failed""},
{""ID"":""PWD"",""CanNull"":""false"",""Reg"":"""",""Error"":""failed""}]";
            FormWrap wrap = new FormWrap();

            Form form = new Form();
            wrap.InitControlsInfo(form, controlInfo);
            Assert.IsTrue(true);
        }
    }
}
