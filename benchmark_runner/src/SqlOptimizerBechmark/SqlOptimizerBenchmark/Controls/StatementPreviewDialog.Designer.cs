namespace SqlOptimizerBenchmark.Controls
{
    partial class StatementPreviewDialog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatementPreviewDialog));
            this.btnClose = new System.Windows.Forms.Button();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStatement = new System.Windows.Forms.TabPage();
            this.pnlTokens = new System.Windows.Forms.Panel();
            this.lblTokens = new System.Windows.Forms.Label();
            this.tabQueryPlan = new System.Windows.Forms.TabPage();
            this.gridPlan = new SqlOptimizerBenchmark.Controls.DataGridViewEx();
            this.colOpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimatedCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimatedRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabStatement.SuspendLayout();
            this.pnlTokens.SuspendLayout();
            this.tabQueryPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(644, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fctb
            // 
            this.fctb.AutoCompleteBracketsList = new char[] {
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
            this.fctb.AutoIndentCharsPatterns = "";
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 14;
            this.fctb.CharWidth = 8;
            this.fctb.CommentPrefix = "--";
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctb.LeftBracket = '(';
            this.fctb.Location = new System.Drawing.Point(3, 3);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.ReadOnly = true;
            this.fctb.RightBracket = ')';
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.Size = new System.Drawing.Size(693, 320);
            this.fctb.TabIndex = 4;
            this.fctb.Zoom = 100;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabStatement);
            this.tabControl.Controls.Add(this.tabQueryPlan);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(707, 379);
            this.tabControl.TabIndex = 5;
            // 
            // tabStatement
            // 
            this.tabStatement.Controls.Add(this.fctb);
            this.tabStatement.Controls.Add(this.pnlTokens);
            this.tabStatement.Location = new System.Drawing.Point(4, 22);
            this.tabStatement.Name = "tabStatement";
            this.tabStatement.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatement.Size = new System.Drawing.Size(699, 353);
            this.tabStatement.TabIndex = 0;
            this.tabStatement.Text = "Statement";
            this.tabStatement.UseVisualStyleBackColor = true;
            // 
            // pnlTokens
            // 
            this.pnlTokens.Controls.Add(this.lblTokens);
            this.pnlTokens.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTokens.Location = new System.Drawing.Point(3, 323);
            this.pnlTokens.Name = "pnlTokens";
            this.pnlTokens.Size = new System.Drawing.Size(693, 27);
            this.pnlTokens.TabIndex = 5;
            // 
            // lblTokens
            // 
            this.lblTokens.AutoSize = true;
            this.lblTokens.Location = new System.Drawing.Point(6, 7);
            this.lblTokens.Name = "lblTokens";
            this.lblTokens.Size = new System.Drawing.Size(43, 13);
            this.lblTokens.TabIndex = 0;
            this.lblTokens.Text = "Tokens";
            // 
            // tabQueryPlan
            // 
            this.tabQueryPlan.Controls.Add(this.gridPlan);
            this.tabQueryPlan.Location = new System.Drawing.Point(4, 22);
            this.tabQueryPlan.Name = "tabQueryPlan";
            this.tabQueryPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabQueryPlan.Size = new System.Drawing.Size(699, 353);
            this.tabQueryPlan.TabIndex = 1;
            this.tabQueryPlan.Text = "Query plan";
            this.tabQueryPlan.UseVisualStyleBackColor = true;
            // 
            // gridPlan
            // 
            this.gridPlan.AllowUserToAddRows = false;
            this.gridPlan.AllowUserToDeleteRows = false;
            this.gridPlan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOpName,
            this.colEstimatedCost,
            this.colActualTime,
            this.colEstimatedRows,
            this.colActualRows});
            this.gridPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlan.Location = new System.Drawing.Point(3, 3);
            this.gridPlan.Name = "gridPlan";
            this.gridPlan.ReadOnly = true;
            this.gridPlan.RowTemplate.Height = 18;
            this.gridPlan.Size = new System.Drawing.Size(693, 347);
            this.gridPlan.TabIndex = 0;
            // 
            // colOpName
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colOpName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOpName.HeaderText = "Operation";
            this.colOpName.Name = "colOpName";
            this.colOpName.ReadOnly = true;
            this.colOpName.Width = 200;
            // 
            // colEstimatedCost
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colEstimatedCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEstimatedCost.HeaderText = "Cost";
            this.colEstimatedCost.Name = "colEstimatedCost";
            this.colEstimatedCost.ReadOnly = true;
            // 
            // colActualTime
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colActualTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colActualTime.HeaderText = "Actual time";
            this.colActualTime.Name = "colActualTime";
            this.colActualTime.ReadOnly = true;
            // 
            // colEstimatedRows
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colEstimatedRows.DefaultCellStyle = dataGridViewCellStyle4;
            this.colEstimatedRows.HeaderText = "Estim. rows";
            this.colEstimatedRows.Name = "colEstimatedRows";
            this.colEstimatedRows.ReadOnly = true;
            // 
            // colActualRows
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colActualRows.DefaultCellStyle = dataGridViewCellStyle5;
            this.colActualRows.HeaderText = "Actual rows";
            this.colActualRows.Name = "colActualRows";
            this.colActualRows.ReadOnly = true;
            // 
            // StatementPreviewDialog
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 432);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatementPreviewDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Statement";
            this.Load += new System.EventHandler(this.StatementPreviewDialog_Load);
            this.Shown += new System.EventHandler(this.StatementPreviewDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabStatement.ResumeLayout(false);
            this.pnlTokens.ResumeLayout(false);
            this.pnlTokens.PerformLayout();
            this.tabQueryPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStatement;
        private System.Windows.Forms.TabPage tabQueryPlan;
        private DataGridViewEx gridPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimatedCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimatedRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualRows;
        private System.Windows.Forms.Panel pnlTokens;
        private System.Windows.Forms.Label lblTokens;
    }
}