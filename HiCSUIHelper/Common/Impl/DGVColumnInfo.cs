using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCSUIHelper
{
    /// <summary>
    /// 列信息
    /// 列控件以ColumnID作为Tag的扩展信息
    /// XuminRong 2016.04.03
    /// </summary>
    public sealed class DGVColumnInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DGVColumnInfo()
        {
            IsShow = 0;
            Type = "text";
        }
        /// <summary>
        /// 列唯一标识
        /// </summary>
        public string ColumnID;

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 标题内容
        /// </summary>
        public string ColumnText { get; set; }

        /// <summary>
        /// 宽度百分比
        /// </summary>
        public short WidthPercent { get; set; }

        /// <summary>
        /// 固定宽度
        /// </summary>
        public short Width { get; set; }

        /// <summary>
        /// 对齐方式
        /// </summary>
        public string Align { set; get; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public int IsShow { set; get; }

        /// <summary>
        /// 列类型text:普通列,chk:多选列;chk_head:含头的多选列
        /// </summary>
        public string Type { set; get; }

    }
}
