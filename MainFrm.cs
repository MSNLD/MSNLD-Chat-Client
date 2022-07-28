using System.Diagnostics;

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
            InstallFrm installFrm = new InstallFrm();
            installFrm.StartPosition = FormStartPosition.CenterParent;
            installFrm.ShowDialog();
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JoinFrm joinFrm = new JoinFrm();
            joinFrm.StartPosition = FormStartPosition.CenterParent;
            joinFrm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsFrm settingsFrm = new SettingsFrm();
            //settingsFrm.MdiParent = this;
            settingsFrm.StartPosition = FormStartPosition.CenterParent;
            settingsFrm.ShowDialog();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) {
                this.ActiveMdiChild.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/MSNLD/msnld-client/blob/master/README.md") { UseShellExecute = true });
        }
    }
}