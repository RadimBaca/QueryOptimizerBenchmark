namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    partial class ConfigurationDetail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationDetail));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gpxConfiguration = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblCleanUpScript = new System.Windows.Forms.LinkLabel();
            this.lblInitScript = new System.Windows.Forms.LinkLabel();
            this.lblTestGroup = new System.Windows.Forms.LinkLabel();
            this.warningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.gpxConfiguration.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gpxConfiguration, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCleanUpScript, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInitScript, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTestGroup, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(821, 564);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gpxConfiguration
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpxConfiguration, 3);
            this.gpxConfiguration.Controls.Add(this.tableLayoutPanel2);
            this.gpxConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxConfiguration.Location = new System.Drawing.Point(3, 3);
            this.gpxConfiguration.Name = "gpxConfiguration";
            this.gpxConfiguration.Size = new System.Drawing.Size(815, 533);
            this.gpxConfiguration.TabIndex = 0;
            this.gpxConfiguration.TabStop = false;
            this.gpxConfiguration.Text = "Configuration";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDescription, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNumber, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(809, 513);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // txtName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtName, 2);
            this.txtName.Location = new System.Drawing.Point(77, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 21);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDescription
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtDescription, 2);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(77, 53);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.tableLayoutPanel2.SetRowSpan(this.txtDescription, 2);
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(729, 457);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number:";
            // 
            // txtNumber
            // 
            this.txtNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumber.Location = new System.Drawing.Point(77, 3);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(114, 21);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // lblCleanUpScript
            // 
            this.lblCleanUpScript.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCleanUpScript.AutoSize = true;
            this.lblCleanUpScript.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblCleanUpScript.Location = new System.Drawing.Point(169, 545);
            this.lblCleanUpScript.Name = "lblCleanUpScript";
            this.lblCleanUpScript.Size = new System.Drawing.Size(94, 13);
            this.lblCleanUpScript.TabIndex = 4;
            this.lblCleanUpScript.TabStop = true;
            this.lblCleanUpScript.Text = "Clean-up script ...";
            this.lblCleanUpScript.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCleanUpScript_LinkClicked);
            // 
            // lblInitScript
            // 
            this.lblInitScript.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInitScript.AutoSize = true;
            this.lblInitScript.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblInitScript.Location = new System.Drawing.Point(90, 545);
            this.lblInitScript.Name = "lblInitScript";
            this.lblInitScript.Size = new System.Drawing.Size(67, 13);
            this.lblInitScript.TabIndex = 3;
            this.lblInitScript.TabStop = true;
            this.lblInitScript.Text = "Init script ...";
            this.lblInitScript.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInitScript_LinkClicked);
            // 
            // lblTestGroup
            // 
            this.lblTestGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTestGroup.AutoSize = true;
            this.lblTestGroup.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblTestGroup.Location = new System.Drawing.Point(3, 545);
            this.lblTestGroup.Name = "lblTestGroup";
            this.lblTestGroup.Size = new System.Drawing.Size(74, 13);
            this.lblTestGroup.TabIndex = 3;
            this.lblTestGroup.TabStop = true;
            this.lblTestGroup.Text = "Test group ...";
            this.lblTestGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTestGroup_LinkClicked);
            // 
            // warningProvider
            // 
            this.warningProvider.ContainerControl = this;
            this.warningProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("warningProvider.Icon")));
            // 
            // ConfigurationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigurationDetail";
            this.Size = new System.Drawing.Size(821, 564);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gpxConfiguration.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gpxConfiguration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblInitScript;
        private System.Windows.Forms.LinkLabel lblCleanUpScript;
        private System.Windows.Forms.LinkLabel lblTestGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ErrorProvider warningProvider;
    }
}
