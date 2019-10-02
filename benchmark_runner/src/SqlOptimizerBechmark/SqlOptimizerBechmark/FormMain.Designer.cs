namespace SqlOptimizerBechmark
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNavigateBack = new System.Windows.Forms.ToolStripButton();
            this.btnNavigateForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActivateAll = new System.Windows.Forms.ToolStripButton();
            this.btnDeactivateAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLaunchTest = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnInterrupt = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.benchmarkTreeView = new SqlOptimizerBechmark.Controls.BenchmarkTreeView.BenchmarkTreeView();
            this.benchmarkObjectEditor = new SqlOptimizerBechmark.Controls.BenchmarkObjectControls.BenchmarkObjectEditor();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.benchmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnNavigateBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnNavigateForward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnActivateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnDeactivateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnLaunchTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnInterrupt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnExportTestingScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnExportToFileSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTSQLScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTSQLFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSave,
            this.btnOpen,
            this.toolStripSeparator1,
            this.btnNavigateBack,
            this.btnNavigateForward,
            this.toolStripSeparator2,
            this.btnActivateAll,
            this.btnDeactivateAll,
            this.toolStripSeparator3,
            this.btnLaunchTest,
            this.btnStop,
            this.btnInterrupt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1137, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::SqlOptimizerBechmark.Properties.Resources.New_16;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "New benchmark";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::SqlOptimizerBechmark.Properties.Resources.Save_16;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::SqlOptimizerBechmark.Properties.Resources.Open_16;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "toolStripButton2";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNavigateBack
            // 
            this.btnNavigateBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNavigateBack.Image = global::SqlOptimizerBechmark.Properties.Resources.Left_16;
            this.btnNavigateBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNavigateBack.Name = "btnNavigateBack";
            this.btnNavigateBack.Size = new System.Drawing.Size(23, 22);
            this.btnNavigateBack.Text = "Navigate backward";
            this.btnNavigateBack.Click += new System.EventHandler(this.btnNavigateBack_Click);
            // 
            // btnNavigateForward
            // 
            this.btnNavigateForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNavigateForward.Image = global::SqlOptimizerBechmark.Properties.Resources.Right_16;
            this.btnNavigateForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNavigateForward.Name = "btnNavigateForward";
            this.btnNavigateForward.Size = new System.Drawing.Size(23, 22);
            this.btnNavigateForward.Text = "Navigate forward";
            this.btnNavigateForward.Click += new System.EventHandler(this.btnNavigateForward_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActivateAll
            // 
            this.btnActivateAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActivateAll.Image = global::SqlOptimizerBechmark.Properties.Resources.CheckAll_16;
            this.btnActivateAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActivateAll.Name = "btnActivateAll";
            this.btnActivateAll.Size = new System.Drawing.Size(23, 22);
            this.btnActivateAll.Text = "Activate all tests";
            this.btnActivateAll.Click += new System.EventHandler(this.btnActivateAll_Click);
            // 
            // btnDeactivateAll
            // 
            this.btnDeactivateAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeactivateAll.Image = global::SqlOptimizerBechmark.Properties.Resources.UncheckAll_16;
            this.btnDeactivateAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeactivateAll.Name = "btnDeactivateAll";
            this.btnDeactivateAll.Size = new System.Drawing.Size(23, 22);
            this.btnDeactivateAll.Text = "Deactivate all tests";
            this.btnDeactivateAll.Click += new System.EventHandler(this.btnDeactivateAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLaunchTest
            // 
            this.btnLaunchTest.Image = global::SqlOptimizerBechmark.Properties.Resources.Play_16;
            this.btnLaunchTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLaunchTest.Name = "btnLaunchTest";
            this.btnLaunchTest.Size = new System.Drawing.Size(78, 22);
            this.btnLaunchTest.Text = "Launch ...";
            this.btnLaunchTest.Click += new System.EventHandler(this.btnLaunchTest_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::SqlOptimizerBechmark.Properties.Resources.StopRed_16;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(51, 22);
            this.btnStop.Text = "Stop";
            this.btnStop.ToolTipText = "Breaks the executing of the tests and runs the clean-up scripts.";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInterrupt
            // 
            this.btnInterrupt.Image = global::SqlOptimizerBechmark.Properties.Resources.InterruptRed;
            this.btnInterrupt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInterrupt.Name = "btnInterrupt";
            this.btnInterrupt.Size = new System.Drawing.Size(73, 22);
            this.btnInterrupt.Text = "Interrupt";
            this.btnInterrupt.ToolTipText = "Breaks the executing of the test, does not run any clean-up scripts.";
            this.btnInterrupt.Click += new System.EventHandler(this.btnInterrupt_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::SqlOptimizerBechmark.Properties.Settings.Default, "MainSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.benchmarkTreeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.benchmarkObjectEditor);
            this.splitContainer.Size = new System.Drawing.Size(1137, 557);
            this.splitContainer.SplitterDistance = global::SqlOptimizerBechmark.Properties.Settings.Default.MainSplitterDistance;
            this.splitContainer.TabIndex = 2;
            // 
            // benchmarkTreeView
            // 
            this.benchmarkTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.benchmarkTreeView.Location = new System.Drawing.Point(0, 0);
            this.benchmarkTreeView.Name = "benchmarkTreeView";
            this.benchmarkTreeView.Size = new System.Drawing.Size(280, 557);
            this.benchmarkTreeView.TabIndex = 1;
            this.benchmarkTreeView.SelectionChanged += new System.EventHandler(this.benchmarkTreeView_SelectionChanged);
            // 
            // benchmarkObjectEditor
            // 
            this.benchmarkObjectEditor.Benchmark = null;
            this.benchmarkObjectEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.benchmarkObjectEditor.Location = new System.Drawing.Point(0, 0);
            this.benchmarkObjectEditor.Name = "benchmarkObjectEditor";
            this.benchmarkObjectEditor.Size = new System.Drawing.Size(853, 557);
            this.benchmarkObjectEditor.TabIndex = 0;
            this.benchmarkObjectEditor.NavigateBenchmarkObject += new SqlOptimizerBechmark.Controls.BenchmarkObjectEventHandler(this.benchmarkObjectEditor_NavigateBenchmarkObject);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.benchmarkToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.testingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1137, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // benchmarkToolStripMenuItem
            // 
            this.benchmarkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnNew,
            this.mbtnOpen,
            this.mbtnSave,
            this.mbtnSaveAs,
            this.toolStripMenuItem1,
            this.mbtnExit});
            this.benchmarkToolStripMenuItem.Name = "benchmarkToolStripMenuItem";
            this.benchmarkToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.benchmarkToolStripMenuItem.Text = "Benchmark";
            // 
            // mbtnNew
            // 
            this.mbtnNew.Image = global::SqlOptimizerBechmark.Properties.Resources.New_16;
            this.mbtnNew.Name = "mbtnNew";
            this.mbtnNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mbtnNew.Size = new System.Drawing.Size(158, 22);
            this.mbtnNew.Text = "New";
            this.mbtnNew.Click += new System.EventHandler(this.mbtnNew_Click);
            // 
            // mbtnOpen
            // 
            this.mbtnOpen.Image = global::SqlOptimizerBechmark.Properties.Resources.Open_16;
            this.mbtnOpen.Name = "mbtnOpen";
            this.mbtnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mbtnOpen.Size = new System.Drawing.Size(158, 22);
            this.mbtnOpen.Text = "Open ...";
            this.mbtnOpen.Click += new System.EventHandler(this.mbtnOpen_Click);
            // 
            // mbtnSave
            // 
            this.mbtnSave.Image = global::SqlOptimizerBechmark.Properties.Resources.Save_16;
            this.mbtnSave.Name = "mbtnSave";
            this.mbtnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mbtnSave.Size = new System.Drawing.Size(158, 22);
            this.mbtnSave.Text = "Save";
            this.mbtnSave.Click += new System.EventHandler(this.mbtnSave_Click);
            // 
            // mbtnSaveAs
            // 
            this.mbtnSaveAs.Name = "mbtnSaveAs";
            this.mbtnSaveAs.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.mbtnSaveAs.Size = new System.Drawing.Size(158, 22);
            this.mbtnSaveAs.Text = "Save as ...";
            this.mbtnSaveAs.Click += new System.EventHandler(this.mbtnSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // mbtnExit
            // 
            this.mbtnExit.Name = "mbtnExit";
            this.mbtnExit.Size = new System.Drawing.Size(158, 22);
            this.mbtnExit.Text = "Exit";
            this.mbtnExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnNavigateBack,
            this.mbtnNavigateForward,
            this.toolStripMenuItem2,
            this.mbtnActivateAll,
            this.mbtnDeactivateAll});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mbtnNavigateBack
            // 
            this.mbtnNavigateBack.Image = global::SqlOptimizerBechmark.Properties.Resources.Left_16;
            this.mbtnNavigateBack.Name = "mbtnNavigateBack";
            this.mbtnNavigateBack.Size = new System.Drawing.Size(175, 22);
            this.mbtnNavigateBack.Text = "Navigate backward";
            this.mbtnNavigateBack.Click += new System.EventHandler(this.mbtnNavigateBack_Click);
            // 
            // mbtnNavigateForward
            // 
            this.mbtnNavigateForward.Image = global::SqlOptimizerBechmark.Properties.Resources.Right_16;
            this.mbtnNavigateForward.Name = "mbtnNavigateForward";
            this.mbtnNavigateForward.Size = new System.Drawing.Size(175, 22);
            this.mbtnNavigateForward.Text = "Navigate forward";
            this.mbtnNavigateForward.Click += new System.EventHandler(this.mbtnNavigateForward_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // mbtnActivateAll
            // 
            this.mbtnActivateAll.Image = global::SqlOptimizerBechmark.Properties.Resources.CheckAll_16;
            this.mbtnActivateAll.Name = "mbtnActivateAll";
            this.mbtnActivateAll.Size = new System.Drawing.Size(175, 22);
            this.mbtnActivateAll.Text = "Activate all tests";
            this.mbtnActivateAll.Click += new System.EventHandler(this.mbtnActivateAll_Click);
            // 
            // mbtnDeactivateAll
            // 
            this.mbtnDeactivateAll.Image = global::SqlOptimizerBechmark.Properties.Resources.UncheckAll_16;
            this.mbtnDeactivateAll.Name = "mbtnDeactivateAll";
            this.mbtnDeactivateAll.Size = new System.Drawing.Size(175, 22);
            this.mbtnDeactivateAll.Text = "Deactivate all tests";
            this.mbtnDeactivateAll.Click += new System.EventHandler(this.mbtnDeactivateAll_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnLaunchTest,
            this.mbtnStop,
            this.mbtnInterrupt,
            this.toolStripMenuItem3,
            this.mbtnExportTestingScript,
            this.mbtnExportToFileSystem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.testingToolStripMenuItem.Text = "Testing";
            // 
            // mbtnLaunchTest
            // 
            this.mbtnLaunchTest.Image = global::SqlOptimizerBechmark.Properties.Resources.Play_16;
            this.mbtnLaunchTest.Name = "mbtnLaunchTest";
            this.mbtnLaunchTest.Size = new System.Drawing.Size(180, 22);
            this.mbtnLaunchTest.Text = "Launch ...";
            this.mbtnLaunchTest.Click += new System.EventHandler(this.mbtnLaunchTest_Click);
            // 
            // mbtnStop
            // 
            this.mbtnStop.Image = global::SqlOptimizerBechmark.Properties.Resources.StopRed_16;
            this.mbtnStop.Name = "mbtnStop";
            this.mbtnStop.Size = new System.Drawing.Size(180, 22);
            this.mbtnStop.Text = "Stop";
            this.mbtnStop.Click += new System.EventHandler(this.mbtnStop_Click);
            // 
            // mbtnInterrupt
            // 
            this.mbtnInterrupt.Image = global::SqlOptimizerBechmark.Properties.Resources.InterruptRed;
            this.mbtnInterrupt.Name = "mbtnInterrupt";
            this.mbtnInterrupt.Size = new System.Drawing.Size(180, 22);
            this.mbtnInterrupt.Text = "Interrupt";
            this.mbtnInterrupt.Click += new System.EventHandler(this.mbtnInterrupt_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // mbtnExportTestingScript
            // 
            this.mbtnExportTestingScript.Image = global::SqlOptimizerBechmark.Properties.Resources.ExportToSql_16;
            this.mbtnExportTestingScript.Name = "mbtnExportTestingScript";
            this.mbtnExportTestingScript.Size = new System.Drawing.Size(180, 22);
            this.mbtnExportTestingScript.Text = "Export testing script";
            this.mbtnExportTestingScript.Click += new System.EventHandler(this.mbtnExportTestingScript_Click);
            // 
            // mbtnExportToFileSystem
            // 
            this.mbtnExportToFileSystem.Image = global::SqlOptimizerBechmark.Properties.Resources.ExportToFileSystem_16;
            this.mbtnExportToFileSystem.Name = "mbtnExportToFileSystem";
            this.mbtnExportToFileSystem.Size = new System.Drawing.Size(180, 22);
            this.mbtnExportToFileSystem.Text = "Export to file system";
            this.mbtnExportToFileSystem.Click += new System.EventHandler(this.exportToFileSystemToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnAbout,
            this.btnTest,
            this.tESTSQLScannerToolStripMenuItem,
            this.tESTSQLFormatToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mbtnAbout
            // 
            this.mbtnAbout.Name = "mbtnAbout";
            this.mbtnAbout.Size = new System.Drawing.Size(180, 22);
            this.mbtnAbout.Text = "About ...";
            this.mbtnAbout.Click += new System.EventHandler(this.mbtnAbout_Click);
            // 
            // btnTest
            // 
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(180, 22);
            this.btnTest.Text = "TEST Debug";
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tESTSQLScannerToolStripMenuItem
            // 
            this.tESTSQLScannerToolStripMenuItem.Name = "tESTSQLScannerToolStripMenuItem";
            this.tESTSQLScannerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tESTSQLScannerToolStripMenuItem.Text = "TEST SQL Scanner";
            this.tESTSQLScannerToolStripMenuItem.Click += new System.EventHandler(this.tESTSQLScannerToolStripMenuItem_Click);
            // 
            // tESTSQLFormatToolStripMenuItem
            // 
            this.tESTSQLFormatToolStripMenuItem.Name = "tESTSQLFormatToolStripMenuItem";
            this.tESTSQLFormatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tESTSQLFormatToolStripMenuItem.Text = "TEST SQL Format";
            this.tESTSQLFormatToolStripMenuItem.Click += new System.EventHandler(this.tESTSQLFormatToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1137, 606);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "SQL Optimizer Benchmark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.BenchmarkTreeView.BenchmarkTreeView benchmarkTreeView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Controls.BenchmarkObjectControls.BenchmarkObjectEditor benchmarkObjectEditor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNavigateBack;
        private System.Windows.Forms.ToolStripButton btnNavigateForward;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnActivateAll;
        private System.Windows.Forms.ToolStripButton btnDeactivateAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem benchmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnNew;
        private System.Windows.Forms.ToolStripMenuItem mbtnOpen;
        private System.Windows.Forms.ToolStripMenuItem mbtnSave;
        private System.Windows.Forms.ToolStripMenuItem mbtnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mbtnExit;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnLaunchTest;
        private System.Windows.Forms.ToolStripMenuItem mbtnStop;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnAbout;
        private System.Windows.Forms.ToolStripButton btnLaunchTest;
        private System.Windows.Forms.ToolStripButton btnInterrupt;
        private System.Windows.Forms.ToolStripMenuItem mbtnInterrupt;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnNavigateBack;
        private System.Windows.Forms.ToolStripMenuItem mbtnNavigateForward;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mbtnActivateAll;
        private System.Windows.Forms.ToolStripMenuItem mbtnDeactivateAll;
        private System.Windows.Forms.ToolStripMenuItem mbtnExportTestingScript;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mbtnExportToFileSystem;
        private System.Windows.Forms.ToolStripMenuItem btnTest;
        private System.Windows.Forms.ToolStripMenuItem tESTSQLScannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tESTSQLFormatToolStripMenuItem;
    }
}

