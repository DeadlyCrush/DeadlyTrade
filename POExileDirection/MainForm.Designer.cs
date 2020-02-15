namespace POExileDirection
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.zoneWatcher = new System.Windows.Forms.Timer(this.components);
            this.panelMid = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLang = new System.Windows.Forms.Button();
            this.panelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoneWatcher
            // 
            this.zoneWatcher.Interval = 200;
            this.zoneWatcher.Tick += new System.EventHandler(this.ReadNewLines_Timer);
            // 
            // panelMid
            // 
            this.panelMid.BackColor = System.Drawing.Color.DarkGray;
            this.panelMid.Controls.Add(this.pictureBox4);
            this.panelMid.Controls.Add(this.pictureBox3);
            this.panelMid.Controls.Add(this.pictureBox2);
            this.panelMid.Controls.Add(this.pictureBox1);
            this.panelMid.Controls.Add(this.noteLabel);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(0, 18);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(534, 121);
            this.panelMid.TabIndex = 2;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(404, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 72);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(268, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 72);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = global::POExileDirection.Properties.Resources.POExileDirection;
            this.pictureBox2.InitialImage = global::POExileDirection.Properties.Resources.POExileDirection;
            this.pictureBox2.Location = new System.Drawing.Point(134, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 72);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 72);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // noteLabel
            // 
            this.noteLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.noteLabel.ForeColor = System.Drawing.Color.Silver;
            this.noteLabel.Image = global::POExileDirection.Properties.Resources.POE_BG_to_BottomPane;
            this.noteLabel.Location = new System.Drawing.Point(0, 78);
            this.noteLabel.Margin = new System.Windows.Forms.Padding(0);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(534, 45);
            this.noteLabel.TabIndex = 0;
            this.noteLabel.Text = "EXPLAIN";
            this.noteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTop.BackgroundImage = global::POExileDirection.Properties.Resources.POE_BG_TILE;
            this.panelTop.Controls.Add(this.btnLang);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(534, 18);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseUp);
            // 
            // btnLang
            // 
            this.btnLang.BackColor = System.Drawing.Color.Transparent;
            this.btnLang.FlatAppearance.BorderSize = 0;
            this.btnLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLang.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLang.ForeColor = System.Drawing.Color.White;
            this.btnLang.Location = new System.Drawing.Point(1, 1);
            this.btnLang.Name = "btnLang";
            this.btnLang.Size = new System.Drawing.Size(531, 18);
            this.btnLang.TabIndex = 3;
            this.btnLang.TabStop = false;
            this.btnLang.Text = "KOR";
            this.btnLang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLang.UseVisualStyleBackColor = false;
            this.btnLang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnLang_MouseDown);
            this.btnLang.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnLang_MouseMove);
            this.btnLang.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnLang_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(534, 139);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POExileDirection";
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Timer zoneWatcher;
        private System.Windows.Forms.Button btnLang;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

