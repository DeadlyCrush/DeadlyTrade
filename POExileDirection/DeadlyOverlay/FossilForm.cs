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
            this.StartPosition = FormStartPosition.Manual;
            Left = 0;
            Top = 0;

            Init_Control();

            pictureBox1.BackgroundImage = null;
            if (LauncherForm.g_strUILang == "KOR")
                img = Image.FromFile(Application.StartupPath+ "\\DeadlyInform\\fossil_kor.jpg");
            else
                img = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\fossil_eng.jpg");

            SetImage();
        }

        private void Init_Control()
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.TabStop = false;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlForm.g_bIsFossilOn = false;
            pictureBox1.Dispose();
            Close();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            nZoom = nZoom + 1;
            if (!SetImage())
                nZoom = nZoom - 1;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            nZoom = nZoom - 1;
            if (!SetImage())
                nZoom = nZoom + 1;
        }
    }
}
