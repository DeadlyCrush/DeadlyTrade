namespace POExileDirection
{
    partial class ImageOverlayFormMap
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
            this.btnZoomout = new System.Windows.Forms.Button();
            this.btnZoomin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(21)))), ((int)(((byte)(16)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnZoomout);
            this.panel1.Controls.Add(this.btnZoomin);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 20);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
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
            this.btnZoomout.Location = new System.Drawing.Point(725, 0);
            this.btnZoomout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnZoomout.Name = "btnZoomout";
            this.btnZoomout.Size = new System.Drawing.Size(17, 18);
            this.btnZoomout.TabIndex = 11;
            this.btnZoomout.Text = "-";
            this.btnZoomout.UseVisualStyleBackColor = false;
            this.btnZoomout.Click += new System.EventHandler(this.BtnZoomOut_Click);
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
            this.btnZoomin.Location = new System.Drawing.Point(742, 0);
            this.btnZoomin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnZoomin.Name = "btnZoomin";
            this.btnZoomin.Size = new System.Drawing.Size(17, 18);
            this.btnZoomin.TabIndex = 10;
            this.btnZoomin.Text = "+";
            this.btnZoomin.UseVisualStyleBackColor = false;
            this.btnZoomin.Click += new System.EventHandler(this.BtnZoomIn_Click);
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
            this.btnClose.Location = new System.Drawing.Point(759, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 18);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(637, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Atlas Information. ( Original image from Reddit u/Towerbruh )";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(778, 404);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ImageOverlayFormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 424);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1901, 1442);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 322);
            this.Name = "ImageOverlayFormMap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ImageOverlayFormMap";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageOverlayFormMap_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageOverlayFormMap_FormClosed);
            this.Load += new System.EventHandler(this.ImageOverlayFormMap_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnZoomout;
        private System.Windows.Forms.Button btnZoomin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}