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
    public partial class GuideGridForm : Form
    {
        public GuideGridForm()
        {
            InitializeComponent();
        }

        private void GuideGridForm_Load(object sender, EventArgs e)
        {
            SetFormStyle();
            Init_Controls();

        }

        private void SetFormStyle()
        {
            this.ControlBox = false;
            this.Text = String.Empty;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.Left = 0;
            this.Top = 0;
            this.Width = 173;
            this.Height = 135;
        }

        private void Init_Controls()
        {
            DeadlyToolTip.SetToolTip(this.checkQuadTab, "4x4 보관함이면 체크 (Check if it is Quad Stash)");
            DeadlyToolTip.SetToolTip(this.textBoxLEFT, "왼쪽 좌표 입력 (Input Left Position)");
            DeadlyToolTip.SetToolTip(this.textBoxTOP, "상단 좌표 입력 (Input Top Position)");
            DeadlyToolTip.SetToolTip(this.textBoxTOP, "좌표에 해당하는 위치 표시 (Show Grid it's position)");
            DeadlyToolTip.SetToolTip(this.textBoxItemName, "아이템 이름 : 복사 후 CTRL+F 로 아이템 찾기시 사용 (Item Name : You can copy this text to find item. CTRL+F)"); 
            DeadlyToolTip.SetToolTip(this.btnClose, "닫기 (Close)");
        }

        private void PanelShowGuide_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelShowGuide.ClientRectangle, Color.Aqua, ButtonBorderStyle.Solid);
        }

        private void PanelShowGuide_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
