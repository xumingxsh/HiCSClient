﻿using System;
using System.Xml;

using HiCSSQL;

namespace HiCSUserControl
{
    /// <summary>
    /// 展示配置获取类
    /// </summary>
    public static class ViewConfig
    {
        /// <summary>
        /// 获得基本展示配置对象
        /// XuminRong 2016.04.21
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetView(string id)
        {
            TextInfo info =  ChchText.GetValue(id);
            if (info == null)
            {
                System.Diagnostics.Debug.Assert(false, string.Format("the key({0}) for view xml config not exist", id));
            }
            return info.Text;
        }

        private static CachProxy<TextInfo> ChchText
        {
            get
            {
                if (chchText == null)
                {
                    chchText = new CachProxy<TextInfo>();
                    chchText.LoadXMLs(ViewXmlFolder);
                }
                return chchText;
            }
        }
        public static string ViewXmlFolder { set; get; }

        static CachProxy<TextInfo> chchText = null;


        class TextInfo : ICachItem
        {
            public bool Parse(XmlNode node)
            {
                if (string.IsNullOrWhiteSpace(node.InnerText))
                {
                    return false;
                }

                Text = node.InnerText;
                return true;
            }
            public string Text { set; get; }
        }
    }
}
