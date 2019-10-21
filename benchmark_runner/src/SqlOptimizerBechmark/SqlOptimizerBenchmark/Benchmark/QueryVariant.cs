using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class QueryVariant : BenchmarkObject, IIdentifiedBenchmarkObject, INumberedBenchmarkObject, INamedBenchmarkObject, IDescribedBenchmarkObject
    {
        private PlanEquivalenceTest planEquivalenceTest;
        private int id = 0;
        private string number = string.Empty;
        private string name = string.Empty;
        private string description = string.Empty;

        private Statement defaultStatement;
        private ObservableCollection<SpecificStatement> specificStatements;
        private ObservableCollection<SelectedAnnotation> selectedAnnotations = new ObservableCollection<SelectedAnnotation>();

        public override IBenchmarkObject ParentObject => planEquivalenceTest;

        public override IEnumerable<IBenchmarkObject> ChildObjects
        {
            get
            {
                yield return defaultStatement;

                foreach (SpecificStatement specificStatement in specificStatements)
                {
                    yield return specificStatement;
                }
                foreach (SelectedAnnotation selectedAnnotation in selectedAnnotations)
                {
                    yield return selectedAnnotation;
                }
            }
        }

        public PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
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

        public Statement DefaultStatement
        {
            get => defaultStatement;
        }
        
        public ObservableCollection<SpecificStatement> SpecificStatements
        {
            get => specificStatements;
        }

        public ObservableCollection<SelectedAnnotation> SelectedAnnotations
        {
            get => selectedAnnotations;
        }

        public QueryVariant(PlanEquivalenceTest planEquivalenceTest)
        {
            this.id = planEquivalenceTest.Owner.GenerateId();
            this.planEquivalenceTest = planEquivalenceTest;
            defaultStatement = new Statement(this);
            specificStatements = new ObservableCollection<SpecificStatement>();
        }

        public Statement GetStatement(string providerName)
        {
            foreach (SpecificStatement specificStatement in specificStatements)
            {
                if (specificStatement.ProviderName == providerName)
                {
                    return specificStatement;
                }
            }

            return defaultStatement;
        }

        public bool HasSpecificStatement(string providerName)
        {
            foreach (SpecificStatement specificStatement in specificStatements)
            {
                if (specificStatement.ProviderName == providerName)
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
            serializer.WriteObject("default_statement", defaultStatement);
            serializer.WriteCollection<SpecificStatement>("specific_statements", "specific_statement", specificStatements);
            serializer.WriteCollection<SelectedAnnotation>("selected_annotations", "selected_annotation", selectedAnnotations);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            if (!serializer.ReadInt("id", ref id))
            {
                id = planEquivalenceTest.TestGroup.Benchmark.GenerateId();
            }
            serializer.ReadString("number", ref number);
            serializer.ReadString("name", ref name);
            serializer.ReadString("description", ref description);
            // Zpetna kompatibilita.
            if (!serializer.ReadObject("default_statement", defaultStatement))
            {
                serializer.ReadObject("statement", defaultStatement);
            }
            serializer.ReadCollection<SpecificStatement>("specific_statements", "specific_statement", specificStatements,
                delegate () { return new SpecificStatement(this); });
            serializer.ReadCollection<SelectedAnnotation>("selected_annotations", "selected_annotation", selectedAnnotations,
                delegate () { return new SelectedAnnotation(this); });
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = new DbTableInfo();

            ret.TableName = "QueryVariant";

            ret.DbColumns.Add(new DbColumnInfo("Id", "query_variant_id", System.Data.DbType.Int32, true));
            ret.DbColumns.Add(new DbColumnInfo("Number", "number", System.Data.DbType.String, 20));
            ret.DbColumns.Add(new DbColumnInfo("Name", "name", System.Data.DbType.String, 50));
            ret.DbColumns.Add(new DbColumnInfo("Description", "description", System.Data.DbType.String, 1000));

            return ret;
        }
    }
}
