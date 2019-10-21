namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    partial class BenchmarkObjectEditor
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
            this.connectionSettingsDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.ConnectionSettingsDetail();
            this.queryVariantDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.QueryVariantDetail();
            this.planEquivalenceTestDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.PlanEquivalenceTestDetail();
            this.configurationDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.ConfigurationDetail();
            this.testGroupDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.TestGroupDetail();
            this.scriptDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.ScriptDetail();
            this.benchmarkDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.BenchmarkDetail();
            this.testRunDetail = new SqlOptimizerBenchmark.Controls.BenchmarkObjectControls.TestRunDetail();
            this.SuspendLayout();
            // 
            // connectionSettingsDetail
            // 
            this.connectionSettingsDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectionSettingsDetail.Location = new System.Drawing.Point(13, 507);
            this.connectionSettingsDetail.Name = "connectionSettingsDetail";
            this.connectionSettingsDetail.Size = new System.Drawing.Size(302, 182);
            this.connectionSettingsDetail.TabIndex = 6;
            this.connectionSettingsDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // queryVariantDetail
            // 
            this.queryVariantDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.queryVariantDetail.Location = new System.Drawing.Point(596, 250);
            this.queryVariantDetail.Name = "queryVariantDetail";
            this.queryVariantDetail.Size = new System.Drawing.Size(273, 260);
            this.queryVariantDetail.TabIndex = 5;
            this.queryVariantDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // planEquivalenceTestDetail
            // 
            this.planEquivalenceTestDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.planEquivalenceTestDetail.Location = new System.Drawing.Point(321, 250);
            this.planEquivalenceTestDetail.Name = "planEquivalenceTestDetail";
            this.planEquivalenceTestDetail.Size = new System.Drawing.Size(269, 260);
            this.planEquivalenceTestDetail.TabIndex = 4;
            this.planEquivalenceTestDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // configurationDetail
            // 
            this.configurationDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.configurationDetail.Location = new System.Drawing.Point(13, 250);
            this.configurationDetail.Name = "configurationDetail";
            this.configurationDetail.Size = new System.Drawing.Size(302, 260);
            this.configurationDetail.TabIndex = 3;
            this.configurationDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // testGroupDetail
            // 
            this.testGroupDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.testGroupDetail.Location = new System.Drawing.Point(596, 7);
            this.testGroupDetail.Name = "testGroupDetail";
            this.testGroupDetail.Size = new System.Drawing.Size(273, 237);
            this.testGroupDetail.TabIndex = 2;
            this.testGroupDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // scriptDetail
            // 
            this.scriptDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scriptDetail.Location = new System.Drawing.Point(321, 3);
            this.scriptDetail.Name = "scriptDetail";
            this.scriptDetail.Size = new System.Drawing.Size(269, 241);
            this.scriptDetail.TabIndex = 1;
            this.scriptDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // benchmarkDetail
            // 
            this.benchmarkDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.benchmarkDetail.Location = new System.Drawing.Point(13, 3);
            this.benchmarkDetail.Name = "benchmarkDetail";
            this.benchmarkDetail.Size = new System.Drawing.Size(302, 241);
            this.benchmarkDetail.TabIndex = 0;
            this.benchmarkDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // testRunDetail
            // 
            this.testRunDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.testRunDetail.Location = new System.Drawing.Point(321, 507);
            this.testRunDetail.Name = "testRunDetail";
            this.testRunDetail.Size = new System.Drawing.Size(269, 207);
            this.testRunDetail.TabIndex = 7;
            this.testRunDetail.NavigateBenchmarkObject += new SqlOptimizerBenchmark.Controls.BenchmarkObjectEventHandler(this.detail_NavigateBenchmarkObject);
            // 
            // BenchmarkObjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testRunDetail);
            this.Controls.Add(this.connectionSettingsDetail);
            this.Controls.Add(this.queryVariantDetail);
            this.Controls.Add(this.planEquivalenceTestDetail);
            this.Controls.Add(this.configurationDetail);
            this.Controls.Add(this.testGroupDetail);
            this.Controls.Add(this.scriptDetail);
            this.Controls.Add(this.benchmarkDetail);
            this.Name = "BenchmarkObjectEditor";
            this.Size = new System.Drawing.Size(929, 692);
            this.ResumeLayout(false);

        }

        #endregion

        private BenchmarkDetail benchmarkDetail;
        private ScriptDetail scriptDetail;
        private TestGroupDetail testGroupDetail;
        private ConfigurationDetail configurationDetail;
        private PlanEquivalenceTestDetail planEquivalenceTestDetail;
        private QueryVariantDetail queryVariantDetail;
        private ConnectionSettingsDetail connectionSettingsDetail;
        private TestRunDetail testRunDetail;
    }
}
