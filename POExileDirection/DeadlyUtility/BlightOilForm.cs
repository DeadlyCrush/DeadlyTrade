using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class BlightOilForm : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        private int nLaskClickSocket = -1;

        private string _strSeletect = String.Empty;

        private List<string> arrSelected = new List<string>();

        public BlightOilForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        private void BlightOilForm_Load(object sender, EventArgs e)
        {
            arrSelected.Add("");
            arrSelected.Add("");
            arrSelected.Add("");

            this.ActiveControl = panelBG;

            _strSeletect = "A";
            pictureBox2.Visible = true;
            label2.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBoxPassive.Text.Length < 1 || textBoxPassive.Text.Length < 1 ||
                textBoxPassive.Text == String.Empty || textBoxPassive.Text == String.Empty)
                return;

            pictureBox1.BackgroundImage = null;
            pictureBox2.BackgroundImage = null;
            pictureBox3.BackgroundImage = null;
            arrSelected[0] = "";
            arrSelected[1] = "";
            arrSelected[2] = "";

            _strSeletect = "S"; // Search
            FindOilsPassives();
        }

        private void FindOilsPassives()
        {
            try
            {
                string strSearch = textBoxPassive.Text;
                List<DeadlyAtlas.OilsPassive> oilPassivesENG =
                    LauncherForm.deadlyInformationData.OilPassiveJsonData.OilsPassive.Where(retval => retval.PassiveName.ToUpper().Contains(strSearch.ToUpper())).ToList();

                List<DeadlyAtlas.OilsPassive> oilPassivesKOR =
                    LauncherForm.deadlyInformationData.OilPassiveJsonData.OilsPassive.Where(retval => retval.KORName.ToUpper().Contains(strSearch.ToUpper())).ToList();

                string strResult = String.Empty;
                string imagePath = String.Empty;
                if (oilPassivesENG.Count > 0)
                {
                    imagePath = String.Format("{0}\\DeadlyInform\\Oils\\{1}.png", Application.StartupPath, oilPassivesENG[0].OilA);
                    pictureBox1.BackgroundImage = resizeImage(Bitmap.FromFile(imagePath), new Size(30, 30));
                    label1.Text = oilPassivesENG[0].OilA;

                    imagePath = String.Format("{0}\\DeadlyInform\\Oils\\{1}.png", Application.StartupPath, oilPassivesENG[0].OilB);
                    pictureBox2.BackgroundImage = resizeImage(Bitmap.FromFile(imagePath), new Size(30, 30));
                    label2.Text = oilPassivesENG[0].OilB;

                    imagePath = String.Format("{0}\\DeadlyInform\\Oils\\{1}.png", Application.StartupPath, oilPassivesENG[0].OilC);
                    pictureBox3.BackgroundImage = resizeImage(Bitmap.FromFile(imagePath), new Size(30, 30));
                    label3.Text = oilPassivesENG[0].OilC;

                    strResult = String.Format("[ {0}({1}) ]\r\n\r\n{2}", oilPassivesENG[0].PassiveName, oilPassivesENG[0].KORName, oilPassivesENG[0].Effect);
                }
                else if (oilPassivesKOR.Count > 0)
                {
                    imagePath = String.Format("{0}\\DeadlyInform\\Oils\\{1}.png", Application.StartupPath, oilPassivesKOR[0].OilA);
                    pictureBox1.BackgroundImage = resizeImage(Bitmap.FromFile(imagePath), new Size(30, 30));
                    label1.Text = oilPassivesKOR[0].OilA;

                    imagePath = String.Format("{0}\\DeadlyInform\\Oils\\{1}.png", Application.StartupPath, oilPassivesKOR[0].OilB);
                    pictureBox2.BackgroundImage = resizeImage(Bitmap.FromFile(imagePath), new Size(30, 30));
                    label2.Text = oilPassivesKOR[0].OilB;

                    imagePath = String.Format("{0}\\DeadlyInform\\Oils\\{1}.png", Application.StartupPath, oilPassivesKOR[0].OilC);
                    pictureBox3.BackgroundImage = resizeImage(Bitmap.FromFile(imagePath), new Size(30, 30));
                    label3.Text = oilPassivesKOR[0].OilC;

                    strResult = String.Format("[ {0}({1}) ]\r\n\r\n{2}", oilPassivesKOR[0].PassiveName, oilPassivesKOR[0].KORName, oilPassivesKOR[0].Effect);
                }
                else
                {
                    strResult = "Not Found.";
                }

                labelResult.Text = strResult;
            }
            catch
            {
                labelResult.Text = "Unknown Error";
            }
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlForm.bOilsFormON = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            Close();
        }

        private void labelTop_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void labelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void labelTop_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        }

        private void textBoxPassive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void AnnointAmulet()
        {
            try
            {
                /*List<DeadlyAtlas.OilsPassive> oilPassivesENG =
                    LauncherForm.deadlyInformationData.OilPassiveJsonData.OilsPassive.Where(s => 
                            s.OilA.ToUpper()== arrSelected[0].ToUpper()
                            && s.OilB.ToUpper() == arrSelected[1].ToUpper()
                            && s.OilC.ToUpper() == arrSelected[2].ToUpper()
                            ).ToList();*/

                /*var objPassive = from passives in LauncherForm.deadlyInformationData.OilPassiveJsonData.OilsPassive
                              where passives.OilA.ToUpper() == arrSelected[0].ToUpper()
                                && passives.OilB.ToUpper() == arrSelected[1].ToUpper()
                                && passives.OilC.ToUpper() == arrSelected[2].ToUpper()
                              select passives;*/

                string strResult = "Not Found.";
                foreach (var item in LauncherForm.deadlyInformationData.OilPassiveJsonData.OilsPassive)
                {
                    if(item.OilA.ToUpper() == arrSelected[0].ToUpper() && item.OilB.ToUpper() == arrSelected[1].ToUpper()
                                && item.OilC.ToUpper() == arrSelected[2].ToUpper())
                    {
                        strResult = String.Format("[ {0}({1}) ]\r\n{2}", item.PassiveName, item.KORName, item.Effect);
                        break;
                    }
                    if (item.OilA.ToUpper() == arrSelected[1].ToUpper() && item.OilB.ToUpper() == arrSelected[0].ToUpper()
                                && item.OilC.ToUpper() == arrSelected[2].ToUpper())
                    {
                        strResult = String.Format("[ {0}({1}) ]\r\n{2}", item.PassiveName, item.KORName, item.Effect);
                        break;
                    }
                    if (item.OilA.ToUpper() == arrSelected[2].ToUpper() && item.OilB.ToUpper() == arrSelected[0].ToUpper()
                                && item.OilC.ToUpper() == arrSelected[1].ToUpper())
                    {
                        strResult = String.Format("[ {0}({1}) ]\r\n{2}", item.PassiveName, item.KORName, item.Effect);
                        break;
                    }

                    if (item.OilA.ToUpper() == arrSelected[0].ToUpper() && item.OilB.ToUpper() == arrSelected[2].ToUpper()
                                                    && item.OilC.ToUpper() == arrSelected[1].ToUpper())
                    {
                        strResult = String.Format("[ {0}({1}) ]\r\n{2}", item.PassiveName, item.KORName, item.Effect);
                        break;
                    }
                    if (item.OilA.ToUpper() == arrSelected[0].ToUpper() && item.OilB.ToUpper() == arrSelected[1].ToUpper()
                                && item.OilC.ToUpper() == arrSelected[2].ToUpper())
                    {
                        strResult = String.Format("[ {0}({1}) ]\r\n{2}", item.PassiveName, item.KORName, item.Effect);
                        break;
                    }
                }

                labelResult.Text = strResult;
            }
            catch(Exception ex)
            {
                labelResult.Text = "Unknown Error : Amulet Data";
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void AnnointRing()
        {
            try
            {
                string strResult = "Not Found.";
                foreach (var item in LauncherForm.deadlyInformationData.OilRingAnointData.OilsRingAnoint)
                {
                    if (item.Oils[0].ToUpper() == arrSelected[0].ToUpper() && item.Oils[1].ToUpper() == arrSelected[2].ToUpper())
                    {
                        if(LauncherForm.g_strUILang=="KOR")
                            strResult = item.EffectKR;
                        else
                            strResult = item.Effect;
                        break;
                    }
                    if (item.Oils[1].ToUpper() == arrSelected[0].ToUpper() && item.Oils[0].ToUpper() == arrSelected[2].ToUpper())
                    {
                        if (LauncherForm.g_strUILang == "KOR")
                            strResult = item.EffectKR;
                        else
                            strResult = item.Effect;
                        break;
                    }
                }

                labelResult.Text = strResult;
            }
            catch (Exception ex)
            {
                labelResult.Text = "Unknown Error : Ring Data";
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void AnnointMap()
        {
            try
            {
                labelResult.Text = "Select Oils";
                int nFound = 0;
                string strResult = "";
                foreach (var item in LauncherForm.deadlyInformationData.OilMapAnointData.OilsMapAnoint)
                {
                    if (item.Oils.ToUpper() == arrSelected[0].ToUpper())
                    {
                        if (LauncherForm.g_strUILang == "KOR")
                            strResult = strResult + item.EffectKR +"\r\n";
                        else
                            strResult = strResult + item.Effect + "\r\n";
                        nFound = nFound + 1;
                    }

                    if (item.Oils.ToUpper() == arrSelected[1].ToUpper())
                    {
                        if (LauncherForm.g_strUILang == "KOR")
                            strResult = strResult + item.EffectKR + "\r\n";
                        else
                            strResult = strResult + item.Effect + "\r\n";
                        nFound = nFound + 1;
                    }

                    if (item.Oils.ToUpper() == arrSelected[2].ToUpper())
                    {
                        if (LauncherForm.g_strUILang == "KOR")
                            strResult = strResult + item.EffectKR + "\r\n";
                        else
                            strResult = strResult + item.Effect + "\r\n";
                        nFound = nFound + 1;
                    }

                    if (nFound == 3)
                        break;
                }

                if(nFound == 0)
                    strResult = "Not Found.";
                labelResult.Text = strResult;
            }
            catch (Exception ex)
            {
                labelResult.Text = "Unknown Error : Map Data";
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }
        
        private void btnAmulet_Click(object sender, EventArgs e)
        {
            btnAmulet.Image = Properties.Resources.Amulet_on;
            btnRing.Image = Properties.Resources.Ring_off;
            btnMap.Image = Properties.Resources.Map_off;

            pictureBox1.BackgroundImage = null;
            pictureBox2.BackgroundImage = null;
            pictureBox3.BackgroundImage = null;
            arrSelected[0] = "";
            arrSelected[1] = "";
            arrSelected[2] = "";
            labelResult.Text = "Select Oils";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            _strSeletect = "A";
            pictureBox2.Visible = true;
            label2.Visible = true;
        }

        private void btnRing_Click(object sender, EventArgs e)
        {
            btnAmulet.Image = Properties.Resources.Amulet_off;
            btnRing.Image = Properties.Resources.Ring_on;
            btnMap.Image = Properties.Resources.Map_off;

            pictureBox1.BackgroundImage = null;
            pictureBox2.BackgroundImage = null;
            pictureBox3.BackgroundImage = null;
            arrSelected[0] = "";
            arrSelected[1] = "";
            arrSelected[2] = "";
            labelResult.Text = "Select Oils";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            _strSeletect = "R";
            pictureBox2.Visible = false;
            label2.Visible = false;
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            btnAmulet.Image = Properties.Resources.Amulet_off;
            btnRing.Image = Properties.Resources.Ring_off;
            btnMap.Image = Properties.Resources.Map_on;

            pictureBox1.BackgroundImage = null;
            pictureBox2.BackgroundImage = null;
            pictureBox3.BackgroundImage = null;
            arrSelected[0] = "";
            arrSelected[1] = "";
            arrSelected[2] = "";
            labelResult.Text = "Select Oils";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            _strSeletect = "M";
            pictureBox2.Visible = true;
            label2.Visible = true;
        }

        /*       
        Amber Oil
        Sepia Oil
        Amber Oil
        Verdant Oil
        Teal Oil
        Azure Oil
        Violet Oil
        Crimson Oil
        Black Oil
        Opalescent Oil
        Silver Oil
        Golden Oil
        */
        private void GetAnointResult(string strSelected0, string strSelected1, string strSelected2)
        {
            if(strSelected0=="" && strSelected1=="" && strSelected2 =="")
            {
                labelResult.Text = "Select Oils";
                return;
            }
            else
            {
                btnFind_Click_1(this, new EventArgs());
            }

            /*if (_strSeletect == "M" && (strSelected0!="" || strSelected1!="" || strSelected2!=""))
                btnFind_Click_1(this, new EventArgs());
            else if (strSelected0 != "" && strSelected2 != "" && _strSeletect == "R")
                btnFind_Click_1(this, new EventArgs());
            else if (strSelected0 != "" && strSelected1 != "" && strSelected2 != "")
                btnFind_Click_1(this, new EventArgs());*/
        }

        private void SetOiltoAnoint(string strOilName)
        {
            if (_strSeletect == "S")
                btnAmulet_Click(this, new EventArgs());

            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            str1 = arrSelected[0];
            str2 = arrSelected[1];
            str3 = arrSelected[2];

            try
            {
                if (str1 == "")// && nLaskClickSocket != 0)
                {
                    arrSelected[0] = strOilName;
                    label1.Text = strOilName;
                    pictureBox1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);

                    nLaskClickSocket = 0;

                    GetAnointResult(arrSelected[0], arrSelected[1], arrSelected[2]);
                    return;
                }

                if (_strSeletect != "R")
                {
                    if (str2 == "")// && nLaskClickSocket != 1)
                    {
                        arrSelected[1] = strOilName;
                        label2.Text = strOilName;
                        pictureBox2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);

                        nLaskClickSocket = 1;
                        GetAnointResult(arrSelected[0], arrSelected[1], arrSelected[2]);
                        return;
                    }
                }

                if (str3 == "")// && nLaskClickSocket != 2)
                {
                    arrSelected[2] = strOilName;
                    label3.Text = strOilName;
                    pictureBox3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);

                    nLaskClickSocket = 2;
                    GetAnointResult(arrSelected[0], arrSelected[1], arrSelected[2]);
                    return;
                }

                if (nLaskClickSocket == 0)
                {
                    if (str2 != strOilName && (_strSeletect != "R") && nLaskClickSocket != 1)
                    {
                        arrSelected[1] = strOilName;
                        label2.Text = strOilName;
                        nLaskClickSocket = 1;
                        pictureBox2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                    else if (str3 != strOilName && nLaskClickSocket != 2)
                    {
                        arrSelected[2] = strOilName;
                        label3.Text = strOilName;
                        nLaskClickSocket = 2;
                        pictureBox3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                    else if ((str1 != strOilName && nLaskClickSocket != 0) || arrSelected[0] == "")
                    {
                        arrSelected[0] = strOilName;
                        label1.Text = strOilName;
                        nLaskClickSocket = 0;
                        pictureBox1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                }
                else if (nLaskClickSocket == 1)
                {
                    if (str3 != strOilName && nLaskClickSocket != 2)
                    {
                        arrSelected[2] = strOilName;
                        label3.Text = strOilName;
                        nLaskClickSocket = 2;
                        pictureBox3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                    else if ((str1 != strOilName && nLaskClickSocket != 0) || arrSelected[0] == "")
                    {
                        arrSelected[0] = strOilName;
                        label1.Text = strOilName;
                        nLaskClickSocket = 0;
                        pictureBox1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                    else if (str2 != strOilName && (_strSeletect != "R") && nLaskClickSocket != 1)
                    {
                        arrSelected[1] = strOilName;
                        label2.Text = strOilName;
                        nLaskClickSocket = 1;
                        pictureBox2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                }
                else if (nLaskClickSocket == 2)
                {
                    if ((str1 != strOilName && nLaskClickSocket != 0) || arrSelected[0] == "")
                    {
                        arrSelected[0] = strOilName;
                        label1.Text = strOilName;
                        nLaskClickSocket = 0;
                        pictureBox1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                    else if (str2 != strOilName && (_strSeletect != "R") && nLaskClickSocket != 1)
                    {
                        arrSelected[1] = strOilName;
                        label2.Text = strOilName;
                        nLaskClickSocket = 1;
                        pictureBox2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                    else if (str3 != strOilName && nLaskClickSocket != 2)
                    {
                        arrSelected[2] = strOilName;
                        label3.Text = strOilName;
                        nLaskClickSocket = 2;
                        pictureBox3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(strOilName);
                    }
                }

                GetAnointResult(arrSelected[0], arrSelected[1], arrSelected[2]);
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name} : " + strOilName, ex);
            }
        }

        private void pictureOil1_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Clear Oil");
        }

        private void pictureOil2_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Sepia Oil");
        }

        private void pictureOil3_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Amber Oil");
        }

        private void pictureOil4_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Verdant Oil");
        }

        private void pictureOil5_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Teal Oil");
        }

        private void pictureOil6_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Azure Oil");
        }

        private void pictureOil7_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Violet Oil");
        }

        private void pictureOil8_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Crimson Oil");
        }

        private void pictureOil9_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Black Oil");
        }

        private void pictureOil10_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Opalescent Oil");
        }

        private void pictureOil11_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Silver Oil");
        }

        private void pictureOil12_Click(object sender, EventArgs e)
        {
            SetOiltoAnoint("Golden Oil");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            arrSelected[0] = "";
            pictureBox1.BackgroundImage = null;
            label1.Text = "";
            GetAnointResult(arrSelected[0], arrSelected[1], arrSelected[2]);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            arrSelected[1] = "";
            pictureBox2.BackgroundImage = null;
            label2.Text = "";
            GetAnointResult(arrSelected[0], arrSelected[1], arrSelected[2]);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            arrSelected[2] = "";
            pictureBox3.BackgroundImage = null;
            label3.Text = "";
            GetAnointResult(arrSelected[0], arrSelected[1], arrSelected[2]);
        }

        private void BlightOilForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (arrSelected != null) arrSelected = null;
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            switch (_strSeletect)
            {
                case "A":
                    AnnointAmulet();
                    break;
                case "R":
                    AnnointRing();
                    break;
                case "M":
                    AnnointMap();
                    break;
                default:
                    break;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ControlForm.bOilsFormON = false;
            pictureBox1.Dispose();
            pictureBox2.Dispose();
            pictureBox3.Dispose();
            pictureBox4.Dispose();

            pictureOil1.Dispose();
            pictureOil2.Dispose();
            pictureOil3.Dispose();
            pictureOil4.Dispose();
            pictureOil5.Dispose();
            pictureOil6.Dispose();
            pictureOil7.Dispose();
            pictureOil8.Dispose();
            pictureOil9.Dispose();
            pictureOil10.Dispose();
            pictureOil11.Dispose();
            pictureOil12.Dispose();
            btnAmulet.Dispose();
            btnRing.Dispose();
            btnMap.Dispose();

            arrSelected = null;
            btnFind.Dispose();            
            Close();
        }

        private void panelBG_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void panelBG_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void panelBG_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        }

        private void textBoxPassive_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxPassive;
            textBoxPassive.Text = "";
            textBoxPassive.SelectAll();
            textBoxPassive.Focus();
        }
    }
}
