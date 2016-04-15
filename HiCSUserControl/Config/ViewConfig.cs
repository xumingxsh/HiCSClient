using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCSUserControl
{
    /// <summary>
    /// 展示配置获取类
    /// </summary>
    static class ViewConfig
    {
        /// <summary>
        /// 获得基本展示配置对象
        /// XuminRong 2016.04.15
        /// </summary>
        public  static HiCSUserControl.Config.View ViewDefault
        {
            get
            {
                return HiCSUserControl.Config.View.Default;
            }
        }
    }
}
