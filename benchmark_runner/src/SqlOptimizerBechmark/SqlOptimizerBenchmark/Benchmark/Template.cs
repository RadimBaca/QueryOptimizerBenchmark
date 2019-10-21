using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class Template : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject
    {
        private PlanEquivalenceTest planEquivalenceTest;
        private ObservableCollection<SelectedAnnotation> selectedAnnotations = new ObservableCollection<SelectedAnnotation>();

        private int id = 0;
        private string number = string.Empty;
        private int expectedResultSize = 0;

        public override IBenchmarkObject ParentObject => planEquivalenceTest;

        public PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
        }

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                foreach (SelectedAnnotation selectedAnnotation in selectedAnnotations)
                {
                    yield return selectedAnnotation;
                }
            }
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

        public ObservableCollection<SelectedAnnotation> SelectedAnnotations
        {
            get => selectedAnnotations;
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
            serializer.ReadCollection<SelectedAnnotation>("selected_annotations", "selected_annotation", selectedAnnotations,
                delegate () { return new SelectedAnnotation(this); });
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("number", number);
            serializer.WriteInt("expected_result_size", expectedResultSize);
            serializer.WriteCollection<SelectedAnnotation>("selected_annotations", "selected_annotation", selectedAnnotations);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "Template";

            ret.DbColumns.Add(new DbColumnInfo("Id", "template_id", System.Data.DbType.Int32, true));
            ret.DbColumns.Add(new DbColumnInfo("Number", "number", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("ExpectedResultSize", "expected_result_size", System.Data.DbType.Int32));

            return ret;
        }
    }
}
