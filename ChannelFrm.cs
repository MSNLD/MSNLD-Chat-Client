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
        public ChannelFrm()
        {
            InitializeComponent();
        }

        private void ChannelFrm_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        public void attachOCX(AxMSNChat axMSNChat)
        {
            axMSNChat.Dock = DockStyle.Fill;
            this.Controls.Add(axMSNChat);
        }
    }
}
