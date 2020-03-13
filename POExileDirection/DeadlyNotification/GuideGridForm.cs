using System;
using System.Windows.Forms;
using System.Reflection;

namespace POExileDirection
{
    public partial class GuideGridForm : Form
    {
        private int nMoving = 0;
        private int nMovePosX = 0;
        private int nMovePosY = 0;

        private bool bIsQuad = false;
        private bool bIndicatorShowing = false;

        ITEMIndicatorForm itemIndicator = null;

        public GuideGridForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void GuideGridForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

            SetFormStyle();
            Init_Controls();

            if (checkQuadTab.Checked)
                bIsQuad = true;
            else
                bIsQuad = false;

            Visible = true;
            BringToFront();

            textBoxLEFT.LostFocus += TextBoxLEFT_LostFocus;
            textBoxTOP.LostFocus += TextBoxTOP_LostFocus;

            ActiveControl = textBoxLEFT;
            textBoxLEFT.Select();
            textBoxLEFT.Focus();

            Width = 219;
            Height = 27;

            ControlForm.gCF_bIsTextFocused = true;
        }

        private void TextBoxTOP_LostFocus(object sender, EventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = false;
        }

        private void TextBoxLEFT_LostFocus(object sender, EventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = false;
        }

        private void SetFormStyle()
        {
            this.ControlBox = false;
            this.Text = String.Empty;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            try
            {
                string sLeft = parser.GetSetting("MISC", "GUIDELEFT");
                string sTop = parser.GetSetting("MISC", "GUIDETOP");

                Left = Convert.ToInt32(sLeft);
                Top = Convert.ToInt32(sTop);
            }
            catch
            {
                MSGForm frmMSG = new MSGForm();
                frmMSG.lbMsg.Text = "Can't read Configuration file. Window posion force to (0,0)";
                frmMSG.ShowDialog();
                Left = 0;
                Top = 0;
            }

            BringToFront();
        }

        private void Init_Controls()
        {
            DeadlyToolTip.SetToolTip(this.checkQuadTab, "Check if it is Quad Stash");
            DeadlyToolTip.SetToolTip(this.textBoxLEFT, "Input Left Position");
            DeadlyToolTip.SetToolTip(this.textBoxTOP, "Input Top Position");
            DeadlyToolTip.SetToolTip(this.textBoxTOP, "Show Grid it's position");
            DeadlyToolTip.SetToolTip(this.btnClose, "Close");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ControlForm.g_bIsSearchPop = false;
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);
            Close();
        }

        #region [[[[[ Moving by Drag ]]]]]
        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = true;
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                ControlForm.gCF_bIsTextFocused = true;
                this.SetDesktopLocation((MousePosition.X - 18) - nMovePosX, (MousePosition.Y - 8) - nMovePosY);
            }
        }

        private void Label1_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            parser.AddSetting("MISC", "GUIDELEFT", Left.ToString());
            parser.AddSetting("MISC", "GUIDETOP", Top.ToString());
            parser.SaveSettings();
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void Label2_MouseDown(object sender, MouseEventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = true;
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void Label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                ControlForm.gCF_bIsTextFocused = true;
                this.SetDesktopLocation((MousePosition.X - 70) - nMovePosX, (MousePosition.Y - 8) - nMovePosY);
            }
        }

        private void Label2_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            parser.AddSetting("MISC", "GUIDELEFT", Left.ToString());
            parser.AddSetting("MISC", "GUIDETOP", Top.ToString());
            parser.SaveSettings();
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = true;
            nMoving = 1;
            nMovePosX = e.X;
            nMovePosY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nMoving == 1)
            {
                ControlForm.gCF_bIsTextFocused = true;
                this.SetDesktopLocation(MousePosition.X - nMovePosX, MousePosition.Y - nMovePosY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            nMoving = 0;

            string strINIPath = String.Format("{0}\\{1}", Application.StartupPath, "ConfigPath.ini");
            IniParser parser = new IniParser(strINIPath);

            parser.AddSetting("MISC", "GUIDELEFT", Left.ToString());
            parser.AddSetting("MISC", "GUIDETOP", Top.ToString());
            parser.SaveSettings();
            ControlForm.gCF_bIsTextFocused = true;
        } 
        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = true;
            if (String.IsNullOrEmpty(textBoxLEFT.Text) || String.IsNullOrEmpty(textBoxTOP.Text))
                return;

            if (checkQuadTab.Checked)
                bIsQuad = true;
            else
                bIsQuad = false;

            int nStashX = Convert.ToInt32(textBoxLEFT.Text);
            int nStashY = Convert.ToInt32(textBoxTOP.Text);
            if (nStashX <= 0 || nStashY <= 0)
                return;

            if (!bIsQuad)
            {
                if (nStashX > 12 || nStashY > 12)
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "Please input below 13 if not quad tap.";
                    frmMSG.ShowDialog();
                    return;
                }
            }
            else
            {
                if (nStashX > 24 || nStashY > 24)
                {
                    MSGForm frmMSG = new MSGForm();
                    frmMSG.lbMsg.Text = "Please input below 24.";
                    frmMSG.ShowDialog();
                    return;
                }
            }

            if (bIndicatorShowing)
            {
                if (itemIndicator != null)
                    itemIndicator.Hide();
                bIndicatorShowing = false;
            }

            itemIndicator = new ITEMIndicatorForm();
            itemIndicator.bIsQuad = bIsQuad;
            itemIndicator.nStashX = nStashX;
            itemIndicator.nStashY = nStashY;
            itemIndicator.bIsMagnify = true;
            itemIndicator.Owner = this;
            itemIndicator.Show();

            bIndicatorShowing = true;
        }

        private void CheckQuadTab_CheckedChanged(object sender, EventArgs e)
        {
            if (checkQuadTab.Checked)
                bIsQuad = true;
            else
                bIsQuad = false;

            if (textBoxLEFT.Text.Length < 1 || textBoxTOP.Text.Length < 1 || 
                textBoxLEFT.Text == String.Empty || textBoxTOP.Text == String.Empty)
                return;

            BtnSearch_Click(sender, e);
        }

        private void TextBoxLEFT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBoxTOP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBoxLEFT_Enter(object sender, EventArgs e)
        {
            textBoxLEFT.SelectAll();
            textBoxLEFT.Focus();
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void TextBoxLEFT_Leave(object sender, EventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = false;
        }

        private void TextBoxTOP_Enter(object sender, EventArgs e)
        {
            textBoxTOP.SelectAll();
            textBoxTOP.Focus();
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void TextBoxTOP_Leave(object sender, EventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = false;
        }

        private void GuideGridForm_Enter(object sender, EventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void checkQuadTab_MouseClick(object sender, MouseEventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            ControlForm.gCF_bIsTextFocused = true;
        }

        private void GuideGridForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (itemIndicator != null) itemIndicator.Dispose();
        }
    }
}
