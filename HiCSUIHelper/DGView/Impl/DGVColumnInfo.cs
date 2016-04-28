using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        /// <summary>
        /// 列对应的实际列
        /// </summary>
        public DataGridViewColumn Control { get; set; } 

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DipplayIndex { get; set; }          

        /// <summary>
        /// 设置列对齐方式
        /// </summary>
        /// <param name="info"></param>
        /// <param name="column"></param>
        public static void SetAlign(DGVColumnInfo info, DataGridViewColumn column)
        {
            if (info.Align == null)
            {
                return;
            }
            string align = info.Align.Trim().ToLower();
            if (align.Equals("left"))
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                return;
            }
            if (align.Equals("right"))
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                return;
            }
            if (align.Equals("center"))
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                return;
            }
        }

        /// <summary>
        /// 创建并初始化控件
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="dgv"></param>
        public static DataGridViewCheckBoxColumn CreateAndInitControls(List< DGVColumnInfo> lst, DataGridView dgv)
        {
            DataGridViewCheckBoxColumn chkColumn = null;
            foreach (var it in lst)
            {
                if (it.Control == null)
                {
                    it.Control = DGVColumnInfo.CreateControl(it);
                    if (it.Control is DataGridViewCheckBoxColumn)
                    {
                        chkColumn = it.Control as DataGridViewCheckBoxColumn;
                    }
                    dgv.Columns.Add(it.Control);
                }
            }

            foreach (var it in lst)
            {
                it.Control.HeaderText = it.ColumnText;
                it.Control.DataPropertyName = it.ColumnName;
                it.Control.Name = it.ColumnID;
            }

            return chkColumn;
        }

        /// <summary>
        /// 取得固定列宽度
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static int GetWidths(List<DGVColumnInfo> lst)
        {
            int width = 0;

            foreach (var it in lst)
            {
                if (it.Width > 0)
                {
                    width += it.Width;
                }
            }
            return width;
        }

        /// <summary>
        /// 是否存在选择列
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static bool HasChkColumn(List<DGVColumnInfo> lst)
        {
            foreach (var it in lst)
            {
                if (it.Type.ToLower().Equals("chk") ||
                    it.Type.ToLower().Equals("chk_head"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 控件改动时修改列宽度
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="width"></param>
        /// <param name="displayStartIndex"></param>
        public static void ControlsResize(List<DGVColumnInfo> lst, int width, int displayStartIndex)
        {
            foreach (var it in lst)
            {
                if (it.Width > 0)
                {
                    it.Control.Width = it.Width;
                }
                else
                {
                    it.Control.Width = (width * it.WidthPercent) / 100;
                }
                it.Control.DisplayIndex = it.DipplayIndex + displayStartIndex;
                DGVColumnInfo.SetAlign(it, it.Control);
            }
        }

        /// <summary>
        /// 常见列
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static DataGridViewColumn CreateControl(DGVColumnInfo info)
        {
            if (info.Type.ToLower().Equals("chk"))
            {
                return DGViewUtil.CreateCheckBoxColumn();
            }
            else if (info.Type.ToLower().Equals("chk_head"))
            {
                return DGViewUtil.CreateCheckBoxColumn(20, true);
            }
            else
            {
                DataGridViewColumn ex = new DataGridViewTextBoxColumn();
                ex.Tag = info.ColumnID;
                if (info.IsShow == 0)
                {
                    ex.Visible = false;
                }
                ex.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                return ex;
            }
        }
    }
}
