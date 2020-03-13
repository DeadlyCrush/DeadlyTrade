namespace POExileDirection.DeadlyNotification
{
    partial class TradeHistory
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.커런시 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.닉네임 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.아이템 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.귓속말 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.구매판매 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDetail = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelNickName = new System.Windows.Forms.Label();
            this.btnWhois = new System.Windows.Forms.Button();
            this.btnWhisper = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(21)))), ((int)(((byte)(16)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 20);
            this.panelTop.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Location = new System.Drawing.Point(581, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 18);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(575, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trade Notification History.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(98)))), ((int)(((byte)(59)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.커런시,
            this.구매판매,
            this.닉네임,
            this.아이템,
            this.귓속말});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 20);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(600, 460);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // 커런시
            // 
            this.커런시.Width = 0;
            // 
            // 닉네임
            // 
            this.닉네임.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.닉네임.Width = 80;
            // 
            // 아이템
            // 
            this.아이템.Width = 100;
            // 
            // 귓속말
            // 
            this.귓속말.Width = 360;
            // 
            // 구매판매
            // 
            this.구매판매.Width = 30;
            // 
            // panelDetail
            // 
            this.panelDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.panelDetail.Controls.Add(this.labelMessage);
            this.panelDetail.Controls.Add(this.labelNickName);
            this.panelDetail.Controls.Add(this.btnWhois);
            this.panelDetail.Controls.Add(this.btnWhisper);
            this.panelDetail.Location = new System.Drawing.Point(76, 163);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(437, 192);
            this.panelDetail.TabIndex = 9;
            this.panelDetail.Visible = false;
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(1, 27);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(433, 136);
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
            this.labelNickName.Size = new System.Drawing.Size(433, 20);
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
            this.btnWhois.Image = global::POExileDirection.Properties.Resources.message_whois;
            this.btnWhois.Location = new System.Drawing.Point(5, 166);
            this.btnWhois.Name = "btnWhois";
            this.btnWhois.Size = new System.Drawing.Size(59, 18);
            this.btnWhois.TabIndex = 5;
            this.btnWhois.UseVisualStyleBackColor = false;
            this.btnWhois.Click += new System.EventHandler(this.btnWhois_Click);
            // 
            // btnWhisper
            // 
            this.btnWhisper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.btnWhisper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhisper.FlatAppearance.BorderSize = 0;
            this.btnWhisper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhisper.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhisper.Image = global::POExileDirection.Properties.Resources.message_whisper;
            this.btnWhisper.Location = new System.Drawing.Point(370, 166);
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.Size = new System.Drawing.Size(59, 18);
            this.btnWhisper.TabIndex = 5;
            this.btnWhisper.UseVisualStyleBackColor = false;
            this.btnWhisper.Click += new System.EventHandler(this.btnWhisper_Click);
            // 
            // TradeHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(600, 480);
            this.ControlBox = false;
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TradeHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TradeHistory";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.TradeHistory_Load);
            this.panelTop.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 커런시;
        private System.Windows.Forms.ColumnHeader 구매판매;
        private System.Windows.Forms.ColumnHeader 닉네임;
        private System.Windows.Forms.ColumnHeader 아이템;
        private System.Windows.Forms.ColumnHeader 귓속말;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Button btnWhois;
        private System.Windows.Forms.Button btnWhisper;
    }
}