using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadlyTradeManager
{
    public partial class DeadlyCoreMgmt : Form
    {
        public DeadlyCoreMgmt()
        {
            InitializeComponent();
            SetVisibleCore(false);
        }

        protected override void SetVisibleCore(bool bIsVisible)
        {
            base.SetVisibleCore(bIsVisible);
        }

        private void MainManager_Load(object sender, EventArgs e)
        {
            SetVisibleCore(false);
            Visible = false;
        }
    }
}
