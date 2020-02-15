using Newtonsoft.Json;
using Ninja_Price.API.PoeNinja;
using Ninja_Price.API.PoeNinja.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using log4net;

namespace POExileDirection
{
    public partial class NinjaForm : Form
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool UpdatingFromJson { get; set; } = false;
        public bool UpdatingFromAPI { get; set; } = false;

        Dictionary<string, double> CurrencyNameAndAverage = new Dictionary<string, double>();

        Dictionary<string, double> CurrencyCalcDictionary = new Dictionary<string, double>();
        bool bCanUseSelectedChange = false;

        public static double oneExaltedChaos = 0.0;

        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        private string _strNowSearching = String.Empty;

        public NinjaForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var Params = base.CreateParams;
        //        Params.ExStyle |= 0x80;
        //        return Params;
        //    }
        //}

        private void NinjaForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

            Init_Controls();

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

            string sLeft = parser.GetSetting("LOCATIONCURR", "LEFT");
            string sTop = parser.GetSetting("LOCATIONCURR", "TOP");

            if (sLeft != null && sTop != null)
            {
                this.Left = Int32.Parse(sLeft);
                this.Top = Int32.Parse(sTop);
            }

            // TO DO : Need to Splash
            // Not for Deployment. Init_Ninja_API();

            xuiFlatProgressBar1.MaxValue = LauncherForm.CNT_NINJACATEGORIES * 2;
            xuiFlatProgressBar1.Value = 0;

            // GetJsonData(LauncherForm.g_CurrentLeague);

            //Show_CurrencySummury();
            _strNowSearching = "";
            Visible = true;

            BtnCurrency_Click(sender, e);
            // UpdatePoeNinjaData();
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        public void Init_Controls()
        {
            // PROGRESS BAR
            xuiFlatProgressBar1.MaxValue = LauncherForm.CNT_NINJACATEGORIES * 2; // Make and Update

            // Currency Listview
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.None;

            // LEAGUE
            cbLeague.Sorted = false;
            cbLeague.SelectedIndex = cbLeague.FindStringExact(LauncherForm.g_CurrentLeague);

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose.TabStop = false;

            // btnCurrency
            /*btnCurrency.FlatStyle = FlatStyle.Flat;
            btnCurrency.BackColor = Color.Transparent;
            btnCurrency.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCurrency.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCurrency.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnCurrency.FlatAppearance.BorderSize = 0;
            btnCurrency.TabStop = false;

            // btnSimple
            btnSimple.FlatStyle = FlatStyle.Flat;
            // btnSimple.BackColor = Color.Transparent;
            btnSimple.FlatAppearance.MouseDownBackColor = Color.Transparent;
            // btnSimple.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimple.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnSimple.FlatAppearance.BorderSize = 0;
            btnSimple.TabStop = false;*/
        }
        #endregion

        /*public void Init_Ninja_API()
        {
            btnCurrency.Hide();

            // GatherLeagueNames();
            CurrentLeague = "Legion";
            GetJsonData(CurrentLeague);
            UpdatePoeNinjaData();

            btnCurrency.Show();
        }*/

