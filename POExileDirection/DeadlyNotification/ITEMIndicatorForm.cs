using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using WindowsInput;
using WindowsInput.Native;

namespace POExileDirection
{
    public partial class ITEMIndicatorForm : Form
    {
        #region [[[[[ Global Variables ]]]]]
        public bool bIsQuad = false; 
        public int nStashX = 0;
        public int nStashY = 0;

        public string _strItemName = String.Empty;
        public string _strPrice = String.Empty;
        public string _strBmpPath = String.Empty;

        public string _strNickName = String.Empty;
        public string _strTradePurpose = String.Empty;
        #endregion

        public ITEMIndicatorForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        //private int nIndicatorLeft;
        //private int nIndicatorTop;

        //private double dWidth;
        //private double dHeight;
        //private int nCellWidth;
        //private int nCellHeight;
        //private int nCellWidth4x4;
        //private int nCellHeight4x4;

        private void ITEMIndicatorForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            //nIndicatorLeft = LauncherForm.g_nGridLeft;
            //nIndicatorTop = LauncherForm.g_nGridTop;

            //dWidth = LauncherForm.g_nGridWidth + 4.5;
            //dHeight = LauncherForm.g_nGridHeight + 4.5;
            //nCellWidth = Convert.ToInt32(Math.Truncate(dWidth / 12));
            //nCellHeight = Convert.ToInt32(Math.Truncate(dHeight / 12));
            //nCellWidth4x4 = Convert.ToInt32(Math.Truncate(dWidth / 24));
            //nCellHeight4x4 = Convert.ToInt32(Math.Truncate(dHeight / 24));

            Init_Controls();

            if (_strTradePurpose == "BUY")
                labelItemName.ForeColor = Color.FromArgb(0, 26, 204, 255);
            else
                labelItemName.ForeColor = Color.FromArgb(0, 255, 236, 26);

            SetIndicatorPictureBox();
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        private void Init_Controls()
        {
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnClose.TabStop = false;

            btnCurrency.FlatStyle = FlatStyle.Flat;
            btnCurrency.BackColor = System.Drawing.Color.Transparent;
            btnCurrency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnCurrency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnCurrency.TabStop = false;

            btnInvite.FlatStyle = FlatStyle.Flat;
            btnInvite.BackColor = System.Drawing.Color.Transparent;
            btnInvite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnInvite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnInvite.TabStop = false;

            btnTrade.FlatStyle = FlatStyle.Flat;
            btnTrade.BackColor = System.Drawing.Color.Transparent;
            btnTrade.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnTrade.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnTrade.TabStop = false;

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnClose.TabStop = false;

            btnThx.FlatStyle = FlatStyle.Flat;
            btnThx.BackColor = System.Drawing.Color.Transparent;
            btnThx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnThx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnThx.TabStop = false;
            if (!String.IsNullOrEmpty(LauncherForm.g_strnotiDONEbtnTITLE))
            {
                btnThx.Text = LauncherForm.g_strnotiDONEbtnTITLE;
                btnThx.Enabled = true;
                btnThx.Visible = true;
            }
            else
            {
                btnThx.Enabled = false;
                btnThx.Visible = false;
            }

            btnWait.FlatStyle = FlatStyle.Flat;
            btnWait.BackColor = System.Drawing.Color.Transparent;
            btnWait.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnWait.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnWait.TabStop = false;
            if (!String.IsNullOrEmpty(LauncherForm.g_strnotiWAITbtnTITLE))
            {
                btnWait.Text = LauncherForm.g_strnotiWAITbtnTITLE;
                btnWait.Enabled = true;
                btnWait.Visible = true;
            }
            else
            {
                btnWait.Enabled = false;
                btnWait.Visible = false;
            }

            btnSold.FlatStyle = FlatStyle.Flat;
            btnSold.BackColor = System.Drawing.Color.Transparent;
            btnSold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnSold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnSold.TabStop = false;
            if (!String.IsNullOrEmpty(LauncherForm.g_strnotiSOLDbtnTITLE))
            {
                btnSold.Text = LauncherForm.g_strnotiSOLDbtnTITLE;
                btnSold.Enabled = true;
                btnSold.Visible = true;
            }
            else
            {
                btnSold.Enabled = false;
                btnSold.Visible = false;
            }
        }
        #endregion

