namespace msnld_client
{
    partial class AccountDlg
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GuestTab = new System.Windows.Forms.TabPage();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.InvalidWarning = new System.Windows.Forms.Label();
            this.NicknameCombo = new System.Windows.Forms.ComboBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.GuestTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GuestTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 181);
            this.tabControl1.TabIndex = 1;
            // 
            // GuestTab
            // 
            this.GuestTab.Controls.Add(this.CancelBtn);
            this.GuestTab.Controls.Add(this.label2);
            this.GuestTab.Controls.Add(this.InvalidWarning);
            this.GuestTab.Controls.Add(this.NicknameCombo);
            this.GuestTab.Controls.Add(this.ConnectBtn);
            this.GuestTab.Location = new System.Drawing.Point(4, 24);
            this.GuestTab.Name = "GuestTab";
            this.GuestTab.Padding = new System.Windows.Forms.Padding(3);
            this.GuestTab.Size = new System.Drawing.Size(421, 153);
            this.GuestTab.TabIndex = 0;
            this.GuestTab.Text = "Guest";
            this.GuestTab.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(254, 124);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Please enter a nickname";
            // 
            // InvalidWarning
            // 
            this.InvalidWarning.AutoSize = true;
            this.InvalidWarning.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InvalidWarning.Location = new System.Drawing.Point(6, 63);
            this.InvalidWarning.Name = "InvalidWarning";
            this.InvalidWarning.Size = new System.Drawing.Size(404, 46);
            this.InvalidWarning.TabIndex = 9;
            this.InvalidWarning.Text = "Nicknames cannot contain the following characters:\r\n! @ # $ & * ) ( + = ; \' : \" <" +
    " > , . ? / % (space)";
            // 
            // NicknameCombo
            // 
            this.NicknameCombo.AllowDrop = true;
            this.NicknameCombo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NicknameCombo.FormattingEnabled = true;
            this.NicknameCombo.Location = new System.Drawing.Point(6, 29);
            this.NicknameCombo.Name = "NicknameCombo";
            this.NicknameCombo.Size = new System.Drawing.Size(409, 31);
            this.NicknameCombo.TabIndex = 8;
            this.NicknameCombo.TextChanged += new System.EventHandler(this.NicknameCombo_TextChanged);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Enabled = false;
            this.ConnectBtn.Location = new System.Drawing.Point(335, 124);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // AccountDlg
            // 
            this.AcceptButton = this.ConnectBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(453, 205);
            this.Controls.Add(this.tabControl1);
            this.Name = "AccountDlg";
            this.Text = "Please enter a nickname";
            this.Load += new System.EventHandler(this.AccountDlg_Load);
            this.tabControl1.ResumeLayout(false);
            this.GuestTab.ResumeLayout(false);
            this.GuestTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private TabPage GuestTab;
        private Button CancelBtn;
        private Label label2;
        private Label InvalidWarning;
        private ComboBox NicknameCombo;
        private Button ConnectBtn;
    }
}