using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.DbProviders
{
    public abstract class DbProvider
    {
        private DbProviderSettingsControl settingsControl = null;


        public abstract string Name
        {
            get;
        }            

        public abstract void Connect();
        
        public abstract void Close();

        public abstract void SaveToXml(XElement element);

        public abstract void LoadFromXml(XElement element);

        public abstract DbProviderSettingsControl CreateSettingsControl();
      



        public abstract void Execute(string statement);

        public abstract DataTable ExecuteQuery(string query);

        public abstract QueryStatistics GetQueryStatistics(string query, bool retrieveWholeResult);

        public abstract QueryPlan GetQueryPlan(string query);

        public abstract string GetTestingScript(Benchmark.Benchmark benchmark);

        public abstract void ExportToFileSystem(string path, Benchmark.Benchmark benchmark);

        public virtual string GetSettingsInfo()
        {
            return string.Empty;
        }

        public virtual DbProviderSettingsControl GetSettingsControl()
        {
            if (settingsControl == null)
            {
                settingsControl = CreateSettingsControl();
                settingsControl.Provider = this;
            }

            settingsControl.BindSettings();

            return settingsControl;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual DbBenchmarkObjectWriter CreateBenchmarkObjectWriter()
        {
            return null;
        }

        // TODO - dynamic loading of providers.

        private static SqlServer.SqlServerProvider sqlServerProvider = new SqlServer.SqlServerProvider();
        private static Oracle.OracleProvider oracleProvider = new Oracle.OracleProvider();
        private static PostgreSql.PostgreSqlProvider postgreSqlProvider = new PostgreSql.PostgreSqlProvider();
        private static MySql.MySqlProvider mySqlProvider = new MySql.MySqlProvider();
        private static SQLite.SQLiteProvider sqLiteProvider = new SQLite.SQLiteProvider();
        private static H2.H2Provider h2Provider = new H2.H2Provider();
        private static Firebird.FirebirdProvider firebirdProvider = new Firebird.FirebirdProvider();


        public static IEnumerable<DbProvider> Providers
        {
            get
            {
                yield return sqlServerProvider;
                yield return oracleProvider;
                yield return postgreSqlProvider;
                yield return mySqlProvider;
                yield return sqLiteProvider;
                yield return h2Provider;
                yield return firebirdProvider;
            }
        }

        public static DbProvider GetProvider(string name)
        {
            foreach (DbProvider provider in Providers)
            {
                if (provider.Name == name)
                {
                    return provider;
                }
            }
            return null;
        }
    }
}
