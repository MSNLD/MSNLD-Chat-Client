namespace msnld_client
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            //var x = new SocketListener("irc.irc7.com 6667");
            //System.Diagnostics.Debug.WriteLine($"Test {x.getPort()}");
            //x = null;

            //InstallFrm installFrm = new InstallFrm();
            //installFrm.MdiParent = this;
            //installFrm.StartPosition = FormStartPosition.CenterParent;
            //installFrm.Show();
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JoinFrm joinFrm = new JoinFrm();
            joinFrm.MdiParent = this;
            joinFrm.StartPosition = FormStartPosition.CenterParent;
            joinFrm.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsFrm settingsFrm = new SettingsFrm();
            //settingsFrm.MdiParent = this;
            settingsFrm.StartPosition = FormStartPosition.CenterParent;
            settingsFrm.ShowDialog();
        }
    }
}