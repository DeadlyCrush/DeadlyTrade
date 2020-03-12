using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class ImageOverlayForm : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        //RECT rectPOE;
        //RECT rectPOEBackup;
        int nLeft = 0;
        int nTop = 0;

        private Graphics gGDIfx;
        public string m_strImagePath = null;

        Image img = null;
        public int nZoom = 0;

        public ImageOverlayForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            this.ShowInTaskbar = false;
        }

        private void ImageOverlayForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

            //gGDIfx.DrawImage(Bitmap.FromFile(@".\DeadlyInform\Essence_KOR.png"), new Point(0, 0));

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
            nLeft = Left;
            nTop = Top;

            Visible = true;
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        public void Init_Controls()
        {
            //
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.TabStop = false;

            //
            btnZoomOut.FlatStyle = FlatStyle.Flat;
            btnZoomOut.BackColor = Color.Transparent;
            btnZoomOut.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnZoomOut.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnZoomOut.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnZoomOut.FlatAppearance.BorderSize = 0;
            btnZoomOut.TabStop = false;

            //
            btnZoomIn.FlatStyle = FlatStyle.Flat;
            btnZoomIn.BackColor = Color.Transparent;
            btnZoomIn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnZoomIn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnZoomIn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnZoomIn.FlatAppearance.BorderSize = 0;
            btnZoomIn.TabStop = false;
        }
        #endregion

        public void Load_Image()
        {
            img = Bitmap.FromFile(m_strImagePath);

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string sZoom = parser.GetSetting("LOCATIONIMG", "ZOOM");
            //img = resizeImage(img, new Size(img.Width + Int32.Parse(sZoom), img.Height + Int32.Parse(sZoom)));

            nZoom = Convert.ToInt32(sZoom);
            SetImage();
        }

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
            Height = iHeight + 16;
            if (Height > rcClient.bottom) Height = rcClient.bottom;

            Left = nLeft;
            Top = nTop;

            pictureBox1.BackgroundImage = null;
            pictureBox1.BackgroundImage = img;
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
            nMoving = 0;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            parser.AddSetting("LOCATIONIMG", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONIMG", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ControlForm.bIMGOvelayActivated = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            this.Close();
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string sZoom = parser.GetSetting("LOCATIONIMG", "ZOOM");
            nZoom = Int32.Parse(sZoom);

            img = Bitmap.FromFile(m_strImagePath);
            nZoom = nZoom - 1;
            
            parser.AddSetting("LOCATIONIMG", "ZOOM", nZoom.ToString());
            parser.SaveSettings();

            SetImage();
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string sZoom = parser.GetSetting("LOCATIONIMG", "ZOOM");
            nZoom = Int32.Parse(sZoom);
            nZoom = nZoom + 1;

            parser.AddSetting("LOCATIONIMG", "ZOOM", nZoom.ToString());
            parser.SaveSettings();

            SetImage();
        }

        private void ImageOverlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (img != null) img.Dispose();
            this.Dispose();
        }

        private void ImageOverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (img != null) img.Dispose();
        }
    }
}
