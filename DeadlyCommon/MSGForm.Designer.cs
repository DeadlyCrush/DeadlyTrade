namespace POExileDirection
{
    partial class MSGForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKOR = new System.Windows.Forms.Button();
            this.btnENG = new System.Windows.Forms.Button();
            this.btmConfirm = new System.Windows.Forms.Button();
            this.lbMsg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = global::POExileDirection.Properties.Resources.Settings_BGBOX;
            this.panel1.Controls.Add(this.lbMsg);
            this.panel1.Controls.Add(this.btnKOR);
            this.panel1.Controls.Add(this.btnENG);
            this.panel1.Controls.Add(this.btmConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 288);
            this.panel1.TabIndex = 0;
            // 
            // btnKOR
            // 
            this.btnKOR.BackColor = System.Drawing.Color.Maroon;
            this.btnKOR.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnKOR.ForeColor = System.Drawing.Color.White;
            this.btnKOR.Location = new System.Drawing.Point(212, 245);
            this.btnKOR.Name = "btnKOR";
            this.btnKOR.Size = new System.Drawing.Size(75, 23);
            this.btnKOR.TabIndex = 1;
            this.btnKOR.Text = "한국어";
            this.btnKOR.UseVisualStyleBackColor = false;
            this.btnKOR.Visible = false;
            this.btnKOR.Click += new System.EventHandler(this.BtmConfirm_Click);
            // 
            // btnENG
            // 
            this.btnENG.BackColor = System.Drawing.Color.Maroon;
            this.btnENG.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnENG.ForeColor = System.Drawing.Color.White;
            this.btnENG.Location = new System.Drawing.Point(116, 245);
            this.btnENG.Name = "btnENG";
            this.btnENG.Size = new System.Drawing.Size(75, 23);
            this.btnENG.TabIndex = 1;
            this.btnENG.Text = "English";
            this.btnENG.UseVisualStyleBackColor = false;
            this.btnENG.Visible = false;
            this.btnENG.Click += new System.EventHandler(this.BtmConfirm_Click);
            // 
            // btmConfirm
            // 
            this.btmConfirm.BackColor = System.Drawing.Color.Maroon;
            this.btmConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btmConfirm.ForeColor = System.Drawing.Color.White;
            this.btmConfirm.Location = new System.Drawing.Point(166, 245);
            this.btmConfirm.Name = "btmConfirm";
            this.btmConfirm.Size = new System.Drawing.Size(75, 23);
            this.btmConfirm.TabIndex = 1;
            this.btmConfirm.Text = "확인";
            this.btmConfirm.UseVisualStyleBackColor = false;
            this.btmConfirm.Click += new System.EventHandler(this.BtmConfirm_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbMsg.Location = new System.Drawing.Point(10, 47);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(376, 181);
            this.lbMsg.TabIndex = 3;
            this.lbMsg.Text = "Msg.";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MSGForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 288);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "MSGForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSGForm";
            this.Load += new System.EventHandler(this.MSGForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btmConfirm;
        public System.Windows.Forms.Button btnKOR;
        public System.Windows.Forms.Button btnENG;
        public System.Windows.Forms.Label lbMsg;
    }
}