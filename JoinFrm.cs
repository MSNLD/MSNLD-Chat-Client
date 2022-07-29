using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace msnld_client
{
    public partial class JoinFrm : Form
    {
        public JoinFrm()
        {
            InitializeComponent();
        }

        private void JoinFrm_Load(object sender, EventArgs e)
        {

        }

        private void SpecifyServer_CheckedChanged(object sender, EventArgs e)
        {
            if (SpecifyServer.Checked)
            {
                this.Height = 240;
            }
            else
            {
                this.Height = 175;
            }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            var requestedSettings = new RequestedSettings();
            if (!SpecifyServer.Checked)
            {
                //RequestedSettings.Server = "irc.irc7.com";
                //RequestedSettings.Port = 6667;
            }
            if (SkipLookup.Checked)
            {
                requestedSettings.InternalLookup = true;
            }
            requestedSettings.RoomName = JoinChannelName.Text;

            Close();
            var accountDlg = new AccountDlg(requestedSettings);
            accountDlg.StartPosition = FormStartPosition.CenterParent;
            accountDlg.ShowDialog();
        }

        private void JoinChannelName_TextChanged(object sender, EventArgs e)
        {
            if (JoinChannelName.Text == "")
            {
                ConnectBtn.Enabled = false;
            }
            else
            {
                ConnectBtn.Enabled = true;
            }
        }
    }
}
