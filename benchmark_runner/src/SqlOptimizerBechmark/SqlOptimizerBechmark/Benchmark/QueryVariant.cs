using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class QueryVariant : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject, INamedBenchmarkObject, IDescribedBenchmarkObject
    {
        private PlanEquivalenceTest planEquivalenceTest;
        private int id = 0;
        private string number = string.Empty;
        private string name = string.Empty;
        private string description = string.Empty;
        private Statement statement;

        public override IBenchmarkObject ParentObject => planEquivalenceTest;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                yield return statement;
            }
        }

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

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public Statement Statement
        {
            get => statement;
        }

        public QueryVariant(PlanEquivalenceTest planEquivalenceTest)
        {
            this.id = planEquivalenceTest.Owner.GenerateId();
            this.planEquivalenceTest = planEquivalenceTest;
            statement = new Statement(this);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("number", number);
            serializer.WriteString("name", name);
            serializer.WriteString("description", description);
            serializer.WriteObject("statement", statement);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            if (!serializer.ReadInt("id", ref id))
            {
                id = planEquivalenceTest.TestGroup.Benchmark.GenerateId();
            }
            serializer.ReadString("number", ref number);
            serializer.ReadString("name", ref name);
            serializer.ReadString("description", ref description);
            serializer.ReadObject("statement", statement);
        }
    }
}
