using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class SpecificStatement : Statement
    {
        private string providerName = string.Empty;
        private bool notSupported = false;

        public string ProviderName
        {
            get => providerName;
            set
            {
                if (value != providerName)
                {
                    providerName = value;
                    OnPropertyChanged("ProviderName");
                }
            }
        }

        public bool NotSupported
        {
            get => notSupported;
            set
            {
                if (value != notSupported)
                {
                    notSupported = value;
                    OnPropertyChanged("NotSupported");
                }
            }
        }

        public SpecificStatement(BenchmarkObject parentObject) 
            : base(parentObject)
        {
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadString("provider_name", ref providerName);
            serializer.ReadBool("not_supported", ref notSupported);
            base.LoadFromXml(serializer);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteString("provider_name", providerName);
            serializer.WriteBool("not_supported", notSupported);
            base.SaveToXml(serializer);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "SpecificStatement";

            ret.DbColumns.Add(new DbColumnInfo("ProviderName", "provider_name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("NotSupported", "not_supported", System.Data.DbType.Boolean));

            return ret;
        }
    }
}
