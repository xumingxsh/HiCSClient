using System;
using System.Data;
using System.Web.Http;

using HiCSRestAPI.Tool;

namespace HiCSRestAPI.Controllers
{
    public class ProductProvidController : ApiController
    {
        [HttpGet]
        public string GetProductProcessMaterial_parm3(string parms)
        {
            string[] arr = parms.Split(',');
            if (arr.Length != 3)
            {
                return "";
            }
            DataTable dt = DBHelper.ExecuteQuery("ProductProvid.GetProductProcessMaterial_parm3", arr);
            return HiCSUtil.Json.DataTable2Json(dt);
        }

        [HttpGet]
        public string GetProductProcesses_parm1(string parms)
        {
            DataTable dt = DBHelper.ExecuteQuery("ProductProvid.GetProductProcesses_parm1", parms);
            return HiCSUtil.Json.DataTable2Json(dt);
        }
    }
}