namespace POExileDirection
{
    partial class StashGrid
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
            this.panelQuadCheck = new System.Windows.Forms.Panel();
            this.labelAddonStatus = new System.Windows.Forms.Label();
            this.checkQuadTab = new System.Windows.Forms.CheckBox();
            this.panelQuadCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQuadCheck
            // 
            this.panelQuadCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(47)))), ((int)(((byte)(28)))));
            this.panelQuadCheck.Controls.Add(this.labelAddonStatus);
            this.panelQuadCheck.Controls.Add(this.checkQuadTab);
            this.panelQuadCheck.Location = new System.Drawing.Point(190, 12);
            this.panelQuadCheck.Name = "panelQuadCheck";
            this.panelQuadCheck.Size = new System.Drawing.Size(133, 22);
            this.panelQuadCheck.TabIndex = 3;
            // 
            // labelAddonStatus
            // 
            this.labelAddonStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(47)))), ((int)(((byte)(28)))));
            this.labelAddonStatus.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddonStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(197)))), ((int)(((byte)(86)))));
            this.labelAddonStatus.Location = new System.Drawing.Point(26, 1);
            this.labelAddonStatus.Name = "labelAddonStatus";
            this.labelAddonStatus.Size = new System.Drawing.Size(104, 18);
            this.labelAddonStatus.TabIndex = 6;
            this.labelAddonStatus.Text = "Show Quad Grid.";
            this.labelAddonStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkQuadTab
            // 
            this.checkQuadTab.AutoSize = true;
            this.checkQuadTab.Location = new System.Drawing.Point(8, 4);
            this.checkQuadTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkQuadTab.Name = "checkQuadTab";
            this.checkQuadTab.Size = new System.Drawing.Size(15, 14);
            this.checkQuadTab.TabIndex = 5;
            this.checkQuadTab.TabStop = false;
            this.checkQuadTab.UseVisualStyleBackColor = true;
            this.checkQuadTab.CheckedChanged += new System.EventHandler(this.checkQuadTab_CheckedChanged);
            // 
            // StashGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(409, 40);
            this.ControlBox = false;
            this.Controls.Add(this.panelQuadCheck);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StashGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StashGrid_FormClosed);
            this.Load += new System.EventHandler(this.StashGrid_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StashGrid_Paint);
            this.panelQuadCheck.ResumeLayout(false);
            this.panelQuadCheck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelQuadCheck;
        private System.Windows.Forms.CheckBox checkQuadTab;
        private System.Windows.Forms.Label labelAddonStatus;
    }
}