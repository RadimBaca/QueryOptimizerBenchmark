using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Controls
{
    public class BenchmarkObjectEventArgs: EventArgs
    {
        private Benchmark.IBenchmarkObject benchmarkObject;

        public Benchmark.IBenchmarkObject BenchmarkObject
        {
            get => benchmarkObject;
        }

        public BenchmarkObjectEventArgs(Benchmark.IBenchmarkObject benchmarkObject)
        {
            this.benchmarkObject = benchmarkObject;
        }
    }

    public delegate void BenchmarkObjectEventHandler(object sender, BenchmarkObjectEventArgs e);
}
