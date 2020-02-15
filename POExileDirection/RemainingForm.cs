using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POExileDirection
{
    public partial class RemainingForm : Form
    {
        public RemainingForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void RemainingForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            // Fix Size 82,70
            this.Width = 82;
            this.Height = 70;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
