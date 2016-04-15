using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HiCSCommonControl.Util;

namespace HiCSCommonControl
{
    public sealed class ControlInfo
    {
        public string ID { get; set; }
        public bool CanNull { get; set; }
        public string Reg { get; set; }
        public string Err { get; set; }
    }
    public sealed class FormWrap
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
            controlsInfo = JsonHelper.Json2Obj<List<ControlInfo>>(json);
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
                //control.KeyPress += OnKeyPress;
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
