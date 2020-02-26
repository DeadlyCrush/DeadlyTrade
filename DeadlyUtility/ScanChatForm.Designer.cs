namespace POExileDirection
{
    partial class ScanChatForm
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
            this.btnClear = new System.Windows.Forms.Button();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelNickName = new System.Windows.Forms.Label();
            this.btnWhois = new System.Windows.Forms.Button();
            this.btnWhisper = new System.Windows.Forms.Button();
            this.panelLeftTopAnchor = new System.Windows.Forms.Panel();
            this.btnLANG2 = new System.Windows.Forms.Button();
            this.textBoxExclude = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxInclude = new System.Windows.Forms.TextBox();
            this.listViewChat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDetail.SuspendLayout();
            this.panelLeftTopAnchor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(145)))), ((int)(((byte)(130)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.btnClear.Location = new System.Drawing.Point(238, 208);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(45, 18);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // panelDetail
            // 
            this.panelDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.panelDetail.Controls.Add(this.labelMessage);
            this.panelDetail.Controls.Add(this.labelNickName);
            this.panelDetail.Controls.Add(this.btnWhois);
            this.panelDetail.Controls.Add(this.btnWhisper);
            this.panelDetail.Location = new System.Drawing.Point(49, 315);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(216, 101);
            this.panelDetail.TabIndex = 8;
            this.panelDetail.Visible = false;
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(1, 27);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(213, 44);
            this.labelMessage.TabIndex = 6;
            this.labelMessage.Text = "Message";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNickName
            // 
            this.labelNickName.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelNickName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.labelNickName.Location = new System.Drawing.Point(1, 3);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(213, 20);
            this.labelNickName.TabIndex = 6;
            this.labelNickName.Text = "NickName";
            this.labelNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWhois
            // 
            this.btnWhois.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.btnWhois.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhois.FlatAppearance.BorderSize = 0;
            this.btnWhois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhois.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhois.Image = global::POExileDirection.Properties.Resources.message_whisper;
            this.btnWhois.Location = new System.Drawing.Point(151, 77);
            this.btnWhois.Name = "btnWhois";
            this.btnWhois.Size = new System.Drawing.Size(59, 18);
            this.btnWhois.TabIndex = 5;
            this.btnWhois.UseVisualStyleBackColor = false;
            this.btnWhois.Click += new System.EventHandler(this.BtnWhois_Click);
            // 
            // btnWhisper
            // 
            this.btnWhisper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.btnWhisper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhisper.FlatAppearance.BorderSize = 0;
            this.btnWhisper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhisper.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhisper.Image = global::POExileDirection.Properties.Resources.message_whois;
            this.btnWhisper.Location = new System.Drawing.Point(5, 77);
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.Size = new System.Drawing.Size(59, 18);
            this.btnWhisper.TabIndex = 5;
            this.btnWhisper.UseVisualStyleBackColor = false;
            this.btnWhisper.Click += new System.EventHandler(this.BtnWhisper_Click);
            // 
            // panelLeftTopAnchor
            // 
            this.panelLeftTopAnchor.BackColor = System.Drawing.Color.DarkGray;
            this.panelLeftTopAnchor.BackgroundImage = global::POExileDirection.Properties.Resources.bg2;
            this.panelLeftTopAnchor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftTopAnchor.Controls.Add(this.btnLANG2);
            this.panelLeftTopAnchor.Controls.Add(this.textBoxExclude);
            this.panelLeftTopAnchor.Controls.Add(this.button1);
            this.panelLeftTopAnchor.Controls.Add(this.btnClose);
            this.panelLeftTopAnchor.Controls.Add(this.textBox2);
            this.panelLeftTopAnchor.Controls.Add(this.panelDetail);
            this.panelLeftTopAnchor.Controls.Add(this.textBoxInclude);
            this.panelLeftTopAnchor.Controls.Add(this.btnClear);
            this.panelLeftTopAnchor.Controls.Add(this.listViewChat);
            this.panelLeftTopAnchor.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTopAnchor.Name = "panelLeftTopAnchor";
            this.panelLeftTopAnchor.Size = new System.Drawing.Size(313, 438);
            this.panelLeftTopAnchor.TabIndex = 5;
            this.panelLeftTopAnchor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnScan_MouseDown);
            this.panelLeftTopAnchor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnScan_MouseMove);
            this.panelLeftTopAnchor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnScan_MouseUp);
            // 
            // btnLANG2
            // 
            this.btnLANG2.BackColor = System.Drawing.Color.Transparent;
            this.btnLANG2.BackgroundImage = global::POExileDirection.Properties.Resources.flag_korea;
            this.btnLANG2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLANG2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnLANG2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLANG2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLANG2.ForeColor = System.Drawing.Color.White;
            this.btnLANG2.Location = new System.Drawing.Point(1386, 4);
            this.btnLANG2.Name = "btnLANG2";
            this.btnLANG2.Size = new System.Drawing.Size(28, 28);
            this.btnLANG2.TabIndex = 2;
            this.btnLANG2.UseVisualStyleBackColor = false;
            // 
            // textBoxExclude
            // 
            this.textBoxExclude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(55)))), ((int)(((byte)(33)))));
            this.textBoxExclude.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxExclude.Location = new System.Drawing.Point(92, 163);
            this.textBoxExclude.Name = "textBoxExclude";
            this.textBoxExclude.Size = new System.Drawing.Size(190, 14);
            this.textBoxExclude.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::POExileDirection.Properties.Resources.CloseButton_45_45_48_24px;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1570, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(16)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::POExileDirection.Properties.Resources.close1;
            this.btnClose.Location = new System.Drawing.Point(280, 39);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1481, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(83, 21);
            this.textBox2.TabIndex = 1;
            // 
            // textBoxInclude
            // 
            this.textBoxInclude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(55)))), ((int)(((byte)(33)))));
            this.textBoxInclude.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInclude.Location = new System.Drawing.Point(92, 126);
            this.textBoxInclude.Name = "textBoxInclude";
            this.textBoxInclude.Size = new System.Drawing.Size(190, 14);
            this.textBoxInclude.TabIndex = 3;
            // 
            // listViewChat
            // 
            this.listViewChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(55)))), ((int)(((byte)(33)))));
            this.listViewChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewChat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewChat.FullRowSelect = true;
            this.listViewChat.GridLines = true;
            this.listViewChat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewChat.HideSelection = false;
            this.listViewChat.Location = new System.Drawing.Point(22, 228);
            this.listViewChat.MultiSelect = false;
            this.listViewChat.Name = "listViewChat";
            this.listViewChat.Size = new System.Drawing.Size(267, 196);
            this.listViewChat.TabIndex = 6;
            this.listViewChat.UseCompatibleStateImageBehavior = false;
            this.listViewChat.View = System.Windows.Forms.View.Details;
            this.listViewChat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewChat_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nick";
            this.columnHeader1.Width = 82;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 165;
            // 
            // ScanChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(313, 438);
            this.ControlBox = false;
            this.Controls.Add(this.panelLeftTopAnchor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanChatForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.ScanChatForm_Load);
            this.panelDetail.ResumeLayout(false);
            this.panelLeftTopAnchor.ResumeLayout(false);
            this.panelLeftTopAnchor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelLeftTopAnchor;
        private System.Windows.Forms.Button btnLANG2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView listViewChat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox textBoxExclude;
        private System.Windows.Forms.TextBox textBoxInclude;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Button btnWhois;
        private System.Windows.Forms.Button btnWhisper;
    }
}