namespace SqlOptimizerBechmark.Controls.BenchmarkObjectControls
{
    partial class QueryVariantDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryVariantDetail));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpxQueryVariant = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.gpxSelectedAnnotations = new System.Windows.Forms.GroupBox();
            this.selectedAnnotationsClb = new SqlOptimizerBechmark.Controls.AnnotationCheckListBox();
            this.splitContainerParameters = new System.Windows.Forms.SplitContainer();
            this.gpxStatement = new System.Windows.Forms.GroupBox();
            this.fctbStatement = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dbProviderComboBox = new SqlOptimizerBechmark.Controls.DbProviderComboBox();
            this.btnChangeImplementation = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxNotSupported = new System.Windows.Forms.CheckBox();
            this.gpxTemplateParameters = new System.Windows.Forms.GroupBox();
            this.listTemplateParameters = new System.Windows.Forms.ListView();
            this.colParameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNextVariant = new System.Windows.Forms.LinkLabel();
            this.lblPreviousVariant = new System.Windows.Forms.LinkLabel();
            this.lblTest = new System.Windows.Forms.LinkLabel();
            this.warningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpxQueryVariant.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpxSelectedAnnotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerParameters)).BeginInit();
            this.splitContainerParameters.Panel1.SuspendLayout();
            this.splitContainerParameters.Panel2.SuspendLayout();
            this.splitContainerParameters.SuspendLayout();
            this.gpxStatement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbStatement)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.gpxTemplateParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNextVariant, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPreviousVariant, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTest, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(789, 542);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer, 3);
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainerParameters);
            this.splitContainer.Size = new System.Drawing.Size(783, 511);
            this.splitContainer.SplitterDistance = 170;
            this.splitContainer.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpxQueryVariant);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpxSelectedAnnotations);
            this.splitContainer1.Size = new System.Drawing.Size(783, 170);
            this.splitContainer1.SplitterDistance = 608;
            this.splitContainer1.TabIndex = 0;
            // 
            // gpxQueryVariant
            // 
            this.gpxQueryVariant.Controls.Add(this.tableLayoutPanel2);
            this.gpxQueryVariant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxQueryVariant.Location = new System.Drawing.Point(0, 0);
            this.gpxQueryVariant.Name = "gpxQueryVariant";
            this.gpxQueryVariant.Size = new System.Drawing.Size(608, 170);
            this.gpxQueryVariant.TabIndex = 0;
            this.gpxQueryVariant.TabStop = false;
            this.gpxQueryVariant.Text = "Query variant";
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(602, 150);
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
            this.txtDescription.Size = new System.Drawing.Size(522, 94);
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
            // gpxSelectedAnnotations
            // 
            this.gpxSelectedAnnotations.Controls.Add(this.selectedAnnotationsClb);
            this.gpxSelectedAnnotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxSelectedAnnotations.Location = new System.Drawing.Point(0, 0);
            this.gpxSelectedAnnotations.Name = "gpxSelectedAnnotations";
            this.gpxSelectedAnnotations.Size = new System.Drawing.Size(171, 170);
            this.gpxSelectedAnnotations.TabIndex = 0;
            this.gpxSelectedAnnotations.TabStop = false;
            this.gpxSelectedAnnotations.Text = "Annotations";
            // 
            // selectedAnnotationsClb
            // 
            this.selectedAnnotationsClb.CheckOnClick = true;
            this.selectedAnnotationsClb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedAnnotationsClb.FormattingEnabled = true;
            this.selectedAnnotationsClb.Location = new System.Drawing.Point(3, 17);
            this.selectedAnnotationsClb.Name = "selectedAnnotationsClb";
            this.selectedAnnotationsClb.ParentBenchmarkObject = null;
            this.selectedAnnotationsClb.SelectedAnnotations = null;
            this.selectedAnnotationsClb.Size = new System.Drawing.Size(165, 150);
            this.selectedAnnotationsClb.TabIndex = 1;
            // 
            // splitContainerParameters
            // 
            this.splitContainerParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerParameters.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerParameters.Location = new System.Drawing.Point(0, 0);
            this.splitContainerParameters.Name = "splitContainerParameters";
            // 
            // splitContainerParameters.Panel1
            // 
            this.splitContainerParameters.Panel1.Controls.Add(this.gpxStatement);
            // 
            // splitContainerParameters.Panel2
            // 
            this.splitContainerParameters.Panel2.Controls.Add(this.gpxTemplateParameters);
            this.splitContainerParameters.Size = new System.Drawing.Size(783, 337);
            this.splitContainerParameters.SplitterDistance = 654;
            this.splitContainerParameters.TabIndex = 2;
            // 
            // gpxStatement
            // 
            this.gpxStatement.Controls.Add(this.fctbStatement);
            this.gpxStatement.Controls.Add(this.tableLayoutPanel3);
            this.gpxStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxStatement.Location = new System.Drawing.Point(0, 0);
            this.gpxStatement.Name = "gpxStatement";
            this.gpxStatement.Size = new System.Drawing.Size(654, 337);
            this.gpxStatement.TabIndex = 1;
            this.gpxStatement.TabStop = false;
            this.gpxStatement.Text = "Statement";
            // 
            // fctbStatement
            // 
            this.fctbStatement.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbStatement.AutoIndentCharsPatterns = "";
            this.fctbStatement.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctbStatement.BackBrush = null;
            this.fctbStatement.CharHeight = 14;
            this.fctbStatement.CharWidth = 8;
            this.fctbStatement.CommentPrefix = "--";
            this.fctbStatement.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbStatement.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbStatement.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbStatement.IsReplaceMode = false;
            this.fctbStatement.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctbStatement.LeftBracket = '(';
            this.fctbStatement.Location = new System.Drawing.Point(3, 46);
            this.fctbStatement.Name = "fctbStatement";
            this.fctbStatement.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbStatement.RightBracket = ')';
            this.fctbStatement.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbStatement.Size = new System.Drawing.Size(648, 288);
            this.fctbStatement.TabIndex = 3;
            this.fctbStatement.Text = "fastColoredTextBox1";
            this.fctbStatement.Zoom = 100;
            this.fctbStatement.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbStatement_TextChangedDelayed);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dbProviderComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnChangeImplementation, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbxNotSupported, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(648, 29);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dbProviderComboBox
            // 
            this.dbProviderComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dbProviderComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dbProviderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbProviderComboBox.FormattingEnabled = true;
            this.dbProviderComboBox.Location = new System.Drawing.Point(77, 3);
            this.dbProviderComboBox.Name = "dbProviderComboBox";
            this.dbProviderComboBox.SelectedDbProvider = null;
            this.dbProviderComboBox.Size = new System.Drawing.Size(230, 22);
            this.dbProviderComboBox.TabIndex = 0;
            this.dbProviderComboBox.ProviderImplemented += new SqlOptimizerBechmark.Controls.DbProviderComboBox.ProviderImplementedEventHandler(this.dbProviderComboBox_ProviderImplemented);
            this.dbProviderComboBox.SelectedIndexChanged += new System.EventHandler(this.dbProviderComboBox_SelectedIndexChanged);
            // 
            // btnChangeImplementation
            // 
            this.btnChangeImplementation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnChangeImplementation.Location = new System.Drawing.Point(310, 2);
            this.btnChangeImplementation.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnChangeImplementation.Name = "btnChangeImplementation";
            this.btnChangeImplementation.Size = new System.Drawing.Size(74, 23);
            this.btnChangeImplementation.TabIndex = 1;
            this.btnChangeImplementation.Text = "Implement";
            this.btnChangeImplementation.UseVisualStyleBackColor = true;
            this.btnChangeImplementation.Click += new System.EventHandler(this.btnChangeImplementation_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Provider:";
            // 
            // cbxNotSupported
            // 
            this.cbxNotSupported.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxNotSupported.AutoSize = true;
            this.cbxNotSupported.Location = new System.Drawing.Point(408, 5);
            this.cbxNotSupported.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.cbxNotSupported.Name = "cbxNotSupported";
            this.cbxNotSupported.Size = new System.Drawing.Size(215, 17);
            this.cbxNotSupported.TabIndex = 2;
            this.cbxNotSupported.Text = "Not supported by the selected provider";
            this.cbxNotSupported.UseVisualStyleBackColor = true;
            this.cbxNotSupported.CheckedChanged += new System.EventHandler(this.cbxNotSupported_CheckedChanged);
            // 
            // gpxTemplateParameters
            // 
            this.gpxTemplateParameters.Controls.Add(this.listTemplateParameters);
            this.gpxTemplateParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxTemplateParameters.Location = new System.Drawing.Point(0, 0);
            this.gpxTemplateParameters.Name = "gpxTemplateParameters";
            this.gpxTemplateParameters.Size = new System.Drawing.Size(125, 337);
            this.gpxTemplateParameters.TabIndex = 0;
            this.gpxTemplateParameters.TabStop = false;
            this.gpxTemplateParameters.Text = "Template parameters";
            // 
            // listTemplateParameters
            // 
            this.listTemplateParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colParameter});
            this.listTemplateParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTemplateParameters.FullRowSelect = true;
            this.listTemplateParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listTemplateParameters.Location = new System.Drawing.Point(3, 17);
            this.listTemplateParameters.Name = "listTemplateParameters";
            this.listTemplateParameters.Size = new System.Drawing.Size(119, 317);
            this.listTemplateParameters.TabIndex = 0;
            this.listTemplateParameters.UseCompatibleStateImageBehavior = false;
            this.listTemplateParameters.View = System.Windows.Forms.View.Details;
            this.listTemplateParameters.DoubleClick += new System.EventHandler(this.listTemplateParameters_DoubleClick);
            this.listTemplateParameters.Resize += new System.EventHandler(this.listTemplateParameters_Resize);
            // 
            // colParameter
            // 
            this.colParameter.Text = "Parameter";
            this.colParameter.Width = 96;
            // 
            // lblNextVariant
            // 
            this.lblNextVariant.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNextVariant.AutoSize = true;
            this.lblNextVariant.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblNextVariant.Location = new System.Drawing.Point(168, 523);
            this.lblNextVariant.Name = "lblNextVariant";
            this.lblNextVariant.Size = new System.Drawing.Size(82, 13);
            this.lblNextVariant.TabIndex = 4;
            this.lblNextVariant.TabStop = true;
            this.lblNextVariant.Text = "Next variant ...";
            this.lblNextVariant.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNextVariant_LinkClicked);
            // 
            // lblPreviousVariant
            // 
            this.lblPreviousVariant.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPreviousVariant.AutoSize = true;
            this.lblPreviousVariant.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblPreviousVariant.Location = new System.Drawing.Point(57, 523);
            this.lblPreviousVariant.Name = "lblPreviousVariant";
            this.lblPreviousVariant.Size = new System.Drawing.Size(100, 13);
            this.lblPreviousVariant.TabIndex = 4;
            this.lblPreviousVariant.TabStop = true;
            this.lblPreviousVariant.Text = "Previous variant ...";
            this.lblPreviousVariant.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPreviousVariant_LinkClicked);
            // 
            // lblTest
            // 
            this.lblTest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTest.AutoSize = true;
            this.lblTest.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblTest.Location = new System.Drawing.Point(3, 523);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(43, 13);
            this.lblTest.TabIndex = 4;
            this.lblTest.TabStop = true;
            this.lblTest.Text = "Test ...";
            this.lblTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTest_LinkClicked);
            // 
            // warningProvider
            // 
            this.warningProvider.ContainerControl = this;
            this.warningProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("warningProvider.Icon")));
            // 
            // QueryVariantDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QueryVariantDetail";
            this.Size = new System.Drawing.Size(789, 542);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpxQueryVariant.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gpxSelectedAnnotations.ResumeLayout(false);
            this.splitContainerParameters.Panel1.ResumeLayout(false);
            this.splitContainerParameters.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerParameters)).EndInit();
            this.splitContainerParameters.ResumeLayout(false);
            this.gpxStatement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbStatement)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gpxTemplateParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gpxQueryVariant;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpxStatement;
        private FastColoredTextBoxNS.FastColoredTextBox fctbStatement;
        private System.Windows.Forms.LinkLabel lblPreviousVariant;
        private System.Windows.Forms.LinkLabel lblNextVariant;
        private System.Windows.Forms.LinkLabel lblTest;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ErrorProvider warningProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DbProviderComboBox dbProviderComboBox;
        private System.Windows.Forms.Button btnChangeImplementation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxNotSupported;
        private System.Windows.Forms.SplitContainer splitContainerParameters;
        private System.Windows.Forms.GroupBox gpxTemplateParameters;
        private System.Windows.Forms.ListView listTemplateParameters;
        private System.Windows.Forms.ColumnHeader colParameter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gpxSelectedAnnotations;
        private AnnotationCheckListBox selectedAnnotationsClb;
    }
}
