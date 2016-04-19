using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace HiCSUserControl.Common
{
    /// <summary>
    /// 列信息类
    /// 该类应该为FormWrap的内部类,
    /// 但是内部类和inneral无法使用jsaon转换,所以定义为public
    /// XuminRong 2016.04.15
    /// </summary>
    public sealed class ControlInfo
    {
        /// <summary>
        /// 控件ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool CanNull { get; set; }

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Reg { get; set; }

        /// <summary>
        /// 错误提示信息
        /// </summary>
        public string Err { get; set; }
    }

    /// <summary>
    /// 窗体控件处理类
    /// XuminRong 2016.04.15
    /// </summary>
    public sealed class FormWrap
    {
        static System.Drawing.Color WarnColor = System.Drawing.Color.Yellow;
        static System.Drawing.Color NormalColor = System.Drawing.Color.White;

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
            foreach (var it in controlsInfo)
            {
                Control control;
                controls.TryGetValue((string)it.ID, out control);
                if (control == null)
                {
                    continue;
                }
                ControlInfo validite = null;
                controlValidite.TryGetValue((string)it.ID, out validite);
                if (validite == null)
                {
                    continue;
                }
                Validite(control, validite);
            }
        }

        private void Validite(Control control, ControlInfo validite)
        {
            TextBox box = control as TextBox;
            if (box != null && !validite.CanNull && control.Text.Trim().Length < 2)
            {
                control.BackColor = WarnColor;
                control.Focus();
                throw new Exception(validite.Err);
            }
        }

        List<ControlInfo> controlsInfo = null;

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
            controlsInfo = HiCSUtil.Json.Json2Obj<List<ControlInfo>>(json);
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
                control.KeyDown += control_KeyDown;
                //control.KeyPress += OnKeyPress;
            }
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box != null && box.BackColor == WarnColor)
            {
                box.BackColor = NormalColor;
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
