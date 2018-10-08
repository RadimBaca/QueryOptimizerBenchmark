using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class ConfigurationResult : BenchmarkObject
    {
        private TestRun testRun;
        private int configurationId;
        private string configurationName;

        public override IBenchmarkObject ParentObject => testRun;

        public int ConfigurationId
        {
            get => configurationId;
            set
            {
                if (configurationId != value)
                {
                    configurationId = value;
                    OnPropertyChanged("ConfigurationId");
                }
            }
        }

        public string ConfigurationName
        {
            get => configurationName;
            set
            {
                if (configurationName != value)
                {
                    configurationName = value;
                    OnPropertyChanged("ConfigurationName");
                }
            }
        }

        public ConfigurationResult(TestRun testRun)
        {
            this.testRun = testRun;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("configuration_id", ref configurationId);
            serializer.ReadString("configuration_name", ref configurationName);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("configuration_id", configurationId);
            serializer.WriteString("configuration_name", configurationName);
        }
    }
}
