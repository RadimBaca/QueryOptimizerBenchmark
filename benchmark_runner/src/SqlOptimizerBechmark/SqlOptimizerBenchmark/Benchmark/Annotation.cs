using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class Annotation : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject, INamedBenchmarkObject, IDescribedBenchmarkObject
    {
        private Benchmark benchmark;
        private int id = 0;
        private string number = string.Empty;
        private string name = string.Empty;
        private string description = string.Empty;

        public override IBenchmarkObject ParentObject => benchmark;

        public Benchmark Benchmark => benchmark;

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

        public Annotation(Benchmark benchmark)
        {
            this.id = benchmark.GenerateId();
            this.benchmark = benchmark;
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("number", number);
            serializer.WriteString("name", name);
            serializer.WriteString("description", description);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            if (!serializer.ReadInt("id", ref id))
            {
                id = benchmark.GenerateId();
            }
            serializer.ReadString("number", ref number);
            serializer.ReadString("name", ref name);
            serializer.ReadString("description", ref description);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "Annotation";

            ret.DbColumns.Add(new DbColumnInfo("Id", "annotation_id", System.Data.DbType.Int32, true)); // PK
            ret.DbColumns.Add(new DbColumnInfo(null, "benchmark_id", System.Data.DbType.Int32, true, "Benchmark", "benchmark_id")); // FK

            ret.DbColumns.Add(new DbColumnInfo("Number", "number", System.Data.DbType.String, 20));
            ret.DbColumns.Add(new DbColumnInfo("Name", "name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("Description", "description", System.Data.DbType.String, 1000));

            return ret;
        }
    }
}
