﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using POExileDirection.DeadlyCommon;
using System.Threading.Tasks;

namespace POExileDirection
{
    public partial class FlaskICONTimer : Form
    {
        #region [[[[[ Global Variables ]]]]]
        private int m_nExStyleNum = -20;
        private const uint WS_EX_LAYERED = 0x00080000;
        private const uint WS_EX_TRANSPARENT = 0x00000020;
        private const int LWA_ALPHA = 0x2;
        private const int LWA_COLORKEY = 0x1;

        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        public int nFlaskNumber = 0;
        public double lnFlaskTimer = 0.0;
        private double lnMaxValue = 0.0;

        public int nFlaskICONEnum = 0;
        public string strUseAlertSound = "N";

        SharpDXDeadlyWrapper dxWrapper = new SharpDXDeadlyWrapper(); 
        #endregion

        public FlaskICONTimer()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

        private void FlaskICONTimer_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

            uint exstyleGet = InteropCommon.GetWindowLong(this.Handle, m_nExStyleNum);
            InteropCommon.SetWindowLong(this.Handle, m_nExStyleNum, exstyleGet | WS_EX_LAYERED | WS_EX_TRANSPARENT);

            #region ⨌⨌ Get Information from ConfigPath.ini ⨌⨌
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string sColor = string.Empty;
            try
            {
                string sLeft = string.Empty;
                string sTop = string.Empty;
                if (nFlaskNumber == 1)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK1LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK1TOP");
                    sColor = parser.GetSetting("MISC", "FLASK1COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(0)]);
                }
                else if (nFlaskNumber == 2)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK2LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK2TOP");
                    sColor = parser.GetSetting("MISC", "FLASK2COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(1)]);
                }
                else if (nFlaskNumber == 3)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK3LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK3TOP");
                    sColor = parser.GetSetting("MISC", "FLASK3COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(2)]);
                }
                else if (nFlaskNumber == 4)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK4LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK4TOP");
                    sColor = parser.GetSetting("MISC", "FLASK4COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(3)]);
                }
                else if (nFlaskNumber == 5)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK5LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK5TOP");
                    sColor = parser.GetSetting("MISC", "FLASK5COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(4)]);
                }

                Left = Convert.ToInt32(sLeft);
                Top = Convert.ToInt32(sTop);
            }
            catch
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "FLASK 환경 파일을 읽을 수 없습니다.\r\n\r\nini 파일이 손상되었거나 삭제되었습니다.";
                frmMSG.ShowDialog();
            }
            #endregion

            xuiFlatProgressBar1.MaxValue = 100; // Convert.ToInt32(lnFlaskTimer);
            xuiFlatProgressBar1.Value = 100;
            xuiFlatProgressBar1.CompleteColor = StringRGBToColor(sColor);
            lnMaxValue = lnFlaskTimer;

            BringToFront();

