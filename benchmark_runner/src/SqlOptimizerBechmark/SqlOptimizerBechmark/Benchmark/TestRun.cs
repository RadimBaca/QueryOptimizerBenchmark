﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class TestRun : BenchmarkObject, IIdentifiedBenchmarkObject, INamedBenchmarkObject
    {
        private Benchmark benchmark;
        private int id;
        private string name = string.Empty;
        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;

        private ObservableCollection<TestGroupResult> testGroupResults = new ObservableCollection<TestGroupResult>();
        private ObservableCollection<ConfigurationResult> configurationResults = new ObservableCollection<ConfigurationResult>();
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

        public ObservableCollection<TestGroupResult> TestGroupResults => testGroupResults;

        public ObservableCollection<ConfigurationResult> ConfigurationResults => configurationResults;

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

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("id", ref id);
            serializer.ReadString("name", ref name);
            serializer.ReadDateTime("start_date", ref startDate);
            serializer.ReadDateTime("end_date", ref endDate);

            serializer.ReadCollection<ConfigurationResult>("configuration_results", "configuration_result", configurationResults,
                delegate () { return new ConfigurationResult(this); });

            serializer.ReadCollection<TestGroupResult>("test_group_results", "test_group_result", testGroupResults,
                delegate () { return new TestGroupResult(this); });

            serializer.ReadCollection<TestResult>("test_results", "test_result", testResults, // TODO - various test types
                delegate () { return new PlanEquivalenceTestResult(this); });
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("name", name);
            serializer.WriteDateTime("start_date", startDate);
            serializer.WriteDateTime("end_date", endDate);
            serializer.WriteCollection<ConfigurationResult>("configuration_results", "configuration_result", configurationResults);
            serializer.WriteCollection<TestGroupResult>("test_group_results", "test_group_result", testGroupResults);
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
                writer.WriteLine("code;group;configuration;test;distinct plans;completed variants");
            }

            if ((exportOptions & CsvExportOptions.ExportQueryVariants) > 0)
            {
                writer.WriteLine("code;group;configuration;test;variant;result size;processing time;query plan");
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
    }
}
