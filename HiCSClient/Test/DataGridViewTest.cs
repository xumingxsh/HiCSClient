using System;
using System.Data;
using System.Windows.Forms;


using HiCSClient.CommonConrol;

namespace HiCSClient.Test
{
    public partial class DataGridViewTest : UserControl
    {
        DGViewHelper helper = new DGViewHelper();

        string text = @"[
{
""ColumnID"":""ColumnID"",
""ColumnText"":""Column ID Test"",
""ColumnName"":""ColumnID"",
""WidthPercent"":30,
""Align"":""right""
},
{
""ColumnID"":""ColumnName"",
""ColumnText"":""Column Name Test"",
""ColumnName"":""ColumnName"",
""WidthPercent"":70,
""Align"":""center""
}
]
";
        public DataGridViewTest()
        {
            InitializeComponent();
        }

        private void DataGridViewTest_Load(object sender, EventArgs e)
        {
            helper.Init(this, dgvTest1, text);

            DataTable dt = new DataTable();
            dt.Columns.Add("ColumnID");
            dt.Columns.Add("ColumnName");

            for (int i = 0; i < 100; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ColumnID"] = i;
                dr["ColumnName"] = 100 - i;
                dt.Rows.Add(dr);
            }

            dgvTest1.DataSource = dt;
        }

        private void DataGridViewTest_Resize(object sender, EventArgs e)
        {
        }

        private void DataGridViewTest_SizeChanged(object sender, EventArgs e)
        {
            helper.OnResize();
        }
    }
}
