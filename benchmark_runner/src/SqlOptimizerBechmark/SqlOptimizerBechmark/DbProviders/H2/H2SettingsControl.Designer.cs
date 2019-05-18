namespace SqlOptimizerBechmark.DbProviders.H2
{
    partial class H2SettingsControl
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
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gpxOtherSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommandTimeout = new System.Windows.Forms.TextBox();
            this.pbxSqlServer = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpxOtherSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSqlServer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rbtnBasicSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtnUseConnectionString, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblUrl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUser, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUrl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtConnectionString, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnTestConnection, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.gpxOtherSettings, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.pbxSqlServer, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUser, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 513);
            this.tableLayoutPanel1.TabIndex = 3;
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
            this.rbtnUseConnectionString.Location = new System.Drawing.Point(3, 129);
            this.rbtnUseConnectionString.Name = "rbtnUseConnectionString";
            this.rbtnUseConnectionString.Size = new System.Drawing.Size(192, 17);
            this.rbtnUseConnectionString.TabIndex = 10;
            this.rbtnUseConnectionString.TabStop = true;
            this.rbtnUseConnectionString.Text = "Use the following connection string";
            this.rbtnUseConnectionString.UseVisualStyleBackColor = true;
            this.rbtnUseConnectionString.CheckedChanged += new System.EventHandler(this.rbtnUseConnectionString_CheckedChanged);
            // 
            // lblUrl
            // 
            this.lblUrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(34, 31);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(30, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL:";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(34, 56);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(33, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User:";
            // 
            // txtUrl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtUrl, 3);
            this.txtUrl.Location = new System.Drawing.Point(135, 28);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(197, 21);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            // 
            // txtConnectionString
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtConnectionString, 4);
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionString.Location = new System.Drawing.Point(34, 153);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(733, 44);
            this.txtConnectionString.TabIndex = 11;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            // 
            // btnTestConnection
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnTestConnection, 4);
            this.btnTestConnection.Location = new System.Drawing.Point(3, 223);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(145, 23);
            this.btnTestConnection.TabIndex = 12;
            this.btnTestConnection.Text = "Test connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(34, 81);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // gpxOtherSettings
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpxOtherSettings, 4);
            this.gpxOtherSettings.Controls.Add(this.tableLayoutPanel2);
            this.gpxOtherSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxOtherSettings.Location = new System.Drawing.Point(3, 273);
            this.gpxOtherSettings.Name = "gpxOtherSettings";
            this.gpxOtherSettings.Size = new System.Drawing.Size(332, 52);
            this.gpxOtherSettings.TabIndex = 14;
            this.gpxOtherSettings.TabStop = false;
            this.gpxOtherSettings.Text = "Other settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCommandTimeout, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(326, 32);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Command timeout [s]:";
            // 
            // txtCommandTimeout
            // 
            this.txtCommandTimeout.Location = new System.Drawing.Point(129, 6);
            this.txtCommandTimeout.Name = "txtCommandTimeout";
            this.txtCommandTimeout.Size = new System.Drawing.Size(76, 21);
            this.txtCommandTimeout.TabIndex = 1;
            this.txtCommandTimeout.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommandTimeout_Validating);
            // 
            // pbxSqlServer
            // 
            this.pbxSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxSqlServer.Image = global::SqlOptimizerBechmark.Properties.Resources.H2_Logo_Small;
            this.pbxSqlServer.Location = new System.Drawing.Point(639, 435);
            this.pbxSqlServer.Name = "pbxSqlServer";
            this.pbxSqlServer.Size = new System.Drawing.Size(128, 75);
            this.pbxSqlServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxSqlServer.TabIndex = 13;
            this.pbxSqlServer.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(341, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "The password is stored in the settings file as a plain text!";
            // 
            // txtUser
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtUser, 2);
            this.txtUser.Location = new System.Drawing.Point(135, 53);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(197, 21);
            this.txtUser.TabIndex = 2;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtPassword
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPassword, 2);
            this.txtPassword.Location = new System.Drawing.Point(135, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(197, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // H2SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "H2SettingsControl";
            this.Size = new System.Drawing.Size(770, 513);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gpxOtherSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSqlServer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rbtnBasicSettings;
        private System.Windows.Forms.RadioButton rbtnUseConnectionString;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox gpxOtherSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommandTimeout;
        private System.Windows.Forms.PictureBox pbxSqlServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
    }
}
