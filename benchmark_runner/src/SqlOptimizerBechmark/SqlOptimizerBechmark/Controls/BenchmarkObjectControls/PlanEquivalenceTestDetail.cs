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
    public partial class PlanEquivalenceTestDetail : BenchmarkObjectDetail
    {
        public PlanEquivalenceTestDetail()
        {
            InitializeComponent();
        }

        private Benchmark.PlanEquivalenceTest PlanEquivalenceTest
        {
            get => (Benchmark.PlanEquivalenceTest)BenchmarkObject;
        }

        protected override void BindControls()
        {
            if (PlanEquivalenceTest == null)
            {
                return;
            }

            txtNumber.Text = PlanEquivalenceTest.Number;
            txtName.Text = PlanEquivalenceTest.Name;
            txtDescription.Text = PlanEquivalenceTest.Description;
            txtExpectedResultSize.Text = Convert.ToString(PlanEquivalenceTest.ExpectedResultSize);
            cbxActive.Checked = PlanEquivalenceTest.Active;

            PlanEquivalenceTest.PropertyChanged -= PlanEquivalenceTest_PropertyChanged;
            PlanEquivalenceTest.PropertyChanged += PlanEquivalenceTest_PropertyChanged;

            queryVariantsListView.PlanEquivalenceTest = PlanEquivalenceTest;
            queryVariantsListView.Collection = PlanEquivalenceTest.Variants;

            CheckUniqueNumber();
        }

        private void CheckUniqueNumber()
        {
            bool notUnique = false;

            foreach (Benchmark.Test test in PlanEquivalenceTest.TestGroup.Tests)
            {
                if (test != PlanEquivalenceTest && test.Number == PlanEquivalenceTest.Number)
                {
                    notUnique = true;
                    break;
                }
            }

            warningProvider.Clear();
            if (notUnique)
            {
                warningProvider.SetError(txtNumber, "The test number is not unique within the test group!");
            }
        }
        private void PlanEquivalenceTest_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Number")
            {
                txtNumber.Text = PlanEquivalenceTest.Number;
            }
            else if (e.PropertyName == "Name")
            {
                txtName.Text = PlanEquivalenceTest.Name;
            }
            else if (e.PropertyName == "Description")
            {
                txtDescription.Text = PlanEquivalenceTest.Description;
            }
            else if (e.PropertyName == "ExpectedResultSize")
            {
                txtExpectedResultSize.Text = Convert.ToString(PlanEquivalenceTest.ExpectedResultSize);
            }
            else if (e.PropertyName == "Active")
            {
                cbxActive.Checked = PlanEquivalenceTest.Active;
            }            
        }
        
        protected override void UpdateUI()
        {
            if (PlanEquivalenceTest == null)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }
        }

        private void SetResultSizeByFirstVariant()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DbProviders.DbProvider provider = PlanEquivalenceTest.Owner.ConnectionSettings.DbProvider;

                if (provider == null)
                {
                    MessageBox.Show("Database connection is not set.",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (PlanEquivalenceTest.Variants.Count == 0)
                {
                    MessageBox.Show("At leas one query variant has to be defined.",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Benchmark.QueryVariant variant = PlanEquivalenceTest.Variants[0];

                provider.Connect();
                DbProviders.QueryStatistics stats = provider.GetQueryStatistics(variant.Statement.CommandText);
                provider.Close();

                PlanEquivalenceTest.ExpectedResultSize = stats.ResultSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            PlanEquivalenceTest.Number = txtNumber.Text;
            CheckUniqueNumber();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            PlanEquivalenceTest.Name = txtName.Text;    
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            PlanEquivalenceTest.Description = txtDescription.Text;
        }

        private void cbxActive_CheckedChanged(object sender, EventArgs e)
        {
            PlanEquivalenceTest.Active = cbxActive.Checked;
        }

        private void queryVariantsListView_BenchmarkObjectDoubleClick(object sender, BenchmarkObjectEventArgs e)
        {
            OnNavigateBenchmarkObject(e.BenchmarkObject);
        }

        private void lblBenchmark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(PlanEquivalenceTest.TestGroup);
        }

        private void txtExpectedResultSize_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (int.TryParse(txtExpectedResultSize.Text, out i))
            {
                PlanEquivalenceTest.ExpectedResultSize = i;
            }
            txtExpectedResultSize.Text = Convert.ToString(PlanEquivalenceTest.ExpectedResultSize);
        }

        private void btnSetByFirstVariant_Click(object sender, EventArgs e)
        {
            SetResultSizeByFirstVariant();
        }
    }
}
