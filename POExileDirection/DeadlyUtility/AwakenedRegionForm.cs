using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Reflection;

namespace POExileDirection
{
    public partial class AwakenedRegionForm : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        public int m_nRight;
        public int m_nTop;

        public AwakenedRegionForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void AwakenedRegionForm_Load(object sender, EventArgs e)
        {
            this.Left = m_nRight - this.Width;
            this.Top = m_nTop - this.Height;

            if (LauncherForm.g_strUILang == "KOR")
            {
                btnOLT.BackgroundImage = Properties.Resources.HamletKR;
                btnORT.BackgroundImage = Properties.Resources.EjorisKR;
                btnOLB.BackgroundImage = Properties.Resources.NewKR;
                btnORB.BackgroundImage = Properties.Resources.LiraArthainKR;
                btnILT.BackgroundImage = Properties.Resources.TirnKR;
                btnIRT.BackgroundImage = Properties.Resources.ProximaKR;
                btnILB.BackgroundImage = Properties.Resources.GairnsKR;
                btnIRB.BackgroundImage = Properties.Resources.ValdoKR;
            }
        }

        private void btnOLT_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();
            
            foreach (var item in NinjaTranslation.RegionMapOLT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "헤이워크 촌락";
            else
                strSendString = "Haewark Hamlet";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlForm.bISearchRegionOn = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            Close();
        }

        private void listResult_DoubleClick(object sender, EventArgs e)
        {
            if (listResult.FocusedItem == null)
                return;

            int nIndex = listResult.FocusedItem.Index;
            string strSelectedName = listResult.Items[nIndex].SubItems[1].Text;
            
            try
            {
                InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

                InputSimulator iSim = new InputSimulator();

                iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
                iSim.Keyboard.TextEntry(strSelectedName);
                iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void btnORT_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            foreach (var item in NinjaTranslation.RegionMapORT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "렉스 에요리스";
            else
                strSendString = "Lex Ejoris";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }

        private void btnOLB_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            foreach (var item in NinjaTranslation.RegionMapOLB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "뉴 바스티르";
            else
                strSendString = "New Vastir";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }

        private void btnORB_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            foreach (var item in NinjaTranslation.RegionMapORB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "리라 아르타인";
            else
                strSendString = "Lira Arthain";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }

        private void btnILT_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            foreach (var item in NinjaTranslation.RegionMapILT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "티른의 끝자락";
            else
                strSendString = "Tirn's End";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }

        private void btnIRT_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            foreach (var item in NinjaTranslation.RegionMapIRT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "렉스 프록시마";
            else
                strSendString = "Lex Proxima";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }

        private void btnILB_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            foreach (var item in NinjaTranslation.RegionMapILB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            //SendKeys.SendWait("^F");
            

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);

            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "글렌나크 돌무덤";
            else
                strSendString = "Glennach Cairns";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            //SendKeys.SendWait("{ENTER}");

            //iSim = null;

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }

        private void btnIRB_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();

            foreach (var item in NinjaTranslation.RegionMapIRB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (NinjaTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = NinjaTranslation.transUniqueMaps[item];
                }                

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = "";
                lvItem.SubItems.Add(strSearch);

                listResult.Items.Add(lvItem);
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            InputSimulator iSim = new InputSimulator();

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            string strSendString = String.Empty;
            if (LauncherForm.g_strUILang == "KOR")
                strSendString = "발도의 휴식처";
            else
                strSendString = "Valdo's Rest";
            iSim.Keyboard.TextEntry(strSendString);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            labelRegion.Text = strSendString + " (Double click listed item to search.)";
        }
    }
}
