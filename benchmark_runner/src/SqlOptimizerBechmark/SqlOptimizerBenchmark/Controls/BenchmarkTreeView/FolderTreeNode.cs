using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkTreeView
{
    public class FolderTreeNode: TreeNode
    {
        private BenchmarkTreeView benchmarkTreeView;

        public FolderTreeNode(BenchmarkTreeView benchmarkTreeView)
        {
            this.benchmarkTreeView = benchmarkTreeView;
        }
    }
}
