using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class PlanEquivalenceTestResult : TestResult
    {
        private int distinctQueryPlans = 0;
        private int successfullyCompletedVariants = 0;
        private ObservableCollection<QueryVariantResult> queryVariantResults = new ObservableCollection<QueryVariantResult>();
        private ObservableCollection<SelectedAnnotationResult> selectedAnnotationResults = new ObservableCollection<SelectedAnnotationResult>();
        private bool started = false;
        private bool completed = false;
        private string templateNumber = string.Empty;
        
        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                foreach (QueryVariantResult queryVariantResult in queryVariantResults)
                {
                    yield return queryVariantResult;
                }
            }
        }

        public int DistinctQueryPlans
        {
            get => distinctQueryPlans;
            set
            {
                if (distinctQueryPlans != value)
                {
                    distinctQueryPlans = value;
                    OnPropertyChanged("DistinctQueryPlans");
                }
            }
        }

        public int SuccessfullyCompletedVariants
        {
            get => successfullyCompletedVariants;
            set
            {
                if (successfullyCompletedVariants != value)
                {
                    successfullyCompletedVariants = value;
                    OnPropertyChanged("SuccessfullyCompletedVariants");
                }
            }
        }

        public string TemplateNumber
        {
            get => templateNumber;
            set
            {
                if (templateNumber != value)
                {
                    templateNumber = value;
                    OnPropertyChanged("TemplateNumber");
                }
            }
        }

        public bool Success
        {
            get
            {
                return completed && distinctQueryPlans == 1 && successfullyCompletedVariants > 1 && string.IsNullOrEmpty(ErrorMessage);
            }
        }

        public ObservableCollection<QueryVariantResult> QueryVariantResults => queryVariantResults;

        public ObservableCollection<SelectedAnnotationResult> SelectedAnnotationResults => selectedAnnotationResults;

        public bool Started
        {
            get => started;
            set
            {
                if (started != value)
                {
                    started = value;
                    OnPropertyChanged("Started");
                }
            }
        }

        public bool Completed
        {
            get => completed;
            set
            {
                if (completed != value)
                {
                    completed = value;
                    OnPropertyChanged("Completed");
                }
            }
        }

        public PlanEquivalenceTestResult(TestRun testRun)
            : base(testRun)
        {

        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            base.LoadFromXml(serializer);
            serializer.ReadInt("distinct_query_plans", ref distinctQueryPlans);
            serializer.ReadInt("successfully_completed_variants", ref successfullyCompletedVariants);
            serializer.ReadCollection<QueryVariantResult>("query_variant_results", "query_variant_result", queryVariantResults,
                delegate () { return new QueryVariantResult(this); });
            serializer.ReadCollection<SelectedAnnotationResult>("selected_annotation_results", "selected_annotation_result", selectedAnnotationResults,
                delegate () { return new SelectedAnnotationResult(this); });
            serializer.ReadBool("started", ref started);
            serializer.ReadBool("completed", ref completed);
            serializer.ReadString("template_number", ref templateNumber);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            base.SaveToXml(serializer);
            serializer.WriteInt("distinct_query_plans", distinctQueryPlans);
            serializer.WriteInt("successfully_completed_variants", successfullyCompletedVariants);
            serializer.WriteCollection<QueryVariantResult>("query_variant_results", "query_variant_result", queryVariantResults);
            serializer.WriteCollection<SelectedAnnotationResult>("selected_annotation_results", "selected_annotation_result", selectedAnnotationResults);
            serializer.WriteBool("started", started);
            serializer.WriteBool("completed", completed);
            serializer.WriteString("template_number", templateNumber);
        }

        public override void ExportToCsv(StreamWriter writer, CsvExportOptions exportOptions)
        {
            if (!completed)
            {
                return;
            }

            if ((exportOptions & CsvExportOptions.ExportDistinctPlans) > 0)
            {
                TestGroupResult testGroupResult = TestRun.GetTestGroupResult(TestGroupId);
                ConfigurationResult configurationResult = TestRun.GetConfigurationResult(ConfigurationId);

                string annotationsStr = string.Empty;
                foreach (int annotationId in selectedAnnotationResults.Select(ar => ar.AnnotationId))
                {
                    AnnotationResult annotationResult = TestRun.GetAnnotationResult(annotationId);
                    string annotationStr = annotationResult.AnnotationNumber;
                    if (!string.IsNullOrEmpty(annotationsStr))
                    {
                        annotationsStr += ",";
                    }
                    annotationsStr += annotationStr;
                }

                string code = string.Format("{0}-{1}-{2}", testGroupResult.TestGroupNumber,
                    configurationResult.ConfigurationNumber, this.TestNumber);
                if (!string.IsNullOrEmpty(templateNumber))
                {
                    code += "/" + templateNumber;
                }

                writer.WriteLine("{0};{1};{2};{3};{4};{5};{6}",
                    TestRun.GetCsvStr(code),
                    TestRun.GetCsvStr(testGroupResult.TestGroupName),
                    TestRun.GetCsvStr(configurationResult.ConfigurationName),
                    TestRun.GetCsvStr(this.TestName),
                    TestRun.GetCsvStr(annotationsStr),
                    TestRun.GetCsvStr(Convert.ToString(this.distinctQueryPlans)),
                    TestRun.GetCsvStr(Convert.ToString(this.successfullyCompletedVariants)));
            }

            if ((exportOptions & CsvExportOptions.ExportQueryVariants) > 0)
            {
                foreach (QueryVariantResult variantResult in queryVariantResults)
                {
                    variantResult.ExportToCsv(writer, exportOptions);
                }
            }
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            // TODO - nebude fungovat pro vice typu testu.

            ret.DbColumns.Add(new DbColumnInfo("DistinctQueryPlans", "distinct_query_plans", System.Data.DbType.Int32));
            ret.DbColumns.Add(new DbColumnInfo("SuccessfullyCompletedVariants", "successfully_completed_variants", System.Data.DbType.Int32));
            ret.DbColumns.Add(new DbColumnInfo("Started", "started", System.Data.DbType.Boolean));
            ret.DbColumns.Add(new DbColumnInfo("Completed", "completed", System.Data.DbType.Boolean));
            ret.DbColumns.Add(new DbColumnInfo("TemplateNumber", "template_number", System.Data.DbType.String, 20));

            ret.DbDependentTables.Add(new DbDependentTableInfo("QueryVariantResults", "QueryVariantResult", "test_result_id"));
            ret.DbDependentTables.Add(new DbDependentTableInfo("SelectedAnnotationResults", "SelectedAnnotationResult", "test_result_id"));

            return ret;
        }
    }
}
