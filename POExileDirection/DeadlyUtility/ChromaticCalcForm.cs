using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class ChromaticCalcForm : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        public int m_nRight;
        public int m_nTop;

        public ChromaticCalcForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";

            listResult.View = View.Details;
            listResult.GridLines = true;
            listResult.FullRowSelect = true;
            // listResult.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            textTotalSockets.Text = "0";
            textSTR.Text = "0";
            textDEX.Text = "0";
            textINT.Text = "0";
            textRED.Text = "0";
            textGREEN.Text = "0";
            textBLUE.Text = "0";
            labelMSG.Text = "";

            this.Left = m_nRight - this.Width;
            this.Top = m_nTop - this.Height;

            ActiveControl = textTotalSockets;
            textTotalSockets.Select();
            textTotalSockets.Focus();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            labelMSG.Text = "";
            if (textTotalSockets.Text.Length < 1)
            {
                labelMSG.Text = "Please fill in Total Sockets.";
                return;
            }

            else if (textSTR.Text.Length < 1 && textDEX.Text.Length < 1 && textINT.Text.Length < 1)
            {
                labelMSG.Text = "Please fill in Requirements.";
                return;
            }
            else if (textRED.Text.Length < 1 && textGREEN.Text.Length < 1 && textBLUE.Text.Length < 1)
            {
                labelMSG.Text = "Please fill in Total Sockets.";
                return;
            }

            else if (textSTR.Text == null || textSTR.Text == String.Empty || textSTR.Text == "")
                textSTR.Text = "0";
            else if (textDEX.Text == null || textDEX.Text == String.Empty || textDEX.Text == "")
                textDEX.Text = "0";
            else if (textINT.Text == null || textINT.Text == String.Empty || textINT.Text == "")
                textINT.Text = "0";

            else if (textRED.Text == null || textRED.Text == String.Empty || textRED.Text == "")
                textRED.Text = "0";
            else if (textGREEN.Text == null || textGREEN.Text == String.Empty || textGREEN.Text == "")
                textGREEN.Text = "0";
            else if (textBLUE.Text == null || textBLUE.Text == String.Empty || textBLUE.Text == "")
                textBLUE.Text = "0";

            int socks = Convert.ToInt32(textTotalSockets.Text);
            int str = Convert.ToInt32(textSTR.Text);
            int dex = Convert.ToInt32(textDEX.Text);
            int _int = Convert.ToInt32(textINT.Text);
            int red = Convert.ToInt32(textRED.Text);
            int green = Convert.ToInt32(textGREEN.Text);
            int blue = Convert.ToInt32(textBLUE.Text);

            if(socks != (red+green+blue))
            {
                labelMSG.Text = "Mismatch number of sockets. (Total Sockets :: Desired Colors)";
                return;
            }
            else if (socks <= 0 || socks > 6)
            {
                labelMSG.Text = "Invalid number of sockets.";
                return;
            }
            if (str < 0 || dex < 0 || _int < 0)
            {
                labelMSG.Text = "Invalid item stat requirements.";
                return;
            }
            if (str == 0 && dex == 0 && _int == 0)
            {
                labelMSG.Text = "Please fill in stat requirements.";
                return;
            }
            if (red < 0 || green < 0 || blue < 0 || red + blue + green == 0 || red > 6 || green > 6 || blue > 6 || red + blue + green > socks)
            {
                labelMSG.Text = "Invalid desired socket colors.";
                return;
            }            

            listResult.Items.Clear();

            VoriciCalulator.probs[] probsST;// = new VoriciCalulator.probs[20];
            // int totalSockets, int STR, int DEX, int _INT, int RED, int GREEN, int BLUE
            VoriciCalulator vCalc = new VoriciCalulator();
            probsST = vCalc.MainCalc(socks, str, dex, _int, red, green, blue);

            for (int nIndex = 2; nIndex < probsST.Length; nIndex++)
            {
                /*
                public string cratfType;
			    public string averageCost;
			    public string successChance;
			    public string averageAttempts;
			    public string costPerTry;
                */
                if (probsST[nIndex].cratfType != null)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = "";
                    lvItem.SubItems.Add(probsST[nIndex].cratfType);
                    lvItem.SubItems.Add(probsST[nIndex].averageCost);
                    lvItem.SubItems.Add(probsST[nIndex].successChance);
                    lvItem.SubItems.Add(probsST[nIndex].averageAttempts);
                    lvItem.SubItems.Add(probsST[nIndex].costPerTry);

                    listResult.Items.Add(lvItem);
                }
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ControlForm.bVoriciCalcFormViewing = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            Close();
        }

        private void textTotalSockets_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only Numeric
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
