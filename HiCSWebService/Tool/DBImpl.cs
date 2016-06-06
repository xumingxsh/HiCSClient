using System;
using System.Data;
using System.Collections.Generic;

using HiCSDBProvider;


namespace HiCSWebService.Tool
{
    /// <summary>
    /// 数据库访问类
    /// XuminRong 2016.04.15
    /// </summary>
    public class DBImpl: HiCSProvider.IRemoteProvide
    {

        public int ExecuteNoQuery(string id, IDictionary<string, string> mp, params string[] args)
        {
            return DBProvider.ExecuteNoQuery(id, mp, args);
        }

        public DataTable ExecuteQuery(string id, IDictionary<string, string> mp, params string[] args)
        {
            return DBProvider.ExecuteQuery(id, mp, args);
        }

        public string ExecuteScalar(string id, IDictionary<string, string> mp, params string[] args)
        {
            return DBProvider.ExecuteScalar(id, mp, args);
        }
    }
}
