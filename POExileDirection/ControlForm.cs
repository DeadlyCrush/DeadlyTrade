using Newtonsoft.Json;
using Ninja_Price.API.PoeNinja;
using Ninja_Price.API.PoeNinja.Classes;
using POExileDirection.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace POExileDirection
{
    public partial class ControlForm : Form
    {
        #region ⨌⨌ DllImport for Invoke ⨌⨌
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern byte VkKeyScan(char ch);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmReleaseContext(IntPtr hWnd, IntPtr hImc);

        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmGetConversionStatus(IntPtr hImc, out int fdwConversion, out int fdwSentence);

        [DllImport("imm32.dll")]
        public static extern bool ImmSetConversionStatus(IntPtr hIMC, int fdwConversion, int fdwSentence);
        #endregion

        public const string WINDOW_NAME = "Path of Exile"; // POE Window Title
        IntPtr handlePOE = FindWindow(null, WINDOW_NAME);
        IntPtr g_thisH;// = FindWindow(null, "POExileDirection");

        int nMoving = 0;
        int nMovePosX = 0;
        int nMovePosY = 0;

        string currentDirectory = null;

        // Hot Keys
        fsModifiers m_unMod = 0;
        Keys m_HotKey = 0;
        const int WM_MOUSEWHEEL = 0x020A;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_CTRL = 0x11;
        const int VK_LEFT = 0x25;
        const int VK_RIGHT = 0x26;

        // OVERLAY
        string[] strImagePath = new string[3];
        static public string keyMAINRemains;// = "특수키없음 + F2";
        static public string keyMAINJUN;// = "특수키없음 + F3";
        static public string keyMAINALVA;// = "특수키없음 + F4";
        static public string keyMAINZANA;// = "특수키없음 + F6";
        OverlayHotkeys ovHRemains = new OverlayHotkeys();
        OverlayHotkeys ovHJUN = new OverlayHotkeys();
        OverlayHotkeys ovHALVA = new OverlayHotkeys();
        OverlayHotkeys ovHZANA = new OverlayHotkeys();
            // QUEST HELPER
            MainForm frmMainForm = new MainForm();
            bool bMainFormActivated = false;
            // JUN (SYNDICATE)
            ImageOverlayForm frmIMGOverlay = null;
            public static bool bIMGOvelayActivated = false;
            // ALVA (INCURSION )
            ImageOverlayFormAlva frmIMGOverlayALVA = null;
            public static bool bIMGOvelayActivatedALVA = false;
            // ZANA (MAP)
            ImageOverlayFormMap frmIMGOverlayMAP = null;
            public static bool bIMGOvelayActivatedMAP = false;           

        // HOOK
        GlobalLowLevelHooks.MouseHook mouseHook = new GlobalLowLevelHooks.MouseHook();
        GlobalLowLevelHooks.KeyboardHook keyHook = new GlobalLowLevelHooks.KeyboardHook();
        bool IsControlKeyDown = false;

        public string g_strISKAKAOUSER = "YES";

        NinjaForm frmNinja = new NinjaForm();
        public static bool bShowNinja = false;

        bool bIsMinimized = false;

        // 2019.07.12 Emergency
        FileStream g_fileStream;
        StreamReader g_logStream;
        UI_LANG g_nUILang;
        string g_strUILang = null;

        // TRADE MSG
        DeadlyRegEx g_DeadlyRegEx = new DeadlyRegEx();
        public static List<DeadlyTRADE.TradeMSG> g_TradeMsgList = new List<DeadlyTRADE.TradeMSG>();
        public static int g_nNotificationCount = 0;

        // STASH GRID
        StashGrid frmStashGrid = null;
        bool bfrmStashGridShow = false;

        string g_LogFilePath = "";

        public ControlForm()
        {
            InitializeComponent();
            this.Text = "POExileDirection";

            Init_Controls();
            currentDirectory = Application.StartupPath;

            if (!Validate_POELogFile())
            {
                this.Close();
                Environment.Exit(0);
            }
            else
            {
                // Set Trade Message RegEx.
                Check_UILanguageWrapping();
                Set_TradeMessageRegEx();

                // Start LOG Parsing UI Thread.
                DeadlyLOGParingTimer.Start();
            }
        }

        #region ⨌⨌ Init. Controls. ⨌⨌
        public void Init_Controls()
        {
            // btnClose
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.TabStop = false;

            //
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.TabStop = false;
            //
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button2.FlatAppearance.BorderSize = 0;
            button2.TabStop = false;
            //
            button3.FlatStyle = FlatStyle.Flat;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button3.FlatAppearance.BorderSize = 0;
            button3.TabStop = false;
            //
            button4.FlatStyle = FlatStyle.Flat;
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button4.FlatAppearance.BorderSize = 0;
            button4.TabStop = false;
            //
            button5.FlatStyle = FlatStyle.Flat;
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button5.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button5.FlatAppearance.BorderSize = 0;
            button5.TabStop = false;
            //
            button6.FlatStyle = FlatStyle.Flat;
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button6.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button6.FlatAppearance.BorderSize = 0;
            button6.TabStop = false;
        }
        #endregion

        private void ControlForm_Load(object sender, EventArgs e)
        {
            Init_ControlFormPosition();

            Register_HotKeys();

            mouseHook.Install();
            mouseHook.MouseWheel += MouseHook_MouseWheel;

            keyHook.Install();
            keyHook.KeyDown += KeyHook_KeyDown;
            keyHook.KeyUp += KeyHook_KeyUp;

            // for ReadStream Client.txt
            /* TEMP_REMOVE frmMainForm.strMainFromKAKAOUSER = g_strISKAKAOUSER;
            frmMainForm.Show();
            frmMainForm.Hide();
            */
        }

        #region ⨌⨌ Check and Set. Path of Exile Log File & Path ⨌⨌
        public bool Validate_POELogFile()
        {
            bool bRet = false;

            /* for Quest Helper ( Remove Temporary )
            if (!ReadDirectionHelperData())
                return bRet;
            */

            string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

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
            catch
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "환경 파일을 읽을 수 없습니다.\r\n\r\nini 파일이 손상되었거나 삭제되었습니다.";
                frmMSG.ShowDialog();
                bRet = false;
                return bRet;
            }

            if (File.Exists(g_LogFilePath))
            {
                try
                {
                    long lnFileSize = new FileInfo(g_LogFilePath).Length;
                    gln_LastRead = lnFileSize;
                }
                catch (FileNotFoundException ex)
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "패스 오브 엑자일 로그파일을 읽는 도중 오류가 발생했습니다. ‼‼‼\r\nERROR : ( " + ex.Message + " )";
                    frmMSG.ShowDialog();
                    bRet = false;
                    return bRet;
                }
            }
            else
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "패스 오브 엑자일 경로가 맞지 않습니다.\r\n경로를 설정해주세요.";
                frmMSG.ShowDialog();
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                DialogResult dr = dlgFolder.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // strPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\Client.txt");
                    g_LogFilePath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\TESTClient.txt");
                }
                else
                {
                    bRet = false;
                    return bRet;
                }

                // Set Ini.
                parser.AddSetting("DIRECTIONHELPER", "POELOGPATH", g_LogFilePath);
                parser.SaveSettings();

                try
                {
                    long lnFileSize = new FileInfo(g_LogFilePath).Length;
                    gln_LastRead = lnFileSize;
                }
                catch (FileNotFoundException ex)
                {
                    MSGForm frmMSG2nd = new MSGForm();
                    frmMSG2nd.lbMsg.Text = "설정한 경로의 로그파일을 읽는 도중 오류가 발생했습니다. ‼‼‼\r\nERROR : ( " + ex.Message + " )";
                    frmMSG2nd.ShowDialog();
                    bRet = false;
                    return bRet;
                }
            }

            #region OLD CODE BACKUP ⨌⨌
            /*if (File.Exists(strPath))
            {
                try
                {
                    g_fileStream = File.Open(strPath, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.ReadWrite);
                    g_logStream = new StreamReader(g_fileStream);
                }
                catch
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "패스 오브 엑자일 로그파일을 읽는 도중 오류가 발생했습니다. ‼‼‼";
                    frmMSG.ShowDialog();
                    bRet = false;
                    return bRet;
                }
            }
            else
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "패스 오브 엑자일 경로가 맞지 않습니다.\r\n경로를 설정해주세요.";
                frmMSG.ShowDialog();
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                DialogResult dr = dlgFolder.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // strPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\Client.txt");
                    strPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\TESTClient.txt");
                }
                else
                {
                    bRet = false;
                    return bRet;
                }

                // Set Ini.
                parser.AddSetting("DIRECTIONHELPER", "POELOGPATH", strPath);
                parser.SaveSettings();

                try
                {
                    g_fileStream = File.Open(strPath, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.ReadWrite);
                    g_logStream = new StreamReader(g_fileStream);
                }
                catch
                {
                    MSGForm frmMSG2 = new MSGForm();
                    frmMSG2.lbMsg.Text = "패스 오브 엑자일 로그파일을 읽는 도중 오류가 발생했습니다. ‼‼‼";
                    frmMSG2.ShowDialog();
                    bRet = false;
                    return bRet;
                }
            }
            */

            // Now Start Monitoring LOG File.
            #endregion

            return true;
        }
        #endregion

        #region ⨌⨌ TRADE Regular Expression ⨌⨌
        private void Set_TradeMessageRegEx()
        {
            /*
            // Trade Message - English
            private string RegExENGPriceWithTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$";
            private string RegExENGPriceNoTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$";
            private string RegExENGUnPrice = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
            private string RegExENGBulkCurrencies = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
            private string RegExENGCurrency = "^(.*\\s)?(.+): (.+ to buy your (\\d+(\\.\\d+)?)? (.+) for my (\\d+(\\.\\d+)?)? (.+) in (.*?)\\.\\s*(.*))$";
            private string RegExENGMapLiveSite = "^(.*\\s)?(.+): (I'd like to exchange my (T\\d+:\\s\\([\\s\\S,]+) for your (T\\d+:\\s\\([\\S,\\s]+) in\\s+?(.+?)\\.)";

            // Trade Message - Korean
            private string RegExKORPriceWithTabName = "^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 (\\d+) (.*?)\\(으\\)로 올려놓은(.?\\s)(.+)을\\(를\\) 구매하고 싶습니다\\s*(.*)$";
            private string RegExKORPriceNoTabName = "NOT";
            private string RegExKORUnPrice = "^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 올려놓은 (.*?\\s*)을\\(를\\) 구매하고 싶습니다\\s*(.*)$";
            private string RegExKORBulkCurrencies = "NOT";
            private string RegExKORCurrency = "NOT";
            private string RegExKORMapLiveSite = "NOT";
            */
            #region ⨌⨌  TRADE - English ⨌⨌
            g_DeadlyRegEx.RegExENGPriceWithTabName = new Regex("^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$");
            g_DeadlyRegEx.RegExENGPriceNoTabName = new Regex("^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$");
            g_DeadlyRegEx.RegExENGUnPrice = new Regex("^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$");
            g_DeadlyRegEx.RegExENGBulkCurrencies = new Regex("^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$");
            g_DeadlyRegEx.RegExENGCurrency = new Regex("^(.*\\s)?(.+): (.+ to buy your (\\d+(\\.\\d+)?)? (.+) for my (\\d+(\\.\\d+)?)? (.+) in (.*?)\\.\\s*(.*))$");
            g_DeadlyRegEx.RegExENGMapLiveSite = new Regex("^(.*\\s)?(.+): (I'd like to exchange my (T\\d+:\\s\\([\\s\\S,]+) for your (T\\d+:\\s\\([\\S,\\s]+) in\\s+?(.+?)\\.)");
            #endregion

            #region ⨌⨌  TRADE - Korean ⨌⨌
            g_DeadlyRegEx.RegExKORPriceWithTabName = new Regex("^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 (\\d+) (.*?)\\(으\\)로 올려놓은(.?\\s)(.+)을\\(를\\) 구매하고 싶습니다\\s*(.*)$");
            g_DeadlyRegEx.RegExKORPriceNoTabName = new Regex("NOT");
            g_DeadlyRegEx.RegExKORUnPrice = new Regex("^(.*\\s)?(.+): 안녕하세요, (\\s*)?(.+)\\(보관함 탭(.*?)\\\"(.*)\\\", 위치: 왼쪽 (\\d+), 상단 (\\d+)\\)에 올려놓은 (.*?\\s*)을\\(를\\) 구매하고 싶습니다\\s*(.*)$");
            g_DeadlyRegEx.RegExKORBulkCurrencies = new Regex("NOT");
            g_DeadlyRegEx.RegExKORCurrency = new Regex("NOT");
            g_DeadlyRegEx.RegExKORMapLiveSite = new Regex("NOT");
            #endregion
        }
        #endregion

        #region ⨌⨌ LOG Parser Timer Thread ⨌⨌

        long gln_LastRead = 0; 
        private void DeadlyLOGParingTimer_Tick(object sender, EventArgs e)
        {
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

                                // Get a handle to POE. The window class and window name were obtained using the Spy++ tool.
                                // DeadlyCrush RM_TEMP IntPtr poeHandle = FindWindow("POEWindowClass", "Path of Exile");

                                // Verify that POE is a running process.
                                // DeadlyCrush RM_TEMP if (poeHandle != IntPtr.Zero)
                                {
                                    #region ⨌⨌ ZONE ⨌⨌
                                    Match mZone = null;
                                    if (g_nUILang == UI_LANG.UI_KOREAN)
                                        mZone = g_DeadlyRegEx.RegExZoneEnteredKOR.Match(readLineString);
                                    else
                                        mZone = g_DeadlyRegEx.RegExZoneEnteredENG.Match(readLineString);

                                    if (mZone.Success)
                                    {
                                        // New zone has been entered.
                                        // this.Invoke((MethodInvoker)delegate ()
                                        //{
                                        btnStashGrid.Text = mZone.Groups[1].ToString();
                                        //});
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
                                    }
                                    #endregion

                                    #region ⨌⨌ ### TRADE Parsing and Notify ### ⨌⨌

                                    #region ⨌⨌ Regular Expression ⨌⨌
                                    /*
                                    // ENG
                                    g_DeadlyRegEx.RegExENGPriceWithTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$";
                                    g_DeadlyRegEx.RegExENGPriceNoTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$";
                                    g_DeadlyRegEx.RegExENGUnPrice = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
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

                                    Match mItemPriceWithTabName = null;
                                    Match mItemPriceNoTabName = null;
                                    Match mItemUnPrice = null;
                                    Match mBulkCurrencies = null;
                                    Match mCurrency = null;
                                    Match mMapLive = null;

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

                                    string strTradePurpose = null;
                                    if (readLineString.Contains("@To") || readLineString.Contains("@수신"))
                                        strTradePurpose = "BUY";
                                    else if (readLineString.Contains("@From") || readLineString.Contains("@발신"))
                                        strTradePurpose = "SELL";

                                    /*
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
                                    if (strTradePurpose != null && strTradePurpose != "")
                                    {
                                        if (g_nUILang == UI_LANG.UI_ENGLISH)
                                        {
                                            DeadlyTRADE.TradeMSG tradeWhisper = new DeadlyTRADE.TradeMSG();
                                            mItemPriceWithTabName = g_DeadlyRegEx.RegExENGPriceWithTabName.Match(readLineString);
                                            if (mItemPriceWithTabName.Groups.Count > 4)
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

                                                g_nNotificationCount = g_nNotificationCount + 1;
                                                tradeWhisper.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                                                tradeWhisper.expanded = false;
                                                g_TradeMsgList.Add(tradeWhisper);

                                                NotificationForm frmNotify = new NotificationForm();
                                                frmNotify.Show();
                                            }
                                        }
                                        else
                                        {
                                            /*DeadlyTRADE.TradeMSG item = new DeadlyTRADE.TradeMSG();
                                            mItemPriceWithTabName = Regex.Matches(readLineString, g_DeadlyRegEx.RegExKORPriceWithTabName.ToString());


                                            item.tradePurpose = strTradePurpose;

                                            g_TradeMessages.TradeMSGData.Add(item);*/
                                        }
                                    }
                                    #endregion
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

            }
            catch (FileNotFoundException)
            {
                DeadlyLOGParingTimer.Tick -= DeadlyLOGParingTimer_Tick;
            }
            catch (Exception ex)
            {
                MSGForm frmMSG2 = new MSGForm();
                frmMSG2.lbMsg.Text = "패스 오브 엑자일 로그파일을 읽는 도중 오류가 발생했습니다. ‼‼‼\r\n\r\n( ERROR : " + ex.Message + ")";
                frmMSG2.ShowDialog();
            }



            #region ⨌⨌ BACKUP - Deadly LOG Parsing by FileStream ⨌⨌

            /*
            string readLineString = g_logStream.ReadToEnd();
            // Temprorary Remove 07.12 string image = null;
            */

            /*
            #region ⨌⨌ ZONE ⨌⨌
            Match mZone = null;
            if (g_nUILang == UI_LANG.UI_KOREAN)
                mZone = g_DeadlyRegEx.RegExZoneEnteredKOR.Match(readLineString);
            else
                mZone = g_DeadlyRegEx.RegExZoneEnteredENG.Match(readLineString);

            if (mZone.Success)
            {
                // New zone has been entered.
                // this.Invoke((MethodInvoker)delegate ()
                //{
                    btnStashGrid.Text = mZone.Groups[1].ToString();
                //});
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
            }
            #endregion
            */

            #region ⨌⨌ ### TRADE Parsing and Notify ### ⨌⨌

            #region ⨌⨌ Regular Expression ⨌⨌
            /*
            // ENG
            g_DeadlyRegEx.RegExENGPriceWithTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash tab \"(.*)\"; position: left (\\d+), top (\\d+)\\)\\s*?(.*))$";
            g_DeadlyRegEx.RegExENGPriceNoTabName = "^(.*\\s)?(.+): (.+ to buy your\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.*?))$";
            g_DeadlyRegEx.RegExENGUnPrice = "^(.*\\s)?(.+): (\\s*?wtb\\s+?(.+?)(\\s+?listed for\\s+?([\\d\\.]+?)\\s+?(.+))?\\s+?in\\s+?(.+?)\\s+?\\(stash\\s+?\"(.*?)\";\\s+?left\\s+?(\\d+?),\\s+?top\\s+(\\d+?)\\)\\s*?(.*))$";
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

            /*
            MatchCollection mItemPriceWithTabName = null;
            MatchCollection mItemPriceNoTabName = null;
            MatchCollection mItemUnPrice = null;
            MatchCollection mBulkCurrencies = null;
            MatchCollection mCurrency = null;
            MatchCollection mMapLive = null;
            */

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

            /*
            string strTradePurpose = null;
            if (readLineString.Contains("@To") || readLineString.Contains("@수신"))
                strTradePurpose = "BUY";
            else if (readLineString.Contains("@From") || readLineString.Contains("@발신"))
                strTradePurpose = "SELL";
            */

            /*
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

            /*
            if (strTradePurpose != null && strTradePurpose != "")
            {
                if (g_nUILang == UI_LANG.UI_ENGLISH)
                {
                    DeadlyTRADE.TradeMSG tradeWhisper = new DeadlyTRADE.TradeMSG();
                    mItemPriceWithTabName = Regex.Matches(readLineString, g_DeadlyRegEx.RegExENGPriceWithTabName.ToString());
                    Match mTest = g_DeadlyRegEx.RegExENGPriceWithTabName.Match(readLineString);
                    if (mItemPriceWithTabName.Count > 4)
                    {
                        foreach (Match matchData in mItemPriceWithTabName)
                        {
                            tradeWhisper.tradePurpose = strTradePurpose;
                            tradeWhisper.fullMSG = matchData.Groups[3].Value;
                            tradeWhisper.league = matchData.Groups[8].Value;
                            tradeWhisper.nickName = matchData.Groups[2].Value;
                            tradeWhisper.itemName = matchData.Groups[4].Value;
                            if (matchData.Groups[6] != null)
                                tradeWhisper.priceCall = matchData.Groups[6].Value;
                            else
                                tradeWhisper.priceCall = "?";
                            if (matchData.Groups[7] != null)
                                tradeWhisper.whichCurrency = matchData.Groups[7].Value;
                            else
                                tradeWhisper.whichCurrency = "?";
                            if (matchData.Groups[9] != null)
                            {
                                tradeWhisper.tabName = matchData.Groups[9].Value;
                                tradeWhisper.xPos = matchData.Groups[10].Value;
                                tradeWhisper.yPos = matchData.Groups[11].Value;
                            }
                            if (matchData.Groups[12] != null)
                                tradeWhisper.offerMSG = matchData.Groups[12].Value;
                        }

                        g_nNotificationCount = g_nNotificationCount + 1;
                        tradeWhisper.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
                        tradeWhisper.expanded = false;
                        g_TradeMsgList.Add(tradeWhisper);

                        NotificationForm frmNotify = new NotificationForm();
                        frmNotify.Show();
                    }
                }
                else
                {
                    //DeadlyTRADE.TradeMSG item = new DeadlyTRADE.TradeMSG();
                    //mItemPriceWithTabName = Regex.Matches(readLineString, g_DeadlyRegEx.RegExKORPriceWithTabName.ToString());

                    
                    //item.tradePurpose = strTradePurpose;

                    //g_TradeMessages.TradeMSGData.Add(item);
                }
            }
            */
            #endregion

            #region ⨌⨌ ZONE ( Temporay Remove 07.12 ) ⨌⨌
            /*Match m = RegExZoneEntered.Match(line);

            if (m.Success)
            {
                // New zone has been entered - update graphics. 
                zoneName = m.Groups[1].ToString();
                actString = "?";

                bSeedFound = false;

                PictureBox[] picBox = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
                image = String.Format("{0}\\Overlays\\{1}.png", currentDirectory, "no_overlay");

                InitMapImage(); // Clear Map Image

                // Attempt to find a corresponding zoneName 
                var seedList = FindZoneName(zoneName);
                int nIndex = 0;
                if (seedList.Item2.Length > 0)
                {
                    foreach (var seed in seedList.Item2) // region.Region (ACT), zone.ZoneSeed (Image), zone.Note (Explain Text)
                    {
                        actString = seedList.Item1;
                        string[] actROMA = actString.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                        actString = actROMA[0];
                        image = String.Format("{0}\\Overlays\\{1}\\{2}.png", currentDirectory, seedList.Item1, seed);

                        // IMAGE
                        picBox[nIndex].Load(image);
                        picBox[nIndex].SizeMode = PictureBoxSizeMode.StretchImage;

                        // TEXT
                        noteLabel.Text = seedList.Item3;
                        bSeedFound = true;

                        nIndex++;
                    }
                }

                string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
                IniParser parser = new IniParser(strINIPath);
                if (actString == "?")
                {
                    actString = commonClass.GetActROMAbyZoneName(zoneName, partTwo);
                }

                if (actString == "I" || actString == "II" || actString == "III" || actString == "IV" || actString == "V")
                {
                    parser.AddSetting("INITPART", "LASTPART", "1");
                    if (!bSeedFound) noteLabel.Text = "마을입니다.";
                }
                else if (actString == "VI" || actString == "VII" || actString == "VIII" || actString == "IX" || actString == "X")
                {
                    parser.AddSetting("INITPART", "LASTPART", "2");
                    if (!bSeedFound) noteLabel.Text = "마을입니다.";
                }
                else if (actString == "O")
                {
                    parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "액트 클리어를 축하드립니다.";
                }
                else if (actString == "Z")
                {
                    parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "지도의 대가 자나를 만나보세요.";
                }
                else if (actString == "H")
                {
                    parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "멋진 은신처군요~!";
                }
                else
                {
                    parser.AddSetting("INITPART", "LASTPART", "3");
                    noteLabel.Text = "정보가 없습니다. (더블클릭시에도 나타나지 않으면 지역 정보가 충분히 파악되지 않았거나, 정보가 없어도 진행이 가능한 지역입니다.)";
                }
                parser.AddSetting("INITPART", "zoneName", zoneName);
                parser.AddSetting("INITPART", "actString", actString);
                parser.SaveSettings();

                btnLangText = String.Format("{0} [ Act {1} ] {2}", g_strUILang, actString, zoneName);
                btnLang.Text = btnLangText;
            }
            */
            #endregion
            #endregion
        }
        #endregion

        #region ⨌⨌ WndProc ⨌⨌
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                Keys keyHot = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                fsModifiers modifier = (fsModifiers)((int)m.LParam & 0xFFFF);

                if (modifier == ovHRemains.fsMod && keyHot == ovHRemains.hotKeys)
                {
                    SetForegroundWindow(handlePOE);
                    Get_Remaining();
                }

                if (modifier == ovHJUN.fsMod && keyHot == ovHJUN.hotKeys)
                {
                    if (!bIMGOvelayActivated)
                        frmIMGOverlay = new ImageOverlayForm();
                    frmIMGOverlay.m_strImagePath = strImagePath[0];
                    frmIMGOverlay.nZoom = 0;
                    frmIMGOverlay.Load_Image();
                    IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_JUN);
                }

                if (modifier == ovHALVA.fsMod && keyHot == ovHALVA.hotKeys)
                {
                    if (!bIMGOvelayActivatedALVA)
                        frmIMGOverlayALVA = new ImageOverlayFormAlva();
                    frmIMGOverlayALVA.m_strImagePath = strImagePath[1];
                    frmIMGOverlayALVA.nZoom = 0;
                    frmIMGOverlayALVA.Load_Image();
                    IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_ALVA);
                }

                if (modifier == ovHZANA.fsMod && keyHot == ovHZANA.hotKeys)
                {
                    if (!bIMGOvelayActivatedMAP)
                        frmIMGOverlayMAP = new ImageOverlayFormMap();
                    frmIMGOverlayMAP.m_strImagePath = strImagePath[2];
                    frmIMGOverlayMAP.nZoom = 0;
                    frmIMGOverlayMAP.Load_Image();
                    IMGOverlayForm_Show_Hide((int)OVERLAY_WHAT.OVER_MAP);
                }
            }

            base.WndProc(ref m);
        }
        #endregion

        #region ⨌⨌ Set Regular Expression ⨌⨌

        #region Check ⨌⨌ UI Language and Set ZONE RegEx ⨌⨌
        public void Check_UILanguageWrapping()
        {
            g_nUILang = CheckPOEUILanguage();

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
                Environment.Exit(0);
            }
            else
            {
                // ZONE
                g_DeadlyRegEx.RegExZoneEnteredENG = new Regex(@"You have entered (.*)\.", RegexOptions.IgnoreCase);
                g_DeadlyRegEx.RegExZoneEnteredKOR = new Regex(@": (.*)에 진입했습니다.", RegexOptions.IgnoreCase); // for Korean Client. ex) [INFO Client 14932] : 오아시스에 진입했습니다.

                // MONSTER
                g_DeadlyRegEx.RegExMonsterRemainsENG = new Regex(@": (.*) monsters remain."); // : 3 monsters remain.
                g_DeadlyRegEx.RegExMonsterRemainsENGMore = new Regex(@": More than (.*) monsters remain."); // : More than 50 monsters remain.
                g_DeadlyRegEx.RegExMonsterRemainsKOR = new Regex(@": 몬스터 (.*)개체가 남아있습니다."); // : 몬스터 0개체가 남아있습니다.
                g_DeadlyRegEx.RegExMonsterRemainsKORMore = new Regex(@": 몬스터가 (.*)개체 이상 남아있습니다."); // : 몬스터가 50개체 이상 남아있습니다.
            }
        }
        #endregion

        #endregion

        #region ⨌⨌ Check Language Setting in Path of Exile production_Config.ini ⨌⨌
        public UI_LANG CheckPOEUILanguage()
        {
            String strPathPOEConifg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            strPathPOEConifg = strPathPOEConifg + "\\My Games\\Path of Exile\\production_Config.ini";
            IniParser parser = new IniParser(strPathPOEConifg);

            /*
            [LANGUAGE]
            language=en
            language=ko-KR
            */
            string strLanguage = "";
            try
            {
                strLanguage = parser.GetSetting("LANGUAGE", "language");


                if (strLanguage.Equals("ko-KR", StringComparison.OrdinalIgnoreCase))
                {
                    g_strUILang = "KOR";
                    return UI_LANG.UI_KOREAN;
                }
                else if (strLanguage.Equals("en", StringComparison.OrdinalIgnoreCase))
                {
                    g_strUILang = "ENG";
                    return UI_LANG.UI_ENGLISH;
                }
                else
                {
                    // 언어 환경 설정 콤보박스를 한번도 건드리지 않은 사용자는 [LANGUAGE] 섹션이 없음
                    MSGForm frmMSG3 = new MSGForm();
                    frmMSG3.lbMsg.Text = "언어 설정을 확인할 수 없어서 한글로 인식합니다.\r\n옵션-UI-언어를 확인해주세요.\r\n\r\n게임 옵션에서 언어 변경 후 저장하시면\r\nPOE의 설정 파일에 기록됩니다.";
                    frmMSG3.ShowDialog();
                    g_strUILang = "KOR";
                    return UI_LANG.UI_KOREAN;
                }
            }
            catch
            {
                /*MSGForm frmMSG4 = new MSGForm();
                frmMSG4.lbMsg.Text = "패스오브엑자일 환경 파일을 읽을 수 없습니다.\r\n\r\n패스오브엑자일을 한번이라도 실행하신 후\r\n\r\n다시 POE COMPASS를 실행해주세요.";
                frmMSG4.ShowDialog();
                return UI_LANG.UI_ERROR;*/

                // 언어 환경 설정 콤보박스를 한번도 건드리지 않은 사용자는 [LANGUAGE] 섹션이 없음 || 또는, PC방 사용자가 꺼져있는 컴을 켜고 처음 실행시켰을 때.
                MSGForm frmMSG3 = new MSGForm();
                frmMSG3.lbMsg.Text = "언어 설정을 확인할 수 없어서 한글로 인식합니다.\r\n옵션-UI-언어를 확인해주세요.\r\n\r\n게임 옵션에서 언어 변경 후 저장하시면\r\nPOE의 설정 파일에 기록됩니다.";
                frmMSG3.ShowDialog();
                g_strUILang = "KOR";
                return UI_LANG.UI_KOREAN;
            }
        }
        #endregion

        /* for Quest Helper ( Remove Temporary )
        public bool ReadDirectionHelperData()
        {
            try
            {
                jsonData = OverlayData.FromJson(File.ReadAllText(String.Format("{0}\\{1}", currentDirectory, "configuration.json")));
                return true;
            }
            catch
            {
                MSGForm frmMSG3 = new MSGForm();
                frmMSG3.lbMsg.Text = "POE Direction Helper를 실행하신 디렉토리의\r\n환경설정 파일(configuration.json)을 읽을 수 없습니다.\r\n\r\nDirectionHelper가 설치한 json 형식이 아닙니다.\r\n파일이 손상되었거나 임의로 수정되었을 수 있습니다.";
                frmMSG3.ShowDialog();
                return false;
            }
        }
        */

        #region ⨌⨌ Form Closed. - Dispose ⨌⨌
        private void ControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterHotKey(g_thisH, 2);
            UnregisterHotKey(g_thisH, 3);
            UnregisterHotKey(g_thisH, 4);
            UnregisterHotKey(g_thisH, 6);

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

            mouseHook.MouseWheel -= MouseHook_MouseWheel;
            mouseHook.Uninstall();

            keyHook.KeyDown -= KeyHook_KeyDown;
            keyHook.KeyUp -= KeyHook_KeyUp;
            keyHook.Uninstall();

            if (frmNinja != null) frmNinja.Dispose();
            if (frmStashGrid != null) frmStashGrid.Dispose();

            g_TradeMsgList.Clear();
            g_TradeMsgList = null;

            // Stop Thread Timer
            if (DeadlyLOGParingTimer != null) DeadlyLOGParingTimer.Stop();
        }
        #endregion

        #region ⨌⨌ Hooking - Mouse, Keyboard ⨌⨌
        private void KeyHook_KeyDown(GlobalLowLevelHooks.KeyboardHook.VKeys key)
        {
            if (key == GlobalLowLevelHooks.KeyboardHook.VKeys.LCONTROL)
            {
                IsControlKeyDown = true;
            }
        }

        private void KeyHook_KeyUp(GlobalLowLevelHooks.KeyboardHook.VKeys key)
        {
            if (key == GlobalLowLevelHooks.KeyboardHook.VKeys.LCONTROL)
            {
                IsControlKeyDown = false;
            }
        }

        private void MouseHook_MouseWheel(GlobalLowLevelHooks.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (mouseStruct.mouseData.ToString() == "7864320")
            {
                // Up
                if (IsControlKeyDown)
                {
                    if (handlePOE != null)
                    {
                        // CTRL + ←
                        SetForegroundWindow(handlePOE);
                        SendKeys.Send("^{LEFT}");
                        
                        /*PostMessage(handlePOE, WM_KEYDOWN, WM_CTRL, 0);
                        PostMessage(handlePOE, 0x0111, VK_LEFT, 0);
                        PostMessage(handlePOE, WM_KEYUP, WM_CTRL, 0);
                        PostMessage(handlePOE, WM_KEYUP, VK_LEFT, 0);*/
                    }
                }
            }

            // VK_RIGHT : 0x26
            IntPtr vkRight = (IntPtr)0x26;
            if (mouseStruct.mouseData.ToString() == "4287102976")
            {
                // Down
                if (IsControlKeyDown)
                {
                    if (handlePOE != null)
                    {
                        // CTRL + →
                        SetForegroundWindow(handlePOE);
                        SendKeys.Send("^{RIGHT}");

                        /*PostMessage(handlePOE, WM_KEYDOWN, WM_CTRL, 0);
                        PostMessage(handlePOE, WM_KEYDOWN, VK_RIGHT, 0);
                        PostMessage(handlePOE, WM_KEYUP, WM_CTRL, 0);
                        PostMessage(handlePOE, WM_KEYUP, VK_RIGHT, 0);*/
                    }
                }
            }
        }
        #endregion

        #region ⨌⨌ Register Hot Keys ⨌⨌
        public void Register_HotKeys()
        {
            g_thisH = FindWindow(null, "POExileDirection");

            Parse_StringToHotKey(keyMAINRemains);
            bool bRetHOT = false;
            bRetHOT = RegisterHotKey(g_thisH, 2, (uint)m_unMod, (uint)m_HotKey);
            if (!bRetHOT)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
                frmMSG.ShowDialog();
            }
            ovHRemains.fsMod = m_unMod;
            ovHRemains.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyMAINJUN);
            bRetHOT = false;
            bRetHOT = RegisterHotKey(g_thisH, 3, (uint)m_unMod, (uint)m_HotKey);
            if (!bRetHOT)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
                frmMSG.ShowDialog();
            }
            ovHJUN.fsMod = m_unMod;
            ovHJUN.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyMAINALVA);
            bRetHOT = false;
            bRetHOT = RegisterHotKey(g_thisH, 4, (uint)m_unMod, (uint)m_HotKey);
            if (!bRetHOT)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
                frmMSG.ShowDialog();
            }
            ovHALVA.fsMod = m_unMod;
            ovHALVA.hotKeys = m_HotKey;

            Parse_StringToHotKey(keyMAINZANA);
            bRetHOT = false;
            bRetHOT = RegisterHotKey(g_thisH, 6, (uint)m_unMod, (uint)m_HotKey);
            if (!bRetHOT)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "단축키 설정에 실패하였습니다.\r\n\r\n단축키를 제외한 다른 기능은 정상작동합니다.";
                frmMSG.ShowDialog();
            }
            ovHZANA.fsMod = m_unMod;
            ovHZANA.hotKeys = m_HotKey;
        }

        public void Parse_StringToHotKey(string text)
        {
            fsModifiers Modifier = fsModifiers.None;
            Keys key = 0;

            bool HasControl = false;
            bool HasAlt = false;
            bool HasShift = false;

            string[] result;
            string[] separators = new string[] { " + " };
            result = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //Iterate through the keys and find the modifier.
            foreach (string entry in result)
            {
                //Find the Control Key.
                if (entry.Trim() == Keys.Control.ToString())
                {
                    HasControl = true;
                }
                //Find the Alt key.
                if (entry.Trim() == Keys.Alt.ToString())
                {
                    HasAlt = true;
                }
                //Find the Shift key.
                if (entry.Trim() == Keys.Shift.ToString())
                {
                    HasShift = true;
                }
            }

            if (HasControl) { Modifier |= fsModifiers.Control; }
            if (HasAlt) { Modifier |= fsModifiers.Alt; }
            if (HasShift) { Modifier |= fsModifiers.Shift; }

            //Get the last key in the shortcut
            KeysConverter keyconverter = new KeysConverter();
            key = (Keys)keyconverter.ConvertFrom(result.GetValue(result.Length - 1));

            m_HotKey = key;
            m_unMod = Modifier;
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
            iSim.Keyboard.KeyPress(VirtualKeyCode.MENU);

            // Make POE the foreground application and send input
            SetForegroundWindow(handlePOE);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/remaining");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            iSim = null;

            SetForegroundWindow(handlePOE);
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
            SetForegroundWindow(handlePOE);

            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            // Send the input
            iSim.Keyboard.TextEntry("/hideout");

            // Send RETURN
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            iSim = null;

            SetForegroundWindow(handlePOE);
        }
        #endregion

        #region ⨌⨌ Init. Form Location ⨌⨌
        public void Init_ControlFormPosition()
        {
            string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            try
            {
                string sLeft = parser.GetSetting("LOCATIONMAIN", "LEFT");
                string sTop = parser.GetSetting("LOCATIONMAIN", "TOP");

                if (sLeft != "CENTER" && sTop != "CENTER")
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Left = Int32.Parse(sLeft);
                    this.Top = Int32.Parse(sTop);
                }

                string strPath = "";
                strPath = parser.GetSetting("DIRECTIONHELPER", "POELOGPATH");

                // Get Image Path
                strImagePath[0] = parser.GetSetting("OVERLAY", "JUN"); // @".\DeadlyInform\Betrayal.png";   // JUN
                if(strImagePath[0]=="")
                    strImagePath[0] = @".\DeadlyInform\Betrayal.png";

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

                if (File.Exists(strPath))
                {
                    ;
                }
                else
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "패스 오브 엑자일 경로가 맞지 않습니다.\r\n경로를 설정해주세요.";
                    frmMSG.ShowDialog();
                    FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                    DialogResult dr = dlgFolder.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        // strPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\Client.txt");
                        strPath = String.Format("{0}\\{1}", dlgFolder.SelectedPath, "logs\\TESTClient.txt");
                    }
                    else
                    {
                        this.Close();
                        Environment.Exit(0);
                    }

                    // Set Ini.
                    parser.AddSetting("DIRECTIONHELPER", "POELOGPATH", strPath);
                    parser.SaveSettings();
                }
            }
            catch
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "환경 파일을 읽을 수 없습니다.\r\n\r\nini 파일이 손상되었거나 삭제되었습니다.";
                frmMSG.ShowDialog();
                this.Close();
                Environment.Exit(0);
            }
        }
        #endregion

        #region ⨌⨌ QUEST, JUN, ALVA, ZANA Buttons Action ⨌⨌
        private void Button1_Click(object sender, EventArgs e)
        {
            // Quest Helper
            MainForm_Show_Hide("DEFAULT");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
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
            // TO DO
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

            SetForegroundWindow(handlePOE);
        }
        #endregion

        #region ⨌⨌ Settings Form ⨌⨌
        private void Button6_Click(object sender, EventArgs e)
        {
            // TO DO
            SettingsForm frmSettings = new SettingsForm();
                frmSettings.keyRemains = keyMAINRemains;
                frmSettings.keyJUN = keyMAINJUN;
                frmSettings.keyALVA = keyMAINALVA;
                frmSettings.keyZANA = keyMAINZANA;
            if (frmSettings.ShowDialog() == DialogResult.OK)
            {
                keyMAINRemains = frmSettings.keyRemains;
                keyMAINJUN = frmSettings.keyJUN;
                keyMAINALVA = frmSettings.keyALVA;
                keyMAINZANA = frmSettings.keyZANA;

                UnregisterHotKey(g_thisH, 2);
                UnregisterHotKey(g_thisH, 3);
                UnregisterHotKey(g_thisH, 4);
                UnregisterHotKey(g_thisH, 6);

                Register_HotKeys();

                string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
                IniParser parser = new IniParser(strINIPath);
                parser.AddSetting("HOTKEY", "R", keyMAINRemains);
                parser.AddSetting("HOTKEY", "J", keyMAINJUN);
                parser.AddSetting("HOTKEY", "A", keyMAINALVA);
                parser.AddSetting("HOTKEY", "Z", keyMAINZANA);
                parser.SaveSettings();
            }
        }
        #endregion

        #region Form moving by PanelTop ⨌⨌
        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
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
            string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATIONMAIN", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONMAIN", "TOP", this.Top.ToString());
            parser.SaveSettings();

            SetForegroundWindow(handlePOE);
        }
        #endregion

        #region ⨌⨌ Image Overlay Show/Hide ⨌⨌

        public void MainForm_Show_Hide(string strDoShow)
        {
            SetForegroundWindow(handlePOE);
            if (strDoShow == "Y")
            {
                bMainFormActivated = true;
                frmMainForm.Show();
            }
            else if (strDoShow == "N")
            {
                bMainFormActivated = false;
                frmMainForm.Hide();
            }
            else
            {
                if (!bMainFormActivated)
                {
                    bMainFormActivated = true;
                    frmMainForm.Show();
                }
                else
                {
                    bMainFormActivated = false;
                    frmMainForm.Hide();
                }
            }
            SetForegroundWindow(handlePOE);
        }

        public void IMGOverlayForm_Show_Hide(int nWhat)
        {
            SetForegroundWindow(handlePOE);

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

            SetForegroundWindow(handlePOE);
        }
        #endregion

        #region ⨌⨌ STASH GRID ⨌⨌
        private void BtnStashGrid_Click(object sender, EventArgs e)
        {
            if (!bfrmStashGridShow)
            {
                bfrmStashGridShow = true;
                frmStashGrid = new StashGrid();
                frmStashGrid.Show();
            }
            else
            {
                bfrmStashGridShow = false;
                frmStashGrid.Close();
            }
            SetForegroundWindow(handlePOE);
        }
        #endregion

        #region ⨌⨌ (Like) Form System Button : Min,Max,Close ⨌⨌
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            if (bIsMinimized == false)
            {
                bIsMinimized = true;

                this.Size = new Size(56, 66);

                this.btnClose.Hide();
                this.btnMinimize.Location = new Point(35, 0);
                this.btnMinimize.BackgroundImage = Properties.Resources.sysMaxPOEBg;
            }
            else
            {
                bIsMinimized = false;

                this.Size = new Size(336, 66);
                this.btnClose.Show();
                this.btnMinimize.Location = new Point(295, 0);
                this.btnMinimize.BackgroundImage = Properties.Resources.sysMinPOEBg1;
            }
            SetForegroundWindow(handlePOE);
        }
        #endregion
    }
}
