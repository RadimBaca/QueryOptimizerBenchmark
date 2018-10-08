namespace SqlOptimizerBechmark.Controls.BenchmarkObjectControls
{
    partial class TestRunDetail
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
            this.testResultsBrowser = new SqlOptimizerBechmark.Controls.TestResultBrowser.TestResultsBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpxSummary = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTestsProcessed = new System.Windows.Forms.Label();
            this.lblTestsPassed = new System.Windows.Forms.Label();
            this.lblTestsFailed = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.gpxLog = new System.Windows.Forms.GroupBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.testResultsBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpxSummary.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpxLog.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testResultsBrowser
            // 
            this.testResultsBrowser.AllowUserToAddRows = false;
            this.testResultsBrowser.AllowUserToDeleteRows = false;
            this.testResultsBrowser.AllowUserToResizeRows = false;
            this.testResultsBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testResultsBrowser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.testResultsBrowser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testResultsBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testResultsBrowser.Location = new System.Drawing.Point(0, 0);
            this.testResultsBrowser.Name = "testResultsBrowser";
            this.testResultsBrowser.ReadOnly = true;
            this.testResultsBrowser.Size = new System.Drawing.Size(840, 406);
            this.testResultsBrowser.TabIndex = 0;
            this.testResultsBrowser.NavigateBenchmarkObject += new SqlOptimizerBechmark.Controls.BenchmarkObjectEventHandler(this.testResultsBrowser_NavigateBenchmarkObject);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.testResultsBrowser);
            this.splitContainer1.Panel1.Controls.Add(this.gpxSummary);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpxLog);
            this.splitContainer1.Size = new System.Drawing.Size(840, 614);
            this.splitContainer1.SplitterDistance = 473;
            this.splitContainer1.TabIndex = 1;
            // 
            // gpxSummary
            // 
            this.gpxSummary.Controls.Add(this.tableLayoutPanel1);
            this.gpxSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gpxSummary.Location = new System.Drawing.Point(0, 406);
            this.gpxSummary.Name = "gpxSummary";
            this.gpxSummary.Size = new System.Drawing.Size(840, 67);
            this.gpxSummary.TabIndex = 1;
            this.gpxSummary.TabStop = false;
            this.gpxSummary.Text = "Summary";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTestsProcessed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTestsPassed, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTestsFailed, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSuccess, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblErrors, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExportToCsv, 10, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 47);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tests processed:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passed:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Failed:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Success:";
            // 
            // lblTestsProcessed
            // 
            this.lblTestsProcessed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTestsProcessed.AutoSize = true;
            this.lblTestsProcessed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTestsProcessed.Location = new System.Drawing.Point(108, 6);
            this.lblTestsProcessed.Name = "lblTestsProcessed";
            this.lblTestsProcessed.Size = new System.Drawing.Size(14, 13);
            this.lblTestsProcessed.TabIndex = 2;
            this.lblTestsProcessed.Text = "0";
            // 
            // lblTestsPassed
            // 
            this.lblTestsPassed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTestsPassed.AutoSize = true;
            this.lblTestsPassed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTestsPassed.Location = new System.Drawing.Point(219, 6);
            this.lblTestsPassed.Name = "lblTestsPassed";
            this.lblTestsPassed.Size = new System.Drawing.Size(14, 13);
            this.lblTestsPassed.TabIndex = 2;
            this.lblTestsPassed.Text = "0";
            // 
            // lblTestsFailed
            // 
            this.lblTestsFailed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTestsFailed.AutoSize = true;
            this.lblTestsFailed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTestsFailed.Location = new System.Drawing.Point(321, 6);
            this.lblTestsFailed.Name = "lblTestsFailed";
            this.lblTestsFailed.Size = new System.Drawing.Size(14, 13);
            this.lblTestsFailed.TabIndex = 2;
            this.lblTestsFailed.Text = "0";
            // 
            // lblSuccess
            // 
            this.lblSuccess.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSuccess.Location = new System.Drawing.Point(435, 6);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(14, 13);
            this.lblSuccess.TabIndex = 2;
            this.lblSuccess.Text = "0";
            // 
            // progressBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar, 11);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 30);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(828, 14);
            this.progressBar.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Errors:";
            // 
            // lblErrors
            // 
            this.lblErrors.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblErrors.AutoSize = true;
            this.lblErrors.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblErrors.Location = new System.Drawing.Point(565, 6);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(14, 13);
            this.lblErrors.TabIndex = 2;
            this.lblErrors.Text = "0";
            // 
            // gpxLog
            // 
            this.gpxLog.Controls.Add(this.rtbMessages);
            this.gpxLog.Controls.Add(this.toolStrip1);
            this.gpxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxLog.Location = new System.Drawing.Point(0, 0);
            this.gpxLog.Name = "gpxLog";
            this.gpxLog.Size = new System.Drawing.Size(840, 137);
            this.gpxLog.TabIndex = 2;
            this.gpxLog.TabStop = false;
            this.gpxLog.Text = "Log";
            // 
            // rtbMessages
            // 
            this.rtbMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessages.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbMessages.Location = new System.Drawing.Point(3, 40);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(834, 94);
            this.rtbMessages.TabIndex = 0;
            this.rtbMessages.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearLog});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 23);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportToCsv.Image = global::SqlOptimizerBechmark.Properties.Resources.ExcelFile_16;
            this.btnExportToCsv.Location = new System.Drawing.Point(708, 0);
            this.btnExportToCsv.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(126, 25);
            this.btnExportToCsv.TabIndex = 4;
            this.btnExportToCsv.Text = "Export to CSV";
            this.btnExportToCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Image = global::SqlOptimizerBechmark.Properties.Resources.Clear_16;
            this.btnClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(74, 20);
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // TestRunDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TestRunDetail";
            this.Size = new System.Drawing.Size(840, 614);
            ((System.ComponentModel.ISupportInitialize)(this.testResultsBrowser)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpxSummary.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gpxLog.ResumeLayout(false);
            this.gpxLog.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TestResultBrowser.TestResultsBrowser testResultsBrowser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClearLog;
        private System.Windows.Forms.GroupBox gpxSummary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTestsProcessed;
        private System.Windows.Forms.Label lblTestsPassed;
        private System.Windows.Forms.Label lblTestsFailed;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.GroupBox gpxLog;
        private System.Windows.Forms.Button btnExportToCsv;
    }
}
