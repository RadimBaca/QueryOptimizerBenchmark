namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    partial class ScriptDetail
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
            this.statementListEditor = new SqlOptimizerBenchmark.Controls.StatementListEditor();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dbProviderComboBox = new SqlOptimizerBenchmark.Controls.DbProviderComboBox();
            this.btnChangeImplementation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statementListEditor
            // 
            this.statementListEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statementListEditor.Location = new System.Drawing.Point(0, 29);
            this.statementListEditor.Name = "statementListEditor";
            this.statementListEditor.Size = new System.Drawing.Size(457, 509);
            this.statementListEditor.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dbProviderComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeImplementation, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dbProviderComboBox
            // 
            this.dbProviderComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dbProviderComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dbProviderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbProviderComboBox.FormattingEnabled = true;
            this.dbProviderComboBox.Location = new System.Drawing.Point(64, 3);
            this.dbProviderComboBox.Name = "dbProviderComboBox";
            this.dbProviderComboBox.SelectedDbProvider = null;
            this.dbProviderComboBox.Size = new System.Drawing.Size(215, 22);
            this.dbProviderComboBox.TabIndex = 0;
            this.dbProviderComboBox.ProviderImplemented += new SqlOptimizerBenchmark.Controls.DbProviderComboBox.ProviderImplementedEventHandler(this.dbProviderComboBox_ProviderImplemented);
            this.dbProviderComboBox.SelectedIndexChanged += new System.EventHandler(this.dbProviderComboBox_SelectedIndexChanged);
            // 
            // btnChangeImplementation
            // 
            this.btnChangeImplementation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeImplementation.Location = new System.Drawing.Point(282, 2);
            this.btnChangeImplementation.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnChangeImplementation.Name = "btnChangeImplementation";
            this.btnChangeImplementation.Size = new System.Drawing.Size(74, 23);
            this.btnChangeImplementation.TabIndex = 1;
            this.btnChangeImplementation.Text = "Implement";
            this.btnChangeImplementation.UseVisualStyleBackColor = true;
            this.btnChangeImplementation.Click += new System.EventHandler(this.btnChangeImplementation_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Provider:";
            // 
            // ScriptDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statementListEditor);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScriptDetail";
            this.Size = new System.Drawing.Size(457, 538);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private StatementListEditor statementListEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DbProviderComboBox dbProviderComboBox;
        private System.Windows.Forms.Button btnChangeImplementation;
        private System.Windows.Forms.Label label1;
    }
}
