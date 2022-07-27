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
            //if (!SpecifyServer.Checked)
            //{
                var server = "irc.irc7.com";
                var port = 6667;
            //}
            if (SkipLookup.Checked)
            {
                var sl = new SocketListener($"{server} {port}");
                server = "127.0.0.1";
                port = sl.getPort();
            }
            var form = new ChannelFrm();
            var activeX = new AxMSNChatFrame(server, port, JoinChannelName.Text);
            form.attachOCX(activeX);
            form.MdiParent = Application.OpenForms[0];
            form.Text = JoinChannelName.Text;
            form.Show();
            Close();
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
