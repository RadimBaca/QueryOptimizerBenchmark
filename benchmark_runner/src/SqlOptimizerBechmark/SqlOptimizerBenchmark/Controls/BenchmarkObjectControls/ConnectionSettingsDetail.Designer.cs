namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    partial class ConnectionSettingsDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboProviders = new System.Windows.Forms.ComboBox();
            this.gpxProviderSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboProviders, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gpxProviderSettings, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provider:";
            // 
            // comboProviders
            // 
            this.comboProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProviders.FormattingEnabled = true;
            this.comboProviders.Location = new System.Drawing.Point(72, 3);
            this.comboProviders.Name = "comboProviders";
            this.comboProviders.Size = new System.Drawing.Size(254, 21);
            this.comboProviders.TabIndex = 1;
            this.comboProviders.SelectedIndexChanged += new System.EventHandler(this.comboProviders_SelectedIndexChanged);
            // 
            // gpxProviderSettings
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpxProviderSettings, 2);
            this.gpxProviderSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxProviderSettings.Location = new System.Drawing.Point(3, 47);
            this.gpxProviderSettings.Name = "gpxProviderSettings";
            this.gpxProviderSettings.Size = new System.Drawing.Size(572, 391);
            this.gpxProviderSettings.TabIndex = 2;
            this.gpxProviderSettings.TabStop = false;
            this.gpxProviderSettings.Text = "Provider settings";
            // 
            // ConnectionSettingsDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectionSettingsDetail";
            this.Size = new System.Drawing.Size(578, 441);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboProviders;
        private System.Windows.Forms.GroupBox gpxProviderSettings;
    }
}
