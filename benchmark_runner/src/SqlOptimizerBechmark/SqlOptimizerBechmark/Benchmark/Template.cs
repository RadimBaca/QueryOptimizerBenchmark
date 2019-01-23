using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class Template : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject
    {
        private PlanEquivalenceTest planEquivalenceTest;
        private int id = 0;
        private string number = string.Empty;
        private int expectedResultSize = 0;

        public override IBenchmarkObject ParentObject => planEquivalenceTest;

        public PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
        }

        public int Id
        {
            get => id;
        }

        public string Number
        {
            get => number;
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public int ExpectedResultSize
        {
            get => expectedResultSize;
            set
            {
                if (expectedResultSize != value)
                {
                    expectedResultSize = value;
                    OnPropertyChanged("ExpectedResultSize");
                }
            }
        }

        public Template(PlanEquivalenceTest planEquivalenceTest)
        {
            this.id = planEquivalenceTest.Owner.GenerateId();
            this.planEquivalenceTest = planEquivalenceTest;
        }


        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            if (!serializer.ReadInt("id", ref id))
            {
                id = planEquivalenceTest.Owner.GenerateId();
            }
            serializer.ReadString("number", ref number);
            serializer.ReadInt("expected_result_size", ref expectedResultSize);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("number", number);
            serializer.WriteInt("expected_result_size", expectedResultSize);
        }
    }
}
