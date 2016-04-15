using System;
using System.Windows.Forms;

namespace HiCSCommonControl.Util
{
    /// <summary>
    /// 消息提示类
    /// XuminRong 2016.04.15
    /// </summary>
    public class MsgBoxHelper
    {
        /// <summary>
        /// 提示显示信息
        /// </summary>
        /// <param name="script"></param>
        /// <param name="caption"></param>
        public static void Show(string script, string caption)
        {
            MessageBox.Show(script, caption);
        }

        /// <summary>
        /// 提示信息提示
        /// </summary>
        /// <param name="script"></param>
        public static void Notiy(string script)
        {
            Show(script, "提示");
        }

        /// <summary>
        /// 报警提示
        /// </summary>
        /// <param name="script"></param>
        public static void Alarm(string script)
        {
            Show(script, "警告");
        }

        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="script"></param>
        public static void Error(string script)
        {
            Show(script, "错误");
        }

        /// <summary>
        /// 判断提示信息
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static bool Confirm(string script)
        {
            return Confirm(script, "确认");
        }

        /// <summary>
        /// 判断提示信息
        /// </summary>
        /// <param name="script"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
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
