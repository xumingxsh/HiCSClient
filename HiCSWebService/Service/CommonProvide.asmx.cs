using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;

using HiCSUtil;
using HiCSProvider;

using HiCSWebService.Tool;

namespace HiCSWebService.Service
{
    /// <summary>
    /// CommonProvide 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CommonProvide : System.Web.Services.WebService
    {
        /// <summary>
        /// 根据SQL的标识执行SQL语句
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [WebMethod]
        public int ExecuteNoQuery(string parms)
        {
            ParamInfo parm = ParamInfo.Parse(parms);
            if (parm == null)
            {
                return -1;
            }

            return DBHelper.ExecuteNoQuery(parm.SQL_ID, parm.Dic, parm.Arr);
        }

        [WebMethod]
        public DataTable ExecuteQuery(string parms)
        {
            ParamInfo parm = ParamInfo.Parse(parms);
            if (parm == null)
            {
                return null;
            }

            return DBHelper.ExecuteQuery(parm.SQL_ID, parm.Dic, parm.Arr);
        }
        
        [WebMethod]
        public string ExecuteScalar(string parms)
        {
            ParamInfo parm = ParamInfo.Parse(parms);
            if (parm == null)
            {
                return "";
            }
            return DBHelper.ExecuteScalar(parm.SQL_ID, parm.Dic, parm.Arr);
        }


        [WebMethod]
        public int ExecuteNoQuery8SQL(string sql)
        {
            throw new NotImplementedException("this function not support");
        }

        IRemoteProvide provider = null;

        private IRemoteProvide Provider
        {
            get
            {
                if (provider == null)
                {
                    provider = new DBImpl();
                }
                return provider;
            }
        }
    }
}