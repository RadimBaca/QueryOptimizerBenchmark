namespace SqlOptimizerBechmark.DbProviders.SQLite
{
    partial class SQLiteSettingsControl
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
            this.gpxOtherSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommandTimeout = new System.Windows.Forms.TextBox();
            this.rbtnBasicSettings = new System.Windows.Forms.RadioButton();
            this.rbtnUseConnectionString = new System.Windows.Forms.RadioButton();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.pbxSqlServer = new System.Windows.Forms.PictureBox();
            this.btnSelectFileName = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cbxInMemory = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpxOtherSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSqlServer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Controls.Add(this.gpxOtherSettings, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.rbtnBasicSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtnUseConnectionString, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblFileName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFileName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtConnectionString, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.pbxSqlServer, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectFileName, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnTestConnection, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbxInMemory, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 432);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gpxOtherSettings
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpxOtherSettings, 4);
            this.gpxOtherSettings.Controls.Add(this.tableLayoutPanel2);
            this.gpxOtherSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxOtherSettings.Location = new System.Drawing.Point(3, 243);
            this.gpxOtherSettings.Name = "gpxOtherSettings";
            this.gpxOtherSettings.Size = new System.Drawing.Size(327, 52);
            this.gpxOtherSettings.TabIndex = 16;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(321, 32);
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
            this.rbtnUseConnectionString.Location = new System.Drawing.Point(3, 99);
            this.rbtnUseConnectionString.Name = "rbtnUseConnectionString";
            this.rbtnUseConnectionString.Size = new System.Drawing.Size(192, 17);
            this.rbtnUseConnectionString.TabIndex = 10;
            this.rbtnUseConnectionString.TabStop = true;
            this.rbtnUseConnectionString.Text = "Use the following connection string";
            this.rbtnUseConnectionString.UseVisualStyleBackColor = true;
            this.rbtnUseConnectionString.CheckedChanged += new System.EventHandler(this.rbtnUseConnectionString_CheckedChanged);
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(34, 31);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(56, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File name:";
            // 
            // txtFileName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtFileName, 3);
            this.txtFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileName.Location = new System.Drawing.Point(106, 28);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(551, 21);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // txtConnectionString
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtConnectionString, 5);
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionString.Location = new System.Drawing.Point(34, 123);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(662, 44);
            this.txtConnectionString.TabIndex = 11;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            // 
            // pbxSqlServer
            // 
            this.pbxSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.pbxSqlServer, 2);
            this.pbxSqlServer.Image = global::SqlOptimizerBechmark.Properties.Resources.SQLite;
            this.pbxSqlServer.Location = new System.Drawing.Point(534, 333);
            this.pbxSqlServer.Name = "pbxSqlServer";
            this.tableLayoutPanel1.SetRowSpan(this.pbxSqlServer, 4);
            this.pbxSqlServer.Size = new System.Drawing.Size(162, 76);
            this.pbxSqlServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxSqlServer.TabIndex = 13;
            this.pbxSqlServer.TabStop = false;
            // 
            // btnSelectFileName
            // 
            this.btnSelectFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectFileName.Location = new System.Drawing.Point(660, 27);
            this.btnSelectFileName.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnSelectFileName.Name = "btnSelectFileName";
            this.btnSelectFileName.Size = new System.Drawing.Size(39, 23);
            this.btnSelectFileName.TabIndex = 2;
            this.btnSelectFileName.Text = "...";
            this.btnSelectFileName.UseVisualStyleBackColor = true;
            this.btnSelectFileName.Click += new System.EventHandler(this.btnSelectFileName_Click);
            // 
            // btnTestConnection
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnTestConnection, 4);
            this.btnTestConnection.Location = new System.Drawing.Point(3, 193);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(145, 24);
            this.btnTestConnection.TabIndex = 12;
            this.btnTestConnection.Text = "Test connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cbxInMemory
            // 
            this.cbxInMemory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxInMemory.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxInMemory, 3);
            this.cbxInMemory.Location = new System.Drawing.Point(34, 64);
            this.cbxInMemory.Name = "cbxInMemory";
            this.cbxInMemory.Size = new System.Drawing.Size(126, 17);
            this.cbxInMemory.TabIndex = 3;
            this.cbxInMemory.Text = "In-memory database";
            this.cbxInMemory.UseVisualStyleBackColor = true;
            this.cbxInMemory.CheckedChanged += new System.EventHandler(this.cbxInMemory_CheckedChanged);
            // 
            // SQLiteSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SQLiteSettingsControl";
            this.Size = new System.Drawing.Size(699, 432);
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
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.PictureBox pbxSqlServer;
        private System.Windows.Forms.CheckBox cbxInMemory;
        private System.Windows.Forms.Button btnSelectFileName;
        private System.Windows.Forms.GroupBox gpxOtherSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommandTimeout;
    }
}
