using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class DbDependentTableInfo
    {
        private string property;
        private string dbTableName;
        private string dbFkColumn;

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

        public DbDependentTableInfo(string property, string dbTableName, string dbFkColumn)
        {
            this.property = property;
            this.dbTableName = dbTableName;
            this.dbFkColumn = dbFkColumn;
        }
    }
}
