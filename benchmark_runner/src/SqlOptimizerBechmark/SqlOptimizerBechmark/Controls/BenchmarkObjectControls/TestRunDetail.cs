using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.BenchmarkObjectControls
{
    public partial class TestRunDetail : BenchmarkObjectDetail
    {
        public TestRunDetail()
        {
            InitializeComponent();
            Executor.Executor.Instance.Message += Instance_Message;
        }


        private delegate void AddMessageDelegate(Executor.ExecutorMessage message);

        private void AddMessage(Executor.ExecutorMessage message)
        {
            logBrowser.AddMessage(message);
        }

        private void Instance_Message(object sender, Executor.ExecutorMessageEventArgs e)
        {
            Invoke(new AddMessageDelegate(AddMessage), e.Message);
            Invoke(new MethodInvoker(UpdateSummary));

            //DateTime now = DateTime.Now;
            //Color color = SystemColors.WindowText;

            //string messageTypeStr = string.Empty;
            //switch (e.MessageType)
            //{
            //    case Executor.ExecutorMessageType.Error:
            //        messageTypeStr = "ERROR";
            //        color = Color.Red;
            //        break;

            //    case Executor.ExecutorMessageType.StatementCompleted:
            //        messageTypeStr = "STATEMENT COMPLETED";
            //        color = Color.Blue;
            //        break;

            //    case Executor.ExecutorMessageType.QueryExecuted:
            //        messageTypeStr = "QUERY EXECUTED";
            //        color = Color.Blue;
            //        break;

            //    case Executor.ExecutorMessageType.UserCancelled:
            //        messageTypeStr = "USER CANCELLED TESTING";
            //        color = Color.Red;
            //        break;

            //    case Executor.ExecutorMessageType.UserInterrupt:
            //        messageTypeStr = "USER INTERRUPT TESTING";
            //        color = Color.Red;
            //        break;

            //    case Executor.ExecutorMessageType.TestCompleted:
            //        messageTypeStr = "TEST COMPLETED";
            //        color = Color.Blue;
            //        break;
            //}

            //string str = string.Format("{0}: {1}\r\n{2}",
            //    now.ToString("HH:mm:ss"),
            //    messageTypeStr,
            //    e.Message);

            //Invoke(new AppendTextDelegate(AppendText), str, color);

            //if (e.MessageType == Executor.ExecutorMessageType.TestCompleted)
            //{
            //    Invoke(new MethodInvoker(UpdateSummary));
            //}
        }

        private Benchmark.TestRun TestRun => (Benchmark.TestRun)BenchmarkObject;

        protected override void BindControls()
        {
            if (TestRun == null)
            {
                return;
            }

            testResultsBrowser.TestRun = TestRun;

            UpdateSummary();

            base.BindControls();
        }

        protected override void UpdateUI()
        {
            if (TestRun == null)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
            }
        }

        private void UpdateSummary()
        {
            int total = 0;
            int processed = 0;
            int passed = 0;
            int failed = 0;
            int errors = 0;
            
            Benchmark.TestRun testRun = TestRun;
            foreach (Benchmark.TestResult testResult in testRun.TestResults)
            {
                if (testResult is Benchmark.PlanEquivalenceTestResult planEquivalenceTestResult)
                {
                    total++;
                    if (planEquivalenceTestResult.Completed)
                    {
                        processed++;


                        bool error = false;
                        foreach (Benchmark.QueryVariantResult queryVariantResult in planEquivalenceTestResult.QueryVariantResults)
                        {
                            if (queryVariantResult.ErrorMessage != string.Empty)
                            {
                                error = true;
                                break;
                            }
                        }
                        if (error)
                        {
                            errors++;
                        }
                        else
                        {
                            if (planEquivalenceTestResult.Success)
                            {
                                passed++;
                            }
                            else
                            {
                                failed++;
                            }
                        }
                    }
                }
            }

            lblTestsProcessed.Text = Convert.ToString(processed);
            lblTestsPassed.Text = Convert.ToString(passed);
            lblTestsFailed.Text = Convert.ToString(failed);
            lblErrors.Text = Convert.ToString(errors);

            lblSuccess.Text = processed > 0 ? (passed / (double)processed).ToString("p2") : string.Empty;

            if (total > 0)
            {
                progressBar.Value = processed * 100 / total;
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            logBrowser.Clear();
        }

        private void testResultsBrowser_NavigateBenchmarkObject(object sender, BenchmarkObjectEventArgs e)
        {
            OnNavigateBenchmarkObject(e.BenchmarkObject);
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            CsvExportSettingsDialog dialog = new CsvExportSettingsDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Benchmark.CsvExportOptions exportOptions;
                if (dialog.DistinctPlans)
                {
                    exportOptions = Benchmark.CsvExportOptions.ExportDistinctPlans;
                }
                else if (dialog.QueryVariants)
                {
                    exportOptions = Benchmark.CsvExportOptions.ExportQueryVariants;
                }
                else
                {
                    exportOptions = Benchmark.CsvExportOptions.ExportQueryVariants;
                }

                string fileName = dialog.FileName;
                TestRun.ExportToCsv(fileName, exportOptions);
            }
        }
    }
}