        private void SetIndicatorPictureBox()
        {
            try
            {
                if(bIsQuad)
                {
                    Rectangle rcIndcator = LauncherForm.g_arrayRect4x4[nStashX - 1, nStashX - 1];
                    Left = rcIndcator.X;
                    Top = rcIndcator.Y;
                    pictureBox1.Width = rcIndcator.Width;
                    pictureBox1.Height = rcIndcator.Height;

                    checkQuadTab.Checked = true;
                }
                else
                {
                    Rectangle rcIndcator = LauncherForm.g_arrayRect1x1[nStashX - 1, nStashX - 1];
                    Left = rcIndcator.X;
                    Top = rcIndcator.Y;
                    pictureBox1.Width = rcIndcator.Width;
                    pictureBox1.Height = rcIndcator.Height;

                    checkQuadTab.Checked = false;
                }

                #region [[[[[ Old Backup - Calc. Rect. ]]]]]
                //int nLeft = 0;
                //int nTop = 0;
                //Rectangle rcBox = new Rectangle(0, 0, nCellWidth, nCellHeight);

                ////Pen AquaPen = new Pen(Color.Aqua, 1);
                ////Pen DarkRed = new Pen(Color.DarkRed, 2);
                //// DarkRed.Alignment = PenAlignment.Center;

                //// Rectangle[,] g_arrayRect4x4 = new Rectangle[24, 24];
                //// Rectangle[,] g_arrayRect1x1 = new Rectangle[12, 12];

                //if (bIsQuad)
                //{
                //    // 4x4 Aqua
                //    for (int iRow = 0; iRow < 24; iRow++) // ROWS
                //    {
                //        nTop = iRow * (nCellWidth4x4);

                //        for (int jCell = 0; jCell < 24; jCell++) // COLLUMS
                //        {
                //            nLeft = jCell * (nCellHeight4x4);

                //            rcBox = new Rectangle(nLeft, nTop, nCellHeight4x4, nCellWidth4x4);

                //            if (jCell == nStashX - 1 && iRow == nStashY - 1)
                //            {
                //                Left = rcBox.X + nIndicatorLeft;
                //                Top = rcBox.Y + nIndicatorTop;
                //                pictureBox1.Width = rcBox.Width;
                //                pictureBox1.Height = rcBox.Height;

                //                break;
                //            }
                //            //g_arrayRect4x4[iRow, jCell] = rcBox;

                //            //e.Graphics.DrawRectangle(AquaPen, g_arrayRect4x4[iRow, jCell]);
                //        }
                //    }

                //    checkQuadTab.Checked = true;
                //}
                //else
                //{
                //    nLeft = 0;
                //    nTop = 0;
                //    // 1x1 Red
                //    //ControlForm.g_arrayRect1x1 = new Rectangle[12, 12];
                //    for (int i = 0; i < 12; i++) // ROWS
                //    {
                //        nTop = i * nCellHeight;

                //        for (int j = 0; j < 12; j++) // COLLUMS
                //        {
                //            nLeft = j * nCellWidth;

                //            rcBox = new Rectangle(nLeft, nTop, nCellWidth, nCellHeight);

                //            if (j == nStashX - 1 && i == nStashY - 1)
                //            {
                //                Left = rcBox.X + nIndicatorLeft;
                //                Top = rcBox.Y + nIndicatorTop;
                //                pictureBox1.Width = rcBox.Width;
                //                pictureBox1.Height = rcBox.Height;

                //                break;
                //            }

                //            //g_arrayRect1x1[i, j] = rcBox;

                //            //e.Graphics.DrawRectangle(DarkRed, g_arrayRect1x1[i, j]);
                //        }
                //    }

                //    checkQuadTab.Checked = false;
                //} 
                #endregion

                if (!String.IsNullOrEmpty(_strBmpPath))
                    btnCurrency.Text = "";

                labelItemName.Text = _strItemName;
                labelPriceAtTitle.Text = _strPrice;
                btnCurrency.BackgroundImage = Bitmap.FromFile(_strBmpPath);

                panelTop.Left = pictureBox1.Width + 1;
                panelFunctions.Left = panelTop.Right - 288;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void ITEMIndicatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Dispose();
        }

        private void labelItemName_Click(object sender, EventArgs e)
        {
            InputSimulator iSim = new InputSimulator();
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            iSim.Keyboard.TextEntry(_strItemName);
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void checkQuadTab_Click(object sender, EventArgs e)
        {
            if (!bIsQuad)
                bIsQuad = true;
            else
                bIsQuad = false;

            SetIndicatorPictureBox();
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send Invite
            string strSendString = String.Format("/invite {0}", _strNickName);
            iSim.Keyboard.TextEntry(strSendString);

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            string strSendString = String.Format("/tradewith {0}", _strNickName);
            iSim.Keyboard.TextEntry(strSendString);

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void btnKick_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            string strSendString = String.Format("/kick {0}", _strNickName);
            if (_strTradePurpose == "BUY")
                strSendString = String.Format("/kick {0}", LauncherForm.g_strMyNickName);
            iSim.Keyboard.TextEntry(strSendString);

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            BtnClose_Click();
        }

        private void btnThx_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            if (!String.IsNullOrEmpty(LauncherForm.g_strnotiDONE))
            {
                InputSimulator iSim = new InputSimulator();
                iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                string strSendString = String.Empty;
                try
                {
                    if (LauncherForm.g_strINVITECheckYNThx == "Y")
                        strSendString = String.Format("/invite {0}", _strNickName);
                    else if (LauncherForm.g_strTRADECheckYNThx == "Y")
                        strSendString = String.Format("/tradewith {0}", _strNickName);
                    else
                        strSendString = String.Format("@{0} {1}", _strNickName, LauncherForm.g_strnotiDONE);
                }
                catch
                {
                    strSendString = String.Format("@{0} thanks. gl hf~.", _strNickName);
                }
                iSim.Keyboard.TextEntry(strSendString);
                iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                if (LauncherForm.g_strTRAutoKick == "Y")
                    BtnKick_Click();
                if (LauncherForm.g_strTRAutoCloseThx == "Y")
                    BtnClose_Click();
            }
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            if (!String.IsNullOrEmpty(LauncherForm.g_strnotiWAIT))
            {
                InputSimulator iSim = new InputSimulator();
                iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                string strSendString = String.Empty;
                try
                {
                    if (LauncherForm.g_strINVITECheckYNWait == "Y")
                        strSendString = String.Format("/invite {0}", _strNickName);
                    else if (LauncherForm.g_strTRADECheckYNWait == "Y")
                        strSendString = String.Format("/tradewith {0}", _strNickName);
                    else
                        strSendString = String.Format("@{0} {1}", _strNickName, LauncherForm.g_strnotiWAIT);
                }
                catch
                {
                    strSendString = String.Format("@{0} wait a sec pls..", _strNickName);
                }
                iSim.Keyboard.TextEntry(strSendString);
                iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                if (LauncherForm.g_strTRAutoKickWait == "Y")
                    BtnKick_Click();
                if (LauncherForm.g_strTRAutoCloseWait == "Y")
                    BtnClose_Click();
            }
        }

        private void btnSold_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            if (!String.IsNullOrEmpty(LauncherForm.g_strnotiSOLD))
            {
                InputSimulator iSim = new InputSimulator();
                iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                string strSendString = String.Empty;
                try
                {
                    if (LauncherForm.g_strINVITECheckYNSold == "Y")
                        strSendString = String.Format("/invite {0}", _strNickName);
                    else if (LauncherForm.g_strTRADECheckYNSold == "Y")
                        strSendString = String.Format("/tradewith {0}", _strNickName);
                    else
                        strSendString = String.Format("@{0} {1}", _strNickName, LauncherForm.g_strnotiSOLD);
                }
                catch
                {
                    strSendString = String.Format("@{0} sold already. sry.", _strNickName);
                }
                iSim.Keyboard.TextEntry(strSendString);
                iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                if (LauncherForm.g_strTRAutoKickSold == "Y")
                    BtnKick_Click();
                if (LauncherForm.g_strTRAutoCloseSold == "Y")
                    BtnClose_Click();
            }
        }

        private void BtnKick_Click()
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            string strSendString = String.Format("/kick {0}", _strNickName);
            if (_strTradePurpose == "BUY")
                strSendString = String.Format("/kick {0}", LauncherForm.g_strMyNickName);
            iSim.Keyboard.TextEntry(strSendString);
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void BtnClose_Click()
        {
            pictureBox1.Dispose();
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            Close();
        }
    }
}
