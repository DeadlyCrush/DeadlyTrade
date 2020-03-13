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
using WindowsInput;
using WindowsInput.Native;

namespace POExileDirection.DeadlyNotification
{
    public partial class TradeHistory : Form
    {
        private bool bInitListviewDone = false;

        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        private string strCurrentNick = String.Empty;

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

        public TradeHistory()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            CenterToScreen();
        }

        private void TradeHistory_Load(object sender, EventArgs e)
        {
            if (!bInitListviewDone)
                Show_ListView();
        }

        private void Show_ListView()
        {
            try
            {
                foreach (var item in ControlForm.g_TradeMsgListHistory)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = "";
                    lvItem.SubItems.Add(item.tradePurpose);
                    lvItem.SubItems.Add(item.nickName);
                    lvItem.SubItems.Add(item.itemName);
                    lvItem.SubItems.Add(item.fullMSG);
                    listView1.Items.Add(lvItem);
                }

                bInitListviewDone = true;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.Items.Count < 1)
                    return;

                if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
                {
                    int nIndex = listView1.FocusedItem.Index;
                    if (nIndex < 0)
                        return;

                    strCurrentNick = listView1.Items[nIndex].SubItems[1].Text;
                    labelNickName.Text = strCurrentNick;
                    labelMessage.Text = listView1.Items[nIndex].SubItems[3].Text;

                    panelDetail.Visible = true;
                }
            }
        }

        private void btnWhois_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            string strSendString = String.Format("/whois {0}", strCurrentNick);
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void btnWhisper_Click(object sender, EventArgs e)
        {
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            string strSendString = String.Format("@{0}", strCurrentNick);
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
        }
    }
}
