using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class TestGroupResult : BenchmarkObject
    {
        private TestRun testRun;
        private int testGroupId;
        private string testGroupName;

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
            serializer.ReadString("test_group_name", ref testGroupName);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("test_group_id", testGroupId);
            serializer.WriteString("test_group_name", testGroupName);
        }
    }
}
