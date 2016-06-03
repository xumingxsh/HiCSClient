using System;
using System.Collections.Generic;
using System.Data;

using HiCSProvider;

namespace HiCSWebService.Service.Impl
{
    class DBProvideImpl
    {
        /// <summary>
        /// 执行无返回值操作
        /// </summary>
        /// <param name="parms"></param>
        /// <returns>-1:失败,其他:影响行数</returns>
        public int ExecuteNoQuery(string id, IDictionary<string, string> mp, params string[] args)
        {
            return DBHelper.ExecuteNoQuery(id, mp, args);
        }

        /// <summary>
        /// 获得DataTable
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string id, IDictionary<string, string> mp, params string[] args)
        {
            return DBHelper.ExecuteQuery(id, mp, args);
        }

        /// <summary>
        /// 获得一个字符串
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public string ExecuteScalar(string id, IDictionary<string, string> mp, params string[] args)
        {
            return DBHelper.ExecuteScalar(id, mp, args);
        }
    }
}