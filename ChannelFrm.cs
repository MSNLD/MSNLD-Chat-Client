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
    public partial class ChannelFrm : Form
    {
        private RequestedSettings requestedSettings;
        private SocketListener? socketListener;
        public ChannelFrm(RequestedSettings requestedSettings)
        {
            InitializeComponent();
            this.requestedSettings = requestedSettings;

            if (requestedSettings.InternalLookup)
            {
                socketListener = new SocketListener($"{requestedSettings.Server} {requestedSettings.Port}");
                requestedSettings.Server = "127.0.0.1";
                requestedSettings.Port = socketListener.getPort();
            }
            else
            {
                socketListener = null;
            }
            var mCC = new AxMSNChatFrame(requestedSettings);
            mCC.Dock = DockStyle.Fill;
            this.Controls.Add(mCC);
            // TODO: We should decode this (at minimum) in case user types The\bLobby or similar.
            this.Text = requestedSettings.RoomName;
        }

        private void ChannelFrm_Load(object sender, EventArgs e)
        {

        }

        private void ChannelFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (socketListener != null)
            {
                socketListener.dispose();
                socketListener = null;
            }
        }
    }
}
