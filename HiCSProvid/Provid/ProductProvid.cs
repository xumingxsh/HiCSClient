using System;
using System.Data;
using System.Collections.Generic;

using HiCSProvid.Util;
using HiCSModel;

namespace HiCSProvid
{
    /// <summary>
    /// 产品数据提供类
    /// </summary>
    public sealed class ProductProvid
    {
		/// <summary>
		/// 根据产品获得工序信息
		/// </summary>
        public static DataTable GetProductProcesses(string productID)
        {
            /*
            Dictionary<string, string> dic = new Dictionary<string,string>();
            dic["productID"] = productID;
            return DBHelper.ExecuteQuery("ProductProvid.GetProductProcesses", dic);*/
            return DBHelper.ExecuteQuery("ProductProvid.GetProductProcesses_parm1", productID);
        }

        /// <summary>
        /// 取得工序的物料
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="processID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DataTable GetProcessMaterial(string productID, string processID, ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            string condition = "";
            if (type != ProvidEnum.MaterialType.All)
            {
                condition = " and MType='" + Convert.ToInt16(type) + "'";
            }
            return DBHelper.ExecuteQuery("ProductProvid.GetProductProcessMaterial_parm3", productID, processID, condition);
        }

        /// <summary>
        /// 取得工序的输入项
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="processID"></param>
        /// <returns></returns>
        public static DataTable GetProcessInput(string productID, string processID)
        {
            return DBHelper.ExecuteQuery("ProductProvid.GetProcessInput_parm2", productID, processID);
        }

        /// <summary>
        /// 取得当日生产计划
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DataTable GetPlan(DateTime time)
        {
            string begin = time.AddDays(-1).ToString("yyyy-MM-dd 23:59:59");
            string end = time.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["begin"] = begin;
            dic["end"] = end;
            return DBHelper.ExecuteQuery("ProductProvid.GetPlan", dic);
        }

        /// <summary>
        /// 取得生产产品的状态
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DataTable GetProductState(DateTime time)
        {
            string begin = time.AddDays(-1).ToString("yyyy-MM-dd 23:59:59");
            string end = time.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["begin"] = begin;
            dic["end"] = end;
            return DBHelper.ExecuteQuery("ProductProvid.GetProductState", dic);
        }

        /// <summary>
        /// 添加输入项的记录
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="inputId"></param>
        /// <param name="number"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static bool InsertInput(string productID, string inputId,  int number, string value1, string value2)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["ProductID"] = productID;
            dic["Number"] = Convert.ToString(number);
            dic["InputID"] = inputId;
            dic["Value1"] = value1;
            dic["Value2"] = value2;
            return DBHelper.ExecuteNoQuery("ProductProvid.InsertInput", dic) == 1;
        }

        public static bool UpdateInput(string productID, string inputId, int number, string value1, string value2)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["ProductID"] = productID;
            dic["Value1"] = value1;
            dic["Value2"] = value2;
            return DBHelper.ExecuteNoQuery("ProductProvid.UpdateInput", dic, productID,number, inputId) == 1;
        }
    }
}
