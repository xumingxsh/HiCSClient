using System;
using System.Data;
using System.Collections.Generic;

using HiCSControl.DB.Impl;

namespace HiCSControl
{
    /// <summary>
    /// 数据库访问类
    /// XuminRong 2016.04.15
    /// </summary>
    public class DBHelper
    {
        static RestHelperImpl rest = new RestHelperImpl();
        static DBHelperImpl db = new DBHelperImpl();
        static IDBHelper dbImpl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(RestHepler.RemoteURI))
                {
                    return db;
                }
                else
                {
                    return rest;
                }
            }
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string id, IDictionary<string, string> mp = null)
        {
            return dbImpl.ExecuteQuery(id, mp);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string id, params object[] args)
        {
            return dbImpl.ExecuteQuery(id, args);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery(string id, IDictionary<string, string> mp = null)
        {
            return dbImpl.ExecuteNoQuery(id, mp);
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
            return dbImpl.ExecuteNoQuery(id, mp, args);
        }

        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery8SQL(string sql)
        {
            return dbImpl.ExecuteNoQuery8SQL(sql);
        }

       /// <summary>
       /// 执行SQL语句，并取得第一行第一列
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
        public static int ExecuteScalarInt8SQL(string sql)
        {
            return dbImpl.ExecuteScalarInt8SQL(sql);
        }
    }
}
