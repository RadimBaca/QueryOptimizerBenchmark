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
            XElement element = serializer.ReadXml("settings");
            if (element != null)
            {
                string providerName = null;
                serializer.ReadString("provider", ref providerName);

                if (providerName != null)
                {
                    dbProvider = DbProviders.DbProvider.GetProvider(providerName);
                    dbProvider.LoadFromXml(element);
                }
            }
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            if (dbProvider != null)
            {
                serializer.WriteString("provider", dbProvider.Name);

                XElement element = new XElement("settings");
                dbProvider.SaveToXml(element);
                serializer.WriteXml(element);
            }
        }
    }
}
