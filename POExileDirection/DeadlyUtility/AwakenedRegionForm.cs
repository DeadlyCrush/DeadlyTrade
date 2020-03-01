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
            
            foreach (var item in DeadlyTranslation.RegionMapOLT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

            foreach (var item in DeadlyTranslation.RegionMapORT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

            foreach (var item in DeadlyTranslation.RegionMapOLB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

            foreach (var item in DeadlyTranslation.RegionMapORB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

            foreach (var item in DeadlyTranslation.RegionMapILT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

            foreach (var item in DeadlyTranslation.RegionMapIRT)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

            foreach (var item in DeadlyTranslation.RegionMapILB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

            foreach (var item in DeadlyTranslation.RegionMapIRB)
            {
                string strSearch = String.Empty;
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (DeadlyTranslation.transWhiteMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transWhiteMaps[item];
                }
                else
                    strSearch = item;

                if (String.IsNullOrEmpty(strSearch))
                {
                    if (DeadlyTranslation.transUniqueMaps.ContainsKey(item))
                        strSearch = DeadlyTranslation.transUniqueMaps[item];
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

        #region [[[[[ Form Drag Moving ]]]]]
        private void xuiFlatTab1_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void xuiFlatTab1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void xuiFlatTab1_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        } 
        #endregion

        #region [[[[[ Dispose & Close ]]]]]
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose2nd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AwakenedRegionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            panel1.Dispose();
            ControlForm.bISearchRegionOn = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        } 
        #endregion
    }
}
