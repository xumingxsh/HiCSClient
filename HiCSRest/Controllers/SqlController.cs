using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

using HiCSRest.Tool;
using HiCSUtil;

namespace HiCSRest.Controllers
{
    public class SqlController : ApiController
    {
        /// <summary>
        /// 根据SQL的标识执行SQL语句
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpGet]
        public int ExecuteNoQuery8ID(string parms)
        {
            ParamInfo parm = ParamInfo.Parse(parms);
            if (parm == null)
            {
                return -1;
            }

            return DBHelper.ExecuteNoQuery(parm.SQL_ID, parm.Dic, parm.Dic);
        }

        [HttpGet]
        public string ExecuteQuery8ID(string parms)
        {
            ParamInfo parm = ParamInfo.Parse(parms);
            if (parm == null)
            {
                return "";
            }

            DataTable dt = null;
            if (parm.Dic == null)
            {
                dt = DBHelper.ExecuteQuery(parm.SQL_ID, parm.Arr);
            }
            else
            {
                dt = DBHelper.ExecuteQuery(parm.SQL_ID, parm.Dic);
            }
            return HiCSUtil.Json.DataTable2Json(dt);
        }


        [HttpGet]
        public int ExecuteNoQuery(string parms)
        {
            return DBHelper.ExecuteNoQuery8SQL(parms);
        }

        [HttpGet]
        public int ExecuteScalarInt(string parms)
        {
            return DBHelper.ExecuteScalarInt8SQL(parms);
        }
    }
}