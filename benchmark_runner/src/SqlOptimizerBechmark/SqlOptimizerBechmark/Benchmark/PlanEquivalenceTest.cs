using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class PlanEquivalenceTest: Test
    {
        private ObservableCollection<QueryVariant> variants = new ObservableCollection<QueryVariant>();
        private ObservableCollection<SelectedAnnotation> selectedAnnotations = new ObservableCollection<SelectedAnnotation>();
        private ObservableCollection<Parameter> parameters = new ObservableCollection<Parameter>();
        private ObservableCollection<Template> templates = new ObservableCollection<Template>();
        private ObservableCollection<ParameterValue> parameterValues = new ObservableCollection<ParameterValue>();

        private int expectedResultSize = 0;
        private bool parametrized;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                foreach (QueryVariant variant in variants)
                {
                    yield return variant;
                }
                foreach (SelectedAnnotation selectedAnnotation in selectedAnnotations)
                {
                    yield return selectedAnnotation;
                }
            }
        }

        public override TestType TestType => TestType.PlanEquivalence;

        public ObservableCollection<QueryVariant> Variants
        {
            get => variants;
        }

        public ObservableCollection<SelectedAnnotation> SelectedAnnotations
        {
            get => selectedAnnotations;
        }

        public ObservableCollection<Parameter> Parameters
        {
            get => parameters;
        }

        public ObservableCollection<Template> Templates
        {
            get => templates;
        }

        public ObservableCollection<ParameterValue> ParameterValues
        {
            get => parameterValues;
        }

        public int ExpectedResultSize
        {
            get => expectedResultSize;
            set
            {
                if (value != expectedResultSize)
                {
                    expectedResultSize = value;
                    OnPropertyChanged("ExpectedResultSize");
                }
            }
        }

        public bool Parametrized
        {
            get => parametrized;
            set
            {
                if (value != parametrized)
                {
                    parametrized = value;
                    OnPropertyChanged("Parametrized");
                }
            }
        }

        public PlanEquivalenceTest(TestGroup testGroup)
            : base(testGroup)
        {
            variants.CollectionChanged += Variants_CollectionChanged;
        }

        private void Variants_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyChange();
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            base.SaveToXml(serializer);
            serializer.WriteCollection<QueryVariant>("variants", "variant", variants);
            serializer.WriteCollection<SelectedAnnotation>("selected_annotations", "selected_annotation", selectedAnnotations);
            serializer.WriteInt("expected_result_size", expectedResultSize);
            serializer.WriteBool("parametrized", parametrized);
            if (parametrized)
            {
                serializer.WriteCollection<Parameter>("parameters", "parameter", parameters);
                serializer.WriteCollection<Template>("templates", "template", templates);
                serializer.WriteCollection<ParameterValue>("parameter_values", "parameter_value", parameterValues);
            }
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            base.LoadFromXml(serializer);
            serializer.ReadCollection<QueryVariant>("variants", "variant", variants,
                delegate () { return new QueryVariant(this); });
            serializer.ReadCollection<SelectedAnnotation>("selected_annotations", "selected_annotation", selectedAnnotations,
                delegate () { return new SelectedAnnotation(this); });
            serializer.ReadInt("expected_result_size", ref expectedResultSize);
            serializer.ReadBool("parametrized", ref parametrized);
            if (parametrized)
            {
                serializer.ReadCollection<Parameter>("parameters", "parameter", parameters,
                    delegate () { return new Parameter(this); });
                serializer.ReadCollection<Template>("templates", "template", templates,
                    delegate () { return new Template(this); });
                serializer.ReadCollection<ParameterValue>("parameter_values", "parameter_value", parameterValues,
                    delegate () { return new ParameterValue(this); });
            }
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.DbColumns.Add(new DbColumnInfo("ExpectedResultSize", "expected_result_size", System.Data.DbType.Int32));
            ret.DbColumns.Add(new DbColumnInfo("Parametrized", "parametrized", System.Data.DbType.Boolean));

            return ret;
        }
    }
}
