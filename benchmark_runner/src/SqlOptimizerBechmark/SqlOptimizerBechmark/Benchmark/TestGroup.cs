using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class TestGroup : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject, INamedBenchmarkObject, IDescribedBenchmarkObject
    {
        private Benchmark benchmark;
        private int id = 0;
        private string number = string.Empty;
        private string name = string.Empty;
        private string description = string.Empty;
        private ObservableCollection<Test> tests = new ObservableCollection<Test>();
        private ObservableCollection<Configuration> configurations = new ObservableCollection<Configuration>();

        public override IBenchmarkObject ParentObject => benchmark;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                foreach (Test test in tests)
                {
                    yield return test;
                }
                foreach (Configuration configuration in configurations)
                {
                    yield return configuration;
                }
            }
        }

        public Benchmark Benchmark
        {
            get => benchmark;
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

        public ObservableCollection<Test> Tests
        {
            get => tests;
        }

        public ObservableCollection<Configuration> Configurations
        {
            get => configurations;
        }

        public TestGroup(Benchmark benchmark)
        {
            this.id = benchmark.GenerateId();
            this.benchmark = benchmark;
            tests.CollectionChanged += Tests_CollectionChanged;
            configurations.CollectionChanged += Configurations_CollectionChanged;
        }

        private void Tests_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyChange();
        }

        private void Configurations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyChange();
        }

        public bool Contains(BenchmarkObject benchmarkObject)
        {
            if (benchmarkObject == this)
            {
                return true;
            }

            foreach (Configuration configuration in configurations)
            {
                if (configuration.Contains(benchmarkObject))
                {
                    return true;
                }
            }

            foreach (Test test in tests)
            {
                if (test.Contains(benchmarkObject))
                {
                    return true;
                }
            }

            return false;
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("id", id);
            serializer.WriteString("number", number);
            serializer.WriteString("name", name);
            serializer.WriteString("description", description);
            serializer.WriteCollection<Test>("tests", "test", tests);
            serializer.WriteCollection<Configuration>("configurations", "configuration", configurations);
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

            serializer.ReadCollection<Test>("tests", "test", tests,
                delegate () { return new PlanEquivalenceTest(this); }); // TODO - distinguish test types.

            serializer.ReadCollection<Configuration>("configurations", "configuration", configurations,
                delegate () { return new Configuration(this); });
        }
    }
}
