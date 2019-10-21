using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Controls.BenchmarkTreeView
{
    public class ScriptTreeNode : BenchmarkObjectTreeNode
    {
        public ScriptTreeNode(Benchmark.Script script, BenchmarkTreeView benchmarkTreeView)
            : base(script, benchmarkTreeView)
        {
        }

        public override void BindNode()
        {
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
