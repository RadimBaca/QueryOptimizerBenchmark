namespace SqlOptimizerBechmark.Controls
{
    partial class NewTestRunDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTestRunDialog));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpxSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRunInitScript = new System.Windows.Forms.CheckBox();
            this.cbxRunCleanUpScript = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbxCheckResultSizes = new System.Windows.Forms.CheckBox();
            this.cbxCompareResults = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ignoreAnnotationsClb = new SqlOptimizerBechmark.Controls.AnnotationCheckListBox();
            this.gpxSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(261, 177);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(342, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gpxSettings
            // 
            this.gpxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpxSettings.Controls.Add(this.tableLayoutPanel1);
            this.gpxSettings.Location = new System.Drawing.Point(12, 12);
            this.gpxSettings.Name = "gpxSettings";
            this.gpxSettings.Size = new System.Drawing.Size(405, 159);
            this.gpxSettings.TabIndex = 0;
            this.gpxSettings.TabStop = false;
            this.gpxSettings.Text = "Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxRunInitScript, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxRunCleanUpScript, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxCheckResultSizes, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxCompareResults, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(399, 139);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // cbxRunInitScript
            // 
            this.cbxRunInitScript.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxRunInitScript.AutoSize = true;
            this.cbxRunInitScript.Location = new System.Drawing.Point(60, 39);
            this.cbxRunInitScript.Name = "cbxRunInitScript";
            this.cbxRunInitScript.Size = new System.Drawing.Size(91, 17);
            this.cbxRunInitScript.TabIndex = 1;
            this.cbxRunInitScript.Text = "Run init script";
            this.cbxRunInitScript.UseVisualStyleBackColor = true;
            // 
            // cbxRunCleanUpScript
            // 
            this.cbxRunCleanUpScript.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxRunCleanUpScript.AutoSize = true;
            this.cbxRunCleanUpScript.Location = new System.Drawing.Point(60, 64);
            this.cbxRunCleanUpScript.Name = "cbxRunCleanUpScript";
            this.cbxRunCleanUpScript.Size = new System.Drawing.Size(118, 17);
            this.cbxRunCleanUpScript.TabIndex = 2;
            this.cbxRunCleanUpScript.Text = "Run clean-up script";
            this.cbxRunCleanUpScript.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(60, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(144, 21);
            this.txtName.TabIndex = 0;
            // 
            // cbxCheckResultSizes
            // 
            this.cbxCheckResultSizes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxCheckResultSizes.AutoSize = true;
            this.cbxCheckResultSizes.Location = new System.Drawing.Point(60, 89);
            this.cbxCheckResultSizes.Name = "cbxCheckResultSizes";
            this.cbxCheckResultSizes.Size = new System.Drawing.Size(111, 17);
            this.cbxCheckResultSizes.TabIndex = 3;
            this.cbxCheckResultSizes.Text = "Check result sizes";
            this.cbxCheckResultSizes.UseVisualStyleBackColor = true;
            // 
            // cbxCompareResults
            // 
            this.cbxCompareResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxCompareResults.AutoSize = true;
            this.cbxCompareResults.Location = new System.Drawing.Point(60, 114);
            this.cbxCompareResults.Name = "cbxCompareResults";
            this.cbxCompareResults.Size = new System.Drawing.Size(104, 17);
            this.cbxCompareResults.TabIndex = 4;
            this.cbxCompareResults.Text = "Compare results";
            this.cbxCompareResults.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ignore annotations:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ignoreAnnotationsClb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(229, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 6);
            this.panel1.Size = new System.Drawing.Size(166, 129);
            this.panel1.TabIndex = 3;
            // 
            // ignoreAnnotationsClb
            // 
            this.ignoreAnnotationsClb.CheckOnClick = true;
            this.ignoreAnnotationsClb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ignoreAnnotationsClb.FormattingEnabled = true;
            this.ignoreAnnotationsClb.Location = new System.Drawing.Point(0, 13);
            this.ignoreAnnotationsClb.Name = "ignoreAnnotationsClb";
            this.ignoreAnnotationsClb.ParentBenchmarkObject = null;
            this.ignoreAnnotationsClb.SelectedAnnotations = null;
            this.ignoreAnnotationsClb.Size = new System.Drawing.Size(166, 116);
            this.ignoreAnnotationsClb.TabIndex = 5;
            // 
            // NewTestRunDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(429, 212);
            this.Controls.Add(this.gpxSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTestRunDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New test run";
            this.Load += new System.EventHandler(this.NewTestRunDialog_Load);
            this.Shown += new System.EventHandler(this.NewTestRunDialog_Shown);
            this.gpxSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gpxSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxRunInitScript;
        private System.Windows.Forms.CheckBox cbxRunCleanUpScript;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox cbxCheckResultSizes;
        private System.Windows.Forms.CheckBox cbxCompareResults;
        private AnnotationCheckListBox ignoreAnnotationsClb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}