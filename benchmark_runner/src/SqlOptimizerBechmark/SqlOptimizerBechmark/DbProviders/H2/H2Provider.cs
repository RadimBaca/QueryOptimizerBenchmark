using System;
using System.Collections.Generic;
using System.Data;
using System.Data.H2;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.DbProviders.H2
{
    public class H2Provider : DbProvider
    {
        #region Fields

        private bool useConnectionString = false;
        private string url = string.Empty;
        private string user = string.Empty;
        private string password = string.Empty;
        private int commandTimeout;
        private string connectionString = string.Empty;

        private H2Connection connection;

        #endregion

        #region Properties

        public override string Name => "H2";

        public bool UseConnectionString
        {
            get => useConnectionString;
            set => useConnectionString = value;
        }
        
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int CommandTimeout
        {
            get { return commandTimeout; }
            set { commandTimeout = value; }
        }

        public string ConnectionString
        {
            get => connectionString;
            set => connectionString = value;
        }

        #endregion

        public override void Connect()
        {
            connection = new H2Connection();
            connection.ConnectionString = GetConnectionString();
            connection.Open();
        }

        public override void Close()
        {
            connection.Close();
        }

        public string GetConnectionString()
        {
            return string.Format("{0};USER={1};PASSWORD={2}", url, user, password);
        }

        public override DbProviderSettingsControl CreateSettingsControl()
        {
            H2SettingsControl settingsControl = new H2SettingsControl();
            settingsControl.Provider = this;
            return settingsControl;
        }

        public override void Execute(string statement)
        {
            H2Command cmd = connection.CreateCommand();
            cmd.CommandTimeout = commandTimeout;
            cmd.CommandText = statement;
            cmd.ExecuteNonQuery();
        }

        public override QueryPlan GetQueryPlan(string query)
        {
            H2Command cmd = connection.CreateCommand();
            cmd.CommandText = "EXPLAIN PLAN FOR " + query;
            object planObj = cmd.ExecuteScalar();
            if (planObj != null)
            {
                string planStr = planObj.ToString();
                QueryPlan plan = new QueryPlan();
                QueryPlanNode root = new QueryPlanNode();
                root.OpName = planStr;
                plan.Root = root;
                return plan;
            }
            else
            {
                return null;
            }
        }

        public override QueryStatistics GetQueryStatistics(string query, bool retrieveWholeResult)
        {
            H2DataReader reader = null;
            try
            {
                QueryStatistics ret = new QueryStatistics();

                H2Command cmdQuery = connection.CreateCommand();
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

        public override void LoadFromXml(XElement element)
        {
            useConnectionString = Convert.ToBoolean(element.Attribute("use_connection_string").Value);
            url = element.Attribute("url").Value;
            user = element.Attribute("user_name").Value;
            password = element.Attribute("password").Value;            
            connectionString = element.Attribute("connection_string").Value;
            commandTimeout = Convert.ToInt32(element.Attribute("command_timeout").Value);
        }

        public override void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("use_connection_string", useConnectionString));
            element.Add(new XAttribute("url", url));
            element.Add(new XAttribute("user_name", user));
            element.Add(new XAttribute("password", password));
            element.Add(new XAttribute("connection_string", connectionString));
            element.Add(new XAttribute("command_timeout", commandTimeout));
        }

        public override void ExportToFileSystem(string path, Benchmark.Benchmark benchmark)
        {

        }

        public override string GetTestingScript(Benchmark.Benchmark benchmark)
        {
            return null;
        }
    }
}
