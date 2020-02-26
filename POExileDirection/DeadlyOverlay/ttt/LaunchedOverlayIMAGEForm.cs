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
        private Bitmap scaledBitmap = null;
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;
        #endregion

        public LaunchedOverlayIMAGEForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";

            scaledBitmap = LabyOverlayForm.g_OverlayLABBmp;
            pictureBoxOverlay.BackgroundImage = scaledBitmap;

            labelTitle.Text = "[" + LabyOverlayForm._LabName + "] DeadlyTrade Overlay Labyrinth ::  from POE LAB";

            this.btnZoomIn.FlatStyle = FlatStyle.Flat;
            this.btnZoomIn.BackColor = Color.Transparent;
            this.btnZoomIn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.btnZoomIn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.btnZoomIn.FlatAppearance.BorderColor = Color.FromArgb(0, 39, 44, 56);
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.TabStop = false;

            this.btnZoomOut.FlatStyle = FlatStyle.Flat;
            this.btnZoomOut.BackColor = Color.Transparent;
            this.btnZoomOut.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.btnZoomOut.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.btnZoomOut.FlatAppearance.BorderColor = Color.FromArgb(0, 39, 44, 56);
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.TabStop = false;

            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(0, 39, 44, 56);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.TabStop = false;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if ((Width - 50) >= 240 && (Height - 50) >= 119)
            {
                scaledBitmap = DeadlyImageCommon.ScaleImage(scaledBitmap, Width - 50, Height - 50);
                Width = scaledBitmap.Width;
                Height = scaledBitmap.Height;
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if ((Width + 50) <= 920 && (Height + 50) <= 455)
            {
                scaledBitmap = DeadlyImageCommon.ScaleImage(scaledBitmap, Width + 50, Height + 50);
                Width = scaledBitmap.Width;
                Height = scaledBitmap.Height;
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

        private void LaunchedOverlayIMAGEForm_Load(object sender, EventArgs e)
        {
            ;
        }
    }
}
