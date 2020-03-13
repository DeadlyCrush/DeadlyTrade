using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class LaunchedOverlayIMAGEForm : Form
    {
        #region Class Global Variables
        int nLeft = 0;
        int nTop = 0;

        Image img = null;
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        public int nZoom = 0;
        #endregion

        public LaunchedOverlayIMAGEForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";        
        }

        private void LaunchedOverlayIMAGEForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            Left = 0;
            Top = 0;

            img = LabyOverlayForm.g_OverlayLABBmp;
            label2.Text = "[" + LabyOverlayForm._LabName + "] Labyrinth (POE Lab)";

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose.TabStop = false;
            btnZoomin.FlatStyle = FlatStyle.Flat;
            btnZoomin.BackColor = Color.Transparent;
            btnZoomin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnZoomin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnZoomin.TabStop = false;
            btnZoomout.FlatStyle = FlatStyle.Flat;
            btnZoomout.BackColor = Color.Transparent;
            btnZoomout.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnZoomout.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnZoomout.TabStop = false;

            SetImage();
        }

        private bool SetImage()
        {
            int nCatch = 0;

            int iWidth = 0;
            int iHeight = 0;
            int nWidth = 0;
            int nHeight = 0;
            if (nZoom != 0)
            {
                nWidth = img.Width + (img.Width * nZoom / 10);
                nHeight = img.Height + (img.Height * nZoom / 10);
            }
            else
            {
                nWidth = img.Width;
                nHeight = img.Height;
            }


            if ((nHeight == 0) && (nWidth != 0))
            {
                iWidth = nWidth;
                iHeight = (img.Size.Height * iWidth / img.Size.Width);
            }
            else if ((nHeight != 0) && (nWidth == 0))
            {
                iHeight = nHeight;
                iWidth = (img.Size.Width * iHeight / img.Size.Height);
            }
            else
            {
                iWidth = nWidth;
                iHeight = nHeight;
            }

            Rectangle rcPrimary = Screen.PrimaryScreen.Bounds;
            Width = iWidth;
            if (Width > rcPrimary.Width)
            {
                Width = rcPrimary.Width;
                nCatch = nCatch + 1;
            }
            Height = iHeight + 16;
            if (Height > rcPrimary.Height)
            {
                Height = rcPrimary.Height;
                nCatch = nCatch + 1;
            }

            Left = nLeft;
            Top = nTop;

            if (nCatch > 1)
                return false;

            pictureBox1.BackgroundImage = null;
            pictureBox1.BackgroundImage = img;

            return true;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            nZoom = nZoom - 1;
            if (!SetImage())
            {
                nZoom = nZoom + 1;
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            nZoom = nZoom + 1;
            if (!SetImage())
            {
                nZoom = nZoom - 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlForm.bLabOverlayShow = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        }
    }
}
