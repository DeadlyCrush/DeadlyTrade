using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Reflection;
using WindowsHook;

namespace POExileDirection
{
    public partial class ControlForm : Form
    {
        /*System.Windows.Forms.Timer DeadlyLOGParingTimer;
        System.Threading.Timer DeadlyLOGParingTimerCalled;
        BackgroundWorker bgDeadlyWorker;
        object lockSafe = new object();*/

        #region ⨌⨌ Get Cursor State ⨌⨌
        /*private static string GetCursorState()
        {
            var h = Cursors.WaitCursor.Handle;

            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out pci);


            return pci.hCursor.ToString();
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;        // Specifies the size, in bytes, of the structure. 
                                        // The caller must set this to Marshal.SizeOf(typeof(CURSORINFO)).
            public Int32 flags;         // Specifies the cursor state. This parameter can be one of the following values:
                                        //    0             The cursor is hidden.
                                        //    CURSOR_SHOWING    The cursor is showing.
            public IntPtr hCursor;          // Handle to the cursor. 
            public POINT ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor. 
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);*/
        #endregion

        public const string POE_WINDOTITLE = "Path of Exile"; // POE Window Title

        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        private bool bIsMinimized = false;

        private bool isMainExpand = false;

        public static bool bNeedtoShowAvailabeUpdate { get; set; }

        #region [[[[[ Hot Keys ]]]]]
        // Hot Keys
        fsModifiers m_unMod = 0;
        System.Windows.Forms.Keys m_HotKey = 0;
        const int WM_MOUSEWHEEL = 0x020A;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_CTRL = 0x11;
        const int VK_LEFT = 0x25;
        const int VK_RIGHT = 0x26;

        // OVERLAY
        string[] strImagePath = new string[3];

        /*
        J=NONE;114
        Z=NONE;117
        H=NONE;116
        R=NONE;113
        A=NONE;115
        */
        // HOTKEY
        static public string keyMAINRemains { get; set; }// F2 - NONE;113
        static public string keyMAINJUN { get; set; }// F3 - NONE;114
        static public string keyMAINALVA { get; set; }// F4 - NONE;115
        static public string keyMAINZANA { get; set; }// F6 - NONE;117
        static public string keyMAINHideout { get; set; }// F5 - NONE;114
        static public string keySearchbyPosition { get; set; }// CONTROL+P

        static public string keyEXIT { get; set; }// CONTROL+SHIT+SPACE

        DeadlyHotkeys ovHRemains = new DeadlyHotkeys();
        DeadlyHotkeys ovHJUN = new DeadlyHotkeys();
        DeadlyHotkeys ovHALVA = new DeadlyHotkeys();
        DeadlyHotkeys ovHZANA = new DeadlyHotkeys();
        DeadlyHotkeys ovHHideout = new DeadlyHotkeys();
        DeadlyHotkeys ovHSearchbyPosition = new DeadlyHotkeys();
        DeadlyHotkeys ovHEXIT = new DeadlyHotkeys();
        #endregion

        #region [[[[[ Child Forms ]]]]]
        // QUEST HELPER
        MainForm frmMainForm = null;

        GuideGridForm frmSearchStash = null;

        // Labyrinth Overlay
        LabyOverlayForm frmLabSelect = null;
        public static bool bLabOverlayShow = false;

        // JUN (SYNDICATE)
        ImageOverlayForm frmIMGOverlay = null; // RollBack to Image File Overlay 1.3.9.0 Ver.
        //DeadlySyndicateForm frmIMGOverlay = null;
        public static bool bIMGOvelayActivated { get; set; }
        // ALVA (INCURSION )
        ImageOverlayFormAlva frmIMGOverlayALVA = null;
        public static bool bIMGOvelayActivatedALVA { get; set; }
        // ZANA (MAP)
        ImageOverlayFormMap frmIMGOverlayMAP = null;
        public static bool bIMGOvelayActivatedMAP { get; set; }

        AwakenedRegionForm frmSearchRegion = null;
        public static bool bISearchRegionOn { get; set; }

        BlightOilForm frmOils = null;
        public static bool bOilsFormON { get; set; }

        NinjaForm frmNinja = new NinjaForm();
        public static bool bShowNinja { get; set; }

        ChromaticCalcForm frmVoriciCalc = new ChromaticCalcForm();
        public static bool bVoriciCalcFormViewing { get; set; }

        // ZONE NAME
        public static string g_strZoneName { get; set; }

        //ZoneItemsForm frmZoneItem = null;

        // STASH GRID
        StashGrid frmStashGrid = null;
        public static bool bfrmStashGridShow { get; set; }

        public static RemainingForm formMonster = null;
        public static bool g_bIsRemainingOn { get; set; }

        public static bool g_bIsSearchPop { get; set; }

        private bool bIsSettingsPop = false;

        public static bool g_bIsDropInformOn { get; set; }

        ScanChatForm frmScanChat = null;
        public static bool g_bIsSCANOn { get; set; }

        public static NotificationContainer frmNotificationContainer = new NotificationContainer();
        public static bool g_bIsNofiticationContainerOn { get; set; }

        private FlaskTimerCircleForm frmF1 = null;
        private FlaskTimerCircleForm frmF2 = null;
        private FlaskTimerCircleForm frmF3 = null;
        private FlaskTimerCircleForm frmF4 = null;
        private FlaskTimerCircleForm frmF5 = null;

        private FlaskICONTimer frmICONF1 = null;
        private FlaskICONTimer frmICONF2 = null;
        private FlaskICONTimer frmICONF3 = null;
        private FlaskICONTimer frmICONF4 = null;
        private FlaskICONTimer frmICONF5 = null;

        private SkillTimerForm frmSkillK1 = null;
        private SkillTimerForm frmSkillK2 = null;
        private SkillTimerForm frmSkillK3 = null;
        private SkillTimerForm frmSkillK4 = null;
        private SkillTimerForm frmSkillK5 = null;

        // FlaskIconImage Timer is Showing T/F
        public static bool bShowingfrmICONF1 { get; set; }
        public static bool bShowingfrmICONF2 { get; set; }
        public static bool bShowingfrmICONF3 { get; set; }
        public static bool bShowingfrmICONF4 { get; set; }
        public static bool bShowingfrmICONF5 { get; set; }

        // FlaskIconImage Timer is Showing T/F
        public static bool bShowingfrmSkillK1 { get; set; }
        public static bool bShowingfrmSkillK2 { get; set; }
        public static bool bShowingfrmSkillK3 { get; set; }
        public static bool bShowingfrmSkillK4 { get; set; }
        public static bool bShowingfrmSkillK5 { get; set; }
        #endregion

        #region [[[[[ Eventhandler ]]]]]
        private event EventHandler deadlyHideoutEvent;
        private event EventHandler deadlyRemainEvent;
        private event EventHandler deadlyJUNEvent;
        private event EventHandler deadlyALVAEvent;
        private event EventHandler deadlyZANAEvent;
        private event EventHandler deadlySearchPositionEvent;
        private event EventHandler deadlyEXITEvent;

        private event EventHandler ClipboardParsingEvent;

        // HOOK
        //GlobalLowLevelHooks.MouseHook mouseHook = new GlobalLowLevelHooks.MouseHook();
        //GlobalLowLevelHooks.KeyboardHook keyHook = new GlobalLowLevelHooks.KeyboardHook();
        private static IKeyboardMouseEvents _keymouseHooks;
        #endregion

        #region [[[[[ Trade Notification :: Trade Message ]]]]]
        private static DeadlyRegEx g_DeadlyRegEx = new DeadlyRegEx();
        public static List<DeadlyTRADE.TradeMSG> g_TradeMsgList = new List<DeadlyTRADE.TradeMSG>();
        public static int g_nNotificationShownCNT { get; set; }
        public static int g_nNotificationPanelShownCNT { get; set; }

        public static string g_LogFilePath { get; set; }
        #endregion

        private static UI_LANG g_nUILang;

        private string m_strClipboardText = null;
        private int m_InitCNT = 0;

        private bool m_bIsCMDVisible = false;
        private bool m_bISDND = false;

        public static bool gCF_bIsTextFocused { get; set; }

        //MapAlertForm frmMapModResult = null;
        private int nRegisterHotKeysCNT = 0;

        public ControlForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";

            Thread.Sleep(10);
            DeadlyLog4Net._log.Info("▶ DeadlyTrade Main Control Form Started");
            Init_Controls();
            Thread.Sleep(10);
            GetCurrencyCalcDictionary();
            Thread.Sleep(10);

            if (!Validate_POELogFile())
            {
                this.Close();
            }
            else
            {
                DeadlyZoneInform.InitActZoneDictionary();

                // Set Trade Message RegEx.
                Check_UILanguageWrapping();
                Set_TradeMessageRegEx();

                Thread.Sleep(100);
            }
        }

        public static Dictionary<string, double> CurrencyCalcDictionary = new Dictionary<string, double>();

