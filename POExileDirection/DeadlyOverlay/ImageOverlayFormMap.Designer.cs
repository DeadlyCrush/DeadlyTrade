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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLauncherLogin = new System.Windows.Forms.Button();
            this.listViewPantheon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.God = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Map = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelPhanteon = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.btnZoomOut);
            this.panelTop.Controls.Add(this.btnZoomIn);
            this.panelTop.Controls.Add(this.button1);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 18);
            this.panelTop.TabIndex = 5;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.BackgroundImage = global::POExileDirection.Properties.Resources.KickFromParty_24px;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZoomOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnZoomOut.Location = new System.Drawing.Point(747, 0);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(17, 16);
            this.btnZoomOut.TabIndex = 8;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.BackgroundImage = global::POExileDirection.Properties.Resources.Invite_24px;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZoomIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnZoomIn.Location = new System.Drawing.Point(764, 0);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(17, 16);
            this.btnZoomIn.TabIndex = 6;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.BackgroundImage = global::POExileDirection.Properties.Resources.CloseButton_45_45_48_24px;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(781, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(17, 16);
            this.button1.TabIndex = 7;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(727, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Atlas Map Information. ( Original image from Reddit u/Towerbruh )";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // btnLauncherLogin
            // 
            this.btnLauncherLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.btnLauncherLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLauncherLogin.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLauncherLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLauncherLogin.ForeColor = System.Drawing.Color.White;
            this.btnLauncherLogin.Location = new System.Drawing.Point(5, 23);
            this.btnLauncherLogin.Name = "btnLauncherLogin";
            this.btnLauncherLogin.Size = new System.Drawing.Size(132, 22);
            this.btnLauncherLogin.TabIndex = 6;
            this.btnLauncherLogin.Text = "Phanteon Inform.";
            this.btnLauncherLogin.UseVisualStyleBackColor = false;
            this.btnLauncherLogin.Click += new System.EventHandler(this.btnLauncherLogin_Click);
            // 
            // listViewPantheon
            // 
            this.listViewPantheon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPantheon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.God,
            this.Map,
            this.Tier});
            this.listViewPantheon.FullRowSelect = true;
            this.listViewPantheon.GridLines = true;
            this.listViewPantheon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPantheon.HideSelection = false;
            this.listViewPantheon.Location = new System.Drawing.Point(5, 52);
            this.listViewPantheon.MultiSelect = false;
            this.listViewPantheon.Name = "listViewPantheon";
            this.listViewPantheon.Size = new System.Drawing.Size(445, 516);
            this.listViewPantheon.TabIndex = 7;
            this.listViewPantheon.UseCompatibleStateImageBehavior = false;
            this.listViewPantheon.View = System.Windows.Forms.View.Details;
            this.listViewPantheon.Visible = false;
            this.listViewPantheon.DoubleClick += new System.EventHandler(this.listViewPantheon_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // God
            // 
            this.God.Width = 200;
            // 
            // Map
            // 
            this.Map.Width = 200;
            // 
            // Tier
            // 
            this.Tier.Width = 40;
            // 
            // labelPhanteon
            // 
            this.labelPhanteon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.labelPhanteon.ForeColor = System.Drawing.Color.Bisque;
            this.labelPhanteon.Location = new System.Drawing.Point(144, 23);
            this.labelPhanteon.Name = "labelPhanteon";
            this.labelPhanteon.Size = new System.Drawing.Size(306, 22);
            this.labelPhanteon.TabIndex = 8;
            this.labelPhanteon.Text = "Double click listed item to copy map name.";
            this.labelPhanteon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPhanteon.Visible = false;
            // 
            // ImageOverlayFormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 586);
            this.Controls.Add(this.labelPhanteon);
            this.Controls.Add(this.listViewPantheon);
            this.Controls.Add(this.btnLauncherLogin);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1901, 1154);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 258);
            this.Name = "ImageOverlayFormMap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ImageOverlayFormMap";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageOverlayFormMap_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageOverlayFormMap_FormClosed);
            this.Load += new System.EventHandler(this.ImageOverlayFormMap_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageOverlayFormMap_Paint);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLauncherLogin;
        private System.Windows.Forms.ListView listViewPantheon;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader God;
        private System.Windows.Forms.ColumnHeader Map;
        private System.Windows.Forms.ColumnHeader Tier;
        private System.Windows.Forms.Label labelPhanteon;
    }
}