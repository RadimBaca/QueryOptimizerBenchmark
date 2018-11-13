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
            this.gpxQueryVariant = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.gpxStatement = new System.Windows.Forms.GroupBox();
            this.fctbStatement = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lblNextVariant = new System.Windows.Forms.LinkLabel();
            this.lblPreviousVariant = new System.Windows.Forms.LinkLabel();
            this.lblTest = new System.Windows.Forms.LinkLabel();
            this.warningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gpxQueryVariant.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpxStatement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbStatement)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.gpxQueryVariant);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gpxStatement);
            this.splitContainer.Size = new System.Drawing.Size(783, 511);
            this.splitContainer.SplitterDistance = 170;
            this.splitContainer.TabIndex = 2;
            // 
            // gpxQueryVariant
            // 
            this.gpxQueryVariant.Controls.Add(this.tableLayoutPanel2);
            this.gpxQueryVariant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxQueryVariant.Location = new System.Drawing.Point(0, 0);
            this.gpxQueryVariant.Name = "gpxQueryVariant";
            this.gpxQueryVariant.Size = new System.Drawing.Size(783, 170);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(777, 150);
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
            this.txtDescription.Size = new System.Drawing.Size(697, 94);
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
            // gpxStatement
            // 
            this.gpxStatement.Controls.Add(this.fctbStatement);
            this.gpxStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxStatement.Location = new System.Drawing.Point(0, 0);
            this.gpxStatement.Name = "gpxStatement";
            this.gpxStatement.Size = new System.Drawing.Size(783, 337);
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
            this.fctbStatement.IsReplaceMode = false;
            this.fctbStatement.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctbStatement.LeftBracket = '(';
            this.fctbStatement.Location = new System.Drawing.Point(3, 17);
            this.fctbStatement.Name = "fctbStatement";
            this.fctbStatement.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbStatement.RightBracket = ')';
            this.fctbStatement.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbStatement.Size = new System.Drawing.Size(777, 317);
            this.fctbStatement.TabIndex = 0;
            this.fctbStatement.Text = "fastColoredTextBox1";
            this.fctbStatement.Zoom = 100;
            this.fctbStatement.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbStatement_TextChangedDelayed);
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
            this.gpxQueryVariant.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gpxStatement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbStatement)).EndInit();
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
    }
}
