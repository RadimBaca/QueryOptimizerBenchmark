using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.BenchmarkObjectControls
{
    public partial class QueryVariantDetail : BenchmarkObjectDetail
    {
        private bool ready = true;

        public QueryVariantDetail()
        {
            InitializeComponent();
        }

        private Benchmark.QueryVariant QueryVariant
        {
            get => (Benchmark.QueryVariant)BenchmarkObject;
        }

        protected override void BindControls()
        {
            if (QueryVariant == null)
            {
                return;
            }

            ready = false;

            dbProviderComboBox.LoadProviders();

            DbProviders.DbProvider dbProvider = QueryVariant.Owner.ConnectionSettings.DbProvider;
            if (dbProvider != null && QueryVariant.HasSpecificStatement(dbProvider.Name))
            {
                dbProviderComboBox.SelectedDbProvider = dbProvider;
            }
            else
            {
                dbProviderComboBox.SelectedDbProvider = null;
            }

            txtNumber.Text = QueryVariant.Number;
            txtName.Text = QueryVariant.Name;
            txtDescription.Text = QueryVariant.Description;

            BindStatement();

            QueryVariant.PropertyChanged -= QueryVariant_PropertyChanged;
            QueryVariant.PropertyChanged += QueryVariant_PropertyChanged;

            QueryVariant.DefaultStatement.PropertyChanged -= Statement_PropertyChanged;
            QueryVariant.DefaultStatement.PropertyChanged += Statement_PropertyChanged;

            CheckUniqueNumber();

            ready = true;
        }

        private void BindStatement()
        {
            DbProviders.DbProvider dbProvider = dbProviderComboBox.SelectedDbProvider;
            if (dbProvider == null)
            {
                fctbStatement.Text = QueryVariant.DefaultStatement.CommandText;
                fctbStatement.Enabled = true;
                btnChangeImplementation.Enabled = false;
            }
            else
            {
                if (QueryVariant.HasSpecificStatement(dbProvider.Name))
                {
                    fctbStatement.Text = QueryVariant.GetStatement(dbProvider.Name).CommandText;
                    fctbStatement.Enabled = true;

                    btnChangeImplementation.Text = "Remove";
                    btnChangeImplementation.Enabled = true;
                }
                else
                {
                    fctbStatement.Text = string.Empty;
                    fctbStatement.Enabled = false;

                    btnChangeImplementation.Text = "Implement";
                    btnChangeImplementation.Enabled = true;
                }
            }
        }

        private void CreateImplementation(DbProviders.DbProvider dbProvider)
        {
            Benchmark.SpecificStatement specificStatement = new Benchmark.SpecificStatement(QueryVariant);
            specificStatement.ProviderName = dbProvider.Name;
            QueryVariant.SpecificStatements.Add(specificStatement);
            BindStatement();
            dbProviderComboBox.Invalidate();
        }

        private void RemoveImplementation(DbProviders.DbProvider dbProvider)
        {
            Benchmark.Statement statement = QueryVariant.GetStatement(dbProvider.Name);
            if (statement is Benchmark.SpecificStatement specificStatement)
            {
                QueryVariant.SpecificStatements.Remove(specificStatement);
            }
            dbProviderComboBox.SelectedDbProvider = null;
        }

        private void CheckUniqueNumber()
        {
            bool notUnique = false;

            foreach (Benchmark.QueryVariant variant in QueryVariant.PlanEquivalenceTest.Variants)
            {
                if (variant != QueryVariant && variant.Number == QueryVariant.Number)
                {
                    notUnique = true;
                    break;
                }
            }

            warningProvider.Clear();
            if (notUnique)
            {
                warningProvider.SetError(txtNumber, "The query variant number is not unique within the test!");
            }
        }
        private void QueryVariant_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Number")
            {
                txtNumber.Text = QueryVariant.Number;
            }
            else if (e.PropertyName == "Name")
            {
                txtName.Text = QueryVariant.Name;   
            }
            else if (e.PropertyName == "Description")
            {
                txtDescription.Text = QueryVariant.Description;
            }
        }

        private void Statement_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CommandText")
            {
                fctbStatement.Text = QueryVariant.DefaultStatement.CommandText;
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            QueryVariant.Number = txtNumber.Text;
            CheckUniqueNumber();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            QueryVariant.Name = txtName.Text;   
        }

        protected override void UpdateUI()
        {
            if (QueryVariant == null)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;

                int index = QueryVariant.PlanEquivalenceTest.Variants.IndexOf(QueryVariant);
                lblPreviousVariant.Enabled = index > 0;
                lblNextVariant.Enabled = index < QueryVariant.PlanEquivalenceTest.Variants.Count - 1;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            QueryVariant.Description = txtDescription.Text;
        }

        private void fctbStatement_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (QueryVariant != null)
            {
                DbProviders.DbProvider dbProvider = dbProviderComboBox.SelectedDbProvider;

                if (dbProvider == null)
                {
                    QueryVariant.DefaultStatement.CommandText = fctbStatement.Text;
                }
                else if (QueryVariant.HasSpecificStatement(dbProvider.Name))
                {
                    QueryVariant.GetStatement(dbProvider.Name).CommandText = fctbStatement.Text;
                }
            }
        }

        private void lblPreviousVariant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int index = QueryVariant.PlanEquivalenceTest.Variants.IndexOf(QueryVariant);
            if (index > 0)
            {
                OnNavigateBenchmarkObject(QueryVariant.PlanEquivalenceTest.Variants[index - 1]);
            }
        }

        private void lblNextVariant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int index = QueryVariant.PlanEquivalenceTest.Variants.IndexOf(QueryVariant);
            if (index < QueryVariant.PlanEquivalenceTest.Variants.Count - 1)
            {
                OnNavigateBenchmarkObject(QueryVariant.PlanEquivalenceTest.Variants[index + 1]);
            }
        }

        private void lblTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(QueryVariant.PlanEquivalenceTest);
        }

        private void btnChangeImplementation_Click(object sender, EventArgs e)
        {
            DbProviders.DbProvider dbProvider = dbProviderComboBox.SelectedDbProvider;
            if (dbProvider != null)
            {
                if (QueryVariant.HasSpecificStatement(dbProvider.Name))
                {
                    RemoveImplementation(dbProvider);
                }
                else
                {
                    CreateImplementation(dbProvider);
                }
            }
        }

        private void dbProviderComboBox_ProviderImplemented(object sender, DbProviderComboBox.ProviderImplementedEventArgs e)
        {
            if (QueryVariant != null)
            {
                if (e.DbProvider != null)
                {
                    e.IsImplemented = QueryVariant.HasSpecificStatement(e.DbProvider.Name);
                }
                else
                {
                    // Default implementation.
                    e.IsImplemented = true;
                }
            }
        }

        private void dbProviderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                BindStatement();
            }
        }
    }
}
