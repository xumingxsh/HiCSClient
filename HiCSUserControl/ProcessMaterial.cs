using System;
using System.Data;
using System.Windows.Forms;

using HiCSModel;
using HiCSUserControl.Common;

namespace HiCSUserControl
{
    /// <summary>
    /// 物料列表
    /// </summary>
    public partial class ProcessMaterial : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProcessMaterial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="material"></param>
        public delegate void OnDbClickHandle(Material material);

        private OnDbClickHandle dbHandler = null;

        /// <summary>
        /// 设置双击事件
        /// </summary>
        /// <param name="evt"></param>
        public void SetDbClick(OnDbClickHandle evt)
        {
            dbHandler = evt;
        }

        private DataTable GetMaterials(ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            string condition = "";
            if (type != ProvidEnum.MaterialType.All)
            {
                condition = " and MType='" + Convert.ToInt16(type) + "'";
            }
            return HiCSControl.DBHelper.ExecuteQuery("ProductProvid.GetProductProcessMaterial_parm3", productID, processID, condition);
        }

        /// <summary>
        /// 设置工序
        /// </summary>
        /// <param name="pdeID"></param>
        /// <param name="prsID"></param>
        /// <param name="type"></param>
        public void SetProcess(string pdeID, string prsID, ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            productID = pdeID;
            processID = prsID;

            DataTable dtMaterial = GetMaterials(type);

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

        /// <summary>
        /// 设置工序
        /// </summary>
        /// <param name="prsID"></param>
        /// <param name="type"></param>
        public void SetProcess(string prsID, ProvidEnum.MaterialType type = ProvidEnum.MaterialType.Main)
        {
            SetProcess(productID, prsID, type);
        }

        /// <summary>
        /// 设置工序
        /// </summary>
        /// <param name="type"></param>
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
            HiCSUtil.CBO.FillObject<Material>(material, (ref object objValue, string name) =>
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
