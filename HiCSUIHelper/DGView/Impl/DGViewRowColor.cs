using System;
using System.Drawing;
using System.Windows.Forms;

namespace HiCSUIHelper
{
    /// <summary>
    /// 多选行显示特殊颜色
    /// </summary>
    class DGViewRowColor
    {
        System.Drawing.Color defColor;
        System.Drawing.Color altColor;
        System.Drawing.Color selColor;

        int CheckBoxIndex = -1;

        public void SetRowColor(DataGridView dgv, int chkIndex, System.Drawing.Color def, System.Drawing.Color alter, System.Drawing.Color current, System.Drawing.Color select)
        {            
            if (dgv == null)
            {
                return;
            }

            defColor = def;
            altColor = alter;
            selColor = select;

            if (chkIndex < 0)
            {
                SetRowColor(dgv, defColor, altColor, selColor);
            }
            else
            {
                CheckBoxIndex = chkIndex;
                dgv.DefaultCellStyle.SelectionBackColor = current;
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = current;
                dgv.RowPostPaint += SetRowColor_Evt;
            }
        }

        /// <summary>
        /// 设置行颜色
        /// </summary>
        /// <param name="def"></param>
        /// <param name="alter"></param>
        /// <param name="select"></param>
        public void SetRowColor(DataGridView dgv, System.Drawing.Color def, System.Drawing.Color alter, System.Drawing.Color select)
        {
            if (dgv == null)
            {
                return;
            }
            dgv.DefaultCellStyle.BackColor = def;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = alter;
            dgv.DefaultCellStyle.SelectionBackColor = select;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = select;
        }
        private void SetRowColor_Evt(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            if (DGViewUtil.IsRowSelected(dgv, CheckBoxIndex, e.RowIndex))
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
    }
}
