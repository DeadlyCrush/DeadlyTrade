namespace POExileDirection
{
    partial class GuideGridForm
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
            this.components = new System.ComponentModel.Container();
            this.textBoxTOP = new System.Windows.Forms.TextBox();
            this.textBoxLEFT = new System.Windows.Forms.TextBox();
            this.DeadlyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.checkQuadTab = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTOP
            // 
            this.textBoxTOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.textBoxTOP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTOP.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxTOP.ForeColor = System.Drawing.Color.White;
            this.textBoxTOP.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxTOP.Location = new System.Drawing.Point(147, 9);
            this.textBoxTOP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTOP.MaxLength = 2;
            this.textBoxTOP.Name = "textBoxTOP";
            this.textBoxTOP.Size = new System.Drawing.Size(14, 14);
            this.textBoxTOP.TabIndex = 1;
            this.textBoxTOP.Text = "1";
            this.textBoxTOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTOP.Enter += new System.EventHandler(this.TextBoxTOP_Enter);
            this.textBoxTOP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxTOP_KeyPress);
            this.textBoxTOP.Leave += new System.EventHandler(this.TextBoxTOP_Leave);
            // 
            // textBoxLEFT
            // 
            this.textBoxLEFT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.textBoxLEFT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLEFT.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxLEFT.ForeColor = System.Drawing.Color.White;
            this.textBoxLEFT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxLEFT.Location = new System.Drawing.Point(95, 9);
            this.textBoxLEFT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxLEFT.MaxLength = 2;
            this.textBoxLEFT.Name = "textBoxLEFT";
            this.textBoxLEFT.Size = new System.Drawing.Size(14, 14);
            this.textBoxLEFT.TabIndex = 0;
            this.textBoxLEFT.Text = "1";
            this.textBoxLEFT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLEFT.Enter += new System.EventHandler(this.TextBoxLEFT_Enter);
            this.textBoxLEFT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxLEFT_KeyPress);
            this.textBoxLEFT.Leave += new System.EventHandler(this.TextBoxLEFT_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel1.BackgroundImage = global::POExileDirection.Properties.Resources.top_bar_bg_symbol;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.checkQuadTab);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 27);
            this.panel1.TabIndex = 8;
            this.panel1.Enter += new System.EventHandler(this.panel1_Enter);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(145, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(93, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(116, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Top";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quad?";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Left";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.btnSearch.BackgroundImage = global::POExileDirection.Properties.Resources._2;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(172, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(20, 20);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TabStop = false;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // checkQuadTab
            // 
            this.checkQuadTab.AutoSize = true;
            this.checkQuadTab.Location = new System.Drawing.Point(49, 9);
            this.checkQuadTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkQuadTab.Name = "checkQuadTab";
            this.checkQuadTab.Size = new System.Drawing.Size(15, 14);
            this.checkQuadTab.TabIndex = 4;
            this.checkQuadTab.TabStop = false;
            this.checkQuadTab.UseVisualStyleBackColor = true;
            this.checkQuadTab.CheckedChanged += new System.EventHandler(this.CheckQuadTab_CheckedChanged);
            this.checkQuadTab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkQuadTab_MouseClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(24)))), ((int)(((byte)(11)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(194, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // GuideGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(219, 27);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxTOP);
            this.Controls.Add(this.textBoxLEFT);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(219, 27);
            this.Name = "GuideGridForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuideGridForm_FormClosing);
            this.Load += new System.EventHandler(this.GuideGridForm_Load);
            this.Enter += new System.EventHandler(this.GuideGridForm_Enter);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkQuadTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxTOP;
        private System.Windows.Forms.TextBox textBoxLEFT;
        private System.Windows.Forms.ToolTip DeadlyToolTip;
        private System.Windows.Forms.Label label3;
    }
}