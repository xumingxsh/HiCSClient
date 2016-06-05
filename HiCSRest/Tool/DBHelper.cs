using System;
using System.Data;
using System.Collections.Generic;

using HiCSDBProvider;


namespace HiCSRest.Tool
{
    /// <summary>
    /// 数据库访问类
    /// XuminRong 2016.04.15
    /// </summary>
    public class DBHelper
    {
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string id, IDictionary<string, string> mp = null)
        {
            return DBProvider.ExecuteQuery(id, mp, null);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string id, params object[] args)
        {
            return DBProvider.ExecuteQuery(id, null, args);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery(string id, IDictionary<string, string> mp = null)
        {
            return DBProvider.ExecuteNoQuery(id, mp, null);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mp"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery(string id, IDictionary<string, string> mp, params object[] args)
        {
            return DBProvider.ExecuteNoQuery(id, mp, null);
        }

        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery8SQL(string sql)
        {
            return DBProvider.ExecuteNoQuery8SQL(sql);
        }

       /// <summary>
       /// 执行SQL语句，并取得第一行第一列
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
        public static int ExecuteScalarInt8SQL(string sql)
        {
            return DBProvider.ExecuteScalarInt8SQL(sql);
        }
    }
}
