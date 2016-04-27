using System;
using System.Drawing;
using System.Windows.Forms;

namespace HiCSUIHelper
{
    /// <summary>
    /// DataGridView事件实现
    /// </summary>
    static class DGViewEvent
    {
        /// <summary>
        /// 设置行编号及相关事件
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="rowHeadWidth"></param>
        public static void SetRowNo(DataGridView dgv, int rowHeadWidth)
        {
            dgv.RowPostPaint += RowPostPaint;
            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = rowHeadWidth;
        }

        /// <summary>
        /// 设置多选列事件
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columnsWidth"></param>
        public static void SetCheckColumns(DataGridView dgv)
        {
            dgv.CellClick += CheckCellClick;
        }

        /// <summary>
        /// 设置多选列列头事件
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="state"></param>
        public static void SetCheckHeadEvent(DataGridView dgv, bool state)
        {
            int checkBoxIndex = -1;
            foreach (DataGridViewColumn it in dgv.Columns)
            {
                DataGridViewColumn cl = it as DataGridViewCheckBoxColumn;
                if (cl != null)
                {
                    checkBoxIndex = cl.Index;
                    break;
                }
            }

            if (checkBoxIndex < 0)
            {
                return;
            }
            foreach (DataGridViewRow it in dgv.Rows)
            {
                DataGridViewCheckBoxCell box = dgv.Rows[it.Index].Cells[checkBoxIndex] as DataGridViewCheckBoxCell;
                if (box == null)
                {
                    continue;
                }
                box.Value = state;
            }
        }

        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 行多选
        /// 如果是CellSelect模式,则需要选中checkbox,
        /// 如果是行选择模式,则选中任何一个Cell即可,其他的选择模式,不响应
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
            DataGridViewCheckBoxCell box = null;
            if (dgv.SelectionMode == DataGridViewSelectionMode.CellSelect)
            {
                box = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
            }
            if (dgv.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                box = GetRowSelect(dgv, e);
            }

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
            box.Value = !flag;
        }

        /// <summary>
        /// 取得备选列
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private static DataGridViewCheckBoxCell GetRowSelect(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell box = null;
            foreach (DataGridViewColumn it in dgv.Columns)
            {
                box = dgv.Rows[e.RowIndex].Cells[it.Index] as DataGridViewCheckBoxCell;
                if (box != null)
                {
                    break;
                }
            }
            return box;
        }
    }
}
