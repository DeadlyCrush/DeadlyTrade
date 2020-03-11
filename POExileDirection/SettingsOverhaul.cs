using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class SettingsOverhaul : Form
    {
        #region [[[[[ Global Variables ]]]]]
        // HOT KEYS
        public string keyRemains;
        public string keyJUN;
        public string keyALVA;
        public string keyZANA;
        public string keyHideout;
        public string keySearchbyPosition;
        public string keyEXIT;
        public string keyInvite;
        public string keyTrade;
        public string keyKick;
        public string keyMinimize;
        public string keyClose;
        public string keySold;
        public string keyWait;
        public string keyThx;

        // Timer Color
        public string colorStringRGB1;
        public string colorStringRGB2;
        public string colorStringRGB3;
        public string colorStringRGB4;
        public string colorStringRGB5;

        public string colorStringRGBQ;
        public string colorStringRGBW;
        public string colorStringRGBE;
        public string colorStringRGBR;
        public string colorStringRGBT;

        // DRAG
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        // INIT FLAG
        private bool bTab1 = false;
        private bool bTab2 = false;
        private bool bTab3 = false;
        private bool bTab4 = false;
        private bool bTab5 = false;
        private bool bTab6 = false;
        private bool bTab7 = false;

        int _nInitCNT = 0;
        #endregion

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

        public SettingsOverhaul()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void SettingsOverhaul_Load(object sender, EventArgs e)
        {
            Visible = false;
            TopMost = true;
            ShowInTaskbar = false;

            timer1.Start();
            Visible = true;

            GetHotkeySettings();                // TAB 1
            _nInitCNT = _nInitCNT + 1;
            GetTradeNotificationSettings();     // TAB 2
            _nInitCNT = _nInitCNT + 1;
            GetFlaskAndSkllTimerSettings();     // TAB 3,4
            _nInitCNT = _nInitCNT + 1;
            GetFlaskAndSkllTimerSettings();     // TAB 3,4
            _nInitCNT = _nInitCNT + 1;
            GetOverlaySettings();               // TAB 5
            _nInitCNT = _nInitCNT + 1;
            GetHelpSettings();                  // TAB 6
            _nInitCNT = _nInitCNT + 1;
            GetHallOfFameSettings();            // TAB 7
            _nInitCNT = _nInitCNT + 1;
        }

        #region [[[[[ Utility Functions ]]]]]
        private Color StringRGBToColor(string color)
        {
            var arrColorFragments = color?.Split(',').Select(sFragment => { _ = int.TryParse(sFragment, out int fragment); return fragment; }).ToArray();

            switch (arrColorFragments?.Length)
            {
                case 3:
                    return Color.FromArgb(255, arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]);
                case 4:
                    return Color.FromArgb(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]);
                default:
                    return Color.Transparent;
            }
        }

        private void Set_FlaskImageList()
        {
            try
            {
                // Set ImageList
                var imageList = new ImageList();
                foreach (var obj in DeadlyTranslation.FlaskImgPath)
                {
                    try
                    {
                        imageList.Images.Add(Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\" + obj.Value));
                    }
                    catch (Exception ex)
                    {
                        DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                    }

                }

                listViewFlaskImage.View = View.LargeIcon;
                imageList.ImageSize = new Size(30, 60);
                imageList.ColorDepth = ColorDepth.Depth32Bit;
                this.listViewFlaskImage.LargeImageList = imageList;

                // Add Item
                for (int j = 0; j < imageList.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.BackColor = Color.FromArgb(39, 44, 56);
                    item.ImageIndex = j;
                    listViewFlaskImage.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }
        #endregion

        #region [[[[[ GetHotkeySettings() ]]]]]
        private void GetHotkeySettings()
        {
            // HOTKEYS
            textRemains.Text = keyRemains;
            textJUN.Text = keyJUN;
            textALVA.Text = keyALVA;
            textZANA.Text = keyZANA;
            textHideout.Text = keyHideout;
            textBoxPositionSearch.Text = keySearchbyPosition;
            textBoxEXIT.Text = keyEXIT;

            // HOTKEYS - Trade Panel.
            btnS.Text = LauncherForm.g_strnotiSOLDbtnTITLE;
            btnW.Text = LauncherForm.g_strnotiWAITbtnTITLE;
            btnT.Text = LauncherForm.g_strnotiDONEbtnTITLE;
            
            textHotKeyInvite.Text = keyInvite;
            textHotKeyTradeRequest.Text = keyTrade;
            textHotKeyKickLeave.Text = keyKick;
            textHotKeyPanelMinimize.Text = keyMinimize;
            textHotKeyPanelClose.Text = keyClose;
            textHotKeySold.Text = keySold;
            textHotKeyWait.Text = keyWait;
            textHotKeyThx.Text = keyThx;

            // HotKey Use
            if (LauncherForm.g_strYNUseRemainingHOTKEY == "Y")
                checkRemaining.Checked = true;
            else
                checkRemaining.Checked = false;
            if (LauncherForm.g_strYNUseSyndicateJUNHOTKEY == "Y")
                checkSyndicateJUN.Checked = true;
            else
                checkSyndicateJUN.Checked = false;
            if (LauncherForm.g_strYNUseIncursionALVAHOTKEY == "Y")
                checkTempleALVA.Checked = true;
            else
                checkTempleALVA.Checked = false;
            if (LauncherForm.g_strYNUseAtlasZANAHOTKEY == "Y")
                checkAtlasZANA.Checked = true;
            else
                checkAtlasZANA.Checked = false;
            if (LauncherForm.g_strYNUseHideoutHOTKEY == "Y")
                checkHideout.Checked = true;
            else
                checkHideout.Checked = false;
            if (LauncherForm.g_strYNUseFindbyPositionHOTKEY == "Y")
                checkFindbyPosition.Checked = true;
            else
                checkFindbyPosition.Checked = false;
            if (LauncherForm.g_strYNUseEmergencyHOTKEY == "Y")
                checkEmergency.Checked = true;
            else
                checkEmergency.Checked = false;

            // CTRL+MOUSEWHEEL
            if (LauncherForm.g_strYNMouseWheelStashTab == "Y")
                checkMouseWheel.Checked = true;
            else
                checkMouseWheel.Checked = false;

            // HotKey Use - Trade Panel.
            if (LauncherForm.g_strYNUseHOTKEYInvite == "Y")
                checkInvite.Checked = true;
            else
                checkInvite.Checked = false;
            if (LauncherForm.g_strYNUseHOTKEYTrade == "Y")
                checkTrade.Checked = true;
            else
                checkTrade.Checked = false;
            if (LauncherForm.g_strYNUseHOTKEYKick == "Y")
                checkUseHotkeyKick.Checked = true;
            else
                checkUseHotkeyKick.Checked = false;
            if (LauncherForm.g_strYNUseHOTKEYMinimize == "Y")
                checkTradePanelMinimize.Checked = true;
            else
                checkTradePanelMinimize.Checked = false;
            if (LauncherForm.g_strYNUseHOTKEYClose == "Y")
                checkTradePanelClose.Checked = true;
            else
                checkTradePanelClose.Checked = false;
            if (LauncherForm.g_strYNUseHOTKEYSold == "Y")
                checkHotkeySold.Checked = true;
            else
                checkHotkeySold.Checked = false;
            if (LauncherForm.g_strYNUseHOTKEYWait == "Y")
                checkHotkeyWait.Checked = true;
            else
                checkHotkeyWait.Checked = false;
            if (LauncherForm.g_strYNUseHOTKEYThx == "Y")
                checkHotkeyThx.Checked = true;
            else
                checkHotkeyThx.Checked = false;
        }
        #endregion

        #region [[[[[ GetTradeNotificationSettings() ]]]]]
        private void GetTradeNotificationSettings()
        {
            // Use Sound Alert when Panel Pop.
            xuiSliderVolumeTrade.Percentage = LauncherForm.g_NotifyVolume;
            xuiSliderVolumeTrade.FilledColor = Color.Tan;
            labelTradeVolume.Text = "Volume = " + xuiSliderVolumeTrade.Percentage.ToString();

            if (LauncherForm.g_strNotificationSoundYN == "Y")
            {
                btnSOUNDTrade.Image = Properties.Resources.Volume_16x16;
                labelSNDOnOff.ForeColor = Color.FromArgb(235, 182, 111);
                labelSNDOnOff.Text = "ON";
                xuiSwitchSoundTrade.SwitchState = XanderUI.XUISwitch.State.On;
            }
            else
            {
                btnSOUNDTrade.Image = Properties.Resources.Volume_16x16_Mute;
                labelSNDOnOff.ForeColor = Color.FromArgb(28, 21, 16);
                labelSNDOnOff.Text = "OFF";
                xuiSwitchSoundTrade.SwitchState = XanderUI.XUISwitch.State.Off;
            }

            // AUTO KICK or LEAVE
            textBoxCharacterNick.Text = LauncherForm.g_strMyNickName;
            if (LauncherForm.g_strTRAutoKickWait.Trim().ToUpper() == "Y")
                checkBoxAutoKickWAIT.Checked = true;
            else
                checkBoxAutoKickWAIT.Checked = false;
            
            if (LauncherForm.g_strTRAutoKickSold.Trim().ToUpper() == "Y")
                checkBoxAutoKickSOLD.Checked = true;
            else
                checkBoxAutoKickSOLD.Checked = false;

            if (LauncherForm.g_strTRAutoKick.Trim().ToUpper() == "Y")
                checkBoxAutoKickTHX.Checked = true;
            else
                checkBoxAutoKickTHX.Checked = false;

            if (LauncherForm.g_strTRAutoKickCustom1.Trim().ToUpper() == "Y")
                checkBoxAutoKickCUSTOM1.Checked = true;
            else
                checkBoxAutoKickCUSTOM1.Checked = false;

            if (LauncherForm.g_strTRAutoKickCustom2.Trim().ToUpper() == "Y")
                checkBoxAutoKickCUSTOM2.Checked = true;
            else
                checkBoxAutoKickCUSTOM2.Checked = false;

            if (LauncherForm.g_strTRAutoKickCustom3.Trim().ToUpper() == "Y")
                checkBoxAutoKickCUSTOM3.Checked = true;
            else
                checkBoxAutoKickCUSTOM3.Checked = false;

            if (LauncherForm.g_strTRAutoKickCustom4.Trim().ToUpper() == "Y")
                checkBoxAutoKickCUSTOM4.Checked = true;
            else
                checkBoxAutoKickCUSTOM4.Checked = false;

            // Auto Close
            if (LauncherForm.g_strTRAutoCloseThx.Trim().ToUpper() == "Y")
                checkAutoCloseThx.Checked = true;
            else
                checkAutoCloseThx.Checked = false;

            if (LauncherForm.g_strTRAutoCloseWait.Trim().ToUpper() == "Y")
                checkAutoCloseWait.Checked = true;
            else
                checkAutoCloseWait.Checked = false;

            if (LauncherForm.g_strTRAutoCloseSold.Trim().ToUpper() == "Y")
                checkAutoCloseSold.Checked = true;
            else
                checkAutoCloseSold.Checked = false;

            if (LauncherForm.g_strTRAutoCloseCustom1.Trim().ToUpper() == "Y")
                checkAutoCloseCustom1.Checked = true;
            else
                checkAutoCloseCustom1.Checked = false;

            if (LauncherForm.g_strTRAutoCloseCustom2.Trim().ToUpper() == "Y")
                checkAutoCloseCustom2.Checked = true;
            else
                checkAutoCloseCustom2.Checked = false;

            if (LauncherForm.g_strTRAutoCloseCustom3.Trim().ToUpper() == "Y")
                checkAutoCloseCustom3.Checked = true;
            else
                checkAutoCloseCustom3.Checked = false;

            if (LauncherForm.g_strTRAutoCloseCustom4.Trim().ToUpper() == "Y")
                checkAutoCloseCustom4.Checked = true;
            else
                checkAutoCloseCustom4.Checked = false;

            // Function Trade Request
            if (LauncherForm.g_strTRADECheckYNThx.Trim().ToUpper() == "Y")
                checkTRADEThx.Checked = true;
            else
                checkTRADEThx.Checked = false;
            if (LauncherForm.g_strTRADECheckYNWait.Trim().ToUpper() == "Y")
                checkTRADEWait.Checked = true;
            else
                checkTRADEWait.Checked = false;
            if (LauncherForm.g_strTRADECheckYNSold.Trim().ToUpper() == "Y")
                checkTRADESold.Checked = true;
            else
                checkTRADESold.Checked = false;
            if (LauncherForm.g_strTRADECheckYNCustom1.Trim().ToUpper() == "Y")
                checkTRADECustom1.Checked = true;
            else
                checkTRADECustom1.Checked = false;
            if (LauncherForm.g_strTRADECheckYNCustom2.Trim().ToUpper() == "Y")
                checkTRADECustom2.Checked = true;
            else
                checkTRADECustom2.Checked = false;
            if (LauncherForm.g_strTRADECheckYNCustom3.Trim().ToUpper() == "Y")
                checkTRADECustom3.Checked = true;
            else
                checkTRADECustom3.Checked = false;
            if (LauncherForm.g_strTRADECheckYNCustom4.Trim().ToUpper() == "Y")
                checkTRADECustom4.Checked = true;
            else
                checkTRADECustom4.Checked = false;

            // Function INVITE
            if (LauncherForm.g_strINVITECheckYNThx.Trim().ToUpper() == "Y")
                checkINVITEThx.Checked = true;
            else
                checkINVITEThx.Checked = false;
            if (LauncherForm.g_strINVITECheckYNWait.Trim().ToUpper() == "Y")
                checkINVITEWait.Checked = true;
            else
                checkINVITEWait.Checked = false;
            if (LauncherForm.g_strINVITECheckYNSold.Trim().ToUpper() == "Y")
                checkINVITESold.Checked = true;
            else
                checkINVITESold.Checked = false;
            if (LauncherForm.g_strINVITECheckYNCustom1.Trim().ToUpper() == "Y")
                checkINVITECustom1.Checked = true;
            else
                checkINVITECustom1.Checked = false;
            if (LauncherForm.g_strINVITECheckYNCustom2.Trim().ToUpper() == "Y")
                checkINVITECustom2.Checked = true;
            else
                checkINVITECustom2.Checked = false;
            if (LauncherForm.g_strINVITECheckYNCustom3.Trim().ToUpper() == "Y")
                checkINVITECustom3.Checked = true;
            else
                checkINVITECustom3.Checked = false;
            if (LauncherForm.g_strINVITECheckYNCustom4.Trim().ToUpper() == "Y")
                checkINVITECustom4.Checked = true;
            else
                checkINVITECustom4.Checked = false;

            // TITLE
            textBoxTitleWAIT.Text = LauncherForm.g_strnotiWAITbtnTITLE;
            textBoxTitleSOLD.Text = LauncherForm.g_strnotiSOLDbtnTITLE;
            textBoxTitleTHX.Text = LauncherForm.g_strnotiDONEbtnTITLE;
            textBoxCustomTitle1.Text = LauncherForm.g_strCUSTOM1btnTITLE;
            textBoxCustomTitle2.Text = LauncherForm.g_strCUSTOM2btnTITLE;
            textBoxCustomTitle3.Text = LauncherForm.g_strCUSTOM3btnTITLE;
            textBoxCustomTitle4.Text = LauncherForm.g_strCUSTOM4btnTITLE;

            // MESSAGE
            textBoxResend.Text = LauncherForm.g_strnotiRESEND;
            textBoxWait.Text = LauncherForm.g_strnotiWAIT;
            textBoxSold.Text = LauncherForm.g_strnotiSOLD;
            textBoxDone.Text = LauncherForm.g_strnotiDONE;
            textBoxCustom1.Text = LauncherForm.g_strCUSTOM1;
            textBoxCustom2.Text = LauncherForm.g_strCUSTOM2;
            textBoxCustom3.Text = LauncherForm.g_strCUSTOM3;
            textBoxCustom4.Text = LauncherForm.g_strCUSTOM4;
        }
        #endregion

        #region [[[[[ GetFlaskAndSkllTimerSettings() ]]]]]
        private void GetFlaskAndSkllTimerSettings()
        {
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            // FLASK Timer & SKILL Timer
            string sColor1 = string.Empty;
            string sColor2 = string.Empty;
            string sColor3 = string.Empty;
            string sColor4 = string.Empty;
            string sColor5 = string.Empty;

            sColor1 = parser.GetSetting("MISC", "FLASK1COLOR");
            sColor2 = parser.GetSetting("MISC", "FLASK2COLOR");
            sColor3 = parser.GetSetting("MISC", "FLASK3COLOR");
            sColor4 = parser.GetSetting("MISC", "FLASK4COLOR");
            sColor5 = parser.GetSetting("MISC", "FLASK5COLOR");

            colorStringRGB1 = sColor1;
            colorStringRGB2 = sColor2;
            colorStringRGB3 = sColor3;
            colorStringRGB4 = sColor4;
            colorStringRGB5 = sColor5;

            panelCO1.BackColor = StringRGBToColor(sColor1);
            panelCO2.BackColor = StringRGBToColor(sColor2);
            panelCO3.BackColor = StringRGBToColor(sColor3);
            panelCO4.BackColor = StringRGBToColor(sColor4);
            panelCO5.BackColor = StringRGBToColor(sColor5);

            sColor1 = parser.GetSetting("SKILL", "SKILL1COLOR");
            sColor2 = parser.GetSetting("SKILL", "SKILL2COLOR");
            sColor3 = parser.GetSetting("SKILL", "SKILL3COLOR");
            sColor4 = parser.GetSetting("SKILL", "SKILL4COLOR");
            sColor5 = parser.GetSetting("SKILL", "SKILL5COLOR");

            colorStringRGBQ = sColor1;
            colorStringRGBW = sColor2;
            colorStringRGBE = sColor3;
            colorStringRGBR = sColor4;
            colorStringRGBT = sColor5;

            panelQ.BackColor = StringRGBToColor(sColor1);
            panelW.BackColor = StringRGBToColor(sColor2);
            panelE.BackColor = StringRGBToColor(sColor3);
            panelR.BackColor = StringRGBToColor(sColor4);
            panelT.BackColor = StringRGBToColor(sColor5);

            textBoxSEC1.Text = parser.GetSetting("MISC", "FLASKTIME1"); // LauncherForm.g_FlaskTime1
            textBoxSEC2.Text = parser.GetSetting("MISC", "FLASKTIME2"); // LauncherForm.g_FlaskTime2
            textBoxSEC3.Text = parser.GetSetting("MISC", "FLASKTIME3"); // LauncherForm.g_FlaskTime3
            textBoxSEC4.Text = parser.GetSetting("MISC", "FLASKTIME4"); // LauncherForm.g_FlaskTime4
            textBoxSEC5.Text = parser.GetSetting("MISC", "FLASKTIME5"); // LauncherForm.g_FlaskTime5

            labelFL1.Text = ((Keys)LauncherForm.g_Flask1).ToString();
            labelFL2.Text = ((Keys)LauncherForm.g_Flask2).ToString();
            labelFL3.Text = ((Keys)LauncherForm.g_Flask3).ToString();
            labelFL4.Text = ((Keys)LauncherForm.g_Flask4).ToString();
            labelFL5.Text = ((Keys)LauncherForm.g_Flask5).ToString();

            textBoxQ.Text = parser.GetSetting("SKILL", "SKILLTIME1");
            textBoxW.Text = parser.GetSetting("SKILL", "SKILLTIME2");
            textBoxE.Text = parser.GetSetting("SKILL", "SKILLTIME3");
            textBoxR.Text = parser.GetSetting("SKILL", "SKILLTIME4");
            textBoxT.Text = parser.GetSetting("SKILL", "SKILLTIME5");

            lbSkillQ.Text = ((Keys)LauncherForm.g_Skill1).ToString();
            lbSkillW.Text = ((Keys)LauncherForm.g_Skill2).ToString();
            lbSkillE.Text = ((Keys)LauncherForm.g_Skill3).ToString();
            lbSkillR.Text = ((Keys)LauncherForm.g_Skill4).ToString();
            lbSkillT.Text = ((Keys)LauncherForm.g_Skill5).ToString();

            xuiSliderVolumeFlask.Percentage = LauncherForm.g_FlaskTimerVolume;
            labelFlaskTimerVolume.Text = "Volume = " + xuiSliderVolumeFlask.Percentage.ToString();

            Set_FlaskImageList();

            // Flask Image
            pictureFlask1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(0)]);
            pictureFlask2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(1)]);
            pictureFlask3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(2)]);
            pictureFlask4.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(3)]);
            pictureFlask5.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(4)]);

            // Use Sound Alert.
            if (LauncherForm.g_strTimerSound1 == "Y")
                xuiSwitchSoundFlaskTimer.SwitchState = XanderUI.XUISwitch.State.On;
            else
                xuiSwitchSoundFlaskTimer.SwitchState = XanderUI.XUISwitch.State.Off;
        }
        #endregion

        private void GetOverlaySettings()
        {
            labelPathJUN.Text = ControlForm.g_strImagePath[0];
            using (Bitmap bmp1 = ResizePictureKeepAspecRatio(ControlForm.g_strImagePath[0], 200, 150))
            {
                pictureBoxJUN.Image = bmp1;
            }

            labelPathALVA.Text = ControlForm.g_strImagePath[1];
            using (Bitmap bmp2 = ResizePictureKeepAspecRatio(ControlForm.g_strImagePath[1], 200, 150))
            {
                pictureBoxALVA.Image = bmp2;
            }

            labelPathZANA.Text = ControlForm.g_strImagePath[2];
            using (Bitmap bmp3 = ResizePictureKeepAspecRatio(ControlForm.g_strImagePath[2], 200, 150))
            {
                pictureBoxZANA.Image = bmp3;
            }
        }

        private void GetHelpSettings()
        {
            try
            {
                string strFilePath = String.Format("{0}\\{1}", Application.StartupPath, "HELP.md");
                string strMDText = String.Empty;
                if (File.Exists(strFilePath))
                {
                    strMDText = File.ReadAllText(strFilePath);
                    var htmlCode = Markdig.Markdown.ToHtml(strMDText);
                    webBrowser1.DocumentText = htmlCode;
                }
            }
            catch (Exception ex)
            {
                webBrowser1.DocumentText = "<html><body style='background-color:Blue'>Unknown Error occurred while reading ReadMe file.</body></html>";
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void GetHallOfFameSettings()
        {
            ;
            //labelSupporters.Text = LauncherForm.g_strDonator;
        }

        #region [[[[[ Function : GetSet_Hotkey ]]]]]
        public void GetSet_HotKey(KeyEventArgs e, string strWhich)
        {
            e.SuppressKeyPress = true;  //Suppress the key from being processed by the underlying control.
            if (strWhich == "REMAINS")
                textRemains.Text = string.Empty;
            else if (strWhich == "JUN")
                textJUN.Text = string.Empty;
            else if (strWhich == "ALVA")
                textALVA.Text = string.Empty;
            else if (strWhich == "ZANA")
                textZANA.Text = string.Empty;
            else if (strWhich == "HIDEOUT")
                textHideout.Text = string.Empty;
            else if (strWhich == "SEARCH")
                textBoxPositionSearch.Text = string.Empty;
            else if (strWhich == "EXIT")
                textBoxEXIT.Text = string.Empty;
            else if (strWhich == "INVITE")
                textHotKeyInvite.Text = string.Empty;
            else if (strWhich == "TRADE")
                textHotKeyTradeRequest.Text = string.Empty;
            else if (strWhich == "KICK")
                textHotKeyKickLeave.Text = string.Empty;
            else if (strWhich == "MINIMIZE")
                textHotKeyPanelMinimize.Text = string.Empty;
            else if (strWhich == "CLOSE")
                textHotKeyPanelClose.Text = string.Empty;
            else if (strWhich == "SOLD")
                textHotKeySold.Text = string.Empty;
            else if (strWhich == "WAIT")
                textHotKeyWait.Text = string.Empty;
            else if (strWhich == "THX")
                textHotKeyThx.Text = string.Empty;

            //Set the backspace button to specify that the user does not want to use a shortcut.
            if (e.KeyData == Keys.Back)
            {
                return;
            }

            // A modifier is present. Process each modifier.
            // Modifiers are separated by a ",". So we'll split them and write each one to the textbox.
            foreach (string modifier in e.Modifiers.ToString().Split(new Char[] { ';' }))
            {
                if (!modifier.Equals("none", StringComparison.OrdinalIgnoreCase))
                {
                    if (strWhich == "REMAINS")
                        textRemains.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "JUN")
                        textJUN.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "ALVA")
                        textALVA.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "ZANA")
                        textZANA.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "HIDEOUT")
                        textHideout.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "SEARCH")
                        textBoxPositionSearch.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "EXIT")
                        textBoxEXIT.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "INVITE")
                        textHotKeyInvite.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "TRADE")
                        textHotKeyTradeRequest.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "KICK")
                        textHotKeyKickLeave.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "MINIMIZE")
                        textHotKeyPanelMinimize.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "CLOSE")
                        textHotKeyPanelClose.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "SOLD")
                        textHotKeySold.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "WAIT")
                        textHotKeyWait.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                    else if (strWhich == "THX")
                        textHotKeyThx.Text = modifier.ToUpper() + ";" + e.KeyCode.ToString();
                }
                else
                {
                    if (strWhich == "REMAINS")
                        textRemains.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "JUN")
                        textJUN.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "ALVA")
                        textALVA.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "ZANA")
                        textZANA.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "HIDEOUT")
                        textHideout.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "SEARCH")
                        textBoxPositionSearch.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "EXIT")
                        textBoxEXIT.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "INVITE")
                        textHotKeyInvite.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "TRADE")
                        textHotKeyTradeRequest.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "KICK")
                        textHotKeyKickLeave.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "MINIMIZE")
                        textHotKeyPanelMinimize.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "CLOSE")
                        textHotKeyPanelClose.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "SOLD")
                        textHotKeySold.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "WAIT")
                        textHotKeyWait.Text = "NONE;" + e.KeyCode.ToString();
                    else if (strWhich == "THX")
                        textHotKeyThx.Text = "NONE;" + e.KeyCode.ToString();
                }
            }

            if (e.KeyCode == Keys.ShiftKey | e.KeyCode == Keys.ControlKey | e.KeyCode == Keys.Menu)
            {
                if (strWhich == "REMAINS")
                    textRemains.Text = keyRemains;
                else if (strWhich == "JUN")
                    textJUN.Text = keyJUN;
                else if (strWhich == "ALVA")
                    textALVA.Text = keyALVA;
                else if (strWhich == "ZANA")
                    textZANA.Text = keyZANA;
                else if (strWhich == "HIDEOUT")
                    textHideout.Text = keyHideout;
                else if (strWhich == "SEARCH")
                    textBoxPositionSearch.Text = keySearchbyPosition;
                else if (strWhich == "EXIT")
                    textBoxEXIT.Text = keySearchbyPosition;
                else if (strWhich == "INVITE")
                    textHotKeyInvite.Text = string.Empty;
                else if (strWhich == "TRADE")
                    textHotKeyTradeRequest.Text = string.Empty;
                else if (strWhich == "KICK")
                    textHotKeyKickLeave.Text = string.Empty;
                else if (strWhich == "MINIMIZE")
                    textHotKeyPanelMinimize.Text = string.Empty;
                else if (strWhich == "CLOSE")
                    textHotKeyPanelClose.Text = string.Empty;
                else if (strWhich == "SOLD")
                    textHotKeySold.Text = string.Empty;
                else if (strWhich == "WAIT")
                    textHotKeyWait.Text = string.Empty;
                else if (strWhich == "THX")
                    textHotKeyThx.Text = string.Empty;
            }

            keyRemains = textRemains.Text;
            keyJUN = textJUN.Text;
            keyALVA = textALVA.Text;
            keyZANA = textZANA.Text;
            keyHideout = textHideout.Text;
            keySearchbyPosition = textBoxPositionSearch.Text;
            keyEXIT = textBoxEXIT.Text;

            keyInvite = textHotKeyInvite.Text;
            keyTrade= textHotKeyTradeRequest.Text;
            keyKick = textHotKeyKickLeave.Text;
            keyMinimize = textHotKeyPanelMinimize.Text;
            keyClose = textHotKeyPanelClose.Text;
            keySold = textHotKeySold.Text;
            keyWait = textHotKeyWait.Text;
            keyThx = textHotKeyThx.Text;
        }
        #endregion

        #region [[[[[ KeyDown Event for HOTKEY ]]]]]
        private void textRemains_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_REMAINS));
        }

        private void textJUN_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_JUN));
        }

        private void textALVA_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_ALVA));
        }

        private void textZANA_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_ZANA));
        }

        private void textHideout_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_HIDEOUT));
        }

        private void textBoxPositionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_SEARCH));
        }

        private void textBoxEXIT_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_EXIT));
        }

        private void textHotKeyInvite_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_INVITE));
        }

        private void textHotKeyTradeRequest_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_TRADE));
        }

        private void textHotKeyKickLeave_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_KICK));
        }

        private void textHotKeyPanelMinimize_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_MINIMIZE));
        }

        private void textHotKeyPanelClose_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_MINIMIZE));
        }

        private void textHotKeySold_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_SOLD));
        }

        private void textHotKeyWait_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_WAIT));
        }

        private void textHotKeyThx_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, HOTKEYNAME_STRINGExtensions.ToDescriptionString(HOTKEYNAME_STRING.HOTKEYNAME_THX));
        }
        #endregion

        #region [[[[[ Text Changed Event - BUTTON TITLE ]]]]]
        private void textBoxTitleTHX_TextChanged(object sender, EventArgs e)
        {
            btnThanks.Text = textBoxTitleTHX.Text;
        }

        private void textBoxTitleSOLD_TextChanged(object sender, EventArgs e)
        {
            btnSold.Text = textBoxTitleSOLD.Text;
        }

        private void textBoxTitleWAIT_TextChanged(object sender, EventArgs e)
        {
            btnWaitPls.Text = textBoxTitleWAIT.Text;
        }
        private void textBoxCustomTitle1_TextChanged(object sender, EventArgs e)
        {
            btnCustom1.Text = textBoxCustomTitle1.Text;
        }

        private void textBoxCustomTitle2_TextChanged(object sender, EventArgs e)
        {
            btnCustom2.Text = textBoxCustomTitle2.Text;
        }

        private void textBoxCustomTitle3_TextChanged(object sender, EventArgs e)
        {
            btnCustom3.Text = textBoxCustomTitle3.Text;
        }
        private void textBoxCustomTitle4_TextChanged(object sender, EventArgs e)
        {
            btnCustom4.Text = textBoxCustomTitle4.Text;
        }
        #endregion

        #region [[[[[ Form Drag Moving ]]]]]
        private void label16_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void label16_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void label16_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        }
        #endregion

        #region [[[[[ TextBox Flask Timer & Skill Timer - Text to Decimal / Input Only Numeric ]]]]]
        private decimal ConvertoCultureDecimal(string strDecimal)
        {
            var c = System.Threading.Thread.CurrentThread.CurrentCulture;
            var s = c.NumberFormat.CurrencyDecimalSeparator;

            strDecimal = strDecimal.Replace(",", s);
            strDecimal = strDecimal.Replace(".", s);

            decimal decimalCulture = Convert.ToDecimal(strDecimal);

            return decimalCulture;
        }
        private void textBoxSEC1_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_FlaskTime1 = ConvertoCultureDecimal(textBoxSEC1.Text).ToString();
        }

        private void textBoxSEC2_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_FlaskTime2 = ConvertoCultureDecimal(textBoxSEC2.Text).ToString();
        }

        private void textBoxSEC3_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_FlaskTime3 = ConvertoCultureDecimal(textBoxSEC3.Text).ToString();
        }

        private void textBoxSEC4_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_FlaskTime4 = ConvertoCultureDecimal(textBoxSEC4.Text).ToString();
        }

        private void textBoxSEC5_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_FlaskTime5 = ConvertoCultureDecimal(textBoxSEC5.Text).ToString();
        }

        private void TextBoxQ_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_SkillTime1 = ConvertoCultureDecimal(textBoxQ.Text).ToString();
        }

        private void TextBoxW_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_SkillTime2 = ConvertoCultureDecimal(textBoxW.Text).ToString();
        }

        private void TextBoxE_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_SkillTime3 = ConvertoCultureDecimal(textBoxE.Text).ToString();
        }

        private void TextBoxR_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_SkillTime4 = ConvertoCultureDecimal(textBoxR.Text).ToString();
        }

        private void TextBoxT_TextChanged(object sender, EventArgs e)
        {
            LauncherForm.g_SkillTime5 = ConvertoCultureDecimal(textBoxT.Text).ToString();
        }

        private void TextBoxSEC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxSEC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxSEC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxSEC4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxSEC5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        } 
        #endregion

        #region [[[[[ Volume Slider - Trade Notification, Flask Timer ]]]]]
        private void xuiSliderVolumeTrade_MouseMove(object sender, MouseEventArgs e)
        {
            LauncherForm.g_NotifyVolume = xuiSliderVolumeTrade.Percentage;
            labelTradeVolume.Text = "Volume = " + xuiSliderVolumeTrade.Percentage.ToString();
        }

        private void xuiSliderVolumeFlask_MouseMove(object sender, MouseEventArgs e)
        {
            LauncherForm.g_FlaskTimerVolume = xuiSliderVolumeFlask.Percentage;
            labelFlaskTimerVolume.Text = "Volume = " + xuiSliderVolumeFlask.Percentage.ToString();
        }

        private void btnSOUNDTrade_Click(object sender, EventArgs e)
        {
            if (xuiSwitchSoundTrade.SwitchState == XanderUI.XUISwitch.State.On)
                xuiSwitchSoundTrade.SwitchState = XanderUI.XUISwitch.State.Off;
            else
                xuiSwitchSoundTrade.SwitchState = XanderUI.XUISwitch.State.On;

            xuiSwitchSoundTrade_SwitchStateChanged(sender, e);
        }

        private void xuiSwitchSoundTrade_SwitchStateChanged(object sender, EventArgs e)
        {
            if (xuiSwitchSoundTrade.SwitchState == XanderUI.XUISwitch.State.On)
            {
                btnSOUNDTrade.Image = Properties.Resources.Volume_16x16;
                labelSNDOnOff.ForeColor = Color.FromArgb(235, 182, 111);
                labelSNDOnOff.Text = "ON";
                LauncherForm.g_strNotificationSoundYN = "Y";
            }
            else
            {
                btnSOUNDTrade.Image = Properties.Resources.Volume_16x16_Mute;
                labelSNDOnOff.ForeColor = Color.FromArgb(28, 21, 16);
                labelSNDOnOff.Text = "OFF";
                LauncherForm.g_strNotificationSoundYN = "N";
            }
        }

        private void xuiSwitchSoundFlaskTimer_SwitchStateChanged(object sender, EventArgs e)
        {
            if (xuiSwitchSoundFlaskTimer.SwitchState == XanderUI.XUISwitch.State.On)
            {
                labelFlaskSoundUse.Text = "ON";
                LauncherForm.g_strTimerSound1 = "Y";
            }
            else
            {
                labelFlaskSoundUse.Text = "OFF";
                LauncherForm.g_strTimerSound1 = "N";
            }
        }
        #endregion

        #region [[[[[ Show Flask Image Select Panel :: g_nFlaskImageTimer (Dictionary) ]]]]]
        private int nFlaskImagePanelFlaskNumber = 0;
        private void pictureFlask1_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 1;
            labelFlaskNumber.Text = "Flask #1";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask2_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 2;
            labelFlaskNumber.Text = "Flask #2";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask3_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 3;
            labelFlaskNumber.Text = "Flask #3";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask4_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 4;
            labelFlaskNumber.Text = "Flask #4";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask5_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 5;
            labelFlaskNumber.Text = "Flask #5";
            panelSetFlaskImage.Visible = true;
        }

        private void btnFlaskCancel_Click(object sender, EventArgs e)
        {
            // Flask Image
            pictureFlask1.BackgroundImage = null;
            pictureFlask2.BackgroundImage = null;
            pictureFlask3.BackgroundImage = null;
            pictureFlask4.BackgroundImage = null;
            pictureFlask5.BackgroundImage = null;
            pictureFlask1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(0)]);
            pictureFlask2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(1)]);
            pictureFlask3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(2)]);
            pictureFlask4.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(3)]);
            pictureFlask5.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(4)]);

            panelSetFlaskImage.Visible = false;
            Invalidate();
        }

        private void btnFlaskOK_Click(object sender, EventArgs e)
        {
            if (listViewFlaskImage.SelectedItems.Count < 1)
                return;

            int nIndex = listViewFlaskImage.Items.IndexOf(listViewFlaskImage.SelectedItems[0]);

            DeadlyFlaskImage.FlaskImageTimerSavetoINI_FlaskImageKeyValue(nFlaskImagePanelFlaskNumber, nIndex);
            switch (nFlaskImagePanelFlaskNumber)
            {
                case 1:
                    pictureFlask1.BackgroundImage = null;
                    pictureFlask1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                   + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(0)]);
                    break;
                case 2:
                    pictureFlask2.BackgroundImage = null;
                    pictureFlask2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(1)]);
                    break;
                case 3:
                    pictureFlask3.BackgroundImage = null;
                    pictureFlask3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(2)]);
                    break;
                case 4:
                    pictureFlask4.BackgroundImage = null;
                    pictureFlask4.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(3)]);
                    break;
                case 5:
                    pictureFlask5.BackgroundImage = null;
                    pictureFlask5.BackgroundImage = Image.FromFile(Application.StartupPath + "\\DeadlyInform\\Flask\\"
                                    + DeadlyTranslation.FlaskImgPath[DeadlyFlaskImage.FlaskImageTimerGetValuebyKey(4)]);
                    break;
                default:
                    break;
            }
            panelSetFlaskImage.Visible = false;
            Invalidate();
        }
        #endregion

        #region [[[[[ COLOR Picker - Flask Timer ]]]]]
        private void panelCO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelCO1.BackColor = colorDialog1.Color;

                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGB1 = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void panelCO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelCO2.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGB2 = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void panelCO3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelCO3.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGB3 = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void panelCO4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelCO4.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGB4 = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void panelCO5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelCO5.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGB5 = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }
        #endregion

        #region [[[[[ COLOR Picker - Skill Timer ]]]]]
        private void PanelQ_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelQ.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGBQ = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void PanelW_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelW.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGBW = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void PanelE_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelE.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGBE = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void PanelR_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelR.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGBR = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }

        private void PanelT_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dRes = colorDialog1.ShowDialog();

            if (dRes == DialogResult.OK)
            {
                panelT.BackColor = colorDialog1.Color;
                string strR = colorDialog1.Color.R.ToString();
                string strG = colorDialog1.Color.G.ToString();
                string strB = colorDialog1.Color.B.ToString();
                colorStringRGBT = String.Format("{0},{1},{2}", strR, strG, strB);
            }
        }
        #endregion

        #region [[[[[ TAB : SAVE/CANCEL ]]]]]
        private void btnSave_Click(object sender, EventArgs e)
        {
            DisposeGarbage();

            SetAllTabsValues();
            btnSave.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisposeGarbage();
            btnSave.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnSaveTab2_Click(object sender, EventArgs e)
        {
            DisposeGarbage();

            SetAllTabsValues();
            btnCancelTab2.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelTab2_Click(object sender, EventArgs e)
        {
            DisposeGarbage();
            btnCancelTab2.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnSaveTab3_Click(object sender, EventArgs e)
        {
            DisposeGarbage();

            SetAllTabsValues();
            btnCancelTab3.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelTab3_Click(object sender, EventArgs e)
        {
            DisposeGarbage();
            btnCancelTab3.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSaveTab4_Click(object sender, EventArgs e)
        {
            DisposeGarbage();

            SetAllTabsValues();
            btnCancelTab4.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelTab4_Click(object sender, EventArgs e)
        {
            DisposeGarbage();
            btnCancelTab4.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnSaveTab5_Click(object sender, EventArgs e)
        {
            DisposeGarbage();

            SetAllTabsValues();
            btnCancelTab5.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelTab5_Click(object sender, EventArgs e)
        {
            DisposeGarbage();
            btnCancelTab5.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnSaveTab6_Click(object sender, EventArgs e)
        {
            DisposeGarbage();

            SetAllTabsValues();
            btnCancelTab6.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelTab6_Click(object sender, EventArgs e)
        {
            DisposeGarbage();
            btnCancelTab6.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnSaveTab7_Click(object sender, EventArgs e)
        {
            DisposeGarbage();

            SetAllTabsValues();
            btnCancelTab7.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancelTab7_Click(object sender, EventArgs e)
        {
            DisposeGarbage();
            btnCancelTab7.DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region [[[[[ Overlay Image Check State Changed - Default / Custom ]]]]]
        System.Drawing.Bitmap OriginBMP;
        System.Drawing.Bitmap NewBMP;
        private System.Drawing.Bitmap ResizePictureKeepAspecRatio(string strImagePath, int nWidth, int nHeight)
        {
            OriginBMP = new System.Drawing.Bitmap(strImagePath);

            int iWidth;
            int iHeight;
            if ((nHeight == 0) && (nWidth != 0))
            {
                iWidth = nWidth;
                iHeight = (OriginBMP.Size.Height * iWidth / OriginBMP.Size.Width);
            }
            else if ((nHeight != 0) && (nWidth == 0))
            {
                iHeight = nHeight;
                iWidth = (OriginBMP.Size.Width * iHeight / OriginBMP.Size.Height);
            }
            else
            {
                iWidth = nWidth;
                iHeight = nHeight;
            }

            NewBMP = new System.Drawing.Bitmap(iWidth, iHeight);
            return NewBMP;

            /*graphicTemp = System.Drawing.Graphics.FromImage(NewBMP);
            graphicTemp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            graphicTemp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphicTemp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphicTemp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphicTemp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphicTemp.DrawImage(bmp, 0, 0, iWidth, iHeight);
            graphicTemp.Dispose();
            System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters();
            System.Drawing.Imaging.EncoderParameter encoderParam = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, ImageQuality);
            encoderParams.Param[0] = encoderParam;
            System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            for (int fwd = 0; fwd <= arrayICI.Length - 1; fwd++)
            {
                if (arrayICI[fwd].FormatDescription.Equals("JPEG"))
                {
                    NewBMP.Save(Des, arrayICI[fwd], encoderParams);
                }
            }

            NewBMP.Dispose();
            bmp.Dispose();*/
        }

        private void xuiCheckBoxDefaultJUN_CheckedStateChanged(object sender, EventArgs e)
        {
            if(xuiCheckBoxDefaultJUN.Checked == true)
            {
                ControlForm.g_strImagePath[0] = @".\DeadlyInform\Betrayal.png";
                labelPathJUN.Text = ControlForm.g_strImagePath[0];
                btnBrowseJUN.Enabled = false;

                xuiCheckBoxCustomJUN.Checked = false;
            }
            else
            {
                xuiCheckBoxCustomJUN.Checked = true;
            }
        }

        private void xuiCheckBoxCustomJUN_CheckedStateChanged(object sender, EventArgs e)
        {
            if (xuiCheckBoxCustomJUN.Checked == true)
            {
                btnBrowseJUN.Enabled = true;
                xuiCheckBoxDefaultJUN.Checked = false;
            }
            else
            {
                xuiCheckBoxDefaultJUN.Checked = true;
            }
        }

        private void btnBrowseJUN_Click(object sender, EventArgs e)
        {
            if (openFileDialogJUN.ShowDialog() == DialogResult.OK)
                labelPathJUN.Text = openFileDialogJUN.FileName;

            if (!String.IsNullOrEmpty(labelPathJUN.Text))
            {
                ControlForm.g_strImagePath[0] = labelPathJUN.Text;
                Bitmap bmp = ResizePictureKeepAspecRatio(ControlForm.g_strImagePath[0], 200, 150);
                pictureBoxJUN.Image = bmp;
            }
        }

        
        private void xuiCheckBoxDefaultALVA_CheckedStateChanged(object sender, EventArgs e)
        {

        }

        private void xuiCheckBoxCustomALVA_CheckedStateChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowseALVA_Click(object sender, EventArgs e)
        {

        }
                
        private void xuiCheckBoxDefaultZANA_CheckedStateChanged(object sender, EventArgs e)
        {

        }

        private void xuiCheckBoxCustomZANA_CheckedStateChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowseZANA_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void SetAllTabsValues()
        {
            try
            {
                #region [[[[[ TAB1 - HOT KEYS ]]]]]
                // Check : HotKey Use - MAIN
                if (checkRemaining.Checked)
                    LauncherForm.g_strYNUseRemainingHOTKEY = "Y";
                else
                    LauncherForm.g_strYNUseRemainingHOTKEY = "N";

                if (checkSyndicateJUN.Checked)
                    LauncherForm.g_strYNUseSyndicateJUNHOTKEY = "Y";
                else
                    LauncherForm.g_strYNUseSyndicateJUNHOTKEY = "N";

                if (checkTempleALVA.Checked)
                    LauncherForm.g_strYNUseIncursionALVAHOTKEY = "Y";
                else
                    LauncherForm.g_strYNUseIncursionALVAHOTKEY = "N";

                if (checkAtlasZANA.Checked)
                    LauncherForm.g_strYNUseAtlasZANAHOTKEY = "Y";
                else
                    LauncherForm.g_strYNUseAtlasZANAHOTKEY = "N";

                if (checkHideout.Checked)
                    LauncherForm.g_strYNUseHideoutHOTKEY = "Y";
                else
                    LauncherForm.g_strYNUseHideoutHOTKEY = "N";

                if (checkFindbyPosition.Checked)
                    LauncherForm.g_strYNUseFindbyPositionHOTKEY = "Y";
                else
                    LauncherForm.g_strYNUseFindbyPositionHOTKEY = "N";

                if (checkEmergency.Checked)
                    LauncherForm.g_strYNUseEmergencyHOTKEY = "Y";
                else
                    LauncherForm.g_strYNUseEmergencyHOTKEY = "N";

                // Check : Use CTRL+MOUSEWHELL
                if (checkMouseWheel.Checked)
                    LauncherForm.g_strYNMouseWheelStashTab = "Y";
                else
                    LauncherForm.g_strYNMouseWheelStashTab = "N";

                // Check : HotKey Use - Trade Notification Panel
                if (checkInvite.Checked)
                    LauncherForm.g_strYNUseHOTKEYInvite = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYInvite = "N";

                if (checkTrade.Checked)
                    LauncherForm.g_strYNUseHOTKEYTrade = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYTrade = "N";

                if (checkUseHotkeyKick.Checked)
                    LauncherForm.g_strYNUseHOTKEYKick = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYKick = "N";

                if (checkTradePanelMinimize.Checked)
                    LauncherForm.g_strYNUseHOTKEYMinimize = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYMinimize = "N";

                if (checkTradePanelClose.Checked)
                    LauncherForm.g_strYNUseHOTKEYClose = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYClose = "N";

                if (checkHotkeySold.Checked)
                    LauncherForm.g_strYNUseHOTKEYSold = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYSold = "N";

                if (checkHotkeyWait.Checked)
                    LauncherForm.g_strYNUseHOTKEYWait = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYWait = "N";

                if (checkHotkeyThx.Checked)
                    LauncherForm.g_strYNUseHOTKEYThx = "Y";
                else
                    LauncherForm.g_strYNUseHOTKEYThx = "N";
                #endregion

                #region [[[[[ TAB2 - TRADE PANEL ]]]]]
                // NICKNAME
                if (!String.IsNullOrEmpty(textBoxCharacterNick.Text))
                    LauncherForm.g_strMyNickName = textBoxCharacterNick.Text;

                // NOTIFICATION BUTTON TITLE
                if (!String.IsNullOrEmpty(textBoxTitleWAIT.Text))
                    LauncherForm.g_strnotiWAITbtnTITLE = textBoxTitleWAIT.Text;
                if (!String.IsNullOrEmpty(textBoxTitleSOLD.Text))
                    LauncherForm.g_strnotiSOLDbtnTITLE = textBoxTitleSOLD.Text;
                if (!String.IsNullOrEmpty(textBoxTitleTHX.Text))
                    LauncherForm.g_strnotiDONEbtnTITLE = textBoxTitleTHX.Text;
                if (!String.IsNullOrEmpty(textBoxCustomTitle1.Text))
                    LauncherForm.g_strCUSTOM1btnTITLE = textBoxCustomTitle1.Text;
                if (!String.IsNullOrEmpty(textBoxCustomTitle2.Text))
                    LauncherForm.g_strCUSTOM2btnTITLE = textBoxCustomTitle2.Text;
                if (!String.IsNullOrEmpty(textBoxCustomTitle3.Text))
                    LauncherForm.g_strCUSTOM3btnTITLE = textBoxCustomTitle3.Text;
                if (!String.IsNullOrEmpty(textBoxCustomTitle4.Text))
                    LauncherForm.g_strCUSTOM4btnTITLE = textBoxCustomTitle4.Text;

                // NOTIFICATION MESSAGE
                if (!String.IsNullOrEmpty(textBoxWait.Text))
                    LauncherForm.g_strnotiWAIT = textBoxWait.Text;
                if (!String.IsNullOrEmpty(textBoxSold.Text))
                    LauncherForm.g_strnotiSOLD = textBoxSold.Text;
                if (!String.IsNullOrEmpty(textBoxDone.Text))
                    LauncherForm.g_strnotiDONE = textBoxDone.Text;
                if (!String.IsNullOrEmpty(textBoxResend.Text))
                    LauncherForm.g_strnotiRESEND = textBoxResend.Text;
                if (!String.IsNullOrEmpty(textBoxCustom1.Text))
                    LauncherForm.g_strCUSTOM1 = textBoxCustom1.Text;
                if (!String.IsNullOrEmpty(textBoxCustom2.Text))
                    LauncherForm.g_strCUSTOM2 = textBoxCustom2.Text;
                if (!String.IsNullOrEmpty(textBoxCustom3.Text))
                    LauncherForm.g_strCUSTOM3 = textBoxCustom3.Text;
                if (!String.IsNullOrEmpty(textBoxCustom4.Text))
                    LauncherForm.g_strCUSTOM4 = textBoxCustom4.Text;

                // CHECK - AUTO KICK : THX
                if (checkBoxAutoKickTHX.Checked)
                    LauncherForm.g_strTRAutoKick = "Y";
                else
                    LauncherForm.g_strTRAutoKick = "N";

                // CHECK - AUTO KICK : WAIT,SOLD, THX, CUSTOM 1,2,3,4
                if (checkBoxAutoKickWAIT.Checked)
                    LauncherForm.g_strTRAutoKickWait = "Y";
                else
                    LauncherForm.g_strTRAutoKickWait = "N";
                if (checkBoxAutoKickSOLD.Checked)
                    LauncherForm.g_strTRAutoKickSold = "Y";
                else
                    LauncherForm.g_strTRAutoKickSold = "N";
                if (checkBoxAutoKickTHX.Checked)
                    LauncherForm.g_strTRAutoKick = "Y";
                else
                    LauncherForm.g_strTRAutoKick = "N";
                if (checkBoxAutoKickCUSTOM1.Checked)
                    LauncherForm.g_strTRAutoKickCustom1 = "Y";
                else
                    LauncherForm.g_strTRAutoKickCustom1 = "N";
                if (checkBoxAutoKickCUSTOM2.Checked)
                    LauncherForm.g_strTRAutoKickCustom2 = "Y";
                else
                    LauncherForm.g_strTRAutoKickCustom2 = "N";
                if (checkBoxAutoKickCUSTOM3.Checked)
                    LauncherForm.g_strTRAutoKickCustom3 = "Y";
                else
                    LauncherForm.g_strTRAutoKickCustom3 = "N";
                if (checkBoxAutoKickCUSTOM4.Checked)
                    LauncherForm.g_strTRAutoKickCustom4 = "Y";
                else
                    LauncherForm.g_strTRAutoKickCustom4 = "N";
                // CHECK - AUTO CLOSE : WAIT,SOLD, THX, CUSTOM 1,2,3,4
                if (checkAutoCloseWait.Checked)
                    LauncherForm.g_strTRAutoCloseWait = "Y";
                else
                    LauncherForm.g_strTRAutoCloseWait = "N";
                if (checkAutoCloseSold.Checked)
                    LauncherForm.g_strTRAutoCloseSold = "Y";
                else
                    LauncherForm.g_strTRAutoCloseSold = "N";
                if (checkAutoCloseThx.Checked)
                    LauncherForm.g_strTRAutoCloseThx = "Y";
                else
                    LauncherForm.g_strTRAutoCloseThx = "N";
                if (checkAutoCloseCustom1.Checked)
                    LauncherForm.g_strTRAutoCloseCustom1 = "Y";
                else
                    LauncherForm.g_strTRAutoCloseCustom1 = "N";
                if (checkAutoCloseCustom2.Checked)
                    LauncherForm.g_strTRAutoCloseCustom2 = "Y";
                else
                    LauncherForm.g_strTRAutoCloseCustom2 = "N";
                if (checkAutoCloseCustom3.Checked)
                    LauncherForm.g_strTRAutoCloseCustom3 = "Y";
                else
                    LauncherForm.g_strTRAutoCloseCustom3 = "N";
                if (checkAutoCloseCustom4.Checked)
                    LauncherForm.g_strTRAutoCloseCustom4 = "Y";
                else
                    LauncherForm.g_strTRAutoCloseCustom4 = "N";
                // CHECK - Function INVITE
                if (checkINVITEWait.Checked)
                    LauncherForm.g_strINVITECheckYNWait = "Y";
                else
                    LauncherForm.g_strINVITECheckYNWait = "N";
                if (checkINVITESold.Checked)
                    LauncherForm.g_strINVITECheckYNSold = "Y";
                else
                    LauncherForm.g_strINVITECheckYNSold = "N";
                if (checkINVITEThx.Checked)
                    LauncherForm.g_strINVITECheckYNThx = "Y";
                else
                    LauncherForm.g_strINVITECheckYNThx = "N";
                if (checkINVITECustom1.Checked)
                    LauncherForm.g_strINVITECheckYNCustom1 = "Y";
                else
                    LauncherForm.g_strINVITECheckYNCustom1 = "N";
                if (checkINVITECustom2.Checked)
                    LauncherForm.g_strINVITECheckYNCustom2 = "Y";
                else
                    LauncherForm.g_strINVITECheckYNCustom2 = "N";
                if (checkINVITECustom3.Checked)
                    LauncherForm.g_strINVITECheckYNCustom3 = "Y";
                else
                    LauncherForm.g_strINVITECheckYNCustom3 = "N";
                if (checkINVITECustom4.Checked)
                    LauncherForm.g_strINVITECheckYNCustom4 = "Y";
                else
                    LauncherForm.g_strINVITECheckYNCustom4 = "N";
                // CHECK - Function Trade Request
                if (checkTRADEWait.Checked)
                    LauncherForm.g_strTRADECheckYNWait = "Y";
                else
                    LauncherForm.g_strTRADECheckYNWait = "N";
                if (checkTRADESold.Checked)
                    LauncherForm.g_strTRADECheckYNSold = "Y";
                else
                    LauncherForm.g_strTRADECheckYNSold = "N";
                if (checkTRADEThx.Checked)
                    LauncherForm.g_strTRADECheckYNThx = "Y";
                else
                    LauncherForm.g_strTRADECheckYNThx = "N";
                if (checkTRADECustom1.Checked)
                    LauncherForm.g_strTRADECheckYNCustom1 = "Y";
                else
                    LauncherForm.g_strTRADECheckYNCustom1 = "N";
                if (checkTRADECustom2.Checked)
                    LauncherForm.g_strTRADECheckYNCustom2 = "Y";
                else
                    LauncherForm.g_strTRADECheckYNCustom2 = "N";
                if (checkTRADECustom3.Checked)
                    LauncherForm.g_strTRADECheckYNCustom3 = "Y";
                else
                    LauncherForm.g_strTRADECheckYNCustom3 = "N";
                if (checkTRADECustom4.Checked)
                    LauncherForm.g_strTRADECheckYNCustom4 = "Y";
                else
                    LauncherForm.g_strTRADECheckYNCustom4 = "N";
                #endregion

                #region[[[[[ TAB3 - FLASK ]]]]]
                double dValidate1 = 0.0;
                double dValidate2 = 0.0;
                double dValidate3 = 0.0;
                double dValidate4 = 0.0;
                double dValidate5 = 0.0;
                // FLASK TIMER
                if (textBoxSEC1.Text.Length < 0 || textBoxSEC2.Text.Length < 0 || textBoxSEC3.Text.Length < 0 || textBoxSEC4.Text.Length < 0 || textBoxSEC5.Text.Length < 0
                    || String.IsNullOrEmpty(textBoxSEC1.Text) || String.IsNullOrEmpty(textBoxSEC2.Text) || String.IsNullOrEmpty(textBoxSEC3.Text)
                        || String.IsNullOrEmpty(textBoxSEC4.Text) || String.IsNullOrEmpty(textBoxSEC5.Text))
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "Flask Timer Sec. field value is Empty.";
                    frmMSG.ShowDialog();

                    return;
                }

                textBoxSEC1.Text = textBoxSEC1.Text.Replace(",", ".");
                textBoxSEC2.Text = textBoxSEC2.Text.Replace(",", ".");
                textBoxSEC3.Text = textBoxSEC3.Text.Replace(",", ".");
                textBoxSEC4.Text = textBoxSEC4.Text.Replace(",", ".");
                textBoxSEC5.Text = textBoxSEC5.Text.Replace(",", ".");

                dValidate1 = Convert.ToDouble(textBoxSEC1.Text);
                dValidate2 = Convert.ToDouble(textBoxSEC2.Text);
                dValidate3 = Convert.ToDouble(textBoxSEC3.Text);
                dValidate4 = Convert.ToDouble(textBoxSEC4.Text);
                dValidate5 = Convert.ToDouble(textBoxSEC5.Text);

                if (dValidate1 < 0.1 || dValidate2 < 0.1 || dValidate3 < 0.1 || dValidate4 < 0.1 || dValidate5 < 0.1)
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "'Second' field value must bigger than 0.1";
                    frmMSG.ShowDialog();

                    return;
                }

                // SKILL TIMER
                if (textBoxQ.Text.Length <= 0 || textBoxW.Text.Length <= 0 || textBoxE.Text.Length <= 0 || textBoxR.Text.Length <= 0 || textBoxT.Text.Length <= 0
                    || String.IsNullOrEmpty(textBoxQ.Text) || String.IsNullOrEmpty(textBoxW.Text) || String.IsNullOrEmpty(textBoxE.Text)
                        || String.IsNullOrEmpty(textBoxR.Text) || String.IsNullOrEmpty(textBoxT.Text))
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "Skill Timer Sec. field value is Empty.";
                    frmMSG.ShowDialog();

                    return;
                }

                DeadlyFlaskImage.FlaskImageTimerSavetoINI();
                #endregion

                #region[[[[[ TAB4 - SKILL ]]]]]
                dValidate1 = 0.0;
                dValidate2 = 0.0;
                dValidate3 = 0.0;
                dValidate4 = 0.0;
                dValidate5 = 0.0;

                textBoxQ.Text = textBoxQ.Text.Replace(",", ".");
                textBoxW.Text = textBoxW.Text.Replace(",", ".");
                textBoxE.Text = textBoxE.Text.Replace(",", ".");
                textBoxR.Text = textBoxR.Text.Replace(",", ".");
                textBoxT.Text = textBoxT.Text.Replace(",", ".");

                dValidate1 = Convert.ToDouble(textBoxQ.Text);
                dValidate2 = Convert.ToDouble(textBoxW.Text);
                dValidate3 = Convert.ToDouble(textBoxE.Text);
                dValidate4 = Convert.ToDouble(textBoxR.Text);
                dValidate5 = Convert.ToDouble(textBoxT.Text);

                if (dValidate1 < 0.1 || dValidate2 < 0.1 || dValidate3 < 0.1 || dValidate4 < 0.1 || dValidate5 < 0.1)
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "'Second' field value must bigger than 0.1";
                    frmMSG.ShowDialog();

                    return;
                }
                #endregion

                #region[[[[[ TAB5 - OVERLAY ]]]]]
                #endregion

                #region[[[[[ TAB6 - HELP ]]]]]
                // NONE
                #endregion

                #region[[[[[ TAB7 - HALL OF FAME ]]]]]
                // NONE
                #endregion
            }
            catch (Exception ex)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Unknown Error occurred while validate settings.\r\n\r\nERROR : ( " + ex.Message + " )";
                frmMSG.ShowDialog();

                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        #region [[[[[ Dispose & Close ]]]]]
        private void DisposeGarbage()
        {
            pictureFlask1.Dispose();
            pictureFlask2.Dispose();
            pictureFlask3.Dispose();
            pictureFlask4.Dispose();
            pictureFlask5.Dispose();

            if (webBrowser1 != null) webBrowser1.Dispose();
        }
        #endregion

        #region [[[[[ INVITE Check Box Limit to Other Check Box. ]]]]]
        private void checkINVITEWait_CheckedChanged(object sender, EventArgs e)
        {
            if (checkINVITEWait.Checked == true)
            {
                checkTRADEWait.Checked = false;
                checkBoxAutoKickWAIT.Checked = false;
                checkAutoCloseWait.Checked = false;
            }
        }

        private void checkINVITESold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkINVITESold.Checked == true)
            {
                checkTRADESold.Checked = false;
                checkBoxAutoKickSOLD.Checked = false;
                checkAutoCloseSold.Checked = false;
            }
        }

        private void checkINVITEThx_CheckedChanged(object sender, EventArgs e)
        {
            if (checkINVITEThx.Checked == true)
            {
                checkTRADEThx.Checked = false;
                checkBoxAutoKickTHX.Checked = false;
                checkAutoCloseThx.Checked = false;
            }
        }

        private void checkINVITECustom1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkINVITECustom1.Checked == true)
            {
                checkTRADECustom1.Checked = false;
                checkBoxAutoKickCUSTOM1.Checked = false;
                checkAutoCloseCustom1.Checked = false;
            }
        }

        private void checkINVITECustom2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkINVITECustom2.Checked == true)
            {
                checkTRADECustom2.Checked = false;
                checkBoxAutoKickCUSTOM2.Checked = false;
                checkAutoCloseCustom2.Checked = false;
            }
        }

        private void checkINVITECustom3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkINVITECustom3.Checked == true)
            {
                checkTRADECustom3.Checked = false;
                checkBoxAutoKickCUSTOM3.Checked = false;
                checkAutoCloseCustom3.Checked = false;
            }
        }

        private void checkINVITECustom4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkINVITECustom4.Checked == true)
            {
                checkTRADECustom4.Checked = false;
                checkBoxAutoKickCUSTOM4.Checked = false;
                checkAutoCloseCustom4.Checked = false;
            }

        }
        #endregion

        #region [[[[[ TRADE Check Box - Limit to Other check box ]]]]]
        private void checkTRADEWait_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTRADEWait.Checked == true)
            {
                checkINVITEWait.Checked = false;
                checkBoxAutoKickWAIT.Checked = false;
                checkAutoCloseWait.Checked = false;
            }
        }

        private void checkTRADESold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTRADESold.Checked == true)
            {
                checkINVITESold.Checked = false;
                checkBoxAutoKickSOLD.Checked = false;
                checkAutoCloseSold.Checked = false;
            }
        }

        private void checkTRADEThx_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTRADEThx.Checked == true)
            {
                checkINVITEThx.Checked = false;
                checkBoxAutoKickTHX.Checked = false;
                checkAutoCloseThx.Checked = false;
            }
        }

        private void checkTRADECustom1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTRADECustom1.Checked == true)
            {
                checkINVITECustom1.Checked = false;
                checkBoxAutoKickCUSTOM1.Checked = false;
                checkAutoCloseCustom1.Checked = false;
            }
        }

        private void checkTRADECustom2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTRADECustom2.Checked == true)
            {
                checkINVITECustom2.Checked = false;
                checkBoxAutoKickCUSTOM2.Checked = false;
                checkAutoCloseCustom2.Checked = false;
            }
        }

        private void checkTRADECustom3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTRADECustom3.Checked == true)
            {
                checkINVITECustom3.Checked = false;
                checkBoxAutoKickCUSTOM3.Checked = false;
                checkAutoCloseCustom3.Checked = false;
            }
        }

        private void checkTRADECustom4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTRADECustom4.Checked == true)
            {
                checkINVITECustom4.Checked = false;
                checkBoxAutoKickCUSTOM4.Checked = false;
                checkAutoCloseCustom4.Checked = false;
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelWaiting.Width = 800;
            panelWaiting.Height = 562;
            panelWaiting.Visible = true;

            if(_nInitCNT>=7)
            {
                panelWaiting.Visible = false;
                timer1.Stop();
            }
        }

        private void SettingsOverhaul_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (panelWaiting != null) panelWaiting.Dispose();
            if (timer1 != null) timer1.Dispose();
        }
    }
}
