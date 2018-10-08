using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.Controls.BenchmarkListView
{
    public class TestGroupsListView: BenchmarkListView<Benchmark.TestGroup>
    {
        private Benchmark.Benchmark benchmark;

        public Benchmark.Benchmark Benchmark
        {
            get => benchmark;
            set => benchmark = value;
        }

        protected override string GetImageKey()
        {
            return "TestGroup";
        }

        protected override TestGroup CreateInstance()
        {
            TestGroup ret = new TestGroup(benchmark);
            ret.Name = Helpers.GuessNewName(Collection.Select(g => g.Name), "new test group");
            return ret;
        }
    }
}
