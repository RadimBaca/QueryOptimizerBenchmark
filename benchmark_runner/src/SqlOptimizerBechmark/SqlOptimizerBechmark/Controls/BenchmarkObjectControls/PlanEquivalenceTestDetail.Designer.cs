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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanEquivalenceTestDetail));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBenchmark = new System.Windows.Forms.LinkLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gpxPlanEquivalenceTest = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpectedResultSize = new System.Windows.Forms.TextBox();
            this.btnSetByFirstVariant = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.gpxVariants = new System.Windows.Forms.GroupBox();
            this.queryVariantsListView = new SqlOptimizerBechmark.Controls.BenchmarkListView.QueryVariantsListView();
            this.warningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gpxPlanEquivalenceTest.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpxVariants.SuspendLayout();
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
            this.splitContainer.SplitterDistance = 196;
            this.splitContainer.TabIndex = 0;
            // 
            // gpxPlanEquivalenceTest
            // 
            this.gpxPlanEquivalenceTest.Controls.Add(this.tableLayoutPanel2);
            this.gpxPlanEquivalenceTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxPlanEquivalenceTest.Location = new System.Drawing.Point(0, 0);
            this.gpxPlanEquivalenceTest.Name = "gpxPlanEquivalenceTest";
            this.gpxPlanEquivalenceTest.Size = new System.Drawing.Size(679, 196);
            this.gpxPlanEquivalenceTest.TabIndex = 0;
            this.gpxPlanEquivalenceTest.TabStop = false;
            this.gpxPlanEquivalenceTest.Text = "Plan equivalence test";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDescription, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbxActive, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtExpectedResultSize, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnSetByFirstVariant, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNumber, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(673, 176);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // txtName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtName, 2);
            this.txtName.Location = new System.Drawing.Point(123, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 21);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDescription
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtDescription, 2);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(123, 53);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.tableLayoutPanel2.SetRowSpan(this.txtDescription, 2);
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(547, 70);
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
            // cbxActive
            // 
            this.cbxActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxActive.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.cbxActive, 2);
            this.cbxActive.Location = new System.Drawing.Point(123, 155);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(56, 17);
            this.cbxActive.TabIndex = 5;
            this.cbxActive.Text = "Active";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.CheckedChanged += new System.EventHandler(this.cbxActive_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Expected result size:";
            // 
            // txtExpectedResultSize
            // 
            this.txtExpectedResultSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpectedResultSize.Location = new System.Drawing.Point(123, 129);
            this.txtExpectedResultSize.Name = "txtExpectedResultSize";
            this.txtExpectedResultSize.Size = new System.Drawing.Size(114, 21);
            this.txtExpectedResultSize.TabIndex = 3;
            this.txtExpectedResultSize.Validating += new System.ComponentModel.CancelEventHandler(this.txtExpectedResultSize_Validating);
            // 
            // btnSetByFirstVariant
            // 
            this.btnSetByFirstVariant.Location = new System.Drawing.Point(240, 128);
            this.btnSetByFirstVariant.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnSetByFirstVariant.Name = "btnSetByFirstVariant";
            this.btnSetByFirstVariant.Size = new System.Drawing.Size(141, 23);
            this.btnSetByFirstVariant.TabIndex = 4;
            this.btnSetByFirstVariant.Text = "Query by first variant";
            this.btnSetByFirstVariant.UseVisualStyleBackColor = true;
            this.btnSetByFirstVariant.Click += new System.EventHandler(this.btnSetByFirstVariant_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Number:";
            // 
            // txtNumber
            // 
            this.txtNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumber.Location = new System.Drawing.Point(123, 3);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(114, 21);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // gpxVariants
            // 
            this.gpxVariants.Controls.Add(this.queryVariantsListView);
            this.gpxVariants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxVariants.Location = new System.Drawing.Point(0, 0);
            this.gpxVariants.Name = "gpxVariants";
            this.gpxVariants.Size = new System.Drawing.Size(679, 241);
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
            this.queryVariantsListView.Size = new System.Drawing.Size(673, 221);
            this.queryVariantsListView.TabIndex = 0;
            this.queryVariantsListView.BenchmarkObjectDoubleClick += new SqlOptimizerBechmark.Controls.BenchmarkObjectEventHandler(this.queryVariantsListView_BenchmarkObjectDoubleClick);
            // 
            // warningProvider
            // 
            this.warningProvider.ContainerControl = this;
            this.warningProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("warningProvider.Icon")));
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
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpectedResultSize;
        private System.Windows.Forms.Button btnSetByFirstVariant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ErrorProvider warningProvider;
    }
}
