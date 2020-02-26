using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace POExileDirection
{
    public class ClipboardHelper
    {
        #region Win32
        public const int WM_CLIPBOARDUPDATE = 0x031D;

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern IntPtr GetClipboardOwner();

        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out uint threadid);

        // ref: https://stackoverflow.com/questions/33003958/getting-byte-from-getclipboarddata-native-method

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsClipboardFormatAvailable(uint format);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseClipboard();

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("Kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern int GlobalSize(IntPtr hMem);

        private const uint CF_UNICODETEXT = 13U;

        private const uint CF_TEXT = 1U;

        #endregion

        private static string OldData
        {
            get; set;
        }

        public static string GetUnicodeText()
        {
            if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
                return null;

            try
            {
                if (!OpenClipboard(IntPtr.Zero))
                    return null;

                IntPtr handle = GetClipboardData(CF_UNICODETEXT);
                if (handle == IntPtr.Zero)
                    return null;

                IntPtr pointer = IntPtr.Zero;

                try
                {
                    pointer = GlobalLock(handle);
                    if (pointer == IntPtr.Zero)
                        return null;

                    int size = GlobalSize(handle);
                    byte[] buff = new byte[size];

                    Marshal.Copy(pointer, buff, 0, size);

                    var text = Encoding.Unicode.GetString(buff).TrimEnd('\0');

                    if (text == OldData)
                        return text; // EOCS_MODIFIED //return null;

                    OldData = text;
                    return text;
                }
                finally
                {
                    if (pointer != IntPtr.Zero)
                        GlobalUnlock(handle);
                }
            }
            finally
            {
                CloseClipboard();
            }
        }

        public static string GetASCIIText()
        {
            if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
                return null;

            try
            {
                if (!OpenClipboard(IntPtr.Zero))
                    return null;

                IntPtr handle = GetClipboardData(CF_TEXT);
                if (handle == IntPtr.Zero)
                    return null;

                IntPtr pointer = IntPtr.Zero;

                try
                {
                    pointer = GlobalLock(handle);
                    if (pointer == IntPtr.Zero)
                        return null;

                    int size = GlobalSize(handle);
                    byte[] buff = new byte[size];

                    Marshal.Copy(pointer, buff, 0, size);

                    var text = Encoding.ASCII.GetString(buff).TrimEnd('\0');

                    if (text == OldData)
                        return text; // EOCS_MODIFIED //return null;

                    OldData = text;
                    return text;
                }
                finally
                {
                    if (pointer != IntPtr.Zero)
                        GlobalUnlock(handle);
                }
            }
            finally
            {
                CloseClipboard();
            }
        }
    }
}
