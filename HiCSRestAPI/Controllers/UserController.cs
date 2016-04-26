using System;
using System.Data;
using System.Web.Http;

using HiCSRestAPI.Tool;

namespace HiCSRestAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Login_param2(string parms)
        {
            string[] arr = parms.Split(',');
            if (arr.Length != 2)
            {
                return "";
            }
            DataTable dt = DBHelper.ExecuteQuery("User.Login_param2", arr);
            return HiCSUtil.Json.DataTable2Json(dt);
        }

        [HttpGet]
        public string Login_param1(string parms)
        {
            DataTable dt = DBHelper.ExecuteQuery("User.Login_param1", parms);
            return HiCSUtil.Json.DataTable2Json(dt);
        }
    }
}