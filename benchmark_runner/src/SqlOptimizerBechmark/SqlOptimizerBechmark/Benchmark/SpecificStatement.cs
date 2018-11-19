using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class SpecificStatement : Statement
    {
        private string providerName = string.Empty;

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

        public SpecificStatement(BenchmarkObject parentObject) 
            : base(parentObject)
        {
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadString("provider_name", ref providerName);
            base.LoadFromXml(serializer);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteString("provider_name", providerName);
            base.SaveToXml(serializer);
        }
    }
}
