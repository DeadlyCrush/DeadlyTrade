using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace POExileDirection
{
    public partial class MainForm : Form
    {
        bool bSeedFound = false;
        private bool bIsMinimized = false;
        private bool partTwo = false;

        int nMoving  = 0;
        int nMovePosX = 0;
        int nMovePosY = 0;

        UI_LANG nUILang;
        string g_strUILang = null;
        Regex RegExZoneEntered;

        Regex RegExMonsterRemains; // ENG : 3 monsters remain. KOR : 몬스터 3개체가 남아있습니다.
        Regex RegExMonsterRemainsKORMore; // : 몬스터가 (.*)개체 이상 남아있습니다.
        Regex RegExMonsterRemainsENGMore; // : More than 50 monsters remain.

        OverlayData[] jsonData;
        string currentDirectory = null;

        FileStream fileStream;
        StreamReader logStream;

        string zoneName = null;
        string actString = null;

        string btnLangText = null;

        string[] separatingStrings = { "Act " };
        Common commonClass = new Common();

        bool bShowSettingButtons = false;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "POExileDirection";

            btnLang.DoubleClick += BtnLang_DoubleClick;

            Init_Controls();
            commonClass.InitActZoneDictionary();
        }

        private void BtnSettings_DoubleClick(object sender, EventArgs e)
        {
            SettingsForm frmSettings = new SettingsForm();
            frmSettings.Show();
        }

        #region ⨌⨌ Init. Controls. ⨌⨌
        private void Init_Controls()
        {
            // btnClose
            btnLang.FlatStyle = FlatStyle.Flat;
            btnLang.BackColor = Color.Transparent;
            btnLang.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLang.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLang.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnLang.FlatAppearance.BorderSize = 0;
            btnLang.TabStop = false;
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            // On Working Monitor
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            CenterToScreen();
            this.TopMost = true;
            zoneName = "?";
            actString = "?";

            currentDirectory = Application.StartupPath;

            bool bRet = ReadDirectionHelperData();
            if (bRet == false)
            {
                this.Close();
                Environment.Exit(0);
            }
            
            /*
            [DIRECTIONHELPER]
            POELOGPATH="SET"        
            */
            
            string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            string strPath = "";
            try
            {
                strPath = parser.GetSetting("DIRECTIONHELPER", "POELOGPATH");
                zoneName = parser.GetSetting("INITPART", "zoneName");
                actString = parser.GetSetting("INITPART", "actString");
                this.noteLabel.Text = "";
                string strLastPart = parser.GetSetting("INITPART", "LASTPART");
                if (strLastPart == "1")
                    partTwo = false;
                else if (strLastPart == "2")
                    partTwo = true;

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
                this.Close();
                Environment.Exit(0);
            }

            if (File.Exists(strPath))
            {
                try
                {
                    fileStream = File.Open(strPath, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.ReadWrite);
                    logStream = new StreamReader(fileStream);
                }
                catch
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "패스 오브 엑자일 로그파일을 읽는 도중 오류가 발생했습니다. ‼‼‼";
                    frmMSG.ShowDialog();
                    this.Close();
                    Environment.Exit(0);
                }

                if (actString == "?")
                    actString = commonClass.GetActROMAbyZoneName(zoneName, partTwo);

                if (actString == "I" || actString == "II" || actString == "III" || actString == "IV" || actString == "V")
                {
                    parser.AddSetting("INITPART", "LASTPART", "1");
                    noteLabel.Text = "마을입니다.";
                }
                else if (actString == "VI" || actString == "VII" || actString == "VIII" || actString == "IX" || actString == "X")
                {
                    parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "마을입니다.";
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

                Check_UILanguageWrapping();

                // Move to the end of the file
                fileStream.Seek(-512, SeekOrigin.End);

                // Start watching client log file
                zoneWatcher.Enabled = true;
            }
            else
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "패스 오브 엑자일 경로가 맞지 않습니다.\r\n경로를 설정해주세요.";
                frmMSG.ShowDialog();
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                DialogResult dr = dlgFolder.ShowDialog();
                if(dr == DialogResult.OK)
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

                try
                {
                    fileStream = File.Open(strPath, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.ReadWrite);
                    logStream = new StreamReader(fileStream);
                }
                catch
                {
                    MSGForm frmMSG2 = new MSGForm();
                    frmMSG2.lbMsg.Text = "패스 오브 엑자일 로그파일을 읽는 도중 오류가 발생했습니다. ‼‼‼";
                    frmMSG2.ShowDialog();
                    this.Close();
                    Environment.Exit(0);
                }

                if (actString == "?")
                    actString = commonClass.GetActROMAbyZoneName(zoneName, partTwo);

                if (actString == "I" || actString == "II" || actString == "III" || actString == "IV" || actString == "V")
                {
                    parser.AddSetting("INITPART", "LASTPART", "1");
                    noteLabel.Text = "마을입니다.";
                }
                else if (actString == "VI" || actString == "VII" || actString == "VIII" || actString == "IX" || actString == "X")
                {
                    parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "마을입니다.";
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

                Check_UILanguageWrapping();
                
                // Move to the end of the file
                fileStream.Seek(-512, SeekOrigin.End);

                // Start watching client log file
                zoneWatcher.Enabled = true;
            }
        }

        public void Check_UILanguageWrapping()
        {
            nUILang = CheckPOEUILanguage();

            if (nUILang == UI_LANG.UI_ERROR) // Can't Read UI Language from POE Config File
            {
                this.Close();
                Environment.Exit(0);
            }
            else if (nUILang == UI_LANG.UI_KOREAN)
            {
                RegExZoneEntered = new Regex(@": (.*)에 진입했습니다.", RegexOptions.IgnoreCase); // for Korean Client. ex) [INFO Client 14932] : 오아시스에 진입했습니다.
                RegExMonsterRemains = new Regex(@": 몬스터 (.*)개체가 남아있습니다."); // : 몬스터 0개체가 남아있습니다.
                RegExMonsterRemainsKORMore = new Regex(@": 몬스터가 (.*)개체 이상 남아있습니다."); // : 몬스터가 50개체 이상 남아있습니다.

            }
            else if (nUILang == UI_LANG.UI_ENGLISH)
            {
                RegExZoneEntered = new Regex(@"You have entered (.*)\.", RegexOptions.IgnoreCase);
                RegExMonsterRemains = new Regex(@": (.*) monsters remain."); // : 3 monsters remain.
                RegExMonsterRemainsENGMore = new Regex(@": More than (.*) monsters remain."); // : More than 50 monsters remain.
            }
        }

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

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if(nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
            string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATION", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATION", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            // Dispose.
            this.Close();
            Environment.Exit(0);
        }

        private void DrawMap(string image, string note, int nCount)
        {
            pictureBox1.Load(image);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ReadNewLines_Timer(object sender, EventArgs e)
        {
            // Read new line every 200 ms and detect zone...
            string line = logStream.ReadToEnd();
            string image = null;

            Match mRemains = RegExMonsterRemains.Match(line);
            if (mRemains.Success)
            {
                string strRemains = "?";

                strRemains = mRemains.Groups[1].ToString();
                if (strRemains.Contains("More")) strRemains = "50+";

                RemainingForm formMonster = new RemainingForm();
                formMonster.lbRemain.Text = strRemains;
                formMonster.Show();
            }

            Match mRemainsKORMore = null;
            if (g_strUILang=="KOR")
                mRemainsKORMore = RegExMonsterRemainsKORMore.Match(line);
            else if (g_strUILang == "ENG")
                mRemainsKORMore = RegExMonsterRemainsENGMore.Match(line);

            if (mRemainsKORMore.Success)
            {
                string strRemainsMore = "50+";

                RemainingForm formMonster = new RemainingForm();
                formMonster.lbRemain.Text = strRemainsMore;
                formMonster.Show();
            }

            Match m = RegExZoneEntered.Match(line);

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
                    if(!bSeedFound) noteLabel.Text = "마을입니다.";
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
        }

        public void InitMapImage()
        {
            PictureBox[] picBox = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            string image = String.Format("{0}\\Overlays\\{1}.png", currentDirectory, "no_overlay_empty");

            // Clear
            /*for (int i = 0; i < 3; i++)
            {
                picBox[i].Load(image);
                picBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            image = String.Format("{0}\\Overlays\\{1}.png", currentDirectory, "no_overlay");
            picBox[3].Load(image);
            picBox[3].SizeMode = PictureBoxSizeMode.StretchImage;*/

            // All Clean
            for (int i = 0; i < 4; i++)
            {
                picBox[i].Load(image);
                picBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            image = String.Format("{0}\\Overlays\\{1}.png", currentDirectory, "no_overlay");
        }

        private Tuple<string, object[], string> FindZoneName(string zoneName)
        {
            bool firstHit = false;
            foreach (var region in jsonData)
                if (region.clientLogFile != null)
                {
                    continue;
                }
                else
                {
                    foreach (var zone in region.Zone)
                    {
                        if (nUILang == UI_LANG.UI_KOREAN)
                        {
                            // if PartTwo is enabled, skip first entry...
                            if (zone.ZoneName.Equals(zoneName))
                            {
                                if (partTwo && !firstHit)
                                {
                                    firstHit = true;
                                }
                                else
                                {
                                    return Tuple.Create(region.Region, zone.ZoneSeed, zone.Note);
                                }

                            }
                        }
                        else
                        {
                            // Added by DeadlyCursh for support all UI : KOR and ENG
                            if (zone.zoneNameENG.Equals(zoneName))
                            {
                                if (partTwo && !firstHit)
                                {
                                    firstHit = true;
                                }
                                else
                                {
                                    return Tuple.Create(region.Region, zone.ZoneSeed, zone.Note);
                                }

                            }
                        }
                    }
                }

            return Tuple.Create("", new object[0], "");
        }

        public void DrawPartTwoImage()
        {
            bSeedFound = false;

            string image = null;
            PictureBox[] picBox = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            image = String.Format("{0}\\Overlays\\{1}.png", currentDirectory, "no_overlay");

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
                actString = commonClass.GetActROMAbyZoneName(zoneName, partTwo);

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

        private void BtnLang_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
            {
                if (bIsMinimized == false)
                    BtnLang_DoubleClick(sender, e);
            }
            else
            {
                nMoving = 1;
                nMovePosX = e.X;
                nMovePosY = e.Y;
            }
        }

        private void BtnLang_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void BtnLang_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
            string strINIPath = String.Format("{0}\\{1}", currentDirectory, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATION", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATION", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        private void BtnLang_DoubleClick(object sender, EventArgs e)
        {
            partTwo = !partTwo;

            InitMapImage(); // Clear Map Image
            DrawPartTwoImage();
        }

        private void BtnSettings_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                BtnSettings_DoubleClick(sender, e);
            else
            {
                bShowSettingButtons = !bShowSettingButtons;
            }
        }
    }
}
