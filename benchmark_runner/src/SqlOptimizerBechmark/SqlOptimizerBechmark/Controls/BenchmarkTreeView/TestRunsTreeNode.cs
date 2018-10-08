using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.BenchmarkTreeView
{
    public class TestRunsTreeNode: TreeNode
    {
        private BenchmarkTreeView benchmarkTreeView;
        private Benchmark.Benchmark benchmark;

        private ContextMenuStrip testRunsContextMenu;

        public BenchmarkTreeView BenchmarkTreeView => benchmarkTreeView;

        public Benchmark.Benchmark Benchmark => benchmark;

        public TestRunsTreeNode(Benchmark.Benchmark benchmark, BenchmarkTreeView benchmarkTreeView)
        {
            this.benchmark = benchmark;
            this.benchmarkTreeView = benchmarkTreeView;
            BindNode();
        }

        private void BindNode()
        {
            ImageKey = "TestRuns";
            SelectedImageKey = "TestRuns";

            testRunsContextMenu = new ContextMenuStrip();
            testRunsContextMenu.Items.Add("Launch benchmark ...", Properties.Resources.Play_16, Launch_Click);

            this.ContextMenuStrip = testRunsContextMenu;
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            Executor.Executor.Instance.LaunchTest(benchmark);
        }
    }
}
