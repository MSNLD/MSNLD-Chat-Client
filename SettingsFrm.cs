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
    public partial class SettingsFrm : Form
    {
        private AxChatSettings _chatSettings;
        public SettingsFrm()
        {
            InitializeComponent();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            _chatSettings = new AxChatSettings();
            this.Controls.Add(_chatSettings);
            _chatSettings.Dock = DockStyle.Fill;
        }

        private void SettingsFrm_Shown(object sender, EventArgs e)
        {
            this.Width = _chatSettings.Width;
        }
    }
}
