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
            if (!string.IsNullOrWhiteSpace(json))
            {
                clsList = HiCSUtil.Json.Json2Obj<List<DGVColumnInfo>>(json);
            }
            else
            {
                clsList = new List<DGVColumnInfo>();
            }

            int index = 0;
            foreach (var it in clsList)
            {
                columns[it.ColumnID] = it;
                it.DipplayIndex = index;
                index++;
            }
            bool result = Init(dgv, usingCheck);

            if (usingCheck || ColumnHasChk())   // 用户自己添加的列不需要自动添加相关事件
            {
                dgv.CellClick += DGViewEvent.CheckCellClick; // 设置多选控件事件
            }

            if (usingNo)
            {
                DGViewUtil.SetRowNo(dgv);
            }
            return true;
        }

        DGViewRowColor rowsColorHelper = new DGViewRowColor();

        /// <summary>
        /// 设置行颜色
        /// </summary>
        /// <param name="def"></param>
        /// <param name="alter"></param>
        /// <param name="select"></param>
        /// <param name="current"></param>
        public void SetRowColor(System.Drawing.Color def, System.Drawing.Color alter, System.Drawing.Color current, System.Drawing.Color select)
        {
            rowsColorHelper.SetRowColor(myDGV, CheckBoxIndex, def, alter, current, select);
        }

        /// <summary>
        /// 设置行颜色
        /// </summary>
        /// <param name="def"></param>
        /// <param name="alter"></param>
        /// <param name="select"></param>
        public void SetRowColor(System.Drawing.Color def, System.Drawing.Color alter, System.Drawing.Color current)
        {
            rowsColorHelper.SetRowColor(myDGV, def, alter, current);
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

            if (checkColumn != null)
            {
                CheckBoxIndex = checkColumn.Index;
            }

            int startIndex = 0;  
            if (IsAutoCreateChkColumn())
            {
                width -= checkColumn.Width;
                startIndex++;
            }

            int pinWidth = DGVColumnInfo.GetWidths(clsList);

            width -= pinWidth;

            if (width < 0)
            {
                width = myDGV.Size.Width;
            }

            DGVColumnInfo.ControlsResize(clsList, width, startIndex);   // 重新设置列宽度
        }

        private bool IsAutoCreateChkColumn()
        {
            return checkColumn != null && checkColumn.DisplayIndex == 0 &&
                checkColumn.HeaderCell is DatagridViewCheckBoxHeaderCell && !ColumnHasChk();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dgv"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        private bool Init(DataGridView dgv, bool isUsingCheck)
        {
            if (dgv == null)
            {
                return false;
            }

            myDGV = dgv;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            InitExistColumns8Tag(dgv); // 对已存在的列进行处理

            if (CheckBoxIndex < 0 && isUsingCheck && !ColumnHasChk())  // 自动创建多选列
            {
                checkColumn = DGViewUtil.CreateCheckBoxColumn(20, true);
                myDGV.Columns.Add(checkColumn);
            }


            DataGridViewCheckBoxColumn chk = DGVColumnInfo.CreateAndInitControls(clsList, dgv);// 创建不存在的列并设置相关信息
            if (chk != null) // 自动创建多选列
            {
                checkColumn = chk;
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
            initHasChk = DGVColumnInfo.HasChkColumn(clsList) ? "1" : "0";
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

                DGVColumnInfo ex = null;
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

        private Dictionary<string, DGVColumnInfo> columns = new Dictionary<string, DGVColumnInfo>();
        private List<DGVColumnInfo> clsList = new List<DGVColumnInfo>(); // 存储的列扩展信息
        private DataGridView myDGV;
        private DataGridViewCheckBoxColumn checkColumn = null;  // 多选列
        private int CheckBoxIndex = -1; // 多选列索引号
    }
}
