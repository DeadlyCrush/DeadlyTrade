namespace POExileDirection
{
    partial class FlaskICONTimer
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAlpha = new System.Windows.Forms.Panel();
            this.xuiFlatProgressBar1 = new XanderUI.XUIFlatProgressBar();
            this.pictureFlask = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlask)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelAlpha);
            this.panel1.Controls.Add(this.xuiFlatProgressBar1);
            this.panel1.Controls.Add(this.pictureFlask);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 70);
            this.panel1.TabIndex = 0;
            // 
            // panelAlpha
            // 
            this.panelAlpha.Location = new System.Drawing.Point(0, 0);
            this.panelAlpha.Name = "panelAlpha";
            this.panelAlpha.Size = new System.Drawing.Size(30, 0);
            this.panelAlpha.TabIndex = 13;
            // 
            // xuiFlatProgressBar1
            // 
            this.xuiFlatProgressBar1.BarStyle = XanderUI.XUIFlatProgressBar.Style.Flat;
            this.xuiFlatProgressBar1.BorderColor = System.Drawing.Color.Transparent;
            this.xuiFlatProgressBar1.CompleteColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.xuiFlatProgressBar1.InocmpletedColor = System.Drawing.Color.Transparent;
            this.xuiFlatProgressBar1.Location = new System.Drawing.Point(0, 60);
            this.xuiFlatProgressBar1.MaxValue = 100;
            this.xuiFlatProgressBar1.Name = "xuiFlatProgressBar1";
            this.xuiFlatProgressBar1.ShowBorder = true;
            this.xuiFlatProgressBar1.Size = new System.Drawing.Size(30, 10);
            this.xuiFlatProgressBar1.TabIndex = 12;
            this.xuiFlatProgressBar1.Value = 100;
            // 
            // pictureFlask
            // 
            this.pictureFlask.BackColor = System.Drawing.Color.Black;
            this.pictureFlask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureFlask.Location = new System.Drawing.Point(0, 0);
            this.pictureFlask.Name = "pictureFlask";
            this.pictureFlask.Size = new System.Drawing.Size(30, 60);
            this.pictureFlask.TabIndex = 11;
            this.pictureFlask.TabStop = false;
            this.pictureFlask.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureFlask_MouseDown);
            this.pictureFlask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureFlask_MouseMove);
            this.pictureFlask.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureFlask_MouseUp);
            // 
            // FlaskICONTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(30, 70);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlaskICONTimer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlaskICONTimer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FlaskICONTimer_FormClosed);
            this.Load += new System.EventHandler(this.FlaskICONTimer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private XanderUI.XUIFlatProgressBar xuiFlatProgressBar1;
        private System.Windows.Forms.PictureBox pictureFlask;
        private System.Windows.Forms.Panel panelAlpha;
    }
}