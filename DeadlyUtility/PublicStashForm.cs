using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using PathOfExile;
using PathOfExile.Model;*/


namespace POExileDirection
{
    public partial class PublicStashForm : Form
    {
        public PublicStashForm()
        {
            InitializeComponent();

            Get_Public_StashName_ByProcessID();
        }

        private void Get_Public_StashName_ByProcessID()
        {
            /*PublicStash publicStash = PublicStashAPI.GetAsync("6961c7d3e27073433286911b34175f7d").Result;
            foreach (Stash stash in publicStash.stashes)
            {
                cbPublicStash.Items.Add(stash.stash);
            }*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
