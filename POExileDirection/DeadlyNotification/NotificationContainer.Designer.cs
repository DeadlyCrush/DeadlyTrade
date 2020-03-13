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
            this.panelHolder = new System.Windows.Forms.Panel();
            this.panelNOTIFICATION = new System.Windows.Forms.Panel();
            this.btnPanelArrow = new System.Windows.Forms.Button();
            this.panelHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHolder
            // 
            this.panelHolder.BackColor = System.Drawing.Color.DarkGray;
            this.panelHolder.Controls.Add(this.btnPanelArrow);
            this.panelHolder.Location = new System.Drawing.Point(0, 0);
            this.panelHolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelHolder.Name = "panelHolder";
            this.panelHolder.Size = new System.Drawing.Size(14, 121);
            this.panelHolder.TabIndex = 2;
            this.panelHolder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureMovingBar_MouseDown);
            this.panelHolder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureMovingBar_MouseMove);
            this.panelHolder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureMovingBar_MouseUp);
            // 
            // panelNOTIFICATION
            // 
            this.panelNOTIFICATION.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelNOTIFICATION.Location = new System.Drawing.Point(13, 0);
            this.panelNOTIFICATION.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelNOTIFICATION.Name = "panelNOTIFICATION";
            this.panelNOTIFICATION.Size = new System.Drawing.Size(495, 121);
            this.panelNOTIFICATION.TabIndex = 3;
            // 
            // btnPanelArrow
            // 
            this.btnPanelArrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(42)))), ((int)(((byte)(0)))));
            this.btnPanelArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPanelArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPanelArrow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPanelArrow.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnPanelArrow.FlatAppearance.BorderSize = 0;
            this.btnPanelArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanelArrow.Image = global::POExileDirection.Properties.Resources.PanelHolderArrow_up;
            this.btnPanelArrow.Location = new System.Drawing.Point(0, 105);
            this.btnPanelArrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPanelArrow.Name = "btnPanelArrow";
            this.btnPanelArrow.Size = new System.Drawing.Size(14, 16);
            this.btnPanelArrow.TabIndex = 2;
            this.btnPanelArrow.UseVisualStyleBackColor = false;
            this.btnPanelArrow.Visible = false;
            this.btnPanelArrow.Click += new System.EventHandler(this.btnPanelArrow_Click);
            // 
            // NotificationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(508, 121);
            this.Controls.Add(this.panelNOTIFICATION);
            this.Controls.Add(this.panelHolder);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationContainer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.NotificationContainer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotificationContainer_KeyDown);
            this.panelHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelHolder;
        private System.Windows.Forms.Button btnPanelArrow;
        private System.Windows.Forms.Panel panelNOTIFICATION;
    }
}