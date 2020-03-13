﻿using System;
using System.Reflection;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class SomeOneEnteredForm : Form
    {
        private int m_nExStyleNum = -20;
        private const uint WS_EX_LAYERED = 0x00080000;
        private const uint WS_EX_TRANSPARENT = 0x00000020;
        private const int LWA_ALPHA = 0x2;
        private const int LWA_COLORKEY = 0x1;

        public string strNickName = String.Empty;
        public string strLableText = String.Empty;
        private int nSec = 0;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public SomeOneEnteredForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            Width = 128;
            Height = 43;
        }

        private void SomeOneEnteredForm_Load(object sender, EventArgs e)
        {
            Visible = false;

            try
            {
                uint exstyleGet = InteropCommon.GetWindowLong(this.Handle, m_nExStyleNum);
                InteropCommon.SetWindowLong(this.Handle, m_nExStyleNum, exstyleGet | WS_EX_LAYERED | WS_EX_TRANSPARENT);

                Width = 105;
                labelNickName.Text = strNickName;
                if (!String.IsNullOrEmpty(strLableText))
                    labelNickName.Text = strLableText;
                StartPosition = FormStartPosition.CenterScreen;
                TopMost = true;
                Top = Top - 100;
                if (strLableText == "Copied.")
                {
                    labelNOTICE.Text = strNickName;
                    labelNOTICE.Visible = true;
                }
                Visible = true;

                timer1.Start();
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(nSec>=3)
            {
                timer1.Stop();
                Close();
            }
            else
                nSec = nSec + 1;
        }
    }
}
