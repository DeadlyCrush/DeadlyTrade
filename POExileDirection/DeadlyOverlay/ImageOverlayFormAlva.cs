using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace POExileDirection
{
    public partial class ImageOverlayFormAlva : Form
    {
        int nLeft = 0;
        int nTop = 0;

        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        //RECT rectPOE;
        //RECT rectPOEBackup;

        public string m_strImagePath = null;

        Image img = null;
        public int nZoom = 0;

        public ImageOverlayFormAlva()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            this.ShowInTaskbar = false;
        }

        private void ImageOverlayFormAlva_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            Left = 0;
            Top = 0;

            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            #region ⨌⨌ Removed ⨌⨌
            // int nInitialStyle = GetWindowLong(this.Handle, -20); // Need to Drag. So Don't Pass
            // SetWindowLong(this.Handle, -20, nInitialStyle | 0x80000 | 0x20);

            /*GetWindowRect(handlePOE, out rectPOE);
            rectPOEBackup = rectPOE;
            //this.Size = new Size(rectPOE.right - rectPOE.left, rectPOE.bottom - rectPOE.top);
            this.Top = rectPOE.top;
            this.Left = rectPOE.left;
            this.Width = rectPOE.right;
            if (this.Width < 600) this.Width = 1920;
            this.Height = rectPOE.bottom;
            if (this.Height < 480) this.Height = 1080;*/
            #endregion


            Init_Controls();
            Visible = true;
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        public void Init_Controls()
        {
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
        }
        #endregion

        public void Load_Image()
        {
            img = Bitmap.FromFile(m_strImagePath);

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string sZoom = parser.GetSetting("LOCATIONIMGALVA", "ZOOM");

            nZoom = Convert.ToInt32(sZoom);
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

            pictureBox1.BackgroundImage = null;
            pictureBox1.BackgroundImage = img;

            if (nCatch > 1)
                return false;

            return true;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            nLeft = Left;
            nTop = Top;
            nMoving = 0;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            parser.AddSetting("LOCATIONIMGALVA", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONIMGALVA", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ControlForm.bIMGOvelayActivatedALVA = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            this.Close();
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string sZoom = parser.GetSetting("LOCATIONIMGALVA", "ZOOM");
            nZoom = Int32.Parse(sZoom);

            nZoom = nZoom - 1;
            if (!SetImage())
            {
                nZoom = nZoom + 1;
            }
            else
            {
                parser.AddSetting("LOCATIONIMGALVA", "ZOOM", nZoom.ToString());
                parser.SaveSettings();
            }            
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string sZoom = parser.GetSetting("LOCATIONIMGALVA", "ZOOM");
            nZoom = Int32.Parse(sZoom);

            nZoom = nZoom + 1;
            if (!SetImage())
            {
                nZoom = nZoom - 1;
            }
            else
            {
                parser.AddSetting("LOCATIONIMGALVA", "ZOOM", nZoom.ToString());
                parser.SaveSettings();
            }
        }

        private void ImageOverlayFormAlva_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (img != null) img.Dispose();
        }

        private void ImageOverlayFormAlva_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (img != null) img.Dispose();
        }
    }
}
