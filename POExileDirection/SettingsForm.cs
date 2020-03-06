using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;

namespace POExileDirection
{
    public partial class SettingsForm : Form
    {
        public string keyRemains;
        public string keyJUN;
        public string keyALVA;
        public string keyZANA;
        public string keyHideout; // hideout
        public string keySearchbyPosition;
        public string keyEXIT;

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

        public SettingsForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            this.ShowInTaskbar = false;
        }

        #region [[[[[ Form_Load ]]]]]
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Visible = false;

            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;

            // HOTKEYS
            textRemains.Text = keyRemains;
            textJUN.Text = keyJUN;
            textALVA.Text = keyALVA;
            textZANA.Text = keyZANA;
            textHideout.Text = keyHideout; // Hideout
            textBoxPositionSearch.Text = keySearchbyPosition;
            textBoxEXIT.Text = keyEXIT;

            // FLASK and TRADING PANEL
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
                // FLASK
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

                // TRADING PANEL
                textBoxCharacterNick.Text = parser.GetSetting("CHARACTER", "MYNICK");
                if (parser.GetSetting("CHARACTER", "AUTOKICK") == "Y")
                    checkBoxAutoKick.Checked = true;
                else
                    checkBoxAutoKick.Checked = false;

                try
                {
                    List<DeadlyAtlas.NotifyMSGCollection> NotifyMSG =
                        LauncherForm.deadlyInformationData.InformationMSG.NotifyMSG.Where(retval => retval.Id == "THX").ToList();

                    textBoxDone.Text = NotifyMSG[0].Msg;
                }
                catch
                {
                    textBoxDone.Text = "thanks. gl hf~.";
                }

                try
                {
                    List<DeadlyAtlas.NotifyMSGCollection> NotifyMSG =
                        LauncherForm.deadlyInformationData.InformationMSG.NotifyMSG.Where(retval => retval.Id == "WILLING").ToList();

                    textBoxResend.Text = NotifyMSG[0].Msg;
                }
                catch
                {
                    textBoxResend.Text = "still willing to buy? 'Your Offer : '";
                }

                try
                {
                    List<DeadlyAtlas.NotifyMSGCollection> NotifyMSG =
                        LauncherForm.deadlyInformationData.InformationMSG.NotifyMSG.Where(retval => retval.Id == "WAIT").ToList();

                    textBoxWait.Text = NotifyMSG[0].Msg;
                }
                catch
                {
                    textBoxWait.Text = "wait a sec pls.";
                }

