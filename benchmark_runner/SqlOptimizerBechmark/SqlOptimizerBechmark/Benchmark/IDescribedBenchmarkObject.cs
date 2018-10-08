using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public interface IDescribedBenchmarkObject: IBenchmarkObject
    {
        string Description
        {
            get;
        }
    }
}
