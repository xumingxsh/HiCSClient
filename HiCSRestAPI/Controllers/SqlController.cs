using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

using HiCSRestAPI.Tool;

namespace HiCSRestAPI.Controllers
{
    public class SqlController : ApiController
    {
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