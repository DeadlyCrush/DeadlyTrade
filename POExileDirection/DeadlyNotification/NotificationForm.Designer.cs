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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            this.labelElapsed = new System.Windows.Forms.Label();
            this.labelStashTabDetail = new System.Windows.Forms.Label();
            this.labelNickName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.checkQuadTab = new XanderUI.XUICheckBox();
            this.labelLeague = new System.Windows.Forms.Label();
            this.DeadlyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.xuiVolumeController1 = new XanderUI.XUIVolumeController();
            this.btnWhisper = new System.Windows.Forms.Button();
            this.btnWhois = new System.Windows.Forms.Button();
            this.btnWilling = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureCurrency = new System.Windows.Forms.PictureBox();
            this.btnThanks = new System.Windows.Forms.Button();
            this.btnWaitPls = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSold = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureArrow = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnMinMax = new System.Windows.Forms.Button();
            this.pictureHideoutVert = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnKick = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
            this.btnHideout = new System.Windows.Forms.Button();
            this.labelItemName = new System.Windows.Forms.Label();
            this.btnCurrency = new System.Windows.Forms.Button();
            this.labelPriceAtTitle = new System.Windows.Forms.Label();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCurrency)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHideoutVert)).BeginInit();
            this.SuspendLayout();
            // 
            // labelElapsed
            // 
            this.labelElapsed.AutoEllipsis = true;
            this.labelElapsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(87)))), ((int)(((byte)(55)))));
            this.labelElapsed.Location = new System.Drawing.Point(416, 5);
            this.labelElapsed.Name = "labelElapsed";
            this.labelElapsed.Size = new System.Drawing.Size(74, 12);
            this.labelElapsed.TabIndex = 0;
            this.labelElapsed.Text = "0h 00m 00s";
            this.labelElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStashTabDetail
            // 
            this.labelStashTabDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStashTabDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(124)))));
            this.labelStashTabDetail.Location = new System.Drawing.Point(135, 33);
            this.labelStashTabDetail.Name = "labelStashTabDetail";
            this.labelStashTabDetail.Size = new System.Drawing.Size(255, 12);
            this.labelStashTabDetail.TabIndex = 0;
            this.labelStashTabDetail.Text = "(00, 00) TabName ( Offer : 0000? )";
            this.labelStashTabDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelStashTabDetail.Click += new System.EventHandler(this.LabelItemName_Click);
            // 
            // labelNickName
            // 
            this.labelNickName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNickName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(124)))));
            this.labelNickName.Location = new System.Drawing.Point(25, 33);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(94, 12);
            this.labelNickName.TabIndex = 0;
            this.labelNickName.Text = "Nick Name\r\nNick Name";
            this.labelNickName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelNickName.DoubleClick += new System.EventHandler(this.BtnWhois_Click);
            // 
            // labelPrice
            // 
            this.labelPrice.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(124)))));
            this.labelPrice.Location = new System.Drawing.Point(390, 33);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(73, 12);
            this.labelPrice.TabIndex = 0;
            this.labelPrice.Text = "99999";
            this.labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPrice.Click += new System.EventHandler(this.LabelItemName_Click);
            // 
            // panelMiddle
            // 
            this.panelMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panelMiddle.Controls.Add(this.checkQuadTab);
            this.panelMiddle.Controls.Add(this.btnWhisper);
            this.panelMiddle.Controls.Add(this.btnWhois);
            this.panelMiddle.Controls.Add(this.btnWilling);
            this.panelMiddle.Controls.Add(this.labelLeague);
            this.panelMiddle.Controls.Add(this.pictureBox4);
            this.panelMiddle.Controls.Add(this.labelNickName);
            this.panelMiddle.Controls.Add(this.pictureBox3);
            this.panelMiddle.Controls.Add(this.labelStashTabDetail);
            this.panelMiddle.Controls.Add(this.labelElapsed);
            this.panelMiddle.Controls.Add(this.pictureCurrency);
            this.panelMiddle.Controls.Add(this.btnThanks);
            this.panelMiddle.Controls.Add(this.btnWaitPls);
            this.panelMiddle.Controls.Add(this.labelPrice);
            this.panelMiddle.Controls.Add(this.button1);
            this.panelMiddle.Controls.Add(this.button2);
            this.panelMiddle.Controls.Add(this.button3);
            this.panelMiddle.Controls.Add(this.button4);
            this.panelMiddle.Controls.Add(this.btnSold);
            this.panelMiddle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMiddle.Location = new System.Drawing.Point(1, 27);
            this.panelMiddle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(492, 93);
            this.panelMiddle.TabIndex = 7;
            // 
            // checkQuadTab
            // 
            this.checkQuadTab.CheckboxCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(87)))), ((int)(((byte)(55)))));
            this.checkQuadTab.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(124)))));
            this.checkQuadTab.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(102)))), ((int)(((byte)(23)))));
            this.checkQuadTab.CheckboxStyle = XanderUI.XUICheckBox.Style.Material;
            this.checkQuadTab.Checked = false;
            this.checkQuadTab.ForeColor = System.Drawing.Color.White;
            this.checkQuadTab.Location = new System.Drawing.Point(120, 33);
            this.checkQuadTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkQuadTab.Name = "checkQuadTab";
            this.checkQuadTab.Size = new System.Drawing.Size(12, 12);
            this.checkQuadTab.TabIndex = 12;
            this.checkQuadTab.TickThickness = 3;
            this.DeadlyToolTip.SetToolTip(this.checkQuadTab, "Check if Quad Stash Tab");
            this.checkQuadTab.Click += new System.EventHandler(this.checkQuadTab_Click);
            // 
            // labelLeague
            // 
            this.labelLeague.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(87)))), ((int)(((byte)(55)))));
            this.labelLeague.Location = new System.Drawing.Point(48, 5);
            this.labelLeague.Name = "labelLeague";
            this.labelLeague.Size = new System.Drawing.Size(320, 15);
            this.labelLeague.TabIndex = 0;
            this.labelLeague.Text = "LeagueName (1ex = 999c)";
            this.labelLeague.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLeague.Click += new System.EventHandler(this.LabelItemName_Click);
            // 
            // DeadlyToolTip
            // 
            this.DeadlyToolTip.AutoPopDelay = 5000;
            this.DeadlyToolTip.BackColor = System.Drawing.Color.Transparent;
            this.DeadlyToolTip.ForeColor = System.Drawing.Color.DarkRed;
            this.DeadlyToolTip.InitialDelay = 200;
            this.DeadlyToolTip.ReshowDelay = 100;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // btnWhisper
            // 
            this.btnWhisper.BackColor = System.Drawing.Color.Transparent;
            this.btnWhisper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWhisper.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnWhisper.FlatAppearance.BorderSize = 0;
            this.btnWhisper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhisper.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWhisper.ForeColor = System.Drawing.Color.White;
            this.btnWhisper.Image = global::POExileDirection.Properties.Resources.panel_whisper;
            this.btnWhisper.Location = new System.Drawing.Point(28, 6);
            this.btnWhisper.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.Size = new System.Drawing.Size(14, 14);
            this.btnWhisper.TabIndex = 1;
            this.btnWhisper.UseVisualStyleBackColor = false;
            this.btnWhisper.Click += new System.EventHandler(this.btnWhisper_Click);
            this.btnWhisper.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnWhois
            // 
            this.btnWhois.BackColor = System.Drawing.Color.Transparent;
            this.btnWhois.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWhois.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhois.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnWhois.FlatAppearance.BorderSize = 0;
            this.btnWhois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhois.Image = global::POExileDirection.Properties.Resources.panel_bg_man;
            this.btnWhois.Location = new System.Drawing.Point(7, 32);
            this.btnWhois.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWhois.Name = "btnWhois";
            this.btnWhois.Size = new System.Drawing.Size(14, 14);
            this.btnWhois.TabIndex = 1;
            this.btnWhois.UseVisualStyleBackColor = false;
            this.btnWhois.Click += new System.EventHandler(this.BtnWhois_Click);
            this.btnWhois.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnWilling
            // 
            this.btnWilling.BackColor = System.Drawing.Color.Transparent;
            this.btnWilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWilling.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnWilling.FlatAppearance.BorderSize = 0;
            this.btnWilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWilling.Image = global::POExileDirection.Properties.Resources.top_bar_resend1;
            this.btnWilling.Location = new System.Drawing.Point(8, 6);
            this.btnWilling.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWilling.Name = "btnWilling";
            this.btnWilling.Size = new System.Drawing.Size(14, 14);
            this.btnWilling.TabIndex = 1;
            this.btnWilling.UseVisualStyleBackColor = false;
            this.btnWilling.Click += new System.EventHandler(this.BtnWilling_Click);
            this.btnWilling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::POExileDirection.Properties.Resources.panel_time;
            this.pictureBox4.Location = new System.Drawing.Point(402, 7);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(12, 12);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::POExileDirection.Properties.Resources.panel_bottom_line;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(0, 52);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(493, 11);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureCurrency
            // 
            this.pictureCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pictureCurrency.BackgroundImage = global::POExileDirection.Properties.Resources.QuestionMark_20px;
            this.pictureCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureCurrency.Location = new System.Drawing.Point(466, 28);
            this.pictureCurrency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureCurrency.Name = "pictureCurrency";
            this.pictureCurrency.Size = new System.Drawing.Size(20, 20);
            this.pictureCurrency.TabIndex = 2;
            this.pictureCurrency.TabStop = false;
            this.pictureCurrency.Click += new System.EventHandler(this.LabelItemName_Click);
            // 
            // btnThanks
            // 
            this.btnThanks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnThanks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThanks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanks.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnThanks.FlatAppearance.BorderSize = 0;
            this.btnThanks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanks.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThanks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.btnThanks.Image = global::POExileDirection.Properties.Resources.Button_bg;
            this.btnThanks.Location = new System.Drawing.Point(424, 62);
            this.btnThanks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThanks.Name = "btnThanks";
            this.btnThanks.Size = new System.Drawing.Size(64, 28);
            this.btnThanks.TabIndex = 1;
            this.btnThanks.UseVisualStyleBackColor = false;
            this.btnThanks.Click += new System.EventHandler(this.BtnThanks_Click);
            this.btnThanks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnWaitPls
            // 
            this.btnWaitPls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnWaitPls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWaitPls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWaitPls.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnWaitPls.FlatAppearance.BorderSize = 0;
            this.btnWaitPls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitPls.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnWaitPls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.btnWaitPls.Image = ((System.Drawing.Image)(resources.GetObject("btnWaitPls.Image")));
            this.btnWaitPls.Location = new System.Drawing.Point(354, 62);
            this.btnWaitPls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWaitPls.Name = "btnWaitPls";
            this.btnWaitPls.Size = new System.Drawing.Size(64, 28);
            this.btnWaitPls.TabIndex = 1;
            this.btnWaitPls.UseVisualStyleBackColor = false;
            this.btnWaitPls.Click += new System.EventHandler(this.BtnWaitpls_Click);
            this.btnWaitPls.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(214, 62);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 28);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(144, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 28);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(74, 62);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 28);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(4, 62);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 28);
            this.button4.TabIndex = 1;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnSold
            // 
            this.btnSold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnSold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSold.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSold.FlatAppearance.BorderSize = 0;
            this.btnSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSold.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.btnSold.Image = ((System.Drawing.Image)(resources.GetObject("btnSold.Image")));
            this.btnSold.Location = new System.Drawing.Point(284, 62);
            this.btnSold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSold.Name = "btnSold";
            this.btnSold.Size = new System.Drawing.Size(64, 28);
            this.btnSold.TabIndex = 1;
            this.btnSold.UseVisualStyleBackColor = false;
            this.btnSold.Click += new System.EventHandler(this.BtnSold_Click);
            this.btnSold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DarkGray;
            this.panelTop.BackgroundImage = global::POExileDirection.Properties.Resources.to_bar_bg;
            this.panelTop.Controls.Add(this.pictureArrow);
            this.panelTop.Controls.Add(this.pictureBox8);
            this.panelTop.Controls.Add(this.btnMinMax);
            this.panelTop.Controls.Add(this.pictureHideoutVert);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnInvite);
            this.panelTop.Controls.Add(this.btnKick);
            this.panelTop.Controls.Add(this.btnTrade);
            this.panelTop.Controls.Add(this.btnHideout);
            this.panelTop.Controls.Add(this.labelItemName);
            this.panelTop.Controls.Add(this.btnCurrency);
            this.panelTop.Controls.Add(this.labelPriceAtTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(494, 28);
            this.panelTop.TabIndex = 0;
            // 
            // pictureArrow
            // 
            this.pictureArrow.BackColor = System.Drawing.Color.Transparent;
            this.pictureArrow.Image = global::POExileDirection.Properties.Resources.top_bar_arrow;
            this.pictureArrow.Location = new System.Drawing.Point(237, 11);
            this.pictureArrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureArrow.Name = "pictureArrow";
            this.pictureArrow.Size = new System.Drawing.Size(16, 9);
            this.pictureArrow.TabIndex = 13;
            this.pictureArrow.TabStop = false;
            this.pictureArrow.Click += new System.EventHandler(this.LabelItemName_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::POExileDirection.Properties.Resources.top_bar_line;
            this.pictureBox8.Location = new System.Drawing.Point(467, 8);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(1, 14);
            this.pictureBox8.TabIndex = 12;
            this.pictureBox8.TabStop = false;
            // 
            // btnMinMax
            // 
            this.btnMinMax.BackColor = System.Drawing.Color.Transparent;
            this.btnMinMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinMax.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnMinMax.FlatAppearance.BorderSize = 0;
            this.btnMinMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinMax.Image = global::POExileDirection.Properties.Resources.top_bar_size_control;
            this.btnMinMax.Location = new System.Drawing.Point(16, 8);
            this.btnMinMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMinMax.Name = "btnMinMax";
            this.btnMinMax.Size = new System.Drawing.Size(10, 12);
            this.btnMinMax.TabIndex = 9;
            this.btnMinMax.UseVisualStyleBackColor = false;
            this.btnMinMax.Click += new System.EventHandler(this.btnMinMax_Click);
            // 
            // pictureHideoutVert
            // 
            this.pictureHideoutVert.Image = global::POExileDirection.Properties.Resources.top_bar_line;
            this.pictureHideoutVert.Location = new System.Drawing.Point(390, 8);
            this.pictureHideoutVert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureHideoutVert.Name = "pictureHideoutVert";
            this.pictureHideoutVert.Size = new System.Drawing.Size(1, 14);
            this.pictureHideoutVert.TabIndex = 10;
            this.pictureHideoutVert.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(473, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(13, 16);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnInvite
            // 
            this.btnInvite.BackColor = System.Drawing.Color.Transparent;
            this.btnInvite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInvite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInvite.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInvite.FlatAppearance.BorderSize = 0;
            this.btnInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvite.Image = global::POExileDirection.Properties.Resources.top_bar_partyadd;
            this.btnInvite.Location = new System.Drawing.Point(399, 6);
            this.btnInvite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(17, 16);
            this.btnInvite.TabIndex = 1;
            this.btnInvite.UseVisualStyleBackColor = false;
            this.btnInvite.Click += new System.EventHandler(this.BtnInvite_Click);
            this.btnInvite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnKick
            // 
            this.btnKick.BackColor = System.Drawing.Color.Transparent;
            this.btnKick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKick.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnKick.FlatAppearance.BorderSize = 0;
            this.btnKick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKick.Image = global::POExileDirection.Properties.Resources.top_bar_partyexit;
            this.btnKick.Location = new System.Drawing.Point(443, 9);
            this.btnKick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(16, 12);
            this.btnKick.TabIndex = 1;
            this.btnKick.UseVisualStyleBackColor = false;
            this.btnKick.Click += new System.EventHandler(this.BtnKick_Click);
            this.btnKick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnTrade
            // 
            this.btnTrade.BackColor = System.Drawing.Color.Transparent;
            this.btnTrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrade.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnTrade.FlatAppearance.BorderSize = 0;
            this.btnTrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrade.Image = global::POExileDirection.Properties.Resources.top_bar_Transaction;
            this.btnTrade.Location = new System.Drawing.Point(422, 7);
            this.btnTrade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(15, 16);
            this.btnTrade.TabIndex = 1;
            this.btnTrade.UseVisualStyleBackColor = false;
            this.btnTrade.Click += new System.EventHandler(this.BtnTrade_Click);
            this.btnTrade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // btnHideout
            // 
            this.btnHideout.BackColor = System.Drawing.Color.Transparent;
            this.btnHideout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHideout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHideout.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnHideout.FlatAppearance.BorderSize = 0;
            this.btnHideout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideout.Image = global::POExileDirection.Properties.Resources.top_bar_home;
            this.btnHideout.Location = new System.Drawing.Point(370, 6);
            this.btnHideout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHideout.Name = "btnHideout";
            this.btnHideout.Size = new System.Drawing.Size(14, 16);
            this.btnHideout.TabIndex = 1;
            this.btnHideout.UseVisualStyleBackColor = false;
            this.btnHideout.Click += new System.EventHandler(this.BtnHideout_Click);
            this.btnHideout.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            // 
            // labelItemName
            // 
            this.labelItemName.BackColor = System.Drawing.Color.Transparent;
            this.labelItemName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(110)))), ((int)(((byte)(23)))));
            this.labelItemName.Location = new System.Drawing.Point(28, 5);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(200, 17);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "Very Expensive Item  (아이템)";
            this.labelItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelItemName.Click += new System.EventHandler(this.LabelItemName_Click);
            // 
            // btnCurrency
            // 
            this.btnCurrency.BackColor = System.Drawing.Color.Transparent;
            this.btnCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCurrency.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCurrency.FlatAppearance.BorderSize = 0;
            this.btnCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrency.Font = new System.Drawing.Font("Cambria", 9.75F);
            this.btnCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(110)))), ((int)(((byte)(23)))));
            this.btnCurrency.Location = new System.Drawing.Point(308, 3);
            this.btnCurrency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCurrency.Name = "btnCurrency";
            this.btnCurrency.Size = new System.Drawing.Size(20, 25);
            this.btnCurrency.TabIndex = 1;
            this.btnCurrency.Text = "?";
            this.btnCurrency.UseVisualStyleBackColor = false;
            this.btnCurrency.Click += new System.EventHandler(this.LabelItemName_Click);
            this.btnCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            this.btnCurrency.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnMinimizeToMsgHolder_KeyUp);
            // 
            // labelPriceAtTitle
            // 
            this.labelPriceAtTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelPriceAtTitle.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceAtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(110)))), ((int)(((byte)(23)))));
            this.labelPriceAtTitle.Location = new System.Drawing.Point(259, 6);
            this.labelPriceAtTitle.Name = "labelPriceAtTitle";
            this.labelPriceAtTitle.Size = new System.Drawing.Size(45, 17);
            this.labelPriceAtTitle.TabIndex = 0;
            this.labelPriceAtTitle.Text = "99999";
            this.labelPriceAtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPriceAtTitle.Click += new System.EventHandler(this.LabelItemName_Click);
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(494, 120);
            this.ControlBox = false;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NotificationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkMagenta;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotificationForm_FormClosed);
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NotificationForm_KeyUp);
            this.panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCurrency)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHideoutVert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.PictureBox pictureCurrency;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelStashTabDetail;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Label labelLeague;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.Button btnSold;
        private System.Windows.Forms.Button btnHideout;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.ToolTip DeadlyToolTip;
        private System.Windows.Forms.Button btnThanks;
        private System.Windows.Forms.Button btnWaitPls;
        private System.Windows.Forms.Button btnWilling;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelElapsed;
        private XanderUI.XUIVolumeController xuiVolumeController1;
        private System.Windows.Forms.Button btnWhisper;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnMinMax;
        private System.Windows.Forms.PictureBox pictureHideoutVert;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnWhois;
        private System.Windows.Forms.PictureBox pictureArrow;
        private XanderUI.XUICheckBox checkQuadTab;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.Label labelPriceAtTitle;
    }
}