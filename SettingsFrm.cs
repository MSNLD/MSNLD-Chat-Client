namespace msnld_client
{
    public partial class SettingsFrm : Form
    {
        public SettingsFrm()
        {
            InitializeComponent();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            var chatSettings = new AxChatSettings(this);
            this.Controls.Add(chatSettings);
            chatSettings.Dock = DockStyle.Fill;
        }
    }
}
