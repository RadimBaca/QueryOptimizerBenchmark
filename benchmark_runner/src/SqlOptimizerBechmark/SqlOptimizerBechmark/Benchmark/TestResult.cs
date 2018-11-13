using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class TestResult : BenchmarkObject
    {
        private TestRun testRun;

        private int testId;
        private string testNumber = string.Empty;
        private string testName = string.Empty;
        private int testGroupId;
        private int configurationId;
        
        public override IBenchmarkObject ParentObject => testRun;

        public TestRun TestRun => testRun;

        public int TestId
        {
            get => testId;
            set
            {
                if (testId != value)
                {
                    testId = value;
                    OnPropertyChanged("TestId");
                }
            }
        }
        
        public string TestNumber
        {
            get => testNumber;
            set
            {
                if (testNumber != value)
                {
                    testNumber = value;
                    OnPropertyChanged("TestNumber");
                }
            }
        }

        public string TestName
        {
            get => testName;
            set
            {
                if (testName != value)
                {
                    testName = value;
                    OnPropertyChanged("TestName");
                }
            }
        }

        public int TestGroupId
        {
            get => testGroupId;
            set
            {
                if (testGroupId != value)
                {
                    testGroupId = value;
                    OnPropertyChanged("TestGroupId");
                }
            }
        }

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

        public TestResult(TestRun testRun)
        {
            this.testRun = testRun;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("test_id", ref testId);
            serializer.ReadString("test_number", ref testNumber);
            serializer.ReadString("test_name", ref testName);
            serializer.ReadInt("test_group_id", ref testGroupId);
            serializer.ReadInt("configuration_id", ref configurationId);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("test_id", testId);
            serializer.WriteString("test_number", testNumber);
            serializer.WriteString("test_name", testName);
            serializer.WriteInt("test_group_id", testGroupId);
            serializer.WriteInt("configuration_id", configurationId);
        }

        public virtual void ExportToCsv(StreamWriter writer, CsvExportOptions exportOptions)
        {
        }
    }
}