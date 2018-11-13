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
    public partial class TestGroupDetail : BenchmarkObjectDetail
    {
        public TestGroupDetail()
        {
            InitializeComponent();
        }

        private Benchmark.TestGroup TestGroup
        {
            get => (Benchmark.TestGroup)BenchmarkObject;
        }

        protected override void BindControls()
        {
            if (TestGroup == null)
            {
                return;
            }

            txtNumber.Text = TestGroup.Number;
            txtName.Text = TestGroup.Name;
            txtDescription.Text = TestGroup.Description;
            
            TestGroup.PropertyChanged -= TestGroup_PropertyChanged;
            TestGroup.PropertyChanged += TestGroup_PropertyChanged;

            testsListView.TestGroup = TestGroup;
            testsListView.Collection = TestGroup.Tests;

            configurationsListView.TestGroup = TestGroup;
            configurationsListView.Collection = TestGroup.Configurations;

            CheckUniqueNumber();
        }

        private void CheckUniqueNumber()
        {
            bool notUnique = false;

            foreach (Benchmark.TestGroup testGroup in TestGroup.Owner.TestGroups)
            {
                if (testGroup != TestGroup && testGroup.Number == TestGroup.Number)
                {
                    notUnique = true;
                    break;
                }
            }

            warningProvider.Clear();
            if (notUnique)
            {
                warningProvider.SetError(txtNumber, "The group number is not unique!");
            }
        }

        private void TestGroup_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Number")
            {
                txtNumber.Text = TestGroup.Number;
            }
            else if (e.PropertyName == "Name")
            {
                txtName.Text = TestGroup.Name;
            }
            else if (e.PropertyName == "Description")
            {
                txtDescription.Text = TestGroup.Description;
            }
        }

        protected override void UpdateUI()
        {
            if (TestGroup == null)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            TestGroup.Number = txtNumber.Text;
            CheckUniqueNumber();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            TestGroup.Name = txtName.Text;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            TestGroup.Description = txtDescription.Text;
        }

        private void configurationsListView_BenchmarkObjectDoubleClick(object sender, BenchmarkObjectEventArgs e)
        {
            OnNavigateBenchmarkObject(e.BenchmarkObject);
        }

        private void testsListView_BenchmarkObjectDoubleClick(object sender, BenchmarkObjectEventArgs e)
        {
            OnNavigateBenchmarkObject(e.BenchmarkObject);
        }

        private void lblBenchmark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(TestGroup.Benchmark);
        }
    }
}