            timer1.Start();
            Visible = true;
        }

        private Color StringRGBToColor(string color)
        {
            var arrColorFragments = color?.Split(',').Select(sFragment => { int.TryParse(sFragment, out int fragment); return fragment; }).ToArray();

            switch (arrColorFragments?.Length)
            {
                case 3:
                    return Color.FromArgb(255, arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]);
                case 4:
                    return Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]);
                default:
                    return Color.Transparent;
            }
        }

        #region [[[[[ Timer ]]]]]
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!LauncherForm.g_pinLOCK)
                {
                    // Reverse Style
                    uint exstyleGet = InteropCommon.GetWindowLong(this.Handle, m_nExStyleNum);
                    InteropCommon.SetWindowLong(this.Handle, m_nExStyleNum, exstyleGet & ~(WS_EX_LAYERED | WS_EX_TRANSPARENT));
                    Width = 30;
                    Height = 70;
                }
                else
                {
                    // Set Style : Can't Click (Layered Transparent)
                    uint exstyleGet = InteropCommon.GetWindowLong(this.Handle, m_nExStyleNum);
                    InteropCommon.SetWindowLong(this.Handle, m_nExStyleNum, exstyleGet | WS_EX_LAYERED | WS_EX_TRANSPARENT);
                    Width = 30;
                    Height = 70;
                }

                int nPercent = Convert.ToInt32(lnFlaskTimer / lnMaxValue * 100);
                xuiFlatProgressBar1.Text = lnFlaskTimer.ToString("N1");
                xuiFlatProgressBar1.Value = nPercent; // Convert.ToInt32(lnFlaskTimer);
                xuiFlatProgressBar1.Invalidate();

                // Change opacity
                //pictureFlask.BackColor = Color.Transparent;
                //pictureFlask.Image = AdjustAlpha((Bitmap)Properties.Resources._60px_Atziri_s_Promise_inventory_icon, nPercent);

                panelAlpha.Height = 60 - nPercent;

                //DeadlyLog4Net._log.Info(nPercent.ToString());
                lnFlaskTimer = lnFlaskTimer - 0.1; // 100ms
                if (lnFlaskTimer <= 0.0)
                {
                    #region [[[[[ Remove temporary - Assertion ]]]]]
                    //if (strUseAlertSound == "Y")
                    //    PlayMediaFile(Application.StartupPath + "\\flaskalert.wav"); 
                    #endregion

                    timer1.Stop();
                    xuiFlatProgressBar1.Dispose();
                    this.BeginInvoke(new MethodInvoker(Close));// Close();
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex); ;
            }
        }
        #endregion

        //private async Task playTask()
        //{
        //    bool bRet = await Task.Run(() => PlayAlertSound());
        //}

        //private bool PlayAlertSound()
        //{
        //    dxWrapper.SetAudioHandler(Application.StartupPath + "\\flaskalert.wav", LauncherForm.g_FlaskTimerVolume / 2);
        //    dxWrapper.Play();

        //    return true;
        //}

        //private Task playTask;
        private void PlayMediaFile(string filename)
        {
            //Task playTask = new Task(delegate
            //{
            //    dxWrapper.SetAudioHandler(filename, LauncherForm.g_FlaskTimerVolume / 2);
            //    dxWrapper.Play();
            //});
            //playTask.Start();
            //await playTask.ConfigureAwait(false);
            //playTask =
            Task.Run(() =>
            {
                dxWrapper.SetAudioHandler(filename, LauncherForm.g_FlaskTimerVolume / 2);
                dxWrapper.Play();
            });
        }

        private void pictureFlask_MouseDown(object sender, MouseEventArgs e)
        {
            if (!LauncherForm.g_pinLOCK)
            {
                nMoving = 1;
                nMovePosX = e.X;
                nMovePosY = e.Y;
            }
        }

        private void pictureFlask_MouseMove(object sender, MouseEventArgs e)
        {
            if (LauncherForm.g_pinLOCK)
                return;

            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void pictureFlask_MouseUp(object sender, MouseEventArgs e)
        {
            if (LauncherForm.g_pinLOCK)
                return;

            nMoving = 0;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            switch (nFlaskNumber)
            {
                case 1:
                    parser.AddSetting("MISC", "FLASK1LEFT", Left.ToString());
                    parser.AddSetting("MISC", "FLASK1TOP", Top.ToString());
                    break;
                case 2:
                    parser.AddSetting("MISC", "FLASK2LEFT", Left.ToString());
                    parser.AddSetting("MISC", "FLASK2TOP", Top.ToString());
                    break;
                case 3:
                    parser.AddSetting("MISC", "FLASK3LEFT", Left.ToString());
                    parser.AddSetting("MISC", "FLASK3TOP", Top.ToString());
                    break;
                case 4:
                    parser.AddSetting("MISC", "FLASK4LEFT", Left.ToString());
                    parser.AddSetting("MISC", "FLASK4TOP", Top.ToString());
                    break;
                case 5:
                    parser.AddSetting("MISC", "FLASK5LEFT", Left.ToString());
                    parser.AddSetting("MISC", "FLASK5TOP", Top.ToString());
                    break;
                default:
                    break;
            }

            parser.SaveSettings();
        }

        #region [[[[[ Dispose & Close ]]]]]
        private void FlaskICONTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (nFlaskNumber)
            {
                case 1:
                    ControlForm.bShowingfrmICONF1 = false;
                    break;
                case 2:
                    ControlForm.bShowingfrmICONF2 = false;
                    break;
                case 3:
                    ControlForm.bShowingfrmICONF3 = false;
                    break;
                case 4:
                    ControlForm.bShowingfrmICONF4 = false;
                    break;
                case 5:
                    ControlForm.bShowingfrmICONF5 = false;
                    break;
                default:
                    break;
            }
            if (timer1 != null) timer1.Dispose();
            if (pictureFlask != null) pictureFlask.Dispose();
            if (xuiFlatProgressBar1 != null) xuiFlatProgressBar1.Dispose();
            if (dxWrapper != null) dxWrapper.Dispose();
        }

        private void FlaskICONTimer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureFlask != null) pictureFlask.Dispose();
            if (xuiFlatProgressBar1 != null) xuiFlatProgressBar1.Dispose();
            this.Dispose();
        }
        #endregion
    }
}
