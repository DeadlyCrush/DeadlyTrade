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
    public partial class SettingsOverhaul : Form
    {
        #region [[[[[ Global Variables ]]]]]
        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public SettingsOverhaul()
        {
            InitializeComponent();
        }

        private void SettingsOverhaul_Load(object sender, EventArgs e)
        {
            Init_Controls();
        }

        private void Init_Controls()
        {
            ;
        }

        private void Init_Tabs()
        {
            //FlatSettingTab.
        }
    }
}
