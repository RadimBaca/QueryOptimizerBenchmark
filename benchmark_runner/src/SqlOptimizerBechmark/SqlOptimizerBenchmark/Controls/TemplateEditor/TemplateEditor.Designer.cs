namespace SqlOptimizerBenchmark.Controls.TemplateEditor
{
    partial class TemplateEditor
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
            this.tsTemplates = new System.Windows.Forms.ToolStrip();
            this.btnAddTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnMoveTemplateUp = new System.Windows.Forms.ToolStripButton();
            this.btnMoveTemplateDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddParameter = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveParameter = new System.Windows.Forms.ToolStripButton();
            this.btnRenameParameter = new System.Windows.Forms.ToolStripButton();
            this.gridTemplates = new SqlOptimizerBenchmark.Controls.DataGridViewEx();
            this.tsTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemplates)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTemplates
            // 
            this.tsTemplates.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddTemplate,
            this.btnRemoveTemplate,
            this.btnMoveTemplateUp,
            this.btnMoveTemplateDown,
            this.toolStripSeparator1,
            this.btnAddParameter,
            this.btnRemoveParameter,
            this.btnRenameParameter});
            this.tsTemplates.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsTemplates.Location = new System.Drawing.Point(0, 0);
            this.tsTemplates.Name = "tsTemplates";
            this.tsTemplates.Size = new System.Drawing.Size(598, 23);
            this.tsTemplates.TabIndex = 2;
            this.tsTemplates.Text = "toolStrip1";
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddTemplate.Image = global::SqlOptimizerBenchmark.Properties.Resources.Add_16;
            this.btnAddTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(23, 20);
            this.btnAddTemplate.Text = "Add template";
            this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // btnRemoveTemplate
            // 
            this.btnRemoveTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveTemplate.Image = global::SqlOptimizerBenchmark.Properties.Resources.Remove_16;
            this.btnRemoveTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveTemplate.Name = "btnRemoveTemplate";
            this.btnRemoveTemplate.Size = new System.Drawing.Size(23, 20);
            this.btnRemoveTemplate.Text = "Remove template";
            this.btnRemoveTemplate.Click += new System.EventHandler(this.btnRemoveTemplate_Click);
            // 
            // btnMoveTemplateUp
            // 
            this.btnMoveTemplateUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveTemplateUp.Image = global::SqlOptimizerBenchmark.Properties.Resources.Up_16;
            this.btnMoveTemplateUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveTemplateUp.Name = "btnMoveTemplateUp";
            this.btnMoveTemplateUp.Size = new System.Drawing.Size(23, 20);
            this.btnMoveTemplateUp.Text = "Move template up";
            this.btnMoveTemplateUp.Click += new System.EventHandler(this.btnMoveTemplateUp_Click);
            // 
            // btnMoveTemplateDown
            // 
            this.btnMoveTemplateDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveTemplateDown.Image = global::SqlOptimizerBenchmark.Properties.Resources.Down_16;
            this.btnMoveTemplateDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveTemplateDown.Name = "btnMoveTemplateDown";
            this.btnMoveTemplateDown.Size = new System.Drawing.Size(23, 20);
            this.btnMoveTemplateDown.Text = "Move template down";
            this.btnMoveTemplateDown.Click += new System.EventHandler(this.btnMoveTemplateDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddParameter.Image = global::SqlOptimizerBenchmark.Properties.Resources.NewParameter_16;
            this.btnAddParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(23, 20);
            this.btnAddParameter.Text = "Add parameter";
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // btnRemoveParameter
            // 
            this.btnRemoveParameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveParameter.Image = global::SqlOptimizerBenchmark.Properties.Resources.DeleteParameter_16;
            this.btnRemoveParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveParameter.Name = "btnRemoveParameter";
            this.btnRemoveParameter.Size = new System.Drawing.Size(23, 20);
            this.btnRemoveParameter.Text = "Remove parameter";
            this.btnRemoveParameter.Click += new System.EventHandler(this.btnRemoveParameter_Click);
            // 
            // btnRenameParameter
            // 
            this.btnRenameParameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRenameParameter.Image = global::SqlOptimizerBenchmark.Properties.Resources.RenameParameter_16;
            this.btnRenameParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenameParameter.Name = "btnRenameParameter";
            this.btnRenameParameter.Size = new System.Drawing.Size(23, 20);
            this.btnRenameParameter.Text = "Rename parameter";
            this.btnRenameParameter.Click += new System.EventHandler(this.btnRenameParameter_Click);
            // 
            // gridTemplates
            // 
            this.gridTemplates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTemplates.Location = new System.Drawing.Point(0, 23);
            this.gridTemplates.Name = "gridTemplates";
            this.gridTemplates.Size = new System.Drawing.Size(598, 366);
            this.gridTemplates.TabIndex = 3;
            this.gridTemplates.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridTemplates_CellPainting);
            this.gridTemplates.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTemplates_CellValueChanged);
            this.gridTemplates.SelectionChanged += new System.EventHandler(this.gridTemplates_SelectionChanged);
            // 
            // TemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTemplates);
            this.Controls.Add(this.tsTemplates);
            this.Name = "TemplateEditor";
            this.Size = new System.Drawing.Size(598, 389);
            this.tsTemplates.ResumeLayout(false);
            this.tsTemplates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemplates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsTemplates;
        private System.Windows.Forms.ToolStripButton btnAddTemplate;
        private System.Windows.Forms.ToolStripButton btnRemoveTemplate;
        private System.Windows.Forms.ToolStripButton btnMoveTemplateUp;
        private System.Windows.Forms.ToolStripButton btnMoveTemplateDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddParameter;
        private System.Windows.Forms.ToolStripButton btnRemoveParameter;
        private System.Windows.Forms.ToolStripButton btnRenameParameter;
        private DataGridViewEx gridTemplates;
    }
}
