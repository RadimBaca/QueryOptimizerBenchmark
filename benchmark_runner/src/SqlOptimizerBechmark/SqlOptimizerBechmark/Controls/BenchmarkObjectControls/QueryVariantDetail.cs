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

            txtName.Text = QueryVariant.Name;
            txtDescription.Text = QueryVariant.Description;
            fctbStatement.Text = QueryVariant.Statement.CommandText;

            QueryVariant.PropertyChanged -= QueryVariant_PropertyChanged;
            QueryVariant.PropertyChanged += QueryVariant_PropertyChanged;

            QueryVariant.Statement.PropertyChanged -= Statement_PropertyChanged;
            QueryVariant.Statement.PropertyChanged += Statement_PropertyChanged;
        }

        private void QueryVariant_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
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
                fctbStatement.Text = QueryVariant.Statement.CommandText;
            }
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
                QueryVariant.Statement.CommandText = fctbStatement.Text;
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

    }
}
