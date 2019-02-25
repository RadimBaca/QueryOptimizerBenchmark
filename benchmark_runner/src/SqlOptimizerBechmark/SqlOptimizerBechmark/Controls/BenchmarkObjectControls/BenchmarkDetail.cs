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

            txtName.DataBindings.Clear();
            txtAuthor.DataBindings.Clear();
            txtDescription.DataBindings.Clear();

            txtName.DataBindings.Add("Text", Benchmark, "Name");
            txtAuthor.DataBindings.Add("Text", Benchmark, "Author");
            txtDescription.DataBindings.Add("Text", Benchmark, "Description");

            //txtName.Text = Benchmark.Name;
            //txtAuthor.Text = Benchmark.Author;
            //txtDescription.Text = Benchmark.Description;

            //Benchmark.PropertyChanged -= Benchmark_PropertyChanged;
            //Benchmark.PropertyChanged += Benchmark_PropertyChanged;

            testGroupsListView.Benchmark = Benchmark;
            testGroupsListView.Collection = Benchmark.TestGroups;

            BindingList<Benchmark.Annotation> bindingList = new BindingList<Benchmark.Annotation>(Benchmark.Annotations);
            bindingList.AddingNew += bindingList_AddingNew;
            gridAnnotations.AutoGenerateColumns = false;
            gridAnnotations.DataSource = bindingList;
        }

        private void bindingList_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Benchmark.Annotation(Benchmark);
        }

        //private void Benchmark_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "Name")
        //    {
        //        txtName.Text = Benchmark.Name;
        //    }
        //    else if (e.PropertyName == "Description")
        //    {
        //        txtDescription.Text = Benchmark.Description;
        //    }
        //    else if (e.PropertyName == "Author")
        //    {
        //        txtAuthor.Text = Benchmark.Author;
        //    }
        //}

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

        //private void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    Benchmark.Name = txtName.Text;
        //}

        //private void txtAuthor_TextChanged(object sender, EventArgs e)
        //{
        //    Benchmark.Author = txtAuthor.Text;
        //}

        //private void txtDescription_TextChanged(object sender, EventArgs e)
        //{
        //    Benchmark.Description = txtDescription.Text;
        //}

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

        private string GetFirstAnnotationUsage(Benchmark.Annotation annotation)
        {
            foreach (Benchmark.TestGroup testGroup in Benchmark.TestGroups)
            {
                foreach (Benchmark.Test test in testGroup.Tests)
                {
                    if (test is Benchmark.PlanEquivalenceTest planEquivalenceTest)
                    {
                        foreach (Benchmark.SelectedAnnotation selectedAnnotation in planEquivalenceTest.SelectedAnnotations)
                        {
                            if (selectedAnnotation.AnnotationId == annotation.Id)
                            {
                                return string.Format("the test {0}-{1}", planEquivalenceTest.TestGroup.Number, planEquivalenceTest.Number);
                            }
                        }
                    }
                }
            }

            return null;
        }

        private void gridAnnotations_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.DataBoundItem is Benchmark.Annotation annotation)
            {
                string str = GetFirstAnnotationUsage(annotation);
                if (!string.IsNullOrEmpty(str))
                {
                    MessageBox.Show(string.Format("This annotation is already used by {0}.", str),
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Cancel = true;
                }
            }
        }
    }
}