        #region ⨌⨌ GET NINJA DATA : LEAGUE ⨌⨌
        private void GetJsonData(string league)
        {
            // Ignore NULL Data.
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            cbCurrency.Items.Clear();
            CurrencyCalcDictionary.Clear();
            timerNinja.Start();
            LauncherForm.g_NinjaFileMakeAndUpdateCNT = 0;

            // Task tWait =
            Task.Run(() =>
            {
                while (UpdatingFromAPI || UpdatingFromJson)
                {
                    Thread.Sleep(250);
                }

                UpdatingFromAPI = true;
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Currency.json", JsonConvert.DeserializeObject<Currency.RootObject>(Api.DownloadFromUrl(LauncherForm.CurrencyURL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "DivinationCards.json", JsonConvert.DeserializeObject<DivinationCards.RootObject>(Api.DownloadFromUrl(LauncherForm.DivinationCards_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Essences.json", JsonConvert.DeserializeObject<Essences.RootObject>(Api.DownloadFromUrl(LauncherForm.Essences_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Fragments.json", JsonConvert.DeserializeObject<Fragments.RootObject>(Api.DownloadFromUrl(LauncherForm.Fragments_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Prophecies.json", JsonConvert.DeserializeObject<Prophecies.RootObject>(Api.DownloadFromUrl(LauncherForm.Prophecies_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "UniqueAccessories.json", JsonConvert.DeserializeObject<UniqueAccessories.RootObject>(Api.DownloadFromUrl(LauncherForm.UniqueAccessories_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "UniqueArmours.json", JsonConvert.DeserializeObject<UniqueArmours.RootObject>(Api.DownloadFromUrl(LauncherForm.UniqueArmours_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "UniqueFlasks.json", JsonConvert.DeserializeObject<UniqueFlasks.RootObject>(Api.DownloadFromUrl(LauncherForm.UniqueFlasks_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "UniqueJewels.json", JsonConvert.DeserializeObject<UniqueJewels.RootObject>(Api.DownloadFromUrl(LauncherForm.UniqueJewels_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "UniqueMaps.json", JsonConvert.DeserializeObject<UniqueMaps.RootObject>(Api.DownloadFromUrl(LauncherForm.UniqueMaps_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "UniqueWeapons.json", JsonConvert.DeserializeObject<UniqueWeapons.RootObject>(Api.DownloadFromUrl(LauncherForm.UniqueWeapons_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "WhiteMaps.json", JsonConvert.DeserializeObject<WhiteMaps.RootObject>(Api.DownloadFromUrl(LauncherForm.WhiteMaps_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Resonators.json", JsonConvert.DeserializeObject<Resonators.RootObject>(Api.DownloadFromUrl(LauncherForm.Resonators_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Fossils.json", JsonConvert.DeserializeObject<Fossils.RootObject>(Api.DownloadFromUrl(LauncherForm.Fossils_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Incubators.json", JsonConvert.DeserializeObject<Incubators.RootObject>(Api.DownloadFromUrl(LauncherForm.Incubators_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Scarabs.json", JsonConvert.DeserializeObject<Scarab.RootObject>(Api.DownloadFromUrl(LauncherForm.Scarabs_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try // BlightOil_URL : Added 1.3.9.0 Version
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Oils.json", JsonConvert.DeserializeObject<Oils.RootObject>(Api.DownloadFromUrl(LauncherForm.BlightOil_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }

                try // Watchstones_URL : Added 1.3.9.0 Version
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Watchstones.json", JsonConvert.DeserializeObject<Watchstones.RootObject>(Api.DownloadFromUrl(LauncherForm.Watchstones_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch (Exception ex)
                {
                    DeadlyLog4Net._log.Error("Error Watchstones Data : " + ex.ToString());
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }

                try // Beasts_URL : Added 1.3.9.1 Version
                {
                    Api.JsonAPI.SaveSettingFile(Application.StartupPath + "\\NinjaData\\" + "Beasts.json", JsonConvert.DeserializeObject<Beasts.RootObject>(Api.DownloadFromUrl(LauncherForm.Beasts_URL + league), settings));
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                    LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                }
                catch (Exception ex)
                {
                    DeadlyLog4Net._log.Error("Error Beasts Data : " + ex.ToString());
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }

                UpdatingFromAPI = false;
            });

            // tWait.Wait();
            UpdatePoeNinjaData();
        }

        private void UpdatePoeNinjaData()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            // Task tWait =
            Task.Run(() =>
            {
                while (UpdatingFromAPI || UpdatingFromJson)
                {
                    Thread.Sleep(250);
                }

                UpdatingFromJson = true;

                var tmpData = new LauncherForm.NinJaAPIData();

                #region ⨌⨌ Get 16 Types data from NINJA API + 1 Type (Blight Oil) ⨌⨌
                try
                {
                    if (JsonExists("Currency.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Currency.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Currency = JsonConvert.DeserializeObject<Currency.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("DivinationCards.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "DivinationCards.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.DivinationCards = JsonConvert.DeserializeObject<DivinationCards.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("Essences.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Essences.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Essences = JsonConvert.DeserializeObject<Essences.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("Fragments.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Fragments.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Fragments = JsonConvert.DeserializeObject<Fragments.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("Prophecies.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Prophecies.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Prophecies = JsonConvert.DeserializeObject<Prophecies.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("UniqueAccessories.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "UniqueAccessories.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.UniqueAccessories = JsonConvert.DeserializeObject<UniqueAccessories.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("UniqueArmours.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "UniqueArmours.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.UniqueArmours = JsonConvert.DeserializeObject<UniqueArmours.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("UniqueFlasks.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "UniqueFlasks.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.UniqueFlasks = JsonConvert.DeserializeObject<UniqueFlasks.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("UniqueJewels.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "UniqueJewels.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.UniqueJewels = JsonConvert.DeserializeObject<UniqueJewels.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("UniqueMaps.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "UniqueMaps.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.UniqueMaps = JsonConvert.DeserializeObject<UniqueMaps.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("UniqueWeapons.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "UniqueWeapons.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.UniqueWeapons = JsonConvert.DeserializeObject<UniqueWeapons.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("WhiteMaps.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "WhiteMaps.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.WhiteMaps = JsonConvert.DeserializeObject<WhiteMaps.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("Resonators.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Resonators.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Resonators = JsonConvert.DeserializeObject<Resonators.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("Fossils.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Fossils.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Fossils = JsonConvert.DeserializeObject<Fossils.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("Incubators.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Incubators.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Incubators = JsonConvert.DeserializeObject<Incubators.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try
                {
                    if (JsonExists("Scarabs.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Scarabs.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Scarabs = JsonConvert.DeserializeObject<Scarab.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try // BlightOil_URL : Added 1.3.9.0 Version
                {
                    if (JsonExists("Oils.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Oils.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Oils = JsonConvert.DeserializeObject<Oils.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try // Watchstones_URL : Added 1.3.9.0 Version
                {
                    if (JsonExists("Watchstones.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Watchstones.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Watchstones = JsonConvert.DeserializeObject<Watchstones.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                try // Beasts_URL : Added 1.3.9.1 Version
                {
                    if (JsonExists("Beasts.json"))
                        using (var r = new StreamReader(Application.StartupPath + "\\NinjaData\\" + "Beasts.json"))
                        {
                            var json = r.ReadToEnd();
                            tmpData.Beasts = JsonConvert.DeserializeObject<Beasts.RootObject>(json, settings);

                            LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                            LauncherForm.g_NinjaUpdatedTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                        }
                }
                catch
                {
                    LauncherForm.g_NinjaFileMakeAndUpdateCNT = LauncherForm.g_NinjaFileMakeAndUpdateCNT + 1;
                }
                #endregion

                LauncherForm.ninjaData = new LauncherForm.NinJaAPIData();
                LauncherForm.ninjaData = tmpData;
                UpdatingFromJson = false;
            });

            // tWait.Wait();               
        }
        #endregion

        public bool JsonExists(string fileName)
        {
            return File.Exists(Application.StartupPath + "\\NinjaData\\" + fileName);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ControlForm.bShowNinja = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            this.Close();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        // Exalted to Chaos
        private void BtnSimple_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == null)
            {
                MessageBox.Show("잘못된 계산입니다. 다시 입력해주세요.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double nCalcRet = 0.0;
            string sInput = textBox1.Text;
            if (oneExaltedChaos != 0)
            {
                nCalcRet = oneExaltedChaos * Convert.ToDouble(sInput);

                textBox2.Text = nCalcRet.ToString("N2");
            }
        }

        // Chaos to Exalted
        private void ButtonExalted_Click(object sender, EventArgs e)
        {
            if (textBoxChaos.Text == "0" || textBoxChaos.Text == null)
            {
                MessageBox.Show("잘못된 계산입니다. 다시 입력해주세요.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double nCalcRet = 0.0;
            string sInput = textBoxChaos.Text;
            if (oneExaltedChaos != 0)
            {
                nCalcRet = Convert.ToDouble(sInput) / oneExaltedChaos;

                textBoxExalted.Text = nCalcRet.ToString("N2");
            }
        }

        // Selected Currency to Chaos
        private void BtnForceChaos_Click(object sender, EventArgs e)
        {
            if (textBoxFreeChoice.Text == "0" || textBoxFreeChoice.Text == null)
            {
                MessageBox.Show("잘못된 계산입니다. 다시 입력해주세요.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCurrency.SelectedIndex < 0)
            {
                MessageBox.Show("계산을 원하는 커런시를 선택해주세요.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strSelectedCurrency = cbCurrency.Items[cbCurrency.SelectedIndex].ToString();

            double nCalcRet = 0.0;
            double dSelectedCurr = 0;
            CurrencyCalcDictionary.TryGetValue(strSelectedCurrency, out dSelectedCurr);
            if (dSelectedCurr <= 0.0)
            {
                MessageBox.Show("선택한 커런시가 0.0 카오스라서 계산할 수 없습니다.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (oneExaltedChaos != 0)
            {
                nCalcRet = Convert.ToDouble(dSelectedCurr * Convert.ToDouble(textBoxFreeChoice.Text));
                textForceChaosResult.Text = nCalcRet.ToString("N2");
                textForceChaostoExalted.Text = (nCalcRet / oneExaltedChaos).ToString("N2");
            }

            bCanUseSelectedChange = true;
        }

        private void BtnBulkCalc_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count < 1)
                return;

            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                int nIndex = listView1.FocusedItem.Index;
                if (nIndex < 0)
                    return;

                if (Convert.ToInt32(textBoxBulkCNT.Text) < 0 || textBoxBulkCNT.Text == null || textBoxBulkCNT.Text == String.Empty || textBoxBulkCNT.Text == "")
                    return;

                string strChaos = listView1.Items[nIndex].SubItems[1].Text;

                double nCalcRetChaos = 0.0;
                nCalcRetChaos = Convert.ToDouble(Convert.ToInt32(textBoxBulkCNT.Text) * Convert.ToDouble(strChaos));
                double nCalcRetExalted = 0.0;
                if (oneExaltedChaos != 0)
                {
                    nCalcRetExalted = nCalcRetChaos / oneExaltedChaos;
                } // Modified 1.3.9.6 Ver.

                textBoxBulkChaos.Text = nCalcRetChaos.ToString("N2");
                textBoxBulkExalted.Text = nCalcRetExalted.ToString("N2");
            }
        }

        private void CbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bCanUseSelectedChange) return;

            if (cbCurrency.SelectedIndex < 0)
                return;
            BtnForceChaos_Click(sender, e);
        }

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

            parser.AddSetting("LOCATIONCURR", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONCURR", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        private void NinjaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox2.Dispose();
            this.Dispose();
        }

        private void Update_ListViewChaosExalted()
        {
            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                double nCalcRet = 0.0;
                string sExalted = nCalcRet.ToString("N2");
                if (oneExaltedChaos != 0)
                {
                    nCalcRet = objShow.Value / oneExaltedChaos;

                    sExalted = nCalcRet.ToString("N2");
                }

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.SubItems.Add(sExalted);
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }
        }

        private void Clear_Bulk_CalcText()
        {
            textBoxBulkCNT.Text = "1";

            textBoxBulkChaos.Text = "";
            textBoxBulkExalted.Text = "";

            // Show_CurrencySummury();
        }

        #region ⨌⨌ 16 Types data BUTTON CLICK FUNCTION ⨌⨌
        #region #1 Currency
        private void BtnCurrency_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Currency";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            cbCurrency.Items.Clear();
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

                if (CurrencyNameAndAverage.ContainsKey(strItemName)) continue;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                {
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosEquivalent);
                    CurrencyCalcDictionary.Add(strItemName, objLine.ChaosEquivalent);
                    cbCurrency.Items.Add(strItemName);

                    foreach (var objDetail in LauncherForm.ninjaData.Currency.CurrencyDetails)
                    {
                        if (objLine.CurrencyTypeName == objDetail.Name)
                        {
                            imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                            /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                            WebResponse TmpResponse = TmpRequest.GetResponse();

                            Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                            TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                            imgList.Images.Add(TmpBmp);*/
                        }
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            foreach (var objLine in LauncherForm.ninjaData.Currency.Lines)
            {
                if (objLine.CurrencyTypeName == "Exalted Orb")
                {
                    oneExaltedChaos = objLine.ChaosEquivalent;
                    break;
                }
            }

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            if (oneExaltedChaos != 0) labelChaos.Text = oneExaltedChaos.ToString("N2");

            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #2 Fragments
        private void BtnFragments_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Fragments";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Fragments.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.CurrencyTypeName)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transFragments.ContainsKey(objLine.CurrencyTypeName))
                        strItemName = NinjaTranslation.transFragments[objLine.CurrencyTypeName];
                }
                else
                    strItemName = objLine.CurrencyTypeName;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosEquivalent);

                foreach (var objDetail in LauncherForm.ninjaData.Fragments.CurrencyDetails)
                {
                    if (objLine.CurrencyTypeName == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #3 Watchstones
        private void btnWatchstones_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Watchstones";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            try
            {
                ImageList imgList = new ImageList();

                string strItemName = String.Empty;
                foreach (var objLine in LauncherForm.ninjaData.Watchstones.lines)
                {
                    if (CurrencyNameAndAverage.ContainsKey(objLine.name)) continue;

                    if (LauncherForm.g_strUILang == "KOR")
                    {
                        if (NinjaTranslation.transWatchstones.ContainsKey(objLine.name))
                            strItemName = NinjaTranslation.transWatchstones[objLine.name];
                    }
                    else
                        strItemName = objLine.name;

                    if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                        CurrencyNameAndAverage.Add(strItemName, objLine.chaosValue);

                    foreach (var objDetail in LauncherForm.ninjaData.Watchstones.lines)
                    {
                        if (objLine.name == objDetail.name)
                            imgList.Images.Add(Properties.Resources.Watchstone_24px);
                    }
                }

                listView1.SmallImageList = imgList;

                Update_ListViewChaosExalted();

                labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                ButtonEnableTRUEFALSE(true);
            }
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #4 Oils
        private void btnOils_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Oils";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Oils.lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transBlightOil.ContainsKey(objLine.name))
                        strItemName = NinjaTranslation.transBlightOil[objLine.name];
                }
                else
                    strItemName = objLine.name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.chaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Oils.lines)
                {
                    if (objLine.name == objDetail.name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #5 Incubators
        private void BtnIncubators_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Incubators";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Incubators.lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transIncubators.ContainsKey(objLine.name))
                        strItemName = NinjaTranslation.transIncubators[objLine.name];
                }
                else
                    strItemName = objLine.name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.chaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Incubators.lines)
                {
                    if (objLine.name == objDetail.name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #6 Scarabs
        private void BtnScarabs_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Scarabs";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Scarabs.lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transScarabs.ContainsKey(objLine.name))
                        strItemName = NinjaTranslation.transScarabs[objLine.name];
                }
                else
                    strItemName = objLine.name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.chaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Scarabs.lines)
                {
                    if (objLine.name == objDetail.name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #7 Fossils
        private void BtnFossils_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Fossils";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Fossils.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transFossils.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transFossils[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Fossils.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #8 Resonators
        private void BtnResonators_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Resonators";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Resonators.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transResonators.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transResonators[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Resonators.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #9 Essences
        private void BtnEssences_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Essences";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Essences.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transEssences.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transEssences[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Essences.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #10 DivinationCards
        private void BtnDivinationCards_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "DivinationCards";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.DivinationCards.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transDivinationCards.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transDivinationCards[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.DivinationCards.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                        imgList.Images.Add(Bitmap.FromFile(@".\NINJA\DIVInventoryIcon.png"));
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #11 Prophecies
        private void BtnProphecies_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Prophecies";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Prophecies.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transProphecies.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transProphecies[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Prophecies.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                        imgList.Images.Add(Bitmap.FromFile(@".\NINJA\ProphecyOrbRed.png"));
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #12 UniqueMaps
        private void BtnUniqueMaps_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "UniqueMaps";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            try
            {
                listView1.Items.Clear();
                CurrencyNameAndAverage.Clear();
                ImageList imgList = new ImageList();

                string strItemName = String.Empty;
                foreach (var objLine in LauncherForm.ninjaData.UniqueMaps.Lines)
                {
                    if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                    objLine.Name = objLine.Name.Replace("r철m", "röm");

                    if (LauncherForm.g_strUILang == "KOR")
                    {
                        if (NinjaTranslation.transUniqueMaps.ContainsKey(objLine.Name))
                            strItemName = NinjaTranslation.transUniqueMaps[objLine.Name];
                    }
                    else
                        strItemName = objLine.Name;

                    if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objLine.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(NinjaTranslation.UniqueMapImages[objLine.Name]);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objLine.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/

                        CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);
                    }
                }

                listView1.SmallImageList = imgList;

                Update_ListViewChaosExalted();

                labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
                ButtonEnableTRUEFALSE(true);
            }
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #13 Maps
        private void BtnMaps_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Maps";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.WhiteMaps.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transWhiteMaps.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transWhiteMaps[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.WhiteMaps.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        if (objDetail.Name.ToUpper().Contains("BLIGHT"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Blighted.png"));
                        else if (objDetail.Name.ToUpper().Contains("CHIMERA"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Chimera.png"));
                        else if (objDetail.Name.ToUpper().Contains("ELDER"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Elder.png"));
                        else if (objDetail.Name.ToUpper().Contains("SHAPED"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Shaped.png"));
                        else if (objDetail.Name.ToUpper().Contains("MINOTAUR"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Minotaur.png"));
                        else if (objDetail.Name.ToUpper().Contains("PHOENIX"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Phoenix.png"));
                        else if (objDetail.Name.ToUpper().Contains("VAAL"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_VaalTempleBase.png"));
                        else if (objDetail.Name.ToUpper().Contains("HYDRA"))
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Hydra.png"));
                        else
                            imgList.Images.Add(Bitmap.FromFile(@".\DeadlyInform\MAP_Normal.png"));
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #14 UniqueJewels
        private void BtnUniqueJewels_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "UniqueJewels";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.UniqueJewels.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transUniqueJewels.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transUniqueJewels[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.UniqueJewels.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #15 UniqueFlasks
        private void BtnUniqueFlasks_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "UniqueFlasks";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.UniqueFlasks.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transUniqueFlasks.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transUniqueFlasks[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.UniqueFlasks.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #16 UniqueWeapons
        private void BtnUniqueWeapons_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "UniqueWeapons";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.UniqueWeapons.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                objLine.Name = objLine.Name.Replace("r철m", "röm");
                objLine.Name = objLine.Name.Replace("Mj철lner", "Mjölner");

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transUniqueWeapons.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transUniqueWeapons[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.UniqueWeapons.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #17 UniqueArmous
        private void BtnUniqueArmours_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "UniqueArmours";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.UniqueArmours.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transUniqueArmours.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transUniqueArmours[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.UniqueArmours.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #18 UniqueAccessories
        private void BtnUniqueAccessories_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "UniqueAccessories";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.UniqueAccessories.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transUniqueAccessories.ContainsKey(objLine.Name))
                        strItemName = NinjaTranslation.transUniqueAccessories[objLine.Name];
                }
                else
                    strItemName = objLine.Name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.ChaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.UniqueAccessories.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        imgList.Images.Add(Bitmap.FromFile(Application.StartupPath + "\\NINJA\\PriceImages\\" + objDetail.Name + ".png"));
                        /*WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());
                        TmpBmp.Save(Application.StartupPath + "\\NinjaData\\Images\\" + objDetail.Name + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        imgList.Images.Add(TmpBmp);*/
                    }
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #region #19 Beasts
        private void btnBeast_Click(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            _strNowSearching = "Beasts";
            // UpdatePoeNinjaData();

            Clear_Bulk_CalcText();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            string strItemName = String.Empty;
            foreach (var objLine in LauncherForm.ninjaData.Beasts.lines)
            {
                if (LauncherForm.g_strUILang == "KOR")
                {
                    if (NinjaTranslation.transBeasts.ContainsKey(objLine.name))
                        strItemName = NinjaTranslation.transBeasts[objLine.name];
                }
                else
                    strItemName = objLine.name;

                if (!CurrencyNameAndAverage.ContainsKey(strItemName))
                    CurrencyNameAndAverage.Add(strItemName, objLine.chaosValue);

                foreach (var objDetail in LauncherForm.ninjaData.Beasts.lines)
                {
                    if (objLine.name == objDetail.name)
                        imgList.Images.Add(Properties.Resources.BestiaryOrb_24px);
                }
            }

            listView1.SmallImageList = imgList;

            Update_ListViewChaosExalted();

            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
            ButtonEnableTRUEFALSE(true);
        }
        #endregion
        #endregion

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null)
                return;

            int nIndex = listView1.FocusedItem.Index;
            string strSelectedName = listView1.Items[nIndex].SubItems[0].Text;

            labelstrSearching.Text = strSelectedName;

            try
            {
                /*bool bFound = false;
                switch (_strNowSearching)
                {
                    case "Currency":// #1
                        //labelKOREAN.Text = Get_KORNameCurrency(strSelectedName);
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transCurrency.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transCurrency[strSelectedName];
                        bFound = true;
                        break;
                    case "Fragments":// #2
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transFragments.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transFragments[strSelectedName];
                        bFound = true;
                        break;
                    case "Watchstones":// #3
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transWatchstones.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transWatchstones[strSelectedName];
                        bFound = true;
                        break;
                    case "Oils":// #4
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transBlightOil.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transBlightOil[strSelectedName];
                        bFound = true;
                        break;
                    case "Incubators":// #5
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transIncubators.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transIncubators[strSelectedName];
                        bFound = true;
                        break;
                    case "Scarabs":// #6
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transScarabs.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transScarabs[strSelectedName];
                        bFound = true;
                        break;
                    case "Fossils":// #7
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transFossils.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transFossils[strSelectedName];
                        bFound = true;
                        break;
                    case "Resonators":// #8
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transResonators.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transResonators[strSelectedName];
                        bFound = true;
                        break;
                    case "Essences":// #9
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transEssences.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transEssences[strSelectedName];
                        bFound = true;
                        break;                       
                    case "DivinationCards":// #10
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transDivinationCards.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transDivinationCards[strSelectedName];
                        bFound = true;
                        break;
                    case "Prophecies":// #11
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transProphecies.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transProphecies[strSelectedName];
                        bFound = true;
                        break;
                    case "UniqueMaps":// #12
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transUniqueMaps.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transUniqueMaps[strSelectedName];
                        bFound = true;
                        break;
                    case "Maps":// #13
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transWhiteMaps.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transWhiteMaps[strSelectedName];
                        bFound = true;
                        break;
                    case "UniqueJewels":// #14
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transUniqueJewels.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transUniqueJewels[strSelectedName];
                        bFound = true;
                        break;
                    case "UniqueFlasks":// #15
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transUniqueFlasks.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transUniqueFlasks[strSelectedName];
                        bFound = true;
                        break;
                    case "UniqueWeapons":// #16
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transUniqueWeapons.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transUniqueWeapons[strSelectedName];
                        bFound = true;
                        break;
                    case "UniqueArmours":// #17
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transUniqueArmours.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transUniqueArmours[strSelectedName];
                        bFound = true;
                        break;
                    case "UniqueAccessories":// #18
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transUniqueAccessories.FirstOrDefault(x => x.Value == strSelectedName).Key;
                        else
                            labelKOREAN.Text = NinjaTranslation.transUniqueAccessories[strSelectedName];
                        bFound = true;
                        break;
                    case "Beasts":// #19
                        if (LauncherForm.g_strUILang == "KOR")
                            labelKOREAN.Text = NinjaTranslation.transBeasts[strSelectedName];
                        bFound = true;
                        break;
                    default:
                        bFound = false;
                        break;
                }
                
                if (!bFound)
                {
                    // Others.
                    foreach (var objKR in LauncherForm.matchingENGKORData.engkorMatching.EnkrData)
                    {
                        if (objKR.en.ToUpper() == strSelectedName.ToUpper())
                        {
                            labelKOREAN.Text = objKR.kr;
                            break;
                        }
                    }
                }*/

                BtnBulkCalc_Click(this, new EventArgs()); // Bulk Calc.
            }
            catch (Exception ex)
            {
                //labelKOREAN.Text = "";
                DeadlyLog4Net._log.Error("SelectedIndexChanged : " + ex.ToString());
            }
        }

        #region [[[[[ Removed : 1.3.9.3 Version ]]]]]
        /*private string Get_KORNameCurrency(string strFind)
        {
            string strRet = "";

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationCurrency.Currency)
                {
                    if (objKR.Name_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Name_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }
        
        private string Get_KORNameDivinationCards(string strFind)
        {
            string strRet = "";

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationDivinationCard.DivinationCards)
                {
                    if (objKR.Name_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Name_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }

        private string Get_KORNameDelve(string strFind)
        {
            string strRet = "";

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationDelve.Delve)
                {
                    if (objKR.Name_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Name_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }

        private string Get_KORNameScarabs(string strFind)
        {
            string strRet = "";

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationScarab.Scarabs)
                {
                    if (objKR.Name_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Name_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }

        private string Get_KORNameFragments(string strFind)
        {
            string strRet = "";

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationMapFragment.MapFragments)
                {
                    if (objKR.Name_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Name_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }

        private string Get_KORNameProphecies(string strFind)
        {
            string strRet = "";

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationProphecy.Prophecies)
                {
                    if (objKR.Name_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Name_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }

        private string Get_KORNameMaps(string strFind)
        {
            string strRet = "";

            bool bIsElder = false;
            if (strFind.ToUpper().Contains("ELDER"))
                bIsElder = true;
            else
                bIsElder = false;

            bool bIsShaped = false;
            if (strFind.ToUpper().Contains("SHAPED"))
                bIsShaped = true;
            else
                bIsShaped = false;

            strFind = Regex.Replace(strFind, "Elder ", "");
            strFind = Regex.Replace(strFind, "elder ", "");

            strFind = Regex.Replace(strFind, "Shaped ", "");
            strFind = Regex.Replace(strFind, "shaped ", "");

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationMaps.Maps)
                {
                    if (objKR.Text_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Text_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            if (bIsElder)
                strRet = "엘더 " + strRet;

            if (bIsShaped)
                strRet = "쉐이퍼 " + strRet;

            return strRet;
        }

        private string Get_KORNameUniqueMaps(string strFind)
        {
            string strRet = "";

            if(strFind.ToUpper().Contains("PERANDUS"))
            {
                strFind = "Perandus Manor";
            }

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationUniqueMap.UniqueMaps)
                {
                    if (objKR.Text_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Text_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }

        private string Get_KORNameUniqueItems(string strFind)
        {
            string strRet = "";

            try
            {
                foreach (var objKR in LauncherForm.deadlyInformationData.InformationUniqueItem.Uniques)
                {
                    if (objKR.Text_en.ToUpper() == strFind.ToUpper())
                    {
                        strRet = objKR.Text_ko;
                        break;
                    }
                }
            }
            catch
            {
                strRet = "";
            }

            return strRet;
        }*/
        #endregion

        private void LinkLabelTrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://poe.trade/");
        }

        private void LinkLabelMap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://poemap.live/");
        }

        private void LinkLabelDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://poedb.tw/kr");
        }

        private void LinkLabelAffix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://poeaffix.net/");
        }

        private void LinkLabelNinja_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://poe.ninja/");
        }

        private void LinkLabelKAKAOTrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // KAKAO Trade Home
            System.Diagnostics.Process.Start("https://poe.game.daum.net/trade/search/" + LauncherForm.g_CurrentLeague);
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // GGG Trade Home
            System.Diagnostics.Process.Start("https://www.pathofexile.com/trade/search/" + LauncherForm.g_CurrentLeague);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://poeapp.com");
        }

        private void TimerNinja_Tick(object sender, EventArgs e)
        {
            ButtonEnableTRUEFALSE(false);
            panelGetData.Left = 133;
            panelGetData.Top = 58;
            panelGetData.Width = 658;
            panelGetData.Height = 665;
            panelGetData.Visible = true;

            xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
            labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;

            Thread.Sleep(100);
            if (LauncherForm.g_NinjaFileMakeAndUpdateCNT >= LauncherForm.CNT_NINJACATEGORIES * 2)
            {
                timerNinja.Stop();
                Thread.Sleep(100);
                xuiFlatProgressBar1.Value = LauncherForm.g_NinjaFileMakeAndUpdateCNT;
                labelDateTimeCalc.Text = "Last Checked : " + LauncherForm.g_NinjaUpdatedTime;
                Thread.Sleep(100);

                //Show_CurrencySummury();

                BtnCurrency_Click(sender, e);
                panelGetData.Visible = false;
                ButtonEnableTRUEFALSE(true);
            }
        }

        private void CbLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LauncherForm.g_CurrentLeague == (string)cbLeague.SelectedItem)
            {
                DeadlyLog4Net._log.Info("CbLeague : Selected same league.");
                return;
            }

            LauncherForm.ninjaData = null;
            LauncherForm.g_CurrentLeague = (string)cbLeague.SelectedItem;

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

            parser.AddSetting("LEAGUE", "USERCHOICE", cbLeague.SelectedIndex.ToString());
            parser.SaveSettings();

            textBox1.Text = "";
            textBox2.Text = "";
            textBoxChaos.Text = "";
            textBoxExalted.Text = "";
            textBoxFreeChoice.Text = "";
            textForceChaosResult.Text = "";
            textForceChaostoExalted.Text = "";
            cbCurrency.SelectedIndex = 0;
            Invalidate();
            GetNinJaDataSync();
        }

        public void GetNinJaDataSync()
        {
            xuiFlatProgressBar1.MaxValue = LauncherForm.CNT_NINJACATEGORIES * 2;
            xuiFlatProgressBar1.Value = 0;
            LauncherForm.g_NinjaFileMakeAndUpdateCNT = 0;
            GetJsonData(LauncherForm.g_CurrentLeague);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSimple_Click(this, new EventArgs());
        }

        private void TextBoxChaos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ButtonExalted_Click(this, new EventArgs());
        }

        private void TextBoxBulkCNT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnBulkCalc_Click(this, new EventArgs());
        }

        private void TextBoxBulkCNT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only Numeric
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ButtonEnableTRUEFALSE(bool bFlag)
        {
            btnRefresh.Enabled = bFlag;
            btnSearch.Enabled = bFlag;
            btnCurrency.Enabled = bFlag;
            btnFragments.Enabled = bFlag;
            btnWatchstones.Enabled = bFlag;
            btnOils.Enabled = bFlag;
            btnIncubators.Enabled = bFlag;
            btnScarabs.Enabled = bFlag;
            btnFossils.Enabled = bFlag;
            btnResonators.Enabled = bFlag;
            btnEssences.Enabled = bFlag;
            btnDivinationCards.Enabled = bFlag;
            btnProphecies.Enabled = bFlag;
            btnUniqueMaps.Enabled = bFlag;
            btnMaps.Enabled = bFlag;
            btnUniqueJewels.Enabled = bFlag;
            btnUniqueFlasks.Enabled = bFlag;
            btnUniqueWeapons.Enabled = bFlag;
            btnUniqueArmours.Enabled = bFlag;
            btnUniqueAccessories.Enabled = bFlag;
            btnBeast.Enabled = bFlag;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LauncherForm.ninjaData = null;
            LauncherForm.g_CurrentLeague = (string)cbLeague.SelectedItem;

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

            parser.AddSetting("LEAGUE", "USERCHOICE", cbLeague.SelectedIndex.ToString());
            parser.SaveSettings();

            textBox1.Text = "";
            textBox2.Text = "";
            textBoxChaos.Text = "";
            textBoxExalted.Text = "";
            textBoxFreeChoice.Text = "";
            textForceChaosResult.Text = "";
            textForceChaostoExalted.Text = "";
            cbCurrency.SelectedIndex = 0;
            Invalidate();
            GetNinJaDataSync();
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            btnRefresh.Image = Properties.Resources.Refresh_3_over;
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.Image = Properties.Resources.Refresh_3;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count <= 0)
                return;

            foreach (ListViewItem item in listView1.Items)
            {
                item.Selected = false;
                item.Focused = false;
                item.BackColor = SystemColors.Window;
                item.ForeColor = SystemColors.WindowText;
            }

            if (!String.IsNullOrEmpty(_strNowSearching))
            {
                if (String.IsNullOrEmpty(textBoxSearch.Text))
                    return;

                bool bFound = false;
                string strSearch = textBoxSearch.Text;
                labelstrSearching.Text = _strNowSearching;
                try
                {
                    for (int nIndex = 0; nIndex < listView1.Items.Count; nIndex++)
                    {
                        var item = listView1.Items[nIndex];

                        if (item.Text.ToUpper().Contains(strSearch.ToUpper()))
                        {
                            item.Selected = true;
                            item.Focused = true;
                            item.BackColor = SystemColors.Highlight;
                            item.ForeColor = SystemColors.HighlightText;
                            listView1.Select();
                            listView1.EnsureVisible(nIndex);
                            bFound = true;
                        }
                        else
                        {
                            item.BackColor = SystemColors.Window;
                            item.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (bFound)
                        listView1.Focus();
                }
                catch (Exception ex)
                {
                    labelstrSearching.Text = "";
                    DeadlyLog4Net._log.Error("Search : " + ex.ToString());
                }
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            textBoxSearch.SelectAll();
            textBoxSearch.Focus();
        }

        /*private void GatherLeagueNames()
        {
            var leagueListFromUrl = Api.DownloadFromUrl(PoeLeagueApiList);
            var leagueData = JsonConvert.DeserializeObject<List<Leagues>>(leagueListFromUrl);
            Api.JsonAPI.SaveSettingFile($"{Application.StartupPath + "\\NinjaData\\"}Leagues.json", leagueData);
            var leagueList = (from league in leagueData where !league.Id.Contains("SSF") select league.Id).ToList();

            // Deadly // set wanted league
            CurrentLeague = CurrentLeague == null ? leagueList[0] : Settings.LeagueList.Value;
            // display default league in setting
            if (Settings.LeagueList.Value == null)
                Settings.LeagueList.Value = CurrentLeague;

            Settings.LeagueList.SetListValues(leagueList);

            CurrentLeague = leagueList[2]; // LEGION : DeadlyCrush HARD CODING ( TO DO : User Choice )
        }*/
    }
}
