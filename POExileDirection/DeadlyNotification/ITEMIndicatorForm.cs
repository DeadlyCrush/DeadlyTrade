using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using WindowsInput;
using WindowsInput.Native;

namespace POExileDirection
{
    public partial class ITEMIndicatorForm : Form
    {
        // BBBBBB private int nDefaultOffsetX = 3;
        // BBBBBB private int nDefaultOffsetY = 4;

        public bool bIsQuad = false;
        public int nStashX = 0;
        public int nStashY = 0;

        public string _strItemName = String.Empty;
        public string _strPrice = String.Empty;
        public string _strBmpPath = String.Empty;

        public ITEMIndicatorForm()
        {
            InitializeComponent();
            Text = "DeadlyTradeForPOE";
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private int nIndicatorLeft;
        private int nIndicatorTop;

        private double dWidth;
        private double dHeight;
        private int nCellWidth;
        private int nCellHeight;
        private int nCellWidth4x4;
        private int nCellHeight4x4;

        private void ITEMIndicatorForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            this.StartPosition = FormStartPosition.Manual;

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

            nIndicatorLeft = LauncherForm.g_nGridLeft;
            nIndicatorTop = LauncherForm.g_nGridTop;

            dWidth = LauncherForm.g_nGridWidth + 4.5;
            dHeight = LauncherForm.g_nGridHeight + 4.5;
            nCellWidth = Convert.ToInt32(Math.Truncate(dWidth / 12));
            nCellHeight = Convert.ToInt32(Math.Truncate(dHeight / 12));
            nCellWidth4x4 = Convert.ToInt32(Math.Truncate(dWidth / 24));
            nCellHeight4x4 = Convert.ToInt32(Math.Truncate(dHeight / 24));

            Init_Controls();

            SetIndicatorPictureBox();
        }

        #region ⨌⨌ Init. Controls ⨌⨌
        private void Init_Controls()
        {
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnClose.TabStop = false;

            btnCurrency.FlatStyle = FlatStyle.Flat;
            btnCurrency.BackColor = System.Drawing.Color.Transparent;
            btnCurrency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnCurrency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnCurrency.TabStop = false;
        }
        #endregion

        private void SetIndicatorPictureBox()
        {
            try
            {
                int nLeft = 0;
                int nTop = 0;
                Rectangle rcBox = new Rectangle(0, 0, nCellWidth, nCellHeight);

                //Pen AquaPen = new Pen(Color.Aqua, 1);
                //Pen DarkRed = new Pen(Color.DarkRed, 2);
                // DarkRed.Alignment = PenAlignment.Center;

                // Rectangle[,] g_arrayRect4x4 = new Rectangle[24, 24];
                // Rectangle[,] g_arrayRect1x1 = new Rectangle[12, 12];

                if (bIsQuad)
                {
                    // 4x4 Aqua
                    for (int iRow = 0; iRow < 24; iRow++) // ROWS
                    {
                        nTop = iRow * (nCellWidth4x4);

                        for (int jCell = 0; jCell < 24; jCell++) // COLLUMS
                        {
                            nLeft = jCell * (nCellHeight4x4);

                            rcBox = new Rectangle(nLeft, nTop, nCellHeight4x4, nCellWidth4x4);

                            if (jCell == nStashX - 1 && iRow == nStashY - 1)
                            {
                                Left = rcBox.X + nIndicatorLeft;
                                Top = rcBox.Y + nIndicatorTop;
                                pictureBox1.Width = rcBox.Width;
                                pictureBox1.Height = rcBox.Height;

                                break;
                            }
                            //g_arrayRect4x4[iRow, jCell] = rcBox;

                            //e.Graphics.DrawRectangle(AquaPen, g_arrayRect4x4[iRow, jCell]);
                        }
                    }

                    checkQuadTab.Checked = true;
                }
                else
                {
                    nLeft = 0;
                    nTop = 0;
                    // 1x1 Red
                    //ControlForm.g_arrayRect1x1 = new Rectangle[12, 12];
                    for (int i = 0; i < 12; i++) // ROWS
                    {
                        nTop = i * nCellHeight;

                        for (int j = 0; j < 12; j++) // COLLUMS
                        {
                            nLeft = j * nCellWidth;

                            rcBox = new Rectangle(nLeft, nTop, nCellWidth, nCellHeight);

                            if (j == nStashX - 1 && i == nStashY - 1)
                            {
                                Left = rcBox.X + nIndicatorLeft;
                                Top = rcBox.Y + nIndicatorTop;
                                pictureBox1.Width = rcBox.Width;
                                pictureBox1.Height = rcBox.Height;

                                break;
                            }

                            //g_arrayRect1x1[i, j] = rcBox;

                            //e.Graphics.DrawRectangle(DarkRed, g_arrayRect1x1[i, j]);
                        }
                    }

                    checkQuadTab.Checked = false;
                }

                if (!String.IsNullOrEmpty(_strBmpPath))
                    btnCurrency.Text = "";

                labelItemName.Text = _strItemName;
                labelPriceAtTitle.Text = _strPrice;
                btnCurrency.BackgroundImage = Bitmap.FromFile(_strBmpPath);

                panelTop.Left = pictureBox1.Width + 1;
            }
            catch (Exception ex)
            {
                DeadlyLog4Net._log.Error($"catch {MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private void ITEMIndicatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Dispose();
        }

        private void labelItemName_Click(object sender, EventArgs e)
        {
            InputSimulator iSim = new InputSimulator();
            InteropCommon.SetForegroundWindow(LauncherForm.g_handlePathOfExile);

            iSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_F);
            iSim.Keyboard.TextEntry(_strItemName);
            iSim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void checkQuadTab_Click(object sender, EventArgs e)
        {
            if (!bIsQuad)
                bIsQuad = true;
            else
                bIsQuad = false;

            SetIndicatorPictureBox();
        }
    }
}
