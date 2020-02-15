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
            this.panelTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.listResult = new System.Windows.Forms.ListView();
            this.HideFirstCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIRB = new System.Windows.Forms.Button();
            this.btnOLT = new System.Windows.Forms.Button();
            this.btnILB = new System.Windows.Forms.Button();
            this.btnORT = new System.Windows.Forms.Button();
            this.btnIRT = new System.Windows.Forms.Button();
            this.btnOLB = new System.Windows.Forms.Button();
            this.btnILT = new System.Windows.Forms.Button();
            this.btnORB = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelRegion = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(472, 18);
            this.panelTop.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(446, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search Atlas Region :: Click Region Button. (Highlight in Stash)";
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HideFirstCol,
            this.MapName});
            this.listResult.FullRowSelect = true;
            this.listResult.GridLines = true;
            this.listResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listResult.HideSelection = false;
            this.listResult.Location = new System.Drawing.Point(0, 266);
            this.listResult.MultiSelect = false;
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(472, 300);
            this.listResult.TabIndex = 4;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
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
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 224);
            this.panel1.TabIndex = 12;
            // 
            // btnIRB
            // 
            this.btnIRB.BackColor = System.Drawing.Color.Transparent;
            this.btnIRB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIRB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnIRB.FlatAppearance.BorderSize = 0;
            this.btnIRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIRB.ForeColor = System.Drawing.Color.Silver;
            this.btnIRB.Image = global::POExileDirection.Properties.Resources.Rest;
            this.btnIRB.Location = new System.Drawing.Point(262, 129);
            this.btnIRB.Name = "btnIRB";
            this.btnIRB.Size = new System.Drawing.Size(121, 22);
            this.btnIRB.TabIndex = 1;
            this.btnIRB.UseVisualStyleBackColor = false;
            this.btnIRB.Click += new System.EventHandler(this.btnIRB_Click);
            // 
            // btnOLT
            // 
            this.btnOLT.BackColor = System.Drawing.Color.Transparent;
            this.btnOLT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOLT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOLT.FlatAppearance.BorderSize = 0;
            this.btnOLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOLT.ForeColor = System.Drawing.Color.Silver;
            this.btnOLT.Image = global::POExileDirection.Properties.Resources.Hamlet;
            this.btnOLT.Location = new System.Drawing.Point(28, 25);
            this.btnOLT.Name = "btnOLT";
            this.btnOLT.Size = new System.Drawing.Size(121, 22);
            this.btnOLT.TabIndex = 1;
            this.btnOLT.UseVisualStyleBackColor = false;
            this.btnOLT.Click += new System.EventHandler(this.btnOLT_Click);
            // 
            // btnILB
            // 
            this.btnILB.BackColor = System.Drawing.Color.Transparent;
            this.btnILB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnILB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnILB.FlatAppearance.BorderSize = 0;
            this.btnILB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnILB.ForeColor = System.Drawing.Color.Silver;
            this.btnILB.Image = global::POExileDirection.Properties.Resources.Cairns;
            this.btnILB.Location = new System.Drawing.Point(88, 129);
            this.btnILB.Name = "btnILB";
            this.btnILB.Size = new System.Drawing.Size(121, 22);
            this.btnILB.TabIndex = 1;
            this.btnILB.UseVisualStyleBackColor = false;
            this.btnILB.Click += new System.EventHandler(this.btnILB_Click);
            // 
            // btnORT
            // 
            this.btnORT.BackColor = System.Drawing.Color.Transparent;
            this.btnORT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnORT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnORT.FlatAppearance.BorderSize = 0;
            this.btnORT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnORT.ForeColor = System.Drawing.Color.Silver;
            this.btnORT.Image = global::POExileDirection.Properties.Resources.Lex;
            this.btnORT.Location = new System.Drawing.Point(322, 25);
            this.btnORT.Name = "btnORT";
            this.btnORT.Size = new System.Drawing.Size(121, 22);
            this.btnORT.TabIndex = 1;
            this.btnORT.UseVisualStyleBackColor = false;
            this.btnORT.Click += new System.EventHandler(this.btnORT_Click);
            // 
            // btnIRT
            // 
            this.btnIRT.BackColor = System.Drawing.Color.Transparent;
            this.btnIRT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIRT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnIRT.FlatAppearance.BorderSize = 0;
            this.btnIRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIRT.ForeColor = System.Drawing.Color.Silver;
            this.btnIRT.Image = global::POExileDirection.Properties.Resources.Proxima;
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
            this.btnOLB.BackColor = System.Drawing.Color.Transparent;
            this.btnOLB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOLB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOLB.FlatAppearance.BorderSize = 0;
            this.btnOLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOLB.ForeColor = System.Drawing.Color.Silver;
            this.btnOLB.Image = global::POExileDirection.Properties.Resources.New;
            this.btnOLB.Location = new System.Drawing.Point(28, 174);
            this.btnOLB.Name = "btnOLB";
            this.btnOLB.Size = new System.Drawing.Size(121, 22);
            this.btnOLB.TabIndex = 1;
            this.btnOLB.UseVisualStyleBackColor = false;
            this.btnOLB.Click += new System.EventHandler(this.btnOLB_Click);
            // 
            // btnILT
            // 
            this.btnILT.BackColor = System.Drawing.Color.Transparent;
            this.btnILT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnILT.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnILT.FlatAppearance.BorderSize = 0;
            this.btnILT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnILT.ForeColor = System.Drawing.Color.Silver;
            this.btnILT.Image = global::POExileDirection.Properties.Resources.End;
            this.btnILT.Location = new System.Drawing.Point(88, 68);
            this.btnILT.Name = "btnILT";
            this.btnILT.Size = new System.Drawing.Size(121, 22);
            this.btnILT.TabIndex = 1;
            this.btnILT.UseVisualStyleBackColor = false;
            this.btnILT.Click += new System.EventHandler(this.btnILT_Click);
            // 
            // btnORB
            // 
            this.btnORB.BackColor = System.Drawing.Color.Transparent;
            this.btnORB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnORB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnORB.FlatAppearance.BorderSize = 0;
            this.btnORB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnORB.ForeColor = System.Drawing.Color.Silver;
            this.btnORB.Image = global::POExileDirection.Properties.Resources.Lira;
            this.btnORB.Location = new System.Drawing.Point(322, 174);
            this.btnORB.Name = "btnORB";
            this.btnORB.Size = new System.Drawing.Size(121, 22);
            this.btnORB.TabIndex = 1;
            this.btnORB.UseVisualStyleBackColor = false;
            this.btnORB.Click += new System.EventHandler(this.btnORB_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(452, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 17);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelRegion
            // 
            this.labelRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.labelRegion.ForeColor = System.Drawing.Color.Bisque;
            this.labelRegion.Location = new System.Drawing.Point(0, 244);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(472, 22);
            this.labelRegion.TabIndex = 13;
            this.labelRegion.Text = "Open Stash && Click Region";
            this.labelRegion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AwakenedRegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(472, 567);
            this.ControlBox = false;
            this.Controls.Add(this.labelRegion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AwakenedRegionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AwakenedRegionForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.AwakenedRegionForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOLT;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOLB;
        private System.Windows.Forms.Button btnORT;
        private System.Windows.Forms.Button btnORB;
        private System.Windows.Forms.Button btnILT;
        private System.Windows.Forms.Button btnIRT;
        private System.Windows.Forms.Button btnILB;
        private System.Windows.Forms.Button btnIRB;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader HideFirstCol;
        private System.Windows.Forms.ColumnHeader MapName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelRegion;
    }
}