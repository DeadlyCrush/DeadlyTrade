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
    public partial class SettingsForm : Form
    {
        public string keyRemains;
        public string keyJUN;
        public string keyALVA;
        public string keyZANA;

        public SettingsForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            textRemains.Text = keyRemains;
            textJUN.Text = keyJUN;
            textALVA.Text = keyALVA;
            textZANA.Text = keyZANA;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            //Set the backspace button to specify that the user does not want to use a shortcut.
            if (e.KeyData == Keys.Back)
            {
                /*if (strWhich == "REMAINS")
                    textRemains.Text = Keys.None.ToString();
                else if (strWhich == "JUN")
                    textJUN.Text = Keys.None.ToString();
                else if (strWhich == "ALVA")
                    textALVA.Text = Keys.None.ToString();
                else if (strWhich == "ZANA")
                    textZANA.Text = Keys.None.ToString();*/
                return;
            }

            if (
                (e.KeyCode == Keys.F2) ||
                (e.KeyCode == Keys.F3) ||
                (e.KeyCode == Keys.F4) ||
                (e.KeyCode == Keys.F5) ||
                (e.KeyCode == Keys.F6) ||
                (e.KeyCode == Keys.F7) ||
                (e.KeyCode == Keys.F8) ||
                (e.KeyCode == Keys.F9) ||
                (e.KeyCode == Keys.F10) ||
                (e.KeyCode == Keys.F11) ||
                (e.KeyCode == Keys.F12)
              )
            {
                ;// MessageBox.Show(e.KeyCode.ToString());
            }
            else
            {
                if (e.Modifiers == Keys.None)
                {
                    MessageBox.Show("펑션키가 아닌 경우 CTRL, ALT, SHIT 키를 조합하셔야 합니다.", "DeadlyCrush", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (strWhich == "REMAINS")
                        textRemains.Text = keyRemains;
                    else if (strWhich == "JUN")
                        textJUN.Text = keyJUN;
                    else if (strWhich == "ALVA")
                        textALVA.Text = keyALVA;
                    else if (strWhich == "ZANA")
                        textZANA.Text = keyZANA;

                    return;
                }
            }

            // A modifier is present. Process each modifier.
            // Modifiers are separated by a ",". So we'll split them and write each one to the textbox.
            foreach (string modifier in e.Modifiers.ToString().Split(new Char[] { ',' }))
            {
                if (!modifier.Equals("none", StringComparison.OrdinalIgnoreCase))
                {
                    if (strWhich == "REMAINS")
                        textRemains.Text += modifier + " + ";
                    else if (strWhich == "JUN")
                        textJUN.Text += modifier + " + ";
                    else if (strWhich == "ALVA")
                        textALVA.Text += modifier + " + ";
                    else if (strWhich == "ZANA")
                        textZANA.Text += modifier + " + ";
                }
                else
                {
                    if (strWhich == "REMAINS")
                        textRemains.Text = "특수키없음" + " + ";
                    else if (strWhich == "JUN")
                        textJUN.Text = "특수키없음" + " + ";
                    else if (strWhich == "ALVA")
                        textALVA.Text = "특수키없음" + " + ";
                    else if (strWhich == "ZANA")
                        textZANA.Text = "특수키없음" + " + ";
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
            }
            else
            {
                if (strWhich == "REMAINS")
                {
                    textRemains.Text += e.KeyCode.ToString();
                    keyRemains = textRemains.Text;
                }
                else if (strWhich == "JUN")
                {
                    textJUN.Text += e.KeyCode.ToString();
                    keyJUN = textJUN.Text;
                }
                else if (strWhich == "ALVA")
                {
                    textALVA.Text += e.KeyCode.ToString();
                    keyALVA = textALVA.Text;
                }
                else if (strWhich == "ZANA")
                {
                    textZANA.Text += e.KeyCode.ToString();
                    keyZANA = textZANA.Text;
                }
            }
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
    }
}
