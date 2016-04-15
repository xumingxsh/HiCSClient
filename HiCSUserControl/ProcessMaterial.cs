using System;
using System.Data;
using System.Windows.Forms;

using HiCSProvid;
using HiCSModel;
using HiCSCommonControl;

namespace HiCSUserControl
{
    public partial class ProcessMaterial : UserControl
    {
        public ProcessMaterial()
        {
            InitializeComponent();
        }


        public delegate void OnDbClickHandle(Material material);

        private OnDbClickHandle dbHandler = null;
        public void SetDbClick(OnDbClickHandle evt)
        {
            dbHandler = evt;
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
        public void SetProcess(string prsID, ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            SetProcess(productID, prsID, type);
        }


        public void SetProcess(ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            SetProcess(productID, processID, type);
        }

        private void ProcessMaterial_Load(object sender, EventArgs e)
        {
            dgvHelper.Init(this, dgvMaterial, ViewConfig.ViewDefault.ProcessMaterial_DGV);
        }
        private void dgvMaterial_SizeChanged(object sender, EventArgs e)
        {
            dgvHelper.OnResize();
        }

        private void dgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dbHandler == null)
            {
                return;
            }
            int index = e.RowIndex;

            Material material = new Material();
            HiCBO.CBO.FillObject<Material>(material, (ref object objValue, string name) =>
                {
                    objValue = dgvHelper.GetCellValue(index, name);
                    return true;
                });

            dbHandler(material);
        }

        string productID;
        string processID;

        DGViewHelper dgvHelper = new DGViewHelper();
    }
}
