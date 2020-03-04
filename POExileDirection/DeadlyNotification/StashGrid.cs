using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace POExileDirection
{
    public partial class StashGrid : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        private const int g_nGrip = 17;

        public StashGrid()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void StashGrid_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

            SetFormStyle();
            //? Temporary Init_Controls();
            Visible = true;
        }

        private void StashGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            ControlForm.bfrmStashGridShow = false;
        }

        const int DWMA_EXTENDED_FRAME_BOUNDS = 9;
        RECT rcAttrBound;
        private RECT rcPOE;
        int nTitleHeight;
        Point ptLeftTop;
        Point ptRightBottom;
        RECT rcClient;
        RECT rcTitleBound;
        private void SetFormStyle()
        {
            this.ControlBox = false;
            DoubleBuffered = true;
            //////SetStyle(ControlStyles.ResizeRedraw, true);            
            InteropCommon.GetWindowRect(LauncherForm.g_handlePathOfExile, out rcPOE);
            Left = rcPOE.left;
            Top = rcPOE.top;
            InteropCommon.DwmGetWindowAttribute(LauncherForm.g_handlePathOfExile, DWMA_EXTENDED_FRAME_BOUNDS, out rcAttrBound, Marshal.SizeOf(typeof(RECT)));
            rcTitleBound.left = rcAttrBound.left - rcPOE.left;
            rcTitleBound.top = rcAttrBound.top - rcPOE.top;
            rcTitleBound.right = rcAttrBound.right - rcPOE.right;
            rcTitleBound.bottom = rcAttrBound.bottom - rcPOE.bottom;

            if (!LauncherForm.g_isWindowdedFullScreen)
            {
                InteropCommon.GetClientRect(LauncherForm.g_handlePathOfExile, out rcClient);
                ptLeftTop = new Point(rcPOE.left, rcPOE.top );
                InteropCommon.ClientToScreen(LauncherForm.g_handlePathOfExile, ref ptLeftTop);
                ptRightBottom = new Point(rcPOE.right, rcPOE.bottom);
                InteropCommon.ClientToScreen(LauncherForm.g_handlePathOfExile, ref ptRightBottom); 

                nTitleHeight = ptLeftTop.Y - rcPOE.top;

                Width = rcPOE.right / 2;
                Height = rcPOE.bottom;
            }
            else
            {
                Width = LauncherForm.resolution_width / 2;
                Height = LauncherForm.resolution_height;
            }
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        private void Init_Controls()
        {
            // btnClose
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.TabStop = false;

            // btnClose2nd
            //btnClose2nd.FlatStyle = FlatStyle.Flat;
            //btnClose2nd.BackColor = Color.Transparent;
            //btnClose2nd.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //btnClose2nd.FlatAppearance.MouseOverBackColor = Color.Transparent;
            //btnClose2nd.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            //btnClose2nd.FlatAppearance.BorderSize = 0;
            //btnClose2nd.TabStop = false;

            btnLeftTop.FlatStyle = FlatStyle.Flat;
            btnLeftTop.BackColor = Color.Transparent;
            btnLeftTop.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLeftTop.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLeftTop.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnLeftTop.FlatAppearance.BorderSize = 0;
            btnLeftTop.TabStop = false;

            // button1
            btnLeftTop.FlatStyle = FlatStyle.Flat;
            btnLeftTop.BackColor = Color.Transparent;
            btnLeftTop.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLeftTop.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLeftTop.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnLeftTop.FlatAppearance.BorderSize = 0;
            btnLeftTop.TabStop = false;

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

            string strLeft = "";
            string strTop = "";
            string strRight = "";
            string strBottom = "";
            try
            {
                strLeft = parser.GetSetting("LOCATIONGRID", "LEFT");
                strTop = parser.GetSetting("LOCATIONGRID", "TOP");
                strRight = parser.GetSetting("LOCATIONGRID", "RIGHT");
                strBottom = parser.GetSetting("LOCATIONGRID", "BOTTOM");

                this.Left = Convert.ToInt32(strLeft);
                this.Top = Convert.ToInt32(strTop);
                this.Width = Convert.ToInt32(strRight);
                this.Height = Convert.ToInt32(strBottom);

                LauncherForm.g_nGridWidth = Convert.ToInt32(strRight);
                LauncherForm.g_nGridHeight = Convert.ToInt32(strBottom);
            }
            catch
            {
                /*
                // 4x4로 맞춰본 결과. 특별히 손안대도 맞는 1920*1080 해상도의 기본 위치
	            [LOCATIONGRID]
	            LEFT=19
                TOP=166
                BOTTOM=628
                RIGHT=628
                */
                this.Left = 19;
                this.Top = 166;
                this.Width = 55;
                this.Height = 55;
                parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
                parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
                parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
                parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
                parser.SaveSettings();
            }
        }
        #endregion

        private void StashGrid_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                double dLeft;
                double dTop;
                double dRight;
                double dBottom;
                double dGridNormal;
                if (!LauncherForm.g_isWindowdedFullScreen)
                {
                    dLeft = Math.Round((rcClient.bottom + rcTitleBound.top) * 0.0125f);
                    dTop = Math.Round((rcClient.bottom + rcTitleBound.top) * 0.146625f);
                    dRight = Math.Round((rcClient.bottom + rcTitleBound.top) * 0.603875f);
                    dBottom = Math.Round((rcClient.bottom + rcTitleBound.top) * 0.738f);
                    dGridNormal = Math.Round(((rcClient.bottom + rcTitleBound.top) * 0.591375 - 4) / 12);
                }
                else
                {
                    dLeft = Math.Round(LauncherForm.resolution_height * 0.0125f);
                    dTop = Math.Round(LauncherForm.resolution_height * 0.146625f);
                    dRight = Math.Round(LauncherForm.resolution_height * 0.603875f);
                    dBottom = Math.Round(LauncherForm.resolution_height * 0.738f);
                    dGridNormal = Math.Round((LauncherForm.resolution_height * 0.591375 - 4) / 12);
                }
                
                double dWidth = dRight - dLeft;
                double dHeight = dBottom - dTop;

                int nGridQuad = Convert.ToInt32(dGridNormal/2);

                //TODO : Top Margin.
                Rectangle rcBoxStashBorder = new Rectangle(Convert.ToInt32(dLeft), Convert.ToInt32(dTop), Convert.ToInt32(dWidth), Convert.ToInt32(dHeight));
                Pen DarkRed = new Pen(Color.DarkRed, 2);
                e.Graphics.DrawRectangle(DarkRed, rcBoxStashBorder);

                Rectangle rcCell;
                Pen NormalPen = new Pen(Color.Aqua, 1);
                int nLeft = Convert.ToInt32(dLeft);
                int nTop = Convert.ToInt32(dTop);

                if (!LauncherForm.g_isWindowdedFullScreen)
                {
                    nTop = nTop + rcTitleBound.top;// nTitleHeight;
                }

                Rectangle[,] g_arrayRect1x1 = new Rectangle[12, 12];
                // 1x1 Normal
                for (int i = 0; i < 12; i++) // ROWS
                {
                    for (int j = 0; j < 12; j++) // COLLUMS
                    {
                        rcCell = new Rectangle(nLeft, nTop, Convert.ToInt32(dGridNormal), Convert.ToInt32(dGridNormal));
                        e.Graphics.DrawRectangle(NormalPen, rcCell);

                        g_arrayRect1x1[i, j] = rcCell;
                        nLeft = nLeft + Convert.ToInt32(dGridNormal); // Next Col.
                    }
                    nLeft = Convert.ToInt32(dLeft); // Back to First COL.
                    nTop = nTop + Convert.ToInt32(dGridNormal); // Next Row.
                }

                Pen QuadPen = new Pen(Color.Plum, 1);
                Rectangle rcQuad = new Rectangle();
                // 4x4 Quad
                //TODO : if show quad grid checked in settings
                for (int i = 0; i < 12; i++) // ROWS
                {
                    for (int j = 0; j < 12; j++) // COLLUMS
                    {
                        rcCell = g_arrayRect1x1[i, j];

                        /*
                        +------------+
                        +     +      +
                        +-----+------+
                        +     +      +
                        +------------+
                        */
                        for (int iQuad = 0; iQuad < 2; iQuad++)
                        {
                            for (int jQuad = 0; jQuad < 2; jQuad++) // Quad Cell in Each normal Cell.
                            {
                                rcQuad.X = rcCell.Left + jQuad * nGridQuad;
                                rcQuad.Y = rcCell.Top + jQuad * nGridQuad;
                                rcQuad.Width = nGridQuad;
                                rcQuad.Height = nGridQuad;
                                e.Graphics.DrawRectangle(QuadPen, rcQuad);
                            }
                            rcQuad.Y = rcCell.Top + iQuad * nGridQuad; // Next Row in Each normal Cell.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }

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

            parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
            parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
            parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
            parser.SaveSettings();

            LauncherForm.g_nGridLeft = Left;
            LauncherForm.g_nGridTop = Top;
            LauncherForm.g_nGridWidth = Width;
            LauncherForm.g_nGridHeight = Height;
            //#endregion
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point posNew = new Point(m.LParam.ToInt32());
                posNew = this.PointToScreen(posNew);

                if (posNew.X >= this.Width - g_nGrip && posNew.Y >= this.Height - g_nGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void BtnLeftTop_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void BtnLeftTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void BtnLeftTop_MouseUp(object sender, MouseEventArgs e)
        {
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

            parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
            parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
            parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
            parser.SaveSettings();

            LauncherForm.g_nGridWidth = Width;
            LauncherForm.g_nGridHeight = Height;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
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

            parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
            parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
            parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
            parser.SaveSettings();

            LauncherForm.g_nGridWidth = Width;
            LauncherForm.g_nGridHeight = Height;

            ControlForm.bfrmStashGridShow = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            this.Close();
        }

        private void StashGrid_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
