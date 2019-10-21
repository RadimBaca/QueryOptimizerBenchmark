using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark
{
    public partial class FormMain : Form
    {
        private Benchmark.Benchmark benchmark;
        private string fileName;
        private bool changed = false;

        public FormMain()
        {
            InitializeComponent();

            Executor.Executor.Instance.TestingStarted += Instance_TestingStarted;
            Executor.Executor.Instance.TestingEnded += Instance_TestingEnded;
            Executor.Executor.Instance.InvokeStartTesting += Instance_InvokeStartTesting;
            Executor.Executor.Instance.InvokeClose += Instance_InvokeClose;
        }

        private void SaveAndClose()
        {
            Save();
            Close();
        }

        private void Instance_InvokeClose(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(SaveAndClose));
        }

        private void Instance_InvokeStartTesting(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(Executor.Executor.Instance.PrepareAndStart));
        }

        private void Instance_TestingStarted(object sender, EventArgs e)
        {
            benchmarkTreeView.SelectedBenchmarkObject = Executor.Executor.Instance.TestRun;
            benchmarkObjectEditor.BenchmarkObject = Executor.Executor.Instance.TestRun;
            UpdateUI();
        }

        private void Instance_TestingEnded(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(UpdateUI));
        }

        private void Benchmark_Changed(object sender, EventArgs e)
        {
            if (!changed)
            {
                changed = true;
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            bool executorTesting = Executor.Executor.Instance.Testing;

            benchmarkTreeView.Enabled = !executorTesting;

            btnNavigateBack.Enabled = benchmarkObjectEditor.CanNavigateBack() && !executorTesting;
            mbtnNavigateBack.Enabled = benchmarkObjectEditor.CanNavigateBack() && !executorTesting;
            btnNavigateForward.Enabled = benchmarkObjectEditor.CanNavigateForward() && !executorTesting;
            mbtnNavigateForward.Enabled = benchmarkObjectEditor.CanNavigateForward() && !executorTesting;
            btnActivateAll.Enabled = !executorTesting;
            mbtnActivateAll.Enabled = !executorTesting;
            btnDeactivateAll.Enabled = !executorTesting;
            mbtnDeactivateAll.Enabled = !executorTesting;
            btnNew.Enabled = !executorTesting; 
            mbtnNew.Enabled = !executorTesting;
            btnSave.Enabled = !executorTesting;
            mbtnSave.Enabled = !executorTesting;
            mbtnSaveAs.Enabled = !executorTesting;
            btnOpen.Enabled = !executorTesting;
            mbtnOpen.Enabled = !executorTesting;
            btnLaunchTest.Enabled = !executorTesting;
            mbtnLaunchTest.Enabled = !executorTesting;

            btnStop.Enabled = executorTesting;
            mbtnStop.Enabled = executorTesting;
            btnInterrupt.Enabled = executorTesting;
            mbtnInterrupt.Enabled = executorTesting;

            string appName = "SQL Optimizer Benchmark";
            string text = appName;

            if (fileName != null)
            {
                text += string.Format(" [{0}]", fileName);
            }
            
            if (changed)
            {
                text += "*";
            }

            Text = text;
        }

        public void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML document (*.xml)|*.xml|All files|*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                benchmark.Save(dialog.FileName);
                fileName = dialog.FileName;
                changed = false;
                UpdateUI();
                Cursor = Cursors.Default;
            }
        }

        private bool QuerySaveChanges()
        {
            if (changed)
            {
                string msg = "The current benchmark has been changed. Do you want to save the changes?";
                DialogResult result = MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                switch (result)
                {
                    case DialogResult.Yes:
                        Save();
                        return true;
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                    default:
                        return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void New()
        {
            if (!QuerySaveChanges())
            {
                return;
            }

            benchmark = new Benchmark.Benchmark();
            benchmark.Name = "New benchmark";
            benchmarkTreeView.Benchmark = benchmark;
            benchmarkObjectEditor.Benchmark = benchmark;
            benchmark.Changed += Benchmark_Changed;

            benchmarkTreeView.SelectedBenchmarkObject = benchmark;
            benchmarkTreeView.GetTreeNode(benchmark).Expand();
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                Cursor = Cursors.WaitCursor;
                benchmark.Save(fileName);
                changed = false;
                UpdateUI();
                Cursor = Cursors.Default;
            }
            else
            {
                SaveAs();
            }
        }

        private void OpenBenchmarkFileName(string fileName)
        {
            Cursor = Cursors.WaitCursor;

            benchmark = new Benchmark.Benchmark();
            benchmark.Load(fileName);

            benchmarkTreeView.Benchmark = benchmark;
            benchmarkObjectEditor.Benchmark = benchmark;

            benchmarkTreeView.SelectedBenchmarkObject = benchmark;
            benchmarkTreeView.GetTreeNode(benchmark).Expand();

            benchmark.Changed += Benchmark_Changed;

            this.fileName = fileName;

            changed = false;
            UpdateUI();
            Cursor = Cursors.Default;
        }

        public void Open()
        {
            if (!QuerySaveChanges())
            {
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML document (*.xml)|*.xml|All files|*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OpenBenchmarkFileName(dialog.FileName);
            }
        }

        private void ActivateAll()
        {
            foreach (Benchmark.TestGroup testGroup in benchmark.TestGroups)
            {
                foreach (Benchmark.Test test in testGroup.Tests)
                {
                    test.Active = true;
                }
            }
        }

        private void DeactivateAll()
        {
            foreach (Benchmark.TestGroup testGroup in benchmark.TestGroups)
            {
                foreach (Benchmark.Test test in testGroup.Tests)
                {
                    test.Active = false;
                }
            }
        }

        private void LaunchTest()
        {
            Executor.Executor.Instance.LaunchTest(benchmark);
        }

        private void StopTesting()
        {
            Executor.Executor.Instance.StopTesting();
        }

        private void InterruptTesting()
        {
            Executor.Executor.Instance.InterruptTesting();
        }

        private void ExportTestingScript()
        {
            if (benchmark.ConnectionSettings.DbProvider == null)
            {
                MessageBox.Show("Database provider must be set.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SQL Script (*.sql)|*.sql|All files|*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string script = benchmark.ConnectionSettings.DbProvider.GetTestingScript(benchmark);
                System.IO.File.WriteAllText(dialog.FileName, script);
            }
        }

        private void ExportToFileSystem()
        {
            if (benchmark.ConnectionSettings.DbProvider == null)
            {
                MessageBox.Show("Database provider must be set.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                benchmark.ConnectionSettings.DbProvider.ExportToFileSystem(dialog.SelectedPath, benchmark);
            }
        }

        private bool IsTrueStr(string str)
        {
            return
                string.Compare(str, "yes", true) == 0 ||
                string.Compare(str, "1", true) == 0 ||
                string.Compare(str, "y", true) == 0 ||
                string.Compare(str, "true", true) == 0;
        }
        
        private bool IsFalseStr(string str)
        {
            return
                string.Compare(str, "no", true) == 0 ||
                string.Compare(str, "0", true) == 0 ||
                string.Compare(str, "n", true) == 0 ||
                string.Compare(str, "false", true) == 0;
        }

        private bool IsBoolString(string str)
        {
            return IsTrueStr(str) || IsFalseStr(str);
        }

        private void ExportAll(string connectionString, bool closeOnComplete)
        {
            try
            {
                if (benchmark == null)
                {
                    throw new Exception("Any benchmark is not open.");
                }

                DbProviders.SqlServer.SqlServerProvider sqlServerProvider = new DbProviders.SqlServer.SqlServerProvider();
                sqlServerProvider.ConnectionString = connectionString;
                sqlServerProvider.UseConnectionString = true;
                sqlServerProvider.Connect();

                DbProviders.DbBenchmarkObjectWriter writer = sqlServerProvider.CreateBenchmarkObjectWriter();
                
                foreach (Benchmark.TestRun testRun in benchmark.TestRuns)
                {
                    writer.WriteToDb(testRun);
                }

                sqlServerProvider.Close();

                if (closeOnComplete)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Process command line arguments.
        /// </summary>
        private void ParseArgs(string[] args)
        {
            try
            {
                string openBenchmarkFileName = null;
                string connectionString = null;
                bool? runInitScript = null;
                bool? runCleanUpScript = null;
                bool? checkResultSizes = null;
                bool? compareResults = null;
                int? queryRuns = null;
                int? testLoops = null;
                bool? closeOnComplete = null;

                bool launch = false;
                bool exportAll = false;

                if (args.Length == 2)
                {
                    openBenchmarkFileName = args[1];
                }
                else
                {
                    // Skip the first argument - the application startup path.
                    int i = 1;
                    while (i < args.Length)
                    {
                        string currentArg = args[i];
                        string nextArg = i < args.Length - 1 ? args[i + 1] : string.Empty;

                        if (string.Compare(currentArg, "/Launch", true) == 0)
                        {
                            launch = true;
                        }

                        if (string.Compare(currentArg, "/ExportAll", true) == 0)
                        {
                            exportAll = true;
                        }


                        if (string.Compare(currentArg, "/FileName", true) == 0)
                        {
                            openBenchmarkFileName = nextArg;
                            i++;
                        }

                        if (string.Compare(currentArg, "/ConnectionString", true) == 0)
                        {
                            connectionString = nextArg;
                            i++;
                        }

                        if (string.Compare(currentArg, "/RunInitScript", true) == 0)
                        {
                            if (IsBoolString(nextArg))
                            {
                                runInitScript = IsTrueStr(nextArg);
                                i++;
                            }
                            else
                            {
                                runInitScript = true;
                            }
                        }

                        if (string.Compare(currentArg, "/RunCleanUpScript", true) == 0)
                        {
                            if (IsBoolString(nextArg))
                            {
                                runCleanUpScript = IsTrueStr(nextArg);
                                i++;
                            }
                            else
                            {
                                runCleanUpScript = true;
                            }
                        }

                        if (string.Compare(currentArg, "/CheckResultSizes", true) == 0)
                        {
                            if (IsBoolString(nextArg))
                            {
                                checkResultSizes = IsTrueStr(nextArg);
                                i++;
                            }
                            else
                            {
                                checkResultSizes = true;
                            }
                        }

                        if (string.Compare(currentArg, "/CompareResults", true) == 0)
                        {
                            if (IsBoolString(nextArg))
                            {
                                compareResults = IsTrueStr(nextArg);
                                i++;
                            }
                            else
                            {
                                compareResults = true;
                            }
                        }

                        if (string.Compare(currentArg, "/CloseOnComplete", true) == 0)
                        {
                            if (IsBoolString(nextArg))
                            {
                                closeOnComplete = IsTrueStr(nextArg);
                                i++;
                            }
                            else
                            {
                                closeOnComplete = true;
                            }
                        }

                        if (string.Compare(currentArg, "/QueryRuns", true) == 0)
                        {
                            queryRuns = Convert.ToInt32(nextArg);
                            if (queryRuns < 1)
                            {
                                queryRuns = 1;
                            }
                            if (queryRuns > 100)
                            {
                                queryRuns = 100;
                            }
                            i++;
                        }

                        if (string.Compare(currentArg, "/TestLoops", true) == 0)
                        {
                            testLoops = Convert.ToInt32(nextArg);
                            if (testLoops < 1)
                            {
                                testLoops = 1;
                            }
                            if (testLoops > 100)
                            {
                                testLoops = 100;
                            }
                            i++;
                        }

                        i++;
                    }
                }


                if (openBenchmarkFileName != null)
                {
                    OpenBenchmarkFileName(openBenchmarkFileName);

                    if (launch)
                    {
                        if (runInitScript.HasValue)
                        {
                            benchmark.TestRunSettings.RunInitScript = runInitScript.Value;
                        }
                        if (runCleanUpScript.HasValue)
                        {
                            benchmark.TestRunSettings.RunCleanUpScript = runCleanUpScript.Value;
                        }
                        if (checkResultSizes.HasValue)
                        {
                            benchmark.TestRunSettings.CheckResultSizes = checkResultSizes.Value;
                        }
                        if (compareResults.HasValue)
                        {
                            benchmark.TestRunSettings.CompareResults = compareResults.Value;
                        }
                        if (queryRuns.HasValue)
                        {
                            benchmark.TestRunSettings.QueryRuns = queryRuns.Value;
                        }
                        if (testLoops.HasValue)
                        {
                            benchmark.TestRunSettings.TestLoops = testLoops.Value;
                        }
                        if (closeOnComplete.HasValue)
                        {
                            benchmark.TestRunSettings.CloseOnComplete = closeOnComplete.Value;
                        }

                        Executor.Executor.Instance.LaunchTest(benchmark, true);
                    }

                    if (exportAll && !string.IsNullOrEmpty(connectionString))
                    {
                        ExportAll(connectionString, closeOnComplete.HasValue ? closeOnComplete.Value : false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void FormMain_Load(object sender, EventArgs e)
        {
            New();
            UpdateUI();

            string[] args = Environment.GetCommandLineArgs();

            ParseArgs(args);
        }

        private void benchmarkTreeView_SelectionChanged(object sender, EventArgs e)
        {
            benchmarkObjectEditor.BenchmarkObject = benchmarkTreeView.SelectedBenchmarkObject;
            UpdateUI();
        }

        private void benchmarkObjectEditor_NavigateBenchmarkObject(object sender, Controls.BenchmarkObjectEventArgs e)
        {
            benchmarkTreeView.SelectedBenchmarkObject = e.BenchmarkObject;
            UpdateUI();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Executor.Executor.Instance.Testing)
            {
                MessageBox.Show("Stop the testing before closing this window.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }

            if (!QuerySaveChanges())
            {
                e.Cancel = true;
                return;
            }

            Properties.Settings.Default.Save();
        }

        private void btnNavigateBack_Click(object sender, EventArgs e)
        {
            benchmarkObjectEditor.NavigateBack();
            UpdateUI();
        }

        private void btnNavigateForward_Click(object sender, EventArgs e)
        {
            benchmarkObjectEditor.NavigateForward();
            UpdateUI();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }
        private void mbtnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void mbtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void mbtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void mbtnOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void btnActivateAll_Click(object sender, EventArgs e)
        {
            ActivateAll();
        }

        private void btnDeactivateAll_Click(object sender, EventArgs e)
        {
            DeactivateAll();
        }

        private void btnLaunchTest_Click(object sender, EventArgs e)
        {
            LaunchTest();
        }

        private void mbtnLaunchTest_Click(object sender, EventArgs e)
        {
            LaunchTest();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopTesting();
        }

        private void mbtnStop_Click(object sender, EventArgs e)
        {
            StopTesting();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInterrupt_Click(object sender, EventArgs e)
        {
            InterruptTesting();
        }

        private void mbtnInterrupt_Click(object sender, EventArgs e)
        {
            InterruptTesting();
        }

        private void mbtnNavigateBack_Click(object sender, EventArgs e)
        {
            benchmarkObjectEditor.NavigateBack();
            UpdateUI();
        }

        private void mbtnNavigateForward_Click(object sender, EventArgs e)
        {
            benchmarkObjectEditor.NavigateForward();
            UpdateUI();
        }

        private void mbtnActivateAll_Click(object sender, EventArgs e)
        {
            ActivateAll();
        }

        private void mbtnDeactivateAll_Click(object sender, EventArgs e)
        {
            DeactivateAll();
        }

        private void mbtnAbout_Click(object sender, EventArgs e)
        {
            FormAbout dialog = new FormAbout();
            dialog.ShowDialog();
        }

        private void mbtnExportTestingScript_Click(object sender, EventArgs e)
        {
            ExportTestingScript();
        }

        private void exportToFileSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToFileSystem();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Benchmark.TestGroup group in benchmark.TestGroups)
            {
                group.Number = global::SqlOptimizerBenchmark.Controls.Helpers.GetNumber(++i, SqlOptimizerBenchmark.Controls.NumeralStyle.RomanUpper);

                int j = 0;

                foreach (Benchmark.Configuration config in group.Configurations)
                {
                    config.Number = global::SqlOptimizerBenchmark.Controls.Helpers.GetNumber(++j, SqlOptimizerBenchmark.Controls.NumeralStyle.AlphabeticUpper);
                }

                j = 0;

                foreach (Benchmark.Test test in group.Tests)
                {
                    test.Number = global::SqlOptimizerBenchmark.Controls.Helpers.GetNumber(++j, SqlOptimizerBenchmark.Controls.NumeralStyle.Arabic);

                    if (test is Benchmark.PlanEquivalenceTest planEquivalenceTest)
                    {
                        int k = 0;

                        foreach (Benchmark.QueryVariant variant in planEquivalenceTest.Variants)
                        {
                            variant.Number = global::SqlOptimizerBenchmark.Controls.Helpers.GetNumber(++k, SqlOptimizerBenchmark.Controls.NumeralStyle.AlphabeticLower);

                        }
                    }
                }
            }
        }

        private void tESTSQLScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection();
                connection.ConnectionString = "data source = (local); initial catalog = SqlBench_SQLite; integrated security = true";
                connection.Open();
                System.Data.SqlClient.SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT query_variant_result_id, query FROM sql_bench.QueryVariantResult";
                DataTable table = new DataTable();
                using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }

                System.Data.SqlClient.SqlCommand cmdUpdate = connection.CreateCommand();
                cmdUpdate.CommandText = "UPDATE sql_bench.QueryVariantResult SET token_count = @tokenCount WHERE query_variant_result_id = @id";
                cmdUpdate.Parameters.Add("tokenCount", SqlDbType.Int);
                cmdUpdate.Parameters.Add("id", SqlDbType.Int);

                foreach (DataRow row in table.Rows)
                {
                    int queryVariantResultId = Convert.ToInt32(row["query_variant_result_id"]);
                    string query = Convert.ToString(row["query"]);

                    Classes.SqlScanner scanner = new Classes.SqlScanner(query);
                    scanner.Scan();
                    int tokenCount = scanner.Tokens.Length;

                    cmdUpdate.Parameters["tokenCount"].Value = tokenCount;
                    cmdUpdate.Parameters["id"].Value = queryVariantResultId;
                    cmdUpdate.ExecuteNonQuery();
                }
                connection.Close();

                MessageBox.Show("Completed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tESTSQLFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlOptimizerBenchmark.Controls.FormattingGuideDialog dialog = new Controls.FormattingGuideDialog();
            dialog.Benchmark = benchmark;
            dialog.Show();
        }
    }
}