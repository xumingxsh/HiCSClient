using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace HiCSCommonControl.Util
{
    /// <summary>
    /// JSON字符串处理类
    /// XuminRong 2016.04.15
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 根据Json字符串获得对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Json2Obj<T>(string json) where T : class
        {
            DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return sr.ReadObject(ms) as T;
            }
        }

        /// <summary>
        /// 根据对象取得Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Obj2Json<T>(T t) where T : class
        {
            if (t == null)
            {
                return "";
            }

            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(t.GetType());
                serializer.WriteObject(ms, t);
                ms.Position = 0;

                using (StreamReader reader = new StreamReader(ms))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}
