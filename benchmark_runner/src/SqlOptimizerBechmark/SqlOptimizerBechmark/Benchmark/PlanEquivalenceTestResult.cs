﻿using System;
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
        private ObservableCollection<QueryVariantResult> queryVariantResults = new ObservableCollection<QueryVariantResult>();
        private bool started = false;
        private bool completed = false;
        
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

        public ObservableCollection<QueryVariantResult> QueryVariantResults => queryVariantResults;

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
            serializer.ReadCollection<QueryVariantResult>("query_variant_results", "query_variant_result", queryVariantResults,
                delegate () { return new QueryVariantResult(this); });
            serializer.ReadBool("started", ref started);
            serializer.ReadBool("completed", ref completed);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            base.SaveToXml(serializer);
            serializer.WriteInt("distinct_query_plans", distinctQueryPlans);
            serializer.WriteCollection<QueryVariantResult>("query_variant_results", "query_variant_result", queryVariantResults);
            serializer.WriteBool("started", started);
            serializer.WriteBool("completed", completed);
        }

        public override void ExportToCsv(StreamWriter writer, CsvExportOptions exportOptions)
        {
            if (!completed)
            {
                return;
            }

            if ((exportOptions & CsvExportOptions.ExportQueryVariants) > 0)
            {
                TestGroupResult testGroupResult = TestRun.GetTestGroupResult(TestGroupId);
                ConfigurationResult configurationResult = TestRun.GetConfigurationResult(ConfigurationId);

                writer.Write("{0};{1};{2};{3}",
                    TestRun.GetCsvStr(testGroupResult.TestGroupName),
                    TestRun.GetCsvStr(configurationResult.ConfigurationName),
                    TestRun.GetCsvStr(this.TestName),
                    TestRun.GetCsvStr(Convert.ToString(this.distinctQueryPlans)));
            }

            if ((exportOptions & CsvExportOptions.ExportDistinctPlans) > 0)
            {
                foreach (QueryVariantResult variantResult in queryVariantResults)
                {
                    variantResult.ExportToCsv(writer, exportOptions);
                }
            }
        }
    }
}