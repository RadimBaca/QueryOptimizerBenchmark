using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using global::MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.DbProviders.MySql
{
    public class MySqlProvider : DbProvider
    {
        #region Fields

        private bool useConnectionString = false;
        private string hostName = string.Empty;
        private string userName = string.Empty;
        private string password = string.Empty;
        private string defaultSchema = string.Empty;
        private string connectionString = string.Empty;
        private int commandTimeout = 60;

        private MySqlConnection connection;

        #endregion

        #region Properties

        public override string Name => "MySQL";

        public bool UseConnectionString
        {
            get => useConnectionString;
            set => useConnectionString = value;
        }

        public string HostName
        {
            get => hostName;
            set => hostName = value;
        }

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string DefaultSchema
        {
            get => defaultSchema;
            set => defaultSchema = value;
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
            hostName = element.Attribute("host_name").Value;
            userName = element.Attribute("user_name").Value;
            password = element.Attribute("password").Value;
            defaultSchema = element.Attribute("default_schema").Value;
            connectionString = element.Attribute("connection_string").Value;
            commandTimeout = Convert.ToInt32(element.Attribute("command_timeout").Value);
        }

        public override void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("use_connection_string", useConnectionString));
            element.Add(new XAttribute("host_name", hostName));
            element.Add(new XAttribute("user_name", userName));
            element.Add(new XAttribute("password", password));
            element.Add(new XAttribute("default_schema", defaultSchema));
            element.Add(new XAttribute("connection_string", connectionString));
            element.Add(new XAttribute("command_timeout", commandTimeout));
        }

        public override DbProviderSettingsControl CreateSettingsControl()
        {
            MySqlSettingsControl ctl = new MySqlSettingsControl();
            ctl.Provider = this;
            return ctl;
        }
        
        public string GetConnectionString()
        {
            if (useConnectionString)
            {
                return connectionString;
            }
            else
            {
                string format = "Server={0};Database={1};Uid={2};Pwd={3};";
                string ret = string.Format(format, hostName, defaultSchema, userName, password);
                return ret;
            }
        }

        public override void Connect()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = GetConnectionString();
            connection.Open();

            MySqlCommand cmdSetProfiling = connection.CreateCommand();
            cmdSetProfiling.CommandText = "SET SESSION profiling = 1";
            cmdSetProfiling.ExecuteNonQuery();

            SetSessionMaxExecuteTime();
        }

        private int GetCommandTimeoutInMs()
        {
            return commandTimeout * 1000;
        }

        private void SetSessionMaxExecuteTime()
        {
            MySqlCommand cmdSetTimeout = connection.CreateCommand();
            cmdSetTimeout.CommandText = "SET SESSION MAX_EXECUTION_TIME = @t";
            cmdSetTimeout.Parameters.AddWithValue("t", GetCommandTimeoutInMs());
            cmdSetTimeout.ExecuteNonQuery();
        }

        public override void Close()
        {
            connection.Close();
        }

        public override void Execute(string statement)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = statement;
            //command.CommandTimeout = commandTimeout;
            command.ExecuteNonQuery();
        }

        private double ReadCostInfo(JsonReader reader)
        {
            double ret = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return ret;
                }
                if (reader.TokenType == JsonToken.PropertyName &&
                    Convert.ToString(reader.Value) == "query_cost")
                {
                    reader.Read();
                    ret = Convert.ToDouble(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return ret;
        }

        private QueryPlanNode ReadNode(JsonReader reader, QueryPlanNode parentNode, string parentPropertyName)
        {
            QueryPlanNode ret = new QueryPlanNode();
            ret.OpName = parentPropertyName;

            int level = 1;
            string propertyName = null;

            while (level > 0 && reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    if (propertyName != null)
                    {
                        QueryPlanNode queryPlanNode = ReadNode(reader, ret, propertyName);
                        ret.ChildNodes.Add(queryPlanNode);
                        queryPlanNode.Parent = ret;
                    }
                    else
                    {
                        level++;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    level--;
                }

                if (reader.TokenType == JsonToken.StartArray)
                {
                    if (propertyName != null)
                    {
                        QueryPlanNode queryPlanNode = ReadNode(reader, ret, propertyName);
                        ret.ChildNodes.Add(queryPlanNode);
                        queryPlanNode.Parent = ret;
                    }
                    else
                    {
                        level++;
                    }
                }
                else if (reader.TokenType == JsonToken.EndArray)
                {
                    level--;

                }

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    propertyName = Convert.ToString(reader.Value);


                    if (propertyName == "rows_produced_per_join")
                    {
                        reader.Read();
                        int rows = Convert.ToInt32(reader.Value);
                        ret.EstimatedRows = rows;

                        propertyName = null;
                    }
                    if (propertyName == "cost_info")
                    {
                        ret.EstimatedCost = ReadCostInfo(reader);
                        propertyName = null;
                    }
                    if (propertyName == "access_type")
                    {
                        reader.Read();
                        string accessTypeStr = Convert.ToString(reader.Value);
                        ret.OpName += "_" + accessTypeStr.ToLower();
                        propertyName = null;
                    }

                    // Ignored properties.
                    if (propertyName == "used_columns")
                    {
                        propertyName = null;
                    }
                }
                else
                {
                    propertyName = null;
                }
            }

            if (ret.OpName == null && ret.ChildNodes.Count == 1)
            {
                QueryPlanNode node = ret.ChildNodes[0];
                node.Parent = null;
                ret = node;
            }

            return ret;
        }

        private QueryPlanNode ParsePlan(string jsonStr)
        {
            QueryPlanNode ret = null;
            System.IO.StringReader stringReader = new System.IO.StringReader(jsonStr);
            JsonTextReader jsonTextReader = new JsonTextReader(stringReader);
            if (jsonTextReader.Read())
            {
                if (jsonTextReader.TokenType == JsonToken.StartObject)
                {
                    ret = ReadNode(jsonTextReader, null, null);
                }
            }
            jsonTextReader.Close();
            return ret;
        }

        public override QueryPlan GetQueryPlan(string query)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "EXPLAIN FORMAT=JSON " + query;
            object o = command.ExecuteScalar();
            string queryPlanStr = Convert.ToString(o);

            QueryPlan ret = new QueryPlan();
            ret.Root = ParsePlan(queryPlanStr);
            return ret;
        }

        public override QueryStatistics GetQueryStatistics(string query, bool retrieveWholeResult)
        {
            QueryStatistics ret = new QueryStatistics();

            MySqlDataReader reader = null;
            bool closing = false;

            try
            {
                MySqlCommand cmdQuery = connection.CreateCommand();
                cmdQuery.CommandText = query;
                cmdQuery.CommandTimeout = 0;

                int resultSize = 0;
                if (!retrieveWholeResult)
                {
                    reader = cmdQuery.ExecuteReader();
                    DateTime t1 = DateTime.Now;
                    while (reader.Read())
                    {
                        resultSize++;
                        DateTime t2 = DateTime.Now;
                        TimeSpan span = t2 - t1;
                        if (span.TotalMilliseconds > GetCommandTimeoutInMs())
                        {
                            resultSize = 0;
                            cmdQuery.Cancel();
                            break;
                        }
                    }
                    closing = true;
                    reader.Close();
                    reader = null;
                }
                else
                {
                    ret.Result = new DataTable();
                    reader = cmdQuery.ExecuteReader();
                    cmdQuery.CommandTimeout = commandTimeout;
                    ret.Result.Load(reader);
                    resultSize = ret.Result.Rows.Count;
                    reader.Close();
                    reader = null;
                }
                ret.ResultSize = resultSize;

                double procesingTime = 0;
                
                MySqlCommand cmdGetTime = connection.CreateCommand();
                cmdGetTime.CommandText = "SHOW PROFILES";
                reader = cmdGetTime.ExecuteReader();
                closing = false;
                while (reader.Read())
                {
                    string readerQuery = Convert.ToString(query);
                    if (readerQuery.Trim() == query.Trim())
                    {
                        double duration = Convert.ToDouble(reader["Duration"], System.Globalization.CultureInfo.InvariantCulture);
                        procesingTime = duration;
                    }
                }
                reader.Close();
                reader = null;
                ret.QueryProcessingTime = TimeSpan.FromSeconds(procesingTime);
                
                return ret;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                bool resetConnection = false;

                if (ex is MySqlException mySqlException1)
                {
                    if (mySqlException1.Number == 3024) // Maximum execution time exceeded.
                    {
                        resetConnection = true;
                    }
                }
                if (ex.InnerException is MySqlException mySqlException2)
                {
                    if (mySqlException2.Number == 3024) // Maximum execution time exceeded.
                    {
                        resetConnection = true;
                    }
                }

                if (resetConnection)
                {
                    reader = null;
                    Connect();
                    Debug.WriteLine("CONNECTION RESET");
                }

                throw;
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed && !closing)
                    {
                        reader.Close();
                    }
                    reader = null;
                }
            }
        }

        public override string GetTestingScript(Benchmark.Benchmark benchmark)
        {
            return string.Empty;
        }

        public override void ExportToFileSystem(string path, Benchmark.Benchmark benchmark)
        {
        }
    }
}
