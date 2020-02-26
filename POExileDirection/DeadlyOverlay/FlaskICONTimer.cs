using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace POExileDirection
{
    public partial class FlaskICONTimer : Form
    {
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

            if (LauncherForm.resolution_width < 1920 && LauncherForm.resolution_height < 1080)
            {
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                if (LauncherForm.resolution_width < 1600 && LauncherForm.resolution_height < 1024)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini");
                else if (LauncherForm.resolution_width < 1280)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_LOW.ini");
            }
            else if (LauncherForm.resolution_width > 1920)
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_HIGH.ini");

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
                                   + NinjaTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(0)]);
                }
                else if (nFlaskNumber == 2)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK2LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK2TOP");
                    sColor = parser.GetSetting("MISC", "FLASK2COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + NinjaTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(1)]);
                }
                else if (nFlaskNumber == 3)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK3LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK3TOP");
                    sColor = parser.GetSetting("MISC", "FLASK3COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + NinjaTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(2)]);
                }
                else if (nFlaskNumber == 4)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK4LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK4TOP");
                    sColor = parser.GetSetting("MISC", "FLASK4COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + NinjaTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(3)]);
                }
                else if (nFlaskNumber == 5)
                {
                    sLeft = parser.GetSetting("MISC", "FLASK5LEFT");
                    sTop = parser.GetSetting("MISC", "FLASK5TOP");
                    sColor = parser.GetSetting("MISC", "FLASK5COLOR");
                    pictureFlask.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + NinjaTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(4)]);
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
                    if (strUseAlertSound == "Y")
                        PlayMediaFile(Application.StartupPath + "\\flaskalert.wav");

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

        private MediaPlayer _mediaPlayer; // Added 1.3.9.9 Ver.

        private void PlayMediaFile(string filename)
        {
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Open(new Uri(filename));

            SetVolume(LauncherForm.g_FlaskTimerVolume);
            _mediaPlayer.Play();
            _mediaPlayer = null;
        }

        public void SetVolume(int volume)
        {
            _mediaPlayer.Volume = volume / 100.0f; // MediaPlayer volume is a float value between 0 and 1.
        }

        // Adjust an image's translucency.
        /*private Bitmap AdjustAlpha(Image image, float translucency)
        {
            // Make the ColorMatrix.
            float t = translucency;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, t, 0},
            new float[] {0, 0, 0, 0, 1},
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while
            // applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
        }*/

        private void FlaskICONTimer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(pictureFlask!=null) pictureFlask.Dispose();
            if(xuiFlatProgressBar1!=null) xuiFlatProgressBar1.Dispose();
            this.Dispose();
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

            if (LauncherForm.resolution_width < 1920 && LauncherForm.resolution_height < 1080)
            {
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                if (LauncherForm.resolution_width < 1600 && LauncherForm.resolution_height < 1024)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini");
                else if (LauncherForm.resolution_width < 1280)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_LOW.ini");
            }
            else if (LauncherForm.resolution_width > 1920)
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_HIGH.ini");

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
        }
    }
}
