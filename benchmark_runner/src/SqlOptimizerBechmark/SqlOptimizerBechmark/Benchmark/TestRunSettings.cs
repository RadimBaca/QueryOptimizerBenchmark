using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class TestRunSettings : BenchmarkObject
    {
        private Benchmark benchmark;

        public override IBenchmarkObject ParentObject => benchmark;

        private bool runInitScript = true;
        private bool runCleanUpScript = true;
        private bool checkResultSizes = true;
        private bool compareResults = true;
        private ObservableCollection<SelectedAnnotation> ignoreAnnotations = new ObservableCollection<SelectedAnnotation>();

        public bool RunInitScript
        {
            get => runInitScript;
            set
            {
                if (runInitScript != value)
                {
                    runInitScript = value;
                    OnPropertyChanged("RunInitScript");
                }
            }
        }

        public bool RunCleanUpScript
        {
            get => runCleanUpScript;
            set
            {
                if (runCleanUpScript != value)
                {
                    runCleanUpScript = value;
                    OnPropertyChanged("RunCleanUpScript");
                }
            }
        }

        public bool CheckResultSizes
        {
            get => checkResultSizes;
            set
            {
                if (checkResultSizes != value)
                {
                    checkResultSizes = value;
                    OnPropertyChanged("CheckResultSizes");
                }
            }
        }

        public bool CompareResults
        {
            get => compareResults;
            set
            {
                if (compareResults != value)
                {
                    compareResults = value;
                    OnPropertyChanged("CompareResults");
                }
            }
        }

        public ObservableCollection<SelectedAnnotation> IgnoreAnnotations
        {
            get => ignoreAnnotations;
        }

        public TestRunSettings(Benchmark benchmark)
        {
            this.benchmark = benchmark;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadBool("run_init_script", ref runInitScript);
            serializer.ReadBool("run_clean_up_script", ref runCleanUpScript);
            serializer.ReadBool("check_result_sizes", ref checkResultSizes);
            serializer.ReadBool("compare_results", ref compareResults);
            serializer.ReadCollection<SelectedAnnotation>("ignore_annotations", "ignore_annotation", ignoreAnnotations,
                delegate() { return new SelectedAnnotation(this); });
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteBool("run_init_script", runInitScript);
            serializer.WriteBool("run_clean_up_script", runCleanUpScript);
            serializer.WriteBool("check_result_sizes", checkResultSizes);
            serializer.WriteBool("compare_results", compareResults);
            serializer.WriteCollection<SelectedAnnotation>("ignore_annotations", "ignore_annotation", ignoreAnnotations);
        }
    }
}
