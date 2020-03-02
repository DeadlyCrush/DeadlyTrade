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
            this.btnLeftTop = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLeftTop
            // 
            this.btnLeftTop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLeftTop.FlatAppearance.BorderSize = 0;
            this.btnLeftTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftTop.Image = global::POExileDirection.Properties.Resources.LEFT_TOP_ANCHOR;
            this.btnLeftTop.Location = new System.Drawing.Point(-1, -1);
            this.btnLeftTop.Name = "btnLeftTop";
            this.btnLeftTop.Size = new System.Drawing.Size(16, 16);
            this.btnLeftTop.TabIndex = 9;
            this.btnLeftTop.UseVisualStyleBackColor = true;
            this.btnLeftTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnLeftTop_MouseDown);
            this.btnLeftTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnLeftTop_MouseMove);
            this.btnLeftTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnLeftTop_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::POExileDirection.Properties.Resources.GridForm_RedCloseButton;
            this.btnClose.Location = new System.Drawing.Point(39, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // StashGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(55, 55);
            this.ControlBox = false;
            this.Controls.Add(this.btnLeftTop);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StashGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StashGrid_FormClosed);
            this.Load += new System.EventHandler(this.StashGrid_Load);
            this.SizeChanged += new System.EventHandler(this.StashGrid_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StashGrid_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLeftTop;
        private System.Windows.Forms.Button btnClose;
    }
}