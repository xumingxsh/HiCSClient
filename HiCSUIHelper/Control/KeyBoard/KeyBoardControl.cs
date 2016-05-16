using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HiCSUIHelper
{
    /// <summary>
    /// 虚拟键盘
    /// </summary>
    public partial class KeyBoardControl : UserControl
    {
        private bool isCapital = true;

        /// <summary>
        /// 构造函数
        /// </summary>
        public KeyBoardControl()
        {
            InitializeComponent();
        }

        LabelMouseProxy mouseProxy = new LabelMouseProxy();
        LabelMouseProxy capProxy = new LabelMouseProxy();

        private void KeyBoardControl_Load(object sender, EventArgs e)
        {		
            InitControl();          // 初始化控件,设置控件事件和鼠标颜色
            SetCaps2Uper(false);    // 设置字母大小写
            MoveInit();             // 初始化控件位置信息
        }
		
		private void InitControl()
		{
            mouseProxy.HoverColor = Color.Blue;
            mouseProxy.NormalColor = Color.LightSteelBlue;
            mouseProxy.PressedColor = Color.Red;
            foreach(Control control in this.Controls)
            {
                Label label = control as Label;
                if (label != null)
                {
                    label.Click += new System.EventHandler(this.btnCommon_Click);
                    if (label.Text.Equals("Caps"))
                    {
                        capProxy.HoverColor = Color.Blue;
                        capProxy.NormalColor = Color.LightSteelBlue;
                        capProxy.PressedColor = Color.Red;
                        capProxy.SetEvent(label);
                        continue;
                    }
                    label.BackColor = Color.LightSteelBlue;
                    mouseProxy.SetEvent(label);
                }
            }
		}

        /// <summary>
        /// 设置字母为大写
        /// </summary>
        /// <param name="isUper"></param>
        private void SetCaps2Uper(bool isUper)
        {
            isCapital = isUper;
            SetState(Win32API.VirtualKeys.VK_CAPITAL, isUper);
            if (!isUper)
            {
                capProxy.NormalColor = Color.LightSteelBlue;
            }
            else
            {
                capProxy.NormalColor = Color.Gray;
            }
            foreach (Control c in this.Controls)
            {
                if (IsChar(c.Text))
                {
                    if (isUper)
                    {
                        c.Text = c.Text.ToUpper();
                    }
                    else
                    {
                        c.Text = c.Text.ToLower();
                    }
                }
            }
        }

        /// <summary>
        /// 设置线程亲和
        /// </summary>
        /// <param name="b"></param>
        private void AttachThreadInput(bool b)
        {
            //设置线程亲和,附到前台窗口所在线程,只有在线程内才可以获取线程内控件的焦点
            //线程亲和: AttachThreadInput(目标线程标识, 当前线程标识, 非零值关联) 零表示取消
            //窗口所在的线程的标识: GetWindowThreadProcessId(窗体句柄, 这里返回进程标识)
            //当前的前台窗口的句柄: GetForegroundWindow()
            //当前程序所在的线程标识: GetCurrentThreadId()
            Win32API.AttachThreadInput(
                   Win32API.GetWindowThreadProcessId(
                            Win32API.GetForegroundWindow(), 0),
                   Win32API.GetCurrentThreadId(), Convert.ToInt32(b));
        }
        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void btnCommon_Click(object sender, EventArgs e)
        {
            AttachThreadInput(true); //设置线程亲和的关联
            btnCommon_Click_i(sender, e);
            AttachThreadInput(false); //取消线程亲和的关联
        }

        private void btnCommon_Click_i(object sender, EventArgs e)
        {
            int getFocus = Win32API.GetFocus();
            Label label = sender as Label;
            if (label == null)
            {
                return;
            }

            if (label.Text.Equals("Hide"))
            {
                this.Visible = false;
                return;
            }

            if (label.Text.Equals("Move"))
            {
                return;
            }

            if (label.Text.Equals("Caps"))
            {

                if (isCapital)
                {
                    SetCaps2Uper(false);
                }
                else
                {
                    SetCaps2Uper(true);
                }
                return;
            }
            if (Win32API.KeyValueListCode.ContainsKey(label.Text))
            {
                Keys keyvalue = Win32API.KeyValueListCode[label.Text];
                //向前台窗口发送按键消息
                Win32API.PostMessage(getFocus, Win32API.WM_KEYDOWN, (byte)keyvalue, 0);
            }
        }

        Dictionary<string, string> notCharArr = null;

        private Dictionary<string, string> NotCharArr
        {
            get
            {
                if (notCharArr == null)
                {
                    notCharArr = new Dictionary<string, string>();
                    string chars = "Caps,Enter,<-,-,+,.,0,1,2,3,4,5,6,7,8,9,Hide,Move";
                    string[] arr = chars.Split(',');
                    foreach(string it in arr)
                    {
                        notCharArr[it] = it;
                    }
                }
                return notCharArr;
            }
        }

        private bool IsChar(string text)
        {
            return !NotCharArr.ContainsKey(text);
        }

        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == Win32API.WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)Win32API.MA_NOACTIVATE;
            }
        }
        /// <summary>
        /// 添加样式
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //为窗体样式添加不激活标识
                cp.ExStyle = Win32API.WS_EX_NOACTIVATE;
                return cp;
            }
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        private static bool GetState(Win32API.VirtualKeys Key)
        {
            return (Win32API.GetKeyState((int)Key) == 1);
        }
        /// <summary>
        /// 设置键盘状态
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="State"></param>
        private static void SetState(Win32API.VirtualKeys Key, bool State)
        {
            if (State != GetState(Key))
            {
                Win32API.keybd_event((byte)Key, 0x45, Win32API.KEYEVENTF_EXTENDEDKEY | 0, 0);
                Win32API.keybd_event((byte)Key, 0x45, Win32API.KEYEVENTF_EXTENDEDKEY | Win32API.KEYEVENTF_KEYUP, 0);
            }
        }
        /// <summary>
        /// 发送组合键
        /// </summary>
        public static void SendKeyCombination(Keys SecondaryKey, Keys MainKey)
        {
            Win32API.keybd_event((byte)SecondaryKey, 0, 0, 0);
            Win32API.keybd_event((byte)MainKey, 0, 0, 0);
            Win32API.keybd_event((byte)MainKey, 0, Win32API.KEYEVENTF_KEYUP, 0);
            Win32API.keybd_event((byte)SecondaryKey, 0, Win32API.KEYEVENTF_KEYUP, 0);
        }

        int disX = 0;
        int disY = 0;
        private void MoveInit()
        {
            disX = lblMove.Left - this.Left + 20;// +lblMove.Width - 20;
            disY = lblMove.Top - this.Top + 20;// +lblMove.Height - 20;           
        }
        Point mouse_offset;
        Control userParent = null;

        /// <summary>
        /// 自定义键盘的活动控件
        /// </summary>
        public Control UserParent
        {
            set
            {
                userParent = value;
            }
            get
            {
                if (userParent == null)
                {
                    userParent = Parent;
                }
                return userParent;
            }
        }
        private void lblMove_MouseUp(object sender, MouseEventArgs e)
        {
            MoveFrom(e);
        }

        private void lblMove_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            MoveFrom(e);
        }

        private void MoveFrom(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Point mousePos = Control.MousePosition;
            mousePos.Offset(mouse_offset.X, mouse_offset.Y);
            mousePos.X = mousePos.X - disX;
            mousePos.Y = mousePos.Y - disY;
            if (mousePos.X + this.Width > UserParent.Right)
            {
                mousePos.X = UserParent.Right - this.Width;
            }
            if (mousePos.Y + this.Height > UserParent.Height)
            {
                mousePos.Y = UserParent.Top + UserParent.Height - this.Height;
            }

            if (mousePos.X < UserParent.Left)
            {
                mousePos.X = UserParent.Left;
            }
            if (mousePos.Y < UserParent.Top)
            {
                mousePos.Y = UserParent.Top + 20;
            }
            this.Location = this.Parent.PointToClient(mousePos);
        }

        private void KeyBoardControl_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
