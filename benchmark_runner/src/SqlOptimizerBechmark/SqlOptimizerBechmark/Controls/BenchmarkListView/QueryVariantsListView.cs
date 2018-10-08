using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Controls.BenchmarkListView
{
    public class QueryVariantsListView : BenchmarkListView<Benchmark.QueryVariant>
    {
        private Benchmark.PlanEquivalenceTest planEquivalenceTest;

        public Benchmark.PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
            set => planEquivalenceTest = value;
        }

        protected override string GetImageKey()
        {
            return "Variant";
        }

        protected override Benchmark.QueryVariant CreateInstance()
        {
            Benchmark.QueryVariant ret = new Benchmark.QueryVariant(planEquivalenceTest);
            ret.Name = Helpers.GuessNewName(Collection.Select(v => v.Name), "new variant");
            return ret;
        }
    }
}
