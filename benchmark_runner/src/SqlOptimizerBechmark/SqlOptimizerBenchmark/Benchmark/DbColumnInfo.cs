using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    /// <summary>
    /// Encapsulates a definition of an attribute in the database.
    /// </summary>
    public class DbColumnInfo
    {
        private string property;
        private string dbColumn;
        private bool dbPrimaryKey;
        private bool dbAutoIncrement;
        private bool dbForeignKey;
        private DbType dbType;
        private int dbSize;
        private string referencedTableName;
        private string referencedColumn;

        /// <summary>
        /// Gets or sets a name of a class property.
        /// </summary>
        public string Property
        {
            get => property;
            set
            {
                property = value;
                if (dbColumn == null)
                {
                    dbColumn = property;
                }
            }
        }

        /// <summary>
        /// Gets or sets the database attribute.
        /// </summary>
        public string DbColumn
        {
            get => dbColumn;
            set => dbColumn = value;
        }

        /// <summary>
        /// Gets or sets the database data type.
        /// </summary>
        public DbType DbType
        {
            get => dbType;
            set => dbType = value;
        }

        /// <summary>
        /// Gets or sets a size of the attribute in the database.
        /// </summary>
        public int DbSize
        {
            get => dbSize;
            set => dbSize = value;
        }

        /// <summary>
        /// Gets or sests whether the column is a primary key.
        /// </summary>
        public bool DbPrimaryKey
        {
            get => dbPrimaryKey;
            set => dbPrimaryKey = value;
        }

        public bool DbAutoIncrement
        {
            get => dbAutoIncrement;
            set => dbAutoIncrement = value;
        }

        public DbColumnInfo()
        {

        }

        public DbColumnInfo(string property, string dbColumn, DbType dbType, int dbSize)
        {
            this.property = property;
            this.dbColumn = dbColumn;
            this.dbType = dbType;
            this.dbSize = dbSize;
        }

        public DbColumnInfo(string property, string dbColumn, DbType dbType, bool dbPrimaryKey)
        {
            this.property = property;
            this.dbColumn = dbColumn;
            this.dbType = dbType;
            this.dbPrimaryKey = dbPrimaryKey;
        }

        public DbColumnInfo(string dbColumn, bool dbPrimaryKey, bool dbAutoIncrement)
        {
            this.dbColumn = dbColumn;
            this.dbType = DbType.Int32;
            this.dbPrimaryKey = dbPrimaryKey;
            this.dbAutoIncrement = dbAutoIncrement;
        }

        public DbColumnInfo(string property, string dbColumn, DbType dbType, bool dbForeignKey, string referencedTableName, string referencedColumn)
        {
            this.property = property;
            this.dbColumn = dbColumn;
            this.dbType = dbType;
            this.dbForeignKey = dbForeignKey;
            this.referencedTableName = referencedTableName;
            this.referencedColumn = referencedColumn;
        }

        public DbColumnInfo(string property, string dbColumn, DbType dbType, bool dbPrimaryKey, bool dbForeignKey, string referencedTableName, string referencedColumn)
        {
            this.property = property;
            this.dbColumn = dbColumn;
            this.dbType = dbType;
            this.dbPrimaryKey = dbPrimaryKey;
            this.dbForeignKey = dbForeignKey;
            this.referencedTableName = referencedTableName;
            this.referencedColumn = referencedColumn;
        }

        public DbColumnInfo(string property, string dbColumn, DbType dbType)
        {
            this.property = property;
            this.dbColumn = dbColumn;
            this.dbType = dbType;
        }
    }
}
