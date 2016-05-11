using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HiCSUIHelper
{
    class Win32API
    {
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
           CharSet = CharSet.Unicode, ExactSpelling = true,
           CallingConvention = CallingConvention.StdCall)]
        public static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        public static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessageW")]
        public static extern int PostMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetFocus();

        [DllImport("user32.dll")]
        public static extern int AttachThreadInput(int idAttach, int idAttachTo, int fAttach);

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(int hwnd, int lpdwProcessId);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


        public static Dictionary<string, char> KeyValueList = new Dictionary<string, char>()
        {
            {"a",'a'},{"b",'b'},{"c",'c'},{"d",'d'},{"e",'e'},{"f",'f'},{"g",'g'},
            {"h",'h'},{"i",'i'},{"j",'j'},{"k",'k'},{"l",'l'},{"m",'m'},{"n",'n'},
            {"o",'o'},{"p",'p'},{"q",'q'},{"r",'r'},{"s",'s'},{"t",'t'},
            {"u",'u'},{"v",'v'},{"w",'w'},{"x",'x'},{"y",'y'},{"z",'z'},

            {"A",'A'},{"B",'B'},{"C",'C'},{"D",'D'},{"E",'E'},{"F",'F'},{"G",'G'},
            {"H",'H'},{"I",'I'},{"J",'J'},{"K",'K'},{"L",'L'},{"M",'M'},{"N",'N'},
            {"O",'O'},{"P",'P'},{"Q",'Q'},{"R",'R'},{"S",'S'},{"T",'T'},
            {"U",'U'},{"V",'V'},{"W",'W'},{"X",'X'},{"Y",'Y'},{"Z",'Z'},

            {"1",'1'},{"2",'2'},{"3",'3'},{"4",'4'},{"5",'5'},
            {"6",'6'},{"7",'7'},{"8",'8'},{"9",'9'},{"0",'0'},

            {"",' '},{"<-",'\b'},{"-",'-'},{"+",'+'},{".",'.'},{"Enter",'\r'},
        };
        public static Dictionary<string, Keys> KeyValueListCode = new Dictionary<string, Keys>()
        {
            {"a",Keys.A},{"b",Keys.B},{"c",Keys.C},{"d",Keys.D},{"e",Keys.E},{"f",Keys.F},{"g",Keys.G},
            {"h",Keys.H},{"i",Keys.I},{"j",Keys.J},{"k",Keys.K},{"l",Keys.L},{"m",Keys.M},{"n",Keys.N},
            {"o",Keys.O},{"p",Keys.P},{"q",Keys.Q},{"r",Keys.R},{"s",Keys.S},{"t",Keys.T},
            {"u",Keys.U},{"v",Keys.V},{"w",Keys.W},{"x",Keys.X},{"y",Keys.Y},{"z",Keys.Z},

            {"A",Keys.A},{"B",Keys.B},{"C",Keys.C},{"D",Keys.D},{"E",Keys.E},{"F",Keys.F},{"G",Keys.G},
            {"H",Keys.H},{"I",Keys.I},{"J",Keys.J},{"K",Keys.K},{"L",Keys.L},{"M",Keys.M},{"N",Keys.N},
            {"O",Keys.O},{"P",Keys.P},{"Q",Keys.Q},{"R",Keys.R},{"S",Keys.S},{"T",Keys.T},
            {"U",Keys.U},{"V",Keys.V},{"W",Keys.W},{"X",Keys.X},{"Y",Keys.Y},{"Z",Keys.Z},

            {"1",Keys.D1},{"2",Keys.D2},{"3",Keys.D3},{"4",Keys.D4},{"5",Keys.D5},
            {"6",Keys.D6},{"7",Keys.D7},{"8",Keys.D8},{"9",Keys.D9},{"0",Keys.D0},

            {"",Keys.Space},{"<-",Keys.Back},{"-",Keys.Subtract},{"+",Keys.Add},{".",Keys.Decimal},{"Enter",Keys.Enter},
        };

        public enum VirtualKeys : byte
        {
            VK_NUMLOCK = 0x90, //数字锁定键 
            VK_SCROLL = 0x91,  //滚动锁定 
            VK_CAPITAL = 0x14, //大小写锁定 
            VK_SHIFT = 0x10,   //Shift
            VK_CONTROL = 0x11, //Ctrl
            VK_A = 62
        }

        public const int WM_MOUSEACTIVATE = 0x21;
        public const int WM_KEYDOWN = 0x100;
        public const int WS_EX_MDICHILD = 0x40;
        public const int WS_VISIBLE = 0x10000000;
        public const int WM_CLOSE = 0x10;
        public const int WS_CHILD = 0x40000000;
        public const int WS_EX_NOACTIVATE = 0x8000000;

        public const int SWP_NOOWNERZORDER = 0x200;
        public const int SWP_NOREDRAW = 0x8;
        public const int SWP_NOZORDER = 0x4;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_FRAMECHANGED = 0x20;
        public const int SWP_NOACTIVATE = 0x10;
        public const int SWP_ASYNCWINDOWPOS = 0x4000;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOSIZE = 0x1;

        public const int GWL_STYLE = (-16);

        public const int MA_NOACTIVATE = 3;
        public const uint KEYEVENTF_EXTENDEDKEY = 0x1;
        public const uint KEYEVENTF_KEYUP = 0x2;
    }
}