        private void GetCurrencyCalcDictionary()
        {
            try
            {
                CurrencyCalcDictionary.Clear();
                string strItemName = String.Empty;
                foreach (var objLine in LauncherForm.ninjaData.Currency.Lines)
                {
                    if (LauncherForm.g_strUILang == "KOR")
                    {
                        if (NinjaTranslation.transCurrency.ContainsKey(objLine.CurrencyTypeName))
                            strItemName = NinjaTranslation.transCurrency[objLine.CurrencyTypeName];
                    }
                    else
                        strItemName = objLine.CurrencyTypeName;

                    CurrencyCalcDictionary.Add(strItemName, objLine.ChaosEquivalent);
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        #region ⨌⨌ Init. Controls. ⨌⨌
        public void Init_Controls()
        {
            //
            frmNotificationContainer.Top = 0;
            frmNotificationContainer.Left = 1000;
            //
            panelInit.Top = 0;
            panelInit.Left = 0;
            panelInit.Width = 241;
            panelInit.Height = 208;
            //
            btnDeadlyTrade.Width = 48;
            btnDeadlyTrade.Height = 48;
            //
            panelCOMMAND.Width = 226;
            panelCOMMAND.Height = 100;
            //
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.TabStop = false;
            //
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.TabStop = false;
            //
            button3.FlatStyle = FlatStyle.Flat;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.TabStop = false;
            //
            button4.FlatStyle = FlatStyle.Flat;
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.TabStop = false;
            //
            button5.FlatStyle = FlatStyle.Flat;
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button5.TabStop = false;
            //
            button6.FlatStyle = FlatStyle.Flat;
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button6.TabStop = false;
            //
            button9.FlatStyle = FlatStyle.Flat;
            button9.BackColor = Color.Transparent;
            button9.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button9.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button9.TabStop = false;
            //
            btnLOCK.FlatStyle = FlatStyle.Flat;
            btnLOCK.BackColor = Color.Transparent;
            btnLOCK.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLOCK.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLOCK.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnLOCK.FlatAppearance.BorderSize = 0;
            btnLOCK.TabStop = false;
            //
            btnDeadlyTrade.FlatStyle = FlatStyle.Flat;
            btnDeadlyTrade.BackColor = Color.Transparent;
            btnDeadlyTrade.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnDeadlyTrade.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnDeadlyTrade.TabStop = false;
        }
        #endregion

        private void ControlForm_Load(object sender, EventArgs e)
        {
            Text = "DeadlyTradeForPOE";

            panelDrag.Visible = false;
            panelInit.Visible = true;
            timerInit.Start();

            gCF_bIsTextFocused = false;

            Init_ControlFormPosition();

            Register_HotKeys();
            nRegisterHotKeysCNT = nRegisterHotKeysCNT + 1;

            if (!LauncherForm.g_pinLOCK)
            {
                btnLOCK.Image = Properties.Resources.icon_re_09_unlock;
                //panelDrag.Visible = false;
                panelDrag.BackgroundImage = Properties.Resources.moving_bar_unlock;
                LauncherForm.g_pinLOCK = false;
            }
            else
            {
                btnLOCK.Image = Properties.Resources.icon_re_09_lock;
                //panelDrag.Visible = true;
                panelDrag.BackgroundImage = Properties.Resources.moving_bar_lock;
                LauncherForm.g_pinLOCK = true;
            }

            // Removed 2019.08.13 Load_MiscForms();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;

            Set_FlaskTimerToggleSwitch();
            Set_SkillTimerToggleSwitch();

            #region [[[[[ Set EventHandler ]]]]]
            deadlyHideoutEvent += ControlForm_deadlyHideoutEvent;
            deadlyRemainEvent += ControlForm_deadlyRemainEvent;
            deadlyJUNEvent += ControlForm_deadlyJUNEvent;
            deadlyALVAEvent += ControlForm_deadlyALVAEvent;
            deadlyZANAEvent += ControlForm_deadlyZANAEvent;
            deadlySearchPositionEvent += ControlForm_deadlySearchPositionEvent;
            deadlyEXITEvent += ControlForm_deadlyEXITEvent;
            ClipboardParsingEvent += ControlForm_ClipboardParsingEvent;
            #endregion

            m_bISDND = false;
            g_bIsDropInformOn = false;
            g_bIsSCANOn = false;

            Text = "DeadlyTradeForPOE";
            frmNotificationContainer.Show();
        }

        private void CheckFocusLosing()
        {
            try
            {
                LauncherForm.g_handlePathOfExile = InteropCommon.FindWindow("POEWindowClass", "Path of Exile"); // ClassName = POEWindowClass

                string strActiveWindowTitle = InteropCommon.GetActiveWindowTitle();
                //!? CHKCHK string strActiveWindowParentTitle = InteropCommon.GetActiveWindowParentTitle();
                if (strActiveWindowTitle == "DeadlyTradeForPOE" || strActiveWindowTitle == "Path of Exile" || gCF_bIsTextFocused)
                    //!? CHKCHK strActiveWindowParentTitle == "DeadlyTradeForPOE" || strActiveWindowParentTitle == "Path of Exile" || gCF_bIsTextFocused)
                {
                    if (strActiveWindowTitle == "DeadlyTradeForPOE" || gCF_bIsTextFocused) //!? CHKCHK strActiveWindowParentTitle == "DeadlyTradeForPOE" || gCF_bIsTextFocused)
                    {
                        LauncherForm.g_FocusOnAddon = true;
                    }
                    else
                    {
                        LauncherForm.g_FocusOnAddon = false;

                        //TODO : WM_GETCURSOR GETCURSOR STATE
                    }

                    ShowHide_Addon_Forms(true);

                    // HOT KEYS
                    if (nRegisterHotKeysCNT <= 0)
                    {
                        Register_HotKeys();
                    }

                    LauncherForm.g_FocusLosing = false;
                }
                else
                {
                    LauncherForm.g_FocusLosing = true;
                    ShowHide_Addon_Forms(false);

                    // HOT KEYS
                    UnRegisterHotKeys();
                }

                if (bNeedtoShowAvailabeUpdate)
                    ShowAvailabeUpdatePanel();
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void MouseWheelThread(object sender, MouseEventExtArgs e)
        {
            MouseWheelExtDelegate delegateInstance =
                            new MouseWheelExtDelegate(MouseWheelExt);
            delegateInstance.BeginInvoke(sender, e, null, null);
        }
        private delegate void MouseWheelExtDelegate(object sender, MouseEventExtArgs e);

        private void _keymouseHooks_MouseWheelExt(object sender, MouseEventExtArgs e)
        {
            ThreadStartWithEvent(sender, e);
        }

        private Thread ThreadStartWithEvent(object sender, MouseEventExtArgs e)
        {
            Thread t = new Thread(() => MouseWheelThread(sender, e));
            t.Start();
            return t;
        }

        private void MouseWheelExt(object sender, MouseEventExtArgs e)
        {
            try
            {
                if (LauncherForm.g_FocusLosing || LauncherForm.g_FocusOnAddon)
                    return;

                InputSimulator iSim = new InputSimulator();

                if (InteropCommon.IsCtrlPressed())
                {
                    Point ptCur = InteropCommon.GetCursorPosition();
                    if (ptCur.X >= LauncherForm.g_nGridLeft && ptCur.X <= LauncherForm.g_nGridWidth)
                        return;
                    else
                    {
                        if (e.Delta > 0)
                        {
                            iSim.Keyboard.KeyDown(VirtualKeyCode.LEFT);
                            iSim.Keyboard.KeyUp(VirtualKeyCode.LEFT);
                        }
                        else
                        {
                            iSim.Keyboard.KeyDown(VirtualKeyCode.RIGHT);
                            iSim.Keyboard.KeyUp(VirtualKeyCode.RIGHT);
                        }
                        // SendKeys.SendWait("{LEFT}");//iSim.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                        //Thread.Sleep(50); // CHKCHKCHK
                    }
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                //Task.Factory.StartNew(() =>
            }
        }
        
        private void GetItemDataThread()
        {
            GetItemDataFromClipboardDelegate delegateInstance =
                            new GetItemDataFromClipboardDelegate(DeadlyPriceAPI.GetItemDataFromClipboard);
            delegateInstance.BeginInvoke(m_strClipboardText, null, null);
        }
        private delegate void GetItemDataFromClipboardDelegate(string strItemClipboardText);

        // KEY HOOK
        private void _keymouseHooks_KeyDown(object sender, WindowsHook.KeyEventArgs e)
        {
            // CTRL + C
            if (LauncherForm.g_FocusLosing && e.Modifiers == WindowsHook.Keys.Control && e.KeyCode == WindowsHook.Keys.C)
            {
                // is it trade whisper?
                DeadlyLog4Net._log.Info("CTRL+C for Trading");
                return;
            }
            else if (!LauncherForm.g_FocusLosing) // Only Exile Focused.
            {
                //? Test for Change HotKye Logic.
                //None = 0x0000,
                //Alt = 0x0001,
                //Control = 0x0002,
                //Shift = 0x0004,
                //Window = 0x0008,
                if(ovHRemains.fsMod == fsModifiers.None)
                {
                    if(e.KeyCode == (WindowsHook.Keys)ovHRemains.hotKeys)
                    {
                        deadlyRemainEvent(this, new EventArgs());
                    }
                }
                else
                {
                    ; //? TESTING.
                }

                if (e.Modifiers == WindowsHook.Keys.Control && e.KeyCode == WindowsHook.Keys.C)
                {

                }

                // CTRL + C
                if (e.Modifiers == WindowsHook.Keys.Control && e.KeyCode == WindowsHook.Keys.C)
                {
                    // is it price checking?
                    try
                    {
                        m_strClipboardText = ClipboardHelper.GetUnicodeText();
                        if (m_strClipboardText.Contains("--------"))
                        {
                            Thread t = new Thread(new ThreadStart(GetItemDataThread));
                            t.Start();
                        }
                        return;
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                        return;
                    }
                }
                // CTRL + V
                if (e.Modifiers == WindowsHook.Keys.Control && e.KeyCode == WindowsHook.Keys.V)
                {
                    #region ⨌⨌ for KAKAO Client : Handle BUYING MESSAGE ⨌⨌
                    try
                    {
                        if (LauncherForm.g_POELogFileName == "KakaoClient.txt") // CTRL+V in KAKAO Client.
                        {
                            m_strClipboardText = ClipboardHelper.GetUnicodeText();
                            if (m_strClipboardText != null && m_strClipboardText.Length > 0)
                            {
                                // for Debug DeadlyLog4Net._log.Debug("KAKAO User's CTRL+V for buy." + " : " + m_strClipboardText);
                                if (m_strClipboardText.ToUpper().Contains("BUY YOUR") || m_strClipboardText.ToUpper().Contains("구매하고") || m_strClipboardText.ToUpper().Contains("WTB"))
                                {
                                    ClipboardParsingEvent(this, new EventArgs());
                                    InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                                }
                            }
                            // TTTT MessageBox.Show(m_strClipboardText);
                            // bExistClipboard = true;

                            return;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                        return;
                    }
                    #endregion
                }

                #region ⨌⨌ Flask Timer ⨌⨌
                // FLASK 1
                if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Flask1.ToString()) && LauncherForm.g_bToggle1 && !LauncherForm.g_FocusOnAddon)
                {
                    /*try
                    {
                        FlaskTimerEvent1(this, new EventArgs()); //ControlForm_FlaskTimerEvent2(this, new EventArgs());
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }*/
                    try
                    {
                        /*if (LauncherForm.g_strFlaskType == "A")
                        {
                            if (frmF1 == null) { frmF1 = new FlaskTimerCircleForm(); }
                            frmF1.nFlaskNumber = 1;
                            frmF1.lnFlaskTimer = Convert.ToDouble(LauncherForm.g_FlaskTime1);
                            frmF1.Show();
                        }
                        else*/
                        if (!bShowingfrmICONF1) { frmICONF1 = new FlaskICONTimer(); }
                        frmICONF1.nFlaskNumber = 1;
                        frmICONF1.strUseAlertSound = LauncherForm.g_strTimerSound1;
                        frmICONF1.lnFlaskTimer = Convert.ToDouble(LauncherForm.g_FlaskTime1);
                        bShowingfrmICONF1 = true;
                        frmICONF1.Show();
                        //Thread.Sleep(50);
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                // FLASK 2
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Flask2.ToString()) && LauncherForm.g_bToggle2 && !LauncherForm.g_FocusOnAddon)
                {
                    /*try
                    {
                        FlaskTimerEvent2(this, new EventArgs()); //ControlForm_FlaskTimerEvent2(this, new EventArgs());
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }*/
                    try
                    {
                        if (!bShowingfrmICONF2) { frmICONF2 = new FlaskICONTimer(); }
                        frmICONF2.nFlaskNumber = 2;
                        frmICONF2.strUseAlertSound = LauncherForm.g_strTimerSound2;
                        frmICONF2.lnFlaskTimer = Convert.ToDouble(LauncherForm.g_FlaskTime2);
                        bShowingfrmICONF2 = true;
                        frmICONF2.Show();
                        //Thread.Sleep(50);
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                // FLASK 3
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Flask3.ToString()) && LauncherForm.g_bToggle3 && !LauncherForm.g_FocusOnAddon)
                {
                    /*try
                    {
                        FlaskTimerEvent3(this, new EventArgs()); //ControlForm_FlaskTimerEvent3(this, new EventArgs());
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }*/
                    try
                    {
                        if (!bShowingfrmICONF3) { frmICONF3 = new FlaskICONTimer(); }
                        frmICONF3.nFlaskNumber = 3;
                        frmICONF3.strUseAlertSound = LauncherForm.g_strTimerSound3;
                        frmICONF3.lnFlaskTimer = Convert.ToDouble(LauncherForm.g_FlaskTime3);
                        bShowingfrmICONF3 = true;
                        frmICONF3.Show();
                        //Thread.Sleep(50);
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                // FLASK 4
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Flask4.ToString()) && LauncherForm.g_bToggle4 && !LauncherForm.g_FocusOnAddon)
                {
                    /*try
                    {
                        FlaskTimerEvent4(this, new EventArgs()); //ControlForm_FlaskTimerEvent4(this, new EventArgs());
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }*/
                    try
                    {
                        if (!bShowingfrmICONF4) { frmICONF4 = new FlaskICONTimer(); }
                        frmICONF4.nFlaskNumber = 4;
                        frmICONF4.strUseAlertSound = LauncherForm.g_strTimerSound4;
                        frmICONF4.lnFlaskTimer = Convert.ToDouble(LauncherForm.g_FlaskTime4);
                        bShowingfrmICONF4 = true;
                        frmICONF4.Show();
                        //Thread.Sleep(50);
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                // FLASK 5
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Flask5.ToString()) && LauncherForm.g_bToggle5 && !LauncherForm.g_FocusOnAddon)
                {
                    /*try
                    {
                        FlaskTimerEvent5(this, new EventArgs()); //ControlForm_FlaskTimerEvent5(this, new EventArgs());
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }*/
                    try
                    {
                        if (!bShowingfrmICONF5) { frmICONF5 = new FlaskICONTimer(); }
                        frmICONF5.nFlaskNumber = 5;
                        frmICONF5.strUseAlertSound = LauncherForm.g_strTimerSound5;
                        frmICONF5.lnFlaskTimer = Convert.ToDouble(LauncherForm.g_FlaskTime5);
                        bShowingfrmICONF5 = true;
                        frmICONF5.Show();
                        //Thread.Sleep(50);
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                #endregion

                #region ⨌⨌ Skill Timer ⨌⨌
                // Skill Q
                if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Skill1.ToString()) && LauncherForm.g_bToggleSkill1 && !LauncherForm.g_FocusOnAddon)
                {
                    try
                    {
                        if (!bShowingfrmSkillK1) { frmSkillK1 = new SkillTimerForm(); }
                        frmSkillK1.nSkillNumber = 1;
                        frmSkillK1.lnSkillTimer = Convert.ToDouble(LauncherForm.g_SkillTime1);
                        bShowingfrmSkillK1 = true;
                        frmSkillK1.Show();
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }

                }
                // Skill W
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Skill2.ToString()) && LauncherForm.g_bToggleSkill2 && !LauncherForm.g_FocusOnAddon)
                {
                    try
                    {
                        if (!bShowingfrmSkillK2) { frmSkillK2 = new SkillTimerForm(); }
                        frmSkillK2.nSkillNumber = 2;
                        frmSkillK2.lnSkillTimer = Convert.ToDouble(LauncherForm.g_SkillTime2);
                        bShowingfrmSkillK2 = true;
                        frmSkillK2.Show();
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                // Skill E
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Skill3.ToString()) && LauncherForm.g_bToggleSkill3 && !LauncherForm.g_FocusOnAddon)
                {
                    try
                    {
                        if (!bShowingfrmSkillK3) { frmSkillK3 = new SkillTimerForm(); }
                        frmSkillK3.nSkillNumber = 3;
                        frmSkillK3.lnSkillTimer = Convert.ToDouble(LauncherForm.g_SkillTime3);
                        bShowingfrmSkillK3 = true;
                        frmSkillK3.Show();
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                // Skill R
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Skill4.ToString()) && LauncherForm.g_bToggleSkill4 && !LauncherForm.g_FocusOnAddon)
                {
                    try
                    {
                        if (!bShowingfrmSkillK4) { frmSkillK4 = new SkillTimerForm(); }
                        frmSkillK4.nSkillNumber = 4;
                        frmSkillK4.lnSkillTimer = Convert.ToDouble(LauncherForm.g_SkillTime4);
                        bShowingfrmSkillK4 = true;
                        frmSkillK4.Show();
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                // Skill T
                else if (e.KeyCode == (WindowsHook.Keys)Enum.Parse(typeof(WindowsHook.Keys), LauncherForm.g_Skill5.ToString()) && LauncherForm.g_bToggleSkill5 && !LauncherForm.g_FocusOnAddon)
                {
                    try
                    {
                        if (!bShowingfrmSkillK5) { frmSkillK5 = new SkillTimerForm(); }
                        frmSkillK5.nSkillNumber = 5;
                        frmSkillK5.lnSkillTimer = Convert.ToDouble(LauncherForm.g_SkillTime5);
                        bShowingfrmSkillK5 = true;
                        frmSkillK5.Show();
                        InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                    }
                    catch (InvalidOperationException ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }
                }
                #endregion
            }
        }

        #region [[[[[ TimerInit ]]]]]
        private void TimerInit_Tick(object sender, EventArgs e)
        {
            // Initializing... Waiting Image.
            m_InitCNT = m_InitCNT + 1;
            if (m_InitCNT > 10)
            {
                //labelDND.Visible = true;
                timerInit.Stop();
                timerInit.Dispose();

                Thread.Sleep(100);
                panelInit.Visible = false;
                panelDrag.Visible = true;

                _keymouseHooks = Hook.GlobalEvents();
                _keymouseHooks.KeyDown += _keymouseHooks_KeyDown;
                if (LauncherForm.g_strYNMouseWheelStashTab == "Y" && !Debugger.IsAttached)
                {
                    DeadlyLog4Net._log.Info("CTRL+MOUSEWHEEL : " + LauncherForm.g_strYNMouseWheelStashTab);
                    _keymouseHooks.MouseWheelExt += _keymouseHooks_MouseWheelExt;
                }

                // Start LOG Parsing UI Thread. 2020.01.13 Using baackground worker
                //DeadlyLOGParingTimer.Start();
                timerParser.Start();
            }
            else
            {
                // Moving MIYA
                switch (m_InitCNT)
                {
                    case 1:
                        pictureBoxMiya.Left = pictureBoxMiya.Left - 10;
                        pictureBoxMiya.Top = pictureBoxMiya.Top - 10;
                        break;
                    case 2:
                        pictureBoxMiya.Top = pictureBoxMiya.Top + 20;
                        break;
                    case 3:
                        pictureBoxMiya.Left = pictureBoxMiya.Left + 20;
                        break;
                    case 4:
                        pictureBoxMiya.Top = pictureBoxMiya.Top - 20;
                        break;
                    case 5:
                        pictureBoxMiya.Left = pictureBoxMiya.Left - 20;
                        break;
                    case 6:
                        pictureBoxMiya.Top = pictureBoxMiya.Top + 20;
                        break;
                    case 7:
                        pictureBoxMiya.Left = pictureBoxMiya.Left + 20;
                        break;
                    case 8:
                        pictureBoxMiya.Top = pictureBoxMiya.Top - 20;
                        break;
                    case 9:
                        pictureBoxMiya.Left = pictureBoxMiya.Left - 20;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void ControlForm_ClipboardParsingMapAlertEvent(object sender, EventArgs e)
        {
            return; // Temprorary Removed 1.3.9.0 Ver.
            /*if (frmMapModResult == null) { frmMapModResult = new MapAlertForm(); }
            frmMapModResult.m_strMapModString = m_strClipboardText;
            frmMapModResult.Show();

            m_strClipboardText = null;*/
        }

        #region ⨌⨌ Hot Key Events ⨌⨌
        private void ControlForm_deadlyEXITEvent(object sender, EventArgs e)
        {
            EXITtoCharacterSelcection();
        }

        //private void ControlForm_stashDownEvent(object sender, EventArgs e)
        //{
        //    // CTRL + →
        //    InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        //    SendKeys.Send("^{RIGHT}");

        //    //PostMessage(handlePOE, WM_KEYDOWN, WM_CTRL, 0);
        //    //PostMessage(handlePOE, WM_KEYDOWN, VK_RIGHT, 0);
        //    //PostMessage(handlePOE, WM_KEYUP, WM_CTRL, 0);
        //    //PostMessage(handlePOE, WM_KEYUP, VK_RIGHT, 0);
        //}

        //private void ControlForm_stashUpEvent(object sender, EventArgs e)
        //{
        //    // CTRL + ←
        //    InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        //    SendKeys.Send("^{LEFT}");

        //    ///*PostMessage(handlePOE, WM_KEYDOWN, WM_CTRL, 0);
        //    //PostMessage(handlePOE, 0x0111, VK_LEFT, 0);
        //    //PostMessage(handlePOE, WM_KEYUP, WM_CTRL, 0);
        //    //PostMessage(handlePOE, WM_KEYUP, VK_LEFT, 0);
        //}

        private void ControlForm_deadlyZANAEvent(object sender, EventArgs e)
        {
            if (!bIMGOvelayActivatedMAP)
                frmIMGOverlayMAP = new ImageOverlayFormMap();
            frmIMGOverlayMAP.m_strImagePath = strImagePath[2];
            frmIMGOverlayMAP.nZoom = 0;
            frmIMGOverlayMAP.Load_Image();
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_MAP);
        }

        private void ControlForm_deadlyALVAEvent(object sender, EventArgs e)
        {
            if (!bIMGOvelayActivatedALVA)
                frmIMGOverlayALVA = new ImageOverlayFormAlva();
            frmIMGOverlayALVA.m_strImagePath = strImagePath[1];
            frmIMGOverlayALVA.nZoom = 0;
            frmIMGOverlayALVA.Load_Image();
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_ALVA);
        }

        private void ControlForm_deadlyJUNEvent(object sender, EventArgs e)
        {
            /*if (!bIMGOvelayActivated)
                frmIMGOverlay = new DeadlySyndicateForm();*/ // RollBack to Image File Overlay 1.3.9.0 Ver.
            if (!bIMGOvelayActivated)
                frmIMGOverlay = new ImageOverlayForm();
            frmIMGOverlay.m_strImagePath = strImagePath[0];
            frmIMGOverlay.nZoom = 0;
            frmIMGOverlay.Load_Image();
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_JUN);
        }

        private void ControlForm_deadlyRemainEvent(object sender, EventArgs e)
        {
            Get_Remaining();
        }

        private void ControlForm_deadlyHideoutEvent(object sender, EventArgs e)
        {
            Go_HideOut();
        }

        private void ControlForm_deadlySearchPositionEvent(object sender, EventArgs e)
        {
            if (!g_bIsSearchPop)
            {
                frmSearchStash = new GuideGridForm();
                frmSearchStash.Owner = this;
                frmSearchStash.Show();

                g_bIsSearchPop = true;
            }
            else
            {
                frmSearchStash.Close();
                g_bIsSearchPop = false;
            }
        }
        #endregion

        #region [[[[[ Toggle Switch : Flask Timer & Skill Timer ]]]]]
        private void Set_SkillTimerToggleSwitch()
        {
            if (LauncherForm.g_bToggleSkill1)
                btnQ.Image = Properties.Resources.check_on;
            else
                btnQ.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggleSkill2)
                btnW.Image = Properties.Resources.check_on;
            else
                btnW.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggleSkill3)
                btnE.Image = Properties.Resources.check_on;
            else
                btnE.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggleSkill4)
                btnR.Image = Properties.Resources.check_on;
            else
                btnR.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggleSkill5)
                btnT.Image = Properties.Resources.check_on;
            else
                btnR.Image = Properties.Resources.check_off;
        }

        private void Set_FlaskTimerToggleSwitch()
        {
            if (LauncherForm.g_bToggle1)
                btn1.Image = Properties.Resources.check_on;
            else
                btn1.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggle2)
                btn2.Image = Properties.Resources.check_on;
            else
                btn2.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggle3)
                btn3.Image = Properties.Resources.check_on;
            else
                btn3.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggle4)
                btn4.Image = Properties.Resources.check_on;
            else
                btn4.Image = Properties.Resources.check_off;

            if (LauncherForm.g_bToggle5)
                btn5.Image = Properties.Resources.check_on;
            else
                btn5.Image = Properties.Resources.check_off;
        }
        #endregion

        private void ControlForm_ClipboardParsingEvent(object sender, EventArgs e)
        {
            // if contain buying message.
            Parse_ClipboardBuying();
        }

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

        #region ⨌⨌ Check and Set. Path of Exile Log File & Path ⨌⨌
        public bool Validate_POELogFile()
        {
            bool bRet = false;

            /* for Quest Helper ( Remove Temporary )
            if (!ReadDirectionHelperData())
                return bRet;
            */

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

            try
            {
                g_LogFilePath = parser.GetSetting("DIRECTIONHELPER", "POELOGPATH"); ;
                /*
                [LOCATION]
                LEFT=1385
                TOP=941
                ISMIN=N
                */
                string sLeft = parser.GetSetting("LOCATION", "LEFT");
                string sTop = parser.GetSetting("LOCATION", "TOP");
                string sMin = parser.GetSetting("LOCATION", "ISMIN");

                if (sLeft != "CENTER" && sTop != "CENTER")
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Left = Int32.Parse(sLeft);
                    this.Top = Int32.Parse(sTop);
                }             
            }
            catch(Exception ex)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read Addon configuration.\r\nFile seems to be corrupt or delete.";
                frmMSG.ShowDialog();
                bRet = false;

                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return bRet;
            }

            // C:\PROGRAM FÝLES (X86)\STEAM\STEAMAPPS\COMMON\PATH OF EXÝLE\LOGS\Client.TXT
            // C:\PROGRAM FİLES (X86)\STEAM\STEAMAPPS\COMMON\PATH OF EXİLE\LOGS\Client.TXT
            g_LogFilePath = g_LogFilePath.Replace("İ", "i");
            g_LogFilePath = g_LogFilePath.Replace("Ý", "i");

            g_LogFilePath = g_LogFilePath.Replace("FÝLES", "FILES");
            g_LogFilePath = g_LogFilePath.Replace("FLES", "FILES");
            g_LogFilePath = g_LogFilePath.Replace("EXÝLE", "EXILE");
            g_LogFilePath = g_LogFilePath.Replace("EXLE", "EXILE");
            g_LogFilePath = g_LogFilePath.Replace("CLÝNT", "Client");
            g_LogFilePath = g_LogFilePath.Replace("CLENT", "Client");

            if (File.Exists(g_LogFilePath))
            {
                try
                {
                    long lnFileSize = new FileInfo(g_LogFilePath).Length;
                    gln_LastRead = lnFileSize;
                }
                catch (Exception ex)
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "Unknown Error occured while reading POE log file.\r\n\r\nERROR : ( " + ex.Message + " )";
                    frmMSG.ShowDialog();
                    bRet = false;

                    DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    return bRet;
                }
            }
            else
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read POE log file.";
                frmMSG.ShowDialog();
                bRet = false;

                DeadlyLog4Net._log.Info("Found Path, But Not Exist Log File : " + g_LogFilePath);
                return bRet;
            }

            return true;
        }
        #endregion

        #region ⨌⨌ TRADE Regular Expression ⨌⨌
        private void Set_TradeMessageRegEx()
        {
            #region ⨌⨌  TRADE - English ⨌⨌
            g_DeadlyRegEx.RegExENGPriceWithTabName = new Regex("^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$");
            g_DeadlyRegEx.RegExENGPriceNoTabName = new Regex("^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$");
            g_DeadlyRegEx.RegExENGPoeAppCom = new Regex("^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$");
            g_DeadlyRegEx.RegExENGBulkCurrencies = new Regex("^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$");
            g_DeadlyRegEx.RegExENGCurrency = new Regex("^(.*\\s)?(.+): (.+ to buy your (\\d+(\\.\\d+)?)? (.+) for my (\\d+(\\.\\d+)?)? (.+) in (.*?)\\.\\s*(.*))$");
            g_DeadlyRegEx.RegExENGMapLiveSite = new Regex("^(.*\\s)?(.+): (I'd like to exchange my (T\\d+:\\s\\([\\s\\S,]+) for your (T\\d+:\\s\\([\\S,\\s]+) in\\s+?(.+?)\\.)");

            // BUY
            // ^@(.*\\s)?(.+) Hi, I (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$
            // Currency KAKAO Whisper Paste : ^@(.*\s)?(.+) Hi, (\s*)?(.+ to buy your (\d+(\.\d+)?)? (.+) for my (\d+(\.\d+)?)? (.+) in (.*?)\.\s*(.*))$
            g_DeadlyRegEx.RegExENGPriceWithTabNameKAKAO = new Regex("^@(.*\\s)?(.+) Hi, I (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$");
            g_DeadlyRegEx.RegExENGPriceNoTabNameKAKAO = new Regex("^@(.*\\s)?(.+) Hi, I (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$");
            g_DeadlyRegEx.RegExENGCurrencyKAKAO = new Regex("^@(.*\\s)?(.+) Hi, (\\s*)?(.+ to buy your (\\d+(\\.\\d+)?)? (.+) for my (\\d+(\\.\\d+)?)? (.+) in (.*?)\\.\\s*(.*))$");
            g_DeadlyRegEx.RegExENGMapLiveSiteKAKAO = new Regex("^@(.*\\s)?(.+) (I'd like to exchange my (T\\d+:\\s\\([\\s\\S,]+) for your (T\\d+:\\s\\([\\S,\\s]+) in\\s+?(.+?)\\.)");
            g_DeadlyRegEx.RegExENGPoeAppComTabNameKAKAO = 
                new Regex("^@(.*\\s)?(.+)?(.+)(\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\\\"(.*?)\\\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$");
            //new Regex("^@(.*\\s)?(.+)?(.+)(\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\\\"(.*?)\\\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$")
            #endregion

            #region ⨌⨌  TRADE - Korean ⨌⨌
            string a = "";
            g_DeadlyRegEx.RegExKORPriceWithTabName = new Regex("^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+?)\\(보관함 탭 \\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 (\\d+) (.*?)\\(으\\)로 올려놓은(.?\\s)(.+)\\(을\\)를 구매하고 싶습니다\\s*(.*)$");
            g_DeadlyRegEx.RegExKORPriceNoTabName = new Regex("NOT");
            g_DeadlyRegEx.RegExKORUnPrice = new Regex("^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 올려놓은 (.*?\\s*)을\\(를\\) 구매하고 싶습니다\\s*(.*)$");
            g_DeadlyRegEx.RegExKORBulkCurrencies = new Regex("NOT");
            g_DeadlyRegEx.RegExKORCurrency = new Regex("^(.*\\s)?(.+): 안녕하세요, (.*?)에 올려놓은(\\d) (\\s*)?(.+?)을\\(를\\) 제 (\\d+) (.*?)\\(으\\)로 구매하고 싶습니다\\s*(.*)$"); // @From TNDlowluck: 안녕하세요, Legion에 올려놓은7 톱니 화석을(를) 제 189 카오스 오브(으)로 구매하고 싶습니다  ^(.*\s)?(.+): 안녕하세요, (\s*)?(.+)(.*)에 올려놓은(\d+) (.*?\s*)을\(를\) 제 (\d+) 구매하고 싶습니다\s*(.*)$
            g_DeadlyRegEx.RegExKORMapLiveSite = new Regex("NOT");

            // BUY
            g_DeadlyRegEx.RegExKORPriceWithTabNameKAKAO = new Regex("^@(.*\\s)?(.+) 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 (\\d+) (.*?)\\(으\\)로 올려놓은(.?\\s)(.+)을\\(를\\) 구매하고 싶습니다\\s*(.*)$");
            g_DeadlyRegEx.RegExKORUnPriceKAKAO = new Regex("^@(.*\\s)?(.+) 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 올려놓은 (.*?\\s*)을\\(를\\) 구매하고 싶습니다\\s*(.*)$");

            #endregion
        }
        #endregion

        #region [[[[[ Show or Hide Addon's Forms by Condition ]]]]]
        private void ShowHide_Addon_Forms(bool bShow)
        {
            try
            {
                if (bShow)
                {
                    if (g_bIsSearchPop)
                        frmSearchStash.Show();

                    if (g_bIsSCANOn)
                        frmScanChat.Show();

                    if (bShowNinja)
                        frmNinja.Show();

                    if (bVoriciCalcFormViewing)
                        frmVoriciCalc.Show();

                    if (g_bIsDropInformOn)
                        frmMainForm.Show();

                    if (bfrmStashGridShow)
                        frmStashGrid.Show();

                    if (bIMGOvelayActivated)
                        frmIMGOverlay.Show();

                    if (bIMGOvelayActivatedALVA)
                        frmIMGOverlayALVA.Show();

                    if (bIMGOvelayActivatedMAP)
                        frmIMGOverlayMAP.Show();

                    if (bOilsFormON)
                        frmOils.Show();

                    if (bISearchRegionOn)
                        frmSearchRegion.Show();

                    if (g_bIsNofiticationContainerOn)
                        frmNotificationContainer.Show();

                    //if (bIsSettingsPop)

                    frmNotificationContainer.Show();
                    this.Show();
                }
                else
                {
                    if (g_bIsSearchPop)
                        frmSearchStash.Hide();

                    if (g_bIsSCANOn)
                        frmScanChat.Hide();

                    if (bShowNinja)
                        frmNinja.Hide();

                    if (bVoriciCalcFormViewing)
                        frmVoriciCalc.Hide();

                    if (g_bIsDropInformOn)
                        frmMainForm.Hide();

                    if (bfrmStashGridShow)
                        frmStashGrid.Hide();

                    if (bIMGOvelayActivated)
                        frmIMGOverlay.Hide();

                    if (bIMGOvelayActivatedALVA)
                        frmIMGOverlayALVA.Hide();

                    if (bIMGOvelayActivatedMAP)
                        frmIMGOverlayMAP.Hide();

                    if (bOilsFormON)
                        frmOils.Hide();

                    if (bISearchRegionOn)
                        frmSearchRegion.Hide();

                    if (g_bIsNofiticationContainerOn)
                        frmNotificationContainer.Hide();

                    //if (bIsSettingsPop)

                    frmNotificationContainer.Hide();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }
        #endregion

        private void ShowAvailabeUpdatePanel()
        {
            panelUpdateAvailable.Width = 200;
            panelUpdateAvailable.Height = 140;
            panelUpdateAvailable.Visible = true;
        }

        #region [[[[[ Whisper Message - Check and Notify : is this TradeWhisper? ]]]]]
        private bool WhisperCheck_ENGPriceWithTabName(string strTradePurpose, string readLineString)
        {
            try
            {
                Match mItemPriceWithTabName = g_DeadlyRegEx.RegExENGPriceWithTabName.Match(readLineString);
                DeadlyTRADE.TradeMSG tradeWhisper = new DeadlyTRADE.TradeMSG();
                if (mItemPriceWithTabName.Groups.Count > 9)
                {
                    tradeWhisper.tradePurpose = strTradePurpose;
                    tradeWhisper.fullMSG = mItemPriceWithTabName.Groups[3].Value;
                    tradeWhisper.league = mItemPriceWithTabName.Groups[8].Value;
                    tradeWhisper.nickName = mItemPriceWithTabName.Groups[2].Value;
                    tradeWhisper.itemName = mItemPriceWithTabName.Groups[4].Value;
                    if (mItemPriceWithTabName.Groups[6] != null)
                        tradeWhisper.priceCall = mItemPriceWithTabName.Groups[6].Value;
                    else
                        tradeWhisper.priceCall = "?";
                    if (mItemPriceWithTabName.Groups[7] != null)
                        tradeWhisper.whichCurrency = mItemPriceWithTabName.Groups[7].Value;
                    else
                        tradeWhisper.whichCurrency = "?";
                    if (mItemPriceWithTabName.Groups[9] != null)
                    {
                        tradeWhisper.tabName = mItemPriceWithTabName.Groups[9].Value;
                        tradeWhisper.xPos = mItemPriceWithTabName.Groups[10].Value;
                        tradeWhisper.yPos = mItemPriceWithTabName.Groups[11].Value;
                    }
                    if (mItemPriceWithTabName.Groups[12] != null)
                        tradeWhisper.offerMSG = mItemPriceWithTabName.Groups[12].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper)) return true;
                    g_TradeMsgList.Add(tradeWhisper);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisper = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool WhisperCheck_ENGCurrency(string strTradePurpose, string readLineString)
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisperCurr = new DeadlyTRADE.TradeMSG();
                Match mItemPriceNoTabName = g_DeadlyRegEx.RegExENGCurrency.Match(readLineString);
                if (mItemPriceNoTabName.Groups.Count > 9)
                {
                    tradeWhisperCurr.tradePurpose = strTradePurpose;
                    tradeWhisperCurr.fullMSG = mItemPriceNoTabName.Groups[3].Value;
                    tradeWhisperCurr.league = mItemPriceNoTabName.Groups[10].Value;
                    tradeWhisperCurr.nickName = mItemPriceNoTabName.Groups[2].Value;
                    if (mItemPriceNoTabName.Groups[4] != null)
                        tradeWhisperCurr.itemName = mItemPriceNoTabName.Groups[4].Value + " " + mItemPriceNoTabName.Groups[6].Value;
                    else
                        tradeWhisperCurr.itemName = mItemPriceNoTabName.Groups[6].Value;
                    if (mItemPriceNoTabName.Groups[7] != null)
                        tradeWhisperCurr.priceCall = mItemPriceNoTabName.Groups[7].Value;
                    else
                        tradeWhisperCurr.priceCall = "?";
                    if (mItemPriceNoTabName.Groups[9] != null)
                        tradeWhisperCurr.whichCurrency = mItemPriceNoTabName.Groups[9].Value;
                    else
                        tradeWhisperCurr.whichCurrency = "?";
                    //if (mItemPriceNoTabName.Groups[9] != null)
                    {
                        tradeWhisperCurr.tabName = "";// mItemPriceNoTabName.Groups[9].Value;
                        tradeWhisperCurr.xPos = "0";// mItemPriceNoTabName.Groups[10].Value;
                        tradeWhisperCurr.yPos = "0";// mItemPriceNoTabName.Groups[11].Value;
                    }
                    if (mItemPriceNoTabName.Groups[11] != null)
                        tradeWhisperCurr.offerMSG = mItemPriceNoTabName.Groups[11].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisperCurr.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisperCurr.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisperCurr)) return true;
                    g_TradeMsgList.Add(tradeWhisperCurr);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisperCurr = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool WhisperCheck_ENGPoeAppComWithTAB(string strTradePurpose, string readLineString)
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper2Un = new DeadlyTRADE.TradeMSG();
                Match mItemPriceWithTabName = g_DeadlyRegEx.RegExENGPoeAppCom.Match(readLineString);
                if (mItemPriceWithTabName.Groups.Count > 8)
                {
                    tradeWhisper2Un.tradePurpose = strTradePurpose;
                    tradeWhisper2Un.fullMSG = mItemPriceWithTabName.Groups[3].Value;
                    tradeWhisper2Un.league = mItemPriceWithTabName.Groups[8].Value;
                    tradeWhisper2Un.nickName = mItemPriceWithTabName.Groups[2].Value;
                    tradeWhisper2Un.itemName = mItemPriceWithTabName.Groups[4].Value;

                    if (mItemPriceWithTabName.Groups[6] != null)
                        tradeWhisper2Un.priceCall = mItemPriceWithTabName.Groups[6].Value;
                    else
                        tradeWhisper2Un.priceCall = "?";
                    if (mItemPriceWithTabName.Groups[7] != null)
                        tradeWhisper2Un.whichCurrency = mItemPriceWithTabName.Groups[7].Value;
                    else
                        tradeWhisper2Un.whichCurrency = "?";

                    if (mItemPriceWithTabName.Groups[9] != null)
                    {
                        tradeWhisper2Un.tabName = mItemPriceWithTabName.Groups[9].Value;
                        tradeWhisper2Un.xPos = mItemPriceWithTabName.Groups[10].Value;
                        tradeWhisper2Un.yPos = mItemPriceWithTabName.Groups[11].Value;
                    }
                    if (mItemPriceWithTabName.Groups[12] != null)
                        tradeWhisper2Un.offerMSG = mItemPriceWithTabName.Groups[12].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper2Un.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper2Un.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper2Un)) return true;
                    g_TradeMsgList.Add(tradeWhisper2Un);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisper2Un = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }
        private bool WhisperCheck_ENGPriceNoTabName(string strTradePurpose, string readLineString)
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper2 = new DeadlyTRADE.TradeMSG();
                Match mItemPriceNoTabName = g_DeadlyRegEx.RegExENGPriceNoTabName.Match(readLineString);
                if (mItemPriceNoTabName.Groups.Count > 7)
                {
                    tradeWhisper2.tradePurpose = strTradePurpose;
                    tradeWhisper2.fullMSG = mItemPriceNoTabName.Groups[3].Value;
                    tradeWhisper2.league = mItemPriceNoTabName.Groups[8].Value;
                    tradeWhisper2.nickName = mItemPriceNoTabName.Groups[2].Value;
                    tradeWhisper2.itemName = mItemPriceNoTabName.Groups[4].Value;
                    if (mItemPriceNoTabName.Groups[6] != null)
                        tradeWhisper2.priceCall = mItemPriceNoTabName.Groups[6].Value;
                    else
                        tradeWhisper2.priceCall = "?";
                    if (mItemPriceNoTabName.Groups[7] != null)
                        tradeWhisper2.whichCurrency = mItemPriceNoTabName.Groups[7].Value;
                    else
                        tradeWhisper2.whichCurrency = "?";
                    //if (mItemPriceNoTabName.Groups[9] != null)
                    {
                        tradeWhisper2.tabName = "";// mItemPriceNoTabName.Groups[9].Value;
                        tradeWhisper2.xPos = "0";// mItemPriceNoTabName.Groups[10].Value;
                        tradeWhisper2.yPos = "0";// mItemPriceNoTabName.Groups[11].Value;
                    }
                    // TO DO if (mItemPriceNoTabName.Groups[12] != null)
                    //    tradeWhisper2.offerMSG = mItemPriceNoTabName.Groups[12].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper2.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper2.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper2)) return true;
                    g_TradeMsgList.Add(tradeWhisper2);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisper2 = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }
        private bool WhisperCheck_KORPriceWIthTabName(string strTradePurpose, string readLineString)
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper3 = new DeadlyTRADE.TradeMSG();
                Match mItemPriceWithTabName = g_DeadlyRegEx.RegExKORPriceWithTabName.Match(readLineString);
                if (mItemPriceWithTabName.Groups.Count > 11)
                {
                    tradeWhisper3.tradePurpose = strTradePurpose;
                    tradeWhisper3.fullMSG = mItemPriceWithTabName.Groups[0].Value;
                    tradeWhisper3.league = mItemPriceWithTabName.Groups[4].Value;
                    tradeWhisper3.nickName = mItemPriceWithTabName.Groups[2].Value;
                    tradeWhisper3.itemName = mItemPriceWithTabName.Groups[12].Value;
                    if (mItemPriceWithTabName.Groups[9] != null)
                        tradeWhisper3.priceCall = mItemPriceWithTabName.Groups[9].Value;
                    else
                        tradeWhisper3.priceCall = "?";
                    if (mItemPriceWithTabName.Groups[10] != null)
                        tradeWhisper3.whichCurrency = mItemPriceWithTabName.Groups[10].Value;
                    else
                        tradeWhisper3.whichCurrency = "?";
                    if (mItemPriceWithTabName.Groups[6] != null)
                    {
                        tradeWhisper3.tabName = mItemPriceWithTabName.Groups[6].Value;
                        tradeWhisper3.xPos = mItemPriceWithTabName.Groups[7].Value;
                        tradeWhisper3.yPos = mItemPriceWithTabName.Groups[8].Value;
                    }
                    if (mItemPriceWithTabName.Groups[13] != null)
                        tradeWhisper3.offerMSG = mItemPriceWithTabName.Groups[13].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper3.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper3.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper3)) return true;
                    g_TradeMsgList.Add(tradeWhisper3);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisper3 = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }
        private bool WhisperCheck_KORUnPricewithTabName(string strTradePurpose, string readLineString)
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper4 = new DeadlyTRADE.TradeMSG();
                Match mItemPriceWithTabName = g_DeadlyRegEx.RegExKORUnPrice.Match(readLineString);
                if (mItemPriceWithTabName.Groups.Count > 8)
                {
                    tradeWhisper4.tradePurpose = strTradePurpose;
                    tradeWhisper4.fullMSG = mItemPriceWithTabName.Groups[0].Value;
                    tradeWhisper4.league = mItemPriceWithTabName.Groups[4].Value;
                    tradeWhisper4.nickName = mItemPriceWithTabName.Groups[2].Value;
                    tradeWhisper4.itemName = mItemPriceWithTabName.Groups[9].Value;
                    //if (mItemPriceWithTabName.Groups[9] != null)
                    //    tradeWhisper4.priceCall = mItemPriceWithTabName.Groups[9].Value;
                    //else
                    tradeWhisper4.priceCall = "?";
                    //if (mItemPriceWithTabName.Groups[10] != null)
                    //    tradeWhisper4.whichCurrency = mItemPriceWithTabName.Groups[10].Value;
                    //else
                    tradeWhisper4.whichCurrency = "?";
                    if (mItemPriceWithTabName.Groups[6] != null)
                    {
                        tradeWhisper4.tabName = mItemPriceWithTabName.Groups[6].Value;
                        tradeWhisper4.xPos = mItemPriceWithTabName.Groups[7].Value;
                        tradeWhisper4.yPos = mItemPriceWithTabName.Groups[8].Value;
                    }
                    if (mItemPriceWithTabName.Groups[10] != null)
                        tradeWhisper4.offerMSG = mItemPriceWithTabName.Groups[10].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper4.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper4.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper4)) return true;
                    g_TradeMsgList.Add(tradeWhisper4);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisper4 = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }
        private bool WhisperCheck_ENGMapLive(string strTradePurpose, string readLineString)
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisperENMAP = new DeadlyTRADE.TradeMSG();
                Match mItemPriceNoTabName = g_DeadlyRegEx.RegExENGMapLiveSite.Match(readLineString);
                if (mItemPriceNoTabName.Groups.Count > 5)
                {
                    tradeWhisperENMAP.tradePurpose = strTradePurpose;
                    tradeWhisperENMAP.fullMSG = mItemPriceNoTabName.Groups[3].Value;
                    tradeWhisperENMAP.league = mItemPriceNoTabName.Groups[6].Value;
                    tradeWhisperENMAP.nickName = mItemPriceNoTabName.Groups[2].Value;
                    tradeWhisperENMAP.itemName = mItemPriceNoTabName.Groups[5].Value;
                    // if (mItemPriceWithTabName.Groups[9] != null)
                    //    tradeWhisperENMAP.priceCall = mItemPriceWithTabName.Groups[9].Value;
                    //else
                    tradeWhisperENMAP.priceCall = "?";
                    //if (mItemPriceWithTabName.Groups[10] != null)
                    //    tradeWhisperENMAP.whichCurrency = mItemPriceWithTabName.Groups[10].Value;
                    //else
                    tradeWhisperENMAP.whichCurrency = "?";
                    //if (mItemPriceWithTabName.Groups[6] != null)
                    {
                        tradeWhisperENMAP.tabName = "";// mItemPriceWithTabName.Groups[6].Value;
                        tradeWhisperENMAP.xPos = "0";// mItemPriceWithTabName.Groups[7].Value;
                        tradeWhisperENMAP.yPos = "0";// mItemPriceWithTabName.Groups[8].Value;
                    }
                    if (mItemPriceNoTabName.Groups[4] != null)
                        tradeWhisperENMAP.offerMSG = mItemPriceNoTabName.Groups[4].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisperENMAP.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisperENMAP.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisperENMAP)) return true;
                    g_TradeMsgList.Add(tradeWhisperENMAP);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisperENMAP = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }
        private bool WhisperCheck_KORPriceNoTabName(string strTradePurpose, string readLineString)
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper2 = new DeadlyTRADE.TradeMSG();
                Match mItemPriceNoTabName = g_DeadlyRegEx.RegExKORPriceNoTabName.Match(readLineString);
                if (mItemPriceNoTabName.Groups.Count > 7)
                {
                    tradeWhisper2.tradePurpose = strTradePurpose;
                    tradeWhisper2.fullMSG = mItemPriceNoTabName.Groups[3].Value;
                    tradeWhisper2.league = mItemPriceNoTabName.Groups[8].Value;
                    tradeWhisper2.nickName = mItemPriceNoTabName.Groups[2].Value;
                    tradeWhisper2.itemName = mItemPriceNoTabName.Groups[4].Value;
                    if (mItemPriceNoTabName.Groups[6] != null)
                        tradeWhisper2.priceCall = mItemPriceNoTabName.Groups[6].Value;
                    else
                        tradeWhisper2.priceCall = "?";
                    if (mItemPriceNoTabName.Groups[7] != null)
                        tradeWhisper2.whichCurrency = mItemPriceNoTabName.Groups[7].Value;
                    else
                        tradeWhisper2.whichCurrency = "?";
                    //if (mItemPriceNoTabName.Groups[9] != null)
                    {
                        tradeWhisper2.tabName = "";// mItemPriceNoTabName.Groups[9].Value;
                        tradeWhisper2.xPos = "0";// mItemPriceNoTabName.Groups[10].Value;
                        tradeWhisper2.yPos = "0";// mItemPriceNoTabName.Groups[11].Value;
                    }
                    // TO DO if (mItemPriceNoTabName.Groups[12] != null)
                    //    tradeWhisper2.offerMSG = mItemPriceNoTabName.Groups[12].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper2.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper2.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper2)) return true;
                    g_TradeMsgList.Add(tradeWhisper2);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisper2 = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }
        private bool aa2(string strTradePurpose, string readLineString)
        {
            return false;
        }
        private bool aa3(string strTradePurpose, string readLineString)
        {
            return false;
        }
        #endregion

        private static long gln_LastRead = 0;

        private void TimerParser_Tick(object sender, EventArgs e)
        {
            CheckFocusLosing();

            /*if (m_strClipboardText != null && m_strClipboardText.Length > 0)
            {
                if (m_strClipboardText.ToUpper().Contains("MAP") || m_strClipboardText.ToUpper().Contains("지도"))
                {
                    if (!m_strClipboardText.ToUpper().Contains("BUY YOUR") && !m_strClipboardText.ToUpper().Contains("구매하고"))
                    {
                        ClipboardParsingMapAlertEvent(this, new EventArgs());
                        return;
                    }
                }
            }*/

            /////////////////////////////////////////////////////////////////////////
            // Threading with UI Thread Timer
            /////////////////////////////////////////////////////////////////////////

            if (gln_LastRead < 0)
            {
                gln_LastRead = 0;
            }

            try
            {
                var fileSize = new FileInfo(g_LogFilePath).Length;
                if (fileSize > gln_LastRead)
                {
                    using (var fs = new FileStream(g_LogFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fs.Seek(gln_LastRead, SeekOrigin.Begin);
                        var buffer = new byte[1024];

                        var bytesRead = fs.Read(buffer, 0, buffer.Length);
                        gln_LastRead += bytesRead;


                        var text = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        using (var reader = new StringReader(text))
                        {
                            for (string readLineString = reader.ReadLine(); readLineString != null; readLineString = reader.ReadLine())
                            {
                                //if (LauncherForm.g_handlePathOfExile != IntPtr.Zero)
                                {
                                    #region ⨌⨌ ZONE ⨌⨌
                                    Match mZone = null;
                                    if (g_nUILang == UI_LANG.UI_KOREAN)
                                        mZone = g_DeadlyRegEx.RegExZoneEnteredKOR.Match(readLineString);
                                    else
                                        mZone = g_DeadlyRegEx.RegExZoneEnteredENG.Match(readLineString);

                                    if (mZone.Success)
                                    {
                                        g_strZoneName = mZone.Groups[1].ToString();
                                        //button10.Text = g_strZoneName;
                                        // New zone has been entered.
                                        // this.Invoke((MethodInvoker)delegate ()
                                        //{
                                        //btnStashGrid.Text = mZone.Groups[1].ToString();
                                        //});

                                        if (frmMainForm != null)
                                        {
                                            frmMainForm.zoneName = g_strZoneName;
                                            if (!frmMainForm.partTwo)
                                                frmMainForm.DrawPartOneImage();
                                            else
                                                frmMainForm.DrawPartTwoImage();

                                            return;

                                            // if (frmZoneItem != null && g_bIsDropInformOn)
                                        }
                                    }
                                    #endregion

                                    #region ⨌⨌ Joined the Area ⨌⨌
                                    Match mJoined = null;
                                    if (g_nUILang == UI_LANG.UI_KOREAN)
                                        mJoined = g_DeadlyRegEx.RegExJoinedAreKOR.Match(readLineString);
                                    else
                                        mJoined = g_DeadlyRegEx.RegExJoinedAreENG.Match(readLineString);

                                    if (mJoined.Success)
                                    {
                                        if (g_strZoneName.ToUpper().Contains("HIDEOUT") || g_strZoneName.Contains("은신처"))
                                        {
                                            SomeOneEnteredForm frmJoined = new SomeOneEnteredForm();
                                            frmJoined.strNickName = mJoined.Groups[1].ToString();
                                            frmJoined.Show();

                                            return;
                                        }
                                    }

                                    #endregion

                                    #region ⨌⨌ MONSTERS ⨌⨌
                                    Match mRemains = null;
                                    if (g_nUILang == UI_LANG.UI_KOREAN)
                                        mRemains = g_DeadlyRegEx.RegExMonsterRemainsKOR.Match(readLineString);
                                    else
                                        mRemains = g_DeadlyRegEx.RegExMonsterRemainsENG.Match(readLineString);

                                    if (mRemains.Success)
                                    {
                                        string strRemains = "?";

                                        strRemains = mRemains.Groups[1].ToString();
                                        if (strRemains.Contains("More")) strRemains = "50+";
                                        if (strRemains.Contains("50개체")) strRemains = "50+";

                                        RemainingForm formMonster = new RemainingForm();
                                        formMonster.lbRemain.Text = strRemains;
                                        formMonster.Show();

                                        return;
                                    }

                                    Match mRemainsMore = null;
                                    if (g_nUILang == UI_LANG.UI_KOREAN)
                                        mRemainsMore = g_DeadlyRegEx.RegExMonsterRemainsKORMore.Match(readLineString);
                                    else
                                        mRemainsMore = g_DeadlyRegEx.RegExMonsterRemainsENGMore.Match(readLineString);

                                    if (mRemainsMore.Success)
                                    {
                                        string strRemainsMore = "50+";

                                        RemainingForm formMonster = new RemainingForm();
                                        formMonster.lbRemain.Text = strRemainsMore;
                                        formMonster.Show();

                                        return;
                                    }
                                    #endregion

                                    #region ⨌⨌ ### TRADE Parsing and Notify ### ⨌⨌

                                    #region ⨌⨌ Regular Expression ⨌⨌
                                    /*
                                    // ENG
                                    g_DeadlyRegEx.RegExENGPriceWithTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$";
                                    g_DeadlyRegEx.RegExENGPriceNoTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$";
                                    g_DeadlyRegEx.RegExENGPoeAppCom = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
                                    g_DeadlyRegEx.RegExENGBulkCurrencies = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
                                    g_DeadlyRegEx.RegExENGCurrency = "^(.*\\s)?(.+): (.+ to buy your (\\d+(\\.\\d+)?)? (.+) for my (\\d+(\\.\\d+)?)? (.+) in (.*?)\\.\\s*(.*))$";
                                    g_DeadlyRegEx.RegExENGMapLiveSite = "^(.*\\s)?(.+): (I'd like to exchange my (T\\d+:\\s\\([\\s\\S,]+) for your (T\\d+:\\s\\([\\S,\\s]+) in\\s+?(.+?)\\.)";
                                    // KOR
                                    g_DeadlyRegEx.RegExKORPriceWithTabName = "^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 (\\d+) (.*?)\\(으\\)로 올려놓은(.?\\s)(.+)을\\(를\\) 구매하고 싶습니다\\s*(.*)$";
                                    g_DeadlyRegEx.RegExKORPriceNoTabName = "NOT";
                                    g_DeadlyRegEx.RegExKORUnPrice = "^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 올려놓은 (.*?\\s*)을\\(를\\) 구매하고 싶습니다\\s*(.*)$";
                                    g_DeadlyRegEx.RegExKORBulkCurrencies = "NOT";
                                    g_DeadlyRegEx.RegExKORCurrency = "NOT";
                                    g_DeadlyRegEx.RegExKORMapLiveSite = "NOT";
                                    */
                                    #endregion

                                    #region ⨌⨌ TradeMSG Class Inform. ⨌⨌
                                    /*
                                    public string tradePurpose { get; set; } // 거래 목적 : 구매? 판매?
                                    public string nickName { get; set; } // 누가
                                    public string tabName { get; set; } // 어떤 보관함의
                                    public string xPos { get; set; } // 가로 좌표
                                    public string yPos { get; set; } // 세로 좌표
                                    public string itemName { get; set; } // 어떤 아이템을
                                    // 메시지 보낸 사람이 내는 가격
                                    public string priceCall { get; set; } // 얼마의 (요청자) :: 나의 170
                                    public string whichCurrency { get; set; } // 어떤 커런시로 (요청자) :: 나의 Chaos Orb 로
                                    // 추가 메시지
                                    public string offerMSG { get; set; } // 추가로 할말과 함께
                                    // 메시지 받는 사람에게 원하는 커런시
                                    public string priceYour { get; set; } // 대상자의 얼마를 :: 너의 1
                                    public string yourCurrency { get; set; } // 대상자의 어떤 커런시를 :: 너의 Exalted Orb 를

                                    
                                    // 구매, 판매 정보
                                    public string tradePurpose { get; set; } // 거래 목적 : 구매? 판매?

                                    // 기본 정보
                                    public string nickName { get; set; } // 누가
                                    public string tabName { get; set; } // 어떤 보관함의
                                    public string xPos { get; set; } // 가로 좌표
                                    public string yPos { get; set; } // 세로 좌표
                                    public string itemName { get; set; } // 어떤 아이템을

                                    // 메시지 보낸 사람이 내는 가격
                                    public string priceCall { get; set; } // 얼마의 (요청자) :: 나의 170
                                    public string whichCurrency { get; set; } // 어떤 커런시로 (요청자) :: 나의 Chaos Orb 로

                                    // 추가 메시지
                                    public string offerMSG { get; set; } // 추가로 할말과 함께

                                    // 메시지 받는 사람에게 원하는 커런시
                                    public string priceYour { get; set; } // 대상자의 얼마를 :: 너의 1
                                    public string yourCurrency { get; set; } // 대상자의 어떤 커런시를 :: 너의 Exalted Orb 를
                                    */
                                    #endregion

                                    string strTradePurpose = null;
                                    if (readLineString.Contains("@To") || readLineString.Contains("@발신"))
                                        strTradePurpose = "BUY"; // → Buy Message Handlling by Clipboard. for KAKAO Client.
                                    if (readLineString.Contains("@From") || readLineString.Contains("@수신"))
                                        strTradePurpose = "SELL";

                                    if (strTradePurpose != null && strTradePurpose != "")
                                    {
                                        if (WhisperCheck_ENGPriceWithTabName(strTradePurpose, readLineString))
                                            return;

                                        if (WhisperCheck_ENGCurrency(strTradePurpose, readLineString))
                                            return;

                                        if (WhisperCheck_ENGPoeAppComWithTAB(strTradePurpose, readLineString))
                                            return;

                                        if (WhisperCheck_ENGPriceNoTabName(strTradePurpose, readLineString))
                                            return;

                                        if (WhisperCheck_KORPriceWIthTabName(strTradePurpose, readLineString))
                                            return;

                                        if (WhisperCheck_KORUnPricewithTabName(strTradePurpose, readLineString))
                                            return;

                                        if (WhisperCheck_ENGMapLive(strTradePurpose, readLineString))
                                            return;

                                        if (WhisperCheck_KORPriceNoTabName(strTradePurpose, readLineString))
                                            return;
                                    }
                                    #endregion

                                    #region ⨌⨌ SCAN : Trade Chat ⨌⨌
                                    if (g_bIsSCANOn)
                                    {
                                        Match mTradeChat = null;
                                        mTradeChat = g_DeadlyRegEx.RegExChatTradeChannel.Match(readLineString);
                                        // new Regex(@"^(.*\\s)?(.+)\\$(.*\\s)?(.+): (.*)$"); // $DeadlyCrush: WTT T6 _ for maze // T7 _ for necro
                                        // Groups[4] = NickName
                                        // Groups[5] = Message
                                        if (mTradeChat.Success)
                                        {
                                            //m_strArrTradeChat
                                            if (frmScanChat != null && mTradeChat.Groups.Count > 4)
                                            {
                                                try
                                                {
                                                    frmScanChat.m_strNick = mTradeChat.Groups[4].ToString();
                                                    frmScanChat.m_strMessage = mTradeChat.Groups[5].ToString();
                                                    frmScanChat.CheckMatchedTradeChat();
                                                }
                                                catch (Exception ex)
                                                {
                                                    DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                                                }
                                            }

                                            return;
                                        }
                                    } // INGING TODOTODO
                                    #endregion
                                }
                            }

                            #region Ref. Customer JOIN or LEFT
                            // Check if customer joined or left
                            /*else if (customerJoinedRegEx.IsMatch(line))
                            {
                                MatchCollection matches = Regex.Matches(line, customerJoinedRegEx.ToString());

                                foreach (Match match in matches)
                                {
                                    foreach (TradeItemControl item in stk_MainPnl.Children)
                                    {
                                        if (item.tItem.Customer == match.Groups[1].Value)
                                        {
                                            item.CustomerJoined();
                                        }
                                    }
                                }
                            }

                            // Check if customer left
                            else if (customerLeftRegEx.IsMatch(line))
                            {
                                MatchCollection matches = Regex.Matches(line, customerLeftRegEx.ToString());

                                foreach (Match match in matches)
                                {
                                    foreach (TradeItemControl item in stk_MainPnl.Children)
                                    {
                                        if (item.tItem.Customer == match.Groups[1].Value)
                                        {
                                            item.CustomerLeft();
                                        }
                                    }
                                }
                            }*/
                            #endregion
                        }
                    }
                }

            }
            catch (FileNotFoundException fex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", fex);
                /*DeadlyLOGParingTimer.Tick -= DeadlyLOGParingTimer_Tick;*/
                MSGForm frmMSG2 = new MSGForm();
                frmMSG2.lbMsg.Text = "Parse :: Can't find POE log file. ‼‼‼\r\n\r\n( ERROR : " + fex.Message + ")";
                frmMSG2.ShowDialog();
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private bool Check_DuplicateTradeMSG(DeadlyTRADE.TradeMSG trMsg)
        {
            if (g_TradeMsgList.Count == 0)
                return false;

            bool bRet = false;

            foreach(var objtr in g_TradeMsgList)
            {
                if (trMsg.tradePurpose == objtr.tradePurpose
                    && trMsg.nickName == objtr.nickName
                    && trMsg.itemName == objtr.itemName
                    && trMsg.tabName == objtr.tabName
                    && trMsg.xPos == objtr.xPos
                    && trMsg.yPos == trMsg.yPos
                    && trMsg.priceCall == objtr.priceCall
                    && trMsg.priceYour == objtr.priceYour
                    && trMsg.whichCurrency == objtr.whichCurrency
                    && trMsg.yourCurrency == objtr.yourCurrency)
                    bRet = true;

                if (trMsg.fullMSG == objtr.fullMSG)
                    bRet = true;

                if (bRet)
                    break;
            }

            return bRet;
        }

        public static void Remove_TradeItem(string strID)
        {
            if (g_TradeMsgList.Count == 0)
                return;

            int nIndex = 0;
            foreach (var objtr in g_TradeMsgList)
            {
                if (objtr.id == strID)
                {
                    g_TradeMsgList.RemoveAt(nIndex);
                    break;
                }
                nIndex = nIndex + 1;
            }
        }

        private void ControlForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Ignore ENTER & ESCAPE
            if (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Escape)
                return;
        }

        private void ControlForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Ignore ENTER & ESCAPE
            if (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Escape)
                return;
        }

        #region ⨌⨌ WndProc ⨌⨌
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                if (!LauncherForm.g_FocusLosing && !bIsSettingsPop) // HOTKEY : 0x0312
                {
                    System.Windows.Forms.Keys keyHot = (System.Windows.Forms.Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    fsModifiers modifier = (fsModifiers)((int)m.LParam & 0xFFFF);

                    if (modifier == ovHRemains.fsMod && keyHot == ovHRemains.hotKeys && LauncherForm.g_strYNUseRemainingHOTKEY=="Y")
                    {
                        deadlyRemainEvent(this, new EventArgs());
                    }

                    if (modifier == ovHJUN.fsMod && keyHot == ovHJUN.hotKeys && LauncherForm.g_strYNUseSyndicateJUNHOTKEY == "Y")
                    {
                        deadlyJUNEvent(this, new EventArgs());
                    }

                    if (modifier == ovHALVA.fsMod && keyHot == ovHALVA.hotKeys && LauncherForm.g_strYNUseIncursionALVAHOTKEY == "Y")
                    {
                        deadlyALVAEvent(this, new EventArgs());
                    }

                    if (modifier == ovHZANA.fsMod && keyHot == ovHZANA.hotKeys && LauncherForm.g_strYNUseAtlasZANAHOTKEY == "Y")
                    {
                        deadlyZANAEvent(this, new EventArgs());
                    }

                    if (modifier == ovHHideout.fsMod && keyHot == ovHHideout.hotKeys && LauncherForm.g_strYNUseHideoutHOTKEY == "Y")
                    {
                        deadlyHideoutEvent(this, new EventArgs());
                    }

                    if (modifier == ovHSearchbyPosition.fsMod && keyHot == ovHSearchbyPosition.hotKeys && LauncherForm.g_strYNUseFindbyPositionHOTKEY == "Y")
                    {
                        deadlySearchPositionEvent(this, new EventArgs());
                    }

                    if (modifier == ovHEXIT.fsMod && keyHot == ovHEXIT.hotKeys && LauncherForm.g_strYNUseEmergencyHOTKEY == "Y")
                    {
                        deadlyEXITEvent(this, new EventArgs());
                    }
                }
            }
        }
        #endregion

        #region ⨌⨌ Set Regular Expression ⨌⨌

        #region Check ⨌⨌ UI Language and Set ZONE RegEx ⨌⨌
        public void Check_UILanguageWrapping()
        {
            g_nUILang = CheckPOEUILanguage();
            // TTTTT g_nUILang = UI_LANG.UI_KOREAN; // TTTTT

            /*
            // ZONE
            public Regex RegExZoneEnteredENG { get; set; } // new Regex(@"You have entered (.*)\.", RegexOptions.IgnoreCase);
            public Regex RegExZoneEnteredKOR { get; set; } // new Regex(@": (.*)에 진입했습니다.", RegexOptions.IgnoreCase);

            // MONSTER
            public Regex RegExMonsterRemainsENG { get; set; } // new Regex(@": (.*) monsters remain."); // : 3 monsters remain.
            public Regex RegExMonsterRemainsKOR { get; set; } // new Regex(@": 몬스터 (.*)개체가 남아있습니다."); // : 몬스터 0개체가 남아있습니다.
            public Regex RegExMonsterRemainsKORMore { get; set; } // : 몬스터가 (.*)개체 이상 남아있습니다.
            public Regex RegExMonsterRemainsENGMore { get; set; } // : More than 50 monsters remain.
            */
            if (g_nUILang == UI_LANG.UI_ERROR) // Can't Read UI Language from POE Config File
            {
                this.Close();
            }
            else
            {
                // ZONE
                g_DeadlyRegEx.RegExZoneEnteredENG = new Regex(@": You have entered (.*)\.", RegexOptions.IgnoreCase);
                g_DeadlyRegEx.RegExZoneEnteredKOR = new Regex(@": (.*)에 진입했습니다.", RegexOptions.IgnoreCase); // for Korean Client. ex) [INFO Client 14932] : 오아시스에 진입했습니다.

                // MONSTER
                g_DeadlyRegEx.RegExMonsterRemainsENG = new Regex(@": (.*) monsters remain."); // : 3 monsters remain.
                g_DeadlyRegEx.RegExMonsterRemainsENGMore = new Regex(@": More than (.*) monsters remain."); // : More than 50 monsters remain.
                g_DeadlyRegEx.RegExMonsterRemainsKOR = new Regex(@": 몬스터 (.*)개체가 남아있습니다."); // : 몬스터 0개체가 남아있습니다.
                g_DeadlyRegEx.RegExMonsterRemainsKORMore = new Regex(@": 몬스터가 (.*)개체 이상 남아있습니다."); // : 몬스터가 50개체 이상 남아있습니다.

                // Joined the area.
                g_DeadlyRegEx.RegExJoinedAreKOR = new Regex(@": (.*) has joined the area."); // : Ian_Curtis has joined the area.
                g_DeadlyRegEx.RegExJoinedAreENG = new Regex(@": (.*) has joined the area."); // : Ian_Curtis has joined the area.

                // Scan Trade Chat. ^(.*\s)?(.+)\$(.*\s)?(.+): (.*)$
                g_DeadlyRegEx.RegExChatTradeChannel = new Regex(@"^(.*\s)?(.+)\$(.*\s)?(.+): (.*)$"); // $DeadlyCrush: WTT T6 _ for maze // T7 _ for necro
            }
        }
        #endregion

        #endregion

        #region ⨌⨌ Check Language Setting in Path of Exile production_Config.ini ⨌⨌
        public UI_LANG CheckPOEUILanguage()
        {
            LauncherForm.g_strExplanationLANG = LauncherForm.g_strUILang;

            if (LauncherForm.g_strUILang == "KOR")
                return UI_LANG.UI_KOREAN;
            else if (LauncherForm.g_strUILang == "ENG")
                return UI_LANG.UI_ENGLISH;
            else
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.btmConfirm.Visible = false;
                frmMSG.btnENG.Visible = true;
                frmMSG.btnKOR.Visible = true;
                frmMSG.lbMsg.Text = "Can't find POE UI Configuration. What is your OPTION-UI Languge in POE?";
                DialogResult dr = frmMSG.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    LauncherForm.g_strUILang = "KOR";
                    LauncherForm.g_strExplanationLANG = LauncherForm.g_strUILang;

                    return UI_LANG.UI_KOREAN;
                }
                else
                {
                    LauncherForm.g_strUILang = "ENG";
                    LauncherForm.g_strExplanationLANG = LauncherForm.g_strUILang;

                    return UI_LANG.UI_ENGLISH;
                }
            }

            #region ⨌⨌ OLD CODE ⨌⨌
            /*String strPathPOEConifg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            strPathPOEConifg = strPathPOEConifg + "\\My Games\\Path of Exile\\production_Config.ini";
            IniParser parser = new IniParser(strPathPOEConifg);

            string strLanguage = "";
            try
            {
                strLanguage = parser.GetSetting("LANGUAGE", "language");


                if (strLanguage.Equals("ko-KR", StringComparison.OrdinalIgnoreCase))
                {
                    LauncherForm.g_strUILang = "KOR";
                    return UI_LANG.UI_KOREAN;
                }
                else if (strLanguage.Equals("en", StringComparison.OrdinalIgnoreCase))
                {
                    LauncherForm.g_strUILang = "ENG";
                    return UI_LANG.UI_ENGLISH;
                }
                else
                {
                    // 언어 환경 설정 콤보박스를 한번도 건드리지 않은 사용자는 [LANGUAGE] 섹션이 없음
                    MSGForm frmMSG3 = new MSGForm();
                    frmMSG3.lbMsg.Text = "언어 설정을 확인할 수 없어서 한글로 인식합니다.\r\n옵션-UI-언어를 확인해주세요.\r\n\r\n게임 옵션에서 언어 변경 후 저장하시면\r\nPOE의 설정 파일에 기록됩니다.";
                    frmMSG3.ShowDialog();
                    LauncherForm.g_strUILang = "KOR";
                    return UI_LANG.UI_KOREAN;
                }
            }
            catch
            {
                // 언어 환경 설정 콤보박스를 한번도 건드리지 않은 사용자는 [LANGUAGE] 섹션이 없음 || 또는, PC방 사용자가 꺼져있는 컴을 켜고 처음 실행시켰을 때.
                MSGForm frmMSG3 = new MSGForm();
                frmMSG3.lbMsg.Text = "언어 설정을 확인할 수 없어서 한글로 인식합니다.\r\n옵션-UI-언어를 확인해주세요.\r\n\r\n게임 옵션에서 언어 변경 후 저장하시면\r\nPOE의 설정 파일에 기록됩니다.";
                frmMSG3.ShowDialog();
                LauncherForm.g_strUILang = "KOR";
                return UI_LANG.UI_KOREAN;
            }*/
            #endregion
        }
        #endregion

        #region ⨌⨌ Form Closed. - Dispose ⨌⨌
        private void ControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InteropCommon.UnregisterHotKey(Handle, 2);
            InteropCommon.UnregisterHotKey(Handle, 3);
            InteropCommon.UnregisterHotKey(Handle, 4);
            InteropCommon.UnregisterHotKey(Handle, 6);

            btnClose.Dispose();
            button1.Dispose();
            button2.Dispose();
            button3.Dispose();
            button4.Dispose();
            button5.Dispose();
            button6.Dispose();

            if (frmMainForm != null) frmMainForm.Dispose();
            if (frmIMGOverlay != null) frmIMGOverlay.Dispose();
            if (frmIMGOverlayALVA != null) frmIMGOverlayALVA.Dispose();
            if (frmIMGOverlayMAP != null) frmIMGOverlayMAP.Dispose();

            //mouseHook.MouseWheel -= MouseHook_MouseWheel;
            //mouseHook.Uninstall();

            //keyHook.KeyDown -= KeyHook_KeyDown;
            //keyHook.KeyUp -= KeyHook_KeyUp;
            //keyHook.Uninstall();

            _keymouseHooks.Dispose();

            if (frmNinja != null) frmNinja.Dispose();
            if (frmStashGrid != null) frmStashGrid.Dispose();

            if (g_TradeMsgList != null)
            {
                g_TradeMsgList.Clear();
                g_TradeMsgList = null;
            }

            if (frmICONF1 != null) frmICONF1.Dispose();
            if (frmICONF2 != null) frmICONF2.Dispose();
            if (frmICONF3 != null) frmICONF3.Dispose();
            if (frmICONF4 != null) frmICONF4.Dispose();
            if (frmICONF5 != null) frmICONF5.Dispose();

            if (frmF1 != null) frmF1.Dispose();
            if (frmF2 != null) frmF2.Dispose();
            if (frmF3 != null) frmF3.Dispose();
            if (frmF4 != null) frmF4.Dispose();
            if (frmF5 != null) frmF5.Dispose();

            if (frmSkillK1 != null) frmSkillK1.Dispose();
            if (frmSkillK2 != null) frmSkillK2.Dispose();
            if (frmSkillK3 != null) frmSkillK3.Dispose();
            if (frmSkillK4 != null) frmSkillK4.Dispose();
            if (frmSkillK5 != null) frmSkillK5.Dispose();

