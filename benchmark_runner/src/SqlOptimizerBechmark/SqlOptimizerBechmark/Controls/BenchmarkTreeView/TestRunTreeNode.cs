using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.BenchmarkTreeView
{
    public class TestRunTreeNode : BenchmarkObjectTreeNode
    {
        private ContextMenuStrip testRunContextMenu;

        public TestRunTreeNode(Benchmark.TestRun testRun, BenchmarkTreeView benchmarkTreeView)
            : base(testRun, benchmarkTreeView)
        {
        }


        public override void BindNode()
        {
            ImageKey = "TestRun";
            SelectedImageKey = "TestRun";

            BindNamedObjectText();

            testRunContextMenu = new ContextMenuStrip();
            testRunContextMenu.Items.Add("Delete", Properties.Resources.Delete_16, Delete_Click);
            testRunContextMenu.Items.Add("Write to database", Properties.Resources.SaveToDb_16, WriteToDatabase_Click);
            this.ContextMenuStrip = testRunContextMenu;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Benchmark.TestRun testRun = (Benchmark.TestRun)BenchmarkObject;
            testRun.Benchmark.TestRuns.Remove(testRun);
        }

        private void WriteToDatabase_Click(object sender, EventArgs e)
        {
            Benchmark.TestRun testRun = (Benchmark.TestRun)BenchmarkObject;
            Executor.Executor.Instance.SaveTestRunToDb(testRun);
        }

        public override void BindChildren()
        {
            ChildrenBound = true;
        }

        public override bool HasChildren()
        {
            return false;
        }
    }
}
