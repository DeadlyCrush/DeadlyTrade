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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLeftTop = new System.Windows.Forms.Button();
            this.btnClose2nd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::POExileDirection.Properties.Resources.GridForm_RedCloseButton;
            this.btnClose.Location = new System.Drawing.Point(610, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnLeftTop
            // 
            this.btnLeftTop.FlatAppearance.BorderSize = 0;
            this.btnLeftTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftTop.ForeColor = System.Drawing.Color.White;
            this.btnLeftTop.Image = global::POExileDirection.Properties.Resources._52x52_Box2;
            this.btnLeftTop.Location = new System.Drawing.Point(-1, -1);
            this.btnLeftTop.Name = "btnLeftTop";
            this.btnLeftTop.Size = new System.Drawing.Size(53, 53);
            this.btnLeftTop.TabIndex = 0;
            this.btnLeftTop.Text = "⩩⩩⩩⩩\r\n⩩⩩⩩⩩\r\n⩩⩩⩩⩩";
            this.btnLeftTop.UseVisualStyleBackColor = true;
            this.btnLeftTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnLeftTop_MouseDown);
            this.btnLeftTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnLeftTop_MouseMove);
            this.btnLeftTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnLeftTop_MouseUp);
            // 
            // btnClose2nd
            // 
            this.btnClose2nd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose2nd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose2nd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2nd.Image = global::POExileDirection.Properties.Resources.GridForm_RedCloseButton;
            this.btnClose2nd.Location = new System.Drawing.Point(0, 610);
            this.btnClose2nd.Name = "btnClose2nd";
            this.btnClose2nd.Size = new System.Drawing.Size(16, 16);
            this.btnClose2nd.TabIndex = 2;
            this.btnClose2nd.UseVisualStyleBackColor = true;
            this.btnClose2nd.Click += new System.EventHandler(this.BtnClose2nd_Click);
            // 
            // StashGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(626, 626);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose2nd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLeftTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(3840, 2160);
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "StashGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StashGrid_FormClosed);
            this.Load += new System.EventHandler(this.StashGrid_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StashGrid_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLeftTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClose2nd;
    }
}