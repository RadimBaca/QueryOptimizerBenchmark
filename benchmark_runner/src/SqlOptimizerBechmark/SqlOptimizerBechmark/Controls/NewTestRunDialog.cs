using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls
{
    public partial class NewTestRunDialog : Form
    {
        private Benchmark.TestRunSettings testRunSettings;
        private ObservableCollection<Benchmark.SelectedAnnotation> ignoreAnnotationsCopy =
            new ObservableCollection<Benchmark.SelectedAnnotation>();

        public string TestRunName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        public Benchmark.TestRunSettings TestRunSettings
        {
            get => testRunSettings;
            set => testRunSettings = value;
        }

        public NewTestRunDialog()
        {
            InitializeComponent();
        }

        private void UpdateControls()
        {
            cbxRunInitScript.Checked = testRunSettings.RunInitScript;
            cbxRunCleanUpScript.Checked = testRunSettings.RunCleanUpScript;
            cbxCheckResultSizes.Checked = testRunSettings.CheckResultSizes;
            cbxCompareResults.Checked = testRunSettings.CompareResults;
            numQueryRuns.Value = testRunSettings.QueryRuns;

            ignoreAnnotationsCopy.Clear();
            foreach (Benchmark.SelectedAnnotation selectedAnnotation in testRunSettings.IgnoreAnnotations)
            {
                ignoreAnnotationsCopy.Add(selectedAnnotation);
            }
            ignoreAnnotationsClb.ParentBenchmarkObject = testRunSettings;
            ignoreAnnotationsClb.SelectedAnnotations = ignoreAnnotationsCopy;
            ignoreAnnotationsClb.BindAnnotations();
        }

        private void UpdateSettings()
        {
            testRunSettings.RunInitScript = cbxRunInitScript.Checked;
            testRunSettings.RunCleanUpScript = cbxRunCleanUpScript.Checked;
            testRunSettings.CheckResultSizes = cbxCheckResultSizes.Checked;
            testRunSettings.CompareResults = cbxCompareResults.Checked;
            testRunSettings.QueryRuns = Convert.ToInt32(numQueryRuns.Value);

            testRunSettings.IgnoreAnnotations.Clear();
            foreach (Benchmark.SelectedAnnotation selectedAnnotation in ignoreAnnotationsCopy)
            {
                testRunSettings.IgnoreAnnotations.Add(selectedAnnotation);
            }
        }

        private void NewTestRunDialog_Shown(object sender, EventArgs e)
        {
            txtName.SelectAll();
            txtName.Focus();
        }

        private void NewTestRunDialog_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UpdateSettings();
        }
    }
}
