using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.DbProviders.SqlServer
{
    public class SqlBenchmarkObjectWriter : DbBenchmarkObjectWriter
    {
        private HashSet<string> fixedTables = new HashSet<string>();
        private SqlTransaction transaction = null;

        public SqlBenchmarkObjectWriter(SqlServerProvider sqlProvider)
            : base(sqlProvider)
        {
        }

        private SqlCommand CreateCommand()
        {
            SqlServerProvider sqlProvider = Provider as SqlServerProvider;
            SqlCommand cmd = sqlProvider.Connection.CreateCommand();
            cmd.Transaction = transaction;

            return cmd;
        }

        private string GetColumnDefinition(Benchmark.DbColumnInfo columnInfo)
        {
            switch (columnInfo.DbType)
            {
                case DbType.String:
                    return string.Format("VARCHAR({0})", columnInfo.DbSize);
                case DbType.Int32:
                    {
                        if (columnInfo.DbAutoIncrement)
                        {
                            return "INT IDENTITY(1, 1)";
                        }
                        else
                        {
                            return "INT";
                        }
                    }
                case DbType.Double:
                    return "FLOAT";
                case DbType.Date:
                case DbType.DateTime:
                    return "DATE";
                case DbType.Boolean:
                    return "BIT";
            }

            throw new Exception(string.Format("The type {0} is not supported.", Enum.GetName(typeof(DbType), columnInfo.DbType)));
        }
        
        private void CreateTable(DbTableInfo tableInfo)
        {
            StringWriter writer = new StringWriter();
            writer.WriteLine("CREATE TABLE [{0}].[{1}] (", Schema, tableInfo.TableName);

            string pkCols = string.Empty;

            foreach (Benchmark.DbColumnInfo columnInfo in tableInfo.DbColumns)
            {
                string colDefinition = GetColumnDefinition(columnInfo);
                writer.WriteLine("  [{0}] {1},", columnInfo.DbColumn, colDefinition);

                if (columnInfo.DbPrimaryKey)
                {
                    if (pkCols != string.Empty)
                    {
                        pkCols += ", ";
                    }
                    pkCols += columnInfo.DbColumn;
                }
            }

            writer.WriteLine("  PRIMARY KEY ({0}));", pkCols);
            writer.WriteLine();

            string createStatement = writer.ToString();

            // Execute the statement.
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = createStatement;
            cmd.ExecuteNonQuery();
        }

        private void AddColumn(DbTableInfo tableInfo, DbColumnInfo columnInfo)
        {
            string colDefinition = GetColumnDefinition(columnInfo);
            string alterStatement = string.Format("ALTER TABLE [{0}].[{1}] ADD {2} {3}",
                Schema, tableInfo.TableName, columnInfo.DbColumn, colDefinition);

            // Execute the statement.
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = alterStatement;
            cmd.ExecuteNonQuery();
        }

        private void AdjustColumnMaxLength(DbTableInfo tableInfo, DbColumnInfo columnInfo, string text)
        {
            if (columnInfo.DbType != DbType.String || string.IsNullOrEmpty(text))
            {
                return;
            }

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = "SELECT max_length FROM sys.columns WHERE object_id = object_id(@fullTableName) AND name = @columnName";
            cmd.Parameters.AddWithValue("fullTableName", string.Format("[{0}].[{1}]", Schema, tableInfo.TableName));
            cmd.Parameters.AddWithValue("columnName", columnInfo.DbColumn);
            object o = cmd.ExecuteScalar();

            if (o != null && o != DBNull.Value)
            {
                int maxLength = Convert.ToInt32(o);
                if (text.Length > maxLength)
                {
                    columnInfo.DbSize = text.Length * 2;
                    SqlCommand cmdAlter = CreateCommand();
                    string colDefinition = GetColumnDefinition(columnInfo);
                    cmdAlter.CommandText = string.Format("ALTER TABLE [{0}].[{1}] ALTER COLUMN [{2}] {3}",
                        Schema, tableInfo.TableName, columnInfo.DbColumn, colDefinition);
                    cmdAlter.ExecuteNonQuery();
                }
            }
        }

        private int GetTableId(string tableName)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = "SELECT OBJECT_ID(@fullTableName)";
            cmd.Parameters.AddWithValue("fullTableName", string.Format("[{0}].[{1}]", Schema, tableName));

            object objectId = cmd.ExecuteScalar();
            if (objectId != null && objectId != DBNull.Value)
            {
                return Convert.ToInt32(objectId);
            }
            else
            {
                return 0;
            }
        }

        private bool ColumnExists(int tableObjectId, string columnName)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM sys.columns WHERE object_id = @objectId AND name = @columnName";
            cmd.Parameters.AddWithValue("objectId", tableObjectId);
            cmd.Parameters.AddWithValue("columnName", columnName);

            object o = cmd.ExecuteScalar();

            int cnt = Convert.ToInt32(o);

            return cnt > 0;
        }

        private void SyncDbStructure(DbTableInfo tableInfo)
        {
            // Skip tables that were already synchrnozed.
            if (fixedTables.Contains(tableInfo.TableName))
            {
                return;
            }

            int tableObjectId = GetTableId(tableInfo.TableName);
            if (tableObjectId == 0)
            {
                CreateTable(tableInfo);
            }
            else
            {
                foreach (DbColumnInfo columnInfo in tableInfo.DbColumns)
                {
                    if (!ColumnExists(tableObjectId, columnInfo.DbColumn))
                    {
                        AddColumn(tableInfo, columnInfo);
                    }
                }
            }

            fixedTables.Add(tableInfo.TableName);
        }

        private object ConvertValue(object value)
        {
            if (value is DateTime && (DateTime)value == DateTime.MinValue)
            {
                return DBNull.Value;
            }

            if (value is TimeSpan)
            {
                return ((TimeSpan)value).TotalMilliseconds;
            }

            if (value is QueryPlan)
            {
                value = ((QueryPlan)value).ToString();
            }

            return value;
        }

        private void Insert(IBenchmarkObject benchmarkObject, string parentFkColumn, object parentFkValue)
        {
            // Create table or add columns.
            DbTableInfo tableInfo = benchmarkObject.GetTableInfo();
            SyncDbStructure(tableInfo);

            Type type = benchmarkObject.GetType();
            SqlCommand cmd = CreateCommand();

            // Prepare command.
            string insert = string.Format("INSERT INTO [{0}].[{1}] (", Schema, tableInfo.TableName);
            string values = "VALUES (";

            bool first = true;
            bool autoIncPk = false;
            object pkValue = null;

            foreach (DbColumnInfo columnInfo in tableInfo.DbColumns)
            {
                // Skip auto-incremented values.
                if (columnInfo.DbAutoIncrement)
                {
                    autoIncPk = true;
                    continue;
                }

                // Skip values for which we do not have a property or they do not match the parent table.
                object value = null;
                if (columnInfo.DbColumn == parentFkColumn)
                {
                    value = parentFkValue;
                }
                else
                {
                    if (columnInfo.Property != null)
                    {
                        PropertyInfo propertyInfo = type.GetProperty(columnInfo.Property);
                        if (propertyInfo != null)
                        {
                            value = propertyInfo.GetValue(benchmarkObject);
                        }
                    }
                }
                if (value == null)
                {
                    continue;
                }

                if (columnInfo.DbPrimaryKey)
                {
                    pkValue = value;
                }

                if (!first)
                {
                    insert += ", ";
                    values += ", ";
                }

                string paramName = "@" + columnInfo.DbColumn;

                value = ConvertValue(value);

                if (value is string)
                {
                    AdjustColumnMaxLength(tableInfo, columnInfo, (string)value);
                }

                insert += string.Format("[{0}]", columnInfo.DbColumn);
                values += paramName;
                cmd.Parameters.AddWithValue(paramName, value);

                first = false;
            }

            insert += ")";
            values += ")";
            cmd.CommandText = insert + Environment.NewLine + values;

            // Run the command.
            cmd.ExecuteNonQuery();
            
            // Retrieve scope identity.
            if (autoIncPk)
            {
                SqlCommand cmdGetIdentity = CreateCommand();
                cmdGetIdentity.CommandText = "SELECT IDENT_CURRENT(@fullTableName)";
                cmdGetIdentity.Parameters.AddWithValue("fullTableName", string.Format("[{0}].[{1}]", Schema, tableInfo.TableName));
                pkValue = cmdGetIdentity.ExecuteScalar();
            }

            // Insert recursive.
            foreach (Benchmark.DbDependentTableInfo dependentTable in tableInfo.DbDependentTables)
            {
                PropertyInfo propertyInfo = type.GetProperty(dependentTable.Property);
                if (propertyInfo != null)
                {
                    object collection = propertyInfo.GetValue(benchmarkObject);
                    if (collection is IEnumerable e)
                    {
                        foreach (IBenchmarkObject childObject in e)
                        {
                            Insert(childObject, dependentTable.DbFkColumn, pkValue);
                        }
                    }
                }
            }
        }

        private void CheckSchema()
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = "IF NOT @schemaName IN (SELECT name FROM sys.schemas) EXEC('CREATE SCHEMA " + Schema + "')";
            cmd.Parameters.AddWithValue("schemaName", Schema);
            cmd.ExecuteNonQuery();
        }
        
        public override void WriteToDb(IBenchmarkObject benchmarkObject)
        {
            fixedTables.Clear();

            SqlServerProvider sqlProvider = Provider as SqlServerProvider;
            transaction = sqlProvider.Connection.BeginTransaction();

            try
            {
                CheckSchema();
                Insert(benchmarkObject, null, null);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
