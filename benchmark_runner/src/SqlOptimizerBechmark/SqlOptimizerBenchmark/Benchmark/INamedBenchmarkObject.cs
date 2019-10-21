using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public interface INamedBenchmarkObject : IBenchmarkObject
    {
        string Name { get; set; }
    }
}
