namespace POExileDirection
{
    partial class ChromaticCalcForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listResult = new System.Windows.Forms.ListView();
            this.HideFirstCOL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Craft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AvgCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuccessPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AvgAttempt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CraftCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.textBLUE = new System.Windows.Forms.TextBox();
            this.textGREEN = new System.Windows.Forms.TextBox();
            this.textRED = new System.Windows.Forms.TextBox();
            this.textINT = new System.Windows.Forms.TextBox();
            this.textDEX = new System.Windows.Forms.TextBox();
            this.textSTR = new System.Windows.Forms.TextBox();
            this.textTotalSockets = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.labelMSG = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(473, 18);
            this.panelTop.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chromatic Calculator :: Fomular from Vorici Calulator (by siveran)";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label2_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label2_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::POExileDirection.Properties.Resources._16;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(454, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 16);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 651);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.listResult);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnCalculate);
            this.panel2.Controls.Add(this.textBLUE);
            this.panel2.Controls.Add(this.textGREEN);
            this.panel2.Controls.Add(this.textRED);
            this.panel2.Controls.Add(this.textINT);
            this.panel2.Controls.Add(this.textDEX);
            this.panel2.Controls.Add(this.textSTR);
            this.panel2.Controls.Add(this.textTotalSockets);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.labelMSG);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 651);
            this.panel2.TabIndex = 28;
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HideFirstCOL,
            this.Craft,
            this.AvgCost,
            this.SuccessPercent,
            this.AvgAttempt,
            this.CraftCost});
            this.listResult.HideSelection = false;
            this.listResult.Location = new System.Drawing.Point(4, 290);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(464, 349);
            this.listResult.TabIndex = 30;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            // 
            // HideFirstCOL
            // 
            this.HideFirstCOL.Text = "HideFirstCOL";
            this.HideFirstCOL.Width = 0;
            // 
            // Craft
            // 
            this.Craft.Text = "Craft";
            this.Craft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Craft.Width = 100;
            // 
            // AvgCost
            // 
            this.AvgCost.Text = "Avg. Cost";
            this.AvgCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvgCost.Width = 100;
            // 
            // SuccessPercent
            // 
            this.SuccessPercent.Text = "Success %";
            this.SuccessPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SuccessPercent.Width = 100;
            // 
            // AvgAttempt
            // 
            this.AvgAttempt.Text = "Avg. Attempt";
            this.AvgAttempt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvgAttempt.Width = 80;
            // 
            // CraftCost
            // 
            this.CraftCost.Text = "Craft Cost";
            this.CraftCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CraftCost.Width = 80;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::POExileDirection.Properties.Resources.socket_blue;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(276, 158);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 36);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::POExileDirection.Properties.Resources.socket_green;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(222, 158);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 36);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::POExileDirection.Properties.Resources.socket_red;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(168, 158);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculate.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.ForeColor = System.Drawing.Color.Gold;
            this.btnCalculate.Location = new System.Drawing.Point(334, 260);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(134, 23);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "▼ Calculate ▼";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // textBLUE
            // 
            this.textBLUE.BackColor = System.Drawing.SystemColors.Window;
            this.textBLUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBLUE.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBLUE.Location = new System.Drawing.Point(272, 198);
            this.textBLUE.MaxLength = 10;
            this.textBLUE.Name = "textBLUE";
            this.textBLUE.Size = new System.Drawing.Size(44, 21);
            this.textBLUE.TabIndex = 6;
            this.textBLUE.Text = "0";
            this.textBLUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBLUE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalSockets_KeyPress);
            // 
            // textGREEN
            // 
            this.textGREEN.BackColor = System.Drawing.SystemColors.Window;
            this.textGREEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textGREEN.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textGREEN.Location = new System.Drawing.Point(218, 198);
            this.textGREEN.MaxLength = 10;
            this.textGREEN.Name = "textGREEN";
            this.textGREEN.Size = new System.Drawing.Size(44, 21);
            this.textGREEN.TabIndex = 5;
            this.textGREEN.Text = "0";
            this.textGREEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textGREEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalSockets_KeyPress);
            // 
            // textRED
            // 
            this.textRED.BackColor = System.Drawing.SystemColors.Window;
            this.textRED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRED.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textRED.Location = new System.Drawing.Point(164, 198);
            this.textRED.MaxLength = 10;
            this.textRED.Name = "textRED";
            this.textRED.Size = new System.Drawing.Size(44, 21);
            this.textRED.TabIndex = 4;
            this.textRED.Text = "0";
            this.textRED.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textRED.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalSockets_KeyPress);
            // 
            // textINT
            // 
            this.textINT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textINT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textINT.Location = new System.Drawing.Point(273, 93);
            this.textINT.MaxLength = 10;
            this.textINT.Name = "textINT";
            this.textINT.Size = new System.Drawing.Size(44, 21);
            this.textINT.TabIndex = 3;
            this.textINT.Text = "0";
            this.textINT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textINT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalSockets_KeyPress);
            // 
            // textDEX
            // 
            this.textDEX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDEX.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textDEX.Location = new System.Drawing.Point(219, 93);
            this.textDEX.MaxLength = 10;
            this.textDEX.Name = "textDEX";
            this.textDEX.Size = new System.Drawing.Size(44, 21);
            this.textDEX.TabIndex = 2;
            this.textDEX.Text = "0";
            this.textDEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textDEX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalSockets_KeyPress);
            // 
            // textSTR
            // 
            this.textSTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSTR.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textSTR.Location = new System.Drawing.Point(165, 93);
            this.textSTR.MaxLength = 10;
            this.textSTR.Name = "textSTR";
            this.textSTR.Size = new System.Drawing.Size(44, 21);
            this.textSTR.TabIndex = 1;
            this.textSTR.Text = "0";
            this.textSTR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textSTR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalSockets_KeyPress);
            // 
            // textTotalSockets
            // 
            this.textTotalSockets.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textTotalSockets.Location = new System.Drawing.Point(165, 48);
            this.textTotalSockets.MaxLength = 10;
            this.textTotalSockets.Name = "textTotalSockets";
            this.textTotalSockets.Size = new System.Drawing.Size(44, 21);
            this.textTotalSockets.TabIndex = 0;
            this.textTotalSockets.Text = "0";
            this.textTotalSockets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTotalSockets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalSockets_KeyPress);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.RoyalBlue;
            this.label18.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label18.Location = new System.Drawing.Point(273, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 15);
            this.label18.TabIndex = 24;
            this.label18.Text = "INT";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Green;
            this.label17.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Location = new System.Drawing.Point(219, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 15);
            this.label17.TabIndex = 24;
            this.label17.Text = "DEX";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Red;
            this.label16.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(165, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 15);
            this.label16.TabIndex = 24;
            this.label16.Text = "STR";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label21.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label21.Location = new System.Drawing.Point(0, 228);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(473, 25);
            this.label21.TabIndex = 24;
            this.label21.Text = "Result";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label12.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(0, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(473, 25);
            this.label12.TabIndex = 24;
            this.label12.Text = "Want to Craft";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label19.Location = new System.Drawing.Point(70, 196);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 25);
            this.label19.TabIndex = 24;
            this.label19.Text = "Desired Colors";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(69, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 25);
            this.label13.TabIndex = 24;
            this.label13.Text = "Require Stats";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Location = new System.Drawing.Point(212, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 25);
            this.label20.TabIndex = 24;
            this.label20.Text = "Sockets";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMSG
            // 
            this.labelMSG.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMSG.ForeColor = System.Drawing.Color.Red;
            this.labelMSG.Location = new System.Drawing.Point(4, 260);
            this.labelMSG.Name = "labelMSG";
            this.labelMSG.Size = new System.Drawing.Size(324, 25);
            this.labelMSG.TabIndex = 24;
            this.labelMSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(69, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 25);
            this.label14.TabIndex = 24;
            this.label14.Text = "Total Sockets";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.label15.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(0, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(473, 25);
            this.label15.TabIndex = 24;
            this.label15.Text = "Your Item";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBox7.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox7.Location = new System.Drawing.Point(266, 179);
            this.textBox7.MaxLength = 10;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(44, 21);
            this.textBox7.TabIndex = 27;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Green;
            this.textBox6.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox6.Location = new System.Drawing.Point(207, 179);
            this.textBox6.MaxLength = 10;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(44, 21);
            this.textBox6.TabIndex = 27;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Red;
            this.textBox5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox5.Location = new System.Drawing.Point(157, 179);
            this.textBox5.MaxLength = 10;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(44, 21);
            this.textBox5.TabIndex = 27;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox4.Location = new System.Drawing.Point(266, 106);
            this.textBox4.MaxLength = 10;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(44, 21);
            this.textBox4.TabIndex = 26;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox3.Location = new System.Drawing.Point(207, 106);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 21);
            this.textBox3.TabIndex = 26;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox2.Location = new System.Drawing.Point(157, 106);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 21);
            this.textBox2.TabIndex = 26;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox1.Location = new System.Drawing.Point(157, 64);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 21);
            this.textBox1.TabIndex = 25;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.RoyalBlue;
            this.label8.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(266, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "B";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Green;
            this.label7.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(207, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "G";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(157, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "R";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(26, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Want to Make";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(26, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Require Stats";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(26, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Total Sockets";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(105, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Your Item";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // ChromaticCalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(473, 669);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(365, 562);
            this.Name = "ChromaticCalcForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChromaticCalcForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBLUE;
        private System.Windows.Forms.TextBox textGREEN;
        private System.Windows.Forms.TextBox textRED;
        private System.Windows.Forms.TextBox textINT;
        private System.Windows.Forms.TextBox textDEX;
        private System.Windows.Forms.TextBox textSTR;
        private System.Windows.Forms.TextBox textTotalSockets;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader HideFirstCOL;
        private System.Windows.Forms.ColumnHeader AvgCost;
        private System.Windows.Forms.ColumnHeader SuccessPercent;
        private System.Windows.Forms.ColumnHeader AvgAttempt;
        private System.Windows.Forms.ColumnHeader CraftCost;
        private System.Windows.Forms.ColumnHeader Craft;
        private System.Windows.Forms.Label labelMSG;
    }
}