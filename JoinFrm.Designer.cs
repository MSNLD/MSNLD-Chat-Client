namespace msnld_client
{
    partial class JoinFrm
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.JoinChannelName = new System.Windows.Forms.TextBox();
            this.SkipLookup = new System.Windows.Forms.CheckBox();
            this.SpecifyServer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Channel name";
            // 
            // JoinChannelName
            // 
            this.JoinChannelName.Location = new System.Drawing.Point(12, 27);
            this.JoinChannelName.Name = "JoinChannelName";
            this.JoinChannelName.Size = new System.Drawing.Size(534, 23);
            this.JoinChannelName.TabIndex = 1;
            this.JoinChannelName.Text = "The Lobby";
            // 
            // SkipLookup
            // 
            this.SkipLookup.AutoSize = true;
            this.SkipLookup.Checked = true;
            this.SkipLookup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SkipLookup.Location = new System.Drawing.Point(12, 86);
            this.SkipLookup.Name = "SkipLookup";
            this.SkipLookup.Size = new System.Drawing.Size(122, 19);
            this.SkipLookup.TabIndex = 2;
            this.SkipLookup.Text = "Skip lookup server";
            this.SkipLookup.UseVisualStyleBackColor = true;
            // 
            // SpecifyServer
            // 
            this.SpecifyServer.AutoSize = true;
            this.SpecifyServer.Enabled = false;
            this.SpecifyServer.Location = new System.Drawing.Point(12, 111);
            this.SpecifyServer.Name = "SpecifyServer";
            this.SpecifyServer.Size = new System.Drawing.Size(98, 19);
            this.SpecifyServer.TabIndex = 3;
            this.SpecifyServer.Text = "Specify server";
            this.SpecifyServer.UseVisualStyleBackColor = true;
            this.SpecifyServer.CheckedChanged += new System.EventHandler(this.SpecifyServer_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server hostname";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 169);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(534, 23);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "irc.irc7.com:6667";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(471, 107);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 6;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // JoinFrm
            // 
            this.ClientSize = new System.Drawing.Size(558, 137);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SpecifyServer);
            this.Controls.Add(this.SkipLookup);
            this.Controls.Add(this.JoinChannelName);
            this.Controls.Add(this.label2);
            this.Name = "JoinFrm";
            this.Load += new System.EventHandler(this.JoinFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private TextBox JoinChannelName;
        private CheckBox SkipLookup;
        private CheckBox SpecifyServer;
        private Label label3;
        private TextBox textBox4;
        private Button ConnectBtn;
    }
}