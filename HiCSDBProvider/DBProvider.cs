using System;
using System.Collections.Generic;
using System.Data;

using HiCSDB;

namespace HiCSDBProvider
{
    /// <summary>
    /// 数据提供者有很多,此处只提供以数据库为数据源,以XML为SQL存储位置的数据提供者
    /// 注: 此处未考虑多数据库问题,以后会根据实际情况提供
    /// XuminRong 2016-06-03
    /// </summary>
    public class DBProvider
    {
        static DBOperate db = null;

        static DBOperate DB
        {
            get
            {
                if (db == null)
                {
                    db = new DBOperate(ProvidConfig.Conn, ProvidConfig.DBType);
                }
                return db;
            }
        }
    }
}
