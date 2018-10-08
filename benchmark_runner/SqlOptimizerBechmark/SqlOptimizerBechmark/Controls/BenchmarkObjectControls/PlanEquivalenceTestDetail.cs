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

            txtName.Text = PlanEquivalenceTest.Name;
            txtDescription.Text = PlanEquivalenceTest.Description;
            cbxActive.Checked = PlanEquivalenceTest.Active;

            PlanEquivalenceTest.PropertyChanged -= PlanEquivalenceTest_PropertyChanged;
            PlanEquivalenceTest.PropertyChanged += PlanEquivalenceTest_PropertyChanged;

            queryVariantsListView.PlanEquivalenceTest = PlanEquivalenceTest;
            queryVariantsListView.Collection = PlanEquivalenceTest.Variants;
        }

        private void PlanEquivalenceTest_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
            {
                txtName.Text = PlanEquivalenceTest.Name;
            }
            else if (e.PropertyName == "Description")
            {
                txtDescription.Text = PlanEquivalenceTest.Description;
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
    }
}