                try
                {
                    List<DeadlyAtlas.NotifyMSGCollection> NotifyMSG =
                        LauncherForm.deadlyInformationData.InformationMSG.NotifyMSG.Where(retval => retval.Id == "SOLD").ToList();

                    textBoxSold.Text = NotifyMSG[0].Msg;
                }
                catch
                {
                    textBoxSold.Text = "sold already. sry.";
                }

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
            }
            catch(Exception ex)
            {
                DeadlyLog4Net._log.Error("Can't read configuration ini. in SettingsForm_Load", ex);
            }

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panelDonateContact.Visible = false;
            panelHallOfFame.Visible = false;
            panelSkillMain.Visible = false;

            panel1.Left = 0;
            panel1.Top = 0;
            panel1.Width = 589;
            panel1.Height = 483;

            panel2.Left = 0;
            panel2.Top = 0;
            panel2.Width = 589;
            panel2.Height = 483;

            panel3.Left = 0;
            panel3.Top = 0;
            panel3.Width = 589;
            panel3.Height = 483;

            panelDonateContact.Left = 0;
            panelDonateContact.Top = 0;
            panelDonateContact.Width = 589;
            panelDonateContact.Height = 483;

            panelHallOfFame.Left = 0;
            panelHallOfFame.Top = 0;
            panelHallOfFame.Width = 589;
            panelHallOfFame.Height = 483;

            panelSkillMain.Left = 0;
            panelSkillMain.Top = 0;
            panelSkillMain.Width = 589;
            panelSkillMain.Height = 483;

            xuiSlider1.Percentage = LauncherForm.g_NotifyVolume;
            labelVolume.Text = "Volume = " + xuiSlider1.Percentage.ToString();
            xuiSliderFlaskVolume.Percentage = LauncherForm.g_FlaskTimerVolume;
            labelFlaskVolume.Text = "Volume = " + xuiSliderFlaskVolume.Percentage.ToString();

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
            
            if (LauncherForm.g_strTimerSound1 == "Y")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;

            labelSupporters.Text = LauncherForm.g_strDonator;

            Visible = true;
        }
        #endregion

        private void Set_FlaskImageList()
        {
            try
            {
                // Set ImageList
                var imageList = new ImageList();
                foreach(var obj in DeadlyTranslation.FlaskImgPath)
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
            catch(Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            double dValidate1 = 0.0;
            double dValidate2 = 0.0;
            double dValidate3 = 0.0;
            double dValidate4 = 0.0;
            double dValidate5 = 0.0;

            try
            {
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

                // NICKNAME
                if (!String.IsNullOrEmpty(textBoxCharacterNick.Text))
                    LauncherForm.g_strMyNickName = textBoxCharacterNick.Text;

                // NOTIFICATION MESSAGE
                /*
                public static string g_strnotiWAIT { get; set; }
                public static string g_strnotiSOLD { get; set; }
                public static string g_strnotiDONE { get; set; }
                public static string g_strnotiRESEND { get; set; }
                */
                if (textBoxWait.Text.Length > 0)
                    LauncherForm.g_strnotiWAIT = textBoxWait.Text;

                if (textBoxSold.Text.Length > 0)
                    LauncherForm.g_strnotiSOLD = textBoxSold.Text;

                if (textBoxDone.Text.Length > 0)
                    LauncherForm.g_strnotiDONE = textBoxDone.Text;

                if (textBoxResend.Text.Length > 0)
                    LauncherForm.g_strnotiRESEND = textBoxResend.Text;

                // AUTO KICK
                if (checkBoxAutoKick.Checked)
                    LauncherForm.g_strTRAutoKick = "Y";
                else
                    LauncherForm.g_strTRAutoKick = "N";

                // HotKey Use
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

                DeadlyFlaskImage.FlaskImageTimerSavetoINI();
            }
            catch
            {
                ;
            }
            btnClose.DialogResult = DialogResult.OK;
            this.Hide();
        }

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
            }

            keyRemains = textRemains.Text;
            keyJUN = textJUN.Text;
            keyALVA = textALVA.Text;
            keyZANA = textZANA.Text;
            keyHideout = textHideout.Text;
            keySearchbyPosition = textBoxPositionSearch.Text;
            keyEXIT = textBoxEXIT.Text;            
        }

        private void TextRemains_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, "REMAINS");
        }

        private void TextJUN_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, "JUN");
        }

        private void TextALVA_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, "ALVA");
        }

        private void TextZANA_KeyDown(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, "ZANA");
        }

        private void TextHideout_KeyUp(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, "HIDEOUT");
        }

        private void TextBoxPositionSearch_KeyUp(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, "SEARCH");
        }

        private void TextBoxEXIT_KeyUp(object sender, KeyEventArgs e)
        {
            GetSet_HotKey(e, "EXIT");
        }

        private void BtnHotKey_Click(object sender, EventArgs e)
        {
            panel1.Visible = true; // HOT KEY
            panel2.Visible = false; // FLASK
            panel3.Visible = false; // TRADE
            panelDonateContact.Visible = false; // TRADE
            panelHallOfFame.Visible = false; // HALL OF FAME
            panelSkillMain.Visible = false;

            panelHotKey.BackColor = Color.Khaki;
            panelFlask.BackColor = Color.FromArgb(29, 34, 46);
            panelTrading.BackColor = Color.FromArgb(29, 34, 46);
            panelSkill.BackColor = Color.FromArgb(29, 34, 46);
            panelHall.BackColor = Color.FromArgb(29, 34, 46);
            panelDonate.BackColor = Color.FromArgb(29, 34, 46);
        }

        private void BtnFlask_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; // HOT KEY
            panel2.Visible = true; // FLASK
            panel3.Visible = false; // TRADE
            panelDonateContact.Visible = false; // TRADE
            panelHallOfFame.Visible = false; // HALL OF FAME
            panelSkillMain.Visible = false;

            panelHotKey.BackColor = Color.FromArgb(29, 34, 46);
            panelFlask.BackColor = Color.Khaki;
            panelTrading.BackColor = Color.FromArgb(29, 34, 46);
            panelSkill.BackColor = Color.FromArgb(29, 34, 46);
            panelHall.BackColor = Color.FromArgb(29, 34, 46);
            panelDonate.BackColor = Color.FromArgb(29, 34, 46);
        }

        private void BtnTrading_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; // HOT KEY
            panel2.Visible = false; // FLASK
            panel3.Visible = true; // TRADE
            panelDonateContact.Visible = false; // TRADE
            panelHallOfFame.Visible = false; // HALL OF FAME
            panelSkillMain.Visible = false;

            panelHotKey.BackColor = Color.FromArgb(29, 34, 46);
            panelFlask.BackColor = Color.FromArgb(29, 34, 46);
            panelTrading.BackColor = Color.Khaki;
            panelSkill.BackColor = Color.FromArgb(29, 34, 46);
            panelHall.BackColor = Color.FromArgb(29, 34, 46);
            panelDonate.BackColor = Color.FromArgb(29, 34, 46);
        }

        private void ButtonDonate_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; // HOT KEY
            panel2.Visible = false; // FLASK
            panel3.Visible = false; // TRADE
            panelDonateContact.Visible = true; // TRADE
            panelHallOfFame.Visible = false; // HALL OF FAME
            panelSkillMain.Visible = false;

            panelHotKey.BackColor = Color.FromArgb(29, 34, 46);
            panelFlask.BackColor = Color.FromArgb(29, 34, 46);
            panelTrading.BackColor = Color.FromArgb(29, 34, 46);
            panelDonate.BackColor = Color.Khaki;
            panelHall.BackColor = Color.FromArgb(29, 34, 46);
            panelSkill.BackColor = Color.FromArgb(29, 34, 46);
        }

        private void BtnHall_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; // HOT KEY
            panel2.Visible = false; // FLASK
            panel3.Visible = false; // TRADE
            panelDonateContact.Visible = false; // TRADE
            panelHallOfFame.Visible = true; // HALL OF FAME
            panelSkillMain.Visible = false;

            panelHotKey.BackColor = Color.FromArgb(29, 34, 46);
            panelFlask.BackColor = Color.FromArgb(29, 34, 46);
            panelTrading.BackColor = Color.FromArgb(29, 34, 46);
            panelSkill.BackColor = Color.FromArgb(29, 34, 46);
            panelHall.BackColor = Color.Khaki;
            panelDonate.BackColor = Color.FromArgb(29, 34, 46);
        }

        private void BtnSkillTimer_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; // HOT KEY
            panel2.Visible = false; // FLASK
            panel3.Visible = false; // TRADE
            panelDonateContact.Visible = false; // TRADE
            panelHallOfFame.Visible = false; // HALL OF FAME
            panelSkillMain.Visible = true;

            panelHotKey.BackColor = Color.FromArgb(29, 34, 46);
            panelFlask.BackColor = Color.FromArgb(29, 34, 46);
            panelTrading.BackColor = Color.FromArgb(29, 34, 46);
            panelSkill.BackColor = Color.Khaki;
            panelHall.BackColor = Color.FromArgb(29, 34, 46);
            panelDonate.BackColor = Color.FromArgb(29, 34, 46);
        }

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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.buymeacoffee.com/UzY5dr7");
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/ryjUA7r"); 
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/ryjUA7r");
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/bePatron?u=25155273"); 
        }
        
        private void PictureBox15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/c/DeadlyCrush");
        }

        private void PictureBox16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitch.tv/deadlycrush");
        }

        private void PictureBox17_MouseHover(object sender, EventArgs e)
        {
            pictureBox17.Cursor = Cursors.Hand;
        }

        private void PictureBox10_MouseHover(object sender, EventArgs e)
        {
            pictureBox10.Cursor = Cursors.Hand;
        }

        private void PictureBox16_MouseHover(object sender, EventArgs e)
        {
            pictureBox16.Cursor = Cursors.Hand;
        }

        private void PictureBox15_MouseHover(object sender, EventArgs e)
        {
            pictureBox15.Cursor = Cursors.Hand;
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

        private void PictureBox27_Click(object sender, EventArgs e)
        {
            // YouTube
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCRG83nTzKgfIkGEeTU0bmXg");
        }

        private void PictureBox26_Click(object sender, EventArgs e)
        {
            // Twitch
            System.Diagnostics.Process.Start("https://www.twitch.tv/deadlycrush");
        }

        private void PictureBox25_Click(object sender, EventArgs e)
        {
            // FaceBook
            System.Diagnostics.Process.Start("https://www.facebook.com/Deadly-Trade-102279784448097");
        }

        private void PictureBox28_Click(object sender, EventArgs e)
        {
            // Discord
            System.Diagnostics.Process.Start("https://discord.gg/ryjUA7r");
        }

        private void PictureBox23_Click(object sender, EventArgs e)
        {
            // Toonation
            System.Diagnostics.Process.Start("https://toon.at/donate/deadly_trade");
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            // Toonation
            System.Diagnostics.Process.Start("https://toon.at/donate/deadly_trade");
        }

        private void PictureBox24_Click(object sender, EventArgs e)
        {
            // donorbox
            System.Diagnostics.Process.Start("https://donorbox.org/deadly-trade-poe");
        }

        private void xuiSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            LauncherForm.g_NotifyVolume = xuiSlider1.Percentage;
            labelVolume.Text = "Volume = " + xuiSlider1.Percentage.ToString();
        }

        private void xuiSlider1_MouseMove(object sender, MouseEventArgs e)
        {
            LauncherForm.g_NotifyVolume = xuiSlider1.Percentage;
            labelVolume.Text = "Volume = " + xuiSlider1.Percentage.ToString();
        }

        private void btnPaypalSub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.jumpleasure.me/deadlytrade/?page_id=455");
        }

        private void btnPaypalMain_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.jumpleasure.me/deadlytrade/?page_id=455");
        }

        #region [[[[[ Show Flask Image Select Panel :: g_nFlaskImageTimer (Dictionary) ]]]]]
        private int nFlaskImagePanelFlaskNumber = 0;
        private void pictureFlask1_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 1;
            labelFlaskNumber.Text = "Flast #1";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask2_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 2;
            labelFlaskNumber.Text = "Flast #2";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask3_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 3;
            labelFlaskNumber.Text = "Flast #3";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask4_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 4;
            labelFlaskNumber.Text = "Flast #4";
            panelSetFlaskImage.Visible = true;
        }

        private void pictureFlask5_Click(object sender, EventArgs e)
        {
            panelSetFlaskImage.Width = 335;
            panelSetFlaskImage.Height = 314;
            nFlaskImagePanelFlaskNumber = 5;
            labelFlaskNumber.Text = "Flast #5";
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
                          
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                LauncherForm.g_strTimerSound1 = "Y";
            else
                LauncherForm.g_strTimerSound1 = "N";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                LauncherForm.g_strTimerSound1 = "Y";
            else
                LauncherForm.g_strTimerSound1 = "N";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                LauncherForm.g_strTimerSound1 = "Y";
            else
                LauncherForm.g_strTimerSound1 = "N";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                LauncherForm.g_strTimerSound1 = "Y";
            else
                LauncherForm.g_strTimerSound1 = "N";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                LauncherForm.g_strTimerSound1 = "Y";
            else
                LauncherForm.g_strTimerSound1 = "N";
        }

        private void xuiSliderFlaskVolume_MouseUp(object sender, MouseEventArgs e)
        {
            LauncherForm.g_FlaskTimerVolume = xuiSliderFlaskVolume.Percentage;
            labelFlaskVolume.Text = "Volume = " + xuiSliderFlaskVolume.Percentage.ToString();
        }

        private void xuiSliderFlaskVolume_MouseMove(object sender, MouseEventArgs e)
        {
            LauncherForm.g_FlaskTimerVolume = xuiSliderFlaskVolume.Percentage;
            labelFlaskVolume.Text = "Volume = " + xuiSliderFlaskVolume.Percentage.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/Gd7MjCz");
        }

        private void pictureBox17_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/crush_deadly");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/DeadlyTradeKOR");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DeadlyCrush");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.naver.com/eocsdev2/221782910762");
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureFlask1.Dispose();
            pictureFlask2.Dispose();
            pictureFlask3.Dispose();
            pictureFlask4.Dispose();
            if (panelSetFlaskImage != null) panelSetFlaskImage.Dispose();

            this.Dispose();
        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        private void btn4_Click(object sender, EventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

        private void btnS1_Click(object sender, EventArgs e)
        {

        }

        private void btnS2_Click(object sender, EventArgs e)
        {

        }

        private void btnS3_Click(object sender, EventArgs e)
        {

        }

        private void btnS4_Click(object sender, EventArgs e)
        {

        }

        private void btnS5_Click(object sender, EventArgs e)
        {

        }
    }
}
