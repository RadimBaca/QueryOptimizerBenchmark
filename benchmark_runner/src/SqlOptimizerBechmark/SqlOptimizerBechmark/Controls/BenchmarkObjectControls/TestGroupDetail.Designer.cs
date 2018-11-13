namespace SqlOptimizerBechmark.Controls.BenchmarkObjectControls
{
    partial class TestGroupDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestGroupDetail));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBenchmark = new System.Windows.Forms.LinkLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gpxTestGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConfigurations = new System.Windows.Forms.TabPage();
            this.configurationsListView = new SqlOptimizerBechmark.Controls.BenchmarkListView.ConfigurationsListView();
            this.tabTests = new System.Windows.Forms.TabPage();
            this.testsListView = new SqlOptimizerBechmark.Controls.BenchmarkListView.TestsListView();
            this.warningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gpxTestGroup.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConfigurations.SuspendLayout();
            this.tabTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblBenchmark, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(705, 489);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblBenchmark
            // 
            this.lblBenchmark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBenchmark.AutoSize = true;
            this.lblBenchmark.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblBenchmark.Location = new System.Drawing.Point(3, 470);
            this.lblBenchmark.Name = "lblBenchmark";
            this.lblBenchmark.Size = new System.Drawing.Size(74, 13);
            this.lblBenchmark.TabIndex = 4;
            this.lblBenchmark.TabStop = true;
            this.lblBenchmark.Text = "Benchmark ...";
            this.lblBenchmark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBenchmark_LinkClicked);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gpxTestGroup);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Size = new System.Drawing.Size(699, 458);
            this.splitContainer.SplitterDistance = 170;
            this.splitContainer.TabIndex = 2;
            // 
            // gpxTestGroup
            // 
            this.gpxTestGroup.Controls.Add(this.tableLayoutPanel2);
            this.gpxTestGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxTestGroup.Location = new System.Drawing.Point(0, 0);
            this.gpxTestGroup.Name = "gpxTestGroup";
            this.gpxTestGroup.Size = new System.Drawing.Size(699, 170);
            this.gpxTestGroup.TabIndex = 0;
            this.gpxTestGroup.TabStop = false;
            this.gpxTestGroup.Text = "Test group";
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(693, 150);
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
            this.txtDescription.Size = new System.Drawing.Size(613, 94);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabConfigurations);
            this.tabControl.Controls.Add(this.tabTests);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(699, 284);
            this.tabControl.TabIndex = 1;
            // 
            // tabConfigurations
            // 
            this.tabConfigurations.Controls.Add(this.configurationsListView);
            this.tabConfigurations.Location = new System.Drawing.Point(4, 22);
            this.tabConfigurations.Name = "tabConfigurations";
            this.tabConfigurations.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfigurations.Size = new System.Drawing.Size(691, 258);
            this.tabConfigurations.TabIndex = 0;
            this.tabConfigurations.Text = "Configurations";
            this.tabConfigurations.UseVisualStyleBackColor = true;
            // 
            // configurationsListView
            // 
            this.configurationsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationsListView.Location = new System.Drawing.Point(3, 3);
            this.configurationsListView.Name = "configurationsListView";
            this.configurationsListView.Size = new System.Drawing.Size(685, 252);
            this.configurationsListView.TabIndex = 0;
            this.configurationsListView.TestGroup = null;
            this.configurationsListView.BenchmarkObjectDoubleClick += new SqlOptimizerBechmark.Controls.BenchmarkObjectEventHandler(this.configurationsListView_BenchmarkObjectDoubleClick);
            // 
            // tabTests
            // 
            this.tabTests.Controls.Add(this.testsListView);
            this.tabTests.Location = new System.Drawing.Point(4, 22);
            this.tabTests.Name = "tabTests";
            this.tabTests.Padding = new System.Windows.Forms.Padding(3);
            this.tabTests.Size = new System.Drawing.Size(691, 258);
            this.tabTests.TabIndex = 1;
            this.tabTests.Text = "Tests";
            this.tabTests.UseVisualStyleBackColor = true;
            // 
            // testsListView
            // 
            this.testsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testsListView.Location = new System.Drawing.Point(3, 3);
            this.testsListView.Name = "testsListView";
            this.testsListView.Size = new System.Drawing.Size(685, 252);
            this.testsListView.TabIndex = 0;
            this.testsListView.TestGroup = null;
            this.testsListView.BenchmarkObjectDoubleClick += new SqlOptimizerBechmark.Controls.BenchmarkObjectEventHandler(this.testsListView_BenchmarkObjectDoubleClick);
            // 
            // warningProvider
            // 
            this.warningProvider.ContainerControl = this;
            this.warningProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("warningProvider.Icon")));
            // 
            // TestGroupDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestGroupDetail";
            this.Size = new System.Drawing.Size(705, 489);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gpxTestGroup.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabConfigurations.ResumeLayout(false);
            this.tabTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gpxTestGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConfigurations;
        private System.Windows.Forms.TabPage tabTests;
        private BenchmarkListView.ConfigurationsListView configurationsListView;
        private BenchmarkListView.TestsListView testsListView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.LinkLabel lblBenchmark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ErrorProvider warningProvider;
    }
}
