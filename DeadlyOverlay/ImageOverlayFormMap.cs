using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace POExileDirection
{
    public partial class ImageOverlayFormMap : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        //RECT rectPOE;
        //RECT rectPOEBackup;

        private Graphics gGDIfx;
        public string m_strImagePath = null;

        private bool bListViewShowing = false;
        private bool bInitListviewDone = false;

        Image img = null;
        public int nZoom = 0;

        public ImageOverlayFormMap()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            this.ShowInTaskbar = false;
        }

        private void ImageOverlayFormMap_Load(object sender, EventArgs e)
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
            Visible = true;
        }

        private void Show_ListView()
        {
            try
            {
                foreach (var item in NinjaTranslation.Phanteons)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = "";
                    lvItem.SubItems.Add(item.strGodName);
                    lvItem.SubItems.Add(item.strMapName);
                    lvItem.SubItems.Add(item.strTier);
                    if(item.strTier == "" || String.IsNullOrEmpty(item.strTier))
                        lvItem.BackColor = Color.Bisque;

                    listViewPantheon.Items.Add(lvItem);
                }

                bInitListviewDone = true;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
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

            string sZoom = parser.GetSetting("LOCATIONIMGMAP", "ZOOM");
            img = resizeImage(img, new Size(img.Width + Int32.Parse(sZoom), img.Height + Int32.Parse(sZoom)));
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void ImageOverlayFormMap_Paint(object sender, PaintEventArgs e)
        {
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

            string sLeft = parser.GetSetting("LOCATIONIMGMAP", "LEFT");
            string sTop = parser.GetSetting("LOCATIONIMGMAP", "TOP");
            string sZoom = parser.GetSetting("LOCATIONIMGMAP", "ZOOM");

            if (sLeft == null) sLeft = "0";
            if (sTop == null) sTop = "0";
            if (sZoom == null) sZoom = "0";

            gGDIfx = e.Graphics;
            gGDIfx.DrawImage(img, new Point(0, 0));
            this.Top = Int32.Parse(sTop);
            this.Left = Int32.Parse(sLeft);
            this.Width = img.Width;
            this.Height = img.Height;

            #region ⨌⨌ Removed ⨌⨌
            /*switch (nButtonNumber)
            {                    
                case 3: // Incursion.png
                    gGDIfx.DrawImage(Bitmap.FromFile(@".\DeadlyInform\Incursion.png"), new Point(0, 25));
                    break;
                case 4:// Betrayal.png
                    gGDIfx.DrawImage(Bitmap.FromFile(@".\DeadlyInform\Betrayal.png"), new Point(0, 25));
                    break;
                case 6: // ExpensiveItemB.png
                    gGDIfx.DrawImage(Bitmap.FromFile(@".\DeadlyInform\ExpensiveItemB.png"), new Point(0, 25));
                    break;
                case 7: // Atlas.png
                    gGDIfx.DrawImage(Bitmap.FromFile(@".\DeadlyInform\Atlas.png"), new Point(0, 25));
                    break;
                case 9: // Vendorrecipe.png
                    gGDIfx.DrawImage(Bitmap.FromFile(@".\DeadlyInform\Vendorrecipe.png"), new Point(0, 25));
                    break;
                case 0:
                    gGDIfx.DrawImage(Bitmap.FromFile(@".\DeadlyInform\Currency.png"), new Point(0, 25));
                    break;
                default:
                    break;
            }
            */
            #endregion
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

            parser.AddSetting("LOCATIONIMGMAP", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONIMGMAP", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ControlForm.bIMGOvelayActivatedMAP = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            this.Close();
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
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

            string sZoom = parser.GetSetting("LOCATIONIMGMAP", "ZOOM");
            nZoom = Int32.Parse(sZoom);
            img = Bitmap.FromFile(m_strImagePath);
            nZoom = nZoom - 100;
            if (img.Width + nZoom >= 320 && img.Height + nZoom >= 258)
            {
                try
                {
                    img = resizeImage(img, new Size(img.Width + nZoom, img.Height + nZoom));

                    parser.AddSetting("LOCATIONIMGMAP", "ZOOM", nZoom.ToString());
                    parser.SaveSettings();

                    this.Invalidate();
                    this.Update();
                    this.Refresh();
                }
                catch (Exception ex)
                {
                    DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                }
            }
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
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

            string sZoom = parser.GetSetting("LOCATIONIMGMAP", "ZOOM");
            nZoom = Int32.Parse(sZoom);

            img = Bitmap.FromFile(m_strImagePath);
            nZoom = nZoom + 100;
            if (img.Width + nZoom <= 1901 && img.Height + nZoom <= 1154)
            {
                try
                //img = resizeImage(img, new Size(img.Width + nZoom, img.Height + nZoom));
                //img = DeadlyImageCommon.ScaleImage(img, img.Width + nZoom, img.Height + nZoom);
                {
                    img = resizeImage(img, new Size(img.Width + nZoom, img.Height + nZoom));

                    parser.AddSetting("LOCATIONIMGMAP", "ZOOM", nZoom.ToString());
                    parser.SaveSettings();

                    this.Invalidate();
                    this.Update();
                    this.Refresh();
                }
                catch (Exception ex)
                {
                    DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                }
            }
        }

        private void ImageOverlayFormMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (gGDIfx != null) gGDIfx.Dispose();
            if (img != null) img.Dispose();
        }

        private void ImageOverlayFormMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gGDIfx != null) gGDIfx.Dispose();
            if (img != null) img.Dispose();
        }

        private void btnLauncherLogin_Click(object sender, EventArgs e)
        {
            if (!bListViewShowing)
            {
                if(!bInitListviewDone)
                    Show_ListView();

                btnLauncherLogin.Text = "Hide Phanteon List";
                bListViewShowing = true;
                labelPhanteon.Visible = true;
                listViewPantheon.Visible = true;
            }
            else
            {
                btnLauncherLogin.Text = "Phanteon Inform.";
                bListViewShowing = false;
                labelPhanteon.Visible = false;
                listViewPantheon.Visible = false;
            }
        }

        private void listViewPantheon_DoubleClick(object sender, EventArgs e)
        {
            // Copy Map Name
            int nIndex = listViewPantheon.FocusedItem.Index;
            string strSelectedMapName = listViewPantheon.Items[nIndex].SubItems[2].Text;
            Clipboard.SetText(strSelectedMapName);

            SomeOneEnteredForm frmJoined = new SomeOneEnteredForm();
            frmJoined.strNickName = "Map Name";
            frmJoined.strLableText = "Copied.";
            frmJoined.Show();
        }
    }
}
