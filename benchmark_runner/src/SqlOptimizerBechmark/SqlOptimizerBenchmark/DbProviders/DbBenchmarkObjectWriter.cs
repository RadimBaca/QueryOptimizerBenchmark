using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.DbProviders
{
    public abstract class DbBenchmarkObjectWriter
    {
        private DbProvider provider;
        private string schema = "sql_bench";

        public DbProvider Provider
        {
            get => provider;
        }

        public string Schema
        {
            get => schema;
            set => schema = value;
        }

        public DbBenchmarkObjectWriter(DbProvider provider)
        {
            this.provider = provider;
        }
                
        public abstract void WriteToDb(Benchmark.IBenchmarkObject benchmarkObject);
    }
}
