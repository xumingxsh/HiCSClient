using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiCSRestAPI.Tool
{
    class ParamInfo
    {
        public string SQL_ID { set; get; }
        public Dictionary<string, string> Dic { set; get; }
        public string[] Arr { set; get; }

        public static  ParamInfo Parse(string text)
        {
            try
            {
                return Parse_i(text);
            }
            catch(Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        private static ParamInfo Parse_i(string text)
        {
            ParamInfo info = new ParamInfo();

            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            // 将parms还原为id,list,取出list中的parms值,作为可变参数
            Dictionary<string, string> dic = HiCSUtil.Json.Json2Obj<Dictionary<string, string>>(text);
            if (dic == null || dic.Count < 1 || !dic.ContainsKey("sql_id"))
            {
                dic = null;
                return null;
            }

            info.SQL_ID = dic["sql_id"];
            info.Arr = null;
            if (dic.ContainsKey("parms"))
            {
                info.Arr = dic["parms"].Split(',');
            }
            dic.Remove("parms");
            dic.Remove("sql_id");

            if (dic.Count < 1)
            {
                dic = null;
            }

            info.Dic = dic;
            return info;
        }
    }
}