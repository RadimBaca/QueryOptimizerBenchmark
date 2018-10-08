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
    public partial class BenchmarkDetail : BenchmarkObjectDetail
    {
        public BenchmarkDetail()
        {
            InitializeComponent();
        }

        private Benchmark.Benchmark Benchmark
        {
            get => (Benchmark.Benchmark)BenchmarkObject;
        }

        protected override void BindControls()
        {
            if (Benchmark == null)
            {
                return;
            }

            txtName.Text = Benchmark.Name;
            txtAuthor.Text = Benchmark.Author;
            txtDescription.Text = Benchmark.Description;

            Benchmark.PropertyChanged -= Benchmark_PropertyChanged;
            Benchmark.PropertyChanged += Benchmark_PropertyChanged;

            testGroupsListView.Benchmark = Benchmark;
            testGroupsListView.Collection = Benchmark.TestGroups;
        }

        private void Benchmark_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
            {
                txtName.Text = Benchmark.Name;
            }
            else if (e.PropertyName == "Description")
            {
                txtDescription.Text = Benchmark.Description;
            }
            else if (e.PropertyName == "Author")
            {
                txtAuthor.Text = Benchmark.Author;
            }
        }

        protected override void UpdateUI()
        {
            if (Benchmark == null)
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
            Benchmark.Name = txtName.Text;
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            Benchmark.Author = txtAuthor.Text;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            Benchmark.Description = txtDescription.Text;
        }

        private void lblInitScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(Benchmark.InitScript);
        }

        private void lblCleanUpScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(Benchmark.CleanUpScript);
        }

        private void testGroupsListView_BenchmarkObjectDoubleClick(object sender, BenchmarkObjectEventArgs e)
        {
            OnNavigateBenchmarkObject(e.BenchmarkObject);
        }
    }
}
