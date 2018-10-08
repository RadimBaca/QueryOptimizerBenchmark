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
            this.ContextMenuStrip = testRunContextMenu;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Benchmark.TestRun testRun = (Benchmark.TestRun)BenchmarkObject;
            testRun.Benchmark.TestRuns.Remove(testRun);
        }

        public override void BindChildren()
        {
        }

        public override bool HasChildren()
        {
            return false;
        }
    }
}
