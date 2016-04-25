using System;
using System.Drawing;
using System.Windows.Forms;

namespace HiCSUserControl
{
    public static class DGViewUtil
    {
        /// <summary>
        /// 设置行号
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="width"></param>
        public static void SetRowNo(DataGridView dgv, int width = 0)
        {
            if (width == 0)
            {
                width = (int)dgv.RowHeadersDefaultCellStyle.Font.Size * 2 + 8;
            }
            DGViewEvent.SetRowNo(dgv, width);
        }

        /// <summary>
        /// 创建多选框
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public static DataGridViewCheckBoxColumn CreateCheckBoxColumn(int width = 20, bool createHead = false)
        {
            if (width < 1)
            {
                width = 20;
            }
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            checkColumn.Width = width;
            checkColumn.DisplayIndex = 0;
            checkColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            if (createHead)
            {
                CreateChkColumnHead(checkColumn);
            }
            return checkColumn;
        }

        /// <summary>
        /// 为多选列生成头
        /// </summary>
        /// <param name="column"></param>
        public static void CreateChkColumnHead(DataGridViewCheckBoxColumn column)
        {
            if (column == null)
            {
                return;
            }

            DatagridViewCheckBoxHeaderCell cell = new DatagridViewCheckBoxHeaderCell();
            cell.OnCheckBoxClicked += DGViewEvent.SetCheckHeadEvent;
            column.HeaderCell = cell;
            column.Resizable = DataGridViewTriState.False;
        }

        /// <summary>
        /// 为多选列生成头
        /// </summary>
        /// <param name="column"></param>
        public static void CreateChkColumnHead(DataGridView dgv)
        {
            DataGridViewCheckBoxColumn column = FindChkColumn(dgv);
            CreateChkColumnHead(column);
        }

        /// <summary>
        /// 查找datagridview的多选列
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataGridViewCheckBoxColumn FindChkColumn(DataGridView dgv)
        {
            foreach (DataGridViewColumn it in dgv.Columns)
            {
                if (it is DataGridViewCheckBoxColumn)
                {
                    return it as DataGridViewCheckBoxColumn;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据列名称,取得列索引
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int GetColumnIndex(DataGridView dgv, string columnName)
        {
            if (dgv == null)
            {
                return -1;
            }

            if (!dgv.Columns.Contains(columnName))
            {
                return -1;
            }

            return dgv.Columns[columnName].Index; ;
        }

        /// <summary>
        /// 取得表格值
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetCellValue(DataGridView dgv, int rowIndex, string columnName)
        {
            int cellIndex = GetColumnIndex(dgv, columnName);
            if (cellIndex < 0)
            {
                return "";
            }
            return GetCellValue(dgv, rowIndex, cellIndex);
        }


        /// <summary>
        /// 取得表格值
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public static string GetCellValue(DataGridView dgv, int rowIndex, int cellIndex)
        {
            if (dgv == null)
            {
                return "";
            }
            if (rowIndex >= dgv.Rows.Count)
            {
                return "";
            }
            if (cellIndex >= dgv.ColumnCount)
            {
                return "";
            }
            return Convert.ToString(dgv.Rows[rowIndex].Cells[cellIndex].Value);
        }

        /// <summary>
        /// 某行是否已选择
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static bool IsRowSelected(DataGridView dgv, int chkIndex, int rowIndex)
        {
            if (chkIndex < 0)
            {
                return false;
            }
            if (rowIndex >= dgv.Rows.Count)
            {
                return false;
            }
            return Convert.ToBoolean(dgv.Rows[rowIndex].Cells[chkIndex].Value);
        }

        /// <summary>
        /// 获得鼠标所处行
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="mouseLocation_Y"></param>
        /// <returns></returns>
        public static int GetMouseIndexAt(DataGridView dgv, int mouseLocation_Y)
        {
            if (dgv.FirstDisplayedScrollingRowIndex < 0)
            {
                return -1;  // no rows.   
            }
            if (dgv.ColumnHeadersVisible == true && mouseLocation_Y <= dgv.ColumnHeadersHeight)
            {
                return -1;
            }
            int index = dgv.FirstDisplayedScrollingRowIndex;
            int displayedCount = dgv.DisplayedRowCount(true);
            for (int k = 1; k <= displayedCount; )  // 因为行不能ReOrder，故只需要搜索显示的行   
            {
                if (dgv.Rows[index].Visible == true)
                {
                    Rectangle rect = dgv.GetRowDisplayRectangle(index, true);  // 取该区域的显示部分区域   
                    if (rect.Top <= mouseLocation_Y && mouseLocation_Y < rect.Bottom)
                    {
                        return index;
                    }
                    k++;  // 只计数显示的行;   
                }
                index++;
            }
            return -1;
        }  
    }
}
