namespace POExileDirection
{
    partial class SettingsForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textZANA = new System.Windows.Forms.TextBox();
            this.textALVA = new System.Windows.Forms.TextBox();
            this.textJUN = new System.Windows.Forms.TextBox();
            this.textRemains = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.BackgroundImage = global::POExileDirection.Properties.Resources.Settings_BGBOX;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textZANA);
            this.panel1.Controls.Add(this.textALVA);
            this.panel1.Controls.Add(this.textJUN);
            this.panel1.Controls.Add(this.textRemains);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 288);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "단축키 설정 : 단축키를 입력하고 확인을 클릭하세요.";
            // 
            // textZANA
            // 
            this.textZANA.BackColor = System.Drawing.Color.Maroon;
            this.textZANA.ForeColor = System.Drawing.Color.White;
            this.textZANA.Location = new System.Drawing.Point(131, 198);
            this.textZANA.Name = "textZANA";
            this.textZANA.ReadOnly = true;
            this.textZANA.Size = new System.Drawing.Size(164, 21);
            this.textZANA.TabIndex = 3;
            this.textZANA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textZANA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextZANA_KeyDown);
            // 
            // textALVA
            // 
            this.textALVA.BackColor = System.Drawing.Color.Maroon;
            this.textALVA.ForeColor = System.Drawing.Color.White;
            this.textALVA.Location = new System.Drawing.Point(131, 158);
            this.textALVA.Name = "textALVA";
            this.textALVA.ReadOnly = true;
            this.textALVA.Size = new System.Drawing.Size(164, 21);
            this.textALVA.TabIndex = 3;
            this.textALVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textALVA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextALVA_KeyDown);
            // 
            // textJUN
            // 
            this.textJUN.BackColor = System.Drawing.Color.Maroon;
            this.textJUN.ForeColor = System.Drawing.Color.White;
            this.textJUN.Location = new System.Drawing.Point(131, 114);
            this.textJUN.Name = "textJUN";
            this.textJUN.ReadOnly = true;
            this.textJUN.Size = new System.Drawing.Size(164, 21);
            this.textJUN.TabIndex = 3;
            this.textJUN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textJUN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextJUN_KeyDown);
            // 
            // textRemains
            // 
            this.textRemains.BackColor = System.Drawing.Color.Maroon;
            this.textRemains.ForeColor = System.Drawing.Color.White;
            this.textRemains.Location = new System.Drawing.Point(131, 72);
            this.textRemains.Name = "textRemains";
            this.textRemains.ReadOnly = true;
            this.textRemains.Size = new System.Drawing.Size(164, 21);
            this.textRemains.TabIndex = 3;
            this.textRemains.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textRemains.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextRemains_KeyDown);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::POExileDirection.Properties.Resources.ZANA1;
            this.pictureBox3.Location = new System.Drawing.Point(66, 185);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::POExileDirection.Properties.Resources.ALVA;
            this.pictureBox2.Location = new System.Drawing.Point(66, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::POExileDirection.Properties.Resources.RemainBGBOX_32_32;
            this.pictureBox4.Location = new System.Drawing.Point(75, 65);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::POExileDirection.Properties.Resources.JUN;
            this.pictureBox1.Location = new System.Drawing.Point(66, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(176, 240);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "확인";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 288);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox textRemains;
        private System.Windows.Forms.TextBox textZANA;
        private System.Windows.Forms.TextBox textALVA;
        private System.Windows.Forms.TextBox textJUN;
        private System.Windows.Forms.Label label1;
    }
}