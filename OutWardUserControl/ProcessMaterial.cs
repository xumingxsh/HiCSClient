using System;
using System.Data;
using System.Windows.Forms;

using OutWardProvid;
using OutWardModel;
using OutWardCommonControl;

namespace OutWardUserControl
{
    public partial class ProcessMaterial : UserControl
    {
        public ProcessMaterial()
        {
            InitializeComponent();
        }

        public void SetProcess(string pdeID, string prsID, ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            productID = pdeID;
            processID = prsID;

            DataTable dtMaterial = ProductProvid.GetProcessMaterial(productID, processID);

            if (dtMaterial == null)
            {
                return;
            }
            DataView dv = dtMaterial.DefaultView;
            if (ProvidEnum.MaterialType.Main != type)
            {
                dv.RowFilter = "MType=" + (int)type;
            }

            dgvMaterial.DataSource = dv;
        }

        private void ProcessMaterial_Load(object sender, EventArgs e)
        {
            dgvHelper.Init(this, dgvMaterial, dgvView);
        }
        private void dgvMaterial_SizeChanged(object sender, EventArgs e)
        {
            dgvHelper.OnResize();
        }

        string productID;
        string processID;
        ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main;
        DGViewHelper dgvHelper = new DGViewHelper();
        string dgvView = @"[
{
""ColumnID"":""Name"",
""ColumnText"":""名称"",
""ColumnName"":""Name"",
""WidthPercent"":40,
""Align"":""left"",
""IsShow"":1
},
{
""ColumnID"":""Model"",
""ColumnText"":""型号"",
""ColumnName"":""Model"",
""WidthPercent"":40,
""Align"":""left"",
""IsShow"":1
},
{
""ColumnID"":""Count"",
""ColumnText"":""数量"",
""ColumnName"":""Count"",
""WidthPercent"":20,
""Align"":""left"",
""IsShow"":1
},
{
""ColumnID"":""ProductID"",
""ColumnText"":"""",
""ColumnName"":""ProductID"",
""WidthPercent"":0,
""Align"":""center"",
""IsShow"":0
},
{
""ColumnID"":""ProcessId"",
""ColumnText"":"""",
""ColumnName"":""ProcessId"",
""WidthPercent"":0,
""Align"":""center"",
""IsShow"":0
}
]
";

    }
}
