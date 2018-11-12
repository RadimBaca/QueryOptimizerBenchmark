namespace SqlOptimizerBechmark.DbProviders.PostgreSql
{
    partial class PostgreSqlSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnBasicSettings = new System.Windows.Forms.RadioButton();
            this.rbtnUseConnectionString = new System.Windows.Forms.RadioButton();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.pbxSqlServer = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommandTimeout = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSqlServer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.rbtnBasicSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtnUseConnectionString, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblHost, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDatabase, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHost, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDatabase, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtConnectionString, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnTestConnection, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.pbxSqlServer, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblUserName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUserName, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtCommandTimeout, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 519);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // rbtnBasicSettings
            // 
            this.rbtnBasicSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBasicSettings.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.rbtnBasicSettings, 5);
            this.rbtnBasicSettings.Location = new System.Drawing.Point(3, 4);
            this.rbtnBasicSettings.Name = "rbtnBasicSettings";
            this.rbtnBasicSettings.Size = new System.Drawing.Size(90, 17);
            this.rbtnBasicSettings.TabIndex = 0;
            this.rbtnBasicSettings.TabStop = true;
            this.rbtnBasicSettings.Text = "Basic settings";
            this.rbtnBasicSettings.UseVisualStyleBackColor = true;
            this.rbtnBasicSettings.CheckedChanged += new System.EventHandler(this.rbtnBasicSettings_CheckedChanged);
            // 
            // rbtnUseConnectionString
            // 
            this.rbtnUseConnectionString.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnUseConnectionString.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.rbtnUseConnectionString, 5);
            this.rbtnUseConnectionString.Location = new System.Drawing.Point(3, 179);
            this.rbtnUseConnectionString.Name = "rbtnUseConnectionString";
            this.rbtnUseConnectionString.Size = new System.Drawing.Size(192, 17);
            this.rbtnUseConnectionString.TabIndex = 10;
            this.rbtnUseConnectionString.TabStop = true;
            this.rbtnUseConnectionString.Text = "Use the following connection string";
            this.rbtnUseConnectionString.UseVisualStyleBackColor = true;
            this.rbtnUseConnectionString.CheckedChanged += new System.EventHandler(this.rbtnUseConnectionString_CheckedChanged);
            // 
            // lblHost
            // 
            this.lblHost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(34, 31);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(33, 13);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Host:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(34, 56);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(57, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            // 
            // txtHost
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtHost, 3);
            this.txtHost.Location = new System.Drawing.Point(135, 28);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(197, 21);
            this.txtHost.TabIndex = 1;
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // txtDatabase
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDatabase, 3);
            this.txtDatabase.Location = new System.Drawing.Point(135, 53);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(197, 21);
            this.txtDatabase.TabIndex = 2;
            this.txtDatabase.TextChanged += new System.EventHandler(this.txtDatabase_TextChanged);
            // 
            // txtConnectionString
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtConnectionString, 4);
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionString.Location = new System.Drawing.Point(34, 203);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(741, 44);
            this.txtConnectionString.TabIndex = 11;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            // 
            // btnTestConnection
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnTestConnection, 4);
            this.btnTestConnection.Location = new System.Drawing.Point(3, 273);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(145, 23);
            this.btnTestConnection.TabIndex = 12;
            this.btnTestConnection.Text = "Test connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // pbxSqlServer
            // 
            this.pbxSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxSqlServer.Image = global::SqlOptimizerBechmark.Properties.Resources.PostgreSqlSmall;
            this.pbxSqlServer.Location = new System.Drawing.Point(655, 383);
            this.pbxSqlServer.Name = "pbxSqlServer";
            this.tableLayoutPanel1.SetRowSpan(this.pbxSqlServer, 3);
            this.pbxSqlServer.Size = new System.Drawing.Size(120, 113);
            this.pbxSqlServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxSqlServer.TabIndex = 13;
            this.pbxSqlServer.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(34, 81);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(33, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User:";
            // 
            // txtUserName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtUserName, 3);
            this.txtUserName.Location = new System.Drawing.Point(135, 78);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(197, 21);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(34, 106);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPassword, 3);
            this.txtPassword.Location = new System.Drawing.Point(135, 103);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(197, 21);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 3);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(135, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "The password is stored in the settings file as a plain text!";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timeout [s]:";
            // 
            // txtCommandTimeout
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtCommandTimeout, 2);
            this.txtCommandTimeout.Location = new System.Drawing.Point(135, 153);
            this.txtCommandTimeout.Name = "txtCommandTimeout";
            this.txtCommandTimeout.Size = new System.Drawing.Size(76, 21);
            this.txtCommandTimeout.TabIndex = 6;
            this.txtCommandTimeout.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommandTimeout_Validating);
            // 
            // PostgreSqlSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PostgreSqlSettingsControl";
            this.Size = new System.Drawing.Size(778, 519);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSqlServer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rbtnBasicSettings;
        private System.Windows.Forms.RadioButton rbtnUseConnectionString;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.PictureBox pbxSqlServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommandTimeout;
    }
}
