using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class Parameter : BenchmarkObject, IIdentifiedBenchmarkObject, INamedBenchmarkObject
    {
        private PlanEquivalenceTest planEquivalenceTest;
        private int id = 0;
        private string name = string.Empty;

        public override IBenchmarkObject ParentObject => planEquivalenceTest;

        public PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
        }
        public int Id
        {
            get => id;
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

        public Parameter(PlanEquivalenceTest planEquivalenceTest)
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
            serializer.ReadString("name", ref name);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("name", name);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "Parameter";
            ret.DbColumns.Add(new DbColumnInfo("Id", "parameter_id", System.Data.DbType.Int32, true));
            ret.DbColumns.Add(new DbColumnInfo("Name", "name", System.Data.DbType.String, 50));

            return ret;
        }
    }
}
