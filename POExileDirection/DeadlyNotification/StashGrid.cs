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
            Init_Controls();
            Visible = true;
        }

        private void StashGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            ControlForm.bfrmStashGridShow = false;
        }

        private void SetFormStyle()
        {
            this.ControlBox = false;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);            

            this.Left = 19;
            this.Top = 166;
            this.Width = 55;
            this.Height = 55;
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
            // Draw Grip
            Rectangle rc = new Rectangle(Width - g_nGrip, Height - g_nGrip, g_nGrip, g_nGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Red, rc);

            // Draw Rectangle
            // BBBBBB Pen AquaPen = new Pen(Color.Aqua, 2);
            // BBBBBB Rectangle rcBox = new Rectangle(2, 2, LauncherForm.g_nGridWidth - 3, LauncherForm.g_nGridHeight - 3);

            /*
            // Draw Grip
            Rectangle rc = new Rectangle(this.Width - g_nGrip, this.Height - g_nGrip, g_nGrip, g_nGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Red, rc);

            // Draw Rectangle
            Pen AquaPen = new Pen(Color.Aqua, 2);
            Rectangle rcBox = new Rectangle(2, 2, this.Width-3, this.Height-3);
            */

            // BBBBBB  e.Graphics.DrawRectangle(AquaPen, rcBox);

            #region ⨌⨌ Back up. Draw Calculated Grid ⨌⨌
            // Draw Stash Box Guide Grid
            //double dWidth = this.Width;
            //double dHeight = this.Height;
            //int nCellWidth = Convert.ToInt32(Math.Truncate(dWidth / 12));
            //int nCellHeight = Convert.ToInt32(Math.Truncate(dHeight / 12));

            double dWidth = this.Width + 4.5;
            double dHeight = this.Height + 4.5;
            int nCellWidth = Convert.ToInt32(Math.Truncate(dWidth / 12));
            int nCellHeight = Convert.ToInt32(Math.Truncate(dHeight / 12));
            int nCellWidth4x4 = Convert.ToInt32(Math.Truncate(dWidth / 24));
            int nCellHeight4x4 = Convert.ToInt32(Math.Truncate(dHeight / 24));

            int nLeft = 0;
            int nTop = 0;
            Rectangle rcBox = new Rectangle(0,0, nCellWidth, nCellHeight);

            Pen AquaPen = new Pen(Color.Aqua, 1);
            Pen DarkRed = new Pen(Color.DarkRed, 2);
            // DarkRed.Alignment = PenAlignment.Center;

            Rectangle[,] g_arrayRect4x4 = new Rectangle[24, 24];
            Rectangle[,] g_arrayRect1x1 = new Rectangle[12, 12];

            // 4x4 Aqua
            for (int iRow = 0; iRow < 24; iRow++) // ROWS
            {
                nTop = iRow * (nCellWidth4x4);

                for (int jCell = 0; jCell < 24; jCell++) // COLLUMS
                {
                    nLeft = jCell * (nCellHeight4x4);

                    rcBox = new Rectangle(nLeft, nTop, nCellHeight4x4, nCellWidth4x4);
                    g_arrayRect4x4[iRow, jCell] = rcBox;

                    e.Graphics.DrawRectangle(AquaPen, g_arrayRect4x4[iRow, jCell]);
                }
            }

            nLeft = 0;
            nTop = 0;
            // 1x1 Red
            //ControlForm.g_arrayRect1x1 = new Rectangle[12, 12];
            for (int i=0; i<12; i++) // ROWS
            {
                nTop = i * nCellHeight;

                for (int j=0; j<12; j++) // COLLUMS
                {
                    nLeft = j * nCellWidth;

                    rcBox = new Rectangle(nLeft, nTop, nCellWidth, nCellHeight);
                    g_arrayRect1x1[i, j] = rcBox;

                    e.Graphics.DrawRectangle(DarkRed, g_arrayRect1x1[i, j]);
                }                
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
            #endregion
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
