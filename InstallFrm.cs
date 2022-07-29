using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace msnld_client
{
    public partial class InstallFrm : Form
    {
        public InstallFrm()
        {
            InitializeComponent();
            defaultMessage = installedLabel.Text;
        }

        private string defaultMessage;
        private Boolean isMSNChatInstalled()
        {
            var result = false;
            var clown = new AxMSNChatTest();
            try
            {
                clownHost.Controls.Clear();
                clownHost.Controls.Add(clown);
                result = true;
            }
            catch (System.Runtime.InteropServices.COMException exception)
            {
                if (exception.ErrorCode.ToString("x8") == "80040154") // REGDB_E_CLASSNOTREGISTERED
                {
                    clownHost.Controls.Remove(clown);
                }
            }
            return result;
        }

        private void InstallFrm_Load(object sender, EventArgs e)
        {
            showMSNChatInstalled();
            DownloadBtn.Focus();
        }

        private void showMSNChatInstalled()
        {
            if (isMSNChatInstalled())
            {
                installedLabel.Text = "The MSN Chat Control is installed on your system.";
                installedLabel.ForeColor = Color.Green;
                ExitBtn.Visible = false;

                // Avoid exiting when dialog closed
                this.FormClosed -= InstallFrm_FormClosed!;
                // Re-write Download Button
                DownloadBtn.Text = "Continue";
                DownloadBtn.Click -= DownloadBtn_Click!;
                DownloadBtn.Click += (sender, e) => this.Close();
                DownloadBtn.Enabled = true;
            }
            else
            {
                installedLabel.Text = defaultMessage;
                installedLabel.ForeColor = Color.Red;
                DownloadBtn.Enabled = true;
            }
        }

        private async void DownloadBtn_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 20;
            progressBar1.Visible = true;
            DownloadBtn.Enabled = false;
            var remoteFile = "https://web.archive.org/web/20150622204452if_/http://fdl.msn.com/public/chat/msnchat45.cab";
            var tmpFilename = Path.GetTempFileName();
            var targetDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\\Downloaded Program Files";
            var filename = "MsnChat45.ocx";
            if (!await downloadFile(remoteFile, tmpFilename))
            {
                MessageBox.Show("Failed to download the MSN Chat Control.");
            }
            else if (!verifyFileIsChatControl(tmpFilename))
            {
                progressBar1.Value = 60;
                MessageBox.Show("Downloaded file failed integrity check.");
            }
            else if (!decompressFile(tmpFilename, targetDir))
            {
                progressBar1.Value = 80;
                MessageBox.Show("Unable to extract the downloaded file's contents.");
            }
            else if (!registerFile(targetDir, filename))
            {
                progressBar1.Value = 90;
                MessageBox.Show("Unable to register the MSN Chat Control.");
            }
            else
            {
                progressBar1.Value = 100;
                MessageBox.Show("Installed MSN Chat Control");
            }
            progressBar1.Visible = false;
            showMSNChatInstalled();
        }

        private async Task<bool> downloadFile(string remoteFile, string tmpFilename)
        {
            Boolean result = false;
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(remoteFile);
                result = writeResponseToFile(response, tmpFilename);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return result;
        }

        private bool writeResponseToFile(HttpResponseMessage response, string tmpFilename)
        {
            Boolean result = false;
            try
            {
                using (var fs = new FileStream(tmpFilename, FileMode.Open, FileAccess.Write))
                {
                    response.Content.CopyToAsync(fs);
                }
                result = true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return result;
        }

        private bool verifyFileIsChatControl(string tmpFilename)
        {
            string knownHash = "D8DC01B430CAD70E0D29919EC70B5A0F641D361384FEF974634AC9C011F9D34684E51C2FBE47DC9142526F63E9EF4C4CB5D623CD674BF613444437230367FC55";
            Boolean result = false;
            string fileHash;
            try
            {
                using (var hasher = System.Security.Cryptography.HashAlgorithm.Create("SHA512"))
                {
                    using (var stream = System.IO.File.OpenRead(tmpFilename))
                    {
                        var hash = hasher!.ComputeHash(stream);
                        fileHash = BitConverter.ToString(hash).Replace("-", "");
                    }
                }
                if (fileHash == knownHash)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return result;
        }

        private bool decompressFile(string tmpFilename, string targetDir)
        {
            Boolean result = false;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("expand.exe", $"{tmpFilename} -F:* \"{targetDir}\"");
                startInfo.Verb = "runas";
                var process = new Process();
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                System.Diagnostics.Debug.WriteLine(process.StandardOutput.ReadToEnd());
                result = process.ExitCode == 0;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return result;
        }

        private bool registerFile(string targetDir,string filename)
        {
            Boolean result = false;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("regsvr32.exe", $"/s \"{targetDir}\\{filename}\"");
                startInfo.Verb = "runas";
                var process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                result = process.ExitCode == 0;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return result;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InstallFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing")
            {
                Application.Exit();
            }
        }
    }
}