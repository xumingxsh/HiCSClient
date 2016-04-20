using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HiCSUserControl.Common
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
        }
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

    }

    /// <summary>
    /// 使用配置文件设置列名，显示标题，列宽度（支持绝对宽度和百分比）
    /// XuminRong 2016.04.03
    /// </summary>
    public sealed class DGViewHelper
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

            public DataGridViewColumn Control { get; set; }

            public int DipplayIndex { get; set; }
        }
        private Dictionary<string, DGVColumnInfoEx> columns = new Dictionary<string,DGVColumnInfoEx>();
        private List<DGVColumnInfoEx> clsList = new List<DGVColumnInfoEx>();
        private DataGridView myDGV;

        private bool isUsingNo = false;
        private bool isUsingCheck = false;

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
                dgv.CellClick += CheckCellClick;
            }
            isUsingNo = usingNo;
            if (isUsingNo)
            {
                dgv.RowPostPaint += RowPostPaint;
                dgv.RowHeadersVisible = true;
                dgv.RowHeadersWidth = RowHeaderWidth;
            }
            return true;
        }

        /// <summary>
        /// 复选列宽度
        /// </summary>
        private static int CheckColumnWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// 编号列宽度
        /// </summary>
        private static int RowHeaderWidth
        {
            get
            {
                return 20;
            }
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
            SetWidth();
            return true;
        }

        private DataGridViewCheckBoxColumn checkColumn = null;

        private void CreateCheckColumn()
        {
            checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            checkColumn.Name = "clChkColumn";
            checkColumn.HeaderText = "";
            checkColumn.Width = CheckColumnWidth;
            checkColumn.DisplayIndex = 0;

            DatagridViewCheckBoxHeaderCell cell = new DatagridViewCheckBoxHeaderCell();
            cell.OnCheckBoxClicked  += OnCheckBoxClicked;
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
        /// 更新控件大小,主要用于界面大小变化时的响应事件
        /// </summary>
        public void OnResize()
        {
            SetWidth();
        }

        /// <summary>
        /// 行多选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CheckCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            DataGridViewCheckBoxCell box = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
            if (box == null)
            {
                return;
            }
            object val = box.Value;
            bool flag = false;
            if (val != null)
            {
                flag = (bool)val;
            }
            dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !flag;
        }

        private static void RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    dgv.RowHeadersWidth - 4,
                    e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font,
                rectangle, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }

        private void OnCheckBoxClicked(bool state)
        {
            int checkBoxIndex = -1;
            foreach (DataGridViewColumn it in myDGV.Columns)
            {
                DataGridViewColumn cl = it as DataGridViewCheckBoxColumn;
                if (cl != null)
                {
                    checkBoxIndex = cl.DisplayIndex;
                    break;
                }
            }

            if (checkBoxIndex < 0)
            {
                return;
            }
            foreach (DataGridViewRow it in myDGV.Rows)
            {
                DataGridViewCheckBoxCell box = myDGV.Rows[it.Index].Cells[checkBoxIndex] as DataGridViewCheckBoxCell;
                if (box == null)
                {
                    continue;
                }
                box.Value = state;

            }
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
    }

    class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }
        public delegate void CheckBoxClickedHandler(bool state);
        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    this.DataGridView.InvalidateCell(this);
                }

            }
            base.OnMouseClick(e);
        }

    }
}
