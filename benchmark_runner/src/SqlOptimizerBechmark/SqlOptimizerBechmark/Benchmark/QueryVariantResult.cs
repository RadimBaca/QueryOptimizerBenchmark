﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.Benchmark
{
    public class QueryVariantResult : BenchmarkObject
    {
        private PlanEquivalenceTestResult planEquivalenceTestResult;
        private string query = string.Empty;
        private int queryVariantId = 0;
        private string queryVariantNumber = string.Empty;
        private string queryVariantName = string.Empty;
        private TimeSpan queryProcessingTime = TimeSpan.Zero;
        private int resultSize = 0;
        private DbProviders.QueryPlan queryPlan = null;
        private bool started = false;
        private bool completed = false;
        private string errorMessage = string.Empty;
        public override IBenchmarkObject ParentObject => planEquivalenceTestResult;

        public string Query
        {
            get => query;
            set
            {
                if (query != value)
                {
                    query = value;
                    OnPropertyChanged("Query");
                }
            }
        }

        public int QueryVariantId
        {
            get => queryVariantId;
            set
            {
                if (queryVariantId != value)
                {
                    queryVariantId = value;
                    OnPropertyChanged("QueryVariantId");
                }
            }
        }

        public string QueryVariantNumber
        {
            get => queryVariantNumber;
            set
            {
                if (queryVariantNumber != value)
                {
                    queryVariantNumber = value;
                    OnPropertyChanged("QueryVariantNumber");
                }
            }
        }

        public string QueryVariantName
        {
            get => queryVariantName;
            set
            {
                if (queryVariantName != value)
                {
                    queryVariantName = value;
                    OnPropertyChanged("QueryVariantName");
                }
            }
        }

        public TimeSpan QueryProcessingTime
        {
            get => queryProcessingTime;
            set
            {
                if (queryProcessingTime != value)
                {
                    queryProcessingTime = value;
                    OnPropertyChanged("QueryProcessingTime");
                }
            }
        }

        public int ResultSize
        {
            get => resultSize;
            set
            {
                if (resultSize != value)
                {
                    resultSize = value;
                    OnPropertyChanged("ResultSize");
                }
            }
        }

        public DbProviders.QueryPlan QueryPlan
        {
            get => queryPlan;
            set
            {
                if (queryPlan != value)
                {
                    queryPlan = value;
                    OnPropertyChanged("QueryPlan");
                }
            }
        }
        
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

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        public QueryVariantResult(PlanEquivalenceTestResult planEquivalenceTestResult)
        {
            this.planEquivalenceTestResult = planEquivalenceTestResult;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadString("query", ref query);
            serializer.ReadInt("query_variant_id", ref queryVariantId);
            serializer.ReadString("query_variant_number", ref queryVariantNumber);
            serializer.ReadString("query_variant_name", ref queryVariantName);
            serializer.ReadTimeSpan("query_processing_time", ref queryProcessingTime);
            serializer.ReadInt("result_size", ref resultSize);
            serializer.ReadBool("started", ref completed);
            serializer.ReadBool("completed", ref completed);
            serializer.ReadString("error_message", ref errorMessage);

            XElement eQueryPlan = serializer.ReadXml("query_plan");
            if (eQueryPlan != null)
            {
                queryPlan = new DbProviders.QueryPlan();
                queryPlan.LoadFromXml(eQueryPlan);
            }
            else
            {
                queryPlan = null;
            }
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteString("query", query);
            serializer.WriteInt("query_variant_id", queryVariantId);
            serializer.WriteString("query_variant_number", queryVariantNumber);
            serializer.WriteString("query_variant_name", queryVariantName);
            serializer.WriteTimeSpan("query_processing_time", queryProcessingTime);
            serializer.WriteInt("result_size", resultSize);
            serializer.WriteBool("started", completed);
            serializer.WriteBool("completed", completed);
            serializer.WriteString("error_message", errorMessage);

            if (queryPlan != null)
            {
                XElement eQueryPlan = new XElement("query_plan");
                queryPlan.SaveToXml(eQueryPlan);
                serializer.WriteXml(eQueryPlan);
            }
        }

        public void ExportToCsv(StreamWriter writer, CsvExportOptions exportOptions)
        {
            if ((exportOptions & CsvExportOptions.ExportQueryVariants) > 0)
            {
                TestGroupResult testGroupResult = planEquivalenceTestResult.TestRun.GetTestGroupResult(planEquivalenceTestResult.TestGroupId);
                ConfigurationResult configurationResult = planEquivalenceTestResult.TestRun.GetConfigurationResult(planEquivalenceTestResult.ConfigurationId);

                string code = string.Format("{0}-{1}-{2}-{3}",
                    testGroupResult.TestGroupNumber, configurationResult.ConfigurationNumber,
                    planEquivalenceTestResult.TestNumber, queryVariantNumber);

                writer.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
                    TestRun.GetCsvStr(code),
                    TestRun.GetCsvStr(testGroupResult.TestGroupName),
                    TestRun.GetCsvStr(configurationResult.ConfigurationName),
                    TestRun.GetCsvStr(planEquivalenceTestResult.TestName),
                    TestRun.GetCsvStr(this.QueryVariantName),
                    TestRun.GetCsvStr(Convert.ToString(this.resultSize)),
                    TestRun.GetCsvStr(Convert.ToString(this.queryProcessingTime)),
                    TestRun.GetCsvStr(Convert.ToString(this.queryPlan)),
                    queryPlan != null && queryPlan.Root != null ? Convert.ToString(queryPlan.Root.EstimatedCost) : string.Empty,
                    queryPlan != null && queryPlan.Root != null ? Convert.ToString(queryPlan.Root.EstimatedRows) : string.Empty,
                    queryPlan != null && queryPlan.Root != null ? Convert.ToString(queryPlan.Root.ActualRows) : string.Empty
                    );
            }
        }
    }
}
