using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlOptimizerBenchmark.Benchmark;

namespace SqlOptimizerBenchmark.Controls.BenchmarkListView
{
    public class TestsListView : BenchmarkListView<Benchmark.Test>
    {
        private Benchmark.TestGroup testGroup;

        public Benchmark.TestGroup TestGroup
        {
            get => testGroup;
            set => testGroup = value;
        }

        protected override string GetImageKey()
        {
            return "Test";
        }

        protected override Test CreateInstance()
        {
            Benchmark.PlanEquivalenceTest ret = new PlanEquivalenceTest(testGroup);
            ret.Name = Helpers.GetNewName(Collection.Select(t => t.Name), "new test", NumeralStyle.Guess);
            ret.Number = Helpers.GetNewName(Collection.Select(t => t.Number), null, NumeralStyle.Arabic);
            return ret;
        }
    }
}
