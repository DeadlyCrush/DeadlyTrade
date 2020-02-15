using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace POExileDirection
{
    public partial class ITEMIndicatorForm : Form
    {
        // BBBBBB private int nDefaultOffsetX = 3;
        // BBBBBB private int nDefaultOffsetY = 4;

        public bool bIsQuad = false;
        public int nStashX = 0;
        public int nStashY = 0;

        public ITEMIndicatorForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void ITEMIndicatorForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

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

            int nIndicatorLeft = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "LEFT"));
            int nIndicatorTop = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "TOP"));

            double dWidth = LauncherForm.g_nGridWidth + 4.5;
            double dHeight = LauncherForm.g_nGridHeight + 4.5;
            int nCellWidth = Convert.ToInt32(Math.Truncate(dWidth / 12));
            int nCellHeight = Convert.ToInt32(Math.Truncate(dHeight / 12));
            int nCellWidth4x4 = Convert.ToInt32(Math.Truncate(dWidth / 24));
            int nCellHeight4x4 = Convert.ToInt32(Math.Truncate(dHeight / 24));

            int nLeft = 0;
            int nTop = 0;
            Rectangle rcBox = new Rectangle(0, 0, nCellWidth, nCellHeight);

            //Pen AquaPen = new Pen(Color.Aqua, 1);
            //Pen DarkRed = new Pen(Color.DarkRed, 2);
            // DarkRed.Alignment = PenAlignment.Center;

            // Rectangle[,] g_arrayRect4x4 = new Rectangle[24, 24];
            // Rectangle[,] g_arrayRect1x1 = new Rectangle[12, 12];

            if (bIsQuad)
            {
                // 4x4 Aqua
                for (int iRow = 0; iRow < 24; iRow++) // ROWS
                {
                    nTop = iRow * (nCellWidth4x4);

                    for (int jCell = 0; jCell < 24; jCell++) // COLLUMS
                    {
                        nLeft = jCell * (nCellHeight4x4);

                        rcBox = new Rectangle(nLeft, nTop, nCellHeight4x4, nCellWidth4x4);

                        if (jCell == nStashX-1 && iRow == nStashY-1)
                        {
                            Left = rcBox.X;
                            Top = rcBox.Y;
                            Width = rcBox.Width;
                            Height = rcBox.Height;

                            break;
                        }
                        //g_arrayRect4x4[iRow, jCell] = rcBox;

                        //e.Graphics.DrawRectangle(AquaPen, g_arrayRect4x4[iRow, jCell]);
                    }
                }
            }
            else
            {
                nLeft = 0;
                nTop = 0;
                // 1x1 Red
                //ControlForm.g_arrayRect1x1 = new Rectangle[12, 12];
                for (int i = 0; i < 12; i++) // ROWS
                {
                    nTop = i * nCellHeight;

                    for (int j = 0; j < 12; j++) // COLLUMS
                    {
                        nLeft = j * nCellWidth;

                        rcBox = new Rectangle(nLeft, nTop, nCellWidth, nCellHeight);

                        if (j == nStashX-1 && i == nStashY-1)
                        {
                            Left = rcBox.X;
                            Top = rcBox.Y;
                            Width = rcBox.Width;
                            Height = rcBox.Height;

                            break;
                        }

                        //g_arrayRect1x1[i, j] = rcBox;

                        //e.Graphics.DrawRectangle(DarkRed, g_arrayRect1x1[i, j]);
                    }
                }
            }

            Left = Left + nIndicatorLeft;
            Top = Top + nIndicatorTop;







            /*BBBBBBB this.ControlBox = false;
            this.Text = String.Empty;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

            if (LauncherForm.resolution_width < 1920  && LauncherForm.resolution_height < 1080)
            {
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                if (LauncherForm.resolution_width < 1600 && LauncherForm.resolution_height < 1024)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini"); 
            }
            IniParser parser = new IniParser(strINIPath);

            int nLeft = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "LEFT"));
            int nTop = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "TOP"));
            LauncherForm.g_nGridWidth = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "RIGHT"));
            LauncherForm.g_nGridHeight = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "BOTTOM"));

            this.Left = nLeft;
            this.Top = nTop;

            int nOffsetX = 0;
            int nOffsetY = 0;

            if (bIsQuad) // 24 x 24
            {
                this.Width = LauncherForm.g_nGridWidth / 2 + 1;
                this.Height = LauncherForm.g_nGridHeight / 2 + 1;

                this.Left = this.Left + ((LauncherForm.g_nGridWidth / 2) * (nStashX - 1));
                this.Top = this.Top + ((LauncherForm.g_nGridHeight / 2) * (nStashY - 1));

                nOffsetX = (nStashX * 10) / 24;
                nOffsetY = (nStashY * 10) / 24;

                nOffsetX = nOffsetX + ((nStashX % 3) * nDefaultOffsetX); // 3칸 단위로 점점 늘어진다.
                nOffsetY = nOffsetY + ((nStashY % 3) * nDefaultOffsetY); // 3칸 단위로 점점 늘어진다.

                this.Left = this.Left - nOffsetX;
                this.Top = this.Top - nOffsetY;
            }
            else // 12 x 12
            {
                this.Width = LauncherForm.g_nGridWidth;
                this.Height = LauncherForm.g_nGridHeight;

                this.Left = this.Left + (LauncherForm.g_nGridWidth * (nStashX - 1));
                this.Top = this.Top + (LauncherForm.g_nGridHeight * (nStashY - 1));

                nOffsetX = (nStashX * 10) / 12;
                nOffsetY = (nStashY * 10) / 12;

                nOffsetX = nOffsetX + ((nStashX % 3) * nDefaultOffsetX); // 3칸 단위로 점점 늘어진다.
                nOffsetY = nOffsetY + ((nStashY % 3) * nDefaultOffsetY); // 3칸 단위로 점점 늘어진다.

                this.Left = this.Left - nOffsetX;
                this.Top = this.Top - nOffsetY;
            }

            // Final Offset.
            this.Left = this.Left + 1;
            this.Top = this.Top + 3;

            Visible = true;

            #region ⨌⨌ Back up. 1920*1080 Fixed ⨌⨌
            /*if (bIsQuad) // 24 x 24
            {
                this.Width = 54 / 2 + 1;
                this.Height = 54 / 2 + 1;

                this.Left = this.Left + ((54/2) * (nStashX-1)) ;
                this.Top = this.Top + ((54/2) * (nStashY-1)) ;

                nOffsetX = (nStashX * 10) / 24;
                nOffsetY = (nStashY * 10) / 24;

                nOffsetX = nOffsetX + ((nStashX % 3) * nDefaultOffsetX); // 3칸 단위로 점점 늘어진다.
                nOffsetY = nOffsetY + ((nStashY % 3) * nDefaultOffsetY); // 3칸 단위로 점점 늘어진다.

                this.Left = this.Left - nOffsetX;
                this.Top = this.Top - nOffsetY;
            }
            else // 12 x 12
            {
                this.Width = 54;
                this.Height = 54;

                this.Left = this.Left + (54 * (nStashX - 1));
                this.Top = this.Top + (54 * (nStashY - 1));

                nOffsetX = (nStashX * 10) / 12;
                nOffsetY = (nStashY * 10) / 12;

                nOffsetX = nOffsetX + ((nStashX % 3) * nDefaultOffsetX); // 3칸 단위로 점점 늘어진다.
                nOffsetY = nOffsetY + ((nStashY % 3) * nDefaultOffsetY); // 3칸 단위로 점점 늘어진다.

                this.Left = this.Left - nOffsetX;
                this.Top = this.Top - nOffsetY;
            }

            // Final Offset.
            this.Left = this.Left + 1;
            this.Top = this.Top + 3;
            */
        }

        private void ITEMIndicatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Dispose();
        }
    }
}
