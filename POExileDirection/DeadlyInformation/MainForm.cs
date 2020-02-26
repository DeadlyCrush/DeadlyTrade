using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace POExileDirection
{
    public partial class MainForm : Form
    {
        bool bSeedFound = false;
        private bool bIsMinimized = false;
        public bool partTwo = false;

        int nMoving  = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        UI_LANG nUILang;

        OverlayData[] jsonData;
        string currentDirectory = null;

        public string zoneName;

        string actString = null;

        string btnLangText = null;

        string[] separatingStrings = { "Act " };

        public MainForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";

            Init_Controls();
        }

        #region ⨌⨌ Init. Controls. ⨌⨌
        private void Init_Controls()
        {
            // btnClose
            btnLang.FlatStyle = FlatStyle.Flat;
            btnLang.BackColor = Color.Transparent;
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

            bIsMinimized = false;

            bool bRet = ReadDirectionHelperData();
            if (bRet == false)
            {
                this.Close();
                Application.Exit();
            }

            /*
            [DIRECTIONHELPER]
            POELOGPATH="SET"        
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
                noteLabel.Text = "";
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
                    StartPosition = FormStartPosition.Manual;
                    Left = Int32.Parse(sLeft);
                    Top = Int32.Parse(sTop);
                }
            }
            catch
            {
                StartPosition = FormStartPosition.Manual;
                Left = 0;
                Top = 0;
            }

            if (actString == "?")
                actString = DeadlyZoneInform.GetActROMAbyZoneName(zoneName, partTwo);

            if (actString == "I" || actString == "II" || actString == "III" || actString == "IV" || actString == "V")
            {
                //parser.AddSetting("INITPART", "LASTPART", "1");
                noteLabel.Text = "마을입니다.";
            }
            else if (actString == "VI" || actString == "VII" || actString == "VIII" || actString == "IX" || actString == "X")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                noteLabel.Text = "마을입니다.";
            }
            else if (actString == "O")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                noteLabel.Text = "액트 클리어를 축하드립니다.";
            }
            else if (actString == "Z")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                noteLabel.Text = "지도의 대가 자나를 만나보세요.";
            }
            else if (actString == "H")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                noteLabel.Text = "멋진 은신처군요~!";
            }
            else
            {
                //parser.AddSetting("INITPART", "LASTPART", "3");
                noteLabel.Text = "정보가 없습니다. (더블클릭시에도 나타나지 않으면 지역 정보가 충분히 파악되지 않았거나, 정보가 없어도 진행이 가능한 지역입니다.)";
            }
            //parser.AddSetting("INITPART", "zoneName", zoneName);
            //parser.AddSetting("INITPART", "actString", actString);
            //parser.SaveSettings();

            btnLangText = String.Format("Act {0} : {1}", actString, zoneName);
            btnLang.Text = btnLangText;

            if (LauncherForm.g_strUILang == "KOR")
                nUILang = UI_LANG.UI_KOREAN;
            else if (LauncherForm.g_strUILang == "ENG")
                nUILang = UI_LANG.UI_ENGLISH;
            else
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.btmConfirm.Visible = false;
                frmMSG.btnENG.Visible = true;
                frmMSG.btnKOR.Visible = true;
                frmMSG.lbMsg.Text = "Can't find POE UI Configuration. What is your OPTION-UI Languge in POE?" +
                    "\r\n\r\n(언어 설정을 확인할 수 없습니다. 옵션-UI에서 어떤 언어를 사용하고 계신가요?)";
                DialogResult dr = frmMSG.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    LauncherForm.g_strUILang = "KOR";
                    LauncherForm.g_strExplanationLANG = LauncherForm.g_strUILang;

                    nUILang = UI_LANG.UI_KOREAN;
                }
                else
                {
                    LauncherForm.g_strUILang = "ENG";
                    LauncherForm.g_strExplanationLANG = LauncherForm.g_strUILang;

                    nUILang = UI_LANG.UI_ENGLISH;
                }
            }
        }

        public bool ReadDirectionHelperData()
        {
            try
            {
                jsonData = OverlayData.FromJson(File.ReadAllText(String.Format("{0}\\{1}", currentDirectory, "ActHelper.json")));
                return true;
            }
            catch
            {
                MSGForm frmMSG3 = new MSGForm();
                frmMSG3.lbMsg.Text = "POE Direction Helper를 실행하신 디렉토리의\r\n환경설정 파일(ActHelper.json)을 읽을 수 없습니다.\r\n\r\nDirectionHelper가 설치한 json 형식이 아닙니다.\r\n파일이 손상되었거나 임의로 수정되었을 수 있습니다.";
                frmMSG3.ShowDialog();
                return false;
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

            parser.AddSetting("LOCATION", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATION", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        /*private void DrawMap(string image, string note, int nCount)
        {
            pictureBox1.Load(image);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }*/

        public void DrawPartOneImage()
        {
            string image = null;

            if (zoneName!=null && zoneName.Length>0 && zoneName!=String.Empty)
            {
                actString = "?";

                bSeedFound = false;

                PictureBox[] picBox = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
                image = String.Format("{0}\\Overlays\\{1}.jpg", currentDirectory, "no_overlay");

                InitMapImage(); // Clear Map Image

                // Attempt to find a corresponding zoneName 
                var seedList = FindZoneName(zoneName);
                int nIndex = 0;
                if (seedList.Item2.Length > 0)
                {
                    foreach (var seed in seedList.Item2)
                    {
                        actString = seedList.Item1;
                        string[] actROMA = actString.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                        actString = actROMA[0];
                        image = String.Format("{0}\\Overlays\\{1}\\{2}.jpg", currentDirectory, seedList.Item1, seed);
                        if (!File.Exists(image))
                            image = String.Format("{0}\\Overlays\\{1}\\bug.jpg", currentDirectory, seedList.Item1);

                        // IMAGE
                        picBox[nIndex].Load(image);
                        picBox[nIndex].SizeMode = PictureBoxSizeMode.StretchImage;

                        // TEXT
                        noteLabel.Text = seedList.Item3;
                        bSeedFound = true;

                        nIndex++;
                    }
                }

                /*string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

                if (LauncherForm.resolution_width < 1920 && LauncherForm.resolution_height < 1080)
                {
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                    if (LauncherForm.resolution_width < 1600 && LauncherForm.resolution_height < 1024)
                        strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini");
                }
                IniParser parser = new IniParser(strINIPath);*/
                if (actString == "?")
                {
                    actString = DeadlyZoneInform.GetActROMAbyZoneName(zoneName, partTwo);
                }

                if (actString == "I" || actString == "II" || actString == "III" || actString == "IV" || actString == "V")
                {
                    //parser.AddSetting("INITPART", "LASTPART", "1");
                    if(!bSeedFound) noteLabel.Text = "마을입니다.";
                }
                else if (actString == "VI" || actString == "VII" || actString == "VIII" || actString == "IX" || actString == "X")
                {
                    //parser.AddSetting("INITPART", "LASTPART", "2");
                    if (!bSeedFound) noteLabel.Text = "마을입니다.";
                }
                else if (actString == "O")
                {
                    //parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "액트 클리어를 축하드립니다.";
                }
                else if (actString == "Z")
                {
                    //parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "지도의 대가 자나를 만나보세요.";
                }
                else if (actString == "H")
                {
                    //parser.AddSetting("INITPART", "LASTPART", "2");
                    noteLabel.Text = "멋진 은신처군요~!";
                }
                else
                {
                    //parser.AddSetting("INITPART", "LASTPART", "3");
                    noteLabel.Text = "정보가 없습니다. (더블클릭시에도 나타나지 않으면 지역 정보가 충분히 파악되지 않았거나, 정보가 없어도 진행이 가능한 지역입니다.)";
                }
                //parser.AddSetting("INITPART", "zoneName", zoneName);
                //parser.AddSetting("INITPART", "actString", actString);
                //parser.SaveSettings();

                btnLangText = String.Format("Act {0} : {1}", actString, zoneName);
                btnLang.Text = btnLangText;
            }
        }

        public void InitMapImage()
        {
            PictureBox[] picBox = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            string image = String.Format("{0}\\Overlays\\{1}.jpg", currentDirectory, "no_overlay_empty");

            // Clear
            /*for (int i = 0; i < 3; i++)
            {
                picBox[i].Load(image);
                picBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            image = String.Format("{0}\\Overlays\\{1}.jpg", currentDirectory, "no_overlay");
            picBox[3].Load(image);
            picBox[3].SizeMode = PictureBoxSizeMode.StretchImage;*/

            // All Clean
            for (int i = 0; i < 4; i++)
            {
                picBox[i].Load(image);
                picBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            image = String.Format("{0}\\Overlays\\{1}.jpg", currentDirectory, "no_overlay");
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
                                    return Tuple.Create(region.Region, zone.ZoneSeed, zone.eng);
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
            image = String.Format("{0}\\Overlays\\{1}.jpg", currentDirectory, "no_overlay");

            var seedList = FindZoneName(zoneName);
            int nIndex = 0;
            
            if (seedList.Item2.Length > 0)
            {
                foreach (var seed in seedList.Item2)
                {
                    actString = seedList.Item1;
                    string[] actROMA = actString.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    actString = actROMA[0];
                    image = String.Format("{0}\\Overlays\\{1}\\{2}.jpg", currentDirectory, seedList.Item1, seed);

                    if (!File.Exists(image))
                        image = String.Format("{0}\\Overlays\\{1}\\bug.jpg", currentDirectory, seedList.Item1);

                    // IMAGE
                    picBox[nIndex].Load(image);
                    picBox[nIndex].SizeMode = PictureBoxSizeMode.StretchImage;

                    // TEXT
                    noteLabel.Text = seedList.Item3;
                    bSeedFound = true;

                    nIndex++;
                }
            }

            /*string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

            if (LauncherForm.resolution_width < 1920 && LauncherForm.resolution_height < 1080)
            {
                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                if (LauncherForm.resolution_width < 1600 && LauncherForm.resolution_height < 1024)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini");
            }
            IniParser parser = new IniParser(strINIPath);*/
            if (actString == "?")
                actString = DeadlyZoneInform.GetActROMAbyZoneName(zoneName, partTwo);

            if (actString == "I" || actString == "II" || actString == "III" || actString == "IV" || actString == "V")
            {
                //parser.AddSetting("INITPART", "LASTPART", "1");
                if (!bSeedFound) noteLabel.Text = "마을입니다.";
            }
            else if (actString == "VI" || actString == "VII" || actString == "VIII" || actString == "IX" || actString == "X")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                if (!bSeedFound) noteLabel.Text = "마을입니다.";
            }
            else if (actString == "O")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                noteLabel.Text = "액트 클리어를 축하드립니다.";
            }
            else if (actString == "Z")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                noteLabel.Text = "지도의 대가 자나를 만나보세요.";
            }
            else if (actString == "H")
            {
                //parser.AddSetting("INITPART", "LASTPART", "2");
                noteLabel.Text = "멋진 은신처군요~!";
            }
            else
            {
                //parser.AddSetting("INITPART", "LASTPART", "3");
                noteLabel.Text = "정보가 없습니다. (더블클릭시에도 나타나지 않으면 지역 정보가 충분히 파악되지 않았거나, 정보가 없어도 진행이 가능한 지역입니다.)";
            }
            //parser.AddSetting("INITPART", "zoneName", zoneName);
            //parser.AddSetting("INITPART", "actString", actString);
            //parser.SaveSettings();

            btnLangText = String.Format("Act {0} : {1}", actString, zoneName);
            btnLang.Text = btnLangText;
        }

        private void BtnLang_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void BtnLang_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX - 92, MousePosition.Y - nMovePosY);
            }
        }

        private void BtnLang_MouseUp(object sender, MouseEventArgs e)
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

            parser.AddSetting("LOCATION", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATION", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        /*private void BtnMin_Click(object sender, EventArgs e)
        {
            if (bIsMinimized)
            {
                btnMin.BackgroundImage = Properties.Resources.sysMinPOEBg1;
                Height = 139;
                bIsMinimized = false;
            }
            else
            {
                btnMin.BackgroundImage = Properties.Resources.sysMaxPOEBg;
                Height = 18;

                bIsMinimized = true;
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            ControlForm.g_bIsDropInformOn = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            // Dispose.
            Close();
        }

        private void btnUILANG_Click(object sender, EventArgs e)
        {
            partTwo = !partTwo;

            InitMapImage(); // Clear Map Image
            DrawPartTwoImage();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Dispose();
            pictureBox2.Dispose();
            pictureBox3.Dispose();
            pictureBox4.Dispose();
        }
    }
}
