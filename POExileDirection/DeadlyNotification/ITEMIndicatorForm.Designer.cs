namespace POExileDirection
{
    partial class ITEMIndicatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ITEMIndicatorForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.checkQuadTab = new System.Windows.Forms.CheckBox();
            this.btnCurrency = new System.Windows.Forms.Button();
            this.labelPriceAtTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelItemName = new System.Windows.Forms.Label();
            this.panelFunctions = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureHideoutVert = new System.Windows.Forms.PictureBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnKick = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHideoutVert)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::POExileDirection.Properties.Resources.GRID_INDICATOR;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 53);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.checkQuadTab);
            this.panelTop.Controls.Add(this.btnCurrency);
            this.panelTop.Controls.Add(this.labelPriceAtTitle);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.labelItemName);
            this.panelTop.Location = new System.Drawing.Point(53, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(312, 24);
            this.panelTop.TabIndex = 1;
            // 
            // checkQuadTab
            // 
            this.checkQuadTab.AutoSize = true;
            this.checkQuadTab.BackColor = System.Drawing.Color.Transparent;
            this.checkQuadTab.FlatAppearance.BorderSize = 0;
            this.checkQuadTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkQuadTab.Location = new System.Drawing.Point(6, 6);
            this.checkQuadTab.Name = "checkQuadTab";
            this.checkQuadTab.Size = new System.Drawing.Size(12, 11);
            this.checkQuadTab.TabIndex = 16;
            this.checkQuadTab.UseVisualStyleBackColor = false;
            this.checkQuadTab.Click += new System.EventHandler(this.checkQuadTab_Click);
            // 
            // btnCurrency
            // 
            this.btnCurrency.BackColor = System.Drawing.Color.Transparent;
            this.btnCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCurrency.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCurrency.FlatAppearance.BorderSize = 0;
            this.btnCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrency.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCurrency.ForeColor = System.Drawing.Color.Silver;
            this.btnCurrency.Location = new System.Drawing.Point(284, 2);
            this.btnCurrency.Name = "btnCurrency";
            this.btnCurrency.Size = new System.Drawing.Size(20, 20);
            this.btnCurrency.TabIndex = 15;
            this.btnCurrency.Text = "?";
            this.btnCurrency.UseVisualStyleBackColor = false;
            this.btnCurrency.Click += new System.EventHandler(this.labelItemName_Click);
            // 
            // labelPriceAtTitle
            // 
            this.labelPriceAtTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelPriceAtTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPriceAtTitle.ForeColor = System.Drawing.Color.Silver;
            this.labelPriceAtTitle.Location = new System.Drawing.Point(235, 2);
            this.labelPriceAtTitle.Name = "labelPriceAtTitle";
            this.labelPriceAtTitle.Size = new System.Drawing.Size(45, 20);
            this.labelPriceAtTitle.TabIndex = 14;
            this.labelPriceAtTitle.Text = "99999";
            this.labelPriceAtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPriceAtTitle.Click += new System.EventHandler(this.labelItemName_Click);
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
            this.btnClose.Location = new System.Drawing.Point(473, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(13, 13);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // labelItemName
            // 
            this.labelItemName.AutoEllipsis = true;
            this.labelItemName.BackColor = System.Drawing.Color.Transparent;
            this.labelItemName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelItemName.ForeColor = System.Drawing.Color.Silver;
            this.labelItemName.Location = new System.Drawing.Point(22, 2);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(207, 20);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "Very Expensive Item  (아이템)";
            this.labelItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelItemName.Click += new System.EventHandler(this.labelItemName_Click);
            // 
            // panelFunctions
            // 
            this.panelFunctions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panelFunctions.Controls.Add(this.pictureBox2);
            this.panelFunctions.Controls.Add(this.pictureHideoutVert);
            this.panelFunctions.Controls.Add(this.btnBackup);
            this.panelFunctions.Controls.Add(this.button1);
            this.panelFunctions.Controls.Add(this.btnInvite);
            this.panelFunctions.Controls.Add(this.btnKick);
            this.panelFunctions.Controls.Add(this.btnTrade);
            this.panelFunctions.Location = new System.Drawing.Point(216, 24);
            this.panelFunctions.Name = "panelFunctions";
            this.panelFunctions.Size = new System.Drawing.Size(149, 22);
            this.panelFunctions.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(123, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1, 11);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureHideoutVert
            // 
            this.pictureHideoutVert.Image = ((System.Drawing.Image)(resources.GetObject("pictureHideoutVert.Image")));
            this.pictureHideoutVert.Location = new System.Drawing.Point(74, 6);
            this.pictureHideoutVert.Name = "pictureHideoutVert";
            this.pictureHideoutVert.Size = new System.Drawing.Size(1, 11);
            this.pictureHideoutVert.TabIndex = 19;
            this.pictureHideoutVert.TabStop = false;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.Enabled = false;
            this.btnBackup.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(83, 2);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(35, 20);
            this.btnBackup.TabIndex = 18;
            this.btnBackup.Text = "thx";
            this.btnBackup.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(132, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(13, 13);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnInvite
            // 
            this.btnInvite.BackColor = System.Drawing.Color.Transparent;
            this.btnInvite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInvite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInvite.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInvite.FlatAppearance.BorderSize = 0;
            this.btnInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvite.Image = ((System.Drawing.Image)(resources.GetObject("btnInvite.Image")));
            this.btnInvite.Location = new System.Drawing.Point(6, 4);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(17, 13);
            this.btnInvite.TabIndex = 2;
            this.btnInvite.UseVisualStyleBackColor = false;
            // 
            // btnKick
            // 
            this.btnKick.BackColor = System.Drawing.Color.Transparent;
            this.btnKick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKick.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnKick.FlatAppearance.BorderSize = 0;
            this.btnKick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKick.Image = ((System.Drawing.Image)(resources.GetObject("btnKick.Image")));
            this.btnKick.Location = new System.Drawing.Point(50, 7);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(16, 10);
            this.btnKick.TabIndex = 3;
            this.btnKick.UseVisualStyleBackColor = false;
            // 
            // btnTrade
            // 
            this.btnTrade.BackColor = System.Drawing.Color.Transparent;
            this.btnTrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrade.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnTrade.FlatAppearance.BorderSize = 0;
            this.btnTrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrade.Image = ((System.Drawing.Image)(resources.GetObject("btnTrade.Image")));
            this.btnTrade.Location = new System.Drawing.Point(29, 5);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(15, 13);
            this.btnTrade.TabIndex = 4;
            this.btnTrade.UseVisualStyleBackColor = false;
            // 
            // ITEMIndicatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(365, 53);
            this.ControlBox = false;
            this.Controls.Add(this.panelFunctions);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ITEMIndicatorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ITEMIndicatorForm_FormClosing);
            this.Load += new System.EventHandler(this.ITEMIndicatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHideoutVert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.Label labelPriceAtTitle;
        private System.Windows.Forms.CheckBox checkQuadTab;
        private System.Windows.Forms.Panel panelFunctions;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureHideoutVert;
    }
}