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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.testResultsBrowser = new SqlOptimizerBechmark.Controls.TestResultBrowser.TestResultsBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpxSummary = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExecutionSettings = new System.Windows.Forms.TextBox();
            this.txtDbProviderSettings = new System.Windows.Forms.MaskedTextBox();
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
            this.btnCopySelectedQueries = new System.Windows.Forms.Button();
            this.btnSaveToDatabase = new System.Windows.Forms.Button();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.gpxLog = new System.Windows.Forms.GroupBox();
            this.logBrowser = new SqlOptimizerBechmark.Controls.LogBrowser();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClearLog = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.testResultsBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpxSummary.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpxLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logBrowser)).BeginInit();
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
            this.testResultsBrowser.Size = new System.Drawing.Size(840, 218);
            this.testResultsBrowser.TabIndex = 0;
            this.testResultsBrowser.NavigateBenchmarkObject += new SqlOptimizerBechmark.Controls.BenchmarkObjectEventHandler(this.testResultsBrowser_NavigateBenchmarkObject);
            this.testResultsBrowser.SelectionChanged += new System.EventHandler(this.testResultsBrowser_SelectionChanged);
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
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 1;
            // 
            // gpxSummary
            // 
            this.gpxSummary.Controls.Add(this.tableLayoutPanel2);
            this.gpxSummary.Controls.Add(this.tableLayoutPanel1);
            this.gpxSummary.Controls.Add(this.btnCopySelectedQueries);
            this.gpxSummary.Controls.Add(this.btnSaveToDatabase);
            this.gpxSummary.Controls.Add(this.btnExportToCsv);
            this.gpxSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gpxSummary.Location = new System.Drawing.Point(0, 218);
            this.gpxSummary.Name = "gpxSummary";
            this.gpxSummary.Size = new System.Drawing.Size(840, 159);
            this.gpxSummary.TabIndex = 1;
            this.gpxSummary.TabStop = false;
            this.gpxSummary.Text = "Summary";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtExecutionSettings, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDbProviderSettings, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 102);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(834, 54);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Execution settings:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "DB Provider settings:";
            // 
            // txtExecutionSettings
            // 
            this.txtExecutionSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExecutionSettings.Location = new System.Drawing.Point(134, 3);
            this.txtExecutionSettings.Name = "txtExecutionSettings";
            this.txtExecutionSettings.ReadOnly = true;
            this.txtExecutionSettings.Size = new System.Drawing.Size(697, 21);
            this.txtExecutionSettings.TabIndex = 0;
            // 
            // txtDbProviderSettings
            // 
            this.txtDbProviderSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDbProviderSettings.Location = new System.Drawing.Point(134, 28);
            this.txtDbProviderSettings.Name = "txtDbProviderSettings";
            this.txtDbProviderSettings.ReadOnly = true;
            this.txtDbProviderSettings.Size = new System.Drawing.Size(697, 21);
            this.txtDbProviderSettings.TabIndex = 1;
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
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblErrors, 9, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
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
            this.progressBar.Location = new System.Drawing.Point(3, 28);
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
            // btnCopySelectedQueries
            // 
            this.btnCopySelectedQueries.Image = global::SqlOptimizerBechmark.Properties.Resources.CopySql_16;
            this.btnCopySelectedQueries.Location = new System.Drawing.Point(306, 70);
            this.btnCopySelectedQueries.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopySelectedQueries.Name = "btnCopySelectedQueries";
            this.btnCopySelectedQueries.Size = new System.Drawing.Size(150, 25);
            this.btnCopySelectedQueries.TabIndex = 5;
            this.btnCopySelectedQueries.Text = "Copy selected queries";
            this.btnCopySelectedQueries.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopySelectedQueries.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopySelectedQueries.UseVisualStyleBackColor = true;
            this.btnCopySelectedQueries.Click += new System.EventHandler(this.btnCopySelectedQueries_Click);
            // 
            // btnSaveToDatabase
            // 
            this.btnSaveToDatabase.Image = global::SqlOptimizerBechmark.Properties.Resources.SaveToDb_16;
            this.btnSaveToDatabase.Location = new System.Drawing.Point(156, 70);
            this.btnSaveToDatabase.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(150, 25);
            this.btnSaveToDatabase.TabIndex = 4;
            this.btnSaveToDatabase.Text = "Save to database";
            this.btnSaveToDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveToDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveToDatabase.UseVisualStyleBackColor = true;
            this.btnSaveToDatabase.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Image = global::SqlOptimizerBechmark.Properties.Resources.ExcelFile_16;
            this.btnExportToCsv.Location = new System.Drawing.Point(6, 70);
            this.btnExportToCsv.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(150, 25);
            this.btnExportToCsv.TabIndex = 4;
            this.btnExportToCsv.Text = "Export to CSV";
            this.btnExportToCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
            // 
            // gpxLog
            // 
            this.gpxLog.Controls.Add(this.logBrowser);
            this.gpxLog.Controls.Add(this.toolStrip1);
            this.gpxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxLog.Location = new System.Drawing.Point(0, 0);
            this.gpxLog.Name = "gpxLog";
            this.gpxLog.Size = new System.Drawing.Size(840, 233);
            this.gpxLog.TabIndex = 2;
            this.gpxLog.TabStop = false;
            this.gpxLog.Text = "Log";
            // 
            // logBrowser
            // 
            this.logBrowser.AllowUserToAddRows = false;
            this.logBrowser.AllowUserToDeleteRows = false;
            this.logBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBrowser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logBrowser.ColumnHeadersVisible = false;
            this.logBrowser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.logBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBrowser.Location = new System.Drawing.Point(3, 40);
            this.logBrowser.Name = "logBrowser";
            this.logBrowser.ReadOnly = true;
            this.logBrowser.Size = new System.Drawing.Size(834, 190);
            this.logBrowser.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn13.HeaderText = "Time";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 120;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.FillWeight = 50F;
            this.dataGridViewTextBoxColumn14.HeaderText = "Message";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn15.FillWeight = 50F;
            this.dataGridViewTextBoxColumn15.HeaderText = "Statement";
            this.dataGridViewTextBoxColumn15.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn10.HeaderText = "Time";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.FillWeight = 50F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Message";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.FillWeight = 50F;
            this.dataGridViewTextBoxColumn12.HeaderText = "Statement";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn7.HeaderText = "Time";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 50F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Message";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.FillWeight = 50F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Statement";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 50F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Message";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.FillWeight = 50F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Statement";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 50F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Message";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.FillWeight = 50F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Statement";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gpxLog.ResumeLayout(false);
            this.gpxLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logBrowser)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TestResultBrowser.TestResultsBrowser testResultsBrowser;
        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private LogBrowser logBrowser;
        private System.Windows.Forms.Button btnSaveToDatabase;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExecutionSettings;
        private System.Windows.Forms.MaskedTextBox txtDbProviderSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnCopySelectedQueries;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    }
}
