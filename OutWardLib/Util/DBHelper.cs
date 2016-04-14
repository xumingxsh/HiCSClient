using System;
using System.Data;
using System.Collections.Generic;

using HiCSSQL;
using HiCSDB;

namespace OutWardProvid.Util
{
    class DBHelper
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

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string id, IDictionary<string, string> mp = null)
        {
            SqlInfo sql = SQLProxy.GetSqlInfo(id, (string propertyName, ref object objVal) =>
            {
                objVal = mp[propertyName];
                return objVal != null;
            });
            DataTable dt = DB.ExecuteDataTable(sql.SQL, sql.Parameters);
            return ExcelDataTable(dt);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string id, params object[] args)
        {
            SqlInfo info = SQLProxy.GetSqlInfo(id);
            string sql = string.Format(info.SQL, args);
            DataTable dt = DB.ExecuteDataTable(sql);
            return ExcelDataTable(dt);
        }

        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery(string id, IDictionary<string, string> mp = null)
        {
            SqlInfo sql = SQLProxy.GetSqlInfo(id, (string propertyName, ref object objVal) =>
            {
                objVal = mp[propertyName];
                return objVal != null;
            });
            return DB.ExecuteNonQuery(sql.SQL, sql.Parameters);
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
            SqlInfo info = SQLProxy.GetSqlInfo(id, (string propertyName, ref object objVal) =>
            {
                objVal = mp[propertyName];
                return objVal != null;
            });
            string sql = string.Format(info.SQL, args);
            return DB.ExecuteNonQuery(sql, info.Parameters);
        }

        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery8SQL(string sql)
        {
            return DB.ExecuteNonQuery(sql);
        }

       /// <summary>
       /// 执行SQL语句，并取得第一行第一列
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
        public static int ExecuteScalarInt8SQL(string sql)
        {
            object obj = DB.ExecuteScalar(sql);
            if (obj is DBNull || obj == null)
            {
                return -1;
            }

            try
            {
                return Convert.ToInt32(obj);
            }
            catch(Exception ex)
            {
                ex.ToString();
                return -1;
            }
        }

        private static DataTable ExcelDataTable(DataTable dt)
        {
            DataTable dtNew = new DataTable();
            foreach(DataColumn cl in dt.Columns)
            {
                dtNew.Columns.Add(cl.ColumnName);
            }

            foreach(DataRow dr in dt.Rows)
            {
                DataRow drNew = dtNew.NewRow();

                foreach (DataColumn cl in dt.Columns)
                {
                    drNew[cl.ColumnName] = Convert.ToString(dr[cl.ColumnName]);
                }

                dtNew.Rows.Add(drNew);
            }

            return dtNew;
        }
    }
}
