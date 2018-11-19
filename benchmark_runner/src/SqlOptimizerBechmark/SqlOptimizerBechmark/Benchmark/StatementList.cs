using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class StatementList : BenchmarkObject
    {
        private Script script;

        private ObservableCollection<Statement> statements = new ObservableCollection<Statement>();

        public override IBenchmarkObject ParentObject => script;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                foreach (Statement statement in statements)
                {
                    yield return statement;
                }
            }
        }

        public ObservableCollection<Statement> Statements
        {
            get => statements;
        }

        public StatementList(Script script)
        {
            this.script = script;
            statements.CollectionChanged += Statements_CollectionChanged;
        }

        private void Statements_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyChange();
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteCollection<Statement>("statements", "statement", statements);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadCollection<Statement>("statements", "statement", statements,
                delegate () { return new Statement(this); });
        }
    }
}
