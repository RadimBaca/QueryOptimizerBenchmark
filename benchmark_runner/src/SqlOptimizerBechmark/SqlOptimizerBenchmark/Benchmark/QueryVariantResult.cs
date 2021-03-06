﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class QueryVariantResult : BenchmarkObject
    {
        private PlanEquivalenceTestResult planEquivalenceTestResult;
        private string query = string.Empty;
        private int tokenCount = 0;
        private int queryVariantId = 0;
        private string queryVariantNumber = string.Empty;
        private string queryVariantName = string.Empty;
        private TimeSpan queryProcessingTime = TimeSpan.Zero;
        private int expectedResultSize = 0;
        private int resultSize = 0;
        private DbProviders.QueryPlan queryPlan = null;
        private bool started = false;
        private bool completed = false;
        private string errorMessage = string.Empty;
        private ObservableCollection<SelectedAnnotationResult> selectedAnnotationResults = new ObservableCollection<SelectedAnnotationResult>();

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

        public int TokenCount
        {
            get => tokenCount;
            set
            {
                if (tokenCount != value)
                {
                    tokenCount = value;
                    OnPropertyChanged("TokenCount");
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
        
        public string QueryPlanWoElapsedTime
        {
            get
            {
                if (queryPlan != null)
                {
                    return queryPlan.ToString(false);
                }
                else
                {
                    return null;
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

        public ObservableCollection<SelectedAnnotationResult> SelectedAnnotationResults => selectedAnnotationResults;

        public QueryVariantResult(PlanEquivalenceTestResult planEquivalenceTestResult)
        {
            this.planEquivalenceTestResult = planEquivalenceTestResult;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadString("query", ref query);
            serializer.ReadInt("token_count", ref tokenCount);
            serializer.ReadInt("query_variant_id", ref queryVariantId);
            serializer.ReadString("query_variant_number", ref queryVariantNumber);
            serializer.ReadString("query_variant_name", ref queryVariantName);
            serializer.ReadTimeSpan("query_processing_time", ref queryProcessingTime);
            serializer.ReadInt("expected_result_size", ref expectedResultSize);
            serializer.ReadInt("result_size", ref resultSize);
            serializer.ReadBool("started", ref completed);
            serializer.ReadBool("completed", ref completed);
            serializer.ReadString("error_message", ref errorMessage);

            serializer.ReadCollection<SelectedAnnotationResult>("selected_annotation_results", "selected_annotation_result", selectedAnnotationResults,
                delegate () { return new SelectedAnnotationResult(this); });


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
            serializer.WriteInt("token_count", tokenCount);
            serializer.WriteInt("query_variant_id", queryVariantId);
            serializer.WriteString("query_variant_number", queryVariantNumber);
            serializer.WriteString("query_variant_name", queryVariantName);
            serializer.WriteTimeSpan("query_processing_time", queryProcessingTime);
            serializer.WriteInt("expected_result_size", expectedResultSize);
            serializer.WriteInt("result_size", resultSize);
            serializer.WriteBool("started", completed);
            serializer.WriteBool("completed", completed);
            serializer.WriteString("error_message", errorMessage);

            serializer.WriteCollection<SelectedAnnotationResult>("selected_annotation_results", "selected_annotation_result",
                selectedAnnotationResults);

            if (queryPlan != null)
            {
                XElement eQueryPlan = new XElement("query_plan");
                queryPlan.SaveToXml(eQueryPlan);
                serializer.WriteXml(eQueryPlan);
            }
        }

        /// <summary>
        /// Returns an unique code of the query variant including variant number, test number, group number and template number.
        /// </summary>
        /// <returns></returns>
        public string GetCode()
        {
            TestGroupResult testGroupResult = planEquivalenceTestResult.TestRun.GetTestGroupResult(planEquivalenceTestResult.TestGroupId);
            ConfigurationResult configurationResult = planEquivalenceTestResult.TestRun.GetConfigurationResult(planEquivalenceTestResult.ConfigurationId);

            string testNumber = planEquivalenceTestResult.TestNumber;
            if (!string.IsNullOrEmpty(planEquivalenceTestResult.TemplateNumber))
            {
                testNumber += "/" + planEquivalenceTestResult.TemplateNumber;
            }

            string code = string.Format("{0}-{1}-{2}-{3}",
                testGroupResult.TestGroupNumber, configurationResult.ConfigurationNumber,
                testNumber, queryVariantNumber);

            return code;
        }

        public void ExportToCsv(StreamWriter writer, CsvExportOptions exportOptions)
        {
            if ((exportOptions & CsvExportOptions.ExportQueryVariants) > 0)
            {
                TestGroupResult testGroupResult = planEquivalenceTestResult.TestRun.GetTestGroupResult(planEquivalenceTestResult.TestGroupId);
                ConfigurationResult configurationResult = planEquivalenceTestResult.TestRun.GetConfigurationResult(planEquivalenceTestResult.ConfigurationId);

                string testAnnotationsStr = string.Empty;
                foreach (int annotationId in planEquivalenceTestResult.SelectedAnnotationResults.Select(ar => ar.AnnotationId))
                {
                    AnnotationResult annotationResult = planEquivalenceTestResult.TestRun.GetAnnotationResult(annotationId);
                    string annotationStr = annotationResult.AnnotationNumber;
                    if (!string.IsNullOrEmpty(testAnnotationsStr))
                    {
                        testAnnotationsStr += ",";
                    }
                    testAnnotationsStr += annotationStr;
                }

                string variantAnnotationsStr = string.Empty;
                foreach (int annotationId in this.SelectedAnnotationResults.Select(ar => ar.AnnotationId))
                {
                    AnnotationResult annotationResult = planEquivalenceTestResult.TestRun.GetAnnotationResult(annotationId);
                    string annotationStr = annotationResult.AnnotationNumber;
                    if (!string.IsNullOrEmpty(variantAnnotationsStr))
                    {
                        variantAnnotationsStr += ",";
                    }
                    variantAnnotationsStr += annotationStr;
                }

                string code = GetCode();

                writer.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12}",
                    TestRun.GetCsvStr(code),
                    TestRun.GetCsvStr(testGroupResult.TestGroupName),
                    TestRun.GetCsvStr(configurationResult.ConfigurationName),
                    TestRun.GetCsvStr(planEquivalenceTestResult.TestName),
                    TestRun.GetCsvStr(testAnnotationsStr),
                    TestRun.GetCsvStr(this.QueryVariantName),
                    TestRun.GetCsvStr(variantAnnotationsStr),
                    TestRun.GetCsvStr(Convert.ToString(this.resultSize)),
                    TestRun.GetCsvStr(Convert.ToString(this.queryProcessingTime)),
                    TestRun.GetCsvStr(Convert.ToString(this.queryPlan)),
                    queryPlan != null && queryPlan.Root != null ? Convert.ToString(queryPlan.Root.EstimatedCost) : string.Empty,
                    queryPlan != null && queryPlan.Root != null ? Convert.ToString(queryPlan.Root.EstimatedRows) : string.Empty,
                    queryPlan != null && queryPlan.Root != null ? Convert.ToString(queryPlan.Root.ActualRows) : string.Empty
                    );
            }
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "QueryVariantResult";

            ret.DbColumns.Add(new DbColumnInfo("query_variant_result_id", true, true)); // PK
            ret.DbColumns.Add(new DbColumnInfo(null, "test_result_id", System.Data.DbType.Int32, true, "TestResult", "test_result_id")); // FK

            ret.DbColumns.Add(new DbColumnInfo("Query", "query", System.Data.DbType.String, 1000));
            ret.DbColumns.Add(new DbColumnInfo("TokenCount", "token_count", System.Data.DbType.Int32));
            ret.DbColumns.Add(new DbColumnInfo("QueryVariantNumber", "query_variant_number", System.Data.DbType.String, 20));
            ret.DbColumns.Add(new DbColumnInfo("QueryVariantName", "query_variant_name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("QueryProcessingTime", "query_processing_time", System.Data.DbType.Double));
            ret.DbColumns.Add(new DbColumnInfo("ExpectedResultSize", "expected_result_size", System.Data.DbType.Int32));
            ret.DbColumns.Add(new DbColumnInfo("ResultSize", "result_size", System.Data.DbType.Int32));
            ret.DbColumns.Add(new DbColumnInfo("Started", "started", System.Data.DbType.Boolean));
            ret.DbColumns.Add(new DbColumnInfo("Completed", "completed", System.Data.DbType.Boolean));
            ret.DbColumns.Add(new DbColumnInfo("ErrorMessage", "error_message", System.Data.DbType.String, 1000));
            ret.DbColumns.Add(new DbColumnInfo("QueryVariantId", "query_variant_id", System.Data.DbType.Int32, true, "QueryVariant", "query_variant_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo("QueryPlanWoElapsedTime", "query_plan", System.Data.DbType.String, 1000));

            ret.DbDependentTables.Add(new DbDependentTableInfo("SelectedAnnotationResults", "SelectedAnnotationResult", "query_variant_result_id"));

            return ret;
        }
    }
}
