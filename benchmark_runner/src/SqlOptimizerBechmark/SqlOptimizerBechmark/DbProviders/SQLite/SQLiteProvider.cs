using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.DbProviders.SQLite
{
    public class SQLiteProvider : DbProvider
    {
        #region Fields

        private bool useConnectionString = false;
        private string fileName;
        private bool inMemory;
        private string connectionString = string.Empty;
        private int commandTimeout = 60;

        private SQLiteConnection connection;

        #endregion

        public override string GetSettingsInfo()
        {
            if (!useConnectionString)
            {
                return $"dbms=SQLite|fileName={fileName}|inMemory={inMemory}|commandTimeout={commandTimeout}";
            }
            else
            {
                return $"dbms=SQLite|connectionString={connectionString}|commandTimeout={commandTimeout}";
            }
        }

        #region Properties

        public override string Name => "SQLite";

        public bool UseConnectionString
        {
            get => useConnectionString;
            set => useConnectionString = value;
        }

        public string FileName
        {
            get => fileName;
            set => fileName = value;
        }

        public bool InMemory
        {
            get => inMemory;
            set => inMemory = value;
        }

        public string ConnectionString
        {
            get => connectionString;
            set => connectionString = value;
        }

        public int CommandTimeout
        {
            get => commandTimeout;
            set => commandTimeout = value;
        }

        #endregion

        public override void LoadFromXml(XElement element)
        {
            useConnectionString = Convert.ToBoolean(element.Attribute("use_connection_string").Value);
            fileName = element.Attribute("file_name").Value;
            inMemory = Convert.ToBoolean(element.Attribute("in_memory").Value);
            connectionString = element.Attribute("connection_string").Value;
            commandTimeout = Convert.ToInt32(element.Attribute("command_timeout").Value);
        }

        public override void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("use_connection_string", useConnectionString));
            element.Add(new XAttribute("file_name", fileName));
            element.Add(new XAttribute("in_memory", inMemory));
            element.Add(new XAttribute("connection_string", connectionString));
            element.Add(new XAttribute("command_timeout", commandTimeout));
        }

        public string GetConnectionString()
        {
            string ret = null;

            if (useConnectionString)
            {
                ret = connectionString;
            }
            else
            {
                if (inMemory)
                {
                    ret = "Data Source=:memory:;Version=3;New=True;";
                }
                else
                {
                    string format = "Data Source={0};Version=3;";
                    ret = string.Format(format, fileName);
                    return ret;
                }
            }

            return ret;
        }

        public override void Connect()
        {
            connection = new SQLiteConnection();
            connection.ConnectionString = GetConnectionString();
            connection.DefaultTimeout = commandTimeout * 1000;
            connection.Open();
        }

        public override void Close()
        {
            connection.Close();
        }

        public override DbProviderSettingsControl CreateSettingsControl()
        {
            SQLiteSettingsControl ctl = new SQLiteSettingsControl();
            ctl.Provider = this;
            return ctl;
        }

        public override void Execute(string statement)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = statement;
            command.ExecuteNonQuery();
        }

        public override void ExportToFileSystem(string path, Benchmark.Benchmark benchmark)
        {
            
        }

        public override QueryPlan GetQueryPlan(string query)
        {
            QueryPlan ret = new QueryPlan();
            SQLiteDataReader reader = null;

            try
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "EXPLAIN QUERY PLAN " + query;

                DataTable tablePlan = new DataTable();
                reader = command.ExecuteReader();
                tablePlan.Load(reader);
                reader.Close();
                reader = null;
                
                Dictionary<int, QueryPlanNode> queryPlanNodes = new Dictionary<int, QueryPlanNode>();

                QueryPlanNode root = new QueryPlanNode();
                root.OpName = "Query";
                queryPlanNodes.Add(0, root);

                foreach (DataRow row in tablePlan.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string detail = Convert.ToString(row["detail"]);

                    QueryPlanNode node = new QueryPlanNode();
                    node.OpName = detail;
                    queryPlanNodes.Add(id, node);
                }


                foreach (DataRow row in tablePlan.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    int parent = Convert.ToInt32(row["parent"]);

                    QueryPlanNode node = queryPlanNodes[id];
                    QueryPlanNode parentNode = queryPlanNodes[parent];

                    node.Parent = parentNode;
                    parentNode.ChildNodes.Add(node);
                }

                ret = new QueryPlan();
                ret.Root = root;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }

            return ret;
        }

        public override QueryStatistics GetQueryStatistics(string query, bool retrieveWholeResult)
        {
            SQLiteDataReader reader = null;
            try
            {
                QueryStatistics ret = new QueryStatistics();

                SQLiteCommand cmdQuery = connection.CreateCommand();
                cmdQuery.CommandText = query;
                cmdQuery.CommandTimeout = commandTimeout;

                DateTime t0 = DateTime.Now;

                int resultSize = 0;
                if (!retrieveWholeResult)
                {
                    reader = cmdQuery.ExecuteReader();
                    while (reader.Read())
                    {
                        resultSize++;
                    }
                    reader.Close();
                    reader = null;
                }
                else
                {
                    ret.Result = new DataTable();
                    ret.Result.Load(cmdQuery.ExecuteReader());
                    resultSize = ret.Result.Rows.Count;
                }

                DateTime t1 = DateTime.Now;

                ret.QueryProcessingTime = t1 - t0;
                ret.ResultSize = resultSize;

                return ret;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }
        }

        public override string GetTestingScript(Benchmark.Benchmark benchmark)
        {
            return string.Empty;
        }

    }
}
