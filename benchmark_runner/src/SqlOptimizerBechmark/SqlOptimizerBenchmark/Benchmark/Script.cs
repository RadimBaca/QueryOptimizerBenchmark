using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class Script : BenchmarkObject
    {
        private IBenchmarkObject parentObject;

        private StatementList defaultStatementList;
        private ObservableCollection<SpecificStatementList> specificStatementLists;
        
        public override IBenchmarkObject ParentObject => parentObject;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                yield return defaultStatementList;
                foreach (SpecificStatementList specificStatementList in specificStatementLists)
                {
                    yield return specificStatementList;
                }
            }
        }

        public StatementList DefaultStatementList
        {
            get => defaultStatementList;
        }

        public ObservableCollection<SpecificStatementList> SpecificStatementLists
        {
            get => specificStatementLists;
        }

        public Script(IBenchmarkObject parentObject)
        {
            this.parentObject = parentObject;
            this.defaultStatementList = new StatementList(this);
            this.specificStatementLists = new ObservableCollection<SpecificStatementList>();
        }

        public StatementList GetStatementList(string providerName)
        {
            foreach (SpecificStatementList specificStatementList in specificStatementLists)
            {
                if (specificStatementList.ProviderName == providerName)
                {
                    return specificStatementList;
                }
            }

            return defaultStatementList;
        }

        public bool HasSpecificStatementList(string providerName)
        {
            foreach (SpecificStatementList specificStatementList in specificStatementLists)
            {
                if (specificStatementList.ProviderName == providerName)
                {
                    return true;
                }
            }
            return false;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            // Zpetna kompatibilita.
            if (!serializer.ReadObject("default_statement_list", defaultStatementList))
            {
                defaultStatementList.LoadFromXml(serializer);
            }
            serializer.ReadCollection<SpecificStatementList>("specific_statement_lists", "specific_statement_list", specificStatementLists,
                delegate () { return new SpecificStatementList(this); });
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteObject("default_statement_list", defaultStatementList);
            serializer.WriteCollection<SpecificStatementList>("specific_statement_lists", "specific_statement_list", specificStatementLists);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "Script";

            return ret;
        }
    }
}
