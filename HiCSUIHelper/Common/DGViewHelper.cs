﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HiCSUIHelper
{ 
    /// <summary>
    /// 使用配置文件设置列名，显示标题，列宽度（支持绝对宽度和百分比）
    /// XuminRong 2016.04.03
    /// </summary>
    public sealed class DGViewHelper
    {
        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dgv"></param>
        /// <param name="json"></param>
        /// <param name="usingCheck">是否使用复选列</param>
        /// <param name="usingNo">是否使用编号</param>
        /// <returns></returns>
        public bool Init(DataGridView dgv, string json, bool usingCheck = false, bool usingNo = false)
        {
            List<DGVColumnInfo> lst = null;
            if (!string.IsNullOrWhiteSpace(json))
            {
                lst = HiCSUtil.Json.Json2Obj<List<DGVColumnInfo>>(json);
            }
            else
            {
                lst = new List<DGVColumnInfo>();
            }
            isUsingCheck = usingCheck;
            bool result = Init(dgv, lst);

            if (!isUsingCheck)
            {
                isUsingCheck = ColumnHasChk();
            }
            if (isUsingCheck)
            {
                DGViewEvent.SetCheckColumns(dgv);
            }
            isUsingNo = usingNo;
            if (isUsingNo)
            {
                DGViewUtil.SetRowNo(dgv);
            }
            return true;
        }

        private int chkWidth = 20;
        private bool useHead = false;
        private string hedText = "";
        private bool isCheckLast = false;
        public void SetChkColumn(bool isLast, bool isHeadCheck, int width = 20, string headText = "")
        {
            isCheckLast = isLast;
            useHead = isHeadCheck;
            chkWidth = width;
            hedText = headText;
        }


        System.Drawing.Color defColor;
        System.Drawing.Color altColor;
        System.Drawing.Color selColor;

        /// <summary>
        /// 设置行颜色
        /// </summary>
        /// <param name="def"></param>
        /// <param name="alter"></param>
        /// <param name="select"></param>
        /// <param name="current"></param>
        public void SetRowColor(System.Drawing.Color def, System.Drawing.Color alter, System.Drawing.Color select, System.Drawing.Color current)
        {
            if (myDGV == null)
            {
                return;
            }

            defColor = def;
            altColor = alter;
            selColor = select;

            if (CheckBoxIndex < 0)
            {
                SetRowColor(defColor, altColor, selColor);
            }
            else
            {
                myDGV.DefaultCellStyle.SelectionBackColor = current;
                myDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = current;
                myDGV.RowPostPaint += SetRowColor_Evt;
            }
        }

        /// <summary>
        /// 设置行颜色
        /// </summary>
        /// <param name="def"></param>
        /// <param name="alter"></param>
        /// <param name="select"></param>
        public void SetRowColor(System.Drawing.Color def, System.Drawing.Color alter, System.Drawing.Color select)
        {
            if (myDGV == null)
            {
                return;
            }
            defColor = def;
            altColor = alter;
            selColor = select;
            myDGV.DefaultCellStyle.BackColor = def;
            myDGV.AlternatingRowsDefaultCellStyle.BackColor = alter;
            myDGV.DefaultCellStyle.SelectionBackColor = select;
            myDGV.AlternatingRowsDefaultCellStyle.SelectionBackColor = select;
        }
        private void SetRowColor_Evt(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            if (IsRowSelected(e.RowIndex))
            {
                SetColor(row.DefaultCellStyle, selColor);
            }
            else
            {
                if (e.RowIndex % 2 == 0)
                {
                    SetColor(row.DefaultCellStyle, defColor);
                }
                else
                {
                    SetColor(row.DefaultCellStyle, altColor);
                }
            }
        }

        private void SetColor(DataGridViewCellStyle style, System.Drawing.Color color)
        {
            if (style.BackColor != color)
            {
                style.BackColor = color;
            }
        }

        /// <summary>
        /// 某行是否已选择
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public bool IsRowSelected(int rowIndex)
        {
            return DGViewUtil.IsRowSelected(myDGV, CheckBoxIndex, rowIndex);
        }

        /// <summary>
        /// 取得视图某行某列的值
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public string GetCellValue(int rowIndex, int cellIndex)
        {
            return DGViewUtil.GetCellValue(myDGV, rowIndex, cellIndex);
        }

        /// <summary>
        /// 取得视图某行某列的值
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string GetCellValue(int rowIndex, string columnName)
        {
            return DGViewUtil.GetCellValue(myDGV, rowIndex, columnName);
        }

        /// <summary>
        /// 设置列宽
        /// </summary>
        public void OnResize()
        {
            if (myDGV == null)
            {
                return;
            }


            int width = myDGV.Size.Width - 5;
            if (myDGV.RowHeadersVisible)
            {
                width -= myDGV.RowHeadersWidth;
            }

            int startIndex = 0;
            if (checkColumn != null)
            {
                if (!ColumnHasChk())
                {
                    width -= checkColumn.Width;
                    if (!isCheckLast)
                    {
                        startIndex++;
                    }
                }

                if (CheckBoxIndex < 0)
                {
                    CheckBoxIndex = checkColumn.Index;
                }
            }

            int pinWidth = 0;

            foreach (var it in clsList)
            {
                if (it.Column.Width > 0)
                {
                    pinWidth += it.Column.Width;
                }
            }

            width -= pinWidth;

            if (width < 0)
            {
                width = myDGV.Size.Width;
            }

            foreach (var it in clsList)
            {
                if (it.Column.Width > 0)
                {
                    it.Control.Width = it.Column.Width;
                }
                else
                {
                    it.Control.Width = (width * it.Column.WidthPercent) / 100;
                }
                it.Control.DisplayIndex = it.DipplayIndex + startIndex;
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
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dgv"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        private bool Init(DataGridView dgv, List<DGVColumnInfo> cls)
        {
            if (dgv == null || cls == null)
            {
                return false;
            }

            myDGV = dgv;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            InitExistColumns8Tag(dgv); // 对已存在的列进行处理

            foreach (var it in columns.Values)
            {
                if (it.Column.Type.ToLower().Equals("chk") || 
                    it.Column.Type.ToLower().Equals("chk_head"))
                {
                    isUsingCheck = false;
                    break;
                }
            }

            if (CheckBoxIndex < 0 && isUsingCheck)  // 并创建多选列
            {
                checkColumn = DGViewUtil.CreateCheckBoxColumn(chkWidth, useHead);
                if (!string.IsNullOrEmpty(hedText))
                {
                    checkColumn.HeaderText = hedText;
                }
            }

            if (!isCheckLast && checkColumn != null)
			{				
                myDGV.Columns.Add(checkColumn);
			}

            CreateColumnsAndInit(dgv);// 创建不存在的列并设置相关信息

            if (isCheckLast && checkColumn != null)
			{				
                myDGV.Columns.Add(checkColumn);
			}
			
            OnResize();     // 设置列宽
            return true;
        }

        private string initHasChk = null;
        private bool ColumnHasChk()
        {
            if (initHasChk != null)
            {
                return initHasChk.Equals("1");
            }
            initHasChk = "0";
            foreach (var it in columns.Values)
            {
                if (it.Column.Type.ToLower().Equals("chk") ||
                    it.Column.Type.ToLower().Equals("chk_head"))
                {
                    initHasChk = "1";
                    break;
                }
            }
            return initHasChk.Equals("1"); 
        }

        /// <summary>
        /// 对已存在的列进行处理,并创建多选列
        /// </summary>
        private void InitExistColumns8Tag(DataGridView dgv)
        {
            foreach (DataGridViewColumn it in dgv.Columns)
            {
                string key = Convert.ToString(it.Tag);
                if (string.IsNullOrWhiteSpace(key))
                {
                    key = it.Name;
                }

                DGVColumnInfoEx ex = null;
                if (!columns.TryGetValue(key, out ex))
                {
                    continue;
                }

                if ((string)it.Tag != key)
                {
                    it.Tag = key;
                }

                if (ex != null)
                {
                    ex.Control = it;
                }

                if (it is DataGridViewCheckBoxColumn)
                {
                    CheckBoxIndex = it.Index;
                }
            }
        }
        
        /// <summary>
        /// 对已存在的列进行处理,并创建多选列
        /// </summary>
        private void CreateColumnsAndInit(DataGridView dgv)
        {
            foreach (var it in columns.Values)
            {
                if (it.Control != null)
                {
                    continue;
                }

                if (it.Column.Type.ToLower().Equals("chk"))
                {
                    checkColumn = DGViewUtil.CreateCheckBoxColumn();
                    it.Control = checkColumn;
                    dgv.Columns.Add(checkColumn);
                }
                else if (it.Column.Type.ToLower().Equals("chk_head"))
                {
                    checkColumn = DGViewUtil.CreateCheckBoxColumn(20, true);
                    it.Control = checkColumn;
                    dgv.Columns.Add(checkColumn);
                }
                else
                {
                    DataGridViewColumn ex = new DataGridViewTextBoxColumn();
                    ex.Tag = it.Column.ColumnID;
                    if (it.Column.IsShow == 0)
                    {
                        ex.Visible = false;
                    }
                    ex.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    it.Control = ex;
                    dgv.Columns.Add(ex);
                }
            }

            foreach (var it in columns.Values)
            {
                it.Control.HeaderText = it.Column.ColumnText;
                it.Control.DataPropertyName = it.Column.ColumnName;
                it.Control.Name = it.Column.ColumnID;
            }
        }

        private Dictionary<string, DGVColumnInfoEx> columns = new Dictionary<string, DGVColumnInfoEx>();
        private List<DGVColumnInfoEx> clsList = new List<DGVColumnInfoEx>(); // 存储的列扩展信息
        private DataGridView myDGV;
        private bool isUsingNo = false;     // 是否使用行编号
        private bool isUsingCheck = false;  // 是否使用多选列
        private DataGridViewCheckBoxColumn checkColumn = null;  // 多选列
        private int CheckBoxIndex = -1; // 多选列索引号

        /// <summary>
        /// 列信息扩展
        /// </summary>
        class DGVColumnInfoEx
        {
            public DGVColumnInfoEx(DGVColumnInfo cl)
            {
                Column = cl;
            }
            public DGVColumnInfo Column { get; set; }       // 列信息
            public DataGridViewColumn Control { get; set; } // 对应的实际列
            public int DipplayIndex { get; set; }           // 显示顺序
        }
    }
}