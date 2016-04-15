using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            processMaterial1.SetDbClick((string productID, string processID, string materialID) =>
            {
                HiCSCommonControl.Util.MsgBoxHelper.Notiy(string.Format("产品：{0};工序：{1};物料：{2}", productID, processID, materialID));
            });
        }
    }
}
