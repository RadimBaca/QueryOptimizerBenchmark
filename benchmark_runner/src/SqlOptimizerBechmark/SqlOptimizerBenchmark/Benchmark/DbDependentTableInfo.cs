using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class DbDependentTableInfo
    {
        private string property;
        private string dbTableName;
        private string dbFkColumn;
        private bool oneToOne;

        public string Property
        {
            get => property;
            set => property = value;
        }

        public string DbTableName
        {
            get => dbTableName;
            set => dbTableName = value;
        }

        public string DbFkColumn
        {
            get => dbFkColumn;
            set => dbFkColumn = value;
        }

        public bool OneToOne
        {
            get => oneToOne;
            set => oneToOne = value;
        }

        public DbDependentTableInfo(string property, string dbTableName, string dbFkColumn, bool oneToOne = false)
        {
            this.property = property;
            this.dbTableName = dbTableName;
            this.dbFkColumn = dbFkColumn;
            this.oneToOne = oneToOne;
        }
    }
}