/*            if (frmZoneItem != null) frmZoneItem.Dispose()*/;

            // Stop Thread Timer
            /*if (DeadlyLOGParingTimer != null) DeadlyLOGParingTimer.Stop();*/
            if (timerParser != null) timerParser.Stop();

            if (frmNotificationContainer != null) frmNotificationContainer.Dispose();

            DeadlyLog4Net._log.Info("▶ DeadlyTrade Main Control Form Closed");
            Application.Exit();
        }
        #endregion

        #region ⨌⨌ Register / UnRegister Hot Keys ⨌⨌
        public void Register_HotKeys()
        {
            nRegisterHotKeysCNT = nRegisterHotKeysCNT + 1;
            bool bRetHOT = false;
            Parse_StringToHotKey(keyMAINRemains);
            //? TEST Change HotKey Logic bRetHOT = InteropCommon.RegisterHotKey(Handle, 2, (uint)m_unMod, (uint)m_HotKey);
            //if (!bRetHOT)
            //{
            //    /*MSGForm frmMSG = new MSGForm();
            //    if(LauncherForm.g_strUILang == "KOR")
            //        frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
            //    else
            //        frmMSG.lbMsg.Text = "Fail to register hotkey.\r\n\r\nBut, all the other function is properly.";
            //    frmMSG.ShowDialog();*/
            //    DeadlyLog4Net._log.Info("Fail to register hotkey.\r\nBut, all the other function is properly.: " + keyMAINRemains);
            //}
            ovHRemains.fsMod = m_unMod;
            ovHRemains.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyMAINJUN);
            bRetHOT = InteropCommon.RegisterHotKey(Handle, 3, (uint)m_unMod, (uint)m_HotKey);
            //if (!bRetHOT)
            //{
            //    /*MSGForm frmMSG = new MSGForm();
            //    if (LauncherForm.g_strUILang == "KOR")
            //        frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
            //    else
            //        frmMSG.lbMsg.Text = "Fail to register hotkey.\r\n\r\nBut, all the other function is properly.";
            //    frmMSG.ShowDialog();*/
            //    DeadlyLog4Net._log.Info("Fail to register hotkey.\r\nBut, all the other function is properly.: " + keyMAINJUN);
            //}
            ovHJUN.fsMod = m_unMod;
            ovHJUN.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyMAINALVA);
            bRetHOT = InteropCommon.RegisterHotKey(Handle, 4, (uint)m_unMod, (uint)m_HotKey);
            //if (!bRetHOT)
            //{
            //    /*MSGForm frmMSG = new MSGForm();
            //    if (LauncherForm.g_strUILang == "KOR")
            //        frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
            //    else
            //        frmMSG.lbMsg.Text = "Fail to register hotkey.\r\n\r\nBut, all the other function is properly.";
            //    frmMSG.ShowDialog();*/
            //    DeadlyLog4Net._log.Info("Fail to register hotkey.\r\nBut, all the other function is properly.: " + keyMAINALVA);
            //}
            ovHALVA.fsMod = m_unMod;
            ovHALVA.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyMAINZANA);
            bRetHOT = InteropCommon.RegisterHotKey(Handle, 5, (uint)m_unMod, (uint)m_HotKey);
            //if (!bRetHOT)
            //{
            //    /*MSGForm frmMSG = new MSGForm();
            //    if (LauncherForm.g_strUILang == "KOR")
            //        frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
            //    else
            //        frmMSG.lbMsg.Text = "Fail to register hotkey.\r\n\r\nBut, all the other function is properly.";
            //    frmMSG.ShowDialog();*/
            //    DeadlyLog4Net._log.Info("Fail to register hotkey.\r\nBut, all the other function is properly.: " + keyMAINZANA);
            //}
            ovHZANA.fsMod = m_unMod;
            ovHZANA.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyMAINHideout);
            bRetHOT = InteropCommon.RegisterHotKey(Handle, 6, (uint)m_unMod, (uint)m_HotKey);
            //if (!bRetHOT)
            //{
            //    /*DeadlyLog4Net._log.Info("Fail to register hotkey : Hideout");
            //    MSGForm frmMSG = new MSGForm();
            //    if (LauncherForm.g_strUILang == "KOR")
            //        frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
            //    else
            //        frmMSG.lbMsg.Text = "Fail to register hotkey.\r\n\r\nBut, all the other function is properly.";
            //    frmMSG.ShowDialog();*/
            //    DeadlyLog4Net._log.Info("Fail to register hotkey.\r\nBut, all the other function is properly.: " + keyMAINHideout);
            //}
            ovHHideout.fsMod = m_unMod;
            ovHHideout.hotKeys = m_HotKey;

            Parse_StringToHotKey(keySearchbyPosition);
            bRetHOT = InteropCommon.RegisterHotKey(Handle, 7, (uint)m_unMod, (uint)m_HotKey);
            //if (!bRetHOT)
            //{
            //    /*DeadlyLog4Net._log.Info("Fail to register hotkey : SearchbyPosition");
            //    MSGForm frmMSG = new MSGForm();
            //    if (LauncherForm.g_strUILang == "KOR")
            //        frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
            //    else
            //        frmMSG.lbMsg.Text = "Fail to register hotkey.\r\n\r\nBut, all the other function is properly.";
            //    frmMSG.ShowDialog();*/
            //    DeadlyLog4Net._log.Info("Fail to register hotkey.\r\nBut, all the other function is properly.: " + keySearchbyPosition);
            //}
            ovHSearchbyPosition.fsMod = m_unMod;
            ovHSearchbyPosition.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyEXIT);
            bRetHOT = InteropCommon.RegisterHotKey(Handle, 8, (uint)m_unMod, (uint)m_HotKey);
            //if (!bRetHOT)
            //{
            //    /*DeadlyLog4Net._log.Info("Fail to register hotkey : EXIT");
            //    MSGForm frmMSG = new MSGForm();
            //    if (LauncherForm.g_strUILang == "KOR")
            //        frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
            //    else
            //        frmMSG.lbMsg.Text = "Fail to register hotkey.\r\n\r\nBut, all the other function is properly.";
            //    frmMSG.ShowDialog();*/
            //    DeadlyLog4Net._log.Info("Fail to register hotkey.\r\nBut, all the other function is properly.: " + keyEXIT);
            //}
            ovHEXIT.fsMod = m_unMod;
            ovHEXIT.hotKeys = m_HotKey;
        }

        public void UnRegisterHotKeys()
        {
            InteropCommon.UnregisterHotKey(Handle, 2);
            InteropCommon.UnregisterHotKey(Handle, 3);
            InteropCommon.UnregisterHotKey(Handle, 4);
            InteropCommon.UnregisterHotKey(Handle, 5);
            InteropCommon.UnregisterHotKey(Handle, 6);
            InteropCommon.UnregisterHotKey(Handle, 7);
            InteropCommon.UnregisterHotKey(Handle, 8);

            nRegisterHotKeysCNT = nRegisterHotKeysCNT - 1;
        }

        public void Parse_StringToHotKey(string text)
        {
            try
            {
                fsModifiers Modifier = fsModifiers.None;
                System.Windows.Forms.Keys key = 0;

                bool HasControl = false;
                bool HasAlt = false;
                bool HasShift = false;

                string[] strRet;
                string[] separators = new string[] { ";" };
                strRet = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                switch (strRet[0].ToUpper())
                {
                    case "NONE":
                        break;
                    case "CONTROL":
                        HasControl = true;
                        break;
                    case "SHIFT":
                        HasShift = true;
                        break;
                    case "ALT":
                        HasAlt = true;
                        break;
                    default:
                        break;
                }

                if (HasControl) { Modifier |= fsModifiers.Control; }
                if (HasAlt) { Modifier |= fsModifiers.Alt; }
                if (HasShift) { Modifier |= fsModifiers.Shift; }

                //Get the last key in the shortcut
                System.Windows.Forms.KeysConverter keyconverter = new System.Windows.Forms.KeysConverter();

                // TO DO More.
                strRet[1] = strRet[1].Replace("SPACE", "Space");
                strRet[1] = strRet[1].Replace("CAPITAL", "Capital");
                strRet[1] = strRet[1].Replace("NUMPAD", "NumPad");

                key = (System.Windows.Forms.Keys)keyconverter.ConvertFrom(strRet[1]);

                m_HotKey = key;
                m_unMod = Modifier;
            }
            catch(Exception ex)
            {
                DeadlyLog4Net._log.Error($"Fail to set hotkey {MethodBase.GetCurrentMethod().Name}", ex);
                MSGForm frmMSG = new MSGForm();
                if (LauncherForm.g_strUILang == "KOR")
                    frmMSG.lbMsg.Text = "단축키 설정에 오류가 있습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
                else
                    frmMSG.lbMsg.Text = "Fail to set hotkey.\r\n\r\nBut, all the other function is properly.";
                frmMSG.ShowDialog();
            }
        }
        #endregion

        #region ⨌⨌ Remaining Hotkey : Send Text to POE ⨌⨌
        public void Get_Remaining()
        {
            /*IntPtr hIMC = ImmGetContext(handlePOE);
            
            // Force to English
            ImmSetConversionStatus(hIMC, IME_CMODE_ALPHANUMERIC, 0);
            SendKeys.Send("{Enter}/remaining{Enter}");
            ImmReleaseContext(handlePOE, hIMC);
            */
            InputSimulator iSim = new InputSimulator();
            
            // Need to press ALT because the SetForegroundWindow sometimes does not work
            //iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/remaining");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        }
        #endregion

        #region ⨌⨌ Hideout Hotkey : Send Text to POE ⨌⨌
        private void Button7_Click(object sender, EventArgs e)
        {
            Go_HideOut();
        }

        public void Go_HideOut()
        {
            InputSimulator iSim = new InputSimulator();

            // Need to press ALT because the SetForegroundWindow sometimes does not work
            // Removed 2019.0712 iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/hideout");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;
            Text = "DeadlyTradeForPOE";
        }
        #endregion

        #region ⨌⨌ Init. Form Location ⨌⨌
        public void Init_ControlFormPosition()
        {
            strImagePath[0] = @".\DeadlyInform\Betrayal.png";

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

            try
            {
                string sLeft = parser.GetSetting("LOCATIONMAIN", "LEFT");
                string sTop = parser.GetSetting("LOCATIONMAIN", "TOP");

                if (sLeft != "CENTER" && sTop != "CENTER")
                {
                    StartPosition = FormStartPosition.Manual;
                    Left = Int32.Parse(sLeft);
                    Top = Int32.Parse(sTop);
                }

                string strPath = "";
                strPath = parser.GetSetting("DIRECTIONHELPER", "POELOGPATH");

                // Get Image Path
                /*strImagePath[0] = parser.GetSetting("OVERLAY", "JUN"); // @".\DeadlyInform\Betrayal.png";   // JUN
                if(strImagePath[0]=="")
                    strImagePath[0] = @".\DeadlyInform\Betrayal.png";*/

                strImagePath[1] = parser.GetSetting("OVERLAY", "ALVA"); // @".\DeadlyInform\Incursion.png";  // ALVA
                if (strImagePath[1] == "")
                    strImagePath[1] = @".\DeadlyInform\Incursion.png";

                strImagePath[2] = parser.GetSetting("OVERLAY", "ZANA"); // @".\DeadlyInform\Atlas.png";      // ZANA
                if (strImagePath[2] == "")
                    strImagePath[2] = @".\DeadlyInform\Atlas.png";

                // HOT KEYS
                keyMAINRemains = parser.GetSetting("HOTKEY", "R");
                keyMAINJUN = parser.GetSetting("HOTKEY", "J");
                keyMAINALVA = parser.GetSetting("HOTKEY", "A");
                keyMAINZANA = parser.GetSetting("HOTKEY", "Z");
                keyMAINHideout = parser.GetSetting("HOTKEY", "H");
                keySearchbyPosition = parser.GetSetting("HOTKEY", "F");
                keyEXIT = parser.GetSetting("HOTKEY", "E");

                strPath = strPath.Replace("İ", "i");
                strPath = strPath.Replace("Ý", "i");

                strPath = strPath.Replace("FÝLES", "FILES");
                strPath = strPath.Replace("FLES", "FILES");
                strPath = strPath.Replace("EXÝLE", "EXILE");
                strPath = strPath.Replace("EXLE", "EXILE");
                strPath = strPath.Replace("CLÝNT", "Client");
                strPath = strPath.Replace("CLENT", "Client");

                if (File.Exists(strPath))
                {
                    ;
                }
                else
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "Not recognize POE Path\r\nCheck your POE Path please.";
                    frmMSG.ShowDialog();
                    FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                    DialogResult dr = dlgFolder.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        DialogResult rsKakao = MessageBox.Show("카카오 클라이언트 유저이신가요?\r\nDo you use KAKAO Client?", "DeadlyCrush", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rsKakao == DialogResult.Yes)
                            strPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\KakaoClient.txt");
                        else
                            strPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\Client.txt");

                        // TTTTTTTTstrPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\TESTClient.txt"); 
                    }
                    else
                    {
                        this.Close();
                    }

                    // Set Ini.
                    parser.AddSetting("DIRECTIONHELPER", "POELOGPATH", strPath);
                    parser.SaveSettings();
                }
            }
            catch(Exception ex)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read configuration file.\r\n\r\nCheck ini file and try again.";
                frmMSG.ShowDialog();

                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                Close();
            }
        }
        #endregion

        #region ⨌⨌ QUEST, JUN, ALVA, ZANA Buttons Action ⨌⨌
        private void Button1_Click(object sender, EventArgs e)
        {
            // Quest Helper
            if (!g_bIsDropInformOn)
            {
                g_bIsDropInformOn = true;

                frmMainForm = new MainForm();
                frmMainForm.Show();
            }
            else
            {
                g_bIsDropInformOn = false;

                frmMainForm.Close();
            }
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            /*if (!bIMGOvelayActivated)
                frmIMGOverlay = new DeadlySyndicateForm();
            // JUN
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_JUN);*/ // Restore Image Overlay 1.3.9.0 Ver.
            if (!bIMGOvelayActivated)
                frmIMGOverlay = new ImageOverlayForm();
            // JUN
            frmIMGOverlay.m_strImagePath = strImagePath[0];
            frmIMGOverlay.nZoom = 0;
            frmIMGOverlay.Load_Image();
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_JUN);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!bIMGOvelayActivatedALVA)
                frmIMGOverlayALVA = new ImageOverlayFormAlva();
            // ALVA
            frmIMGOverlayALVA.m_strImagePath = strImagePath[1];
            frmIMGOverlayALVA.nZoom = 0;
            frmIMGOverlayALVA.Load_Image();
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_ALVA);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (!bIMGOvelayActivatedMAP)
                frmIMGOverlayMAP = new ImageOverlayFormMap();
            // ZANA
            frmIMGOverlayMAP.m_strImagePath = strImagePath[2];
            frmIMGOverlayMAP.nZoom = 0;
            frmIMGOverlayMAP.Load_Image();
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_MAP);
        }
        #endregion

        #region ⨌⨌ Check Ninja Price Form ⨌⨌
        private void Button5_Click(object sender, EventArgs e)
        {
            if (!bShowNinja)
            {
                frmNinja = new NinjaForm();
                bShowNinja = true;
                frmNinja.Show();
            }
            else
            {
                bShowNinja = false;
                frmNinja.Close();
            }
        }
        #endregion

        #region ⨌⨌ Settings Form ⨌⨌
        private void Button6_Click(object sender, EventArgs e)
        {
            bIsSettingsPop = true;
            gCF_bIsTextFocused = true;
            try
            {
                SettingsOverhaul settingsOverhaul = new SettingsOverhaul();
                settingsOverhaul.Show();
                return;
                using (SettingsForm frmSettings = new SettingsForm())
                {
                    frmSettings.keyRemains = keyMAINRemains;
                    frmSettings.keyJUN = keyMAINJUN;
                    frmSettings.keyALVA = keyMAINALVA;
                    frmSettings.keyZANA = keyMAINZANA;
                    frmSettings.keyHideout = keyMAINHideout; // hideout
                    frmSettings.keySearchbyPosition = keySearchbyPosition;
                    frmSettings.keyEXIT = keyEXIT;
                    if (frmSettings.ShowDialog() == DialogResult.OK)
                    {
                        keyMAINRemains = frmSettings.keyRemains;
                        keyMAINJUN = frmSettings.keyJUN;
                        keyMAINALVA = frmSettings.keyALVA;
                        keyMAINZANA = frmSettings.keyZANA;
                        keyMAINHideout = frmSettings.keyHideout;
                        keySearchbyPosition = frmSettings.keySearchbyPosition;
                        keyEXIT = frmSettings.keyEXIT;

                        UnRegisterHotKeys();

                        Register_HotKeys();
                        Thread.Sleep(200);

                        SaveNofiticationMsg(); //TODO: g_strCUSTOM1,2,3 Added.
                        Thread.Sleep(200);

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

                        parser.AddSetting("HOTKEY", "R", keyMAINRemains);
                        parser.AddSetting("HOTKEY", "J", keyMAINJUN);
                        parser.AddSetting("HOTKEY", "A", keyMAINALVA);
                        parser.AddSetting("HOTKEY", "Z", keyMAINZANA);
                        parser.AddSetting("HOTKEY", "H", keyMAINHideout);
                        parser.AddSetting("HOTKEY", "F", keySearchbyPosition);
                        parser.AddSetting("HOTKEY", "E", keyEXIT);

                        // FLASK COLOR
                        parser.AddSetting("MISC", "FLASK1COLOR", frmSettings.colorStringRGB1);
                        parser.AddSetting("MISC", "FLASK2COLOR", frmSettings.colorStringRGB2);
                        parser.AddSetting("MISC", "FLASK3COLOR", frmSettings.colorStringRGB3);
                        parser.AddSetting("MISC", "FLASK4COLOR", frmSettings.colorStringRGB4);
                        parser.AddSetting("MISC", "FLASK5COLOR", frmSettings.colorStringRGB5);
                        // FLASK TIMER
                        parser.AddSetting("MISC", "FLASKTIME1", LauncherForm.g_FlaskTime1);
                        parser.AddSetting("MISC", "FLASKTIME2", LauncherForm.g_FlaskTime2);
                        parser.AddSetting("MISC", "FLASKTIME3", LauncherForm.g_FlaskTime3);
                        parser.AddSetting("MISC", "FLASKTIME4", LauncherForm.g_FlaskTime4);
                        parser.AddSetting("MISC", "FLASKTIME5", LauncherForm.g_FlaskTime5);

                        // SKILL COLOR
                        parser.AddSetting("SKILL", "SKILL1COLOR", frmSettings.colorStringRGBQ);
                        parser.AddSetting("SKILL", "SKILL2COLOR", frmSettings.colorStringRGBW);
                        parser.AddSetting("SKILL", "SKILL3COLOR", frmSettings.colorStringRGBE);
                        parser.AddSetting("SKILL", "SKILL4COLOR", frmSettings.colorStringRGBR);
                        parser.AddSetting("SKILL", "SKILL5COLOR", frmSettings.colorStringRGBT);
                        // SKILL TIMER
                        parser.AddSetting("SKILL", "SKILLTIME1", LauncherForm.g_SkillTime1);
                        parser.AddSetting("SKILL", "SKILLTIME2", LauncherForm.g_SkillTime2);
                        parser.AddSetting("SKILL", "SKILLTIME3", LauncherForm.g_SkillTime3);
                        parser.AddSetting("SKILL", "SKILLTIME4", LauncherForm.g_SkillTime4);
                        parser.AddSetting("SKILL", "SKILLTIME5", LauncherForm.g_SkillTime5);

                        // My Character NickName and Trade Setting
                        parser.AddSetting("CHARACTER", "MYNICK", LauncherForm.g_strMyNickName);
                        parser.AddSetting("CHARACTER", "AUTOKICK", LauncherForm.g_strTRAutoKick);

                        //TODO : check box custom1,2,3 g_strTRAutoKickCustom1,2,3 - "CHARACTER", "AUTOKICK" Search All~!

                        // Notification Volume, Flask Timer Volume
                        parser.AddSetting("LOCATIONNOTIFY", "VOLUME", LauncherForm.g_NotifyVolume.ToString());
                        parser.AddSetting("LOCATIONNOTIFY", "VOLUMEFLASKTIMER", LauncherForm.g_FlaskTimerVolume.ToString());

                        // FLASK SOUND Y/N
                        parser.AddSetting("MISC", "FLASKSOUND1", LauncherForm.g_strTimerSound1);
                        parser.AddSetting("MISC", "FLASKSOUND2", LauncherForm.g_strTimerSound2);
                        parser.AddSetting("MISC", "FLASKSOUND3", LauncherForm.g_strTimerSound3);
                        parser.AddSetting("MISC", "FLASKSOUND4", LauncherForm.g_strTimerSound4);
                        parser.AddSetting("MISC", "FLASKSOUND5", LauncherForm.g_strTimerSound5);

                        // HotKey Use
                        parser.AddSetting("MISC", "HOTKEYHIDEOUT", LauncherForm.g_strYNUseHideoutHOTKEY);
                        parser.AddSetting("MISC", "EMERGENCY", LauncherForm.g_strYNUseEmergencyHOTKEY);
                        parser.AddSetting("MISC", "REMAINING", LauncherForm.g_strYNUseRemainingHOTKEY);
                        parser.AddSetting("MISC", "FINDBYPOSTION", LauncherForm.g_strYNUseFindbyPositionHOTKEY);
                        parser.AddSetting("MISC", "HOTKEYSYNDICATE", LauncherForm.g_strYNUseSyndicateJUNHOTKEY);
                        parser.AddSetting("MISC", "HOTKEYALVAINCURSION", LauncherForm.g_strYNUseIncursionALVAHOTKEY);
                        parser.AddSetting("MISC", "HOTKEYZANAATLAS", LauncherForm.g_strYNUseAtlasZANAHOTKEY);

                        parser.SaveSettings();
                        parser = null;

                        bIsSettingsPop = false;
                        gCF_bIsTextFocused = false;
                    }
                    else
                    {
                        bIsSettingsPop = false;
                        gCF_bIsTextFocused = false;
                    }
                }

                InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void SaveNofiticationMsg()
        {
            //TODO: g_strCUSTOM1,2,3 Added.

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            /*
            {
            "Id": "THX",
            "Msg": "Thanks. gl hf~. (감사합니다.)"
            },
            {
            "Id": "WAIT",
            "Msg": "Wait a sec pls."
            },
            {
            "Id": "WILLING",
            "Msg": "Still Willing to Buy?"
            },
            {
            "Id": "SOLD",
            "Msg": "Sold already. sry."
            },
            */
            /*
            if (textBoxWait.Text.Length > 0)
                LauncherForm.g_strnotiWAIT = textBoxWait.Text;

            if (textBoxSold.Text.Length <= 0)
                LauncherForm.g_strnotiSOLD = textBoxSold.Text;

            if (textBoxDone.Text.Length <= 0)
                LauncherForm.g_strnotiDONE = textBoxDone.Text;

            if (textBoxResend.Text.Length <= 0)
                LauncherForm.g_strnotiRESEND = textBoxResend.Text;
            */
            //string output = String.Empty;
            //List<DeadlyAtlas.NotifyMSGCollection> NotifyMSG;

            //NotifyMSG = LauncherForm.deadlyInformationData.InformationMSG.NotifyMSG.Where(retval => retval.Id == "THX").ToList();
            //NotifyMSG[0].Msg = LauncherForm.g_strnotiDONE;

            List<DeadlyAtlas.NotifyMSGCollection> notiMSGUpdate = new List<DeadlyAtlas.NotifyMSGCollection>();
            foreach (var item in LauncherForm.deadlyInformationData.InformationMSG.NotifyMSG)
            {
                if (item.Id == "THX")
                    item.Msg = LauncherForm.g_strnotiDONE;
                else if (item.Id == "WAIT")
                    item.Msg = LauncherForm.g_strnotiWAIT;
                else if (item.Id == "WILLING")
                    item.Msg = LauncherForm.g_strnotiRESEND;
                else if (item.Id == "SOLD")
                    item.Msg = LauncherForm.g_strnotiSOLD;

                notiMSGUpdate.Add(item);
            }

            string output = JsonConvert.SerializeObject(notiMSGUpdate, Formatting.Indented);
            output = "{   \"NotifyMSG\": " + output + " }";
            File.WriteAllText(Application.StartupPath + "\\DeadlyInform\\NotificationMSG.json", output);
        }
        #endregion

        #region ⨌⨌ STASH GRID ⨌⨌
        private void Button9_Click(object sender, EventArgs e)
        {
            if (!bfrmStashGridShow)
            {
                frmStashGrid = new StashGrid();
                frmStashGrid.Owner = this;
                frmStashGrid.Show();

                bfrmStashGridShow = true;
            }
            else
            {
                frmStashGrid.Close();
                bfrmStashGridShow = false;
            }
            

        }
        #endregion

        #region ⨌⨌ Form moving by Top Click ⨌⨌
        /*private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

            if (LauncherForm.resolution_width < 1920  && LauncherForm.resolution_height < 1080)
            {
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                if (LauncherForm.resolution_width < 1600 && LauncherForm.resolution_height < 1024)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini"); 
            }
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATIONMAIN", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONMAIN", "TOP", this.Top.ToString());
            parser.SaveSettings();

            SetForegroundWindow(handlePOE);
        }*/
        private void PictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            /*Removed 1.3.9.1 if (e.Clicks > 1)
            {
                if (bIsMinimized == false)
                {
                    bIsMinimized = true;

                    Size = new Size(24, 22);

                    //this.btnClose.Hide();
                    //this.btnMinimize.Location = new Point(35, 0);
                    //btnMinimize.BackgroundImage = Properties.Resources.sysMaxPOEBg;
                }
                else
                {
                    bIsMinimized = false;

                    Size = new Size(170, 147);
                    //this.btnClose.Show();
                    //this.btnMinimize.Location = new Point(295, 0);
                    //btnMinimize.BackgroundImage = Properties.Resources.sysMinPOEBg1;
                }
            }
            else*/
            //{
            if (!LauncherForm.g_pinLOCK)
            {
                nMoving = 1;
                nMovePosX = e.X;
                nMovePosY = e.Y;
            }
            //}
        }

        private void PictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void PictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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

            parser.AddSetting("LOCATIONMAIN", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONMAIN", "TOP", this.Top.ToString());
            parser.SaveSettings();

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        }
        #endregion

        #region ⨌⨌ Image Overlay Show/Hide ⨌⨌
        public void IMGOverlayForm_Show_Hide(int nWhat)
        {
            switch (nWhat)
            {
                case (int)OVERLAY_WHAT.OVER_JUN:
                    if (!bIMGOvelayActivated)
                    {
                        bIMGOvelayActivated = true;
                        frmIMGOverlay.Show();
                    }
                    else
                    {
                        bIMGOvelayActivated = false;
                        frmIMGOverlay.Close();
                    }
                    break;
                case (int)OVERLAY_WHAT.OVER_ALVA:
                    if (!bIMGOvelayActivatedALVA)
                    {
                        bIMGOvelayActivatedALVA = true;
                        frmIMGOverlayALVA.Show();
                    }
                    else
                    {
                        bIMGOvelayActivatedALVA = false;
                        frmIMGOverlayALVA.Close();
                    }
                    break;
                case (int)OVERLAY_WHAT.OVER_MAP:
                    if (!bIMGOvelayActivatedMAP)
                    {
                        bIMGOvelayActivatedMAP = true;
                        frmIMGOverlayMAP.Show();
                    }
                    else
                    {
                        bIMGOvelayActivatedMAP = false;
                        frmIMGOverlayMAP.Close();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ⨌⨌ (Like) Form System Button : Min,Max,Close ⨌⨌
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            return; // REMOVED
            /*if (bIsMinimized == false)
            {
                bIsMinimized = true;

                Size = new Size(115, 66);

                //this.btnClose.Hide();
                //this.btnMinimize.Location = new Point(35, 0);
                btnMinimize.BackgroundImage = Properties.Resources.sysMaxPOEBg;
            }
            else
            {
                bIsMinimized = false;

                Size = new Size(115, 178);
                //this.btnClose.Show();
                //this.btnMinimize.Location = new Point(295, 0);
                btnMinimize.BackgroundImage = Properties.Resources.sysMinPOEBg1;
            }
            SetForegroundWindow(handlePOE);*/
        }
        #endregion

        #region ⨌⨌ for TEST ⨌⨌
        private void Button8_Click(object sender, EventArgs e)
        {
            NotificationForm frmSelling = new NotificationForm();
            frmSelling.ShowDialog();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            // StashGrid ttt = new StashGrid();
            // ttt.Show();

            //FlaskTimerCircleForm ttt2 = new FlaskTimerCircleForm();
            //ttt2.nFlaskNumber = 2;
            //ttt2.lnFlaskTimer = Convert.ToDouble(LauncherForm.g_FlaskTime2);
            //ttt2.Show();

            //DeadlySyndicateForm ttt3 = new DeadlySyndicateForm();
            //ttt3.Show();

            //ZoneItemsForm ttt4 = new ZoneItemsForm();
            //ttt4.strZoneName = "Dungeon";
            //ttt4.Show();

            // FlaskTransparentForm ttt5 = new FlaskTransparentForm();
            // ttt5.Show();
            List<DeadlyAtlas.NotifyMSGCollection> NotifyMSG =
                    LauncherForm.deadlyInformationData.InformationMSG.NotifyMSG.Where(retval => retval.Id == "THX").ToList();

            string strSendString = String.Format("@{0} {1}", "DeadlyCrush", NotifyMSG[0].Msg);
            MessageBox.Show(strSendString);
        }
        #endregion

        #region [[[[[ Clipboard Parsing - KAKAO User's BUYing whisper ]]]]]
        private bool KAKAOBUYwithTabName()
        {
            try
            {
                Match mMatch = g_DeadlyRegEx.RegExENGPriceWithTabNameKAKAO.Match(m_strClipboardText);
                DeadlyTRADE.TradeMSG tradeWhisper = new DeadlyTRADE.TradeMSG();
                if (mMatch.Groups.Count > 9)
                {
                    tradeWhisper.tradePurpose = "BUY";
                    tradeWhisper.fullMSG = mMatch.Groups[3].Value;
                    tradeWhisper.league = mMatch.Groups[8].Value;
                    tradeWhisper.nickName = mMatch.Groups[2].Value;
                    tradeWhisper.itemName = mMatch.Groups[4].Value;
                    if (mMatch.Groups[6] != null)
                        tradeWhisper.priceCall = mMatch.Groups[6].Value;
                    else
                        tradeWhisper.priceCall = "?";
                    if (mMatch.Groups[7] != null)
                        tradeWhisper.whichCurrency = mMatch.Groups[7].Value;
                    else
                        tradeWhisper.whichCurrency = "?";
                    if (mMatch.Groups[9] != null)
                    {
                        tradeWhisper.tabName = mMatch.Groups[9].Value;
                        tradeWhisper.xPos = mMatch.Groups[10].Value;
                        tradeWhisper.yPos = mMatch.Groups[11].Value;
                    }
                    if (mMatch.Groups[12] != null)
                        tradeWhisper.offerMSG = mMatch.Groups[12].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper)) return true;
                    g_TradeMsgList.Add(tradeWhisper);

                    NotificationForm frmNotifyPanel = new NotificationForm();
                    frmNotificationContainer.AddNotifyForm(frmNotifyPanel);

                    tradeWhisper = null;

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool KAKAOBUYCurrency()
        {
            try
            {
                Match mMatch = g_DeadlyRegEx.RegExENGCurrencyKAKAO.Match(m_strClipboardText);
                DeadlyTRADE.TradeMSG tradeWhisperCurr = new DeadlyTRADE.TradeMSG();
                if (mMatch.Groups.Count > 9)
                {
                    tradeWhisperCurr.tradePurpose = "BUY";
                    tradeWhisperCurr.fullMSG = mMatch.Groups[4].Value;
                    tradeWhisperCurr.league = mMatch.Groups[11].Value;
                    tradeWhisperCurr.nickName = mMatch.Groups[2].Value;
                    if (mMatch.Groups[5] != null)
                        tradeWhisperCurr.itemName = mMatch.Groups[5].Value + " " + mMatch.Groups[7].Value;
                    else
                        tradeWhisperCurr.itemName = mMatch.Groups[7].Value;
                    if (mMatch.Groups[8] != null)
                        tradeWhisperCurr.priceCall = mMatch.Groups[8].Value;
                    else
                        tradeWhisperCurr.priceCall = "?";
                    if (mMatch.Groups[10] != null)
                        tradeWhisperCurr.whichCurrency = mMatch.Groups[10].Value;
                    else
                        tradeWhisperCurr.whichCurrency = "?";
                    //if (mMatch.Groups[9] != null)
                    {
                        tradeWhisperCurr.tabName = "";// mMatch.Groups[9].Value;
                        tradeWhisperCurr.xPos = "0";// mMatch.Groups[10].Value;
                        tradeWhisperCurr.yPos = "0";// mMatch.Groups[11].Value;
                    }
                    if (mMatch.Groups[12] != null)
                        tradeWhisperCurr.offerMSG = mMatch.Groups[12].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisperCurr.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisperCurr.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisperCurr)) return true;
                    g_TradeMsgList.Add(tradeWhisperCurr);

                    NotificationForm frmNotifySell = new NotificationForm();
                    frmNotifySell.Owner = this;
                    frmNotifySell.Show();

                    tradeWhisperCurr = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool KAKAOBUYwithTabNamePoeAppCom()
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper2Un = new DeadlyTRADE.TradeMSG();
                Match mMatch = g_DeadlyRegEx.RegExENGPoeAppComTabNameKAKAO.Match(m_strClipboardText);
                if (mMatch.Groups.Count > 11)
                {
                    tradeWhisper2Un.tradePurpose = "BUY";
                    tradeWhisper2Un.fullMSG = mMatch.Groups[0].Value;
                    tradeWhisper2Un.league = mMatch.Groups[9].Value;
                    tradeWhisper2Un.nickName = mMatch.Groups[2].Value;
                    tradeWhisper2Un.itemName = mMatch.Groups[5].Value;

                    if (mMatch.Groups[7] != null)
                        tradeWhisper2Un.priceCall = mMatch.Groups[7].Value;
                    else
                        tradeWhisper2Un.priceCall = "?";
                    if (mMatch.Groups[8] != null)
                        tradeWhisper2Un.whichCurrency = mMatch.Groups[8].Value;
                    else
                        tradeWhisper2Un.whichCurrency = "?";

                    if (mMatch.Groups[10] != null)
                    {
                        tradeWhisper2Un.tabName = mMatch.Groups[10].Value;
                        tradeWhisper2Un.xPos = mMatch.Groups[11].Value;
                        tradeWhisper2Un.yPos = mMatch.Groups[12].Value;
                    }
                    if (mMatch.Groups[12] != null)
                        tradeWhisper2Un.offerMSG = mMatch.Groups[13].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper2Un.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper2Un.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper2Un)) return true;
                    g_TradeMsgList.Add(tradeWhisper2Un);

                    NotificationForm frmNotifySell = new NotificationForm();
                    frmNotifySell.Owner = this;
                    frmNotifySell.Show();

                    tradeWhisper2Un = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool KAKAOBUYENGPriceNoTabName()
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper2 = new DeadlyTRADE.TradeMSG();
                Match mMatch = g_DeadlyRegEx.RegExENGPriceNoTabNameKAKAO.Match(m_strClipboardText);
                if (mMatch.Groups.Count > 7)
                {
                    tradeWhisper2.tradePurpose = "BUY";
                    tradeWhisper2.fullMSG = mMatch.Groups[3].Value;
                    tradeWhisper2.league = mMatch.Groups[8].Value;
                    tradeWhisper2.nickName = mMatch.Groups[2].Value;
                    tradeWhisper2.itemName = mMatch.Groups[4].Value;
                    if (mMatch.Groups[6] != null)
                        tradeWhisper2.priceCall = mMatch.Groups[6].Value;
                    else
                        tradeWhisper2.priceCall = "?";
                    if (mMatch.Groups[7] != null)
                        tradeWhisper2.whichCurrency = mMatch.Groups[7].Value;
                    else
                        tradeWhisper2.whichCurrency = "?";
                    //if (mMatch.Groups[9] != null)
                    {
                        tradeWhisper2.tabName = "";// mMatch.Groups[9].Value;
                        tradeWhisper2.xPos = "0";// mMatch.Groups[10].Value;
                        tradeWhisper2.yPos = "0";// mMatch.Groups[11].Value;
                    }
                    // TO DO if (mMatch.Groups[12] != null)
                    //    tradeWhisper2.offerMSG = mMatch.Groups[12].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper2.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper2.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper2)) return true;
                    g_TradeMsgList.Add(tradeWhisper2);

                    NotificationForm frmNotifySell = new NotificationForm();
                    frmNotifySell.Owner = this;
                    frmNotifySell.Show();

                    tradeWhisper2 = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool KAKAOBUYKORPriceWIthTabName()
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper3 = new DeadlyTRADE.TradeMSG();
                Match mMatch = g_DeadlyRegEx.RegExKORPriceWithTabNameKAKAO.Match(m_strClipboardText);
                if (mMatch.Groups.Count > 11)
                {
                    tradeWhisper3.tradePurpose = "BUY";
                    tradeWhisper3.fullMSG = mMatch.Groups[0].Value;
                    tradeWhisper3.league = mMatch.Groups[4].Value;
                    tradeWhisper3.nickName = mMatch.Groups[2].Value;
                    tradeWhisper3.itemName = mMatch.Groups[12].Value;
                    if (mMatch.Groups[9] != null)
                        tradeWhisper3.priceCall = mMatch.Groups[9].Value;
                    else
                        tradeWhisper3.priceCall = "?";
                    if (mMatch.Groups[10] != null)
                        tradeWhisper3.whichCurrency = mMatch.Groups[10].Value;
                    else
                        tradeWhisper3.whichCurrency = "?";
                    if (mMatch.Groups[6] != null)
                    {
                        tradeWhisper3.tabName = mMatch.Groups[6].Value;
                        tradeWhisper3.xPos = mMatch.Groups[7].Value;
                        tradeWhisper3.yPos = mMatch.Groups[8].Value;
                    }
                    if (mMatch.Groups[13] != null)
                        tradeWhisper3.offerMSG = mMatch.Groups[13].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper3.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper3.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper3)) return true;
                    g_TradeMsgList.Add(tradeWhisper3);

                    NotificationForm frmNotifySell = new NotificationForm();
                    frmNotifySell.Owner = this;
                    frmNotifySell.Show();

                    tradeWhisper3 = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool KAKAOBUYKORUnPricewithTabName()
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisper4 = new DeadlyTRADE.TradeMSG();
                Match mMatch = g_DeadlyRegEx.RegExKORUnPriceKAKAO.Match(m_strClipboardText);
                if (mMatch.Groups.Count > 8)
                {
                    tradeWhisper4.tradePurpose = "BUY";
                    tradeWhisper4.fullMSG = mMatch.Groups[0].Value;
                    tradeWhisper4.league = mMatch.Groups[4].Value;
                    tradeWhisper4.nickName = mMatch.Groups[2].Value;
                    tradeWhisper4.itemName = mMatch.Groups[9].Value;
                    //if (mMatch.Groups[9] != null)
                    //    tradeWhisper4.priceCall = mMatch.Groups[9].Value;
                    //else
                    tradeWhisper4.priceCall = "?";
                    //if (mMatch.Groups[10] != null)
                    //    tradeWhisper4.whichCurrency = mMatch.Groups[10].Value;
                    //else
                    tradeWhisper4.whichCurrency = "?";
                    if (mMatch.Groups[6] != null)
                    {
                        tradeWhisper4.tabName = mMatch.Groups[6].Value;
                        tradeWhisper4.xPos = mMatch.Groups[7].Value;
                        tradeWhisper4.yPos = mMatch.Groups[8].Value;
                    }
                    if (mMatch.Groups[10] != null)
                        tradeWhisper4.offerMSG = mMatch.Groups[10].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisper4.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisper4.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisper4)) return true;
                    g_TradeMsgList.Add(tradeWhisper4);

                    NotificationForm frmNotifySell = new NotificationForm();
                    frmNotifySell.Owner = this;
                    frmNotifySell.Show();

                    tradeWhisper4 = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }

        private bool KAKAOBUYENGMapLiveSite()
        {
            try
            {
                DeadlyTRADE.TradeMSG tradeWhisperENMAP = new DeadlyTRADE.TradeMSG();
                Match mMatch = g_DeadlyRegEx.RegExENGMapLiveSiteKAKAO.Match(m_strClipboardText);
                if (mMatch.Groups.Count > 5)
                {
                    tradeWhisperENMAP.tradePurpose = "BUY";
                    tradeWhisperENMAP.fullMSG = mMatch.Groups[3].Value;
                    tradeWhisperENMAP.league = mMatch.Groups[6].Value;
                    tradeWhisperENMAP.nickName = mMatch.Groups[2].Value;
                    tradeWhisperENMAP.itemName = mMatch.Groups[5].Value;
                    // if (mMatch.Groups[9] != null)
                    //    tradeWhisperENMAP.priceCall = mMatch.Groups[9].Value;
                    //else
                    tradeWhisperENMAP.priceCall = "?";
                    //if (mMatch.Groups[10] != null)
                    //    tradeWhisperENMAP.whichCurrency = mMatch.Groups[10].Value;
                    //else
                    tradeWhisperENMAP.whichCurrency = "?";
                    //if (mMatch.Groups[6] != null)
                    {
                        tradeWhisperENMAP.tabName = "";// mMatch.Groups[6].Value;
                        tradeWhisperENMAP.xPos = "0";// mMatch.Groups[7].Value;
                        tradeWhisperENMAP.yPos = "0";// mMatch.Groups[8].Value;
                    }
                    if (mMatch.Groups[4] != null)
                        tradeWhisperENMAP.offerMSG = mMatch.Groups[4].Value;

                    g_nNotificationShownCNT = g_nNotificationShownCNT + 1;
                    tradeWhisperENMAP.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                    tradeWhisperENMAP.expanded = false;

                    if (Check_DuplicateTradeMSG(tradeWhisperENMAP)) return true;
                    g_TradeMsgList.Add(tradeWhisperENMAP);

                    NotificationForm frmNotifySell = new NotificationForm();
                    frmNotifySell.Owner = this;
                    frmNotifySell.Show();

                    tradeWhisperENMAP = null;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return false;
            }
        }
        #endregion

        private void Parse_ClipboardBuying()
        {
            if (m_strClipboardText.ToUpper().Contains("BUY YOUR")
                || m_strClipboardText.ToUpper().Contains("구매하고")
                || m_strClipboardText.ToUpper().Contains("WTB"))
            {
                #region ⨌⨌ ### for KAKAO BUYING Parsing and Notify ### ⨌⨌

                #region ⨌⨌ Regular Expression ⨌⨌
                /*
                // ENG
                g_DeadlyRegEx.RegExENGPriceWithTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$";
                g_DeadlyRegEx.RegExENGPriceNoTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$";
                g_DeadlyRegEx.RegExENGPoeAppCom = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
                g_DeadlyRegEx.RegExENGBulkCurrencies = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
                g_DeadlyRegEx.RegExENGCurrency = "^(.*\\s)?(.+): (.+ to buy your (\\d+(\\.\\d+)?)? (.+) for my (\\d+(\\.\\d+)?)? (.+) in (.*?)\\.\\s*(.*))$";
                g_DeadlyRegEx.RegExENGMapLiveSite = "^(.*\\s)?(.+): (I'd like to exchange my (T\\d+:\\s\\([\\s\\S,]+) for your (T\\d+:\\s\\([\\S,\\s]+) in\\s+?(.+?)\\.)";
                // KOR
                g_DeadlyRegEx.RegExKORPriceWithTabName = "^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 (\\d+) (.*?)\\(으\\)로 올려놓은(.?\\s)(.+)을\\(를\\) 구매하고 싶습니다\\s*(.*)$";
                g_DeadlyRegEx.RegExKORPriceNoTabName = "NOT";
                g_DeadlyRegEx.RegExKORUnPrice = "^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 올려놓은 (.*?\\s*)을\\(를\\) 구매하고 싶습니다\\s*(.*)$";
                g_DeadlyRegEx.RegExKORBulkCurrencies = "NOT";
                g_DeadlyRegEx.RegExKORCurrency = "NOT";
                g_DeadlyRegEx.RegExKORMapLiveSite = "NOT";
                */
                #endregion

                #region ⨌⨌ TradeMSG Class Inform. ⨌⨌
                /*
                public string tradePurpose { get; set; } // 거래 목적 : 구매? 판매?
                public string nickName { get; set; } // 누가
                public string tabName { get; set; } // 어떤 보관함의
                public string xPos { get; set; } // 가로 좌표
                public string yPos { get; set; } // 세로 좌표
                public string itemName { get; set; } // 어떤 아이템을
                // 메시지 보낸 사람이 내는 가격
                public string priceCall { get; set; } // 얼마의 (요청자) :: 나의 170
                public string whichCurrency { get; set; } // 어떤 커런시로 (요청자) :: 나의 Chaos Orb 로
                // 추가 메시지
                public string offerMSG { get; set; } // 추가로 할말과 함께
                // 메시지 받는 사람에게 원하는 커런시
                public string priceYour { get; set; } // 대상자의 얼마를 :: 너의 1
                public string yourCurrency { get; set; } // 대상자의 어떤 커런시를 :: 너의 Exalted Orb 를
                */
                #endregion

                // KAKAOBUYwithTabName
                if (KAKAOBUYwithTabName())
                    return;

                // KAKAOBUYCurrency
                if (KAKAOBUYCurrency())
                    return;

                // KAKAOBUYwithTabNamePoeAppCom
                if (KAKAOBUYwithTabNamePoeAppCom())
                    return;

                // KAKAOBUYENGPriceNoTabName
                if (KAKAOBUYENGPriceNoTabName())
                    return;

                // KAKAOBUYKORPriceWIthTabName
                if (KAKAOBUYKORPriceWIthTabName())
                    return;

                // KAKAOBUYKORUnPricewithTabName
                if (KAKAOBUYKORUnPricewithTabName())
                    return;

                // KAKAOBUYENGMapLiveSite
                if (KAKAOBUYENGMapLiveSite())
                    return;

                #endregion
            }
        }

        private void BtnLOCK_Click(object sender, EventArgs e)
        {
            string strLock = String.Empty;
            if(!LauncherForm.g_pinLOCK)
            {
                LauncherForm.g_pinLOCK = true;
                btnLOCK.Image = Properties.Resources.icon_re_09_lock;
                panelDrag.BackgroundImage = Properties.Resources.moving_bar_lock;
                strLock = "Y";

                //panelDrag.Visible = false;
            }
            else
            {
                LauncherForm.g_pinLOCK = false;
                btnLOCK.Image = Properties.Resources.icon_re_09_unlock;
                panelDrag.BackgroundImage = Properties.Resources.moving_bar_unlock;
                strLock = "N";

                //panelDrag.Visible = true;
            }

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

            parser.AddSetting("MISC", "PUSHPINLOCK", strLock);
            parser.SaveSettings();

            // SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        }

        private void BtnHideout_Click(object sender, EventArgs e)
        {
            Go_HideOut();
        }

        private void BtnSearchStash_Click(object sender, EventArgs e)
        {
            if (!g_bIsSearchPop)
            {
                frmSearchStash = new GuideGridForm();
                frmSearchStash.Owner = this;
                frmSearchStash.Show();

                g_bIsSearchPop = true;
            }
            else
            {
                frmSearchStash.Close();
                g_bIsSearchPop = false;
            }
        }

        #region ⨌⨌ Flask Switch ⨌⨌

        private void XuiSwitch1_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggle1)
            {
                LauncherForm.g_bToggle1 = true;
                btn1.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggle1 = false;
                btn1.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("MISC", "TOGGLE1ON", LauncherForm.g_bToggle1.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitch2_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggle2)
            {
                LauncherForm.g_bToggle2 = true;
                btn2.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggle2 = false;
                btn2.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("MISC", "TOGGLE2ON", LauncherForm.g_bToggle2.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitch3_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggle3)
            {
                LauncherForm.g_bToggle3 = true;
                btn3.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggle3 = false;
                btn3.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("MISC", "TOGGLE3ON", LauncherForm.g_bToggle3.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitch4_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggle4)
            {
                LauncherForm.g_bToggle4 = true;
                btn4.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggle4 = false;
                btn4.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("MISC", "TOGGLE4ON", LauncherForm.g_bToggle4.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitch5_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggle5)
            {
                LauncherForm.g_bToggle5 = true;
                btn5.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggle5 = false;
                btn5.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("MISC", "TOGGLE5ON", LauncherForm.g_bToggle5.ToString());

            parser.SaveSettings();
        }

        #endregion

        #region ⨌⨌ Skill Timer Switch ⨌⨌

        private void XuiSwitchQ_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggleSkill1)
            {
                LauncherForm.g_bToggleSkill1 = true;
                btnQ.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggleSkill1 = false;
                btnQ.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("SKILL", "TOGGLESKILL1ON", LauncherForm.g_bToggleSkill1.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitchW_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggleSkill2)
            {
                LauncherForm.g_bToggleSkill2 = true;
                btnW.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggleSkill2 = false;
                btnW.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("SKILL", "TOGGLESKILL2ON", LauncherForm.g_bToggleSkill2.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitchE_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggleSkill3)
            {
                LauncherForm.g_bToggleSkill3 = true;
                btnE.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggleSkill3 = false;
                btnE.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("SKILL", "TOGGLESKILL3ON", LauncherForm.g_bToggleSkill3.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitchR_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggleSkill4)
            {
                LauncherForm.g_bToggleSkill4 = true;
                btnR.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggleSkill4 = false;
                btnR.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("SKILL", "TOGGLESKILL4ON", LauncherForm.g_bToggleSkill4.ToString());

            parser.SaveSettings();
        }

        private void XuiSwitchT_SwitchStateChanged(object sender, EventArgs e)
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

            if (!LauncherForm.g_bToggleSkill5)
            {
                LauncherForm.g_bToggleSkill5 = true;
                btnT.Image = Properties.Resources.check_on;
            }
            else
            {
                LauncherForm.g_bToggleSkill5 = false;
                btnT.Image = Properties.Resources.check_off;
            }
            parser.AddSetting("SKILL", "TOGGLESKILL5ON", LauncherForm.g_bToggleSkill5.ToString());

            parser.SaveSettings();
        }

        #endregion

        private void XuiSwitchDND_SwitchStateChanged(object sender, EventArgs e)
        {
            DNDSetState();
        }

        public void DNDSetState()
        {
            InputSimulator iSim = new InputSimulator();

            // Need to press ALT because the SetForegroundWindow sometimes does not work
            // Removed 2019.0712 iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            if(m_bISDND)
            {
                btnDND.Image = Properties.Resources.check_off;
                m_bISDND = false;
            }
            else
            {
                btnDND.Image = Properties.Resources.check_on;
                m_bISDND = true;
            }

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/dnd");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;
        }

        private void BtnManagerie_Click(object sender, EventArgs e)
        {
            GO_Managerie();
        }

        private void GO_Managerie() // /menagerie
        {
            InputSimulator iSim = new InputSimulator();

            // Need to press ALT because the SetForegroundWindow sometimes does not work
            // Removed 2019.0712 iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/menagerie");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;
        }

        private void BtnDELVE_Click(object sender, EventArgs e)
        {
            GO_Delve();
        }

        private void GO_Delve()
        {
            InputSimulator iSim = new InputSimulator();

            // Need to press ALT because the SetForegroundWindow sometimes does not work
            // Removed 2019.0712 iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/delve");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;
        }

        private void BtnPassives_Click(object sender, EventArgs e)
        {
            SendPOECommand("/passives");
        }
        
        private void BtnPlayed_Click(object sender, EventArgs e)
        {
            SendPOECommand("/played");
        }

        private void BtnDEATH_Click(object sender, EventArgs e)
        {
            SendPOECommand("/deaths");
        }

        private void SendPOECommand(string strSendString)
        {
            InputSimulator iSim = new InputSimulator();

            // Need to press ALT because the SetForegroundWindow sometimes does not work
            // Removed 2019.0712 iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry(strSendString);

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;
        }

        private void BtnEXIT_Click(object sender, EventArgs e)
        {
            EXITtoCharacterSelcection();
        }

        private void EXITtoCharacterSelcection()
        {
            InputSimulator iSim = new InputSimulator();

            // Need to press ALT because the SetForegroundWindow sometimes does not work
            // Removed 2019.0712 iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/exit");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            //iSim = null;
        }

        private void BtnCMD_Click(object sender, EventArgs e)
        {
            if(m_bIsCMDVisible)
            {
                //panelCMDTop.Visible = false;
                panelCOMMAND.Visible = false;

                m_bIsCMDVisible = false;
            }
            else
            {
                //panelCMDTop.Visible = true;
                panelCOMMAND.Visible = true;

                m_bIsCMDVisible = true;
            }
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            if(g_bIsSCANOn)
            {
                g_bIsSCANOn = false;
                frmScanChat.Close();
            }
            else
            {
                g_bIsSCANOn = true;
                frmScanChat = new ScanChatForm();
                frmScanChat.Show();
            }
        }

        private void btnLabOverlay_Click(object sender, EventArgs e)
        {
            if (bLabOverlayShow)
            {
                bLabOverlayShow = false;
                frmLabSelect.Close();
            }
            else
            {
                bLabOverlayShow = true;
                frmLabSelect = new LabyOverlayForm();
                frmLabSelect.Show();
            }
        }

        #region [[[[[ EXPAND / COLLAPSE ]]]]]
        private void btnExpandCollapse_Click(object sender, EventArgs e)
        {
            if (!isMainExpand)
            {
                panelUtilityRectBorder.Visible = true;            

                isMainExpand = true;
                btnExpandCollapse.Image = Properties.Resources.arrow_up;
            }
            else
            {
                panelUtilityRectBorder.Visible = false;

                isMainExpand = false;
                btnExpandCollapse.Image = Properties.Resources.arrow_down;
            }
        }
        #endregion

        private void btnList_Click(object sender, EventArgs e)
        {
            if (!bVoriciCalcFormViewing || frmVoriciCalc==null)
            {
                bVoriciCalcFormViewing = true;
                //btnList.Image = Properties.Resources.icon_over_05;

                frmVoriciCalc = new ChromaticCalcForm();
                frmVoriciCalc.m_nRight = this.Right;
                frmVoriciCalc.m_nTop = this.Top;
                frmVoriciCalc.Show();
            }
            else if(bVoriciCalcFormViewing && frmVoriciCalc!=null)
            {
                //btnList.Image = Properties.Resources._5;
                bVoriciCalcFormViewing = false;

                frmVoriciCalc.Close();
            }
        }

        private void btnUserOverlay_Click(object sender, EventArgs e)
        {
            // Temporary Using : Oils
            if (!bOilsFormON)
            {
                bOilsFormON = true;

                frmOils = new BlightOilForm();
                frmOils.Show();
            }
            else
            {
                bOilsFormON = false;

                frmOils.Close();
            }
        }

        #region [[[[[ Ignore ENTER & ESCAPE ]]]]]
        // Ignore ENTER & ESCAPE
        private void btnHideout_Enter(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Escape)
                return;
        }
        #endregion

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Escape)
                return;
        }

        private void panelDrag_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Escape)
                return;
        }

        private void btnSearchRegion_Click(object sender, EventArgs e)
        {
            if (!bISearchRegionOn)
            {
                bISearchRegionOn = true;

                frmSearchRegion = new AwakenedRegionForm();
                frmSearchRegion.m_nRight = this.Right;
                frmSearchRegion.m_nTop = this.Top;
                frmSearchRegion.Show();
            }
            else
            {
                bISearchRegionOn = false;

                frmSearchRegion.Close();
            }

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        }

        private void btnAtlasOverlay_Click(object sender, EventArgs e)
        {
            if (!bIMGOvelayActivatedMAP)
                frmIMGOverlayMAP = new ImageOverlayFormMap();
            // ZANA
            frmIMGOverlayMAP.m_strImagePath = strImagePath[2];
            frmIMGOverlayMAP.nZoom = 0;
            frmIMGOverlayMAP.Load_Image();
            IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_MAP);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region [[[[[ Main Button ToolTip - onFocus ]]]]]
        /*
        btnHideout          1 : Hideout
        btnSearchStash      2 : Find by X,Y Position (Magnify Glass)
        btnScan             3 : Chat Scanner
        button5             4 : Ninja Price
        button4             5 : Atlas Information
        btnSearchRegion     6 : Search Region Map
        btnCMD              7 : POE Command
        btnLabOverlay       8 : Labyrinth Overlay
        btnLOCK             9 : Lockpin (Lock, Unlock)

        button1             10 : Act Helper
        button9             11 : Grid, Stash
        button2             12 : Syndicate Information
        button3             13 : Incrusion(Temple) Information
        btnList             14 : Chromatic calculator
        btnUserOverlay      15 : Annoint Information (Oil Enchant)
        btnHelp             16 : Help (Simple Guide)
        button6             17 : Settings
        btnClose            18 : Close

        DeadlyToolTip.SetToolTip(btnHideout, "Go to Hideout (하이드아웃으로 이동)");
        DeadlyToolTip.SetToolTip(btnSearchStash, "Find item by X,Y Position (좌표로 아이템 찾기)");
        DeadlyToolTip.SetToolTip(btnScan, "Scan trade chat (트레이드 채널 채팅 스캔)");
        DeadlyToolTip.SetToolTip(button5, "Poe.Ninja Price (닌자 시세 확인)");
        DeadlyToolTip.SetToolTip(btnList, "Chromatic Caculator (크로마틱 계산기)");
        DeadlyToolTip.SetToolTip(btnCMD, "POE Command (POE 명령어)");
        DeadlyToolTip.SetToolTip(btnLabOverlay, "Labyrinth Overlay (미궁 오버레이)");
        DeadlyToolTip.SetToolTip(btnLOCK, "Lock/Unlock panel position. (위치 고정, 고정 해제");

        DeadlyToolTip.SetToolTip(button1, "Act Helper (엑트 헬퍼)");
        DeadlyToolTip.SetToolTip(button9, "Stash Grid & Net worth (보관함 격자 설정, 보관함의 아이템 가격");
        DeadlyToolTip.SetToolTip(button2, "Syndicate Overlay (JUN 신디케이트 보상표)");
        DeadlyToolTip.SetToolTip(button3, "Alva Temple Incursion Overlay (ALVA 사원 보상표)");
        DeadlyToolTip.SetToolTip(button4, "Atlas map Infomation Overlay (ZANA 아틀라스 맵 정보)");
        DeadlyToolTip.SetToolTip(btnUserOverlay, "Search Oil Enchant Passives & Information (성유 인챈트 검색, 정보)");
        DeadlyToolTip.SetToolTip(button6, "Settings (설정)");
        DeadlyToolTip.SetToolTip(btnClose, "Close DeadlyTrade (데들리트레이드 종료)");

        1. Go to Hideout.
        2. Find item by X,Y Position. (useful for other langue's whispers)
        3. Scan trade channel chatting.
        4. Poe.Ninja Price and Simple caclulator.
        5. Atlas map Infomation Overlay.
        6. Region Map Search Helper.
        7. POE Useful Command.
        8. Labyrinth Information Overlay.
        9. Lock/UnLock Adoon Panel&Timer Position

        10. Act Helper for leveling and Quest line.
        11. Set Stash Grid (Item Price : Work in porgress)
        12. Syndicate Information Overlay.
        13. Incursion Information Overlay.
        14. Chromatic claculator.
        15. Annoint(Oil Enchant) Information.
        16. Help : Simple Guide
        17. Settings
        18. Close

        [ Tray Icon. ]
        Maximize Launcher
        Exit DeadlyTrade
        */
        private void btnHideout_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnHideout, "Go to Hideout.");
        }

        private void btnSearchStash_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnSearchStash, "Find item by X,Y Position. (useful for other langue's whispers)");
        }

        private void btnScan_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnScan, "Scan trade channel chatting.");
        }

        
        private void button5_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(button5, "Poe.Ninja Price and Simple caclulator.");
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(button4, "Atlas map Infomation Overlay.");
        }

        private void btnSearchRegion_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnSearchRegion, "Region Map Search Helper.");
        }

        private void btnCMD_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnCMD, "POE Useful Command.");
        }

        private void btnLabOverlay_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnLabOverlay, "Labyrinth Information Overlay.");
        }

        private void btnLOCK_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnLOCK, "Lock/UnLock Adoon Panel&Timer Position.");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(button1, "Act Helper for leveling and Quest line.");
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(button9, "Set Stash Grid (Item Price : Work in porgress)");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(button2, "Syndicate Information Overlay."); 
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(button3, "Incursion Information Overlay.");
        }

        private void btnList_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnList, "Chromatic claculator.");
        }

        private void btnUserOverlay_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnUserOverlay, "Annoint(Oil Enchant) Information.");
        }

        private void btnHelp_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnHelp, "Help: Simple Guide");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(button6, "Settings.");
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            DeadlyToolTip.SetToolTip(btnClose, "Close.");
        }
        #endregion

        #region [[[[[ Main HUD - Minimize, Maximize ]]]]]
        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            if (!bIsMinimized)
            {
                btnHideout.Visible = false;
                btnSearchStash.Visible = false;
                btnScan.Visible = false;
                button5.Visible = false;
                button4.Visible = false;
                btnSearchRegion.Visible = false;
                btnCMD.Visible = false;
                btnLabOverlay.Visible = false;
                btnLOCK.Visible = false;

                button1.Visible = false;
                button9.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                btnList.Visible = false;
                btnUserOverlay.Visible = false;
                btnHelp.Visible = false;
                button6.Visible = false;
                btnClose.Visible = false;

                btnMinimize.Visible = false;
                panelDrag.Visible = false;
                btnExpandCollapse.Visible = false;

                bIsMinimized = true;
                btnDeadlyTrade.Visible = true;
                panel6.BorderStyle = BorderStyle.None;
                
                panelUtilityRectBorder.Visible = false;
            }
            else
            {
                btnHideout.Visible = true;
                btnSearchStash.Visible = true;
                btnScan.Visible = true;
                button5.Visible = true;
                button4.Visible = true;
                btnSearchRegion.Visible = true;
                btnCMD.Visible = true;
                btnLabOverlay.Visible = true;
                btnLOCK.Visible = true;

                button1.Visible = true;
                button9.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                btnList.Visible = true;
                btnUserOverlay.Visible = true;
                btnHelp.Visible = true;
                button6.Visible = true;
                btnClose.Visible = true;

                btnMinimize.Visible = true;
                panelDrag.Visible = true;
                btnExpandCollapse.Visible = true;

                bIsMinimized = false;
                btnDeadlyTrade.Visible = false;
                panel6.BorderStyle = BorderStyle.FixedSingle;
                if (isMainExpand)
                    panelUtilityRectBorder.Visible = true;
                else
                    panelUtilityRectBorder.Visible = false;
            }
        }
        #endregion

        private void btnDeadlyTrade_Click(object sender, EventArgs e)
        {
            btnMinimize_Click_1(this, new EventArgs());
        }

        private void btnDeadlyTrade_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!LauncherForm.g_pinLOCK)
            {
                nMoving = 1;
                nMovePosX = e.X;
                nMovePosY = e.Y;
            }
        }

        private void btnDeadlyTrade_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX - 201, MousePosition.Y - nMovePosY);
            }
        }

        private void btnDeadlyTrade_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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

            parser.AddSetting("LOCATIONMAIN", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONMAIN", "TOP", this.Top.ToString());
            parser.SaveSettings();

            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
        }

        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int nElapse = 0;
            double elapsedmin = ((TimeSpan)(LauncherForm.dtLoggedIn - DateTime.Now)).TotalMinutes;
            nElapse = Convert.ToInt32(elapsedmin);
            if (nElapse < 0)
                nElapse = 0;
            DeadlyDBHelper.InsertLoginStatus(LauncherForm._sqlcon, "N", LauncherForm._strIPAddress, LauncherForm._strMacAddress, ".", "LOGOUT", 
                                            LauncherForm.GetCountryByIPINFO(LauncherForm._strIPAddress), LauncherForm.dtLoggedIn, nElapse); 
            DeadlyLog4Net._log.Info("LOGOUT : " + LauncherForm._strIPAddress + LauncherForm._strMacAddress + " Elapsedminute : " + nElapse);
        }

        private void btnTEST_Click(object sender, EventArgs e)
        {
            //DeadlyPriceAPI.GetItemDataFromClipboard(ClipboardHelper.GetUnicodeText());
            
            //frmNotify.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //Form1 frm = new Form1();
            //frmNotify.AddBuyNotifyForm("TEST", frm);
        }
    }
}
