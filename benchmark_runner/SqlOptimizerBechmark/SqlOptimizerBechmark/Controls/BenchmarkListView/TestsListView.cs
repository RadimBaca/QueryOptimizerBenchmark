using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.Controls.BenchmarkListView
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
            ret.Name = Helpers.GuessNewName(Collection.Select(t => t.Name), "new test");
            return ret;
        }
    }
}
