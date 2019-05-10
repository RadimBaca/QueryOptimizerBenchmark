using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.Benchmark
{
    public class ConnectionSettings: BenchmarkObject
    {
        private Benchmark benchmark;
        private DbProviders.DbProvider dbProvider;

        public DbProviders.DbProvider DbProvider
        {
            get => dbProvider;
            set => dbProvider = value;
        }

        public override IBenchmarkObject ParentObject => benchmark;

        public ConnectionSettings(Benchmark benchmark)
        {
            this.benchmark = benchmark;
        }


        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            string providerName = null;
            serializer.ReadString("provider", ref providerName);

            if (providerName != null)
            {
                XElement element = serializer.ReadXml("settings");
                if (element != null)
                {
                    dbProvider = DbProviders.DbProvider.GetProvider(providerName);
                    dbProvider.LoadFromXml(element);
                }
            }
            else
            {
                string currentProvider = null;
                serializer.ReadString("current_provider", ref currentProvider);

                if (currentProvider != null)
                {
                    XElement eProviders = serializer.ReadXml("providers");
                    foreach (XElement eProvider in eProviders.Elements("provider"))
                    {
                        providerName = eProvider.Attribute("name").Value;
                        DbProviders.DbProvider dbProvider1 = DbProviders.DbProvider.GetProvider(providerName);
                        dbProvider1.LoadFromXml(eProvider);

                        if (currentProvider == providerName)
                        {
                            dbProvider = dbProvider1;
                        }
                    }
                }
            }
        }
        

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            if (dbProvider != null)
            {
                serializer.WriteString("current_provider", dbProvider.Name);

                XElement eProviders = new XElement("providers");

                // Since ver. 1.30, settings of all providers are stored in the XML.
                foreach (DbProviders.DbProvider provider in DbProviders.DbProvider.Providers)
                {
                    XElement eProvider = new XElement("provider");
                    XAttribute aProviderName = new XAttribute("name", provider.Name);
                    eProvider.Add(aProviderName);
                    provider.SaveToXml(eProvider);
                    eProviders.Add(eProvider);
                }

                serializer.WriteXml(eProviders);
            }
        }
    }
}
