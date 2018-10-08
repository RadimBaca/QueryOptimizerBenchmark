namespace SqlOptimizerBechmark.Controls.BenchmarkObjectControls
{
    partial class PlanEquivalenceTestDetail
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
            this.lblBenchmark = new System.Windows.Forms.LinkLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gpxPlanEquivalenceTest = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gpxVariants = new System.Windows.Forms.GroupBox();
            this.queryVariantsListView = new SqlOptimizerBechmark.Controls.BenchmarkListView.QueryVariantsListView();
            this.cbxActive = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gpxPlanEquivalenceTest.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpxVariants.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 472);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblBenchmark
            // 
            this.lblBenchmark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBenchmark.AutoSize = true;
            this.lblBenchmark.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblBenchmark.Location = new System.Drawing.Point(3, 453);
            this.lblBenchmark.Name = "lblBenchmark";
            this.lblBenchmark.Size = new System.Drawing.Size(74, 13);
            this.lblBenchmark.TabIndex = 5;
            this.lblBenchmark.TabStop = true;
            this.lblBenchmark.Text = "Test group ...";
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
            this.splitContainer.Panel1.Controls.Add(this.gpxPlanEquivalenceTest);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gpxVariants);
            this.splitContainer.Size = new System.Drawing.Size(679, 441);
            this.splitContainer.SplitterDistance = 170;
            this.splitContainer.TabIndex = 0;
            // 
            // gpxPlanEquivalenceTest
            // 
            this.gpxPlanEquivalenceTest.Controls.Add(this.tableLayoutPanel2);
            this.gpxPlanEquivalenceTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxPlanEquivalenceTest.Location = new System.Drawing.Point(0, 0);
            this.gpxPlanEquivalenceTest.Name = "gpxPlanEquivalenceTest";
            this.gpxPlanEquivalenceTest.Size = new System.Drawing.Size(679, 170);
            this.gpxPlanEquivalenceTest.TabIndex = 0;
            this.gpxPlanEquivalenceTest.TabStop = false;
            this.gpxPlanEquivalenceTest.Text = "Plan equivalence test";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDescription, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbxActive, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(673, 150);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // txtName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtName, 2);
            this.txtName.Location = new System.Drawing.Point(77, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 21);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDescription
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtDescription, 2);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(77, 28);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.tableLayoutPanel2.SetRowSpan(this.txtDescription, 2);
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(593, 94);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // gpxVariants
            // 
            this.gpxVariants.Controls.Add(this.queryVariantsListView);
            this.gpxVariants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxVariants.Location = new System.Drawing.Point(0, 0);
            this.gpxVariants.Name = "gpxVariants";
            this.gpxVariants.Size = new System.Drawing.Size(679, 267);
            this.gpxVariants.TabIndex = 1;
            this.gpxVariants.TabStop = false;
            this.gpxVariants.Text = "Variants";
            // 
            // queryVariantsListView
            // 
            this.queryVariantsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryVariantsListView.Location = new System.Drawing.Point(3, 17);
            this.queryVariantsListView.Name = "queryVariantsListView";
            this.queryVariantsListView.PlanEquivalenceTest = null;
            this.queryVariantsListView.Size = new System.Drawing.Size(673, 247);
            this.queryVariantsListView.TabIndex = 0;
            this.queryVariantsListView.BenchmarkObjectDoubleClick += new SqlOptimizerBechmark.Controls.BenchmarkObjectEventHandler(this.queryVariantsListView_BenchmarkObjectDoubleClick);
            // 
            // cbxActive
            // 
            this.cbxActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxActive.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.cbxActive, 2);
            this.cbxActive.Location = new System.Drawing.Point(77, 129);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(56, 17);
            this.cbxActive.TabIndex = 3;
            this.cbxActive.Text = "Active";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.CheckedChanged += new System.EventHandler(this.cbxActive_CheckedChanged);
            // 
            // PlanEquivalenceTestDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlanEquivalenceTestDetail";
            this.Size = new System.Drawing.Size(685, 472);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gpxPlanEquivalenceTest.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gpxVariants.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gpxPlanEquivalenceTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpxVariants;
        private BenchmarkListView.QueryVariantsListView queryVariantsListView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.LinkLabel lblBenchmark;
        private System.Windows.Forms.CheckBox cbxActive;
    }
}
