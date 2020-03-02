using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class RemainingForm : Form
    {
        private int m_nExStyleNum = -20;
        private const uint WS_EX_LAYERED = 0x00080000;
        private const uint WS_EX_TRANSPARENT = 0x00000020;
        private const int LWA_ALPHA = 0x2;
        private const int LWA_COLORKEY = 0x1; 

        [DllImport("user32.dll")]
        public static extern uint GetWindowLong(IntPtr hWnd, int nExStyleNum);

        [DllImport("user32.dll")]
        public static extern uint SetWindowLong(IntPtr hWnd, int nExStyleNum, uint dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        public RemainingForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            this.ShowInTaskbar = false;
        }

        private void RemainingForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            // Fix Size 82,70
            this.Width = 82;
            this.Height = 70;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

            uint exstyleGet = GetWindowLong(this.Handle, m_nExStyleNum);
            SetWindowLong(this.Handle, m_nExStyleNum, exstyleGet | WS_EX_LAYERED | WS_EX_TRANSPARENT);

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ControlForm.g_bIsRemainingOn = false;
            this.Close();
        }
    }
}
