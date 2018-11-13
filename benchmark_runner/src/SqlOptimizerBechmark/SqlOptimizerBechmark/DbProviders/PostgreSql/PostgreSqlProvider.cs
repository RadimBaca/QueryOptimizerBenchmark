using Npgsql;
using SqlOptimizerBechmark.Benchmark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.DbProviders.PostgreSql
{
    public class PostgreSqlProvider: DbProvider
    {
        #region Fields

        private bool useConnectionString = false;
        private string host = string.Empty;
        private string userName = string.Empty;
        private string password = string.Empty;
        private string database = string.Empty;
        private string connectionString = string.Empty;
        private int commandTimeout = 30;

        private NpgsqlConnection connection;

        #endregion

        #region Properties

        public override string Name => "PostgreSQL";

        public bool UseConnectionString
        {
            get => useConnectionString;
            set => useConnectionString = value;
        }

        public string Host
        {
            get => host;
            set => host = value;
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
            host = element.Attribute("host").Value;
            userName = element.Attribute("user_name").Value;
            password = element.Attribute("password").Value;
            database = element.Attribute("database").Value;
            commandTimeout = Convert.ToInt32(element.Attribute("command_timeout").Value);
            connectionString = element.Attribute("connection_string").Value;
        }

        public override void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("use_connection_string", useConnectionString));
            element.Add(new XAttribute("host", host));
            element.Add(new XAttribute("user_name", userName));
            element.Add(new XAttribute("password", password));
            element.Add(new XAttribute("database", database));
            element.Add(new XAttribute("command_timeout", commandTimeout));
            element.Add(new XAttribute("connection_string", connectionString));
        }

        public override DbProviderSettingsControl CreateSettingsControl()
        {
            PostgreSqlSettingsControl ctl = new PostgreSqlSettingsControl();
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
                string format = "Host={0};Username={1};Password={2};Database={3};Command timeout={4}";
                string ret = string.Format(format, host, userName, password, database, commandTimeout);
                return ret;
            }
        }

        public override void Connect()
        {
            connection = new NpgsqlConnection();
            connection.ConnectionString = GetConnectionString();
            connection.Open();
        }

        public override void Close()
        {
            connection.Close();
        }

        private void CheckConnection()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Open)
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                    connection = null;
                }

                Connect();
            }
        }

        public override void Execute(string statement)
        {
            CheckConnection();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = statement;
            command.ExecuteNonQuery();
        }

        private void GetPlanStr(ref string destStr, XElement element, int level = 0)
        {
            XNamespace ns = "http://www.postgresql.org/2009/explain";

            for (int i = 0; i < level; i++)
            {
                destStr += "    ";
            }

            if (element.Element(ns + "Node-Type") != null)
            {
                destStr += "|--" + element.Element(ns + "Node-Type").Value + Environment.NewLine;
            }

            if (element.Element(ns + "Plans") != null)
            {
                foreach (XElement child in element.Element(ns + "Plans").Elements(ns + "Plan"))
                {
                    GetPlanStr(ref destStr, child, level + 1);
                }
            }
        }
        
        public override QueryStatistics GetQueryStatistics(string query)
        {
            CheckConnection();

            string sql = "EXPLAIN (ANALYZE, FORMAT XML) " + query;

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            object obj = command.ExecuteScalar();

            string xmlStr = Convert.ToString(obj);
            XDocument document = XDocument.Parse(xmlStr);

            QueryStatistics ret = new QueryStatistics();

            XNamespace ns = "http://www.postgresql.org/2009/explain";

            string actualRowsStr = document.Element(ns + "explain").Element(ns + "Query").Element(ns + "Plan").Element(ns + "Actual-Rows").Value;
            ret.ResultSize = Convert.ToInt32(actualRowsStr);

            string executionTime = document.Element(ns + "explain").Element(ns + "Query").Element(ns + "Execution-Time").Value;
            double milliseconds = double.Parse(executionTime, System.Globalization.CultureInfo.InvariantCulture);
            ret.QueryProcessingTime = TimeSpan.FromMilliseconds(milliseconds);

            return ret;
        }


        public override string GetQueryPlan(string query)
        {
            CheckConnection();

            string sql = "EXPLAIN (FORMAT XML) " + query;

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            object obj = command.ExecuteScalar();

            string xmlStr = Convert.ToString(obj);
            XDocument document = XDocument.Parse(xmlStr);

            XNamespace ns = "http://www.postgresql.org/2009/explain";

            string ret = string.Empty;
            GetPlanStr(ref ret, document.Element(ns + "explain").Element(ns + "Query").Element(ns + "Plan"));

            return ret;
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
