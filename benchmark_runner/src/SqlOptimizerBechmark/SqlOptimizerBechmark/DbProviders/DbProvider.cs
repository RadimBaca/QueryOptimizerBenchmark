using System;
using System.Collections.Generic;
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

        public abstract QueryStatistics GetQueryStatistics(string query);

        public abstract string GetQueryPlan(string query);

        public abstract string GetTestingScript(Benchmark.Benchmark benchmark);

        public abstract void ExportToFileSystem(string path, Benchmark.Benchmark benchmark);

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

        // TODO - dynamic loading of providers.

        private static SqlServer.SqlServerProvider sqlServerProvider = new SqlServer.SqlServerProvider();
        private static Oracle.OracleProvider oracleProvider = new Oracle.OracleProvider();

        public static IEnumerable<DbProvider> Providers
        {
            get
            {
                yield return sqlServerProvider;
                yield return oracleProvider;
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
