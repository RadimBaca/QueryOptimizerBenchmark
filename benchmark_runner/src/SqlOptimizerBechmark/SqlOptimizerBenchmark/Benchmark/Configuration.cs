using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class Configuration : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject, INamedBenchmarkObject, IDescribedBenchmarkObject
    {
        private TestGroup testGroup;
        private int id = 0;
        private string number = string.Empty;
        private string name = string.Empty;
        private string description = string.Empty;
        private Script initScript;
        private Script cleanUpScript;

        public override IBenchmarkObject ParentObject => testGroup;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                yield return initScript;
                yield return cleanUpScript;
            }
        }

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

        public Script InitScript
        {
            get => initScript;
        }

        public Script CleanUpScript
        {
            get => cleanUpScript;
        }

        public Configuration(TestGroup testGroup)
        {
            this.id = testGroup.Owner.GenerateId();
            this.testGroup = testGroup;
            initScript = new Script(this);
            cleanUpScript = new Script(this);
        }
        
        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("number", number);
            serializer.WriteString("name", name);
            serializer.WriteString("description", description);
            serializer.WriteObject("init_script", initScript);
            serializer.WriteObject("clean_up_script", cleanUpScript);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            if (!serializer.ReadInt("id", ref id))
            {
                id = testGroup.Benchmark.GenerateId();
            }
            serializer.ReadString("name", ref name);
            serializer.ReadString("number", ref number);
            serializer.ReadString("description", ref description);
            serializer.ReadObject("init_script", initScript);
            serializer.ReadObject("clean_up_script", cleanUpScript);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "Configuration";

            ret.DbColumns.Add(new DbColumnInfo("Id", "configuration_id", System.Data.DbType.Int32, true));
            ret.DbColumns.Add(new DbColumnInfo("Number", "number", System.Data.DbType.String, 20));
            ret.DbColumns.Add(new DbColumnInfo("Name", "name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("Description", "description", System.Data.DbType.String, 1000));

            return ret;
        }
    }
}
