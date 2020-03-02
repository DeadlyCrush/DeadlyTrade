using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class NotificationContainer : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        private string sLeft = String.Empty;
        private string sTop = String.Empty;

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

        public NotificationContainer()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void NotificationContainer_Load(object sender, EventArgs e)
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

            sLeft = parser.GetSetting("LOCATIONNOTIFY", "LEFT");
            sTop = parser.GetSetting("LOCATIONNOTIFY", "TOP");

            this.Left = Convert.ToInt32(sLeft);
            this.Top = Convert.ToInt32(sTop);
        }

        public void AddNotifyForm(NotificationForm frmNotifyPanel)
        {
            Height = Height + 114;
            try
            {
                if (frmNotifyPanel != null)
                {
                    Panel p = new Panel();
                    p.Name = "Notification_" + (panelNOTIFICATION.Controls.Count + 1);
                    p.Size = new Size(frmNotifyPanel.Width, 114);

                    NotificationForm.panelName = p.Name;
                    frmNotifyPanel.FormClosed += FrmNotifyPanel_FormClosed;
                    frmNotifyPanel.SizeChanged += FrmNotifyPanel_SizeChanged;
                    frmNotifyPanel.TopLevel = false;
                    frmNotifyPanel.Dock = DockStyle.Top;
                    frmNotifyPanel.FormBorderStyle = FormBorderStyle.None;

                    p.Dock = DockStyle.Top;
                    p.Controls.Add(frmNotifyPanel);
                    p.Tag = frmNotifyPanel;
                    frmNotifyPanel.BringToFront();
                    frmNotifyPanel.Show();

                    panelNOTIFICATION.Controls.Add(p);

                    PanelAdjust(p);
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void FrmNotifyPanel_SizeChanged(object sender, EventArgs e)
        {
            Panel parentPanel = ((Form)sender).Parent as Panel;
            Form frmSender = (Form)sender as Form;
            parentPanel.Height = frmSender.Height;
        }

        private void FrmNotifyPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Panel parentPanel = ((Form)sender).Parent as Panel;
            parentPanel.Visible = false;
            parentPanel.Dispose();

            if(Height > 113)
                Height = Height - 114;
        }

        private void PanelAdjust(Panel newPanel)
        {
            panelNOTIFICATION.Controls.SetChildIndex(newPanel, 0);
            //panelNOTIFICATION.Invalidate();
        }

        private void NotificationContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Escape)
                return;
        }

        private void pictureMovingBar_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void pictureMovingBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void pictureMovingBar_MouseUp(object sender, MouseEventArgs e)
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
            DeadlyLog4Net._log.Info($"{MethodBase.GetCurrentMethod().Name} RESOLUTION : " + strINIPath);

            parser.AddSetting("LOCATIONNOTIFY", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONNOTIFY", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }
    }
}
