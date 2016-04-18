using System;
using System.Windows.Forms;

namespace HiCSFormTest
{
    public partial class ProcessMaterial_DBClick : Form
    {
        public ProcessMaterial_DBClick()
        {
            InitializeComponent();
        }

        private void ProcessMaterial_DBClick_Load(object sender, EventArgs e)
        {
            processMaterial1.SetProcess("P1", "1");
            processMaterial1.SetDbClick((HiCSModel.Material material) =>
            {
                string text = HiCSUtil.Json.Obj2Json<HiCSModel.Material>(material);
                HiCSCommonControl.Util.MsgBoxHelper.Notiy(text);
            });
        }
    }
}
