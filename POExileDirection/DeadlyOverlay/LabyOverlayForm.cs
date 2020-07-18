using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class LabyOverlayForm : Form
    {
        #region Glova; Variables
        public static Bitmap g_OverlayLABBmp { get; set; }
        LaunchedOverlayIMAGEForm frmOverlayIMAGE;
        public static string _LabName { get; set; }

        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;
        #endregion
        public LabyOverlayForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";

            HidePanelMarker();
            g_OverlayLABBmp = null;
        }

        private string GetPOELABDateTime()
        {
            // poelab changed image file name format ex) 2020-07-18_000138227_uber.jpg
            DateTime dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));

            string strAUSDateTime = dt.ToString("yyyy-MM-dd");
            //string strDebug = dt.ToString("yyy-MM-dd HH:mm:ss");
            //MessageBox.Show(strDebug);
            return strAUSDateTime;
        }

        private string GetPOELABDateTimeDetail()
        {
            DateTime dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));

            string strAUSDateTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return strAUSDateTime;
        }

        private void HidePanelMarker()
        {
            panelUBER.Visible = false;
            panelMERC.Visible = false;
            panelCRUEL.Visible = false;
            panelNORMAL.Visible = false;
        }

        private void pictureUBER_Click(object sender, EventArgs e)
        {
            btnLaunchOverlay.Enabled = false;

            HidePanelMarker();
            panelUBER.Visible = true;

            string strLABImagePath = String.Empty;
            strLABImagePath = String.Format(@"https://www.poelab.com/wp-content/labfiles/{0}_uber.jpg", GetPOELABDateTime());

            labelAUDAteTime.Text = "GMT 0 DateTime : " + GetPOELABDateTimeDetail();

            WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(strLABImagePath);
            TmpRequest.Timeout = 3000;
            try
            {
                WebResponse TmpResponse = TmpRequest.GetResponse();
                g_OverlayLABBmp = new Bitmap(TmpResponse.GetResponseStream());

                Rectangle rcCrop = new Rectangle(289, 110, 840, 268);
                g_OverlayLABBmp = DeadlyImageCommon.cropImage(g_OverlayLABBmp, rcCrop);

                pictureLabyrinthLayout.BackgroundImage = g_OverlayLABBmp;
                _LabName = "UBER";

                btnLaunchOverlay.Enabled = true;
            }
            catch
            {
                pictureLabyrinthLayout.BackgroundImage = Properties.Resources.LABUber;
                pictureLabyrinthLayout.Invalidate();
                labelAUDAteTime.Text = "Can't Get LAB Image from POE LAB. Try Later";
            }
        }

        private void pictureBERC_Click(object sender, EventArgs e)
        {
            btnLaunchOverlay.Enabled = false;

            HidePanelMarker();
            panelMERC.Visible = true;

            string strLABImagePath = String.Empty;
            strLABImagePath = String.Format(@"https://www.poelab.com/wp-content/labfiles/{0}_merciless.jpg", GetPOELABDateTime());

            labelAUDAteTime.Text = "GMT 0 DateTime : " + GetPOELABDateTimeDetail();

            WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(strLABImagePath);
            TmpRequest.Timeout = 3000;
            try
            {
                WebResponse TmpResponse = TmpRequest.GetResponse();
                g_OverlayLABBmp = new Bitmap(TmpResponse.GetResponseStream());

                Rectangle rcCrop = new Rectangle(289, 110, 840, 268);
                g_OverlayLABBmp = DeadlyImageCommon.cropImage(g_OverlayLABBmp, rcCrop);

                pictureLabyrinthLayout.BackgroundImage = g_OverlayLABBmp;
                _LabName = "MERC";

                btnLaunchOverlay.Enabled = true;
            }
            catch
            {
                pictureLabyrinthLayout.BackgroundImage = Properties.Resources.LABMerc;
                pictureLabyrinthLayout.Invalidate();
                labelAUDAteTime.Text = "Can't Get LAB Image from POE LAB. Try Later";
            }
        }

        private void pictureCRUEL_Click(object sender, EventArgs e)
        {
            btnLaunchOverlay.Enabled = false;

            HidePanelMarker();
            panelCRUEL.Visible = true;

            string strLABImagePath = String.Empty;
            strLABImagePath = String.Format(@"https://www.poelab.com/wp-content/labfiles/{0}_cruel.jpg", GetPOELABDateTime());

            labelAUDAteTime.Text = "GMT 0 DateTime : " + GetPOELABDateTimeDetail();

            WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(strLABImagePath);
            TmpRequest.Timeout = 3000;
            try
            {
                WebResponse TmpResponse = TmpRequest.GetResponse();
                g_OverlayLABBmp = new Bitmap(TmpResponse.GetResponseStream());

                Rectangle rcCrop = new Rectangle(289, 110, 840, 268);
                g_OverlayLABBmp = DeadlyImageCommon.cropImage(g_OverlayLABBmp, rcCrop);

                pictureLabyrinthLayout.BackgroundImage = g_OverlayLABBmp;
                _LabName = "CRUEL";

                btnLaunchOverlay.Enabled = true;
            }
            catch
            {
                pictureLabyrinthLayout.BackgroundImage = Properties.Resources.LABCruel;
                pictureLabyrinthLayout.Invalidate();
                labelAUDAteTime.Text = "Can't Get LAB Image from POE LAB. Try Later";
            }
        }

        private void pictureNORMAL_Click(object sender, EventArgs e)
        {
            btnLaunchOverlay.Enabled = false;

            HidePanelMarker();
            panelNORMAL.Visible = true;

            string strLABImagePath = String.Empty;
            strLABImagePath = String.Format(@"https://www.poelab.com/wp-content/labfiles/{0}_normal.jpg", GetPOELABDateTime());

            labelAUDAteTime.Text = "GMT 0 DateTime : " + GetPOELABDateTimeDetail();

            WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(strLABImagePath);
            TmpRequest.Timeout = 3000;
            try
            {
                WebResponse TmpResponse = TmpRequest.GetResponse();
                g_OverlayLABBmp = new Bitmap(TmpResponse.GetResponseStream());

                Rectangle rcCrop = new Rectangle(289, 110, 840, 268);
                g_OverlayLABBmp = DeadlyImageCommon.cropImage(g_OverlayLABBmp, rcCrop);

                pictureLabyrinthLayout.BackgroundImage = g_OverlayLABBmp;
                _LabName = "NORMAL";

                btnLaunchOverlay.Enabled = true;
            }
            catch
            {
                pictureLabyrinthLayout.BackgroundImage = Properties.Resources.LABNormal;
                pictureLabyrinthLayout.Invalidate();
                labelAUDAteTime.Text = "Can't Get LAB Image from POE LAB. Try Later";
            }
        }

        private void btnLaunchOverlay_Click(object sender, EventArgs e)
        {
            if (g_OverlayLABBmp != null)
            {
                if (frmOverlayIMAGE == null)
                    frmOverlayIMAGE = new LaunchedOverlayIMAGEForm();

                frmOverlayIMAGE.Show();

                Close();
            }
        }

        private void LabyOverlayForm_Load(object sender, EventArgs e)
        {
            btnLaunchOverlay.Enabled = false;
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void labelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlForm.bLabOverlayShow = false;
            Close();
        }
    }
}
