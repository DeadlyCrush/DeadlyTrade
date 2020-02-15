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
    public partial class NotificationForm : Form
    {
        private const int g_nGrip = 16;

        int nMoving = 0;
        int nMovePosX = 0;
        int nMovePosY = 0;

        public NotificationForm()
        {
            InitializeComponent();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            SetFormStyle();
            Init_Controls();

            /*
            g_nNotificationCount = g_nNotificationCount + 1;
            tradeWhisper.id = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss_fff");
            tradeWhisper.expanded = false;
            g_TradeMsgList.Add(tradeWhisper);
            */
            if (ControlForm.g_nNotificationCount > 0)
            {
                labelItemName.Text = ControlForm.g_TradeMsgList[0].itemName;
            }
        }

        private void SetFormStyle()
        {
            this.ControlBox = false;
            this.Text = String.Empty;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            this.Left = 1920-480;
            this.Top = 0;
            this.Width = 480;
            this.Height = 240;
        }

        private void Init_Controls()
        {
            DeadlyToolTip.SetToolTip(this.btnInvite, "파티 초대하기 (Invite to Party)"); 
            DeadlyToolTip.SetToolTip(this.btnTrade, "거래 요청하기 (Trade Request)"); 
            DeadlyToolTip.SetToolTip(this.btnKick, "파티에서 추방하기 (Kick From Party)"); 
            DeadlyToolTip.SetToolTip(this.btnMinimizeToMsgHolder, "알림창 숨기기 (Hide Panel)"); 
            DeadlyToolTip.SetToolTip(this.btnPin, "알림창 고정 (Lock Panel)");
            DeadlyToolTip.SetToolTip(this.btnClose, "알림창 닫기 (Close Panel)");
            DeadlyToolTip.SetToolTip(this.btnThanks, "닫기 : 거래 완료 메시지 전송 (Send 'Thanks' Message and Close Panel)");
            DeadlyToolTip.SetToolTip(this.btnWaitPlz, "잠시 기다려달라는 메시지 전송 (Send 'Plz. Wait a sec.' Message)");
            DeadlyToolTip.SetToolTip(this.btnSold, "닫기 : 판매완료 메시지 전송 후 알림 닫기 (Send 'Sold already' and Close Panel)");
            DeadlyToolTip.SetToolTip(this.btnHideout, "은신처로 이동 (Visit Hideout)");
            DeadlyToolTip.SetToolTip(this.btnWhois, "구매자 정보 확인 (Whois? Buyer Information)");
            DeadlyToolTip.SetToolTip(this.btnWilling, "구매의사 재확인 (Send 'Still willing to buy?' Message");
            DeadlyToolTip.SetToolTip(this.checkQuadTab, "4x4 보관함이면 체크 (Check if it is Quad Stash)");
            DeadlyToolTip.SetToolTip(this.btnCallCalc, "윈도우즈 계산기 열기 (Open Windows Calculator"); 
            /*
            DeadlyToolTip.SetToolTip(this.btnExpand, "알림창 펼치기 : 세부 내용 보기 (Expand : Detail Information)");
            DeadlyToolTip.SetToolTip(this.btnCollapse, "알림창 접기 : 간단히 보기 (Collapse : Simple View)");
            */
        }

        private void NotificationForm_Paint(object sender, PaintEventArgs e)
        {
            // Draw Grip
            Rectangle rc = new Rectangle(this.Width - g_nGrip, this.Height - g_nGrip, g_nGrip, g_nGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Red, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point posNew = new Point(m.LParam.ToInt32());
                posNew = this.PointToScreen(posNew);

                if (posNew.X >= this.Width - g_nGrip && posNew.Y >= this.Height - g_nGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
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
        }
    }
}
