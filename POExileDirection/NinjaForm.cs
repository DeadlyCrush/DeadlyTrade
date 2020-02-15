using Newtonsoft.Json;
using Ninja_Price.API.PoeNinja;
using Ninja_Price.API.PoeNinja.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class NinjaForm : Form
    {
        #region ⨌⨌ Declaration for NINJA API ⨌⨌
        // POE.NINJA
        public string CurrentLeague { get; set; }
        public string PoeLeagueApiList = "http://api.pathofexile.com/leagues?type=main&compact=1";

        // 16 Types
        private const string CurrencyURL = "https://poe.ninja/api/data/currencyoverview?type=Currency&league=";
        private const string Fragments_URL = "https://poe.ninja/api/data/currencyoverview?type=Fragment&league=";
        private const string Incubators_URL = "https://poe.ninja/api/data/itemoverview?type=Incubator&league=";
        private const string Scarabs_URL = "https://poe.ninja/api/data/itemoverview?type=Scarab&league=";
        private const string Fossils_URL = "https://poe.ninja/api/data/itemoverview?type=Fossil&league=";
        private const string Resonators_URL = "https://poe.ninja/api/data/itemoverview?type=Resonator&league=";

        private const string Essences_URL = "https://poe.ninja/api/data/itemoverview?type=Essence&league=";
        private const string DivinationCards_URL = "https://poe.ninja/api/data/itemoverview?type=DivinationCard&league=";
        private const string Prophecies_URL = "https://poe.ninja/api/data/itemoverview?type=Prophecy&league=";

        private const string UniqueMaps_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueMap&league=";
        private const string WhiteMaps_URL = "https://poe.ninja/api/data/itemoverview?type=Map&league=";

        private const string UniqueJewels_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueJewel&league=";
        private const string UniqueFlasks_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueFlask&league=";

        private const string UniqueWeapons_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueWeapon&league=";
        private const string UniqueArmours_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueArmour&league=";
        private const string UniqueAccessories_URL = "https://poe.ninja/api/data/itemoverview?type=UniqueAccessory&league=";

        // Ninja Object 16 Types
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
        }
        #endregion

        NinJaAPIData ninjaData = new NinJaAPIData();

        public string NinjaDirectory;
        public bool UpdatingFromJson { get; set; } = false;
        public bool UpdatingFromAPI { get; set; } = false;

        Dictionary<string, double> CurrencyNameAndAverage = new Dictionary<string, double>();

        Dictionary<string, double> CurrencyCalcDictionary = new Dictionary<string, double>();
        bool bCanUseSelectedChange = false;

        public double oneExaltedChaos = 0.0;

        int nMoving = 0;
        int nMovePosX = 0;
        int nMovePosY = 0;

        ConvertKOR.RootObject enKOR = new ConvertKOR.RootObject();

        public NinjaForm()
        {
            InitializeComponent();
        }

        private void NinjaForm_Load(object sender, EventArgs e)
        {
            Init_Controls();

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);
            string sLeft = parser.GetSetting("LOCATIONCURR", "LEFT");
            string sTop = parser.GetSetting("LOCATIONCURR", "TOP");

            if(sLeft!=null && sTop!=null)
            {
                this.Left = Int32.Parse(sLeft);
                this.Top = Int32.Parse(sTop);
            }

            // TO DO : Need to Splash
            NinjaDirectory = Application.StartupPath + "\\NinjaData\\";
            CurrentLeague = "Legion";
            // Not for Deployment. Init_Ninja_API();

            GetJsonData(CurrentLeague);

            // for Convert to KOREAN
            if (JsonExists("jsonformEnKR.json"))
            using (var r = new StreamReader(NinjaDirectory + "jsonformEnKR.json"))
            {
                var json = r.ReadToEnd();
                enKOR = JsonConvert.DeserializeObject<ConvertKOR.RootObject>(json);
            }

            labelKOREAN.Text = "한글명을 찾을 수 없습니다.";

            UpdatePoeNinjaData();
            foreach (var objLine in ninjaData.Currency.Lines)
            {
                CurrencyCalcDictionary.Add(objLine.CurrencyTypeName, objLine.ChaosEquivalent);
                if (objLine.CurrencyTypeName == "Exalted Orb")
                    oneExaltedChaos = objLine.ChaosEquivalent;

                cbCurrency.Items.Add(objLine.CurrencyTypeName);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            if (oneExaltedChaos != 0) labelChaos.Text = oneExaltedChaos.ToString("N2");
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        public void Init_Controls()
        {
            // Currency Listview
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.None;

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

        private void GetJsonData(string league)
        {
            Task tWait =
            Task.Run(() =>
            {
                while (UpdatingFromAPI || UpdatingFromJson)
                {
                    Thread.Sleep(250);
                }

                UpdatingFromAPI = true;
                Api.Json.SaveSettingFile(NinjaDirectory + "Currency.json", JsonConvert.DeserializeObject<Currency.RootObject>(Api.DownloadFromUrl(CurrencyURL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "DivinationCards.json", JsonConvert.DeserializeObject<DivinationCards.RootObject>(Api.DownloadFromUrl(DivinationCards_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Essences.json", JsonConvert.DeserializeObject<Essences.RootObject>(Api.DownloadFromUrl(Essences_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Fragments.json", JsonConvert.DeserializeObject<Fragments.RootObject>(Api.DownloadFromUrl(Fragments_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Prophecies.json", JsonConvert.DeserializeObject<Prophecies.RootObject>(Api.DownloadFromUrl(Prophecies_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueAccessories.json", JsonConvert.DeserializeObject<UniqueAccessories.RootObject>(Api.DownloadFromUrl(UniqueAccessories_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueArmours.json", JsonConvert.DeserializeObject<UniqueArmours.RootObject>(Api.DownloadFromUrl(UniqueArmours_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueFlasks.json", JsonConvert.DeserializeObject<UniqueFlasks.RootObject>(Api.DownloadFromUrl(UniqueFlasks_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueJewels.json", JsonConvert.DeserializeObject<UniqueJewels.RootObject>(Api.DownloadFromUrl(UniqueJewels_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueMaps.json", JsonConvert.DeserializeObject<UniqueMaps.RootObject>(Api.DownloadFromUrl(UniqueMaps_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueWeapons.json", JsonConvert.DeserializeObject<UniqueWeapons.RootObject>(Api.DownloadFromUrl(UniqueWeapons_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "WhiteMaps.json", JsonConvert.DeserializeObject<WhiteMaps.RootObject>(Api.DownloadFromUrl(WhiteMaps_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Resonators.json", JsonConvert.DeserializeObject<Resonators.RootObject>(Api.DownloadFromUrl(Resonators_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Fossils.json", JsonConvert.DeserializeObject<Fossils.RootObject>(Api.DownloadFromUrl(Fossils_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Incubators.json", JsonConvert.DeserializeObject<Incubators.RootObject>(Api.DownloadFromUrl(Incubators_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Scarabs.json", JsonConvert.DeserializeObject<Scarab.RootObject>(Api.DownloadFromUrl(Scarabs_URL + league)));
                
                UpdatingFromAPI = false;
                // RM_DeadlyCrush UpdatePoeNinjaData();
            });

            tWait.Wait();
        }

        private void UpdatePoeNinjaData()
        {
            Task tWait =
            Task.Run(() =>
            {
                while (UpdatingFromAPI || UpdatingFromJson)
                {
                    Thread.Sleep(250);
                }

                UpdatingFromJson = true;

                var tmpData = new NinJaAPIData();

                #region ⨌⨌ Get 16 Types data from NINJA API ⨌⨌
                if (JsonExists("Currency.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Currency.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Currency = JsonConvert.DeserializeObject<Currency.RootObject>(json);
                    }

                if (JsonExists("DivinationCards.json"))
                    using (var r = new StreamReader(NinjaDirectory + "DivinationCards.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.DivinationCards = JsonConvert.DeserializeObject<DivinationCards.RootObject>(json);
                    }

                if (JsonExists("Essences.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Essences.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Essences = JsonConvert.DeserializeObject<Essences.RootObject>(json);
                    }

                if (JsonExists("Fragments.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Fragments.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Fragments = JsonConvert.DeserializeObject<Fragments.RootObject>(json);
                    }

                if (JsonExists("Prophecies.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Prophecies.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Prophecies = JsonConvert.DeserializeObject<Prophecies.RootObject>(json);
                    }

                if (JsonExists("UniqueAccessories.json"))
                    using (var r = new StreamReader(NinjaDirectory + "UniqueAccessories.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.UniqueAccessories = JsonConvert.DeserializeObject<UniqueAccessories.RootObject>(json);
                    }

                if (JsonExists("UniqueArmours.json"))
                    using (var r = new StreamReader(NinjaDirectory + "UniqueArmours.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.UniqueArmours = JsonConvert.DeserializeObject<UniqueArmours.RootObject>(json);
                    }

                if (JsonExists("UniqueFlasks.json"))
                    using (var r = new StreamReader(NinjaDirectory + "UniqueFlasks.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.UniqueFlasks = JsonConvert.DeserializeObject<UniqueFlasks.RootObject>(json);
                    }

                if (JsonExists("UniqueJewels.json"))
                    using (var r = new StreamReader(NinjaDirectory + "UniqueJewels.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.UniqueJewels = JsonConvert.DeserializeObject<UniqueJewels.RootObject>(json);
                    }

                if (JsonExists("UniqueMaps.json"))
                    using (var r = new StreamReader(NinjaDirectory + "UniqueMaps.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.UniqueMaps = JsonConvert.DeserializeObject<UniqueMaps.RootObject>(json);
                    }

                if (JsonExists("UniqueWeapons.json"))
                    using (var r = new StreamReader(NinjaDirectory + "UniqueWeapons.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.UniqueWeapons = JsonConvert.DeserializeObject<UniqueWeapons.RootObject>(json);
                    }

                if (JsonExists("WhiteMaps.json"))
                    using (var r = new StreamReader(NinjaDirectory + "WhiteMaps.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.WhiteMaps = JsonConvert.DeserializeObject<WhiteMaps.RootObject>(json);
                    }

                if (JsonExists("Resonators.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Resonators.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Resonators = JsonConvert.DeserializeObject<Resonators.RootObject>(json);
                    }

                if (JsonExists("Fossils.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Fossils.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Fossils = JsonConvert.DeserializeObject<Fossils.RootObject>(json);
                    }

                if (JsonExists("Incubators.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Incubators.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Incubators = JsonConvert.DeserializeObject<Incubators.RootObject>(json);
                    }

                if (JsonExists("Scarabs.json"))
                    using (var r = new StreamReader(NinjaDirectory + "Scarabs.json"))
                    {
                        var json = r.ReadToEnd();
                        tmpData.Scarabs = JsonConvert.DeserializeObject<Scarab.RootObject>(json);
                    }
                #endregion

                ninjaData = tmpData;
                UpdatingFromJson = false;
            });

            tWait.Wait();
        }

        public bool JsonExists(string fileName)
        {
            return File.Exists(NinjaDirectory + fileName);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ControlForm.bShowNinja = false;
            this.Hide();
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
            if(textBox1.Text == "0" || textBox1.Text == null)
            {
                MessageBox.Show("잘못된 계산입니다. 다시 입력해주세요.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double nCalcRet = 0;
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

            double nCalcRet = 0;
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
            if(textBoxFreeChoice.Text == "0" || textBoxFreeChoice.Text == null)
            {
                MessageBox.Show("잘못된 계산입니다. 다시 입력해주세요.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCurrency.SelectedIndex<0)
            {
                MessageBox.Show("계산을 원하는 커런시를 선택해주세요.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strSelectedCurrency = cbCurrency.Items[cbCurrency.SelectedIndex].ToString();
            
            double nCalcRet = 0;
            double dSelectedCurr = 0;
            CurrencyCalcDictionary.TryGetValue(strSelectedCurrency, out dSelectedCurr);
            if (dSelectedCurr<=0.0)
            {
                MessageBox.Show("선택한 커런시가 0.0 카오스라서 계산할 수 없습니다.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (oneExaltedChaos != 0)
            {
                nCalcRet = Convert.ToDouble(dSelectedCurr*Convert.ToDouble(textBoxFreeChoice.Text));
                textForceChaosResult.Text = nCalcRet.ToString("N2");
                textForceChaostoExalted.Text = (nCalcRet / oneExaltedChaos).ToString("N2");
            }

            bCanUseSelectedChange = true;
        }

        private void CbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bCanUseSelectedChange) return;

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
            IniParser parser = new IniParser(strINIPath);
            parser.AddSetting("LOCATIONCURR", "LEFT", this.Left.ToString());
            parser.AddSetting("LOCATIONCURR", "TOP", this.Top.ToString());
            parser.SaveSettings();
        }

        private void NinjaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ;
        }

        #region ⨌⨌ 16 Types data BUTTON CLICK FUNCTION ⨌⨌
        private void BtnCurrency_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "화폐";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            CurrencyCalcDictionary.Clear();
            foreach (var objLine in ninjaData.Currency.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.CurrencyTypeName)) continue;

                CurrencyNameAndAverage.Add(objLine.CurrencyTypeName, objLine.ChaosEquivalent);
                foreach (var objDetail in ninjaData.Currency.CurrencyDetails)
                {
                    if (objLine.CurrencyTypeName == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
                CurrencyCalcDictionary.Add(objLine.CurrencyTypeName, objLine.ChaosEquivalent);
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            foreach (var objLine in ninjaData.Currency.Lines)
            {
                if (objLine.CurrencyTypeName == "Exalted Orb")
                {
                    oneExaltedChaos = objLine.ChaosEquivalent;
                    break;
                }
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            if (oneExaltedChaos != 0) labelChaos.Text = oneExaltedChaos.ToString("N2");
        }

        private void BtnFragments_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "조각";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.Fragments.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.CurrencyTypeName)) continue;

                CurrencyNameAndAverage.Add(objLine.CurrencyTypeName, objLine.ChaosEquivalent);
                foreach (var objDetail in ninjaData.Fragments.CurrencyDetails)
                {
                    if (objLine.CurrencyTypeName == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnIncubators_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "인큐베이터";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.Incubators.lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.name)) continue;

                CurrencyNameAndAverage.Add(objLine.name, objLine.chaosValue);
                foreach (var objDetail in ninjaData.Incubators.lines)
                {
                    if (objLine.name == objDetail.name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnScarabs_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "스카랍";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.Scarabs.lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.name)) continue;

                CurrencyNameAndAverage.Add(objLine.name, objLine.chaosValue);
                foreach (var objDetail in ninjaData.Scarabs.lines)
                {
                    if (objLine.name == objDetail.name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnFossils_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "화석";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.Fossils.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.Fossils.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnResonators_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "리조네이터";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.Resonators.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.Resonators.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnEssences_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "에센스";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.Essences.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.Essences.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnDivinationCards_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "(디비네이션) 카드";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.DivinationCards.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.DivinationCards.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnProphecies_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "예언";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.Prophecies.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.Prophecies.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnUniqueAccessories_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "유니크 악세서리";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.UniqueAccessories.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.UniqueAccessories.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnUniqueMaps_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "유니크 지도";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.UniqueMaps.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.UniqueMaps.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnMaps_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "지도 (엘더,쉐이퍼,일반)";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.WhiteMaps.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.WhiteMaps.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnUniqueJewels_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "유니크 주얼";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.UniqueJewels.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.UniqueJewels.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnUniqueFlasks_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "유니크 플라스크";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.UniqueFlasks.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.UniqueFlasks.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnUniqueWeapons_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "유니크 무기";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.UniqueWeapons.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.UniqueWeapons.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void BtnUniqueArmours_Click(object sender, EventArgs e)
        {
            labelKOREAN.Text = "유니크 방어구";
            UpdatePoeNinjaData();

            listView1.Items.Clear();
            CurrencyNameAndAverage.Clear();
            ImageList imgList = new ImageList();

            foreach (var objLine in ninjaData.UniqueArmours.Lines)
            {
                if (CurrencyNameAndAverage.ContainsKey(objLine.Name)) continue;

                CurrencyNameAndAverage.Add(objLine.Name, objLine.ChaosValue);
                foreach (var objDetail in ninjaData.UniqueArmours.Lines)
                {
                    if (objLine.Name == objDetail.Name)
                    {
                        WebRequest TmpRequest = (HttpWebRequest)WebRequest.Create(objDetail.Icon);
                        WebResponse TmpResponse = TmpRequest.GetResponse();

                        Bitmap TmpBmp = new Bitmap(TmpResponse.GetResponseStream());

                        imgList.Images.Add(TmpBmp);
                    }
                }
            }

            listView1.SmallImageList = imgList;

            int nIndex = 0;
            foreach (var objShow in CurrencyNameAndAverage)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = objShow.Key;
                lvItem.SubItems.Add(objShow.Value.ToString("N2"));
                lvItem.ImageIndex = nIndex++;

                listView1.Items.Add(lvItem);
            }

            labelDateTimeCalc.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
        }
        #endregion

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIndex = listView1.FocusedItem.Index;
            string strEn = listView1.Items[nIndex].SubItems[0].Text;

            labelKOREAN.Text = "한글명을 찾을 수 없습니다.";
            foreach (var objKR in enKOR.EnkrData)
            {
                if(objKR.en==strEn)
                {
                    labelKOREAN.Text = objKR.kr;
                    break;
                }
            }
        }

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
            System.Diagnostics.Process.Start("https://poe.game.daum.net/trade/search/Legion");
        }

        /*private void GatherLeagueNames()
        {
            var leagueListFromUrl = Api.DownloadFromUrl(PoeLeagueApiList);
            var leagueData = JsonConvert.DeserializeObject<List<Leagues>>(leagueListFromUrl);
            Api.Json.SaveSettingFile($"{NinjaDirectory}Leagues.json", leagueData);
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
