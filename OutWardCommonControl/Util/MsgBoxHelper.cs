using System;
using System.Windows.Forms;

namespace OutWardCommonControl.Util
{
    /// <summary>
    /// 消息提示
    /// </summary>
    public class MsgBoxHelper
    {
        public static void Show(string script, string caption)
        {
            MessageBox.Show(script, caption);
        }
        public static void Notiy(string script)
        {
            Show(script, "提示");
        }
        public static void Error(string script)
        {
            Show(script, "错误");
        }

        public static bool Confirm(string script)
        {
            return Confirm(script, "确认");
        }

        public static bool Confirm(string script, string caption)
        {
            DialogResult result = MessageBox.Show(script, caption, MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {
                return true;
            }
            return false;
        }
    }
}
