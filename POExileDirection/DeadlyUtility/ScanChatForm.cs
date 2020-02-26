using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Reflection;

namespace POExileDirection
{
    public partial class ScanChatForm : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        bool bIsMin = false;

        public string m_strNick = String.Empty;
        public string m_strMessage = String.Empty;
        private Dictionary<string, string> strArrMatchedTradeChat = new Dictionary<string, string>();

        private string strCurrentNick = String.Empty;

        public ScanChatForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void ScanChatForm_Load(object sender, EventArgs e)
        {
            Visible = false;

            listViewChat.View = View.Details;
            listViewChat.GridLines = true;
            listViewChat.FullRowSelect = true;
            listViewChat.

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

            try
            {
                string sLeft = parser.GetSetting("LOCATION", "SCANLEFT");
                string sTop = parser.GetSetting("LOCATION", "SCANTOP");
                
                Left = Convert.ToInt32(sLeft);
                Top = Convert.ToInt32(sTop);
            }
            catch(Exception ex)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't Read CHAT SCAN configuration.\r\n\r\ncheck your Configpath.ini case by game resolution.";
                frmMSG.ShowDialog();

                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }

            CheckMatchedTradeChat();

            Visible = true;
        }

        public void CheckMatchedTradeChat()
        {
            if (textBoxInclude.Text.Length <= 0)
                return;

            string[] separatingStrings = { ";" };
            string[] strArrInclude = textBoxInclude.Text.ToString().Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            string[] strArrExclude = textBoxExclude.Text.ToString().Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            int nCnt = 0;
            bool bDontAdd = false;

            // INCLUDE
            foreach (var itemInclude in strArrInclude)
            {
                if (m_strMessage.ToUpper().Contains(itemInclude.ToString().ToUpper()) && !bDontAdd)
                {
                    // EXCLUDE
                    foreach (var itemExclude in strArrExclude)
                    {
                        if (m_strMessage.ToUpper().Contains(itemExclude.ToString().ToUpper()))
                        {
                            bDontAdd = true;
                            break;
                        }
                    }

                    if (!bDontAdd)
                    {
                        bool bDuplicated = false;
                        foreach (var item in strArrMatchedTradeChat)
                        {
                            if(item.Key.ToString().ToUpper() == m_strNick && item.Value.ToString().ToUpper() == m_strMessage)
                            {
                                bDuplicated = true;
                                break;
                            }
                        }

                        if(!bDuplicated)
                        {
                            try
                            {
                                nCnt = nCnt + 1;
                                strArrMatchedTradeChat.Add(m_strNick, m_strMessage);
                                AddItemtoListView(m_strNick, m_strMessage);
                            }
                            catch
                            {
                                ; // Do Nothing.
                            }
                        }
                    }
                }

                bDontAdd = false;
            }
        }

        private void AddItemtoListView(string strNick, string strMessage)
        {
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = strNick;
            lvItem.SubItems.Add(strMessage);

            listViewChat.Items.Add(lvItem);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ControlForm.g_bIsSCANOn = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            this.Close();
        }

        private void BtnScan_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void BtnScan_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
        }

        private void BtnScan_MouseUp(object sender, MouseEventArgs e)
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

            parser.AddSetting("LOCATION", "SCANLEFT", Left.ToString());
            parser.AddSetting("LOCATION", "SCANTOP", Top.ToString());

            parser.SaveSettings();
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
                this.SetDesktopLocation(MousePosition.X - nMovePosX -34, MousePosition.Y - nMovePosY);
        }

        private void Label1_MouseUp(object sender, MouseEventArgs e)
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

            parser.AddSetting("LOCATION", "SCANLEFT", Left.ToString());
            parser.AddSetting("LOCATION", "SCANTOP", Top.ToString());

            parser.SaveSettings();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            strArrMatchedTradeChat.Clear();
            listViewChat.Items.Clear();
        }

        private void BtnWhisper_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            string strSendString = String.Format("@{0}", strCurrentNick);
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.SPACE);

            //iSim = null;
        }

        private void ListViewChat_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (listViewChat.Items.Count < 1)
                    return;

                if (listViewChat.SelectedItems != null && listViewChat.SelectedItems.Count > 0)
                {
                    int nIndex = listViewChat.FocusedItem.Index;
                    if (nIndex < 0)
                        return;

                    strCurrentNick = listViewChat.Items[nIndex].SubItems[0].Text;
                    labelNickName.Text = strCurrentNick;
                    labelMessage.Text = listViewChat.Items[nIndex].SubItems[1].Text;

                    panelDetail.Visible = true;
                }
            }
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            panelDetail.Visible = false;
        }

        private void BtnWhois_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            string strSendString = String.Format("/whois {0}", strCurrentNick);
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;
        }
    }
}
