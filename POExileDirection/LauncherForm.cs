using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using AutoUpdaterDotNET;
using Newtonsoft.Json;
using Ninja_Price.API.PoeNinja.Classes;
using System.Net;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Globalization;

namespace POExileDirection
{
    public partial class LauncherForm : Form
    {
        #region [[[[[ IP Information ]]]]]
        public class DeadlyIPINFO
        {

            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("hostname")]
            public string Hostname { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("loc")]
            public string Loc { get; set; }

            [JsonProperty("org")]
            public string Org { get; set; }

            [JsonProperty("postal")]
            public string Postal { get; set; }
        }
        #endregion

        public static string _strIPAddress { get; set; }
        public static string _strMacAddress { get; set; }
        public static DateTime _dtLogin { get; set; }
        public static SqlConnection _sqlcon { get; set; }

        public static Rectangle[,] g_arrayRect1x1 = new Rectangle[12, 12];
        public static Rectangle[,] g_arrayRect4x4 = new Rectangle[24, 24];

        #region [[[[[ Pre-Check :: MOUSE WHEEL and HOT KEYS ]]]]]
        public static string g_strYNMouseWheelStashTab { get; set; } // Added 1.3.9.6 Ver.
        public static string g_strYNUseEmergencyHOTKEY { get; set; }
        public static string g_strYNUseRemainingHOTKEY { get; set; }
        public static string g_strYNUseFindbyPositionHOTKEY { get; set; }
        public static string g_strYNUseSyndicateJUNHOTKEY { get; set; }
        public static string g_strYNUseHideoutHOTKEY { get; set; }
        public static string g_strYNUseIncursionALVAHOTKEY { get; set; }
        public static string g_strYNUseAtlasZANAHOTKEY { get; set; }
        public static string g_strYNUseHOTKEYInvite { get; set; }
        public static string g_strYNUseHOTKEYTrade { get; set; }
        public static string g_strYNUseHOTKEYKick { get; set; }
        public static string g_strYNUseHOTKEYMinimize { get; set; }
        public static string g_strYNUseHOTKEYClose { get; set; }
        public static string g_strYNUseHOTKEYSold { get; set; }
        public static string g_strYNUseHOTKEYWait { get; set; }
        public static string g_strYNUseHOTKEYThx { get; set; }
        #endregion

        #region ⨌⨌ for FLASK TIMER ⨌⨌
        public static int g_Flask1 { get; set; }
        public static int g_Flask2 { get; set; }
        public static int g_Flask3 { get; set; }
        public static int g_Flask4 { get; set; }
        public static int g_Flask5 { get; set; }

        public static string g_FlaskTime1 { get; set; }
        public static string g_FlaskTime2 { get; set; }
        public static string g_FlaskTime3 { get; set; }
        public static string g_FlaskTime4 { get; set; }
        public static string g_FlaskTime5 { get; set; }

        public static bool g_bToggle1 { get; set; }
        public static bool g_bToggle2 { get; set; }
        public static bool g_bToggle3 { get; set; }
        public static bool g_bToggle4 { get; set; }
        public static bool g_bToggle5 { get; set; }

        public static string g_strTimerSound1 { get; set; }       
        #endregion

        #region ⨌⨌ for SKILL TIMER ⨌⨌
        public static int g_Skill1 { get; set; }
        public static int g_Skill2 { get; set; }
        public static int g_Skill3 { get; set; }
        public static int g_Skill4 { get; set; }
        public static int g_Skill5 { get; set; }

        public static string g_SkillTime1 { get; set; }
        public static string g_SkillTime2 { get; set; }
        public static string g_SkillTime3 { get; set; }
        public static string g_SkillTime4 { get; set; }
        public static string g_SkillTime5 { get; set; }

        public static bool g_bToggleSkill1 { get; set; }
        public static bool g_bToggleSkill2 { get; set; }
        public static bool g_bToggleSkill3 { get; set; }
        public static bool g_bToggleSkill4 { get; set; }
        public static bool g_bToggleSkill5 { get; set; }
        #endregion

        #region ⨌⨌ Declaration for NINJA API ⨌⨌
        // POE.NINJA
        public static string PoeLeagueApiList = "http://api.pathofexile.com/leagues?type=main&compact=1";

        // 19 Types
        public static string CurrencyURL = "https://poe.ninja/api/data/currencyoverview?type=Currency&league=";
        public static string Fragments_URL = "https://poe.ninja/api/data/currencyoverview?type=Fragment&league=";
        public static string Incubators_URL = "https://poe.ninja/api/data/itemoverview?type=Incubator&league=";
        public static string Scarabs_URL = "https://poe.ninja/api/data/itemoverview?type=Scarab&league=";
        public static string Fossils_URL = "https://poe.ninja/api/data/itemoverview?type=Fossil&league=";
        public static string Resonators_URL = "https://poe.ninja/api/data/itemoverview?type=Resonator&league=";
        
        public static string Essences_URL = "https://poe.ninja/api/data/itemoverview?type=Essence&league=";
        public static string DivinationCards_URL = "https://poe.ninja/api/data/itemoverview?type=DivinationCard&league=";
        public static string Prophecies_URL = "https://poe.ninja/api/data/itemoverview?type=Prophecy&league=";
        
        public static string UniqueMaps_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueMap&league=";
        public static string WhiteMaps_URL = "https://poe.ninja/api/data/itemoverview?type=Map&league=";
        
        public static string UniqueJewels_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueJewel&league=";
        public static string UniqueFlasks_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueFlask&league=";
        
        public static string UniqueWeapons_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueWeapon&league=";
        public static string UniqueArmours_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueArmour&league=";
        public static string UniqueAccessories_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueAccessory&league=";

        public static string BlightOil_URL = "https://poe.ninja/api/data/itemoverview?type=Oil&league="; // Added 1.3.9.0 Version
        public static string Watchstones_URL = "https://poe.ninja/api/data/itemoverview?type=Watchstone&league="; // Added 1.3.9.0 Version
        public static string Beasts_URL = "https://poe.ninja/api/data/itemoverview?type=Beast&league="; // Added 1.3.9.1 Version

        // Ninja Object 19 Types
        public class NinJaAPIData
        {
            public Currency.RootObject Currency { get; set; } = new Currency.RootObject();
            public DivinationCards.RootObject DivinationCards { get; set; } = new DivinationCards.RootObject();
            public Essences.RootObject Essences { get; set; } = new Essences.RootObject();
            public Fragments.RootObject Fragments { get; set; } = new Fragments.RootObject();
            public Prophecies.RootObject Prophecies { get; set; } = new Prophecies.RootObject();
            public UniqueAccessories.RootObject UniqueAccessories { get; set; } = new UniqueAccessories.RootObject();
            public UniqueArmours.RootObject UniqueArmours { get; set; } = new UniqueArmours.RootObject();
            public UniqueFlasks.RootObject UniqueFlasks { get; set; } = new UniqueFlasks.RootObject();
            public UniqueJewels.RootObject UniqueJewels { get; set; } = new UniqueJewels.RootObject();
            public UniqueMaps.RootObject UniqueMaps { get; set; } = new UniqueMaps.RootObject();
            public UniqueWeapons.RootObject UniqueWeapons { get; set; } = new UniqueWeapons.RootObject();
            public WhiteMaps.RootObject WhiteMaps { get; set; } = new WhiteMaps.RootObject();
            public Resonators.RootObject Resonators { get; set; } = new Resonators.RootObject();
            public Fossils.RootObject Fossils { get; set; } = new Fossils.RootObject();
            public Scarab.RootObject Scarabs { get; set; } = new Scarab.RootObject();
            public Incubators.RootObject Incubators { get; set; } = new Incubators.RootObject();

            public Oils.RootObject Oils { get; set; } = new Oils.RootObject(); // Added 1.3.9.0 Version : Blight Oils
            public Watchstones.RootObject Watchstones { get; set; } = new Watchstones.RootObject(); // Added 1.3.9.0 Version : 3.9 Watchstones
            public Beasts.RootObject Beasts { get; set; } = new Beasts.RootObject(); // Beasts_URL : Added 1.3.9.1 Version
        }
        #endregion

        NinjaForm frmNinja = null;
        public static readonly int CNT_NINJACATEGORIES = 19;
        public static int g_NinjaFileMakeAndUpdateCNT = 0; // Make 16 + Update 16 ( 16 = CNT_NINJACATEGORIES )
        public static string g_NinjaUpdatedTime { get; set; }
        public static string g_CurrentLeague { get; set; }

        public static NinJaAPIData ninjaData { get; set; }// = new NinJaAPIData();
        private string g_NinjaDirectory = null;

        // DeadlyOverlay : Syndicate, and TO DO...
        /*public class DeadlyOverlay
        {
            public Syndicate.RootObject SyndicateDeadly { get; set; } = new Syndicate.RootObject();
        }
        public static DeadlyOverlay deadlyOverlayData { get; set; }*/

        #region [[[[[ Jason Class : DeadlyInformation ]]]]
        // DeadlyInformation for Atlas MAP ( Data From ggpk : aNitMotD )
        public class DeadlyInformation
        {
            public DeadlyAtlas.RootObject InformationDeadly { get; set; } = new DeadlyAtlas.RootObject();
            public DeadlyAtlas.RootObjectMap InformationMaps { get; set; } = new DeadlyAtlas.RootObjectMap();
            public DeadlyAtlas.RootObjectCurruncy InformationCurrency { get; set; } = new DeadlyAtlas.RootObjectCurruncy();
            public DeadlyAtlas.RootObjectDivinationCard InformationDivinationCard { get; set; } = new DeadlyAtlas.RootObjectDivinationCard();
            public DeadlyAtlas.RootObjectDelve InformationDelve { get; set; } = new DeadlyAtlas.RootObjectDelve();
            public DeadlyAtlas.RootObjectScarab InformationScarab { get; set; } = new DeadlyAtlas.RootObjectScarab();
            public DeadlyAtlas.RootObjectMapFragment InformationMapFragment { get; set; } = new DeadlyAtlas.RootObjectMapFragment();
            public DeadlyAtlas.RootObjectProphecy InformationProphecy { get; set; } = new DeadlyAtlas.RootObjectProphecy();
            public DeadlyAtlas.RootObjectUniqueMap InformationUniqueMap { get; set; } = new DeadlyAtlas.RootObjectUniqueMap();
            public DeadlyAtlas.RootObjectUnique InformationUniqueItem { get; set; } = new DeadlyAtlas.RootObjectUnique();
            public DeadlyAtlas.RootObjectNotifyMSG InformationMSG { get; set; } = new DeadlyAtlas.RootObjectNotifyMSG();
            public DeadlyAtlas.RootObjectMapAlertMSG MapAlertMSG { get; set; } = new DeadlyAtlas.RootObjectMapAlertMSG();
            public DeadlyAtlas.RootObjectOilsPassive OilPassiveJsonData { get; set; } = new DeadlyAtlas.RootObjectOilsPassive();

