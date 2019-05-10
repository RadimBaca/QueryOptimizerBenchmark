using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.DbProviders.Oracle
{
    public class OracleProvider : DbProvider
    {
        #region Fields

        private bool useConnectionString = false;
        private string userName = string.Empty;
        private string password = string.Empty;
        private string hostName = string.Empty;
        private int port = 1521;
        private string sID = string.Empty;
        private string connectionString = string.Empty;
        private int commandTimeout = 60;
        private bool disableParallelQueryProcessing = false;

        private OracleConnection connection;

        #endregion

        public override string GetSettingsInfo()
        {
            if (!useConnectionString)
            {
                return $"dbms=Oracle|userName={userName}|password={password}|hostName={hostName}|port={port}|sID={sID}|commandTimeout={commandTimeout}|disableParallelQueryProcessing={disableParallelQueryProcessing}";
            }
            else
            {
                return $"dbms=Oracle|connectionString={connectionString}|commandTimeout={commandTimeout}|disableParallelQueryProcessing={disableParallelQueryProcessing}";
            }
        }

        #region Properties

        public override string Name => "Oracle Database";

        public bool UseConnectionString
        {
            get => useConnectionString;
            set => useConnectionString = value;
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

        public string HostName
        {
            get => hostName;
            set => hostName = value;
        }

        public int Port
        {
            get => port;
            set => port = value;
        }

        public string SID
        {
            get => sID;
            set => sID = value;
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

        public bool DisableParallelQueryProcessing
        {
            get => disableParallelQueryProcessing;
            set => disableParallelQueryProcessing = value;
        }

        #endregion

        public string GetConnectionString()
        {
            if (useConnectionString)
            {
                return connectionString;
            }
            else
            {
                string format = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={2})(PORT={3})))(CONNECT_DATA=(SID={4})));User ID={0};Password={1}";
                string ret = string.Format(format, userName, password, hostName, port, sID);
                return ret;
            }
        }

        public override void Connect()
        {
            connection = new OracleConnection();
            connection.ConnectionString = GetConnectionString();
            connection.Open();

            // Set capturing statistics on.
            OracleCommand cmdCaptureStatsOn = connection.CreateCommand();
            cmdCaptureStatsOn.CommandText = "ALTER SESSION SET STATISTICS_LEVEL = 'ALL'";
            cmdCaptureStatsOn.ExecuteNonQuery();

            if (disableParallelQueryProcessing)
            {
                // Disable parallel query processing.
                OracleCommand cmdDisaleParallelQueryProcessing = connection.CreateCommand();
                cmdDisaleParallelQueryProcessing.CommandText = "ALTER SESSION DISABLE PARALLEL QUERY";
                cmdDisaleParallelQueryProcessing.ExecuteNonQuery();
            }
        }

        public override void Close()
        {
            connection.Close();
        }

        public override DbProviderSettingsControl CreateSettingsControl()
        {
            OracleSettingsControl ctl = new OracleSettingsControl();
            ctl.Provider = this;
            return ctl;
        }

        private static string RemoveComments(string statement)
        {
            bool readingString = false;
            string stringClosingStr = string.Empty;

            bool readingComment = false;
            string commentClosingStr = string.Empty;

            string ret = string.Empty;
            
            int position = 0;
            while (position < statement.Length)
            {
                if (!readingComment && !readingString)
                {
                    if (statement[position] == '\'')
                    {
                        readingString = true;
                        stringClosingStr = "'";
                        ret += statement[position++];
                    }
                    else if (statement[position] == '"')
                    {
                        readingString = true;
                        stringClosingStr = "\"";
                        ret += statement[position++];
                    }
                }

                if (readingString && statement.Substring(position).StartsWith(stringClosingStr))
                {
                    readingString = false;
                }

                if (!readingString && !readingComment)
                {
                    if (statement.Substring(position).StartsWith("--"))
                    {
                        readingComment = true;
                        commentClosingStr = Environment.NewLine;
                    }
                    else if (statement.Substring(position).StartsWith("/*"))
                    {
                        readingComment = true;
                        commentClosingStr = "*/";
                    }
                }

                if (readingComment && statement.Substring(position).StartsWith(commentClosingStr))
                {
                    readingComment = false;
                    position += commentClosingStr.Length;
                    continue;
                }

                if (!readingComment)
                {
                    ret += statement[position];
                }

                position++;
            }

            return ret;
        }

        private bool IsAnonymousBlock(string statement)
        {
            statement = RemoveComments(statement);
            statement = statement.Trim();
            statement = statement.TrimEnd(';');
            statement = statement.TrimEnd();
            if (statement.StartsWith("begin", true, System.Globalization.CultureInfo.CurrentCulture) &&
                statement.EndsWith("end", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Execute(string statement)
        {
            // Odstranit zbytecne bile znaky a strednik z konce prikazu.
            statement = statement.Trim();
            if (!IsAnonymousBlock(statement))
            {
                statement = statement.TrimEnd(';');
            }

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "BEGIN EXECUTE IMMEDIATE :cmd; END;";
            command.Parameters.Add("cmd", statement);
            command.ExecuteNonQuery();
        }

        public override DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            using (OracleDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }
            return table;
        }

        public override void ExportToFileSystem(string path, Benchmark.Benchmark benchmark)
        {
        }

        private static void ParsePlanOutput(string planOutput, DataTable table)
        {
            using (var reader = new StringReader(planOutput))
            {
                string line;
                bool readingContent = false;
                bool parseHeader = false;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("| Id", true, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        readingContent = true;
                        parseHeader = true;
                    }
                    if (readingContent)
                    {
                        if (!line.StartsWith("|") && !line.StartsWith("-"))
                        {
                            readingContent = false;
                            break;
                        }

                        if (line.StartsWith("-"))
                        {
                            continue;
                        }

                        if (parseHeader)
                        {
                            string[] fields = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
                            foreach (string field in fields)
                            {
                                table.Columns.Add(new DataColumn(field, typeof(string)));
                            }
                            parseHeader = false;
                        }
                        else
                        {
                            string[] values = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                            DataRow row = table.NewRow();

                            for (int columnIndex = 0; columnIndex < values.Length && columnIndex <= table.Columns.Count; columnIndex++)
                            {
                                row[columnIndex] = values[columnIndex];
                            }

                            table.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private static int ParseInt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return -1;
            }

            int multiplier = 1;
            str = str.Trim();

            if (str.EndsWith("K", true, System.Globalization.CultureInfo.InvariantCulture))
            {
                multiplier = 1000;
                str = str.TrimEnd('K', 'k');
            }
            else if (str.EndsWith("M", true, System.Globalization.CultureInfo.InvariantCulture))
            {
                multiplier = 1000000;
                str = str.TrimEnd('M', 'm');
            }
            else if (str.EndsWith("G", true, System.Globalization.CultureInfo.InvariantCulture))
            {
                multiplier = 1000000000;
                str = str.TrimEnd('G', 'g');
            }

            return Convert.ToInt32(str) * multiplier;
        }

        private QueryPlan CompleteQueryPlan(DataTable actualStatsTable, DataTable estimatedStatsTable)
        {
            // Verify whether the both tables have the same number of rows.
            bool collectEstimatedStats = actualStatsTable.Rows.Count == estimatedStatsTable.Rows.Count;

            QueryPlan ret = new QueryPlan();

            Stack<QueryPlanNode> stack = new Stack<QueryPlanNode>();
            int rowIndex = 0;
            int prevLevel = -1;
            foreach (DataRow actualRow in actualStatsTable.Rows)
            {
                DataRow estimatedRow = collectEstimatedStats ? estimatedStatsTable.Rows[rowIndex] : null;

                string operatorNameRaw = Convert.ToString(actualRow["Operation"]);
                string idRaw = Convert.ToString(actualRow["Id"]);
                string actualRowsRaw = Convert.ToString(actualRow["A-Rows"]);
                string estimatedRowsRaw1 = Convert.ToString(actualRow["E-Rows"]);
                string estimatedRowsRaw2 = estimatedRow != null ? Convert.ToString(estimatedRow["Rows"]) : string.Empty;
                string costRaw = estimatedRow != null ? Convert.ToString(estimatedRow["Cost (%CPU)"]) : string.Empty;
                string actualTimeRaw = Convert.ToString(actualRow["A-Time"]);
                
                string operatorName = Convert.ToString(operatorNameRaw).Trim();
                int id = Convert.ToInt32(idRaw.Replace("*", string.Empty).Trim());
                int actualRows = ParseInt(actualRowsRaw);
                int estimatedRows = !string.IsNullOrWhiteSpace(estimatedRowsRaw1) ? ParseInt(estimatedRowsRaw1) : ParseInt(estimatedRowsRaw2);
                int cost = costRaw.Contains("(") ? ParseInt(costRaw.Remove(costRaw.IndexOf('('))) : ParseInt(costRaw);
                TimeSpan actualTime = TimeSpan.Parse(actualTimeRaw);

                // Count tree level (number of initial spaces).
                int level = 0;
                while (level < operatorNameRaw.Length && operatorNameRaw[level] == ' ')
                {
                    level++;
                }
                level--; // The first character is always a space.

                if (level <= prevLevel)
                {
                    for (int i = level; i <= prevLevel; i++)
                    {
                        stack.Pop();
                    }
                }
                prevLevel = level;

                QueryPlanNode parent = stack.Count > 0 ? stack.Peek() : null;

                QueryPlanNode node = new QueryPlanNode();
                node.OpName = operatorName;
                node.ActualRows = actualRows;
                node.EstimatedRows = estimatedRows;
                node.EstimatedCost = cost;
                node.ActualTime = actualTime;
                
                if (parent != null)
                {
                    parent.ChildNodes.Add(node);
                    node.Parent = parent;
                }

                if (ret.Root == null)
                {
                    ret.Root = node;
                }

                stack.Push(node);

                rowIndex++;
            }

            return ret;
        }

        public override QueryPlan GetQueryPlan(string query)
        {
            query = query.Trim();
            if (!IsAnonymousBlock(query))
            {
                query = query.TrimEnd(';');
            }

            OracleDataReader reader = null;
            try
            {
                // Execute the query.
                OracleCommand cmdExecute = connection.CreateCommand();
                cmdExecute.CommandText = query;
                cmdExecute.ExecuteNonQuery();

                // Gather actual statistics.
                OracleCommand cmdGetActualStats = connection.CreateCommand();
                cmdGetActualStats.CommandText = @"
SELECT PLAN_TABLE_OUTPUT 
FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR(FORMAT=>'ALLSTATS LAST'))";
                reader = cmdGetActualStats.ExecuteReader();
                StringWriter actualStatsWriter = new StringWriter();
                while (reader.Read())
                {
                    actualStatsWriter.WriteLine(reader.GetString(0));
                }
                reader.Close();
                reader = null;
                DataTable actualStatsTable = new DataTable();
                ParsePlanOutput(actualStatsWriter.ToString(), actualStatsTable);

                // Gather estimated statistics.
                OracleCommand cmdEstimate = connection.CreateCommand();
                cmdEstimate.CommandText = "EXPLAIN PLAN FOR " + query;
                cmdEstimate.ExecuteNonQuery();

                OracleCommand cmdGetEstimatedStats = connection.CreateCommand();
                cmdGetEstimatedStats.CommandText = @"
SELECT PLAN_TABLE_OUTPUT
FROM TABLE(DBMS_XPLAN.DISPLAY)";
                reader = cmdGetEstimatedStats.ExecuteReader();
                StringWriter estimatedStatsWriter = new StringWriter();
                while (reader.Read())
                {
                    estimatedStatsWriter.WriteLine(reader.GetString(0));
                }
                reader.Close();
                reader = null;
                DataTable estimatedStatsTable = new DataTable();
                ParsePlanOutput(estimatedStatsWriter.ToString(), estimatedStatsTable);
                
                // Complete actual and estimated statistics into a query plan.
                QueryPlan ret = CompleteQueryPlan(actualStatsTable, estimatedStatsTable);
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

        public override QueryStatistics GetQueryStatistics(string query, bool retrieveWholeResult)
        {
            // Odstranit zbytecne bile znaky a strednik z konce prikazu.
            query = query.Trim();
            if (!IsAnonymousBlock(query))
            {
                query = query.TrimEnd(';');
            }

            OracleDataReader reader = null;
            try
            {
                QueryStatistics ret = new QueryStatistics();

                //long t0 = 0;

                //OracleCommand cmdGetSqlId = connection.CreateCommand();
                //cmdGetSqlId.CommandText = "SELECT SQL_ID FROM V$SQL WHERE dbms_lob.compare(SQL_FULLTEXT, :sql) = 0";
                //cmdGetSqlId.Parameters.Add("sql", query);

                //object sqlIdObj = cmdGetSqlId.ExecuteScalar();
                //string sqlId = null;
                //if (sqlIdObj != null)
                //{
                //    sqlId = Convert.ToString(sqlIdObj);
                //    OracleCommand cmdGetT0 = connection.CreateCommand();
                //    cmdGetT0.CommandText = "SELECT CPU_TIME FROM V$SQL WHERE SQL_ID = :sqlid";
                //    cmdGetT0.Parameters.Add("sqlid", sqlId);
                //    object t0obj = cmdGetT0.ExecuteScalar();
                //    t0 = Convert.ToInt64(t0obj);
                //}

                OracleCommand cmdQuery = connection.CreateCommand();
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

                    OracleDataAdapter adapter = new OracleDataAdapter(cmdQuery);
                    adapter.ReturnProviderSpecificTypes = true;
                    adapter.Fill(ret.Result);
                    resultSize = ret.Result.Rows.Count;
                }

                DateTime t1 = DateTime.Now;

                //if (sqlIdObj is null)
                //{
                //    sqlIdObj = cmdGetSqlId.ExecuteScalar();
                //    if (sqlIdObj is null)
                //    {
                //        throw new Exception("Unexpected exception. Cannot retrieve SQL_ID of the query.");
                //    }
                //    sqlId = Convert.ToString(sqlIdObj);
                //}

                //OracleCommand cmdGetT1 = connection.CreateCommand();
                //cmdGetT1.CommandText = "SELECT CPU_TIME FROM V$SQL WHERE SQL_ID = :sqlid";
                //cmdGetT1.Parameters.Add("sqlid", sqlId);
                //object t1Obj = cmdGetT1.ExecuteScalar();
                //long t1 = Convert.ToInt64(t1Obj);

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

        public override void LoadFromXml(XElement element)
        {
            useConnectionString = Convert.ToBoolean(element.Attribute("use_connection_string").Value);
            userName = element.Attribute("user_name").Value;
            password = element.Attribute("password").Value;
            hostName = element.Attribute("host_name").Value;
            port = Convert.ToInt32(element.Attribute("port").Value);
            sID = element.Attribute("s_id").Value;
            connectionString = element.Attribute("connection_string").Value;

            if (element.Attribute("command_timeout") != null)
            {
                commandTimeout = Convert.ToInt32(element.Attribute("command_timeout").Value);
            }
            else
            {
                commandTimeout = 60;
            }

            if (element.Attribute("disable_parallel_query_processing") != null)
            {
                disableParallelQueryProcessing = Convert.ToBoolean(element.Attribute("disable_parallel_query_processing").Value);
            }
        }

        public override void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("use_connection_string", useConnectionString));
            element.Add(new XAttribute("user_name", userName));
            element.Add(new XAttribute("password", password));
            element.Add(new XAttribute("host_name", hostName));
            element.Add(new XAttribute("port", port));
            element.Add(new XAttribute("s_id", sID));
            element.Add(new XAttribute("connection_string", connectionString));
            element.Add(new XAttribute("command_timeout", commandTimeout));
            element.Add(new XAttribute("disable_parallel_query_processing", disableParallelQueryProcessing));
        }
    }
}
