namespace msnld_client
{
    partial class InstallFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clownHost = new System.Windows.Forms.PictureBox();
            this.installedLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ExitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clownHost)).BeginInit();
            this.SuspendLayout();
            // 
            // clownHost
            // 
            this.clownHost.Location = new System.Drawing.Point(396, 12);
            this.clownHost.Name = "clownHost";
            this.clownHost.Size = new System.Drawing.Size(64, 64);
            this.clownHost.TabIndex = 0;
            this.clownHost.TabStop = false;
            // 
            // installedLabel
            // 
            this.installedLabel.AutoSize = true;
            this.installedLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.installedLabel.ForeColor = System.Drawing.Color.Red;
            this.installedLabel.Location = new System.Drawing.Point(12, 12);
            this.installedLabel.Name = "installedLabel";
            this.installedLabel.Size = new System.Drawing.Size(302, 15);
            this.installedLabel.TabIndex = 1;
            this.installedLabel.Text = "The MSN Chat Control is not installed on your system.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "You must download and install the MSN Chat Control to be able\r\nto use this applic" +
    "ation.";
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Location = new System.Drawing.Point(385, 141);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(75, 23);
            this.DownloadBtn.TabIndex = 5;
            this.DownloadBtn.Text = "Download";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 82);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(448, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(304, 141);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // InstallFrm
            // 
            this.AcceptButton = this.DownloadBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitBtn;
            this.ClientSize = new System.Drawing.Size(472, 176);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DownloadBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.installedLabel);
            this.Controls.Add(this.clownHost);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallFrm";
            this.Text = "MSN Chat Control Installer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InstallFrm_FormClosed);
            this.Load += new System.EventHandler(this.InstallFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clownHost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox clownHost;
        private Label installedLabel;
        private Label label2;
        private Button DownloadBtn;
        private ProgressBar progressBar1;
        private Button ExitBtn;
    }
}