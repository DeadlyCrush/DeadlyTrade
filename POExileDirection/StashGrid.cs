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

namespace POExileDirection
{
    public partial class StashGrid : Form
    {
        int nMoving = 0;
        int nMovePosX = 0;
        int nMovePosY = 0;

        private const int g_nGrip = 24;

        public StashGrid()
        {
            InitializeComponent();
        }

        private void StashGrid_Load(object sender, EventArgs e)
        {
            SetFormStyle();
            Init_Controls();
        }

        private void StashGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
            parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
            parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
            parser.SaveSettings();
            this.Close();*/
        }

        private void SetFormStyle()
        {
            this.ControlBox = false;
            this.Text = String.Empty;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.Left = 19;
            this.Top = 166;
            this.Width = 628;
            this.Height = 628;
        }

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
            btnClose2nd.FlatStyle = FlatStyle.Flat;
            btnClose2nd.BackColor = Color.Transparent;
            btnClose2nd.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose2nd.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose2nd.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnClose2nd.FlatAppearance.BorderSize = 0;
            btnClose2nd.TabStop = false;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
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
                this.Width = 628;
                this.Height = 628;
                parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
                parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
                parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
                parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
                parser.SaveSettings();
            }
        }

        private void StashGrid_Paint(object sender, PaintEventArgs e)
        {
            // Draw Grip
            Rectangle rc = new Rectangle(this.Width - g_nGrip, this.Height - g_nGrip, g_nGrip, g_nGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Red, rc);

            // Drad Stash Box Guide Grid
            //double dWidth = this.Width;
            //double dHeight = this.Height;
            //int nCellWidth = Convert.ToInt32(Math.Truncate(dWidth / 12));
            //int nCellHeight = Convert.ToInt32(Math.Truncate(dHeight / 12));

            double dWidth = this.Width + 4.5;
            double dHeight = this.Height + 4.5;
            int nCellWidth = Convert.ToInt32(Math.Truncate(dWidth / 12));
            int nCellHeight = Convert.ToInt32(Math.Truncate(dHeight / 12));

            int nLeft = 0;
            int nTop = 0;
            Rectangle rcBox = new Rectangle(0,0, nCellWidth, nCellHeight);

            Pen AquaPen = new Pen(Color.Aqua, 1);
            // Pen DarkRed = new Pen(Color.DarkRed, 2);
            // DarkRed.Alignment = PenAlignment.Center;

            // 4x4 Aqua
            Rectangle[,] g_arrayRect4x4 = new Rectangle[24, 24];
            for (int iRow = 0; iRow < 24; iRow++) // ROWS
            {
                nTop = iRow * (nCellHeight / 2);

                for (int jCell = 0; jCell < 24; jCell++) // COLLUMS
                {
                    nLeft = jCell * (nCellWidth / 2);

                    rcBox = new Rectangle(nLeft, nTop, nCellWidth / 2, nCellHeight / 2);
                    g_arrayRect4x4[iRow, jCell] = rcBox;

                    e.Graphics.DrawRectangle(AquaPen, g_arrayRect4x4[iRow, jCell]);
                }
            }

            // 1x1 Red
            Rectangle[,] g_arrayRect1x1 = new Rectangle[12, 12];
            for (int i=0; i<12; i++) // ROWS
            {
                nTop = i * nCellHeight;

                for (int j=0; j<12; j++) // COLLUMS
                {
                    nLeft = j * nCellWidth;

                    rcBox = new Rectangle(nLeft, nTop, nCellWidth, nCellHeight);
                    g_arrayRect1x1[i, j] = rcBox;

                    // e.Graphics.DrawRectangle(DarkRed, g_arrayRect1x1[i, j]);
                }                
            }
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
            /*string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
            parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
            parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
            parser.SaveSettings();*/
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
            parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
            parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
            parser.SaveSettings();
            this.Close();
        }

        private void BtnClose2nd_Click(object sender, EventArgs e)
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATIONGRID", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONGRID", "TOP", this.Top.ToString());
            parser.AddSetting("LOCATIONGRID", "RIGHT", this.Width.ToString());
            parser.AddSetting("LOCATIONGRID", "BOTTOM", this.Height.ToString());
            parser.SaveSettings();
            this.Close();
        }
    }
}
