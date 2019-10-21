using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlOptimizerBenchmark.DbProviders;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class TestRun : BenchmarkObject, IIdentifiedBenchmarkObject, INamedBenchmarkObject
    {
        private Benchmark benchmark;
        private int id;
        private string name = string.Empty;
        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private string settingsInfo = string.Empty;
        private string executorInfo = string.Empty;

        private ObservableCollection<TestGroupResult> testGroupResults = new ObservableCollection<TestGroupResult>();
        private ObservableCollection<ConfigurationResult> configurationResults = new ObservableCollection<ConfigurationResult>();
        private ObservableCollection<AnnotationResult> annotationResults = new ObservableCollection<AnnotationResult>();
        private ObservableCollection<TestResult> testResults = new ObservableCollection<TestResult>();

        public override IBenchmarkObject ParentObject => benchmark;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                foreach (TestGroupResult testGroupResult in testGroupResults)
                {
                    yield return testGroupResult;
                }

                foreach (ConfigurationResult configurationResult in configurationResults)
                {
                    yield return configurationResult;
                }

                foreach (AnnotationResult annotationResult in annotationResults)
                {
                    yield return annotationResult;
                }

                foreach (TestResult testResult in testResults)
                {
                    yield return testResult;
                }
            }
        }

        public int Id => id;

        public Benchmark Benchmark => benchmark;

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

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }

        public string SettingsInfo
        {
            get => settingsInfo;
            set
            {
                if (settingsInfo != value)
                {
                    settingsInfo = value;
                    OnPropertyChanged("SettingsInfo");
                }
            }
        }

        public string ExecutorInfo
        {
            get => executorInfo;
            set
            {
                if (executorInfo != value)
                {
                    executorInfo = value;
                    OnPropertyChanged("ExecutorInfo");
                }
            }
        }

        public ObservableCollection<TestGroupResult> TestGroupResults => testGroupResults;

        public ObservableCollection<ConfigurationResult> ConfigurationResults => configurationResults;

        public ObservableCollection<AnnotationResult> AnnotationResults => annotationResults;

        public ObservableCollection<TestResult> TestResults => testResults;


        public TestRun(Benchmark benchmark)
        {
            this.id = benchmark.GenerateId();
            this.benchmark = benchmark;
        }

        public TestGroupResult GetTestGroupResult(int testGroupId)
        {
            return testGroupResults.Where(t => t.TestGroupId == testGroupId).FirstOrDefault();
        }

        public ConfigurationResult GetConfigurationResult(int configurationId)
        {
            return configurationResults.Where(c => c.ConfigurationId == configurationId).FirstOrDefault();
        }

        public AnnotationResult GetAnnotationResult(int annotationId)
        {
            return annotationResults.Where(a => a.AnnotationId == annotationId).FirstOrDefault();
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("id", ref id);
            serializer.ReadString("name", ref name);
            serializer.ReadDateTime("start_date", ref startDate);
            serializer.ReadDateTime("end_date", ref endDate);
            serializer.ReadString("settings_info", ref settingsInfo);
            serializer.ReadString("executor_info", ref executorInfo);

            serializer.ReadCollection<ConfigurationResult>("configuration_results", "configuration_result", configurationResults,
                delegate () { return new ConfigurationResult(this); });

            serializer.ReadCollection<TestGroupResult>("test_group_results", "test_group_result", testGroupResults,
                delegate () { return new TestGroupResult(this); });

            serializer.ReadCollection<AnnotationResult>("annotation_results", "annotation_result", annotationResults,
                delegate () { return new AnnotationResult(this); });

            serializer.ReadCollection<TestResult>("test_results", "test_result", testResults, // TODO - various test types
                delegate () { return new PlanEquivalenceTestResult(this); });
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("name", name);
            serializer.WriteDateTime("start_date", startDate);
            serializer.WriteDateTime("end_date", endDate);
            serializer.WriteString("settings_info", settingsInfo);
            serializer.WriteString("executor_info", executorInfo);
            serializer.WriteCollection<ConfigurationResult>("configuration_results", "configuration_result", configurationResults);
            serializer.WriteCollection<TestGroupResult>("test_group_results", "test_group_result", testGroupResults);
            serializer.WriteCollection<AnnotationResult>("annotation_results", "annotation_result", annotationResults);
            serializer.WriteCollection<TestResult>("test_results", "test_result", testResults);
        }

        public static string GetCsvStr(string str)
        {
            return string.Format("\"{0}\"", str.Replace("\"", "\"\""));
        }

        public void ExportToCsv(StreamWriter writer, CsvExportOptions exportOptions)
        {
            if ((exportOptions & CsvExportOptions.ExportDistinctPlans) > 0)
            {
                writer.WriteLine("code;group;configuration;test;test annotations;distinct plans;completed variants");
            }

            if ((exportOptions & CsvExportOptions.ExportQueryVariants) > 0)
            {
                writer.WriteLine("code;group;configuration;test;test annotations;variant;variant annotations;result size;processing time;query plan;root cost;root estimated rows;root actual rows");
            }

            foreach (TestResult testResult in testResults)
            {
                testResult.ExportToCsv(writer, exportOptions);
            }
        }

        public void ExportToCsv(string fileName, CsvExportOptions exportOptions)
        {
            StreamWriter writer = new StreamWriter(fileName);
            ExportToCsv(writer, exportOptions);
            writer.Close();
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "TestRun";

            ret.DbColumns.Add(new DbColumnInfo("Id", "test_run_id", System.Data.DbType.Int32, true)); // PK
            ret.DbColumns.Add(new DbColumnInfo(null, "benchmark_id", System.Data.DbType.Int32, true, "Benchmark", "benchmark_id")); // FK

            ret.DbColumns.Add(new DbColumnInfo("Name", "name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("StartDate", "start_date", System.Data.DbType.DateTime));
            ret.DbColumns.Add(new DbColumnInfo("EndDate", "end_date", System.Data.DbType.DateTime));
            ret.DbColumns.Add(new DbColumnInfo("SettingsInfo", "settings_info", System.Data.DbType.String, 300));
            ret.DbColumns.Add(new DbColumnInfo("ExecutorInfo", "executor_info", System.Data.DbType.String, 300));

            ret.DbDependentTables.Add(new DbDependentTableInfo("ConfigurationResults", "ConfigurationResult", "test_run_id"));
            ret.DbDependentTables.Add(new DbDependentTableInfo("TestGroupResults", "TestGroupResult", "test_run_id"));
            ret.DbDependentTables.Add(new DbDependentTableInfo("AnnotationResults", "AnnotationResult", "test_run_id"));
            ret.DbDependentTables.Add(new DbDependentTableInfo("TestResults", "TestResult", "test_run_id"));

            return ret;
        }
    }
}
