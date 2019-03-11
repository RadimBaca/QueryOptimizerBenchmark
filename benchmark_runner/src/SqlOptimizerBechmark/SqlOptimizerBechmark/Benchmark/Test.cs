using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public abstract class Test : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject, INamedBenchmarkObject, IDescribedBenchmarkObject
    {
        private TestGroup testGroup;
        private int id = 0;
        private string number = string.Empty;
        private string name = string.Empty;
        private string description = string.Empty;
        private bool active = true;

        public override IBenchmarkObject ParentObject => testGroup;

        public TestGroup TestGroup
        {
            get => testGroup;
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

        public bool Active
        {
            get => active;
            set
            {
                if (active != value)
                {
                    active = value;
                    OnPropertyChanged("Active");
                }
            }
        }

        public abstract TestType TestType
        {
            get;
        }

        public Test(TestGroup testGroup)
        {
            this.id = testGroup.Owner.GenerateId();
            this.testGroup = testGroup;
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("number", number);
            serializer.WriteString("name", name);
            serializer.WriteString("description", description);
            serializer.WriteBool("active", active);            
        }
        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            if (!serializer.ReadInt("id", ref id))
            {
                id = testGroup.Benchmark.GenerateId();
            }
            serializer.ReadString("number", ref number);
            serializer.ReadString("name", ref name);
            serializer.ReadString("description", ref description);
            serializer.ReadBool("Active", ref active);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "Test";

            ret.DbColumns.Add(new DbColumnInfo("Id", "test_id", System.Data.DbType.Int32, true));
            ret.DbColumns.Add(new DbColumnInfo("Number", "number", System.Data.DbType.String, 20));
            ret.DbColumns.Add(new DbColumnInfo("Name", "name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("Description", "description", System.Data.DbType.String, 1000));
            ret.DbColumns.Add(new DbColumnInfo("Active", "active", System.Data.DbType.Boolean));

            return ret;
        }
    }
}
