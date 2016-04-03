﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Runtime.Serialization.Json;

namespace HiCSClient.CommonConrol
{
    /// <summary>
    /// 列信息
    /// 列控件以ColumnID作为Tag的扩展信息
    /// XuminRong 2016.04.03
    /// </summary>
    public class DGVColumnInfo
    {
        /// <summary>
        /// 列唯一标识
        /// </summary>
        public string ColumnID;

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName{get;set;}

        /// <summary>
        /// 标题内容
        /// </summary>
        public string ColumnText { get; set; }

        /// <summary>
        /// 宽度百分比
        /// </summary>
        public short WidthPercent { get; set; }

        public string Align { set; get; }

    }

    /// <summary>
    /// 使用配置文件设置列名，显示标题，列宽度（支持绝对宽度和百分比）
    /// 数据源只支持DataTable
    /// XuminRong 2016.04.03
    /// </summary>
    public class DGViewHelper
    {
        class DGVColumnInfoEx
        {
            public DGVColumnInfoEx()
            {
            }

            public DGVColumnInfoEx(DGVColumnInfo cl)
            {
                Column = cl;
            }

            public DGVColumnInfo Column { get; set; }

            public DataGridViewTextBoxColumn Control { get; set; }

            public int DipplayIndex { get; set; }
        }
        private Dictionary<string, DGVColumnInfoEx> columns = new Dictionary<string,DGVColumnInfoEx>();
        private List<DGVColumnInfoEx> clsList = new List<DGVColumnInfoEx>();
        DataGridView myDGV;

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dgv"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public bool Init(ContainerControl form, DataGridView dgv, string json)
        {
            DataContractJsonSerializer serial = new DataContractJsonSerializer(typeof(List<DGVColumnInfo>));
            var mStream = new MemoryStream(Encoding.Default.GetBytes(json));
            List<DGVColumnInfo>  lst = (List<DGVColumnInfo>)serial.ReadObject(mStream);
            return Init(form, dgv, lst);
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dgv"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        private bool Init(ContainerControl form, DataGridView dgv, List<DGVColumnInfo> cls)
        {
            if (form == null || dgv == null || cls == null)
            {
                return false;
            }
            myDGV = dgv;
            columns.Clear();
            clsList.Clear();
            int index = 0;
            foreach(var it in cls)
            {
                DGVColumnInfoEx ex = new DGVColumnInfoEx(it);
                columns[it.ColumnID] = ex;
                ex.DipplayIndex = index;
                index++;
                clsList.Add(ex);
            }

            foreach (var it in form.Controls)
            {
                DataGridViewTextBoxColumn clm = it as DataGridViewTextBoxColumn;
                if (clm == null)
                {
                    continue;
                }

                string key = Convert.ToString(clm.Tag);
                if (key == null)
                {
                    continue;
                }

                DGVColumnInfoEx ex = null;
                if (!columns.TryGetValue(key, out ex))
                {
                    continue;
                }

                if (ex != null)
                {
                    ex.Control = clm;
                }
            }

            foreach (var it in columns.Values)
            {
                if (it.Control != null)
                {
                    continue;
                }

                DataGridViewTextBoxColumn ex = new DataGridViewTextBoxColumn();
                ex.Tag = it.Column.ColumnID;
                it.Control = ex;
            }

            foreach (var it in columns.Values)
            {
                it.Control.HeaderText = it.Column.ColumnText;
                it.Control.DataPropertyName = it.Column.ColumnName;
            }
            SetWidth();
            return true;
        }

        /// <summary>
        /// 更新控件大小
        /// </summary>
        public void OnResize()
        {
            SetWidth();
        }

        /// <summary>
        /// 设置列宽
        /// </summary>
        private void SetWidth()
        {
            if (myDGV == null)
            {
                return;
            }
            int width = myDGV.Size.Width - 18;
            if (myDGV.RowHeadersVisible)
            {
                width -= myDGV.RowHeadersWidth;
            }

            myDGV.Columns.Clear();
            foreach (var it in clsList)
            {
                it.Control.Width = (width * it.Column.WidthPercent) / 100;
                it.Control.DisplayIndex = it.DipplayIndex;
                if (it.Column.Align != null)
                {
                    string align = it.Column.Align.Trim().ToLower();
                    if (align.Equals("left"))
                    {
                        it.Control.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        it.Control.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    if (align.Equals("right"))
                    {
                        it.Control.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        it.Control.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (align.Equals("center"))
                    {
                        it.Control.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        it.Control.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                myDGV.Columns.Add(it.Control);
            }
        }
    }
}
