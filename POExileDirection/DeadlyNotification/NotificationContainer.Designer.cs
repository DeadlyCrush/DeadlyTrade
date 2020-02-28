namespace POExileDirection
{
    partial class NotificationContainer
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
            this.panelNOTIFICATION = new System.Windows.Forms.Panel();
            this.pictureMovingBar = new System.Windows.Forms.PictureBox();
            this.panelNOTIFICATION.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMovingBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNOTIFICATION
            // 
            this.panelNOTIFICATION.Controls.Add(this.pictureMovingBar);
            this.panelNOTIFICATION.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNOTIFICATION.Location = new System.Drawing.Point(0, 0);
            this.panelNOTIFICATION.Name = "panelNOTIFICATION";
            this.panelNOTIFICATION.Size = new System.Drawing.Size(494, 113);
            this.panelNOTIFICATION.TabIndex = 0;
            // 
            // pictureMovingBar
            // 
            this.pictureMovingBar.BackgroundImage = global::POExileDirection.Properties.Resources.moving_bar_unlock;
            this.pictureMovingBar.Location = new System.Drawing.Point(0, 0);
            this.pictureMovingBar.Name = "pictureMovingBar";
            this.pictureMovingBar.Size = new System.Drawing.Size(40, 46);
            this.pictureMovingBar.TabIndex = 0;
            this.pictureMovingBar.TabStop = false;
            this.pictureMovingBar.Visible = false;
            this.pictureMovingBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureMovingBar_MouseDown);
            this.pictureMovingBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureMovingBar_MouseMove);
            this.pictureMovingBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureMovingBar_MouseUp);
            // 
            // NotificationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(494, 113);
            this.Controls.Add(this.panelNOTIFICATION);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationContainer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.NotificationContainer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationContainer_KeyDown);
            this.panelNOTIFICATION.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMovingBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNOTIFICATION;
        public System.Windows.Forms.PictureBox pictureMovingBar;
    }
}