            public DeadlyAtlas.RootObjectOilsRingAnoint OilRingAnointData { get; set; } = new DeadlyAtlas.RootObjectOilsRingAnoint();
            public DeadlyAtlas.RootObjectOilsMapAnoint OilMapAnointData { get; set; } = new DeadlyAtlas.RootObjectOilsMapAnoint();
        }
        public static DeadlyInformation deadlyInformationData { get; set; }
        #endregion

        // DeadlyCrush ENG_KOR Matching Data ( Data From ggpk : aNitMotD )
        //public class DeadlyENGKORMatching
        //{
        //    public ConvertKOR.RootObject engkorMatching { get; set; } = new ConvertKOR.RootObject();
        //}
        //public static DeadlyENGKORMatching matchingENGKORData { get; set; }

        #region [[[[[ NOTIFICATION MESSAGE ]]]]]
        public static string g_strnotiWAIT { get; set; }
        public static string g_strnotiSOLD { get; set; }
        public static string g_strnotiDONE { get; set; }
        public static string g_strnotiRESEND { get; set; }
        public static string g_strCUSTOM1 { get; set; }
        public static string g_strCUSTOM2 { get; set; }
        public static string g_strCUSTOM3 { get; set; }
        public static string g_strCUSTOM4 { get; set; }

        public static string g_strnotiWAITbtnTITLE { get; set; }
        public static string g_strnotiSOLDbtnTITLE { get; set; }
        public static string g_strnotiDONEbtnTITLE { get; set; }
        public static string g_strCUSTOM1btnTITLE { get; set; }
        public static string g_strCUSTOM2btnTITLE { get; set; }
        public static string g_strCUSTOM3btnTITLE { get; set; }
        public static string g_strCUSTOM4btnTITLE { get; set; }

        public static string g_strNotificationSoundYN { get; set; }
        #endregion

        public static IntPtr g_handlePathOfExile { get; set; }
        public static string g_strDonator { get; set; }

        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        public static string g_POELogPath { get; set; }
        public static string g_POELogFileName { get; set; }
        public static string g_strUILang { get; set; }
        public static bool g_bShowLocalChat { get; set; }
        public static string g_strExplanationLANG { get; set; }

        private bool g_bCanLaunchAddon = false;
        private bool g_bAddonLaunched = false;
        ControlForm frmMainControl = null;

        #region [[[[[ Global Variables ]]]]]
        public static string g_strMyNickName { get; set; }
        public static string g_strTRAutoKick { get; set; }
        public static string g_strTRAutoKickWait { get; set; }
        public static string g_strTRAutoKickSold { get; set; }
        public static string g_strTRAutoKickCustom1 { get; set; }
        public static string g_strTRAutoKickCustom2 { get; set; }
        public static string g_strTRAutoKickCustom3 { get; set; }
        public static string g_strTRAutoKickCustom4 { get; set; }

        public static string g_strTRAutoCloseThx { get; set; }
        public static string g_strTRAutoCloseWait { get; set; }
        public static string g_strTRAutoCloseSold { get; set; }
        public static string g_strTRAutoCloseCustom1 { get; set; }
        public static string g_strTRAutoCloseCustom2 { get; set; }
        public static string g_strTRAutoCloseCustom3 { get; set; }
        public static string g_strTRAutoCloseCustom4 { get; set; }

        public static int resolution_height { get; set; }
        public static int resolution_width { get; set; }

        public static bool g_isWindowdedFullScreen { get; set; }
        private bool g_isWindowdedFullScreenOLD;

        public static int g_nGridLeft { get; set; }
        public static int g_nGridTop { get; set; }

        public static int g_nGridWidth { get; set; }
        public static int g_nGridHeight { get; set; }

        public static bool g_FocusLosing { get; set; }
        public static bool g_FocusOnAddon { get; set; }

        public static bool g_pinLOCK { get; set; }

        public static bool g_ZoneInfoExpanded { get; set; }

        public static int g_NotifyVolume { get; set; }

        public static int g_FlaskTimerVolume { get; set; }
        #endregion

        public static DateTime dtLoggedIn { get; set; }

        public static List<string> g_strArrREDAlert { get; set; }
        public static List<string> g_strArrGREENAlert { get; set; }

        private DateTime ScrollTick;
        internal static Screen g_ScreenLocation;

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

