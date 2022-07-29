using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace msnld_client
{
    public partial class AccountDlg : Form
    {
        public RequestedSettings requestedSettings;
        private Regex invalidNicknameRegex = new Regex("[!@#\\\\\\$_\\*\\)\\(\\+=;':\"<>,.?/%\\s]");

        public AccountDlg(RequestedSettings requestedSettings)
        {
            InitializeComponent();
            this.requestedSettings = requestedSettings;
        }

        private void AccountDlg_Load(object sender, EventArgs e)
        {
            LoadNicknames();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            SaveNicknames();

            Close();

            requestedSettings.Nickname = NicknameCombo.Text;
            var ChannelFrm = new ChannelFrm(requestedSettings);
            ChannelFrm.MdiParent = Application.OpenForms[0];
            ChannelFrm.Show();
        }

        private void LoadNicknames()
        {
            var json = Properties.Settings.Default.GuestNicknames;
            List<string>? pastNicknames;
            try
            {
                pastNicknames = System.Text.Json.JsonSerializer.Deserialize<List<string>>(json);
            } catch(Exception e) {
                pastNicknames = new List<string>();
            }
            NicknameCombo.DataSource = pastNicknames;
            NicknameCombo.Text = pastNicknames.FirstOrDefault("");
        }

        private void SaveNicknames()
        {
            var nickname = NicknameCombo.Text;
            var pastNicknames = (List<string>)NicknameCombo.DataSource;
            pastNicknames.Remove(nickname);
            pastNicknames.Insert(0, nickname);
            if (pastNicknames.Count > 10)
            {
                pastNicknames.RemoveRange(10, pastNicknames.Count - 10);
            }
            var json = System.Text.Json.JsonSerializer.Serialize(pastNicknames);
            Properties.Settings.Default.GuestNicknames = json;
            Properties.Settings.Default.Save();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NicknameCombo_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NicknameCombo.Text))
            {
                ConnectBtn.Enabled = false;
                InvalidWarning.ForeColor = Color.Black;
            }
            else if (invalidNicknameRegex.IsMatch(NicknameCombo.Text))
            {
                ConnectBtn.Enabled = false;
                InvalidWarning.ForeColor = Color.Red;
            }
            else
            {
                ConnectBtn.Enabled = true;
                InvalidWarning.ForeColor = Color.Black;
            }
        }
    }
}
