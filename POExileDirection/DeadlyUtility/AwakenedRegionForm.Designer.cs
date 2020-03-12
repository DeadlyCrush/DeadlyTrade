namespace POExileDirection
{
    partial class AwakenedRegionForm
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
            this.xuiFlatTab1 = new XanderUI.XUIFlatTab();
            this.tabSearchRegionMap = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.listResult = new System.Windows.Forms.ListView();
            this.HideFirstCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelRegion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIRB = new System.Windows.Forms.Button();
            this.btnOLT = new System.Windows.Forms.Button();
            this.btnILB = new System.Windows.Forms.Button();
            this.btnORT = new System.Windows.Forms.Button();
            this.btnIRT = new System.Windows.Forms.Button();
            this.btnOLB = new System.Windows.Forms.Button();
            this.btnILT = new System.Windows.Forms.Button();
            this.btnORB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClose2nd = new System.Windows.Forms.Button();
            this.listViewPantheon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.God = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Map = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.xuiFlatTab1.SuspendLayout();
            this.tabSearchRegionMap.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xuiFlatTab1
            // 
            this.xuiFlatTab1.ActiveHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.xuiFlatTab1.ActiveTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(182)))), ((int)(((byte)(111)))));
            this.xuiFlatTab1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.xuiFlatTab1.Controls.Add(this.tabSearchRegionMap);
            this.xuiFlatTab1.Controls.Add(this.tabPage2);
            this.xuiFlatTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xuiFlatTab1.HeaderBackgroundColor = System.Drawing.Color.DarkGray;
            this.xuiFlatTab1.InActiveHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(16)))));
            this.xuiFlatTab1.InActiveTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(145)))), ((int)(((byte)(130)))));
            this.xuiFlatTab1.ItemSize = new System.Drawing.Size(240, 16);
            this.xuiFlatTab1.Location = new System.Drawing.Point(0, 0);
            this.xuiFlatTab1.Name = "xuiFlatTab1";
            this.xuiFlatTab1.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(16)))));
            this.xuiFlatTab1.SelectedIndex = 0;
            this.xuiFlatTab1.ShowBorder = true;
            this.xuiFlatTab1.Size = new System.Drawing.Size(471, 596);
            this.xuiFlatTab1.TabIndex = 14;
            this.xuiFlatTab1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xuiFlatTab1_MouseDown);
            this.xuiFlatTab1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xuiFlatTab1_MouseMove);
            this.xuiFlatTab1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xuiFlatTab1_MouseUp);
            // 
            // tabSearchRegionMap
            // 
            this.tabSearchRegionMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(16)))));
            this.tabSearchRegionMap.Controls.Add(this.btnClose);
            this.tabSearchRegionMap.Controls.Add(this.listResult);
            this.tabSearchRegionMap.Controls.Add(this.labelRegion);
            this.tabSearchRegionMap.Controls.Add(this.panel1);
            this.tabSearchRegionMap.Controls.Add(this.label1);
            this.tabSearchRegionMap.Location = new System.Drawing.Point(4, 20);
            this.tabSearchRegionMap.Name = "tabSearchRegionMap";
            this.tabSearchRegionMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchRegionMap.Size = new System.Drawing.Size(463, 572);
            this.tabSearchRegionMap.TabIndex = 0;
            this.tabSearchRegionMap.Text = "Atlas Region";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(440, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 17);
            this.btnClose.TabIndex = 18;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HideFirstCol,
            this.MapName});
            this.listResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.listResult.FullRowSelect = true;
            this.listResult.GridLines = true;
            this.listResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listResult.HideSelection = false;
            this.listResult.Location = new System.Drawing.Point(3, 271);
            this.listResult.MultiSelect = false;
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(457, 300);
            this.listResult.TabIndex = 17;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            this.listResult.Click += new System.EventHandler(this.listResult_DoubleClick);
            this.listResult.DoubleClick += new System.EventHandler(this.listResult_DoubleClick);
            // 
            // HideFirstCol
            // 
            this.HideFirstCol.Width = 0;
            // 
            // MapName
            // 
            this.MapName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MapName.Width = 450;
            // 
            // labelRegion
            // 
            this.labelRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.labelRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelRegion.ForeColor = System.Drawing.Color.Bisque;
            this.labelRegion.Location = new System.Drawing.Point(3, 249);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(457, 22);
            this.labelRegion.TabIndex = 16;
            this.labelRegion.Text = "Open Stash && Click Region";
            this.labelRegion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::POExileDirection.Properties.Resources.bg;
            this.panel1.Controls.Add(this.btnIRB);
            this.panel1.Controls.Add(this.btnOLT);
            this.panel1.Controls.Add(this.btnILB);
            this.panel1.Controls.Add(this.btnORT);
            this.panel1.Controls.Add(this.btnIRT);
            this.panel1.Controls.Add(this.btnOLB);
            this.panel1.Controls.Add(this.btnILT);
            this.panel1.Controls.Add(this.btnORB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 224);
            this.panel1.TabIndex = 15;
            // 
            // btnIRB
            // 
            this.btnIRB.BackColor = System.Drawing.Color.Black;
            this.btnIRB.BackgroundImage = global::POExileDirection.Properties.Resources.Rest;
            this.btnIRB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIRB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIRB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnIRB.FlatAppearance.BorderSize = 0;
            this.btnIRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIRB.ForeColor = System.Drawing.Color.Silver;
            this.btnIRB.Location = new System.Drawing.Point(262, 129);
            this.btnIRB.Name = "btnIRB";
            this.btnIRB.Size = new System.Drawing.Size(121, 22);
            this.btnIRB.TabIndex = 1;
            this.btnIRB.UseVisualStyleBackColor = false;
            this.btnIRB.Click += new System.EventHandler(this.btnIRB_Click);
            // 
            // btnOLT
            // 
            this.btnOLT.BackColor = System.Drawing.Color.Black;
            this.btnOLT.BackgroundImage = global::POExileDirection.Properties.Resources.Hamlet;
            this.btnOLT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOLT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOLT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOLT.FlatAppearance.BorderSize = 0;
            this.btnOLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOLT.ForeColor = System.Drawing.Color.Silver;
            this.btnOLT.Location = new System.Drawing.Point(28, 25);
            this.btnOLT.Name = "btnOLT";
            this.btnOLT.Size = new System.Drawing.Size(121, 22);
            this.btnOLT.TabIndex = 1;
            this.btnOLT.UseVisualStyleBackColor = false;
            this.btnOLT.Click += new System.EventHandler(this.btnOLT_Click);
            // 
            // btnILB
            // 
            this.btnILB.BackColor = System.Drawing.Color.Black;
            this.btnILB.BackgroundImage = global::POExileDirection.Properties.Resources.Cairns;
            this.btnILB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnILB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnILB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnILB.FlatAppearance.BorderSize = 0;
            this.btnILB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnILB.ForeColor = System.Drawing.Color.Silver;
            this.btnILB.Location = new System.Drawing.Point(88, 129);
            this.btnILB.Name = "btnILB";
            this.btnILB.Size = new System.Drawing.Size(121, 22);
            this.btnILB.TabIndex = 1;
            this.btnILB.UseVisualStyleBackColor = false;
            this.btnILB.Click += new System.EventHandler(this.btnILB_Click);
            // 
            // btnORT
            // 
            this.btnORT.BackColor = System.Drawing.Color.Black;
            this.btnORT.BackgroundImage = global::POExileDirection.Properties.Resources.Lex;
            this.btnORT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnORT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnORT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnORT.FlatAppearance.BorderSize = 0;
            this.btnORT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnORT.ForeColor = System.Drawing.Color.Silver;
            this.btnORT.Location = new System.Drawing.Point(322, 25);
            this.btnORT.Name = "btnORT";
            this.btnORT.Size = new System.Drawing.Size(121, 22);
            this.btnORT.TabIndex = 1;
            this.btnORT.UseVisualStyleBackColor = false;
            this.btnORT.Click += new System.EventHandler(this.btnORT_Click);
            // 
            // btnIRT
            // 
            this.btnIRT.BackColor = System.Drawing.Color.Black;
            this.btnIRT.BackgroundImage = global::POExileDirection.Properties.Resources.Proxima;
            this.btnIRT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIRT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIRT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnIRT.FlatAppearance.BorderSize = 0;
            this.btnIRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIRT.ForeColor = System.Drawing.Color.Silver;
            this.btnIRT.Location = new System.Drawing.Point(262, 68);
            this.btnIRT.Name = "btnIRT";
            this.btnIRT.Size = new System.Drawing.Size(121, 22);
            this.btnIRT.TabIndex = 1;
            this.btnIRT.Text = "\r\n";
            this.btnIRT.UseVisualStyleBackColor = false;
            this.btnIRT.Click += new System.EventHandler(this.btnIRT_Click);
            // 
            // btnOLB
            // 
            this.btnOLB.BackColor = System.Drawing.Color.Black;
            this.btnOLB.BackgroundImage = global::POExileDirection.Properties.Resources.New;
            this.btnOLB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOLB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOLB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOLB.FlatAppearance.BorderSize = 0;
            this.btnOLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOLB.ForeColor = System.Drawing.Color.Silver;
            this.btnOLB.Location = new System.Drawing.Point(28, 174);
            this.btnOLB.Name = "btnOLB";
            this.btnOLB.Size = new System.Drawing.Size(121, 22);
            this.btnOLB.TabIndex = 1;
            this.btnOLB.UseVisualStyleBackColor = false;
            this.btnOLB.Click += new System.EventHandler(this.btnOLB_Click);
            // 
            // btnILT
            // 
            this.btnILT.BackColor = System.Drawing.Color.Black;
            this.btnILT.BackgroundImage = global::POExileDirection.Properties.Resources.End;
            this.btnILT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnILT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnILT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnILT.FlatAppearance.BorderSize = 0;
            this.btnILT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnILT.ForeColor = System.Drawing.Color.Silver;
            this.btnILT.Location = new System.Drawing.Point(88, 68);
            this.btnILT.Name = "btnILT";
            this.btnILT.Size = new System.Drawing.Size(121, 22);
            this.btnILT.TabIndex = 1;
            this.btnILT.UseVisualStyleBackColor = false;
            this.btnILT.Click += new System.EventHandler(this.btnILT_Click);
            // 
            // btnORB
            // 
            this.btnORB.BackColor = System.Drawing.Color.Black;
            this.btnORB.BackgroundImage = global::POExileDirection.Properties.Resources.Lira;
            this.btnORB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnORB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnORB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnORB.FlatAppearance.BorderSize = 0;
            this.btnORB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnORB.ForeColor = System.Drawing.Color.Silver;
            this.btnORB.Location = new System.Drawing.Point(322, 174);
            this.btnORB.Name = "btnORB";
            this.btnORB.Size = new System.Drawing.Size(121, 22);
            this.btnORB.TabIndex = 1;
            this.btnORB.UseVisualStyleBackColor = false;
            this.btnORB.Click += new System.EventHandler(this.btnORB_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Bisque;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search Atlas Region :: Click Region Button. (Highlight in Stash)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(20)))), ((int)(((byte)(16)))));
            this.tabPage2.Controls.Add(this.btnClose2nd);
            this.tabPage2.Controls.Add(this.listViewPantheon);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 20);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(463, 572);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Phanteon";
            // 
            // btnClose2nd
            // 
            this.btnClose2nd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.btnClose2nd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose2nd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose2nd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose2nd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose2nd.FlatAppearance.BorderSize = 0;
            this.btnClose2nd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2nd.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose2nd.ForeColor = System.Drawing.Color.White;
            this.btnClose2nd.Location = new System.Drawing.Point(440, 5);
            this.btnClose2nd.Name = "btnClose2nd";
            this.btnClose2nd.Size = new System.Drawing.Size(17, 17);
            this.btnClose2nd.TabIndex = 19;
            this.btnClose2nd.TabStop = false;
            this.btnClose2nd.Text = "X";
            this.btnClose2nd.UseVisualStyleBackColor = false;
            this.btnClose2nd.Click += new System.EventHandler(this.btnClose2nd_Click);
            // 
            // listViewPantheon
            // 
            this.listViewPantheon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPantheon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.God,
            this.Map,
            this.Tier});
            this.listViewPantheon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPantheon.FullRowSelect = true;
            this.listViewPantheon.GridLines = true;
            this.listViewPantheon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPantheon.HideSelection = false;
            this.listViewPantheon.Location = new System.Drawing.Point(3, 25);
            this.listViewPantheon.MultiSelect = false;
            this.listViewPantheon.Name = "listViewPantheon";
            this.listViewPantheon.Size = new System.Drawing.Size(457, 544);
            this.listViewPantheon.TabIndex = 16;
            this.listViewPantheon.UseCompatibleStateImageBehavior = false;
            this.listViewPantheon.View = System.Windows.Forms.View.Details;
            this.listViewPantheon.Visible = false;
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
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(62)))), ((int)(((byte)(37)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.Bisque;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(457, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Phanteon Information : Double click listed item to copy map name.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AwakenedRegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(471, 596);
            this.ControlBox = false;
            this.Controls.Add(this.xuiFlatTab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AwakenedRegionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AwakenedRegionForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AwakenedRegionForm_FormClosed);
            this.Load += new System.EventHandler(this.AwakenedRegionForm_Load);
            this.xuiFlatTab1.ResumeLayout(false);
            this.tabSearchRegionMap.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private XanderUI.XUIFlatTab xuiFlatTab1;
        private System.Windows.Forms.TabPage tabSearchRegionMap;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader HideFirstCol;
        private System.Windows.Forms.ColumnHeader MapName;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIRB;
        private System.Windows.Forms.Button btnOLT;
        private System.Windows.Forms.Button btnILB;
        private System.Windows.Forms.Button btnORT;
        private System.Windows.Forms.Button btnIRT;
        private System.Windows.Forms.Button btnOLB;
        private System.Windows.Forms.Button btnILT;
        private System.Windows.Forms.Button btnORB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose2nd;
        private System.Windows.Forms.ListView listViewPantheon;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader God;
        private System.Windows.Forms.ColumnHeader Map;
        private System.Windows.Forms.ColumnHeader Tier;
        private System.Windows.Forms.Label label2;
    }
}