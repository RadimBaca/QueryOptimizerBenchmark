using FirebirdSql.Data.FirebirdClient;
using SqlOptimizerBechmark.Benchmark;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.DbProviders.Firebird
{
    public class FirebirdProvider: DbProvider
    {
        #region Fields

        private bool useConnectionString = false;
        private string hostName = string.Empty;
        private string userName = string.Empty;
        private string password = string.Empty;
        private string database = string.Empty;
        private bool adminRole = false;
        private string connectionString = string.Empty;
        private int commandTimeout = 60;

        private FbConnection connection;

        #endregion

        public override string GetSettingsInfo()
        {
            if (!useConnectionString)
            {
                return $"dbms=Firebird|hostName={hostName}|userName={userName}|password={password}|database={database}|adminRole={adminRole}|commandTimeout={commandTimeout}";
            }
            else
            {
                return $"dbms=Firebird|hostName={hostName}|connectionString={connectionString}|commandTimeout={commandTimeout}";
            }
        }

        #region Properties

        public override string Name => "Firebird";

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

        public string Database
        {
            get => database;
            set => database = value;
        }

        public bool AdminRole
        {
            get => adminRole;
            set => adminRole = value;
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
            database = element.Attribute("database").Value;
            adminRole = Convert.ToBoolean(element.Attribute("admin_role").Value);
            connectionString = element.Attribute("connection_string").Value;
            commandTimeout = Convert.ToInt32(element.Attribute("command_timeout").Value);
        }

        public override void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("use_connection_string", useConnectionString));
            element.Add(new XAttribute("host_name", hostName));
            element.Add(new XAttribute("user_name", userName));
            element.Add(new XAttribute("password", password));
            element.Add(new XAttribute("database", database));
            element.Add(new XAttribute("admin_role", adminRole));
            element.Add(new XAttribute("connection_string", connectionString));
            element.Add(new XAttribute("command_timeout", commandTimeout));
        }

        public override DbProviderSettingsControl CreateSettingsControl()
        {
            FirebirdSettingsControl ctl = new FirebirdSettingsControl();
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
                string format = "User={0}; Password={1}; Database={2}; DataSource={3}";
                if (adminRole)
                {
                    format += "; Role=rdb$admin";
                }

                string ret = string.Format(format, userName, password, database, hostName);
                return ret;
            }
        }

        public override void Connect()
        {
            connection = new FbConnection();
            connection.ConnectionString = GetConnectionString();
            connection.Open();
        }

        public override void Close()
        {
            connection.Close();
        }

        public override void Execute(string statement)
        {
            FbCommand command = connection.CreateCommand();
            command.CommandText = statement;
            command.ExecuteNonQuery();
        }

        public override QueryPlan GetQueryPlan(string query)
        {
            FbCommand command = connection.CreateCommand();
            command.CommandText = query;

            command.ExecuteNonQuery(); // Does not actually run the query.

            string planStr = command.CommandPlan;

            QueryPlan ret = new QueryPlan();
            ret.Root = new QueryPlanNode() { OpName = planStr };
            return ret;
        }

        private static class FbStatsCollector
        {
            private static bool finished;
            private static int resultSize;
            private static DataTable result;
            private static TimeSpan queryProcessingTime;
            private static Exception exception;

            public static bool Finished
            {
                get => finished;
            }

            public static int ResultSize
            {
                get => resultSize;
            }

            public static DataTable Result
            {
                get => result;
            }

            public static TimeSpan QueryProcessingTime
            {
                get => queryProcessingTime;
            }

            public static Exception Exception
            {
                get => exception;
            }

            public static void Clear()
            {
                finished = false;
                resultSize = 0;
                result = null;
                queryProcessingTime = TimeSpan.Zero;
                exception = null;
            }
            
            public static void GetStatsResultSizeCore(FbCommand cmd, bool retrieveWholeResult)
            {
                try
                {
                    int resultSize = 0;
                    DateTime t0 = DateTime.Now;
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultSize++;
                        }
                    }
                    DateTime t1 = DateTime.Now;
                    FbStatsCollector.resultSize = resultSize;
                    FbStatsCollector.queryProcessingTime = t1 - t0;
                }
                catch (Exception ex)
                {
                    FbStatsCollector.exception = ex;
                }
            }

            public static void GetStatsWholeResultCore(FbCommand cmd, bool retrieveWholeResult)
            {
                try
                {
                    int resultSize = 0;
                    DateTime t0 = DateTime.Now;
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        FbStatsCollector.result = table;
                        FbStatsCollector.resultSize = table.Rows.Count;
                    }
                    cmd = null;
                    DateTime t1 = DateTime.Now;
                    FbStatsCollector.resultSize = resultSize;
                    FbStatsCollector.queryProcessingTime = t1 - t0;
                    FbStatsCollector.finished = true;
                }
                catch (Exception ex)
                {
                    FbStatsCollector.exception = ex;
                }
            }

        }

        public override QueryStatistics GetQueryStatistics(string query, bool retrieveWholeResult)
        {
            FbCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;

            Thread thread;
            FbStatsCollector.Clear();
            if (retrieveWholeResult)
            {
                thread = new Thread(() => FbStatsCollector.GetStatsWholeResultCore(cmd, retrieveWholeResult));
            }
            else
            {
                thread = new Thread(() => FbStatsCollector.GetStatsResultSizeCore(cmd, retrieveWholeResult));
            }

            thread.Start();

            DateTime t0 = DateTime.Now;
            while (!FbStatsCollector.Finished)
            {
                Thread.Yield();
                DateTime t1 = DateTime.Now;
                TimeSpan span = t1 - t0;
                if (span.TotalSeconds >= commandTimeout)
                {
                    cmd.Cancel();
                    break;
                }
            }

            thread.Join();
            
            if (FbStatsCollector.Exception != null)
            {
                throw FbStatsCollector.Exception;
            }
            
            QueryStatistics ret = new QueryStatistics();
            ret.QueryProcessingTime = FbStatsCollector.QueryProcessingTime;
            ret.ResultSize = FbStatsCollector.ResultSize;
            ret.Result = FbStatsCollector.Result;
            return ret;
        }



        public override void ExportToFileSystem(string path, Benchmark.Benchmark benchmark)
        {
            throw new NotImplementedException();
        }

        public override string GetTestingScript(Benchmark.Benchmark benchmark)
        {
            throw new NotImplementedException();
        }
    }
}
