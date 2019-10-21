using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class TestGroupResult : BenchmarkObject
    {
        private TestRun testRun;
        private int testGroupId = 0;
        private string testGroupNumber = string.Empty;
        private string testGroupName = string.Empty;

        public override IBenchmarkObject ParentObject => testRun;

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

        public string TestGroupNumber
        {
            get => testGroupNumber;
            set
            {
                if (testGroupNumber != value)
                {
                    testGroupNumber = value;
                    OnPropertyChanged("TestGroupNumber");
                }
            }
        }

        public string TestGroupName
        {
            get => testGroupName;
            set
            {
                if (testGroupName != value)
                {
                    testGroupName = value;
                    OnPropertyChanged("TestGroupName");
                }
            }
        }

        public TestGroupResult(TestRun testRun)
        {
            this.testRun = testRun;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("test_group_id", ref testGroupId);
            serializer.ReadString("test_group_number", ref testGroupNumber);
            serializer.ReadString("test_group_name", ref testGroupName);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("test_group_id", testGroupId);
            serializer.WriteString("test_group_number", testGroupNumber);
            serializer.WriteString("test_group_name", testGroupName);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "TestGroupResult";

            ret.DbColumns.Add(new DbColumnInfo(null, "test_run_id", System.Data.DbType.Int32, true, true, "TestRun", "test_run_id")); // PK, FK
            ret.DbColumns.Add(new DbColumnInfo("TestGroupId", "test_group_id", System.Data.DbType.Int32, true, true, "TestGroup", "test_group_id")); // PK, FK

            ret.DbColumns.Add(new DbColumnInfo("TestGroupNumber", "test_group_number", System.Data.DbType.String, 20));
            ret.DbColumns.Add(new DbColumnInfo("TestGroupName", "test_group_name", System.Data.DbType.String, 50));

            return ret;
        }
    }
}
