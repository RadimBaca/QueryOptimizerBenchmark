using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkListView
{
    public class BenchmarkObjectListViewItem: ListViewItem
    {
        private Benchmark.IBenchmarkObject benchmarkObject;

        public Benchmark.IBenchmarkObject BenchmarkObject
        {
            get => benchmarkObject;
        }

        public BenchmarkObjectListViewItem(Benchmark.IBenchmarkObject benchmarkObject)
        {
            this.benchmarkObject = benchmarkObject;
        }
    }
}
