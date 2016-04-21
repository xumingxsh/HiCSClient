using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HiCSUserControl.Common
{ 
    /// <summary>
    /// 使用配置文件设置列名，显示标题，列宽度（支持绝对宽度和百分比）
    /// XuminRong 2016.04.03
    /// </summary>
    public sealed class DGViewHelper
    {
        const int CheckColumnWidth = 20;/// 复选列宽度
        const int RowHeaderWidth = 20;// 编号列宽度

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dgv"></param>
        /// <param name="json"></param>
        /// <param name="usingCheck">是否使用复选列</param>
        /// <param name="usingNo">是否使用编号</param>
        /// <returns></returns>
        public bool Init(ContainerControl form, DataGridView dgv, string json, bool usingCheck = false, bool usingNo = false)
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
            bool result = Init(form, dgv, lst);

            if (usingCheck)
            {
                DataGridViewEvent.SetCheckColumns(dgv);
            }
            isUsingNo = usingNo;
            if (isUsingNo)
            {
                DataGridViewEvent.SetRowNo(dgv, RowHeaderWidth);
            }
            return true;
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
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
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

            InitExistColumns8TagAndCreateCheckBox(dgv); // 对已存在的列进行处理,并创建多选列
            CreateColumnsAndInit(dgv);// 创建不存在的列并设置相关信息
            OnResize();     // 设置列宽
            return true;
        }

        /// <summary>
        /// 对已存在的列进行处理,并创建多选列
        /// </summary>
        private void InitExistColumns8TagAndCreateCheckBox(DataGridView dgv)
        {
            bool hasCheck = false;
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
                    hasCheck = true;
                }
            }

            if (!hasCheck && isUsingCheck)
            {
                CreateCheckColumn();
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

                DataGridViewColumn ex = new DataGridViewTextBoxColumn();
                ex.Tag = it.Column.ColumnID;
                if (it.Column.IsShow == 0)
                {
                    ex.Visible = false;
                }
                ex.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                it.Control = ex;
            }

            foreach (var it in columns.Values)
            {
                it.Control.HeaderText = it.Column.ColumnText;
                it.Control.DataPropertyName = it.Column.ColumnName;
                it.Control.Name = it.Column.ColumnID;
            }
        }

        private void CreateCheckColumn()
        {
            checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            checkColumn.Name = "clChkColumn";
            checkColumn.HeaderText = "";
            checkColumn.Width = CheckColumnWidth;
            checkColumn.DisplayIndex = 0;

            DatagridViewCheckBoxHeaderCell cell = new DatagridViewCheckBoxHeaderCell();
            cell.OnCheckBoxClicked += DataGridViewEvent.SetCheckHeadEvent;
            checkColumn.HeaderCell = cell;
            checkColumn.Resizable = DataGridViewTriState.False;            
        }

        /// <summary>
        /// 取得视图某行某列的值
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public string GetCellValue(int rowIndex, int cellIndex)
        {
            if (myDGV == null)
            {
                return null;
            }
            if (rowIndex >= myDGV.Rows.Count)
            {
                return null;
            }
            if (cellIndex >= myDGV.ColumnCount)
            {
                return null;
            }
            return Convert.ToString(myDGV.Rows[rowIndex].Cells[cellIndex].Value);
        }

        /// <summary>
        /// 取得视图某行某列的值
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string GetCellValue(int rowIndex, string columnName)
        {
            if (myDGV == null)
            {
                return null;
            }
            if (rowIndex >= myDGV.Rows.Count)
            {
                return null;
            }

            if (!myDGV.Columns.Contains(columnName))
            {
                return null;
            }

            int cellIndex = myDGV.Columns[columnName].Index;
            return GetCellValue(rowIndex, cellIndex);
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
            if (isUsingNo)
            {
                width -= RowHeaderWidth;
            }
            myDGV.Columns.Clear();
            int startIndex = 0;
            if (checkColumn != null)
            {
                width -= checkColumn.Width;
                startIndex++;
                myDGV.Columns.Add(checkColumn);
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
                myDGV.Columns.Add(it.Control);
            }
        }
        private Dictionary<string, DGVColumnInfoEx> columns = new Dictionary<string, DGVColumnInfoEx>();
        private List<DGVColumnInfoEx> clsList = new List<DGVColumnInfoEx>(); // 存储的列扩展信息
        private DataGridView myDGV;
        private bool isUsingNo = false;     // 是否使用行编号
        private bool isUsingCheck = false;  // 是否使用多选列
        private DataGridViewCheckBoxColumn checkColumn = null;  // 多选列

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
