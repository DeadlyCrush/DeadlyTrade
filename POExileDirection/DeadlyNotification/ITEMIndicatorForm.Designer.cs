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
            this.labelItemName = new System.Windows.Forms.Label();
            this.panelFunctions = new System.Windows.Forms.Panel();
            this.btnSold = new System.Windows.Forms.Button();
            this.btnWait = new System.Windows.Forms.Button();
            this.btnThx = new System.Windows.Forms.Button();
            this.pictureHideoutVert = new System.Windows.Forms.PictureBox();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnKick = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHideoutVert)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::POExileDirection.Properties.Resources.GRID_INDICATOR;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 54);
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
            this.panelTop.Controls.Add(this.labelItemName);
            this.panelTop.Location = new System.Drawing.Point(54, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.checkQuadTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkQuadTab.Name = "checkQuadTab";
            this.checkQuadTab.Size = new System.Drawing.Size(12, 11);
            this.checkQuadTab.TabIndex = 0;
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
            this.btnCurrency.Location = new System.Drawing.Point(289, 2);
            this.btnCurrency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.labelPriceAtTitle.Location = new System.Drawing.Point(235, 5);
            this.labelPriceAtTitle.Name = "labelPriceAtTitle";
            this.labelPriceAtTitle.Size = new System.Drawing.Size(52, 16);
            this.labelPriceAtTitle.TabIndex = 14;
            this.labelPriceAtTitle.Text = "99999";
            this.labelPriceAtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPriceAtTitle.Click += new System.EventHandler(this.labelItemName_Click);
            // 
            // labelItemName
            // 
            this.labelItemName.AutoEllipsis = true;
            this.labelItemName.BackColor = System.Drawing.Color.Transparent;
            this.labelItemName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelItemName.ForeColor = System.Drawing.Color.Silver;
            this.labelItemName.Location = new System.Drawing.Point(21, 5);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(207, 16);
            this.labelItemName.TabIndex = 1;
            this.labelItemName.Text = "Very Expensive Item  (아이템)";
            this.labelItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelItemName.Click += new System.EventHandler(this.labelItemName_Click);
            // 
            // panelFunctions
            // 
            this.panelFunctions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panelFunctions.Controls.Add(this.btnSold);
            this.panelFunctions.Controls.Add(this.btnWait);
            this.panelFunctions.Controls.Add(this.btnThx);
            this.panelFunctions.Controls.Add(this.pictureHideoutVert);
            this.panelFunctions.Controls.Add(this.btnInvite);
            this.panelFunctions.Controls.Add(this.btnClose);
            this.panelFunctions.Controls.Add(this.btnKick);
            this.panelFunctions.Controls.Add(this.btnTrade);
            this.panelFunctions.Location = new System.Drawing.Point(77, 24);
            this.panelFunctions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelFunctions.Name = "panelFunctions";
            this.panelFunctions.Size = new System.Drawing.Size(288, 30);
            this.panelFunctions.TabIndex = 2;
            // 
            // btnSold
            // 
            this.btnSold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnSold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSold.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSold.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSold.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSold.Location = new System.Drawing.Point(107, 5);
            this.btnSold.Name = "btnSold";
            this.btnSold.Size = new System.Drawing.Size(45, 22);
            this.btnSold.TabIndex = 4;
            this.btnSold.Text = "Sold";
            this.btnSold.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSold.UseVisualStyleBackColor = false;
            this.btnSold.Click += new System.EventHandler(this.btnSold_Click);
            // 
            // btnWait
            // 
            this.btnWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnWait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWait.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnWait.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnWait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWait.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWait.Location = new System.Drawing.Point(56, 5);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(45, 22);
            this.btnWait.TabIndex = 3;
            this.btnWait.Text = "Wait";
            this.btnWait.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWait.UseVisualStyleBackColor = false;
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // btnThx
            // 
            this.btnThx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnThx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThx.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnThx.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnThx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThx.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnThx.Location = new System.Drawing.Point(5, 5);
            this.btnThx.Name = "btnThx";
            this.btnThx.Size = new System.Drawing.Size(45, 22);
            this.btnThx.TabIndex = 2;
            this.btnThx.Text = "Thx";
            this.btnThx.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThx.UseVisualStyleBackColor = false;
            this.btnThx.Click += new System.EventHandler(this.btnThx_Click);
            // 
            // pictureHideoutVert
            // 
            this.pictureHideoutVert.Image = ((System.Drawing.Image)(resources.GetObject("pictureHideoutVert.Image")));
            this.pictureHideoutVert.Location = new System.Drawing.Point(264, 10);
            this.pictureHideoutVert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureHideoutVert.Name = "pictureHideoutVert";
            this.pictureHideoutVert.Size = new System.Drawing.Size(1, 14);
            this.pictureHideoutVert.TabIndex = 19;
            this.pictureHideoutVert.TabStop = false;
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
            this.btnInvite.Location = new System.Drawing.Point(196, 6);
            this.btnInvite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(17, 16);
            this.btnInvite.TabIndex = 5;
            this.btnInvite.UseVisualStyleBackColor = false;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(268, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnKick.Location = new System.Drawing.Point(240, 10);
            this.btnKick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(16, 12);
            this.btnKick.TabIndex = 7;
            this.btnKick.UseVisualStyleBackColor = false;
            this.btnKick.Click += new System.EventHandler(this.btnKick_Click);
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
            this.btnTrade.Location = new System.Drawing.Point(219, 7);
            this.btnTrade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(15, 16);
            this.btnTrade.TabIndex = 6;
            this.btnTrade.UseVisualStyleBackColor = false;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // ITEMIndicatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(365, 54);
            this.ControlBox = false;
            this.Controls.Add(this.panelFunctions);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureHideoutVert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.Label labelPriceAtTitle;
        private System.Windows.Forms.CheckBox checkQuadTab;
        private System.Windows.Forms.Panel panelFunctions;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.PictureBox pictureHideoutVert;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSold;
        private System.Windows.Forms.Button btnWait;
        private System.Windows.Forms.Button btnThx;
    }
}