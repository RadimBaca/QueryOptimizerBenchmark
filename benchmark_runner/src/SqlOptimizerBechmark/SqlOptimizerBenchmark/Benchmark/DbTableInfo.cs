using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class DbTableInfo
    {
        private string tableName;
        private IList<DbColumnInfo> dbColumns = new List<DbColumnInfo>();
        private IList<DbDependentTableInfo> dbDependentTables = new List<DbDependentTableInfo>();

        public string TableName
        {
            get => tableName;
            set => tableName = value;
        }

        public IList<DbColumnInfo> DbColumns
        {
            get => dbColumns;
        }

        public IList<DbDependentTableInfo> DbDependentTables
        {
            get => dbDependentTables;
        }

        public DbTableInfo()
        {

        }

        public DbTableInfo(string tableName)
        {
            this.tableName = tableName;
        }
    }
}
