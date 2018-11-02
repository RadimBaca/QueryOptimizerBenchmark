using System;
using System.Collections.Generic;
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

        private OracleConnection connection;

        #endregion

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

        public override void Execute(string statement)
        {
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "BEGIN EXECUTE IMMEDIATE :cmd; END;";
            command.Parameters.Add("cmd", statement);
            command.ExecuteNonQuery();
        }

        public override void ExportToFileSystem(string path, Benchmark.Benchmark benchmark)
        {
        }

        public override string GetQueryPlan(string query)
        {
            OracleDataReader reader = null;
            try
            {
                OracleCommand cmdDelete = connection.CreateCommand();
                cmdDelete.CommandText = "DELETE FROM PLAN_TABLE";
                cmdDelete.ExecuteNonQuery();

                OracleCommand cmdExplain = connection.CreateCommand();
                cmdExplain.CommandText = "EXPLAIN PLAN FOR " + query;
                cmdExplain.ExecuteNonQuery();

                OracleCommand cmdGetPlan = connection.CreateCommand();
                cmdGetPlan.CommandText = @"
SELECT depth, operation
FROM PLAN_TABLE
ORDER BY id";
                string ret = string.Empty;

                reader = cmdGetPlan.ExecuteReader();
                while (reader.Read())
                {
                    if (ret != string.Empty)
                    {
                        ret += Environment.NewLine;
                    }

                    int depth = Convert.ToInt32(reader["depth"]);
                    string operation = Convert.ToString(reader["operation"]);

                    string line = string.Empty;
                    for (int i = 0; i < depth; i++)
                    {
                        line += "    ";
                    }
                    line += "|--" + operation;
                    ret += line;
                }
                reader.Close();
                reader = null;

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

        public override QueryStatistics GetQueryStatistics(string query)
        {
            OracleDataReader reader = null;
            try
            {
                QueryStatistics ret = new QueryStatistics();

                long t0 = 0;

                OracleCommand cmdGetSqlId = connection.CreateCommand();
                cmdGetSqlId.CommandText = "SELECT SQL_ID FROM V$SQL WHERE dbms_lob.compare(SQL_FULLTEXT, :sql) = 0";
                cmdGetSqlId.Parameters.Add("sql", query);

                object sqlIdObj = cmdGetSqlId.ExecuteScalar();
                string sqlId = null;
                if (sqlIdObj != null)
                {
                    sqlId = Convert.ToString(sqlIdObj);
                    OracleCommand cmdGetT0 = connection.CreateCommand();
                    cmdGetT0.CommandText = "SELECT CPU_TIME FROM V$SQL WHERE SQL_ID = :sqlid";
                    cmdGetT0.Parameters.Add("sqlid", sqlId);
                    object t0obj = cmdGetT0.ExecuteScalar();
                    t0 = Convert.ToInt64(t0obj);
                }

                OracleCommand cmdQuery = connection.CreateCommand();
                cmdQuery.CommandText = query;
                cmdQuery.CommandTimeout = commandTimeout;

                int resultSize = 0;
                reader = cmdQuery.ExecuteReader();
                while (reader.Read())
                {
                    resultSize++;
                }
                reader.Close();
                reader = null;

                if (sqlIdObj is null)
                {
                    sqlIdObj = cmdGetSqlId.ExecuteScalar();
                    if (sqlIdObj is null)
                    {
                        throw new Exception("Unexpected exception. Cannot retrieve SQL_ID of the query.");
                    }
                    sqlId = Convert.ToString(sqlIdObj);
                }

                OracleCommand cmdGetT1 = connection.CreateCommand();
                cmdGetT1.CommandText = "SELECT CPU_TIME FROM V$SQL WHERE SQL_ID = :sqlid";
                cmdGetT1.Parameters.Add("sqlid", sqlId);
                object t1Obj = cmdGetT1.ExecuteScalar();
                long t1 = Convert.ToInt64(t1Obj);

                ret.QueryProcessingTime = TimeSpan.FromMilliseconds((t1 - t0) / 1000.0);
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
        }
    }
}
