﻿namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    partial class BenchmarkDetail
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gpxBenchmark = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTestGroups = new System.Windows.Forms.TabPage();
            this.testGroupsListView = new SqlOptimizerBenchmark.Controls.BenchmarkListView.TestGroupsListView();
            this.tabAnnotations = new System.Windows.Forms.TabPage();
            this.gridAnnotations = new SqlOptimizerBenchmark.Controls.DataGridViewEx();
            this.colAnnotationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnotationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnotationDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInitScript = new System.Windows.Forms.LinkLabel();
            this.lblCleanUpScript = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gpxBenchmark.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTestGroups.SuspendLayout();
            this.tabAnnotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnotations)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblInitScript, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCleanUpScript, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 472);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer, 2);
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gpxBenchmark);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer.Size = new System.Drawing.Size(667, 441);
            this.splitContainer.SplitterDistance = 170;
            this.splitContainer.TabIndex = 2;
            // 
            // gpxBenchmark
            // 
            this.gpxBenchmark.Controls.Add(this.tableLayoutPanel2);
            this.gpxBenchmark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpxBenchmark.Location = new System.Drawing.Point(0, 0);
            this.gpxBenchmark.Name = "gpxBenchmark";
            this.gpxBenchmark.Size = new System.Drawing.Size(667, 170);
            this.gpxBenchmark.TabIndex = 0;
            this.gpxBenchmark.TabStop = false;
            this.gpxBenchmark.Text = "Benchmark";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDescription, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtAuthor, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(661, 150);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // txtName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtName, 2);
            this.txtName.Location = new System.Drawing.Point(77, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 21);
            this.txtName.TabIndex = 0;
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
            this.txtDescription.Size = new System.Drawing.Size(581, 94);
            this.txtDescription.TabIndex = 2;
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
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Author:";
            // 
            // txtAuthor
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtAuthor, 2);
            this.txtAuthor.Location = new System.Drawing.Point(77, 28);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(190, 21);
            this.txtAuthor.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTestGroups);
            this.tabControl1.Controls.Add(this.tabAnnotations);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 267);
            this.tabControl1.TabIndex = 3;
            // 
            // tabTestGroups
            // 
            this.tabTestGroups.Controls.Add(this.testGroupsListView);
            this.tabTestGroups.Location = new System.Drawing.Point(4, 22);
            this.tabTestGroups.Name = "tabTestGroups";
            this.tabTestGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestGroups.Size = new System.Drawing.Size(659, 241);
            this.tabTestGroups.TabIndex = 0;
            this.tabTestGroups.Text = "Test groups";
            this.tabTestGroups.UseVisualStyleBackColor = true;
            // 
            // testGroupsListView
            // 
            this.testGroupsListView.Benchmark = null;
            this.testGroupsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testGroupsListView.Location = new System.Drawing.Point(3, 3);
            this.testGroupsListView.Name = "testGroupsListView";
            this.testGroupsListView.Size = new System.Drawing.Size(653, 235);
            this.testGroupsListView.TabIndex = 0;
            this.testGroupsListView.BenchmarkObjectDoubleClick += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.testGroupsListView_BenchmarkObjectDoubleClick);
            // 
            // tabAnnotations
            // 
            this.tabAnnotations.Controls.Add(this.gridAnnotations);
            this.tabAnnotations.Location = new System.Drawing.Point(4, 22);
            this.tabAnnotations.Name = "tabAnnotations";
            this.tabAnnotations.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnnotations.Size = new System.Drawing.Size(659, 241);
            this.tabAnnotations.TabIndex = 1;
            this.tabAnnotations.Text = "Annotations";
            this.tabAnnotations.UseVisualStyleBackColor = true;
            // 
            // gridAnnotations
            // 
            this.gridAnnotations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridAnnotations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAnnotations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAnnotationNumber,
            this.colAnnotationName,
            this.colAnnotationDescription});
            this.gridAnnotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAnnotations.Location = new System.Drawing.Point(3, 3);
            this.gridAnnotations.Name = "gridAnnotations";
            this.gridAnnotations.Size = new System.Drawing.Size(653, 235);
            this.gridAnnotations.TabIndex = 0;
            this.gridAnnotations.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridAnnotations_UserDeletingRow);
            // 
            // colAnnotationNumber
            // 
            this.colAnnotationNumber.DataPropertyName = "Number";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAnnotationNumber.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAnnotationNumber.HeaderText = "Number";
            this.colAnnotationNumber.Name = "colAnnotationNumber";
            // 
            // colAnnotationName
            // 
            this.colAnnotationName.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAnnotationName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAnnotationName.HeaderText = "Name";
            this.colAnnotationName.Name = "colAnnotationName";
            // 
            // colAnnotationDescription
            // 
            this.colAnnotationDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAnnotationDescription.DataPropertyName = "Description";
            this.colAnnotationDescription.HeaderText = "Description";
            this.colAnnotationDescription.Name = "colAnnotationDescription";
            // 
            // lblInitScript
            // 
            this.lblInitScript.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInitScript.AutoSize = true;
            this.lblInitScript.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblInitScript.Location = new System.Drawing.Point(3, 453);
            this.lblInitScript.Name = "lblInitScript";
            this.lblInitScript.Size = new System.Drawing.Size(67, 13);
            this.lblInitScript.TabIndex = 3;
            this.lblInitScript.TabStop = true;
            this.lblInitScript.Text = "Init script ...";
            this.lblInitScript.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInitScript_LinkClicked);
            // 
            // lblCleanUpScript
            // 
            this.lblCleanUpScript.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCleanUpScript.AutoSize = true;
            this.lblCleanUpScript.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblCleanUpScript.Location = new System.Drawing.Point(95, 453);
            this.lblCleanUpScript.Name = "lblCleanUpScript";
            this.lblCleanUpScript.Size = new System.Drawing.Size(94, 13);
            this.lblCleanUpScript.TabIndex = 4;
            this.lblCleanUpScript.TabStop = true;
            this.lblCleanUpScript.Text = "Clean-up script ...";
            this.lblCleanUpScript.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCleanUpScript_LinkClicked);
            // 
            // BenchmarkDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BenchmarkDetail";
            this.Size = new System.Drawing.Size(673, 472);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gpxBenchmark.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabTestGroups.ResumeLayout(false);
            this.tabAnnotations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnotations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox gpxBenchmark;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblInitScript;
        private System.Windows.Forms.LinkLabel lblCleanUpScript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthor;
        private BenchmarkListView.TestGroupsListView testGroupsListView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTestGroups;
        private System.Windows.Forms.TabPage tabAnnotations;
        private DataGridViewEx gridAnnotations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnotationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnotationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnotationDescription;
    }
}
