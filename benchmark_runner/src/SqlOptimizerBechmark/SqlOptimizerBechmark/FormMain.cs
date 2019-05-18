using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark
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
                Cursor = Cursors.WaitCursor;

                benchmark = new Benchmark.Benchmark();
                benchmark.Load(dialog.FileName);

                benchmarkTreeView.Benchmark = benchmark;
                benchmarkObjectEditor.Benchmark = benchmark;

                benchmarkTreeView.SelectedBenchmarkObject = benchmark;
                benchmarkTreeView.GetTreeNode(benchmark).Expand();

                benchmark.Changed += Benchmark_Changed;

                fileName = dialog.FileName;

                changed = false;
                UpdateUI();
                Cursor = Cursors.Default;
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
                
        private void FormMain_Load(object sender, EventArgs e)
        {
            New();
            UpdateUI();
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
                group.Number = global::SqlOptimizerBechmark.Controls.Helpers.GetNumber(++i, SqlOptimizerBechmark.Controls.NumeralStyle.RomanUpper);

                int j = 0;

                foreach (Benchmark.Configuration config in group.Configurations)
                {
                    config.Number = global::SqlOptimizerBechmark.Controls.Helpers.GetNumber(++j, SqlOptimizerBechmark.Controls.NumeralStyle.AlphabeticUpper);
                }

                j = 0;

                foreach (Benchmark.Test test in group.Tests)
                {
                    test.Number = global::SqlOptimizerBechmark.Controls.Helpers.GetNumber(++j, SqlOptimizerBechmark.Controls.NumeralStyle.Arabic);

                    if (test is Benchmark.PlanEquivalenceTest planEquivalenceTest)
                    {
                        int k = 0;

                        foreach (Benchmark.QueryVariant variant in planEquivalenceTest.Variants)
                        {
                            variant.Number = global::SqlOptimizerBechmark.Controls.Helpers.GetNumber(++k, SqlOptimizerBechmark.Controls.NumeralStyle.AlphabeticLower);

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
    }
}