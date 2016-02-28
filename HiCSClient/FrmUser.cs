using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

using System.Text.RegularExpressions;

namespace HiCSClient
{
    public partial class frmUser : Form
    {
        string controlInfo = @"[{""ID"":""Name"",""CanNull"":""false"",""Reg"":""""},
{""ID"":""EMail"",""CanNull"":""false"",""Reg"":""""},
{""ID"":""Address"",""CanNull"":""false"",""Reg"":""""},
{""ID"":""Age"",""CanNull"":""false"",""Reg"":""^\\d{2,3]""}]";
        public frmUser()
        {
            InitializeComponent();
        }

        FormWrap wrap = null;

        private void frmUser_Load(object sender, EventArgs e)
        {
            if (wrap == null)
            {
                wrap = new FormWrap();
                wrap.InitControlsInfo(this, controlInfo);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
    class ControlInfo
    {
        public string ID { get; set; }
        public bool CanNull { get; set; }
        public string Reg { get; set; }
    }

    class FormWrap
    {

        Dictionary<string, ControlInfo> controlValidite = new Dictionary<string, ControlInfo>();
        Dictionary<string, Control> controls = new Dictionary<string, Control>();

        /// <summary>
        /// 设置控件初始值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void SetFormValue<T>(T t)
        {
            foreach (var it in controls)
            {
            }
        }

        /// <summary>
        /// 获得界面值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetFormValue<T>() where T : new()
        {
            T t = new T();
            foreach (var it in controls)
            {
            }
            return t;
        }

        /// <summary>
        /// 检验数据合法性
        ///     如果失败，抛出异常
        /// </summary>
        public void Validite()
        {
            foreach (var it in controls)
            {
                ControlInfo validite = null;
                controlValidite.TryGetValue((string)it.Value.Tag, out validite);
                if (validite == null)
                {
                    continue;
                }
                Validite(it.Value, validite);
            }
        }

        private void Validite(Control control, ControlInfo validite)
        {

        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        /// <param name="form"></param>
        /// <param name="json"></param>
        public void InitControlsInfo(Form form, string json)
        {
            if (controlValidite.Count > 0)
            {
                return;
            }

            JavaScriptSerializer serial = new JavaScriptSerializer();
            List<ControlInfo> controlsInfo = serial.Deserialize<List<ControlInfo>>(json);
            foreach (ControlInfo it in controlsInfo)
            {
                controlValidite.Add(it.ID, it);
            }

            foreach (Control it in form.Controls)
            {
                if (it.Tag == null)
                {
                    continue;
                }

                string id = (string)it.Tag;

                controls.Add(id, it);

                ControlInfo valite = controlValidite[id];
                if (valite == null)
                {
                    continue;
                }
                if (it is TextBox)
                {
                    InitControl(it, valite);
                }
            }
        }

        private void InitControl(Control control, ControlInfo valite)
        {
            if (control is TextBox)
            {
                control.KeyPress += OnKeyPress;
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box == null)
            {
                return;
            }
            ControlInfo valite = controlValidite[(string)box.Tag];
            if (valite == null)
            {
                return;
            }

            if (valite.Reg == null || valite.Reg.Trim().Equals(""))
            {
                return;
            }


            string text = box.Text.Trim();
            string newText = text + e.KeyChar;
            if (!Regex.IsMatch(newText, valite.Reg))
            {
                e.Handled = false;
            }
        }
    }
}
