namespace POExileDirection
{
    partial class FlaskTimerCircleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.circularProgressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 40);
            this.panel1.TabIndex = 0;
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 100;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.circularProgressBar1.InnerColor = System.Drawing.Color.WhiteSmoke;
            this.circularProgressBar1.InnerMargin = 0;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.DarkGray;
            this.circularProgressBar1.OuterMargin = -10;
            this.circularProgressBar1.OuterWidth = 0;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circularProgressBar1.ProgressWidth = 6;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.circularProgressBar1.Size = new System.Drawing.Size(40, 40);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.Step = 5;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.Red;
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 0;
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.circularProgressBar1.Value = 75;
            this.circularProgressBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircularProgressBar1_MouseDown);
            this.circularProgressBar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CircularProgressBar1_MouseMove);
            this.circularProgressBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CircularProgressBar1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FlaskTimerCircleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(40, 40);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlaskTimerCircleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlaskTimerCircleForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FlaskTimerCircleForm_FormClosed);
            this.Load += new System.EventHandler(this.FlaskTimerCircleForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
    }
}