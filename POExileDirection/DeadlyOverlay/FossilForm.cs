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
    public partial class FossilForm : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        int nLeft = 0;
        int nTop = 0;

        public FossilForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            this.ShowInTaskbar = false;
        }

        Image img;
        private void FossilForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            Left = 0;
            Top = 0;

            pictureBox1.BackgroundImage = null;
            if (LauncherForm.g_strUILang == "KOR")
                img = Image.FromFile(Application.StartupPath+ "\\DeadlyInform\\fossil_kor.jpg");
            else
                img = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\fossil_eng.jpg");

            SetImage();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            nLeft = Left;
            nTop = Top;
            nMoving = 0;
        }

        private int nZoom = 0;
        private void SetImage()
        {
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

            RECT rcClient;
            InteropCommon.GetClientRect(LauncherForm.g_handlePathOfExile, out rcClient);

            Width = iWidth;
            if (Width > rcClient.right) Width = rcClient.right;
            Height = iHeight + 20;
            if (Height > rcClient.bottom) Height = rcClient.bottom;

            Left = nLeft;
            Top = nTop;

            pictureBox1.BackgroundImage = null;
            pictureBox1.BackgroundImage = img;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlForm.g_bIsFossilOn = false;
            pictureBox1.Dispose();
            Close();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            nZoom = nZoom + 1;
            SetImage();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            nZoom = nZoom - 1;
            SetImage();
        }
    }
}
