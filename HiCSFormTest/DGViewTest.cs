using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HiCSUIHelper;
using HiCSModel;

namespace HiCSFormTest
{
    public partial class DGViewTest : Form
    {
        public DGViewTest()
        {
            InitializeComponent();
        }

        private void DGViewTest_Load(object sender, EventArgs e)
        {
            helper.Init(dgvView, HiCSUserControl.ViewConfig.GetView("Production.DGV_Materials_noChk"), true, true);            
            helper.SetRowColor(System.Drawing.Color.White,
                System.Drawing.Color.FromArgb(192, 192, 192),
                System.Drawing.Color.FromArgb(219, 229, 241),
                System.Drawing.Color.FromArgb(215, 228, 188));
            DataTable dt = HiCSProvider.DBHelper.ExecuteQuery("ProductProvid.GetProductProcessMaterial_parm3", "P1", "1", "");
            dgvView.DataSource = dt;
        }

        DGViewHelper helper = new DGViewHelper();

        private void DGViewTest_Resize(object sender, EventArgs e)
        {
            helper.OnResize();
        }
    }
}
