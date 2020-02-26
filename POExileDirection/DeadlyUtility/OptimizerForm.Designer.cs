namespace POExileDirection
{
    partial class OptimizerForm
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
            this.xuiGaugeMinimapCache = new XanderUI.XUIGauge();
            this.xuiGaugeLogFileSize = new XanderUI.XUIGauge();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMinimapCacheInform = new System.Windows.Forms.Label();
            this.labelShaderFileInform = new System.Windows.Forms.Label();
            this.lablePath = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCleanShaderCacheFile = new System.Windows.Forms.Button();
            this.btnStartCheck = new System.Windows.Forms.Button();
            this.btnCleanMinimapCache = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelTop = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // xuiGaugeMinimapCache
            // 
            this.xuiGaugeMinimapCache.DialColor = System.Drawing.Color.LightCoral;
            this.xuiGaugeMinimapCache.DialThickness = 10;
            this.xuiGaugeMinimapCache.FilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.xuiGaugeMinimapCache.ForeColor = System.Drawing.Color.DarkMagenta;
            this.xuiGaugeMinimapCache.GaugeStyle = XanderUI.XUIGauge.Style.Standard;
            this.xuiGaugeMinimapCache.Location = new System.Drawing.Point(27, 243);
            this.xuiGaugeMinimapCache.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xuiGaugeMinimapCache.Name = "xuiGaugeMinimapCache";
            this.xuiGaugeMinimapCache.Percentage = 75;
            this.xuiGaugeMinimapCache.Size = new System.Drawing.Size(242, 88);
            this.xuiGaugeMinimapCache.TabIndex = 0;
            this.xuiGaugeMinimapCache.Text = "xuiGauge1";
            this.xuiGaugeMinimapCache.Thickness = 15;
            this.xuiGaugeMinimapCache.UnfilledColor = System.Drawing.Color.Gray;
            // 
            // xuiGaugeLogFileSize
            // 
            this.xuiGaugeLogFileSize.DialColor = System.Drawing.Color.LightCoral;
            this.xuiGaugeLogFileSize.DialThickness = 10;
            this.xuiGaugeLogFileSize.FilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.xuiGaugeLogFileSize.ForeColor = System.Drawing.Color.DarkMagenta;
            this.xuiGaugeLogFileSize.GaugeStyle = XanderUI.XUIGauge.Style.Standard;
            this.xuiGaugeLogFileSize.Location = new System.Drawing.Point(27, 405);
            this.xuiGaugeLogFileSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xuiGaugeLogFileSize.Name = "xuiGaugeLogFileSize";
            this.xuiGaugeLogFileSize.Percentage = 75;
            this.xuiGaugeLogFileSize.Size = new System.Drawing.Size(242, 88);
            this.xuiGaugeLogFileSize.TabIndex = 0;
            this.xuiGaugeLogFileSize.Text = "xuiGauge1";
            this.xuiGaugeLogFileSize.Thickness = 15;
            this.xuiGaugeLogFileSize.UnfilledColor = System.Drawing.Color.Gray;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Location = new System.Drawing.Point(296, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "   Minimap Cache File Information";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Location = new System.Drawing.Point(296, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "   Shader Cache File Information";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMinimapCacheInform
            // 
            this.labelMinimapCacheInform.ForeColor = System.Drawing.Color.Gold;
            this.labelMinimapCacheInform.Location = new System.Drawing.Point(296, 272);
            this.labelMinimapCacheInform.Name = "labelMinimapCacheInform";
            this.labelMinimapCacheInform.Size = new System.Drawing.Size(292, 29);
            this.labelMinimapCacheInform.TabIndex = 2;
            this.labelMinimapCacheInform.Text = "aaaa";
            this.labelMinimapCacheInform.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShaderFileInform
            // 
            this.labelShaderFileInform.ForeColor = System.Drawing.Color.Gold;
            this.labelShaderFileInform.Location = new System.Drawing.Point(296, 434);
            this.labelShaderFileInform.Name = "labelShaderFileInform";
            this.labelShaderFileInform.Size = new System.Drawing.Size(292, 29);
            this.labelShaderFileInform.TabIndex = 2;
            this.labelShaderFileInform.Text = "bbb";
            this.labelShaderFileInform.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lablePath
            // 
            this.lablePath.ForeColor = System.Drawing.Color.Gold;
            this.lablePath.Location = new System.Drawing.Point(21, 53);
            this.lablePath.Name = "lablePath";
            this.lablePath.Size = new System.Drawing.Size(567, 29);
            this.lablePath.TabIndex = 2;
            this.lablePath.Text = "Can\'t Find POE Path in DeadlyTrade Config File.";
            this.lablePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label5.Location = new System.Drawing.Point(12, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(576, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "   Path Of Exile Path";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.Location = new System.Drawing.Point(12, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(576, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "   Check Cache file status";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label7.Location = new System.Drawing.Point(12, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(576, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "   Clean Cache file if necessary";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Moccasin;
            this.label1.Location = new System.Drawing.Point(34, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "LOW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(120, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "MEDIUM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(216, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 29);
            this.label8.TabIndex = 2;
            this.label8.Text = "HIGH";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCleanShaderCacheFile
            // 
            this.btnCleanShaderCacheFile.BackColor = System.Drawing.Color.White;
            this.btnCleanShaderCacheFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCleanShaderCacheFile.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCleanShaderCacheFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanShaderCacheFile.Image = global::POExileDirection.Properties.Resources.recycle_bin_24x24;
            this.btnCleanShaderCacheFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCleanShaderCacheFile.Location = new System.Drawing.Point(299, 467);
            this.btnCleanShaderCacheFile.Name = "btnCleanShaderCacheFile";
            this.btnCleanShaderCacheFile.Size = new System.Drawing.Size(289, 26);
            this.btnCleanShaderCacheFile.TabIndex = 4;
            this.btnCleanShaderCacheFile.Text = "  Clean Shader Cache";
            this.btnCleanShaderCacheFile.UseVisualStyleBackColor = false;
            this.btnCleanShaderCacheFile.Visible = false;
            this.btnCleanShaderCacheFile.Click += new System.EventHandler(this.btnCleanShaderCacheFile_Click);
            // 
            // btnStartCheck
            // 
            this.btnStartCheck.BackColor = System.Drawing.Color.White;
            this.btnStartCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartCheck.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnStartCheck.FlatAppearance.BorderSize = 2;
            this.btnStartCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartCheck.Image = global::POExileDirection.Properties.Resources.button_blue_play_24x24;
            this.btnStartCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartCheck.Location = new System.Drawing.Point(474, 127);
            this.btnStartCheck.Name = "btnStartCheck";
            this.btnStartCheck.Size = new System.Drawing.Size(114, 42);
            this.btnStartCheck.TabIndex = 3;
            this.btnStartCheck.Text = "     START\r\n     Checking";
            this.btnStartCheck.UseVisualStyleBackColor = false;
            this.btnStartCheck.Visible = false;
            this.btnStartCheck.Click += new System.EventHandler(this.btnStartCheck_Click);
            // 
            // btnCleanMinimapCache
            // 
            this.btnCleanMinimapCache.BackColor = System.Drawing.Color.White;
            this.btnCleanMinimapCache.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCleanMinimapCache.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCleanMinimapCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanMinimapCache.Image = global::POExileDirection.Properties.Resources.recycle_bin_24x24;
            this.btnCleanMinimapCache.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCleanMinimapCache.Location = new System.Drawing.Point(299, 305);
            this.btnCleanMinimapCache.Name = "btnCleanMinimapCache";
            this.btnCleanMinimapCache.Size = new System.Drawing.Size(289, 26);
            this.btnCleanMinimapCache.TabIndex = 3;
            this.btnCleanMinimapCache.Text = "  Clean Minimap Cache";
            this.btnCleanMinimapCache.UseVisualStyleBackColor = false;
            this.btnCleanMinimapCache.Visible = false;
            this.btnCleanMinimapCache.Click += new System.EventHandler(this.btnCleanMinimapCache_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.labelTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 22);
            this.panelTop.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::POExileDirection.Properties.Resources._16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(581, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 20);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelTop
            // 
            this.labelTop.BackColor = System.Drawing.Color.Transparent;
            this.labelTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTop.ForeColor = System.Drawing.Color.White;
            this.labelTop.Location = new System.Drawing.Point(0, 0);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(226, 20);
            this.labelTop.TabIndex = 4;
            this.labelTop.Text = "POE Cache File Clean Utility";
            this.labelTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Moccasin;
            this.label9.Location = new System.Drawing.Point(34, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 29);
            this.label9.TabIndex = 2;
            this.label9.Text = "LOW";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.OrangeRed;
            this.label10.Location = new System.Drawing.Point(216, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 29);
            this.label10.TabIndex = 2;
            this.label10.Text = "HIGH";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.DarkOrange;
            this.label11.Location = new System.Drawing.Point(120, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 29);
            this.label11.TabIndex = 2;
            this.label11.Text = "MEDIUM";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptimizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(600, 514);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnCleanShaderCacheFile);
            this.Controls.Add(this.btnStartCheck);
            this.Controls.Add(this.btnCleanMinimapCache);
            this.Controls.Add(this.labelShaderFileInform);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelMinimapCacheInform);
            this.Controls.Add(this.lablePath);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.xuiGaugeLogFileSize);
            this.Controls.Add(this.xuiGaugeMinimapCache);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(600, 514);
            this.MinimumSize = new System.Drawing.Size(600, 514);
            this.Name = "OptimizerForm";
            this.Text = "OptimizerForm";
            this.Load += new System.EventHandler(this.OptimizerForm_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XanderUI.XUIGauge xuiGaugeMinimapCache;
        private XanderUI.XUIGauge xuiGaugeLogFileSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMinimapCacheInform;
        private System.Windows.Forms.Label labelShaderFileInform;
        private System.Windows.Forms.Button btnCleanMinimapCache;
        private System.Windows.Forms.Button btnCleanShaderCacheFile;
        private System.Windows.Forms.Button btnStartCheck;
        private System.Windows.Forms.Label lablePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}