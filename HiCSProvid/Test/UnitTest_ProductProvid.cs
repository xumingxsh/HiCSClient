using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Text;
using System.IO;

using HiCSProvid;
using HiCSProvid.Util;
using HiCSDB;

namespace HiCSProvid.Test
{
    /// <summary>
    /// 产品数据处理测试类
    /// XuminRong 2016.04.15
    /// </summary>
    [TestClass]
    public class UnitTest_ProductProvid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UnitTest_ProductProvid()
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
        /// 测试产品工序
        /// </summary>
        [TestMethod]
        public void GetProductProcesses_excel()
        {
            DataTable dt = ProductProvid.GetProductProcesses("P1");
            Assert.IsTrue(dt != null && dt.Rows.Count > 1);
            WriteLog(DataTable2String(dt));
        }

        /// <summary>
        /// 测试产品物料
        /// </summary>
        [TestMethod]
        public void GetProductProcessMaterial_excel()
        {
            DataTable dt = ProductProvid.GetProcessMaterial("P1", "1");
            Assert.IsTrue(dt != null && dt.Rows.Count > 1);
            WriteLog(DataTable2String(dt));
        }

        /// <summary>
        /// 测试获得输入项
        /// </summary>
        [TestMethod]
        public void GetProcessInput_excel()
        {
            DataTable dt = ProductProvid.GetProcessInput("P1", "1");
            Assert.IsTrue(dt != null && dt.Rows.Count > 1);
            WriteLog(DataTable2String(dt));
        }

        /// <summary>
        /// 测试添加输入项数据
        /// </summary>
        [TestMethod]
        public void InsertInput_excel()
        {
            DBHelper.ExecuteNoQuery8SQL("update [InputValue$] set ProductID=null,Num=null, InputID=null, value1=null,value2=null where ProductID='P1' and Num='1' and InputID='1'");
            bool result = ProductProvid.InsertInput("P1", "1", 1, "1601620-", "393");
            Assert.IsTrue(result);
            int count = DBHelper.ExecuteScalarInt8SQL("Select count(1) from [InputValue$] where ProductID='P1' and Num='1' and InputID='1'");
            Assert.IsTrue(count == 1);
            DBHelper.ExecuteNoQuery8SQL("update [InputValue$] set ProductID=null,Num=null, InputID=null, value1=null,value2=null where ProductID='P1' and Num='1' and InputID='1'");
        }

        /// <summary>
        /// 测试更新输入向数据
        /// </summary>
        [TestMethod]
        public void UpdateInput_excel()
        {
            DBHelper.ExecuteNoQuery8SQL("update [InputValue$] set ProductID=null,Num=null, InputID=null, value1=null,value2=null where ProductID='P1' and Num='1' and InputID='1'");
            bool result = ProductProvid.InsertInput("P1", "1", 1, "1601620-", "393");
            Assert.IsTrue(result);
            int count = DBHelper.ExecuteScalarInt8SQL("Select count(1) from [InputValue$] where ProductID='P1' and Num='1' and InputID='1'");
            Assert.IsTrue(count == 1);
            result = ProductProvid.UpdateInput("P1", "1", 1, "1601621-", "467");
            Assert.IsTrue(result);
            count = DBHelper.ExecuteScalarInt8SQL("Select count(1) from [InputValue$] where ProductID='P1' and Num='1' and InputID='1' and value2='467'");
            Assert.IsTrue(count == 1);
            DBHelper.ExecuteNoQuery8SQL("update [InputValue$] set ProductID=null,Num=null, InputID=null, value1=null,value2=null where ProductID='P1' and Num='1' and InputID='1'");
        }

        /// <summary>
        /// 测试取得产品计划
        /// </summary>
        [TestMethod]
        public void GetPlan_excel()
        {
            DataTable dt = ProductProvid.GetPlan(Convert.ToDateTime("2016-04-13 00:00"));
            Assert.IsTrue(dt != null && dt.Rows.Count > 1);
            WriteLog(DataTable2String(dt));
        }

        /// <summary>
        /// 测试产品进度
        /// </summary>
        [TestMethod]
        public void GetProductState_excel()
        {
            DataTable dt = ProductProvid.GetProductState(Convert.ToDateTime("2016-04-13 00:00"));
            Assert.IsTrue(dt != null && dt.Rows.Count > 1);
            WriteLog(DataTable2String(dt));
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        private static void WriteLog(string log)
        {
            Debug.WriteLine(log);
        }

        /// <summary>
        /// DataTable转换为字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static string DataTable2String(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach(DataColumn cl in dt.Columns)
            {
                sb.AppendFormat("\"{0}\":\"{1}\"\r\n", cl.ColumnName, Convert.ToString(cl.DataType));

            }
            foreach (DataRowView r in dt.DefaultView)
            {
                int index = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    if (index != 0)
                    {
                        sb.Append(" , ");
                    }
                    index++;
                    sb.AppendFormat("\"{0}\":\"{1}\"", c.ColumnName, Convert.ToString(r[c.ColumnName]));
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
    }
}
