using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace POExileDirection
{
    public static class InteropCommon
    {
        #region ⨌⨌ DllImport for Invoke ⨌⨌
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out uint processId);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern uint GetWindowLong(IntPtr hWnd, int nExStyleNum);

        [DllImport("user32.dll")]
        public static extern uint SetWindowLong(IntPtr hWnd, int nExStyleNum, uint dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        static extern short GetKeyState(int ctrlKey = 0x11);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", EntryPoint = "GetParent", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        #endregion

        public static bool IsCtrlPressed()
        {
            var result = GetKeyState();

            bool bctrlKeyPressed = false;
            switch (result)
            {
                case 0:
                    bctrlKeyPressed = false;
                    break;

                case 1:
                    bctrlKeyPressed = false;
                    break;

                default:
                    bctrlKeyPressed = true;
                    break;
            }

            return bctrlKeyPressed;
        }

        public static string GetPathFromHandle(IntPtr hwnd)
        {
            uint pid = 0;
            int nRet = GetWindowThreadProcessId(hwnd, out pid);
            Process procInform = Process.GetProcessById((int)pid);
            return procInform.MainModule.FileName.ToString();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static string GetActiveWindowParentTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();
            IntPtr parentHandle = GetParent(handle);

            if (GetWindowText(parentHandle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
    }
}
