using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.DbProviders.SqlServer
{
    public class SqlServerProvider: DbProvider
    {
        #region Fields

        private bool useConnectionString = false;
        private string dataSource = string.Empty;
        private string initialCatalog = string.Empty;
        private bool integratedSecurity = true;
        private string userId = string.Empty;
        private string password = string.Empty;
        private string connectionString = string.Empty;

        private SqlConnection connection;

        #endregion

        #region Properties

        public override string Name => "Microsoft SQL Server";

        public bool UseConnectionString
        {
            get => useConnectionString;
            set => useConnectionString = value;
        }

        public string DataSource
        {
            get => dataSource;
            set => dataSource = value;
        }

        public string InitialCatalog
        {
            get => initialCatalog;
            set => initialCatalog = value;
        }

        public bool IntegratedSecurity
        {
            get => integratedSecurity;
            set => integratedSecurity = value;
        }

        public string UserId
        {
            get => userId;
            set => userId = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string ConnectionString
        {
            get => connectionString;
            set => connectionString = value;
        }

        #endregion

        public override void LoadFromXml(XElement element)
        {
            useConnectionString = Convert.ToBoolean(element.Attribute("use_connection_string").Value);
            dataSource = element.Attribute("data_source").Value;
            initialCatalog = element.Attribute("initial_catalog").Value;
            integratedSecurity = Convert.ToBoolean(element.Attribute("integrated_security").Value);
            userId = element.Attribute("user_id").Value;
            password = element.Attribute("password").Value;
            connectionString = element.Attribute("connection_string").Value;
        }

        public override void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("use_connection_string", useConnectionString));
            element.Add(new XAttribute("data_source", dataSource));
            element.Add(new XAttribute("initial_catalog", initialCatalog));
            element.Add(new XAttribute("integrated_security", integratedSecurity));
            element.Add(new XAttribute("user_id", userId));
            element.Add(new XAttribute("password", password));
            element.Add(new XAttribute("connection_string", connectionString));
        }

        public override DbProviderSettingsControl CreateSettingsControl()
        {
            SqlServerSettingsControl ctl = new SqlServerSettingsControl();
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
                if (integratedSecurity)
                {
                    string format = "data source = {0}; initial catalog = {1}; integrated security = true;";
                    string ret = string.Format(format, dataSource, initialCatalog);
                    return ret;
                }
                else
                {
                    string format = "data source = {0}; initial catalog = {1}; user id = {2}; password = {3}";
                    string ret = string.Format(format, dataSource, initialCatalog, userId, password);
                    return ret;
                }
            }
        }

        public override void Connect()
        {
            connection = new SqlConnection();
            connection.ConnectionString = GetConnectionString();
            connection.Open();
        }


        public override void Close()
        {
            connection.Close();
        }

        public override void Execute(string statement)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "sp_executesql @stmt";
            command.Parameters.AddWithValue("stmt", statement);
            command.ExecuteNonQuery();
        }

        public override QueryStatistics GetQueryStatistics(string query)
        {
            SqlDataReader reader = null;
            try
            {
                QueryStatistics ret = new QueryStatistics();

                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandText = query;
                reader = cmd1.ExecuteReader();
                int resultSize = 0;
                while (reader.Read())
                {
                    resultSize++;
                }
                reader.Close();
                reader = null;
                ret.ResultSize = resultSize;

                connection.ResetStatistics();
                connection.StatisticsEnabled = true;
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = query;
                cmd2.ExecuteNonQuery();
                var statistics = connection.RetrieveStatistics();
                long ms = (long)statistics["ExecutionTime"];
                ret.QueryProcessingTime = TimeSpan.FromMilliseconds(ms);

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
                connection.StatisticsEnabled = false;
            }
        }

        private string ParsePlanLine(string line)
        {
            int index1 = line.IndexOf("(");
            if (index1 > 0)
            {
                string opName = line.Substring(0, index1);
                return opName;
            }
            else
            {
                return null;
            }
        }
        
        public override string GetQueryPlan(string query)
        {
            SqlDataReader reader = null;

            try
            {
                string ret = string.Empty;

                SqlCommand cmdEnableShowPlan = connection.CreateCommand();
                cmdEnableShowPlan.CommandText = "SET SHOWPLAN_TEXT ON";
                cmdEnableShowPlan.ExecuteNonQuery();

                SqlCommand cmdGetPlan = connection.CreateCommand();
                cmdGetPlan.CommandText = query;
                reader = cmdGetPlan.ExecuteReader();

                // Skip the first result (command text).
                if (reader.NextResult())
                {
                    ret = string.Empty;
                    while (reader.Read())
                    {
                        if (ret != string.Empty)
                        {
                            ret += Environment.NewLine;
                        }

                        string line = Convert.ToString(reader[0]);
                        if (line != null)
                        {
                            ret += ParsePlanLine(line);
                        }
                    }
                }

                reader.Close();
                reader = null;

                SqlCommand cmdDisableShowPlan = connection.CreateCommand();
                cmdDisableShowPlan.CommandText = "SET SHOWPLAN_TEXT OFF";
                cmdDisableShowPlan.ExecuteNonQuery();

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

        private static string GetSqlString(string str)
        {
            return str.Replace("'", "''");
        }

        private static string GetComment(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }
            else
            {
                return "-- " + str.Replace("\n", "\n-- ");
            }
        }

        public override string GetTestingScript(Benchmark.Benchmark benchmark)
        {
            StringWriter writer = new StringWriter();

            writer.WriteLine(SqlServerProviderResources.SqlInitScript);

            writer.WriteLine("GO");

            Benchmark.StatementList initScriptStatements = benchmark.InitScript.GetStatementList(this.Name);
            foreach (Benchmark.Statement statement in initScriptStatements.Statements)
            {
                writer.WriteLine(statement.CommandText);
                writer.WriteLine("GO");
            }

            foreach (Benchmark.TestGroup testGroup in benchmark.TestGroups)
            {
                bool activeTests = false;
                foreach (Benchmark.Test test in testGroup.Tests)
                {
                    if (test.Active)
                    {
                        activeTests = true;
                        break;
                    }
                }
                if (!activeTests)
                {
                    continue;
                }

                writer.WriteLine();
                writer.WriteLine("---------------------------------------------------------------------------------------------------------------");
                writer.WriteLine("-- test group: " + testGroup.Name.ToUpper());
                if (!string.IsNullOrWhiteSpace(testGroup.Description))
                {
                    writer.WriteLine(GetComment(testGroup.Description));
                }
                writer.WriteLine("---------------------------------------------------------------------------------------------------------------");
                writer.WriteLine("PRINT 'GROUP: {0}'", GetSqlString(testGroup.Name));

                foreach (Benchmark.Configuration configuration in testGroup.Configurations)
                {
                    writer.WriteLine();
                    writer.WriteLine("-- configuration: " + configuration.Name.ToUpper());
                    if (!string.IsNullOrWhiteSpace(configuration.Description))
                    {
                        writer.WriteLine(GetComment(configuration.Description));
                    }

                    writer.WriteLine("PRINT '    CONFIGURATION: {0}'", GetSqlString(configuration.Name));

                    Benchmark.StatementList configurationInitScriptStatements = configuration.InitScript.GetStatementList(this.Name);
                    foreach (Benchmark.Statement statement in configurationInitScriptStatements.Statements)
                    {
                        writer.WriteLine(statement.CommandText);
                        writer.WriteLine("GO");
                    }

                    foreach (Benchmark.Test test in testGroup.Tests)
                    {
                        if (!test.Active)
                        {
                            continue;
                        }

                        if (test is Benchmark.PlanEquivalenceTest planEquivalenceTest)
                        {
                            writer.WriteLine();
                            writer.WriteLine("-- test: " + planEquivalenceTest.Name.ToUpper());
                            if (!string.IsNullOrWhiteSpace(planEquivalenceTest.Description))
                            {
                                writer.WriteLine(GetComment(planEquivalenceTest.Description));
                            }
                            writer.WriteLine("PRINT '        TEST: {0}'", GetSqlString(planEquivalenceTest.Name));

                            string sqlVariantsScript = string.Empty;

                            foreach (Benchmark.QueryVariant variant in planEquivalenceTest.Variants)
                            {
                                if (sqlVariantsScript != string.Empty)
                                {
                                    sqlVariantsScript += Environment.NewLine;
                                    sqlVariantsScript += Environment.NewLine;
                                }

                                string commandText = variant.GetStatement(this.Name).CommandText;
                                sqlVariantsScript += string.Format(SqlServerProviderResources.SqlVariantScript, GetSqlString(commandText));
                            }

                            string sqlTestScript = string.Format(SqlServerProviderResources.SqlTestScript,
                                GetSqlString(testGroup.Name), GetSqlString(configuration.Name), GetSqlString(planEquivalenceTest.Name), sqlVariantsScript);

                            writer.WriteLine(sqlTestScript);
                            writer.WriteLine("GO");
                        }
                    }

                    Benchmark.StatementList configurationCleanUpScriptStatements = configuration.CleanUpScript.GetStatementList(this.Name);
                    foreach (Benchmark.Statement statement in configurationCleanUpScriptStatements.Statements)
                    {
                        writer.WriteLine(statement.CommandText);
                        writer.WriteLine("GO");
                    }
                }
                writer.WriteLine("---------------------------------------------------------------------------------------------------------------");
            }
                        
            Benchmark.StatementList cleanUpScriptStatements = benchmark.CleanUpScript.GetStatementList(this.Name);
            foreach (Benchmark.Statement statement in cleanUpScriptStatements.Statements)
            {
                writer.WriteLine(statement.CommandText);
                writer.WriteLine("GO");
            }
            writer.Close();

            return writer.ToString();
        }

        public override void ExportToFileSystem(string path, Benchmark.Benchmark benchmark)
        {
            StringWriter writer;
            string fileName;
            
            // Description.
            if (!string.IsNullOrWhiteSpace(benchmark.Description))
            {
                writer = new StringWriter();
                writer.WriteLine(benchmark.Description);
                writer.Close();
                fileName = Path.Combine(path, "description.txt");
                File.WriteAllText(fileName, writer.ToString());
            }

            // Init script.
            writer = new StringWriter();
            Benchmark.StatementList initScriptStatements = benchmark.InitScript.GetStatementList(this.Name);
            foreach (Benchmark.Statement statement in initScriptStatements.Statements)
            {
                writer.WriteLine(statement.CommandText);
                writer.WriteLine("GO");
            }
            writer.Close();
            fileName = Path.Combine(path, "init_script.sql");
            File.WriteAllText(fileName, writer.ToString());

            // Test groups.
            foreach (Benchmark.TestGroup testGroup in benchmark.TestGroups)
            {
                bool activeTests = false;
                foreach (Benchmark.Test test in testGroup.Tests)
                {
                    if (test.Active)
                    {
                        activeTests = true;
                        break;
                    }
                }
                if (!activeTests)
                {
                    continue;
                }

                string groupDirectory = Path.Combine(path, testGroup.Name);
                if (!Directory.Exists(groupDirectory))
                {
                    Directory.CreateDirectory(groupDirectory);
                }

                // Description.
                if (!string.IsNullOrWhiteSpace(testGroup.Description))
                {
                    writer = new StringWriter();
                    writer.WriteLine(testGroup.Description);
                    writer.Close();
                    fileName = Path.Combine(groupDirectory, "description.txt");
                    File.WriteAllText(fileName, writer.ToString());
                }

                // Confiurations.
                foreach (Benchmark.Configuration configuration in testGroup.Configurations)
                {
                    string configurationsDirectory = Path.Combine(groupDirectory, "configurations");
                    if (!Directory.Exists(configurationsDirectory))
                    {
                        Directory.CreateDirectory(configurationsDirectory);
                    }
                    string configurationDirectory = Path.Combine(configurationsDirectory, configuration.Name);
                    if (!Directory.Exists(configurationDirectory))
                    {
                        Directory.CreateDirectory(configurationDirectory);
                    }

                    // Description.
                    if (!string.IsNullOrWhiteSpace(configuration.Description))
                    {
                        writer = new StringWriter();
                        writer.WriteLine(configuration.Description);
                        writer.Close();
                        fileName = Path.Combine(configurationDirectory, "description.txt");
                        File.WriteAllText(fileName, writer.ToString());
                    }

                    // Init script.
                    writer = new StringWriter();
                    Benchmark.StatementList configurationInitScriptStatements = configuration.InitScript.GetStatementList(this.Name);
                    foreach (Benchmark.Statement statement in configurationInitScriptStatements.Statements)
                    {
                        writer.WriteLine(statement.CommandText);
                        writer.WriteLine("GO");
                    }
                    writer.Close();
                    fileName = Path.Combine(configurationDirectory, "init_script.sql");
                    File.WriteAllText(fileName, writer.ToString());

                    // Init script.
                    writer = new StringWriter();
                    Benchmark.StatementList configurationCleanUpScriptStatements = configuration.CleanUpScript.GetStatementList(this.Name);
                    foreach (Benchmark.Statement statement in configurationCleanUpScriptStatements.Statements)
                    {
                        writer.WriteLine(statement.CommandText);
                        writer.WriteLine("GO");
                    }
                    writer.Close();
                    fileName = Path.Combine(configurationDirectory, "clean_up_script.sql");
                    File.WriteAllText(fileName, writer.ToString());
                }

                // Tests.
                foreach (Benchmark.Test test in testGroup.Tests)
                {
                    if (!test.Active)
                    {
                        continue;
                    }

                    if (test is Benchmark.PlanEquivalenceTest planEquivalenceTest)
                    {
                        string testsDirectory = Path.Combine(groupDirectory, "tests");
                        if (!Directory.Exists(testsDirectory))
                        {
                            Directory.CreateDirectory(testsDirectory);
                        }
                        string testDirectory = Path.Combine(testsDirectory, planEquivalenceTest.Name);
                        if (!Directory.Exists(testDirectory))
                        {
                            Directory.CreateDirectory(testDirectory);
                        }

                        // Description.
                        if (!string.IsNullOrWhiteSpace(planEquivalenceTest.Description))
                        {
                            writer = new StringWriter();
                            writer.WriteLine(planEquivalenceTest.Description);
                            writer.Close();
                            fileName = Path.Combine(testDirectory, "description.txt");
                            File.WriteAllText(fileName, writer.ToString());
                        }

                        // Variants.
                        foreach (Benchmark.QueryVariant variant in planEquivalenceTest.Variants)
                        {
                            writer = new StringWriter();
                            string commandText = variant.GetStatement(this.Name).CommandText;
                            writer.WriteLine(commandText);
                            writer.Close();

                            fileName = Path.Combine(testDirectory, variant.Name + ".sql");
                            File.WriteAllText(fileName, writer.ToString());
                        }
                    }
                }

                // Clean-up script.
                writer = new StringWriter();
                Benchmark.StatementList cleanUpScriptStatements = benchmark.CleanUpScript.GetStatementList(this.Name);
                foreach (Benchmark.Statement statement in cleanUpScriptStatements.Statements)
                {
                    writer.WriteLine(statement.CommandText);
                    writer.WriteLine("GO");
                }
                writer.Close();
                fileName = Path.Combine(path, "clean_up_script.sql");
                File.WriteAllText(fileName, writer.ToString());
            }
        }
    }
}