        public LauncherForm()
        {            
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        public static string GetCountryByIPINFO(string strIP)
        {
            DeadlyIPINFO ipInfo = new DeadlyIPINFO();

            try
            {
                string ioinfo = new WebClient().DownloadString("http://ipinfo.io/" + strIP);
                ipInfo = JsonConvert.DeserializeObject<DeadlyIPINFO>(ioinfo);
                RegionInfo regionInformation = new RegionInfo(ipInfo.Country);
                ipInfo.Country = regionInformation.EnglishName;
            }
            catch (Exception ex)
            {
                ipInfo.Country = "Unknown";
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }

            return ipInfo.Country;
        }

        private void GetPOE_IngameUserOption()
        {
            #region ⨌⨌ Parsing POE production_Config.ini ⨌⨌
            // Get Addon Data & Pesonal Setting ( From My Games - Path of Exile )               
            String strPathPOEConifg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            strPathPOEConifg = strPathPOEConifg + "\\My Games\\Path of Exile\\production_Config.ini";
            IniParser parser = new IniParser(strPathPOEConifg);

            try
            {
                string strLanguage = parser.GetSetting("LANGUAGE", "language");
                if (String.IsNullOrEmpty(strLanguage))
                {
                    g_strUILang = "ENG";
                }
                else
                {
                    if (strLanguage.Equals("ko-KR", StringComparison.OrdinalIgnoreCase))
                        g_strUILang = "KOR";
                    else if (strLanguage.Equals("en", StringComparison.OrdinalIgnoreCase))
                        g_strUILang = "ENG";
                    else
                        g_strUILang = "UNKNOWN";
                }

                // STEP #1 Done.
                xuiFlatProgressBar2.Value = 1;
                labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));

                string strLocalChat = parser.GetSetting("UI", "show_local_chat");
                if (String.IsNullOrEmpty(strLocalChat))
                {
                    g_bShowLocalChat = false;
                }
                else
                {
                    if (strLocalChat.Equals("true", StringComparison.OrdinalIgnoreCase))
                        g_bShowLocalChat = true;
                    else
                        g_bShowLocalChat = false;
                }
                DeadlyLog4Net._log.Info("Show Local Chat : " + g_bShowLocalChat.ToString());

                // STEP #2 Done.
                xuiFlatProgressBar2.Value = 2;
                labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));

                if (g_strUILang == "UNKNOWN")
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.btmConfirm.Visible = false;
                    frmMSG.btnENG.Visible = true;
                    frmMSG.btnKOR.Visible = true;
                    frmMSG.lbMsg.Text = "Can't find POE UI Configuration (UNKNOWN). What is your OPTION-UI Languge in POE?";
                    DialogResult dr = frmMSG.ShowDialog();
                    if (dr == DialogResult.Yes)
                        g_strUILang = "KOR";
                    else
                        g_strUILang = "ENG";
                }
                DeadlyLog4Net._log.Info("UI Language : " + g_strUILang);

                #region ⨌⨌ POE KEYS : FLASK, SKILL ⨌⨌
                // FLASK KEYS
                string strFlask1 = parser.GetSetting("ACTION_KEYS", "use_flask_in_slot1");
                string strFlask2 = parser.GetSetting("ACTION_KEYS", "use_flask_in_slot2");
                string strFlask3 = parser.GetSetting("ACTION_KEYS", "use_flask_in_slot3");
                string strFlask4 = parser.GetSetting("ACTION_KEYS", "use_flask_in_slot4");
                string strFlask5 = parser.GetSetting("ACTION_KEYS", "use_flask_in_slot5");
                g_Flask1 = Convert.ToInt32(strFlask1);
                g_Flask2 = Convert.ToInt32(strFlask2);
                g_Flask3 = Convert.ToInt32(strFlask3);
                g_Flask4 = Convert.ToInt32(strFlask4);
                g_Flask5 = Convert.ToInt32(strFlask5);
                DeadlyLog4Net._log.Info(String.Format("Flask Keys #1 {0}, #2 {1}, #3 {2}, #4 {3}, #5 {4}", strFlask1, strFlask2, strFlask3, strFlask4, strFlask5));

                // SKILL KEYS use_bound_skill4 ~ use_bound_skill8 ( Default : QWERT )
                string strSkill1 = parser.GetSetting("ACTION_KEYS", "use_bound_skill4");
                string strSkill2 = parser.GetSetting("ACTION_KEYS", "use_bound_skill5");
                string strSkill3 = parser.GetSetting("ACTION_KEYS", "use_bound_skill6");
                string strSkill4 = parser.GetSetting("ACTION_KEYS", "use_bound_skill7");
                string strSkill5 = parser.GetSetting("ACTION_KEYS", "use_bound_skill8");
                g_Skill1 = Convert.ToInt32(strSkill1);
                g_Skill2 = Convert.ToInt32(strSkill2);
                g_Skill3 = Convert.ToInt32(strSkill3);
                g_Skill4 = Convert.ToInt32(strSkill4);
                g_Skill5 = Convert.ToInt32(strSkill5);                
                DeadlyLog4Net._log.Info(String.Format("Skill Keys #Q {0}, #W {1}, #E {2}, #R {3}, #T {4}", strSkill1, strSkill2, strSkill3, strSkill4, strSkill5));
                #endregion

                string strTemp = String.Empty;
                resolution_height = Convert.ToInt32(parser.GetSetting("DISPLAY", "resolution_height"));
                resolution_width = Convert.ToInt32(parser.GetSetting("DISPLAY", "resolution_width"));
                strTemp = parser.GetSetting("DISPLAY", "borderless_windowed_fullscreen");
                if (!String.IsNullOrEmpty(strTemp))
                {
                    if (strTemp.ToUpper() == "TRUE")
                        g_isWindowdedFullScreen = true;
                    else
                        g_isWindowdedFullScreen = false;

                    g_isWindowdedFullScreenOLD = g_isWindowdedFullScreen;
                }
                DeadlyLog4Net._log.Info(String.Format("resolution_height : {0}, resolution_width : {1}, g_isWindowdedFullScreen : {2}", 
                    resolution_height.ToString(), resolution_width.ToString(), g_isWindowdedFullScreen.ToString()));
            }
            catch (Exception ex)
            {
                /*g_strUILang = "UNKNOWN";
                g_bShowLocalChat = false;

                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read POE Configuration.\r\nPlease check POE UI Setting and Local Chat Enabled & Save Game Options.\r\nAnd Try again Please." +
                    "\r\n\r\n(게임 설정 정보를 확인할 수 없습니다.\r\n게임 실행 후, UI언어와 지역채팅 활성화를 확인하고 게임 옵션을 저장 후에\r\n다시 실행해주세요.)";
                DialogResult dr = frmMSG.ShowDialog();

                // Force Terminate Launcher.
                if (dr == DialogResult.OK)
                    Application.Exit();
                else
                    Application.Exit();*/
                if (g_strUILang == "UNKNOWN")
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.btmConfirm.Visible = false;
                    frmMSG.btnENG.Visible = true;
                    frmMSG.btnKOR.Visible = true;
                    frmMSG.lbMsg.Text = "Can't find POE UI Configuration. UI Language is Unknown\r\nWhat is your OPTION-UI Languge in POE?";
                    DialogResult dr = frmMSG.ShowDialog();
                    if (dr == DialogResult.Yes)
                        g_strUILang = "KOR";
                    else
                        g_strUILang = "ENG";
                }
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
            #endregion
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            dtLoggedIn = DateTime.Now;
            DeadlyLog4Net._log.Info("〓〓〓〓〓 ↓↓↓ Launcher Load ↓↓↓ 〓〓〓〓〓");
            g_handlePathOfExile = IntPtr.Zero;

            g_NinjaDirectory = Application.StartupPath + "\\NinjaData\\";
            // g_CurrentLeague = "Legion";

            g_ZoneInfoExpanded = true;

            Init_Controls();
            CommonDeadly.DeleteAllFilesInFoder(g_NinjaDirectory);

            string strThisAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.labelCurrentVer.Text = strThisAssemblyVersion;
            this.labelServerVer.Text = strThisAssemblyVersion;
            this.labelVersionState.Text = "Current Version is the Newest.";
            this.labelNeedToUpdate.Text = "No Update Needed.";

            g_strArrREDAlert = new List<string>();
            g_strArrGREENAlert = new List<string>();

            bool bFontcheck1 = Check_FontInstalled("굴림");
            bool bFontcheck2 = Check_FontInstalled("Gulim");
            bool bFontcheck3 = Check_FontInstalled("gulim");
            if (!bFontcheck1 && !bFontcheck2 && !bFontcheck3)
            {
                DeadlyLog4Net._log.Info("FONT not found");
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "If UI showing wrong font\r\nplease install Gulim font that located in sub folder 'FONT'\r\ngulim.ttc\r\n\r\nIt use gulim and arial font.";
                DialogResult dr = frmMSG.ShowDialog();
                /*MessageBox.Show("NOT FOUND");
                var info = new ProcessStartInfo()
                {
                    FileName = Application.StartupPath + "\\FONT\\FontReg.exe",
                    Arguments = "/copy",
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden

                };

                Process.Start(info);*/
            }
            else
            {
                /*try
                {
                    var info = new ProcessStartInfo()
                    {
                        FileName = Application.StartupPath + "\\FONT\\FontReg.exe",
                        Arguments = "/copy",
                        UseShellExecute = false,
                        Verb = "runas",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process.Start(info);
                    DeadlyLog4Net._log.Info("HI " + info.FileName);
                }
                catch (Exception ex)
                {
                    DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                }*/

                DeadlyLog4Net._log.Info("FONT Exist");
            }
            //this.Close();
            //Application.Exit();

            // DB Connection
            /*
            Provider=SQLOLEDB.1;Password=dydtjs06617!;Persist Security Info=True;User ID=deadlycruh;
            Initial Catalog=deadlycruh_godohosting_com;Data Source=211.233.51.65
            */
            string strConnString = "data source=211.233.51.65;initial catalog=deadlycruh_godohosting_com;persist security info=True" +
            ";user id=deadlycruh;Password=dydtjs06617!;workstation id=HOUSEPCTECHNICA;packet size=4096";
            _sqlcon = new SqlConnection(strConnString);


            this.TopMost = true;
            this.BringToFront();

            _strIPAddress = getInternalIP();
            _strMacAddress = NICMacAddress();

            GetPOE_IngameUserOption();

            btnLauncherLogin_Click(this, new EventArgs());
            //TEST TTTTTTT
            // TTTTT panelWaiting.Visible = false;
            // TTTTT Get_NinjaData();
        }

        private void Check_Authentication()
        {
            DeadlyLog4Net._log.Info("Check_Authentication  : " + _strIPAddress + _strMacAddress);

            panelLogin.Left = 5;
            panelLogin.Top = 6;
            panelLogin.Width = 548;
            panelLogin.Height = 536;
            panelLogin.Visible = true;
            panelLogin.BringToFront();
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _strIPAddress = getInternalIP();
            _strMacAddress = NICMacAddress();

            int nElapse = 0;
            double elapsedmin = ((TimeSpan)(dtLoggedIn - DateTime.Now)).TotalMinutes;
            nElapse = Convert.ToInt32(elapsedmin);
            if (nElapse < 0)
                nElapse = 0;
            DeadlyDBHelper.InsertLoginStatus(_sqlcon, "N", _strIPAddress, _strMacAddress, ".", "LOGOUT", GetCountryByIPINFO(_strIPAddress), dtLoggedIn,
                                            nElapse);
            DeadlyLog4Net._log.Info("LOGOUT : " + _strIPAddress + _strMacAddress + " Elapsedminute : " + nElapse);
        }

        private void textBoxDeadlyTradeCODE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLauncherLogin_Click(this, new EventArgs());
        }

        private void btnLauncherLogin_Click(object sender, EventArgs e)
        {
            bool bIsValid = false;
            

            DeadlyLog4Net._log.Info(_strIPAddress + _strMacAddress);
            string strisLogin = String.Empty;
            try
            {
                _strIPAddress = getInternalIP();
                _strMacAddress = NICMacAddress();
                strisLogin = DeadlyDBHelper.IsLoggedIn(_sqlcon, _strIPAddress, _strMacAddress);

                if (strisLogin == "Y")
                {
                    labelMsg.Text = "Already logged in. Disconnect existing user?";
                    Check_Authentication();
                    btnForceLogin.Visible = true;
                    btnForceLogin.Enabled = true;
                }

                //if (checkBoxAutoLogin.Checked)
                //    SaveLoginInformEncrypt();

                // Insert Action Log.
                dtLoggedIn = DateTime.Now;
                DeadlyDBHelper.InsertLoginStatus(_sqlcon, "Y", _strIPAddress, _strMacAddress, ".", "LOGIN", GetCountryByIPINFO(_strIPAddress), dtLoggedIn, 0);
                DeadlyLog4Net._log.Info("LOGIN Welcome : " + _strIPAddress + _strMacAddress);

                // Now Check Update available.
                panelLogin.Visible = false;
                // AutoUpdater check server's xml.
                AutoUpdateCheck();
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        #region [[[[[ Save Inform with TripleDES ]]]]]
        /*private void SaveLoginInformEncrypt()
        {
            string output = String.Format("{0}\r\n{1}\r\n{2}\r\n",
                EncryptionHelper.Encrypt(textBoxDeadlyTradeID.Text),
                EncryptionHelper.Encrypt(textBoxDeadlyTradeCODE.Text),
                EncryptionHelper.Encrypt(textBoxProcessID.Text));
            try
            {
                File.WriteAllText(Application.StartupPath + "\\DeadlyInform\\DeadlyInform.Info", output);

                string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

                if (resolution_width < 1920 && resolution_height < 1080)
                {
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                    if (resolution_width < 1600 && resolution_height < 1024)
                        strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini");
                    else if (LauncherForm.resolution_width < 1280)
                        strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_LOW.ini");
                }
                else if (resolution_width > 1920)
                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_HIGH.ini");

                IniParser parser = new IniParser(strINIPath);
                DeadlyLog4Net._log.Info($"{MethodBase.GetCurrentMethod().Name} RESOLUTION : " + strINIPath);

                parser.AddSetting("CHARACTER", "AUTOLOGIN", "Y");
                parser.SaveSettings();
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }*/
        #endregion

        private void btnForceLogin_Click(object sender, EventArgs e)
        {
            _strIPAddress = getInternalIP();
            _strMacAddress = NICMacAddress();

            DeadlyLog4Net._log.Info("Force Login : " + _strIPAddress + _strMacAddress);
            // Insert Action Log.
            dtLoggedIn = DateTime.Now;
            DeadlyDBHelper.InsertLoginStatus(_sqlcon, "Y", _strIPAddress, _strMacAddress, ".", "LOGIN", GetCountryByIPINFO(_strIPAddress), dtLoggedIn, 0);
            DeadlyLog4Net._log.Info("LOGIN Welcome : " + _strIPAddress + _strMacAddress);

            // Now Check Update available.
            panelLogin.Visible = false;
            // AutoUpdater check server's xml.
            AutoUpdateCheck();
        }

        private string getInternalIP()
        {
            string strIpAddress = String.Empty;
            try
            {
                string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
                IPAddress[] addr = hostEntry.AddressList;
                var ip = addr.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                             .FirstOrDefault();
                return ip.ToString() ?? "";

                /*IPHostEntry ip2;
                if (ip.ToString().Contains("192.168.") || ip.ToString() == "" || ip == null)
                {
                    string host = Dns.GetHostName();
                    ip2 = Dns.GetHostEntry(host);
                    strIpAddress = ip2.AddressList[0].ToString();
                }
                else
                    strIpAddress = ip.ToString();

                return strIpAddress;*/
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return "";
            }
            //localIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(localIP)[0].ToString();

            // return localIP;
        }

        private string NICMacAddress()
        {
            try
            {
                String firstMacAddress = NetworkInterface
              .GetAllNetworkInterfaces()
              .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
              .Select(nic => nic.GetPhysicalAddress().ToString())
              .FirstOrDefault();

                return firstMacAddress;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                return "";
            }
        }

        private bool Check_FontInstalled(string fontName)
        {
            bool bFound = false;
            float fontSize = 12;
            try
            {
                using (Font fontTester = new Font(
                     fontName,
                     fontSize,
                     FontStyle.Regular,
                     GraphicsUnit.Pixel))
                {
                    if (fontTester.Name == fontName)
                        bFound = true;
                    else
                        bFound = false;
                }
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }

            return bFound;
        }

        public void AutoUpdateCheck()
        {
            // Waiting Panel : 558, 573
            this.panelWaiting.Left = 1;
            this.panelWaiting.Top = 1;
            this.panelWaiting.Width = 558;
            this.panelWaiting.Height = 545;
            this.panelWaiting.Visible = true;

            try
            {
                AutoUpdater.ShowSkipButton = false;
                AutoUpdater.ShowRemindLaterButton = false;
                AutoUpdater.Mandatory = true;
                AutoUpdater.RunUpdateAsAdmin = true;
                AutoUpdater.OpenDownloadPage = false;
                AutoUpdater.DownloadPath = Application.StartupPath;
                AutoUpdater.Start("https://www.jumpleasure.me/deadlytrade/repository/DeadlyTradeVersion.xml");
                AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't connect update server.\r\nPlease check your network and Try again.";
                DialogResult dr = frmMSG.ShowDialog();

                // Force Terminate Launcher.
                if (dr == DialogResult.OK)
                    Application.Exit();
                else
                    Application.Exit();
            }
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        private void Init_Controls()
        {
            this.Text = "Deadly Trade";
            ShowInTaskbar = true;

            // NOTIFY, TRAY
            this.notifyIconDeadlyTrade.BalloonTipTitle = "Deadly Trade";
            this.notifyIconDeadlyTrade.BalloonTipText = "Deadly Trade Still Working...";
            this.notifyIconDeadlyTrade.Text = "DeadlyTrade ::\r\nDouble Click : launcher\r\nRight Click : menu";
            this.notifyIconDeadlyTrade.BalloonTipIcon = ToolTipIcon.Info;

            // btnClose
            this.btnStartAddon.FlatStyle = FlatStyle.Flat;
            this.btnStartAddon.BackColor = Color.Transparent;
            this.btnStartAddon.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.btnStartAddon.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.btnStartAddon.FlatAppearance.BorderColor = Color.FromArgb(0, 39, 44, 56);
            this.btnStartAddon.FlatAppearance.BorderSize = 0;
            this.btnStartAddon.TabStop = false;

            // btnStartAddon
            this.btnStartAddon.FlatStyle = FlatStyle.Flat;
            this.btnStartAddon.BackColor = Color.Transparent;
            this.btnStartAddon.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.btnStartAddon.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.btnStartAddon.FlatAppearance.BorderColor = Color.FromArgb(0, 39, 44, 56);
            this.btnStartAddon.FlatAppearance.BorderSize = 0;
            this.btnStartAddon.TabStop = false;

            // PROGRESS BAR
            xuiFlatProgressBar1.MaxValue = CNT_NINJACATEGORIES; // Make and Update
            xuiFlatProgressBar2.MaxValue = 20;

            labelAddonStatus.Text = "Add-on Data (Not loaded yet)";

            // TOOLTIP
            DeadlyToolTip.SetToolTip(this.btnMinimize, "Minimize.");
            DeadlyToolTip.SetToolTip(this.btnClose, "Close.");
            DeadlyToolTip.SetToolTip(this.btnStartAddon, "Waiting for Path Of Exile Launch Finished.");
        }
        #endregion

        private void ReadyToStartAddon()
        {          
            btnStartAddon.Image = Properties.Resources.DeadlyTradeStartYellowButton;
            DeadlyToolTip.SetToolTip(btnStartAddon, "Start Add-on 'Deadly Trade'");

            g_bCanLaunchAddon = true;
        }

        #region ⨌⨌ Check. Auto Update ⨌⨌

        private class WebClientWithTimeout : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest wr = base.GetWebRequest(address);
                wr.Timeout = 5000; // timeout in milliseconds (ms)
                return wr;
            }
        }

        private void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            this.btnClose.Enabled = false;
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    // args.CurrentVersion means Server's Current Version.
                    this.labelServerVer.Text = args.CurrentVersion.ToString();
                    this.labelVersionState.Text = "Current Vrsion is not up to date.";
                    this.labelNeedToUpdate.Text = "Update Nedeed.";

                    // Uncomment the following line if you want to show standard update dialog instead.
                    // AutoUpdater.ShowUpdateForm();

                    try
                    {
                        this.TopMost = false;
                        panelWaiting.Visible = false;
                        #region [[[[[ Delete Useless Files ]]]]]
                        DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                        FileInfo[] files = di.GetFiles("*.zip").Where(p => p.Extension == ".zip").ToArray();
                        foreach (FileInfo file in files)
                        {
                            try
                            {
                                file.Attributes = FileAttributes.Normal;
                                File.Delete(file.FullName);
                            }
                            catch(Exception ex)
                            {
                                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                            }
                        }
                        // Specific File : File.Delete(Application.StartupPath + "\\");
                        #endregion

                        if (AutoUpdater.DownloadUpdate())
                        {
                            this.TopMost = true;
                            #region [[[[[ Show Update Contents. ]]]]]
                            try
                            {
                                string strRead = String.Empty;
                                // Read Update Contents.
                                try
                                {
                                    WebClient wc = new WebClientWithTimeout();
                                    if (LauncherForm.g_strUILang == "KOR")
                                    {
                                        var readData = wc.DownloadData("https://www.jumpleasure.me/deadlytrade/repository/UpdateContents.txt");
                                        strRead = Encoding.UTF8.GetString(readData);
                                    }

                                    else
                                    {
                                        var readData = wc.DownloadData("https://www.jumpleasure.me/deadlytrade/repository/UpdateContentsEN.txt");
                                        strRead = Encoding.UTF8.GetString(readData);
                                    }
                                }
                                catch (WebException ex)
                                {
                                    DeadlyLog4Net._log.Error($"Read Contents. {MethodBase.GetCurrentMethod().Name}", ex);
                                }
                                this.TopMost = true;
                                labelUpdateTitle.Text = "DeadlyTrade " + strRead.Substring(0, 7) + " Updated contents.";
                                labelPatchNote.Text = strRead;
                                panelUpdateContents.Left = 0;
                                panelUpdateContents.Top = 1;
                                panelUpdateContents.Width = 558;
                                panelUpdateContents.Height = 544;
                                panelUpdateContents.Visible = true;
                                btnExitAndUpdate.Visible = true;
                                btnExitAndUpdate.BringToFront();
                                pictureBox2.Dispose();
                                panelWaiting.Dispose();
                            }
                            catch (Exception ex)
                            {
                                DeadlyLog4Net._log.Error($"Update Msg. {MethodBase.GetCurrentMethod().Name}", ex);
                            }
                            this.TopMost = true;
                            Thread.Sleep(1000);
                            #endregion
                        }
                    }
                    catch(Exception exception)
                    {
                        /*MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);*/
                        MSGForm frmMSG = new MSGForm();
                        frmMSG.lbMsg.Text = "An error occrred while checking update, please try again later" +
                            "\r\n\r\nERROR MESSAGE : " + exception.Message;
                        DialogResult dr = frmMSG.ShowDialog();

                        DeadlyLog4Net._log.Error($"Update {MethodBase.GetCurrentMethod().Name}", exception);

                        // Force Terminate Launcher.
                        if (dr == DialogResult.OK)
                            Application.Exit();
                        else
                            Application.Exit();
                    }
                }
                else
                {
                    AutoUpdater.CheckForUpdateEvent -= AutoUpdater_CheckForUpdateEvent;
                    g_bCanLaunchAddon = false;

                    // args.CurrentVersion means Server's Current Version.
                    this.labelCurrentVer.Text = args.InstalledVersion.ToString();
                    this.labelServerVer.Text = args.CurrentVersion.ToString();
                    this.labelVersionState.Text = "Current Version is the Newest.";
                    this.labelNeedToUpdate.Text = "No Update Needed.";

                    Thread.Sleep(100);
                    this.panelWaiting.Visible = false;
                    Thread.Sleep(500);

                    g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));

                    // STEP #3 Done.
                    xuiFlatProgressBar2.Value = 3;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));

                    Get_NinjaData();
                }
            }
            else
            {
                /*MessageBox.Show(
                        @"There is a problem reaching update server please check your internet connection and try again later.",
                        @"Update check failed", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "There is a problem reaching update server.\r\nPlease check your internet connection and try again later";
                DialogResult dr = frmMSG.ShowDialog();

                // Force Terminate Launcher.
                if (dr == DialogResult.OK)
                    Application.Exit();
                else
                    Application.Exit();
            }
            this.btnClose.Enabled = true;
        }
        #endregion

        private void btnExitAndUpdate_Click(object sender, EventArgs e)
        {
            pictureBox2.Dispose();
            panelWaiting.Dispose();
            this.Close();
            Application.Exit();
        }

        private decimal ConvertoCultureDecimal(string strDecimal)
        {
            var c = System.Threading.Thread.CurrentThread.CurrentCulture;
            var s = c.NumberFormat.CurrencyDecimalSeparator;

            strDecimal = strDecimal.Replace(",", s);
            strDecimal = strDecimal.Replace(".", s);

            decimal decimalCulture = Convert.ToDecimal(strDecimal);

            return decimalCulture;
        }

        private void Get_NinjaData()
        {
            Thread.Sleep(300);

            #region ⨌⨌ Parsing ADDON ConfigPath.ini ⨌⨌
            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            DeadlyLog4Net._log.Info($"{MethodBase.GetCurrentMethod().Name} RESOLUTION : " + strINIPath);

            try
            {
                string strUserChoideLeague = parser.GetSetting("LEAGUE", "USERCHOICE");
                int nUserChoice = Convert.ToInt32(strUserChoideLeague);

                LEAGUE_STRING enumUerChoice = LEAGUE_STRING.LEAGUE_CURRENT;
                switch (nUserChoice)
                {
                    case 0:
                        enumUerChoice = LEAGUE_STRING.LEAGUE_CURRENT;
                        break;
                    case 1:
                        enumUerChoice = LEAGUE_STRING.LEAGUE_STANDARD;
                        break;
                    case 2:
                        enumUerChoice = LEAGUE_STRING.LEAGUE_HDCORE_CURRENT;
                        break;
                    case 3:
                        enumUerChoice = LEAGUE_STRING.LEAGUE_HDCORE_STANDARD;
                        break;
                    default:
                        enumUerChoice = LEAGUE_STRING.LEAGUE_CURRENT;
                        break;
                }

                g_CurrentLeague = enumUerChoice.ToDescriptionString();
                labelUserLeague.Text = String.Format("Last Your currency checked league is '{0}'.", g_CurrentLeague);

                #region ⨌⨌ GET TIMER SETTING : FLASK, SKILL ⨌⨌
                // FLASK TIMER
                g_FlaskTime1 = parser.GetSetting("MISC", "FLASKTIME1");
                g_FlaskTime2 = parser.GetSetting("MISC", "FLASKTIME2");
                g_FlaskTime3 = parser.GetSetting("MISC", "FLASKTIME3");
                g_FlaskTime4 = parser.GetSetting("MISC", "FLASKTIME4");
                g_FlaskTime5 = parser.GetSetting("MISC", "FLASKTIME5");
                g_FlaskTime1 = ConvertoCultureDecimal(g_FlaskTime1).ToString();
                g_FlaskTime2 = ConvertoCultureDecimal(g_FlaskTime2).ToString();
                g_FlaskTime3 = ConvertoCultureDecimal(g_FlaskTime3).ToString();
                g_FlaskTime4 = ConvertoCultureDecimal(g_FlaskTime4).ToString();
                g_FlaskTime5 = ConvertoCultureDecimal(g_FlaskTime5).ToString();

                if (parser.GetSetting("MISC", "TOGGLE1ON") == "TRUE")
                    g_bToggle1 = true;
                else
                    g_bToggle1 = false;

                if (parser.GetSetting("MISC", "TOGGLE2ON") == "TRUE")
                    g_bToggle2 = true;
                else
                    g_bToggle2 = false;

                if (parser.GetSetting("MISC", "TOGGLE3ON") == "TRUE")
                    g_bToggle3 = true;
                else
                    g_bToggle3 = false;

                if (parser.GetSetting("MISC", "TOGGLE4ON") == "TRUE")
                    g_bToggle4 = true;
                else
                    g_bToggle4 = false;

                if (parser.GetSetting("MISC", "TOGGLE5ON") == "TRUE")
                    g_bToggle5 = true;
                else
                    g_bToggle5 = false;

                // SKILL TIMER
                g_SkillTime1 = parser.GetSetting("SKILL", "SKILLTIME1");
                g_SkillTime2 = parser.GetSetting("SKILL", "SKILLTIME2");
                g_SkillTime3 = parser.GetSetting("SKILL", "SKILLTIME3");
                g_SkillTime4 = parser.GetSetting("SKILL", "SKILLTIME4");
                g_SkillTime5 = parser.GetSetting("SKILL", "SKILLTIME5");

                g_SkillTime1 = ConvertoCultureDecimal(g_SkillTime1).ToString();
                g_SkillTime2 = ConvertoCultureDecimal(g_SkillTime2).ToString();
                g_SkillTime3 = ConvertoCultureDecimal(g_SkillTime3).ToString();
                g_SkillTime4 = ConvertoCultureDecimal(g_SkillTime4).ToString();
                g_SkillTime5 = ConvertoCultureDecimal(g_SkillTime4).ToString();

                if (parser.GetSetting("SKILL", "TOGGLESKILL1ON") == "TRUE")
                    g_bToggleSkill1 = true;
                else
                    g_bToggleSkill1 = false;
                
                if (parser.GetSetting("SKILL", "TOGGLESKILL2ON") == "TRUE")
                    g_bToggleSkill2 = true;
                else
                    g_bToggleSkill2 = false;

                if (parser.GetSetting("SKILL", "TOGGLESKILL3ON") == "TRUE")
                    g_bToggleSkill3 = true;
                else
                    g_bToggleSkill3 = false;

                if (parser.GetSetting("SKILL", "TOGGLESKILL4ON") == "TRUE")
                    g_bToggleSkill4 = true;
                else
                    g_bToggleSkill4 = false;

                if (parser.GetSetting("SKILL", "TOGGLESKILL5ON") == "TRUE")
                    g_bToggleSkill5 = true;
                else
                    g_bToggleSkill5 = false;
                #endregion

                // Check Auto Kick.
                g_strMyNickName = parser.GetSetting("CHARACTER", "MYNICK");
                g_strTRAutoKick = parser.GetSetting("CHARACTER", "AUTOKICK");
                g_strTRAutoKickWait = parser.GetSetting("LOCATIONNOTIFY", "WAIT");
                g_strTRAutoKickSold = parser.GetSetting("LOCATIONNOTIFY", "SOLD");
                g_strTRAutoKickCustom1 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOM1");
                g_strTRAutoKickCustom2 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOM2");
                g_strTRAutoKickCustom3 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOM3");
                g_strTRAutoKickCustom4 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOM4");

                g_strTRAutoCloseThx = parser.GetSetting("LOCATIONNOTIFY", "THXCLOSE");
                g_strTRAutoCloseWait = parser.GetSetting("LOCATIONNOTIFY", "WAITCLOSE");
                g_strTRAutoCloseSold = parser.GetSetting("LOCATIONNOTIFY", "SOLDCLOSE");
                g_strTRAutoCloseCustom1 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOMCLOSE1");
                g_strTRAutoCloseCustom2 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOMCLOSE2");
                g_strTRAutoCloseCustom3 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOMCLOSE3");
                g_strTRAutoCloseCustom4 = parser.GetSetting("LOCATIONNOTIFY", "CUSTOMCLOSE4");

                g_nGridLeft = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "LEFT"));
                g_nGridTop = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "TOP"));

                string strGridWidth = parser.GetSetting("LOCATIONGRID", "RIGHT");
                string strGridHeight = parser.GetSetting("LOCATIONGRID", "BOTTOM");
                g_nGridWidth = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "RIGHT"));
                g_nGridHeight = Convert.ToInt32(parser.GetSetting("LOCATIONGRID", "BOTTOM"));

                #region [[[[[Pre-Check::MOUSE WHEEL and HOT KEYS]]]]]
                // MOUSE WHEEL
                g_strYNMouseWheelStashTab = parser.GetSetting("MISC", "MOUSESTASHTAB"); // Addded 1.3.9.6 Ver.
                if (String.IsNullOrEmpty(g_strYNMouseWheelStashTab))
                    g_strYNMouseWheelStashTab = "Y";
                DeadlyLog4Net._log.Info("checkUseWheelStash : " + g_strYNMouseWheelStashTab);

                // EMERGENCY
                g_strYNUseEmergencyHOTKEY = parser.GetSetting("MISC", "EMERGENCY");
                if (String.IsNullOrEmpty(g_strYNUseEmergencyHOTKEY))
                    g_strYNUseEmergencyHOTKEY = "Y";
                DeadlyLog4Net._log.Info("checkEmergency : " + g_strYNUseEmergencyHOTKEY);

                // REMAINING
                g_strYNUseRemainingHOTKEY = parser.GetSetting("MISC", "REMAINING");
                if (String.IsNullOrEmpty(g_strYNUseRemainingHOTKEY))
                    g_strYNUseRemainingHOTKEY = "Y";
                DeadlyLog4Net._log.Info("checkRemaining : " + g_strYNUseRemainingHOTKEY);

                // FINDBYPOSTION
                g_strYNUseFindbyPositionHOTKEY = parser.GetSetting("MISC", "FINDBYPOSTION");
                if (String.IsNullOrEmpty(g_strYNUseFindbyPositionHOTKEY))
                    g_strYNUseFindbyPositionHOTKEY = "Y";
                DeadlyLog4Net._log.Info("checkFindbyPosition : " + g_strYNUseFindbyPositionHOTKEY);

                // HOTKEYSYNDICATE
                g_strYNUseSyndicateJUNHOTKEY = parser.GetSetting("MISC", "HOTKEYSYNDICATE");
                if (String.IsNullOrEmpty(g_strYNUseSyndicateJUNHOTKEY))
                    g_strYNUseSyndicateJUNHOTKEY = "Y";
                DeadlyLog4Net._log.Info("checkSyndicateJUN : " + g_strYNUseSyndicateJUNHOTKEY);

                // HOTKEYHIDEOUT
                g_strYNUseHideoutHOTKEY = parser.GetSetting("MISC", "HOTKEYHIDEOUT");
                if (String.IsNullOrEmpty(g_strYNUseHideoutHOTKEY))
                    g_strYNUseHideoutHOTKEY = "Y";
                DeadlyLog4Net._log.Info("checkHideout : " + g_strYNUseHideoutHOTKEY);

                // HOTKEYALVAINCURSION
                g_strYNUseIncursionALVAHOTKEY = parser.GetSetting("MISC", "HOTKEYALVAINCURSION");
                if (String.IsNullOrEmpty(g_strYNUseIncursionALVAHOTKEY))
                    g_strYNUseIncursionALVAHOTKEY = "Y";
                DeadlyLog4Net._log.Info("checkTempleALVA : " + g_strYNUseIncursionALVAHOTKEY);

                // HOTKEYZANAATLAS
                g_strYNUseAtlasZANAHOTKEY = parser.GetSetting("MISC", "HOTKEYZANAATLAS");
                if (String.IsNullOrEmpty(g_strYNUseAtlasZANAHOTKEY))
                    g_strYNUseAtlasZANAHOTKEY = "Y";
                DeadlyLog4Net._log.Info("checkAtlasZANA : " + g_strYNUseAtlasZANAHOTKEY);

                //-------------------------------------------//
                // HOTKEY USE Y/N - Trade Notification Panel //
                //-------------------------------------------//

                g_strYNUseHOTKEYInvite = parser.GetSetting("NOTIFYHOTKEY", "INVITE");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYInvite))
                    g_strYNUseHOTKEYInvite = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYInvite);
                
                g_strYNUseHOTKEYTrade = parser.GetSetting("NOTIFYHOTKEY", "TRADE");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYTrade))
                    g_strYNUseHOTKEYTrade = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYTrade);
                
                g_strYNUseHOTKEYKick = parser.GetSetting("NOTIFYHOTKEY", "KICK");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYKick))
                    g_strYNUseHOTKEYKick = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYKick);

                g_strYNUseHOTKEYMinimize = parser.GetSetting("NOTIFYHOTKEY", "MINIMIZE");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYMinimize))
                    g_strYNUseHOTKEYMinimize = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYMinimize);

                g_strYNUseHOTKEYClose = parser.GetSetting("NOTIFYHOTKEY", "CLOSE");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYClose))
                    g_strYNUseHOTKEYClose = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYClose);

                g_strYNUseHOTKEYWait = parser.GetSetting("NOTIFYHOTKEY", "WAIT");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYWait))
                    g_strYNUseHOTKEYWait = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYWait);

                g_strYNUseHOTKEYSold = parser.GetSetting("NOTIFYHOTKEY", "SOLD");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYSold))
                    g_strYNUseHOTKEYSold = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYSold);

                g_strYNUseHOTKEYThx = parser.GetSetting("NOTIFYHOTKEY", "THX");
                if (String.IsNullOrEmpty(g_strYNUseHOTKEYThx))
                    g_strYNUseHOTKEYThx = "N";
                DeadlyLog4Net._log.Info("checkTRDADE INVITE : " + g_strYNUseHOTKEYThx);
                #endregion

                #region [[[[[ push pin LOCK, UNLOCK ]]]]]
                string strTemp = parser.GetSetting("MISC", "PUSHPINLOCK");
                if (strTemp.ToUpper() == "N")
                {
                    DeadlyLog4Net._log.Info("PUSHPINLOCK = N");
                    g_pinLOCK = false;
                }
                else
                {
                    DeadlyLog4Net._log.Info("PUSHPINLOCK = Y");
                    g_pinLOCK = true;
                }
                #endregion

                DeadlyFlaskImage.FlaskImageTimerFromINI();

                // USE Y/N Sound Alert - Flask Timer, Notification Panel
                strTemp = parser.GetSetting("LOCATIONNOTIFY", "FLASKTIMERSOUND");
                if (String.IsNullOrEmpty(strTemp))
                    g_strTimerSound1 = "N";
                else
                    g_strTimerSound1 = strTemp;

                strTemp = parser.GetSetting("LOCATIONNOTIFY", "NOTIFICATIONSOUND");
                if (String.IsNullOrEmpty(strTemp))
                    g_strNotificationSoundYN = "Y";
                else
                    g_strNotificationSoundYN = strTemp;

                // Volume - Flask Timer, Notification Panel
                g_NotifyVolume = Convert.ToInt32(parser.GetSetting("LOCATIONNOTIFY", "VOLUME"));
                g_FlaskTimerVolume = Convert.ToInt32(parser.GetSetting("LOCATIONNOTIFY", "VOLUMEFLASKTIMER"));

                parser = null;
            }
            catch(Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);

                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read configuration. File seems to be corrupt or delete.\r\nPlease Try again.";
                DialogResult dr = frmMSG.ShowDialog();

                // Force Terminate Launcher.
                if (dr == DialogResult.OK)
                    Application.Exit();
                else
                    Application.Exit();
            }
            #endregion

            g_NinjaFileMakeAndUpdateCNT = 0;

            g_strDonator = String.Empty;
            // Read Supports.
            try
            {
                WebClient wc = new WebClientWithTimeout();
                var readData = wc.DownloadData("https://www.jumpleasure.me/deadlytrade/repository/Supporters.txt");
                g_strDonator = Encoding.UTF8.GetString(readData);
            }
            catch (WebException ex)
            {
                DeadlyLog4Net._log.Error($"Read Contents. {MethodBase.GetCurrentMethod().Name}", ex);
            }
            labelSupportersRealTime.Text = g_strDonator;
            timerScrolling.Start();

            launcherTimer.Start();
#if !DEBUG
            frmNinja = new NinjaForm();
            frmNinja.GetNinJaDataSync();
#endif
        }

        private void LauncherTimer_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            // int nCnt = CommonDeadly.GetFileCountFromFolder(g_NinjaDirectory, false);
            labelNINJASTATUS.Text = "POE.NINJA Data ("+ g_NinjaUpdatedTime + ")";

            xuiFlatProgressBar1.Value = g_NinjaFileMakeAndUpdateCNT;
#if !DEBUG
            if (g_NinjaFileMakeAndUpdateCNT >= CNT_NINJACATEGORIES)
#endif
            {
                try
                {
                    launcherTimer.Stop();
                    launcherTimer.Dispose();
                    Thread.Sleep(100);
                    if(frmNinja!=null) frmNinja.Dispose();

                    //Get_DeadlyOverlayData(); // STEP #4~14 Done.

                    Get_deadlyInformationData();

                    // STEP #15 Done.
                    xuiFlatProgressBar2.Value = 19;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));

                    //Get_matchingENGKORData();

                    // STEP #16 Done.
                    xuiFlatProgressBar2.Value = 20;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));

                    g_strExplanationLANG = g_strUILang;
                    Thread.Sleep(500);
                    timerDetect.Start();
                }
                catch (WebException ex)
                {
                    launcherTimer.Stop();
                    launcherTimer.Dispose();

                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "WebException occurred.\r\nPlease check your network and Try again~.";
                    DialogResult dr = frmMSG.ShowDialog();

                    // Force Terminate Launcher.
                    if (dr == DialogResult.OK)
                        Application.Exit();
                    else
                        Application.Exit();
                    DeadlyLog4Net._log.Error($"WebException. {MethodBase.GetCurrentMethod().Name}", ex);
                }
            }

            //DeadlyLog4Net._log.Info("LauncherTimer_Tick : " + g_NinjaFileMakeAndUpdateCNT.ToString()); // Temporary.
        }

        private void Start_ControlForm()
        {
            g_bAddonLaunched = true;

            g_handlePathOfExile = InteropCommon.FindWindow("POEWindowClass", "Path of Exile"); // ClassName = POEWindowClass
            // g_handleDeadlyTrade = FindWindow("WindowsForms10.Window.8.app.0.141b42a_r6_ad1", null); // DeadlyTrade CLASSID = "WindowsForms10.Window.8.app.0.141b42a_r6_ad1"

            //InteropCommon.GetWindowRect(g_handlePathOfExile, out g_rcPOE);
            //_rcOLDPOEWinRect = g_rcPOE;

            Thread.Sleep(100);
            timerCheckFocus.Start();

            frmMainControl = new ControlForm();
            frmMainControl.ShowIcon = false;
            frmMainControl.ShowInTaskbar = false;
            //frmMainControl.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmMainControl.Show();

            // Load_MiscForms();

            labelReady.Text = "DeadlyTrade is running...";
            btnStartAddon.Image = Properties.Resources.DeadlyTradeStartButtonDisabled;
            WindowState = FormWindowState.Minimized;
            Hide();

            InteropCommon.SetForegroundWindow(g_handlePathOfExile);
        }

        #region [[[[[ TimerDetect Tick ]]]]]
        private void TimerDetect_Tick(object sender, EventArgs e)
        {
            #region ⨌⨌ Wait for POE Launching ⨌⨌
            g_handlePathOfExile = InteropCommon.FindWindow("POEWindowClass", "Path of Exile"); // ClassName = POEWindowClass
            if (g_handlePathOfExile != IntPtr.Zero)
            {
                try
                {
                    timerDetect.Stop();
                    timerDetect.Dispose();
                    DeadlyTranslation.InitTranslateKOR();
                    DeadlyPriceCommon.InitDeadlyPriceCommon();
                
                    g_POELogPath = InteropCommon.GetPathFromHandle(LauncherForm.g_handlePathOfExile);

                    bool containsKG = Regex.IsMatch(g_POELogPath, Regex.Escape("KG"), RegexOptions.IgnoreCase);

                    if (containsKG)
                    {
                        g_POELogFileName = "KakaoClient.txt";
                        labelReady.Text = "POE [KAKAO Client] Ready to";

                        labelClient.Text = "CLIENT : KAKAO";
                    }
                    else
                    {
                        g_POELogFileName = "Client.txt";
                        labelReady.Text = "POE [GGG Client] Ready to";

                        labelClient.Text = "CLIENT : GGG";
                    }

                    if (g_strUILang == "KOR")
                        pictureBoxKOREA.BackgroundImage = Properties.Resources.flag_korea;
                    else if (g_strUILang == "ENG")
                        pictureBoxKOREA.BackgroundImage = Properties.Resources.flag_united_kingdom;
                    else
                    {
                        if (containsKG)
                        {
                            g_strUILang = "KOR";
                            pictureBoxKOREA.BackgroundImage = Properties.Resources.flag_korea;
                        }
                        else
                        {
                            g_strUILang = "ENG";
                            pictureBoxKOREA.BackgroundImage = Properties.Resources.flag_united_kingdom;
                        }
                    }

                    // Show resolution_width*resolution_height to Launcher : Modified 1.3.9.6 Ver.
                    labelUI.Text = String.Format("({0}*{1}) Your UI : {2}", resolution_width.ToString(), resolution_height.ToString(), g_strUILang);
                    labelClient.Visible = true;
                    labelUI.Visible = true;
                    pictureBoxKOREA.Visible = true;

                    g_POELogPath = Path.GetDirectoryName(g_POELogPath);

                    labelReady.Visible = true;
                    labelPOEAddonNotice.Text = "Path of Exile Detected.";

                    g_POELogPath = String.Format("{0}\\Logs\\{1}", g_POELogPath, g_POELogFileName);
                    labelPOERealPath.Text = g_POELogPath;

                    // TTTTTTT // TTTTTTTg_POELogPath = @"D:\DAUM GAMES\PATH OF EXILE\LOGS\TESTCLIENT.TXT"; 

                    string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

                    if (resolution_width < 1920 && resolution_height < 1080)
                    {
                        strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
                        if (resolution_width < 1600 && resolution_height < 1024)
                            strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini");
                        else if (LauncherForm.resolution_width < 1280)
                            strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_LOW.ini");
                    }
                    else if (resolution_width > 1920)
                        strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_HIGH.ini");

                    IniParser parser = new IniParser(strINIPath);
                    DeadlyLog4Net._log.Info($"{MethodBase.GetCurrentMethod().Name} RESOLUTION : " + strINIPath);

                    parser.AddSetting("CHARACTER", "MYNICK", g_strMyNickName);
                    parser.AddSetting("CHARACTER", "AUTOKICK", g_strTRAutoKick);

                    parser.AddSetting("DIRECTIONHELPER", "POELOGPATH", g_POELogPath);
                    parser.AddSetting("MISC", "PUSHPINLOCK", g_pinLOCK ? "Y" : "N");

                    parser.AddSetting("LOCATIONGRID", "RIGHT", g_nGridWidth.ToString());
                    parser.AddSetting("LOCATIONGRID", "BOTTOM", g_nGridHeight.ToString());
                    parser.AddSetting("MISC", "MOUSESTASHTAB", g_strYNMouseWheelStashTab);

                    DeadlyFlaskImage.FlaskImageTimerSavetoINI();

                    parser.AddSetting("MISC", "FLASKSOUND1", g_strTimerSound1);

                    parser.AddSetting("LOCATIONNOTIFY", "VOLUME", g_NotifyVolume.ToString());
                    parser.AddSetting("LOCATIONNOTIFY", "VOLUMEFLASKTIMER", g_FlaskTimerVolume.ToString());

                    DeadlyLog4Net._log.Info($"{MethodBase.GetCurrentMethod().Name} CTRL+MOUSEWHEEL : " + g_strYNMouseWheelStashTab);
                    parser.SaveSettings();
                }
                catch (Exception ex)
                {
                    timerDetect.Stop();
                    timerDetect.Dispose();
                    DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                }

                InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                this.BringToFront();

                ScrollTick = DateTime.Now;
                // Show Start Button
                ReadyToStartAddon();
                btnCleaner.Enabled = true; // Added 1.3.9.4 Ver.
                IsExistPOESettingBackup();

                // Start_ControlForm(); // Added 1.3.9.0 Ver
                //CHKCHK CheckUpdateLoop(); // Added 1.3.9.2 Ver.
                RunDeadlyTradeManager();
                Thread.Sleep(200);

                InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
                this.BringToFront();
            }
            #endregion
        } 
        #endregion

        private void RunDeadlyTradeManager()
        {
            return;
            //TODO : exe
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "aaa.EXE";
                //startInfo.Arguments = file;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        #region [[[[[ Real Time Supporters Scrolling ]]]]]
        private async Task ScrollingText()
        {
            //Task.Run(() =>
            //{
                labelSupportersRealTime.Text =
                labelSupportersRealTime.Text.Substring(1, labelSupportersRealTime.Text.Length - 1) + labelSupportersRealTime.Text.Substring(0, 1);
            //});
        }
        #endregion

        #region [[[[[ TODO : CHECK UPDATE AVAILABLE ]]]]]
        // Added 1.3.9.2
        //private async Task CheckUpdateLoop()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            #region [[[[[ Show Update Contents. ]]]]]
        //            string strRead = String.Empty;
        //            // Read Update Contents.
        //            try
        //            {
        //                WebClient wc = new WebClientWithTimeout();
        //                if (LauncherForm.g_strUILang == "KOR")
        //                {
        //                    var readData = wc.DownloadData("https://www.jumpleasure.me/deadlytrade/repository/UpdateAvailable.txt");
        //                    strRead = Encoding.UTF8.GetString(readData);
        //                }
        //                else
        //                {
        //                    var readData = wc.DownloadData("https://www.jumpleasure.me/deadlytrade/repository/UpdateAvailableEN.txt");
        //                    strRead = Encoding.UTF8.GetString(readData);
        //                }
        //            }
        //            catch (WebException ex)
        //            {
        //                DeadlyLog4Net._log.Error($"Read Contents. {MethodBase.GetCurrentMethod().Name}", ex);
        //            }

        //            Assembly assembly = Assembly.GetExecutingAssembly();
        //            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
        //            string version = fvi.FileVersion;

        //            DeadlyLog4Net._log.Info("strRead : " + strRead + " Your version : " + version);
        //            if (strRead.Trim() != version) // 1.3.9.4
        //            {
        //                if (ControlForm.g_strZoneName.ToUpper().Contains("HIDEOUT") || ControlForm.g_strZoneName.Contains("은신처"))
        //                {
        //                    ControlForm.bNeedtoShowAvailabeUpdate = true;
        //                }
        //            }
        //            #endregion

        //            // Check Duplicate Login.
        //            /*try
        //            {
        //                WebClient wc = new WebClientWithTimeout();
        //                if (LauncherForm.g_strUILang == "KOR")
        //                {
        //                    var readData = wc.DownloadData("https://www.jumpleasure.me/deadlytrade/repository/UpdateAvailable.txt");
        //                    strRead = Encoding.UTF8.GetString(readData);
        //                }
        //                else
        //                {
        //                    var readData = wc.DownloadData("https://www.jumpleasure.me/deadlytrade/repository/UpdateAvailableEN.txt");
        //                    strRead = Encoding.UTF8.GetString(readData);
        //                }
        //            }
        //            catch (WebException ex)
        //            {
        //                DeadlyLog4Net._log.Error($"Read Contents. {MethodBase.GetCurrentMethod().Name}", ex);
        //            }*/
        //        }
        //        catch (Exception ex)
        //        {
        //            DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
        //        }

        //        try
        //        {
        //            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");

        //            if (resolution_width < 1920 && resolution_height < 1080)
        //            {
        //                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1600_1024.ini");
        //                if (resolution_width < 1600 && resolution_height < 1024)
        //                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_1280_768.ini");
        //                else if (LauncherForm.resolution_width < 1280)
        //                    strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_LOW.ini");
        //            }
        //            else if (resolution_width > 1920)
        //                strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath_HIGH.ini");

        //            IniParser parser = new IniParser(strINIPath);
        //            DeadlyLog4Net._log.Info($"{MethodBase.GetCurrentMethod().Name} RESOLUTION : " + strINIPath);

        //            parser.AddSetting("CHARACTER", "MYNICK", g_strMyNickName);
        //            parser.SaveSettings();
        //        }
        //        catch (Exception ex)
        //        {
        //            DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
        //        }

        //        await Task.Delay(1000*60*60*1); // 1000ms(1s) * 60 = 60s(1m) * 60 = 60m(1h) * 1 = 1h
        //    }
        //} 
        #endregion

        #region [[[[[ Get JSON Data : DeadlyInformation ]]]]]
        private void Get_deadlyInformationData()
        {
            var tmpData = new DeadlyInformation();

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            #region ⨌⨌ Get Deadly JSON Data ⨌⨌
            try
            {
                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\ZoneInform.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationDeadly = JsonConvert.DeserializeObject<DeadlyAtlas.RootObject>(json, settings);

                    xuiFlatProgressBar2.Value = 5;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\Maps.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationMaps = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectMap>(json, settings);

                    xuiFlatProgressBar2.Value = 6;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\Currency.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationCurrency = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectCurruncy>(json, settings);

                    xuiFlatProgressBar2.Value = 7;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\DivinationCards.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationDivinationCard = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectDivinationCard>(json, settings);

                    xuiFlatProgressBar2.Value = 8;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\Delve.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationDelve = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectDelve>(json, settings);

                    xuiFlatProgressBar2.Value = 9;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\Scarabs.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationScarab = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectScarab>(json, settings);

                    xuiFlatProgressBar2.Value = 10;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\MapFragments.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationMapFragment = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectMapFragment>(json, settings);

                    xuiFlatProgressBar2.Value = 11;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\Prophecies.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationProphecy = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectProphecy>(json, settings);

                    xuiFlatProgressBar2.Value = 12;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\UniqueMaps.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationUniqueMap = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectUniqueMap>(json, settings);

                    xuiFlatProgressBar2.Value = 13;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                using (var r = new StreamReader(Application.StartupPath + "\\AtlasDrop\\Uniques.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationUniqueItem = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectUnique>(json, settings);

                    xuiFlatProgressBar2.Value = 14;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                // NOTIFICATION MESSAGE
                using (var r = new StreamReader(Application.StartupPath + "\\DeadlyInform\\NotificationMSG.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.InformationMSG = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectNotifyMSG>(json, settings);

                    xuiFlatProgressBar2.Value = 15;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                // MAP ALERT MESSAGE SETTINGS
                using (var r = new StreamReader(Application.StartupPath + "\\DeadlyInform\\MapAlertSettingMSG.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.MapAlertMSG = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectMapAlertMSG>(json, settings);

                    xuiFlatProgressBar2.Value = 16;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                // OIL PASSIVES : OilPassiveJsonData
                using (var r = new StreamReader(Application.StartupPath + "\\DeadlyInform\\OilsPassivesCollection.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.OilPassiveJsonData = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectOilsPassive>(json, settings);

                    xuiFlatProgressBar2.Value = 17;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                // OIL Anoint : Ring Anoint Data
                using (var r = new StreamReader(Application.StartupPath + "\\DeadlyInform\\OilsAnointRing.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.OilRingAnointData = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectOilsRingAnoint>(json, settings);

                    xuiFlatProgressBar2.Value = 17;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }

                // OIL Anoint : Map Anoint Data
                using (var r = new StreamReader(Application.StartupPath + "\\DeadlyInform\\OilsAnointMap.json"))
                {
                    var json = r.ReadToEnd();
                    tmpData.OilMapAnointData = JsonConvert.DeserializeObject<DeadlyAtlas.RootObjectOilsMapAnoint>(json, settings);

                    xuiFlatProgressBar2.Value = 17;
                    labelAddonStatus.Text = String.Format("Addon Data ({0})", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
                }
            }
            catch
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read Deadly Mapping Information.\r\nPlease check your addon installation and Try again.";
                DialogResult dr = frmMSG.ShowDialog();

                // Force Terminate Launcher.
                if (dr == DialogResult.OK)
                    Application.Exit();
                else
                    Application.Exit();
            }
            #endregion

            deadlyInformationData = tmpData;
            try
            {
                if (deadlyInformationData.InformationCurrency.Currency.Count <= 0 ||
                  deadlyInformationData.InformationDeadly.AtlasData.Count <= 0 ||
                  deadlyInformationData.InformationDelve.Delve.Count <= 0 ||
                  deadlyInformationData.InformationDivinationCard.DivinationCards.Count <= 0 ||
                  deadlyInformationData.InformationMapFragment.MapFragments.Count <= 0 ||
                  deadlyInformationData.InformationMaps.Maps.Count <= 0 ||
                  deadlyInformationData.InformationProphecy.Prophecies.Count <= 0 ||
                  deadlyInformationData.InformationScarab.Scarabs.Count <= 0 ||
                  deadlyInformationData.InformationUniqueItem.Uniques.Count <= 0 ||
                  deadlyInformationData.InformationUniqueMap.UniqueMaps.Count <= 0 ||
                  deadlyInformationData.InformationMSG.NotifyMSG.Count <= 0 ||
                  deadlyInformationData.MapAlertMSG.MapAlertMSG.Count <= 0)
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "Can't read Deadly Mapping Information~.\r\nPlease check your add-on installation and Try again~.";
                    DialogResult dr = frmMSG.ShowDialog();

                    // Force Terminate Launcher.
                    if (dr == DialogResult.OK)
                        Application.Exit();
                    else
                        Application.Exit();
                }
            }
            catch
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read Deadly Mapping Information~!.\r\nPlease check your add-on installation and Try again~!.";
                DialogResult dr = frmMSG.ShowDialog();

                // Force Terminate Launcher.
                if (dr == DialogResult.OK)
                    Application.Exit();
                else
                    Application.Exit();
            }

            foreach (var item in deadlyInformationData.InformationMSG.NotifyMSG)
            {
                if (item.Id == "THX")
                {
                    g_strnotiDONE = item.Msg;
                    g_strnotiDONEbtnTITLE = item.Title;
                }
                else if (item.Id == "WAIT")
                {
                    g_strnotiWAIT = item.Msg;
                    g_strnotiWAITbtnTITLE = item.Title;
                }
                else if (item.Id == "WILLING")
                {
                    g_strnotiRESEND = item.Msg;
                    // Not Title Button.
                }
                else if (item.Id == "SOLD")
                {
                    g_strnotiSOLD = item.Msg;
                    g_strnotiSOLDbtnTITLE = item.Title;
                }
                else if (item.Id == "CUSTOM1")
                {
                    g_strCUSTOM1 = item.Msg;
                    g_strCUSTOM1btnTITLE = item.Title;
                }
                else if (item.Id == "CUSTOM2")
                {
                    g_strCUSTOM2 = item.Msg;
                    g_strCUSTOM2btnTITLE = item.Title;
                }
                else if (item.Id == "CUSTOM3")
                {
                    g_strCUSTOM3 = item.Msg;
                    g_strCUSTOM3btnTITLE = item.Title;
                }
                else if (item.Id == "CUSTOM4")
                {
                    g_strCUSTOM4 = item.Msg;
                    g_strCUSTOM4btnTITLE = item.Title;
                }
            }

            foreach (var item in deadlyInformationData.MapAlertMSG.MapAlertMSG)
            {
                if (item.Id == "RED")
                {
                    foreach (var itemMsg in item.Msg)
                    {
                        g_strArrREDAlert.Add(itemMsg);
                    }
                }
                else if (item.Id == "GREEN")
                {
                    foreach (var itemMsg in item.Msg)
                    {
                        g_strArrGREENAlert.Add(itemMsg);
                    }
                }
            }

            // TODO : CHAT SCAN MESSAGE
        }
        #endregion

        #region [[[[[ Drag Moving ]]]]]
        private void PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void PictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void PictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        } 
        #endregion

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void LauncherForm_Resize(object sender, EventArgs e)
        {
            if(FormWindowState.Minimized == this.WindowState)
            {
                notifyIconDeadlyTrade.Visible = true;
                notifyIconDeadlyTrade.ShowBalloonTip(500);
                this.Hide();
                ShowInTaskbar = false;
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIconDeadlyTrade.Visible = false;
            }
        }

        #region ⨌⨌ NotifyIcon : Tray ⨌⨌
        private void NotifyIconDeadlyTrade_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timerScrolling.Start();
            this.Show();
            this.WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        #endregion

        private void BtnStartAddon_Click(object sender, EventArgs e)
        {
            if (!g_bCanLaunchAddon)
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Waiting for 'POE' Started";
                frmMSG.ShowDialog();
                return;
            }

            if (g_bAddonLaunched)
            {
                timerScrolling.Stop();
                timerScrolling.Dispose();
                WindowState = FormWindowState.Minimized;
                Hide();
                return;
            }

            if(!g_bShowLocalChat)
            {
                /*MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Addon use LOCAL CHAT Information.\r\nPlease turn on LOCAL CHAT.";
                frmMSG.ShowDialog();*/
                DeadlyLog4Net._log.Info("Addon use LOCAL CHAT Information.Please turn on LOCAL CHAT.");
            }

            timerScrolling.Stop();
            timerScrolling.Dispose();

            Start_ControlForm();
        }

        #region ⨌⨌ FormClosed : Dispose All ⨌⨌
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void LauncherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeadlyLog4Net._log.Info("〓〓〓〓〓 ↑↑↑ Launcher END ↑↑↑ 〓〓〓〓〓");

            if (timerDetect != null) timerDetect.Dispose();
            if (timerScrolling != null) timerScrolling.Dispose();
            if (frmNinja != null) frmNinja.Close();
            if (frmMainControl != null) frmMainControl.Close();

            if (ninjaData != null) ninjaData = null;
            if (deadlyInformationData != null) deadlyInformationData = null;
        }
        #endregion

        private void btnCleaner_Click(object sender, EventArgs e)
        {
            OptimizerForm frmOptimizer = new OptimizerForm();
            frmOptimizer.ShowDialog();
        }

        private void IsExistPOESettingBackup()
        {
            btnBackup.Enabled = true;
            if(File.Exists(Application.StartupPath + "\\POESetting\\production_Config.ini"))
            {
                btnRestore.Enabled = true;
            }
            else
            {
                btnRestore.Enabled = false;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\POESetting\\production_Config.ini"))
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.btmConfirm.Visible = false;
                frmMSG.btnENG.Text = "NO";
                frmMSG.btnENG.Visible = true;
                frmMSG.btnKOR.Text = "YES";
                frmMSG.btnKOR.Visible = true;
                frmMSG.lbMsg.Text = "Already exist POE setting file in backup folder. Want to overwrite?";
                DialogResult dr = frmMSG.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    BackupPOESetting();
                }
            }
            else
                BackupPOESetting();
        }

        private void BackupPOESetting()
        {
            try
            {
                String strPathPOEConifg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                strPathPOEConifg = strPathPOEConifg + "\\My Games\\Path of Exile\\production_Config.ini";
                File.Copy(strPathPOEConifg, Application.StartupPath + "\\POESetting\\production_Config.ini");
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"File Copy. {MethodBase.GetCurrentMethod().Name}", ex);
                MessageBox.Show("Backup : Failed.");
            }
            finally
            {
                MessageBox.Show("Backup : Success.");
                btnRestore.Enabled = true;
            }
        }

        private void RestorePOESetting()
        {
            try
            {
                String strPathPOEConifg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                strPathPOEConifg = strPathPOEConifg + "\\My Games\\Path of Exile\\production_Config.ini";
                File.Copy(Application.StartupPath + "\\POESetting\\production_Config.ini", strPathPOEConifg);
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"File Copy. {MethodBase.GetCurrentMethod().Name}", ex);
                MessageBox.Show("Restore : Failed.");
            }
            finally
            {
                MessageBox.Show("Restore :Success.");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\POESetting\\production_Config.ini"))
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.btmConfirm.Visible = false;
                    frmMSG.btnENG.Text = "NO";
                    frmMSG.btnENG.Visible = true;
                    frmMSG.btnKOR.Text = "YES";
                    frmMSG.btnKOR.Visible = true;
                    frmMSG.lbMsg.Text = "Really want to restore POE setting file to My Games folder from backups?";
                    DialogResult dr = frmMSG.ShowDialog();
                    if (dr == DialogResult.Yes)
                    {
                        RestorePOESetting();
                    }
                }
                else
                    MessageBox.Show("There is not exist backup file.");
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void btnToonation_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://toon.at/donate/deadly_trade");
        }

        private void btnPatron_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/bePatron?u=25155273");
        }

        private void btnPaypalSub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.jumpleasure.me/deadlytrade/?page_id=455");
        }

        private void btnPaypalSub_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.jumpleasure.me/deadlytrade/?page_id=455");
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            panelDonate.Visible = false;
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            panelDonate.Width = 548;
            panelDonate.Height = 100;
            panelDonate.Visible = true;
        }

        private void timerScrolling_Tick(object sender, EventArgs e)
        {
            try
            {
                ScrollingText();
            }
            catch (Exception ex)
            {
                timerScrolling.Stop();
                timerScrolling.Dispose();
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        #region [[[[[ Timer Check Focus ON/OFF - POE, DeadlyTrade ]]]]]
        private void timerCheckFocus_Tick(object sender, EventArgs e)
        {
            try
            {
                g_handlePathOfExile = InteropCommon.FindWindow("POEWindowClass", "Path of Exile"); // ClassName = POEWindowClass

                string strActiveWindowTitle = InteropCommon.GetActiveWindowTitle();
                //!? CHKCHK string strActiveWindowParentTitle = InteropCommon.GetActiveWindowParentTitle();
                if (strActiveWindowTitle == "DeadlyTradeForPOE" || strActiveWindowTitle == "Path of Exile" || ControlForm.gCF_bIsTextFocused)
                //!? CHKCHK strActiveWindowParentTitle == "DeadlyTradeForPOE" || strActiveWindowParentTitle == "Path of Exile" || gCF_bIsTextFocused)
                {
                    if (strActiveWindowTitle == "DeadlyTradeForPOE" || ControlForm.gCF_bIsTextFocused) //!? CHKCHK strActiveWindowParentTitle == "DeadlyTradeForPOE" || gCF_bIsTextFocused)
                    {
                        g_FocusOnAddon = true;
                    }
                    else
                    {
                        g_FocusOnAddon = false;

                        //TODO : WM_GETCURSOR GETCURSOR STATE
                    }
                    g_FocusLosing = false;
                }
                else
                {
                    g_FocusLosing = true;
                }

                //TODO: if (bNeedtoShowAvailabeUpdate)
                //TODO:     ShowAvailabeUpdatePanel();

                //if(!g_FocusLosing) // FOCUSED
                //{
                //    DetectResolutionChanging(); //  Check & Get changed resolution.
                //}
            }
            catch (Exception ex)
            {
                timerCheckFocus.Stop();
                timerCheckFocus.Dispose();
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }
        #endregion

        #region [[[[[ TODO : Multiple Monitor ]]]]]
        /*
        public static RECT g_rcPOE;
        public static RECT g_rcClient;
        public static Point g_ptLeftTop;
        private RECT _rcOLDPOEWinRect;
        public static bool g_bIsPOESizeChanged { get; set; }

        private void DetectResolutionChanging()
        {
            try
            {
                // if(Screen.AllScreens.Length > 0)
                //g_ScreenLocation = Screen.FromPoint(Cursor.Position); // Screen.FromControl(this); // by Form Control.

                InteropCommon.GetWindowRect(g_handlePathOfExile, out g_rcPOE);
                if (g_rcPOE.left != _rcOLDPOEWinRect.left || g_rcPOE.top != _rcOLDPOEWinRect.top ||
                    g_rcPOE.right != _rcOLDPOEWinRect.right || g_rcPOE.bottom != _rcOLDPOEWinRect.bottom)
                {
                    _rcOLDPOEWinRect = g_rcPOE;
                    g_bIsPOESizeChanged = true;
                }
                else
                    g_bIsPOESizeChanged = false;

                //InteropCommon.GetClientRect(g_handlePathOfExile, out g_rcClient);
                //InteropCommon.ClientToScreen(g_handlePathOfExile, ref g_ptLeftTop);
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }
        */
        #endregion
    }
}
