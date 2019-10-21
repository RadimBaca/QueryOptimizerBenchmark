using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    public partial class BenchmarkObjectEditor : UserControl
    {
        private Benchmark.IBenchmarkObject benchmarkObject;
        private BenchmarkObjectDetail activeDetail;

        private Benchmark.Benchmark benchmark;

        private List<Benchmark.IBenchmarkObject> navigationHistory = new List<Benchmark.IBenchmarkObject>();
        private int navigationHistoryCurrentIndex = -1;
        private bool historyNavigation = false;
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benchmark.IBenchmarkObject BenchmarkObject
        {
            get => benchmarkObject;
            set
            {
                if (Executor.Executor.Instance.Testing &&
                    value != Executor.Executor.Instance.TestRun)
                {
                    return;
                }

                benchmarkObject = value;
                ShowDetail();

                if (!historyNavigation)
                {
                    if (navigationHistoryCurrentIndex < navigationHistory.Count - 1)
                    {
                        navigationHistory.RemoveRange(navigationHistoryCurrentIndex + 1,
                            navigationHistory.Count - navigationHistoryCurrentIndex - 1);
                    }

                    if (navigationHistory.Contains(benchmarkObject))
                    {
                        navigationHistory.Remove(benchmarkObject);
                    }

                    navigationHistory.Add(benchmarkObject);
                    navigationHistoryCurrentIndex = navigationHistory.Count - 1;
                }
            }
        }

        public Benchmark.Benchmark Benchmark
        {
            get => benchmark;
            set => benchmark = value;
        }

        public event BenchmarkObjectEventHandler NavigateBenchmarkObject;

        protected virtual void OnNavigateBenchmarkObject(Benchmark.IBenchmarkObject benchmarkObject)
        {
            if (NavigateBenchmarkObject != null)
            {
                NavigateBenchmarkObject(this, new BenchmarkObjectEventArgs(benchmarkObject));
            }
        }

        public BenchmarkObjectEditor()
        {
            InitializeComponent();
        }

        private void ActivateDetail(BenchmarkObjectDetail detail)
        {
            if (detail != activeDetail)
            {
                if (activeDetail != null)
                {
                    activeDetail.Validate();
                }

                Controls.Clear();

                if (detail != null)
                {
                    Controls.Add(detail);
                    detail.Dock = DockStyle.Fill;
                }

                activeDetail = detail;
            }
        }

        private void ShowDetail()
        {
            if (benchmarkObject is Benchmark.Benchmark)
            {
                benchmarkDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(benchmarkDetail);
            }
            else if (benchmarkObject is Benchmark.Script)
            {
                scriptDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(scriptDetail);
            }
            else if (benchmarkObject is Benchmark.TestGroup)
            {
                testGroupDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(testGroupDetail);
            }
            else if (benchmarkObject is Benchmark.Configuration)
            {
                configurationDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(configurationDetail);
            }
            else if (benchmarkObject is Benchmark.PlanEquivalenceTest)
            {
                planEquivalenceTestDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(planEquivalenceTestDetail);
            }
            else if (benchmarkObject is Benchmark.QueryVariant)
            {
                queryVariantDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(queryVariantDetail);
            }
            else if (benchmarkObject is Benchmark.ConnectionSettings)
            {
                connectionSettingsDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(connectionSettingsDetail);
            }
            else if (benchmarkObject is Benchmark.TestRun)
            {
                testRunDetail.BenchmarkObject = benchmarkObject;
                ActivateDetail(testRunDetail);
            }
            else
            {
                ActivateDetail(null);
            }
        }

        public bool CanNavigateBack()
        {
            if (navigationHistoryCurrentIndex > 0)
            {
                int newNavigationIndex = navigationHistoryCurrentIndex - 1;
                while (newNavigationIndex >= 0 && !benchmark.Contains(navigationHistory[newNavigationIndex]))
                {
                    newNavigationIndex--;
                }

                if (newNavigationIndex >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void NavigateBack()
        {
            if (navigationHistoryCurrentIndex > 0)
            {
                int newNavigationIndex = navigationHistoryCurrentIndex - 1;
                while (newNavigationIndex >= 0 && !benchmark.Contains(navigationHistory[newNavigationIndex]))
                {
                    newNavigationIndex--;
                }

                if (newNavigationIndex >= 0)
                {
                    historyNavigation = true;
                    navigationHistoryCurrentIndex = newNavigationIndex;
                    OnNavigateBenchmarkObject(navigationHistory[newNavigationIndex]);
                    historyNavigation = false;
                }
            }
        }

        public bool CanNavigateForward()
        {
            if (navigationHistoryCurrentIndex < navigationHistory.Count - 1)
            {
                int newNavigationIndex = navigationHistoryCurrentIndex + 1;
                while (newNavigationIndex < navigationHistory.Count && !benchmark.Contains(navigationHistory[newNavigationIndex]))
                {
                    newNavigationIndex++;
                }

                if (newNavigationIndex < navigationHistory.Count)
                {
                    return true;
                }
            }

            return false;
        }

        public void NavigateForward()
        {
            if (navigationHistoryCurrentIndex < navigationHistory.Count - 1)
            {
                int newNavigationIndex = navigationHistoryCurrentIndex + 1;
                while (newNavigationIndex < navigationHistory.Count && !benchmark.Contains(navigationHistory[newNavigationIndex]))
                {
                    newNavigationIndex++;
                }

                if (newNavigationIndex < navigationHistory.Count)
                {
                    historyNavigation = true;
                    navigationHistoryCurrentIndex = newNavigationIndex;
                    OnNavigateBenchmarkObject(navigationHistory[newNavigationIndex]);
                    historyNavigation = false;
                }
            }
        }

        private void detail_NavigateBenchmarkObject(object sender, BenchmarkObjectEventArgs e)
        {
            OnNavigateBenchmarkObject(e.BenchmarkObject);
        }
    }
}
