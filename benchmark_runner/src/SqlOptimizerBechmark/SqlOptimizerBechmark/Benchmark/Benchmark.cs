using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SqlOptimizerBechmark.Benchmark
{
    public class Benchmark: BenchmarkObject, INamedBenchmarkObject, IDescribedBenchmarkObject
    {
        private string name = string.Empty;
        private string author = string.Empty;
        private string description = string.Empty;
        private Script initScript;
        private Script cleanUpScript;
        private ObservableCollection<TestGroup> testGroups = new ObservableCollection<TestGroup>();
        private ConnectionSettings connectionSettings;
        private ObservableCollection<TestRun> testRuns = new ObservableCollection<TestRun>();
        private ObservableCollection<Annotation> annotations = new ObservableCollection<Annotation>();
        private TestRunSettings testRunSettings;

        private int lastId = 0;

        public override Benchmark Owner => this;

        public override IBenchmarkObject ParentObject => null;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                yield return initScript;
                yield return cleanUpScript;
                foreach (TestGroup testGroup in testGroups)
                {
                    yield return testGroup;
                }
                yield return connectionSettings;
                foreach (TestRun testRun in testRuns)
                {
                    yield return testRun;
                }
                foreach (Annotation annotation in annotations)
                {
                    yield return annotation;
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

        public string Author
        {
            get => author;
            set
            {
                if (author != value)
                {
                    author = value;
                    OnPropertyChanged("Author");
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

        public Script InitScript
        {
            get => initScript;
        }

        public Script CleanUpScript
        {
            get => cleanUpScript;
        }

        public ObservableCollection<TestGroup> TestGroups
        {
            get => testGroups;
        }

        public ConnectionSettings ConnectionSettings
        {
            get => connectionSettings;
        }

        public TestRunSettings TestRunSettings
        {
            get => testRunSettings;
        }

        public ObservableCollection<TestRun> TestRuns
        {
            get => testRuns;
        }

        public ObservableCollection<Annotation> Annotations
        {
            get => annotations;
        }

        public Benchmark()
        {
            initScript = new Script(this);
            cleanUpScript = new Script(this);
            connectionSettings = new ConnectionSettings(this);
            testRunSettings = new TestRunSettings(this);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteString("name", name);
            serializer.WriteString("author", author);
            serializer.WriteString("description", description);
            serializer.WriteObject("init_script", initScript);
            serializer.WriteObject("clean_up_script", cleanUpScript);
            serializer.WriteCollection<TestGroup>("test_groups", "test_group", testGroups);
            serializer.WriteObject("connection_settings", connectionSettings);
            serializer.WriteCollection<TestRun>("test_runs", "test_run", testRuns);
            serializer.WriteCollection<Annotation>("annotations", "annotation", annotations);
            serializer.WriteObject("test_run_settings", testRunSettings);
            serializer.WriteInt("last_id", lastId);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadString("name", ref name);
            serializer.ReadString("author", ref author);
            serializer.ReadString("description", ref description);
            serializer.ReadObject("init_script", initScript);
            serializer.ReadObject("clean_up_script", cleanUpScript);
            serializer.ReadCollection<TestGroup>("test_groups", "test_group", testGroups,
                delegate () { return new TestGroup(this); });
            serializer.ReadObject("connection_settings", connectionSettings);
            serializer.ReadCollection<TestRun>("test_runs", "test_run", testRuns,
                delegate () { return new TestRun(this); });
            serializer.ReadCollection<Annotation>("annotations", "annotation", annotations,
                delegate () { return new Annotation(this); });
            serializer.ReadObject("test_run_settings", testRunSettings);
            serializer.ReadInt("last_id", ref lastId);
        }

        public void Save(string fileName)
        {
            BenchmarkXmlSerializer serializer = new BenchmarkXmlSerializer();
            serializer.SaveBenchmark(this, fileName);
        }

        public void Load(string fileName)
        {
            BenchmarkXmlSerializer serializer = new BenchmarkXmlSerializer();
            serializer.LoadBenchmark(this, fileName);
        }

        public IIdentifiedBenchmarkObject FindObjectById(int id)
        {
            Stack<IBenchmarkObject> stack = new Stack<IBenchmarkObject>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                IBenchmarkObject obj = stack.Pop();
                if (obj is IIdentifiedBenchmarkObject identifiedBenchmarkObject &&
                    identifiedBenchmarkObject.Id == id)
                {
                    return identifiedBenchmarkObject;
                }
                foreach (IBenchmarkObject child in obj.ChildObjects)
                {
                    stack.Push(child);
                }
            }
            return null;
        }

        public int GenerateId()
        {
            return ++lastId;
        }
    }
}
