namespace POExileDirection
{
    partial class NotificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelMsgTime = new System.Windows.Forms.Label();
            this.labelStashTabDetail = new System.Windows.Forms.Label();
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelItemName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOfferExist = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.textBoxCalcResult = new System.Windows.Forms.TextBox();
            this.textBoxThisCurrency = new System.Windows.Forms.TextBox();
            this.cbThisCurrency = new System.Windows.Forms.ComboBox();
            this.cbWhichCurrency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLeague = new System.Windows.Forms.Label();
            this.DeadlyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkQuadTab = new System.Windows.Forms.CheckBox();
            this.btnCallCalc = new System.Windows.Forms.Button();
            this.btnWhois = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
            this.btnWilling = new System.Windows.Forms.Button();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnHideout = new System.Windows.Forms.Button();
            this.pictureCurrency = new System.Windows.Forms.PictureBox();
            this.btnThanks = new System.Windows.Forms.Button();
            this.btnMinimizeToMsgHolder = new System.Windows.Forms.Button();
            this.btnPin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnKick = new System.Windows.Forms.Button();
            this.btnSold = new System.Windows.Forms.Button();
            this.btnWaitPlz = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelTop.Controls.Add(this.checkQuadTab);
            this.panelTop.Controls.Add(this.btnWhois);
            this.panelTop.Controls.Add(this.btnTrade);
            this.panelTop.Controls.Add(this.btnWilling);
            this.panelTop.Controls.Add(this.btnInvite);
            this.panelTop.Controls.Add(this.btnHideout);
            this.panelTop.Controls.Add(this.pictureCurrency);
            this.panelTop.Controls.Add(this.btnThanks);
            this.panelTop.Controls.Add(this.btnMinimizeToMsgHolder);
            this.panelTop.Controls.Add(this.btnPin);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnKick);
            this.panelTop.Controls.Add(this.labelStashTabDetail);
            this.panelTop.Controls.Add(this.labelNickName);
            this.panelTop.Controls.Add(this.btnSold);
            this.panelTop.Controls.Add(this.labelItemName);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnWaitPlz);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(336, 75);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseUp);
            // 
            // labelMsgTime
            // 
            this.labelMsgTime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMsgTime.ForeColor = System.Drawing.Color.White;
            this.labelMsgTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMsgTime.Location = new System.Drawing.Point(167, 7);
            this.labelMsgTime.Name = "labelMsgTime";
            this.labelMsgTime.Size = new System.Drawing.Size(162, 23);
            this.labelMsgTime.TabIndex = 0;
            this.labelMsgTime.Text = "Message Recieved 00:00:00";
            this.labelMsgTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStashTabDetail
            // 
            this.labelStashTabDetail.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelStashTabDetail.ForeColor = System.Drawing.Color.PaleGreen;
            this.labelStashTabDetail.Location = new System.Drawing.Point(42, 52);
            this.labelStashTabDetail.Name = "labelStashTabDetail";
            this.labelStashTabDetail.Size = new System.Drawing.Size(218, 20);
            this.labelStashTabDetail.TabIndex = 0;
            this.labelStashTabDetail.Text = "(00, 00) TabName";
            this.labelStashTabDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNickName
            // 
            this.labelNickName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelNickName.ForeColor = System.Drawing.Color.LightBlue;
            this.labelNickName.Location = new System.Drawing.Point(107, 0);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(158, 20);
            this.labelNickName.TabIndex = 0;
            this.labelNickName.Text = "NickName";
            this.labelNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelItemName
            // 
            this.labelItemName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelItemName.ForeColor = System.Drawing.Color.PaleGreen;
            this.labelItemName.Location = new System.Drawing.Point(21, 26);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(244, 20);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "엄청 비싼 아이템 ( Very Exepensive Item )";
            this.labelItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(271, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "99999";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelOfferExist
            // 
            this.labelOfferExist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.labelOfferExist.ForeColor = System.Drawing.Color.White;
            this.labelOfferExist.Location = new System.Drawing.Point(8, 35);
            this.labelOfferExist.Name = "labelOfferExist";
            this.labelOfferExist.Size = new System.Drawing.Size(153, 45);
            this.labelOfferExist.TabIndex = 0;
            this.labelOfferExist.Text = "OfferExist\r\nIf Not. Original Price";
            this.labelOfferExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMiddle
            // 
            this.panelMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.panelMiddle.Controls.Add(this.labelOfferExist);
            this.panelMiddle.Controls.Add(this.labelLeague);
            this.panelMiddle.Controls.Add(this.btnCallCalc);
            this.panelMiddle.Controls.Add(this.textBoxCalcResult);
            this.panelMiddle.Controls.Add(this.textBoxThisCurrency);
            this.panelMiddle.Controls.Add(this.cbThisCurrency);
            this.panelMiddle.Controls.Add(this.cbWhichCurrency);
            this.panelMiddle.Controls.Add(this.label3);
            this.panelMiddle.Controls.Add(this.label2);
            this.panelMiddle.Controls.Add(this.labelMsgTime);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 75);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(336, 85);
            this.panelMiddle.TabIndex = 7;
            // 
            // textBoxCalcResult
            // 
            this.textBoxCalcResult.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxCalcResult.Location = new System.Drawing.Point(284, 59);
            this.textBoxCalcResult.MaxLength = 10;
            this.textBoxCalcResult.Name = "textBoxCalcResult";
            this.textBoxCalcResult.Size = new System.Drawing.Size(44, 21);
            this.textBoxCalcResult.TabIndex = 4;
            this.textBoxCalcResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxThisCurrency
            // 
            this.textBoxThisCurrency.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxThisCurrency.Location = new System.Drawing.Point(167, 32);
            this.textBoxThisCurrency.MaxLength = 10;
            this.textBoxThisCurrency.Name = "textBoxThisCurrency";
            this.textBoxThisCurrency.Size = new System.Drawing.Size(44, 21);
            this.textBoxThisCurrency.TabIndex = 4;
            this.textBoxThisCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbThisCurrency
            // 
            this.cbThisCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThisCurrency.FormattingEnabled = true;
            this.cbThisCurrency.Location = new System.Drawing.Point(235, 32);
            this.cbThisCurrency.Name = "cbThisCurrency";
            this.cbThisCurrency.Size = new System.Drawing.Size(93, 20);
            this.cbThisCurrency.TabIndex = 2;
            // 
            // cbWhichCurrency
            // 
            this.cbWhichCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhichCurrency.FormattingEnabled = true;
            this.cbWhichCurrency.Location = new System.Drawing.Point(167, 59);
            this.cbWhichCurrency.Name = "cbWhichCurrency";
            this.cbWhichCurrency.Size = new System.Drawing.Size(93, 20);
            this.cbWhichCurrency.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(259, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "=";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(209, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "to";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLeague
            // 
            this.labelLeague.ForeColor = System.Drawing.Color.White;
            this.labelLeague.Location = new System.Drawing.Point(8, 7);
            this.labelLeague.Name = "labelLeague";
            this.labelLeague.Size = new System.Drawing.Size(115, 23);
            this.labelLeague.TabIndex = 0;
            this.labelLeague.Text = "League";
            this.labelLeague.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // DeadlyToolTip
            // 
            this.DeadlyToolTip.BackColor = System.Drawing.Color.Transparent;
            this.DeadlyToolTip.ForeColor = System.Drawing.Color.DarkRed;
            // 
            // checkQuadTab
            // 
            this.checkQuadTab.AutoSize = true;
            this.checkQuadTab.Location = new System.Drawing.Point(26, 55);
            this.checkQuadTab.Name = "checkQuadTab";
            this.checkQuadTab.Size = new System.Drawing.Size(15, 14);
            this.checkQuadTab.TabIndex = 3;
            this.checkQuadTab.UseVisualStyleBackColor = true;
            // 
            // btnCallCalc
            // 
            this.btnCallCalc.BackColor = System.Drawing.Color.Transparent;
            this.btnCallCalc.BackgroundImage = global::POExileDirection.Properties.Resources.calculator;
            this.btnCallCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCallCalc.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCallCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallCalc.Location = new System.Drawing.Point(137, 8);
            this.btnCallCalc.Name = "btnCallCalc";
            this.btnCallCalc.Size = new System.Drawing.Size(24, 24);
            this.btnCallCalc.TabIndex = 1;
            this.btnCallCalc.UseVisualStyleBackColor = false;
            // 
            // btnWhois
            // 
            this.btnWhois.BackgroundImage = global::POExileDirection.Properties.Resources.Search_24px;
            this.btnWhois.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWhois.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnWhois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhois.Location = new System.Drawing.Point(63, 0);
            this.btnWhois.Name = "btnWhois";
            this.btnWhois.Size = new System.Drawing.Size(20, 20);
            this.btnWhois.TabIndex = 1;
            this.btnWhois.UseVisualStyleBackColor = true;
            // 
            // btnTrade
            // 
            this.btnTrade.BackColor = System.Drawing.Color.Transparent;
            this.btnTrade.BackgroundImage = global::POExileDirection.Properties.Resources.TradeCommand_24px;
            this.btnTrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrade.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnTrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrade.Location = new System.Drawing.Point(0, 26);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(20, 20);
            this.btnTrade.TabIndex = 1;
            this.btnTrade.UseVisualStyleBackColor = false;
            // 
            // btnWilling
            // 
            this.btnWilling.BackgroundImage = global::POExileDirection.Properties.Resources.Re_SendMessage_24px;
            this.btnWilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWilling.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnWilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWilling.Location = new System.Drawing.Point(42, 0);
            this.btnWilling.Name = "btnWilling";
            this.btnWilling.Size = new System.Drawing.Size(20, 20);
            this.btnWilling.TabIndex = 1;
            this.btnWilling.UseVisualStyleBackColor = true;
            // 
            // btnInvite
            // 
            this.btnInvite.BackColor = System.Drawing.Color.Transparent;
            this.btnInvite.BackgroundImage = global::POExileDirection.Properties.Resources.Invite_24px;
            this.btnInvite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInvite.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvite.Location = new System.Drawing.Point(0, 0);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(20, 20);
            this.btnInvite.TabIndex = 1;
            this.btnInvite.UseVisualStyleBackColor = false;
            // 
            // btnHideout
            // 
            this.btnHideout.BackgroundImage = global::POExileDirection.Properties.Resources.Hideout_24px;
            this.btnHideout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHideout.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnHideout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideout.Location = new System.Drawing.Point(84, 0);
            this.btnHideout.Name = "btnHideout";
            this.btnHideout.Size = new System.Drawing.Size(20, 20);
            this.btnHideout.TabIndex = 1;
            this.btnHideout.UseVisualStyleBackColor = true;
            // 
            // pictureCurrency
            // 
            this.pictureCurrency.BackColor = System.Drawing.Color.Transparent;
            this.pictureCurrency.BackgroundImage = global::POExileDirection.Properties.Resources.Chaos_Orb;
            this.pictureCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureCurrency.Location = new System.Drawing.Point(315, 52);
            this.pictureCurrency.Name = "pictureCurrency";
            this.pictureCurrency.Size = new System.Drawing.Size(20, 20);
            this.pictureCurrency.TabIndex = 2;
            this.pictureCurrency.TabStop = false;
            // 
            // btnThanks
            // 
            this.btnThanks.BackColor = System.Drawing.Color.Transparent;
            this.btnThanks.BackgroundImage = global::POExileDirection.Properties.Resources.TradeAccepted_24px;
            this.btnThanks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThanks.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnThanks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanks.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnThanks.ForeColor = System.Drawing.Color.Black;
            this.btnThanks.Location = new System.Drawing.Point(0, 52);
            this.btnThanks.Name = "btnThanks";
            this.btnThanks.Size = new System.Drawing.Size(20, 20);
            this.btnThanks.TabIndex = 1;
            this.btnThanks.UseVisualStyleBackColor = false;
            // 
            // btnMinimizeToMsgHolder
            // 
            this.btnMinimizeToMsgHolder.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeToMsgHolder.BackgroundImage = global::POExileDirection.Properties.Resources.Minimize_45_45_48_24px;
            this.btnMinimizeToMsgHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimizeToMsgHolder.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnMinimizeToMsgHolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeToMsgHolder.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeToMsgHolder.ForeColor = System.Drawing.Color.White;
            this.btnMinimizeToMsgHolder.Location = new System.Drawing.Point(271, 0);
            this.btnMinimizeToMsgHolder.Name = "btnMinimizeToMsgHolder";
            this.btnMinimizeToMsgHolder.Size = new System.Drawing.Size(20, 20);
            this.btnMinimizeToMsgHolder.TabIndex = 1;
            this.btnMinimizeToMsgHolder.Text = "_";
            this.btnMinimizeToMsgHolder.UseVisualStyleBackColor = false;
            // 
            // btnPin
            // 
            this.btnPin.BackColor = System.Drawing.Color.Transparent;
            this.btnPin.BackgroundImage = global::POExileDirection.Properties.Resources.PinLock_45_45_48_24px;
            this.btnPin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPin.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPin.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPin.ForeColor = System.Drawing.Color.White;
            this.btnPin.Location = new System.Drawing.Point(293, 0);
            this.btnPin.Name = "btnPin";
            this.btnPin.Size = new System.Drawing.Size(20, 20);
            this.btnPin.TabIndex = 1;
            this.btnPin.Text = "∞";
            this.btnPin.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::POExileDirection.Properties.Resources.CloseButton_45_45_48_24px;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(315, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnKick
            // 
            this.btnKick.BackColor = System.Drawing.Color.Transparent;
            this.btnKick.BackgroundImage = global::POExileDirection.Properties.Resources.KickFromParty_24px;
            this.btnKick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKick.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnKick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKick.Location = new System.Drawing.Point(21, 0);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(20, 20);
            this.btnKick.TabIndex = 1;
            this.btnKick.UseVisualStyleBackColor = false;
            // 
            // btnSold
            // 
            this.btnSold.BackgroundImage = global::POExileDirection.Properties.Resources.Soldout_24px;
            this.btnSold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSold.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSold.Location = new System.Drawing.Point(315, 26);
            this.btnSold.Name = "btnSold";
            this.btnSold.Size = new System.Drawing.Size(20, 20);
            this.btnSold.TabIndex = 1;
            this.btnSold.UseVisualStyleBackColor = true;
            // 
            // btnWaitPlz
            // 
            this.btnWaitPlz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnWaitPlz.BackgroundImage = global::POExileDirection.Properties.Resources.WaitPlz_45_45_48_24px;
            this.btnWaitPlz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWaitPlz.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnWaitPlz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitPlz.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWaitPlz.ForeColor = System.Drawing.Color.White;
            this.btnWaitPlz.Location = new System.Drawing.Point(293, 26);
            this.btnWaitPlz.Name = "btnWaitPlz";
            this.btnWaitPlz.Size = new System.Drawing.Size(20, 20);
            this.btnWaitPlz.TabIndex = 1;
            this.btnWaitPlz.UseVisualStyleBackColor = false;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(336, 160);
            this.ControlBox = false;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(960, 480);
            this.MinimumSize = new System.Drawing.Size(120, 35);
            this.Name = "NotificationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NotificationForm_Paint);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.panelMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCurrency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.PictureBox pictureCurrency;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelOfferExist;
        private System.Windows.Forms.Label labelStashTabDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Button btnWhois;
        private System.Windows.Forms.Label labelLeague;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.Button btnSold;
        private System.Windows.Forms.Button btnWaitPlz;
        private System.Windows.Forms.Button btnHideout;
        private System.Windows.Forms.Button btnMinimizeToMsgHolder;
        private System.Windows.Forms.Label labelMsgTime;
        private System.Windows.Forms.ComboBox cbThisCurrency;
        private System.Windows.Forms.ComboBox cbWhichCurrency;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.TextBox textBoxCalcResult;
        private System.Windows.Forms.TextBox textBoxThisCurrency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip DeadlyToolTip;
        private System.Windows.Forms.Button btnPin;
        private System.Windows.Forms.Button btnThanks;
        private System.Windows.Forms.Button btnWilling;
        private System.Windows.Forms.CheckBox checkQuadTab;
        private System.Windows.Forms.Button btnCallCalc;
    }
}