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
        private bool disableParallelQueryProcessing = false;

        private SqlConnection connection;

        #endregion

        public override string GetSettingsInfo()
        {
            if (!useConnectionString)
            {
                return $"dbms=SqlServer|dataSource={DataSource}|initialCatalog={initialCatalog}|integratedSecurity={integratedSecurity}|userId={userId}|password={password}|disableParallelQueryProcessing={disableParallelQueryProcessing}";
            }
            else
            {
                return $"dbms=SqlServer|connectionString={connectionString}|disableParallelQueryProcessing={disableParallelQueryProcessing}";
            }
        }

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

        public bool DisableParallelQueryProcessing
        {
            get => disableParallelQueryProcessing;
            set => disableParallelQueryProcessing = value;
        }

        public SqlConnection Connection
        {
            get => connection;
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

            if (element.Attribute("disable_parallel_query_processing") != null)
            {
                disableParallelQueryProcessing = Convert.ToBoolean(element.Attribute("disable_parallel_query_processing").Value);
            }
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
            element.Add(new XAttribute("disable_parallel_query_processing", disableParallelQueryProcessing));
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

        public override QueryStatistics GetQueryStatistics(string query, bool retrieveWholeResult)
        {
            SqlDataReader reader = null;
            try
            {
                if (disableParallelQueryProcessing)
                {
                    query += " OPTION (MAXDOP 1)";
                }

                QueryStatistics ret = new QueryStatistics();

                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandText = query;
                
                if (!retrieveWholeResult)
                {
                    reader = cmd1.ExecuteReader();
                    int resultSize = 0;
                    while (reader.Read())
                    {
                        resultSize++;
                    }
                    reader.Close();
                    reader = null;
                    ret.ResultSize = resultSize;
                }
                else
                {
                    reader = cmd1.ExecuteReader();
                    ret.Result = new System.Data.DataTable();
                    ret.Result.Load(reader);
                    ret.ResultSize = ret.Result.Rows.Count;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                        reader = null;
                    }
                }

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

        private IEnumerable<XElement> FindNearestDescendants(XElement element, string name)
        {
            foreach (XElement child in element.Elements())
            {
                if (child.Name.LocalName == name)
                {
                    yield return child;
                }
                else
                {
                    foreach (XElement ret in FindNearestDescendants(child, name))
                    {
                        yield return ret;
                    }
                }
            }
        }

        private void ParseQueryPlanNode(QueryPlanNode node, XElement element)
        {
            XAttribute aOpName = element.Attribute("PhysicalOp");
            node.OpName = aOpName.Value;

            XAttribute aEstimatedRows = element.Attribute("EstimateRows");
            if (aEstimatedRows != null)
            {
                node.EstimatedRows = Convert.ToDouble(aEstimatedRows.Value, System.Globalization.CultureInfo.InvariantCulture);
            }

            XAttribute aCost = element.Attribute("EstimatedTotalSubtreeCost");
            if (aCost != null)
            {
                node.EstimatedCost = Convert.ToDouble(aCost.Value, System.Globalization.CultureInfo.InvariantCulture);
            }

            XElement eRunTimeInformation = element.Element(XName.Get("RunTimeInformation", element.Name.NamespaceName));
            if (eRunTimeInformation != null)
            {
                int actualRowsTotal = 0;
                int msTotal = 0;
                foreach (XElement eRunTimeCountersPerThread in eRunTimeInformation.Elements(XName.Get("RunTimeCountersPerThread", element.Name.NamespaceName)))
                {
                    int actualRows = Convert.ToInt32(eRunTimeCountersPerThread.Attribute("ActualRows").Value);
                    actualRowsTotal += actualRows;

                    XAttribute aActualElapsedMs = eRunTimeCountersPerThread.Attribute("ActualElapsedms");
                    if (aActualElapsedMs != null)
                    {
                        int ms = Convert.ToInt32(aActualElapsedMs.Value);
                        msTotal += ms;
                    }
                }
                node.ActualRows = actualRowsTotal;
                node.ActualTime = TimeSpan.FromMilliseconds(msTotal);
            }

            foreach (XElement eChildNode in FindNearestDescendants(element, "RelOp"))
            {
                QueryPlanNode child = new QueryPlanNode();
                ParseQueryPlanNode(child, eChildNode);

                node.ChildNodes.Add(child);
                child.Parent = node;
            }
        }

        private void ParsePlan(QueryPlan plan, XDocument document)
        {
            XElement root = document.Root;
            XElement rootOpElement = FindNearestDescendants(root, "RelOp").First();
            QueryPlanNode rootNode = new QueryPlanNode();
            ParseQueryPlanNode(rootNode, rootOpElement);
            plan.Root = rootNode;
        }
        
        public override QueryPlan GetQueryPlan(string query)
        {
            if (disableParallelQueryProcessing)
            {
                query += " OPTION (MAXDOP 1)";
            }

            SqlDataReader reader = null;
            QueryPlan ret = new QueryPlan();

            try
            {
                SqlCommand cmdEnableShowPlan = connection.CreateCommand();
                cmdEnableShowPlan.CommandText = "SET STATISTICS XML ON";
                cmdEnableShowPlan.ExecuteNonQuery();

                SqlCommand cmdGetPlan = connection.CreateCommand();
                cmdGetPlan.CommandText = query;
                reader = cmdGetPlan.ExecuteReader();

                // Skip the first result (command text).
                if (reader.NextResult())
                {
                    if (reader.Read())
                    {
                        string xml = reader.GetString(0);
                        XDocument doc = new XDocument();
                        doc = XDocument.Parse(xml);
                        ParsePlan(ret, doc);
                    }
                }

                reader.Close();
                reader = null;

                SqlCommand cmdDisableShowPlan = connection.CreateCommand();
                cmdDisableShowPlan.CommandText = "SET STATISTICS XML OFF";
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

        public override DbBenchmarkObjectWriter CreateBenchmarkObjectWriter()
        {
            return new SqlBenchmarkObjectWriter(this);
        }
    }
}
