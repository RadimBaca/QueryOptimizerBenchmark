using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark
{
    static class Program
    {
        private static void MergeScript(Benchmark.Script msSqlScript, Benchmark.Script oracleScript, Benchmark.Script postgresScript)
        {
            Benchmark.SpecificStatementList msSqlStatementList = new Benchmark.SpecificStatementList(msSqlScript);
            msSqlStatementList.ProviderName = "Microsoft SQL Server";
            foreach (Benchmark.Statement statement in msSqlScript.DefaultStatementList.Statements)
            {
                string commandText = statement.CommandText;
                msSqlStatementList.Statements.Add(new Benchmark.Statement(msSqlStatementList) { CommandText = commandText });
            }
            msSqlScript.SpecificStatementLists.Add(msSqlStatementList);
            // Oracle Init
            Benchmark.SpecificStatementList oracleStatementList = new Benchmark.SpecificStatementList(msSqlScript);
            oracleStatementList.ProviderName = "Oracle Database";
            foreach (Benchmark.Statement statement in oracleScript.DefaultStatementList.Statements)
            {
                string commandText = statement.CommandText;
                oracleStatementList.Statements.Add(new Benchmark.Statement(oracleStatementList) { CommandText = commandText });
            }
            msSqlScript.SpecificStatementLists.Add(oracleStatementList);
            // Postgres Init
            Benchmark.SpecificStatementList postgresStatementList = new Benchmark.SpecificStatementList(msSqlScript);
            postgresStatementList.ProviderName = "PostgreSQL";
            foreach (Benchmark.Statement statement in postgresScript.DefaultStatementList.Statements)
            {
                string commandText = statement.CommandText;
                postgresStatementList.Statements.Add(new Benchmark.Statement(postgresStatementList) { CommandText = commandText });
            }
            msSqlScript.SpecificStatementLists.Add(postgresStatementList);
        }

        private static void MergeVariant(Benchmark.QueryVariant msSqlVariant, Benchmark.QueryVariant oracleVariant, Benchmark.QueryVariant postgresVariant)
        {
            string msSqlCommand = msSqlVariant.DefaultStatement.CommandText.Replace("option(maxdop 1)", string.Empty).Trim();
            string oracleCommand = oracleVariant.DefaultStatement.CommandText.Trim();
            string postgresCommand = postgresVariant.DefaultStatement.CommandText.Trim();

            if (msSqlCommand != oracleCommand ||
                msSqlCommand != postgresCommand)
            {
                msSqlVariant.DefaultStatement.CommandText = msSqlCommand;

                Benchmark.SpecificStatement msSqlStatement = new Benchmark.SpecificStatement(msSqlVariant);
                msSqlStatement.ProviderName = "Microsoft SQL Server";
                msSqlStatement.CommandText = msSqlCommand;
                msSqlVariant.SpecificStatements.Add(msSqlStatement);

                Benchmark.SpecificStatement oracleStatement = new Benchmark.SpecificStatement(msSqlVariant);
                oracleStatement.ProviderName = "Oracle Database";
                oracleStatement.CommandText = oracleCommand;
                msSqlVariant.SpecificStatements.Add(oracleStatement);

                Benchmark.SpecificStatement postgresStatement = new Benchmark.SpecificStatement(msSqlVariant);
                postgresStatement.ProviderName = "PostgreSQL";
                postgresStatement.CommandText = postgresCommand;
                msSqlVariant.SpecificStatements.Add(postgresStatement);
            }
            else
            {
                msSqlVariant.DefaultStatement.CommandText = msSqlCommand;
            }
        }

        private static void MergeTests()
        {
            Benchmark.Benchmark msSql = new Benchmark.Benchmark();
            msSql.Load(@"C:\Users\Petr\source\repos\QueryOptimizerBenchmark\benchmark_runner\ms_sql.xml");

            Benchmark.Benchmark oracle = new Benchmark.Benchmark();
            oracle.Load(@"C:\Users\Petr\source\repos\QueryOptimizerBenchmark\benchmark_runner\oracle.xml");

            Benchmark.Benchmark postgreSql = new Benchmark.Benchmark();
            postgreSql.Load(@"C:\Users\Petr\source\repos\QueryOptimizerBenchmark\benchmark_runner\postgresql.xml");
            
            Benchmark.Benchmark merged = new Benchmark.Benchmark();
            if (msSql.TestGroups.Count > oracle.TestGroups.Count ||
                msSql.TestGroups.Count > postgreSql.TestGroups.Count)
            {
                return;
            }

            MergeScript(msSql.InitScript, oracle.InitScript, postgreSql.InitScript);
            MergeScript(msSql.CleanUpScript, oracle.CleanUpScript, postgreSql.CleanUpScript);

            for (int group = 0; group < msSql.TestGroups.Count; group++)
            {
                Benchmark.TestGroup msSqlGroup = msSql.TestGroups[group];
                Benchmark.TestGroup oracleGroup = oracle.TestGroups[group];
                Benchmark.TestGroup postgresGroup = postgreSql.TestGroups[group];

                if (msSqlGroup.Configurations.Count > oracleGroup.Configurations.Count ||
                    msSqlGroup.Configurations.Count > postgresGroup.Configurations.Count)
                {
                    return;
                }

                if (msSqlGroup.Tests.Count > oracleGroup.Tests.Count ||
                    msSqlGroup.Tests.Count > postgresGroup.Tests.Count)
                {
                    //return;
                }

                for (int config = 0; config < msSqlGroup.Configurations.Count; config++)
                {
                    Benchmark.Configuration msSqlConfiguration = msSqlGroup.Configurations[config];
                    Benchmark.Configuration oracleConfiguration = oracleGroup.Configurations[config];
                    Benchmark.Configuration postgresConfiguration = postgresGroup.Configurations[config];

                    MergeScript(msSqlConfiguration.InitScript, oracleConfiguration.InitScript, postgresConfiguration.InitScript);
                    MergeScript(msSqlConfiguration.CleanUpScript, oracleConfiguration.CleanUpScript, postgresConfiguration.CleanUpScript);
                }

                for (int test = 0; test < msSqlGroup.Tests.Count && test < oracleGroup.Tests.Count &&  test < postgresGroup.Tests.Count; test++)
                {
                    Benchmark.PlanEquivalenceTest msSqlTest = (Benchmark.PlanEquivalenceTest)msSqlGroup.Tests[test];
                    Benchmark.PlanEquivalenceTest oracleTest = (Benchmark.PlanEquivalenceTest)oracleGroup.Tests[test];
                    Benchmark.PlanEquivalenceTest postgresTest = (Benchmark.PlanEquivalenceTest)postgresGroup.Tests[test];

                    for (int variant = 0; variant < msSqlTest.Variants.Count && variant < oracleTest.Variants.Count && variant < postgresTest.Variants.Count; variant++)
                    {
                        Benchmark.QueryVariant msSqlVariant = msSqlTest.Variants[variant];
                        Benchmark.QueryVariant oracleVariant = oracleTest.Variants[variant];
                        Benchmark.QueryVariant postgresVariant = postgresTest.Variants[variant];

                        MergeVariant(msSqlVariant, oracleVariant, postgresVariant);
                    }
                }
            }

            msSql.Save(@"C:\users\petr\desktop\merged.xml");

            MessageBox.Show("OK");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
