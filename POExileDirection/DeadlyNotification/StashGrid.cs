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

        public StashGrid()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void StashGrid_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

            this.ControlBox = false;
            DoubleBuffered = true;

            GetScreenWidthHeight();
            //timerSizeChecker.Start();
            Visible = true;
        }

        private void StashGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (timerSizeChecker != null) timerSizeChecker.Dispose();
            ControlForm.bfrmStashGridShow = false;
        }

        private RECT rcPOE;
        private Point ptLeftTop;
        private RECT rcClient;
        private void GetScreenWidthHeight()
        {
            InteropCommon.GetWindowRect(LauncherForm.g_handlePathOfExile, out rcPOE);
            InteropCommon.GetClientRect(LauncherForm.g_handlePathOfExile, out rcClient);
            InteropCommon.ClientToScreen(LauncherForm.g_handlePathOfExile, ref ptLeftTop);

            Width = rcPOE.right / 2;
            Height = rcPOE.bottom;
        }
        private void StashGrid_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                double dLeft;
                double dTop;
                double dRight;
                double dBottom;
                double dGridNormal;

                dLeft = Math.Round(rcClient.bottom * 0.0125f);
                dTop = Math.Round(rcClient.bottom * 0.146625f);
                dRight = Math.Round(rcClient.bottom * 0.603875f);
                dBottom = Math.Round(rcClient.bottom * 0.738f);
                dGridNormal = Math.Round((rcClient.bottom * 0.591375 - 4) / 12);

                double dWidth = dRight;// - dLeft;
                double dHeight = dBottom;// - dTop;

                int nLeft = Convert.ToInt32(dLeft);
                int nTop = Convert.ToInt32(dTop);
                if (!LauncherForm.g_isWindowdedFullScreen)
                {
                    nLeft = nLeft + ptLeftTop.X;
                    nTop = nTop + ptLeftTop.Y;

                    Width = Width + ptLeftTop.X;
                    Height = Height + ptLeftTop.Y;
                }
                Height = Height + 22; // Quad Check Panel

                int nGridQuad = Convert.ToInt32(dGridNormal / 2);

                // 1x1 Normal
                Rectangle rcCell;
                Pen NormalPen = new Pen(Color.Aqua, 1);
                for (int i = 0; i < 12; i++) // ROWS
                {
                    for (int j = 0; j < 12; j++) // COLLUMS
                    {
                        rcCell = new Rectangle(nLeft, nTop, Convert.ToInt32(dGridNormal), Convert.ToInt32(dGridNormal));
                        e.Graphics.DrawRectangle(NormalPen, rcCell);

                        LauncherForm.g_arrayRect1x1[i, j] = rcCell;
                        nLeft = nLeft + Convert.ToInt32(dGridNormal); // Next Col.
                    }
                    nLeft = Convert.ToInt32(dLeft); // Back to First COL.
                    if (!LauncherForm.g_isWindowdedFullScreen)
                        nLeft = nLeft + ptLeftTop.X;
                    nTop = nTop + Convert.ToInt32(dGridNormal); // Next Row.
                }

                panelQuadCheck.Left = LauncherForm.g_arrayRect1x1[11, 11].Right - panelQuadCheck.Width;
                panelQuadCheck.Top = LauncherForm.g_arrayRect1x1[11, 11].Bottom + 10;

                // 4x4 Quad
                Pen QuadPen = new Pen(Color.Plum, 1);
                Rectangle rcQuad = new Rectangle();
                for (int i = 0; i < 12; i++) // ROWS
                {
                    for (int j = 0; j < 12; j++) // COLLUMS
                    {
                        rcCell = LauncherForm.g_arrayRect1x1[i, j];

                        /*
                        +------------++------------++------------++------------+
                        +     +      ++     +      ++     +      ++     +      +
                        +-----+------++-----+------++-----+------++-----+------+
                        +     +      ++     +      ++     +      ++     +      +
                        +------------++------------++------------++------------+
                        +     +      ++     +      ++     +      ++     +      +
                        +-----+------++-----+------++-----+------++-----+------+
                        +     +      ++     +      ++     +      ++     +      +
                        +------------++------------++------------++------------+
                        */
                        for (int iQuad = 0; iQuad < 2; iQuad++)
                        {
                            for (int jQuad = 0; jQuad < 2; jQuad++) // Quad Cell in Each normal Cell.
                            {
                                rcQuad.X = rcCell.Left + jQuad * nGridQuad;
                                rcQuad.Y = rcCell.Top + jQuad * nGridQuad;
                                rcQuad.Width = nGridQuad;
                                rcQuad.Height = nGridQuad;
                                if(checkQuadTab.Checked)
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
        }

        private void checkQuadTab_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
