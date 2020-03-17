namespace POExileDirection
{
    partial class LaunchedOverlayIMAGEForm
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
            this.btnZoomout = new System.Windows.Forms.Button();
            this.btnZoomin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(21)))), ((int)(((byte)(16)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.btnZoomout);
            this.panelTop.Controls.Add(this.btnZoomin);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(445, 20);
            this.panelTop.TabIndex = 6;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnZoomout
            // 
            this.btnZoomout.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnZoomout.FlatAppearance.BorderSize = 0;
            this.btnZoomout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomout.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZoomout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnZoomout.Location = new System.Drawing.Point(392, 0);
            this.btnZoomout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnZoomout.Name = "btnZoomout";
            this.btnZoomout.Size = new System.Drawing.Size(17, 18);
            this.btnZoomout.TabIndex = 11;
            this.btnZoomout.Text = "-";
            this.btnZoomout.UseVisualStyleBackColor = false;
            this.btnZoomout.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomin
            // 
            this.btnZoomin.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnZoomin.FlatAppearance.BorderSize = 0;
            this.btnZoomin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomin.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZoomin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnZoomin.Location = new System.Drawing.Point(409, 0);
            this.btnZoomin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnZoomin.Name = "btnZoomin";
            this.btnZoomin.Size = new System.Drawing.Size(17, 18);
            this.btnZoomin.TabIndex = 10;
            this.btnZoomin.Text = "+";
            this.btnZoomin.UseVisualStyleBackColor = false;
            this.btnZoomin.Click += new System.EventHandler(this.btnZoomIn_Click);
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
            this.btnClose.Location = new System.Drawing.Point(426, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 18);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Labyrinth information. (POE Lab)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(445, 170);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LaunchedOverlayIMAGEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(64)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(445, 190);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 569);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 149);
            this.Name = "LaunchedOverlayIMAGEForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaunchedOverlayIMAGEForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LaunchedOverlayIMAGEForm_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnZoomout;
        private System.Windows.Forms.Button btnZoomin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}