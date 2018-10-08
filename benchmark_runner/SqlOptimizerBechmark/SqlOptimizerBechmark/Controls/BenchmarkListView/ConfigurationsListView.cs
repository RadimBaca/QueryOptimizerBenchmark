using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Controls.BenchmarkListView
{
    public class ConfigurationsListView : BenchmarkListView<Benchmark.Configuration>
    {
        private Benchmark.TestGroup testGroup;

        public Benchmark.TestGroup TestGroup
        {
            get => testGroup;
            set => testGroup = value;
        }

        protected override string GetImageKey()
        {
            return "Configuration";
        }

        protected override Benchmark.Configuration CreateInstance()
        {
            Benchmark.Configuration ret = new Benchmark.Configuration(testGroup);
            ret.Name = Helpers.GuessNewName(Collection.Select(c => c.Name), "new configuration");
            return ret;
        }
    }
}
