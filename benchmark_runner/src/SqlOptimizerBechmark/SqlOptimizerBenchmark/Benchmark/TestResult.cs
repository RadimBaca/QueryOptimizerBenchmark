using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class TestResult : BenchmarkObject
    {
        private TestRun testRun;

        private int testId;
        private string testNumber = string.Empty;
        private string testName = string.Empty;
        private int testGroupId;
        private int configurationId;
        private string errorMessage = string.Empty;
        
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

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
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
            serializer.ReadString("error_message", ref errorMessage);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("test_id", testId);
            serializer.WriteString("test_number", testNumber);
            serializer.WriteString("test_name", testName);
            serializer.WriteInt("test_group_id", testGroupId);
            serializer.WriteInt("configuration_id", configurationId);
            serializer.WriteString("error_message", errorMessage);
        }

        public virtual void ExportToCsv(StreamWriter writer, CsvExportOptions exportOptions)
        {
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "TestResult";

            ret.DbColumns.Add(new DbColumnInfo("test_result_id", true, true)); // PK
            ret.DbColumns.Add(new DbColumnInfo(null, "test_run_id", System.Data.DbType.Int32, true, "TestRun", "test_run_id")); // FK

            ret.DbColumns.Add(new DbColumnInfo("TestId", "test_id", System.Data.DbType.Int32, true, "Test", "test_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo("TestNumber", "test_number", System.Data.DbType.String, 20));
            ret.DbColumns.Add(new DbColumnInfo("TestName", "test_name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("ErrorMessage", "error_message", System.Data.DbType.String, 1000));
            ret.DbColumns.Add(new DbColumnInfo("TestGroupId", "test_group_id", System.Data.DbType.Int32, true, "TestGroup", "test_group_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo("ConfigurationId", "configuration_id", System.Data.DbType.Int32, true, "Configuration", "configuration_id")); // FK

            return ret;
        }
    }
}