using System;

using HiCSSQL;

namespace OutWardProvid
{
    public class ProvidConfig
    {
        public static int DBType { set; get; }
        public static string Conn { set; get; }


        static string xmlFolder = "";
        public static string XMLFolder
        {
            set
            {
                xmlFolder = value;

                SQLProxy.LoadXMLs(xmlFolder);
            }
        }
    }
}
