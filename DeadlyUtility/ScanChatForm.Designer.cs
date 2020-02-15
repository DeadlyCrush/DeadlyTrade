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
            this.panelLeftTopAnchor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLANG2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMinMax = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listViewChat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxExclude = new System.Windows.Forms.TextBox();
            this.textBoxInclude = new System.Windows.Forms.TextBox();
            this.labelExclude = new System.Windows.Forms.Label();
            this.labelInclude = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTop2 = new System.Windows.Forms.Label();
            this.labelTop1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelNickName = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnWhois = new System.Windows.Forms.Button();
            this.btnWhisper = new System.Windows.Forms.Button();
            this.panelLeftTopAnchor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftTopAnchor
            // 
            this.panelLeftTopAnchor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelLeftTopAnchor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftTopAnchor.Controls.Add(this.label1);
            this.panelLeftTopAnchor.Controls.Add(this.btnLANG2);
            this.panelLeftTopAnchor.Controls.Add(this.button1);
            this.panelLeftTopAnchor.Controls.Add(this.btnMinMax);
            this.panelLeftTopAnchor.Controls.Add(this.btnClose);
            this.panelLeftTopAnchor.Controls.Add(this.textBox2);
            this.panelLeftTopAnchor.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTopAnchor.Name = "panelLeftTopAnchor";
            this.panelLeftTopAnchor.Size = new System.Drawing.Size(240, 36);
            this.panelLeftTopAnchor.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Scanning Trade Channel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
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
            // btnMinMax
            // 
            this.btnMinMax.BackColor = System.Drawing.Color.Transparent;
            this.btnMinMax.BackgroundImage = global::POExileDirection.Properties.Resources.Minimize_45_45_48_24px;
            this.btnMinMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinMax.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnMinMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinMax.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMinMax.ForeColor = System.Drawing.Color.White;
            this.btnMinMax.Location = new System.Drawing.Point(188, 7);
            this.btnMinMax.Name = "btnMinMax";
            this.btnMinMax.Size = new System.Drawing.Size(20, 20);
            this.btnMinMax.TabIndex = 2;
            this.btnMinMax.UseVisualStyleBackColor = false;
            this.btnMinMax.Click += new System.EventHandler(this.BtnMinMax_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::POExileDirection.Properties.Resources.Close_45_45_48_24px;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(214, 7);
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
            // listViewChat
            // 
            this.listViewChat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewChat.FullRowSelect = true;
            this.listViewChat.GridLines = true;
            this.listViewChat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewChat.HideSelection = false;
            this.listViewChat.Location = new System.Drawing.Point(0, 132);
            this.listViewChat.MultiSelect = false;
            this.listViewChat.Name = "listViewChat";
            this.listViewChat.Size = new System.Drawing.Size(240, 227);
            this.listViewChat.TabIndex = 6;
            this.listViewChat.UseCompatibleStateImageBehavior = false;
            this.listViewChat.View = System.Windows.Forms.View.Details;
            this.listViewChat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewChat_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nick";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 155;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.textBoxExclude);
            this.panel1.Controls.Add(this.textBoxInclude);
            this.panel1.Controls.Add(this.labelExclude);
            this.panel1.Controls.Add(this.labelInclude);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelTop2);
            this.panel1.Controls.Add(this.labelTop1);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 95);
            this.panel1.TabIndex = 7;
            // 
            // textBoxExclude
            // 
            this.textBoxExclude.Location = new System.Drawing.Point(73, 69);
            this.textBoxExclude.Name = "textBoxExclude";
            this.textBoxExclude.Size = new System.Drawing.Size(159, 21);
            this.textBoxExclude.TabIndex = 3;
            // 
            // textBoxInclude
            // 
            this.textBoxInclude.Location = new System.Drawing.Point(73, 43);
            this.textBoxInclude.Name = "textBoxInclude";
            this.textBoxInclude.Size = new System.Drawing.Size(159, 21);
            this.textBoxInclude.TabIndex = 3;
            // 
            // labelExclude
            // 
            this.labelExclude.AutoSize = true;
            this.labelExclude.ForeColor = System.Drawing.Color.Salmon;
            this.labelExclude.Location = new System.Drawing.Point(9, 74);
            this.labelExclude.Name = "labelExclude";
            this.labelExclude.Size = new System.Drawing.Size(57, 12);
            this.labelExclude.TabIndex = 2;
            this.labelExclude.Text = "제외 단어";
            // 
            // labelInclude
            // 
            this.labelInclude.AutoSize = true;
            this.labelInclude.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.labelInclude.Location = new System.Drawing.Point(9, 49);
            this.labelInclude.Name = "labelInclude";
            this.labelInclude.Size = new System.Drawing.Size(57, 12);
            this.labelInclude.TabIndex = 2;
            this.labelInclude.Text = "찾을 단어";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 1);
            this.panel2.TabIndex = 1;
            // 
            // labelTop2
            // 
            this.labelTop2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTop2.Location = new System.Drawing.Point(0, 15);
            this.labelTop2.Name = "labelTop2";
            this.labelTop2.Size = new System.Drawing.Size(240, 20);
            this.labelTop2.TabIndex = 0;
            this.labelTop2.Text = "(예: wts;팝니다;wtb;삽니다)";
            this.labelTop2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTop1
            // 
            this.labelTop1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTop1.Location = new System.Drawing.Point(0, 0);
            this.labelTop1.Name = "labelTop1";
            this.labelTop1.Size = new System.Drawing.Size(240, 20);
            this.labelTop1.TabIndex = 0;
            this.labelTop1.Text = "여러개의 단어는 \';\' 로 구분합니다.";
            this.labelTop1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.btnClear.Location = new System.Drawing.Point(186, 133);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 22);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "지우기";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // panelDetail
            // 
            this.panelDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelDetail.Controls.Add(this.labelMessage);
            this.panelDetail.Controls.Add(this.labelNickName);
            this.panelDetail.Controls.Add(this.btnHide);
            this.panelDetail.Controls.Add(this.btnWhois);
            this.panelDetail.Controls.Add(this.btnWhisper);
            this.panelDetail.Location = new System.Drawing.Point(11, 192);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(216, 141);
            this.panelDetail.TabIndex = 8;
            this.panelDetail.Visible = false;
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(68)))));
            this.labelMessage.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelMessage.Location = new System.Drawing.Point(5, 34);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(207, 72);
            this.labelMessage.TabIndex = 6;
            this.labelMessage.Text = "Message";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNickName
            // 
            this.labelNickName.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.labelNickName.Location = new System.Drawing.Point(5, 5);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(140, 22);
            this.labelNickName.TabIndex = 6;
            this.labelNickName.Text = "NickName";
            this.labelNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(68)))));
            this.btnHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHide.Location = new System.Drawing.Point(151, 112);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(61, 22);
            this.btnHide.TabIndex = 5;
            this.btnHide.Text = "닫기";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // btnWhois
            // 
            this.btnWhois.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(68)))));
            this.btnWhois.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhois.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhois.Location = new System.Drawing.Point(7, 112);
            this.btnWhois.Name = "btnWhois";
            this.btnWhois.Size = new System.Drawing.Size(98, 22);
            this.btnWhois.TabIndex = 5;
            this.btnWhois.Text = "사용자 정보";
            this.btnWhois.UseVisualStyleBackColor = false;
            this.btnWhois.Click += new System.EventHandler(this.BtnWhois_Click);
            // 
            // btnWhisper
            // 
            this.btnWhisper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(68)))));
            this.btnWhisper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhisper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhisper.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhisper.Location = new System.Drawing.Point(151, 5);
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.Size = new System.Drawing.Size(61, 22);
            this.btnWhisper.TabIndex = 5;
            this.btnWhisper.Text = "귓속말";
            this.btnWhisper.UseVisualStyleBackColor = false;
            this.btnWhisper.Click += new System.EventHandler(this.BtnWhisper_Click);
            // 
            // ScanChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 359);
            this.ControlBox = false;
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewChat);
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
            this.panelLeftTopAnchor.ResumeLayout(false);
            this.panelLeftTopAnchor.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelLeftTopAnchor;
        private System.Windows.Forms.Button btnLANG2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMinMax;
        private System.Windows.Forms.ListView listViewChat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxExclude;
        private System.Windows.Forms.TextBox textBoxInclude;
        private System.Windows.Forms.Label labelExclude;
        private System.Windows.Forms.Label labelInclude;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTop2;
        private System.Windows.Forms.Label labelTop1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnWhois;
        private System.Windows.Forms.Button btnWhisper;
    }
}