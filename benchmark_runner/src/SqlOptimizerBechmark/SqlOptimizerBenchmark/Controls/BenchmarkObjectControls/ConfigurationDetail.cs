using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    public partial class ConfigurationDetail : BenchmarkObjectDetail
    {
        public ConfigurationDetail()
        {
            InitializeComponent();
        }

        private Benchmark.Configuration Configuration
        {
            get => (Benchmark.Configuration)BenchmarkObject;
        }

        protected override void BindControls()
        {
            if (Configuration == null)
            {
                return;
            }

            txtNumber.Text = Configuration.Number;
            txtName.Text = Configuration.Name;
            txtDescription.Text = Configuration.Description;

            Configuration.PropertyChanged -= Configuration_PropertyChanged;
            Configuration.PropertyChanged += Configuration_PropertyChanged;

            CheckUniqueNumber();
        }

        private void CheckUniqueNumber()
        {
            bool notUnique = false;

            foreach (Benchmark.Configuration configuration in Configuration.TestGroup.Configurations)
            {
                if (configuration != Configuration && configuration.Number == Configuration.Number)
                {
                    notUnique = true;
                    break;
                }
            }

            warningProvider.Clear();
            if (notUnique)
            {
                warningProvider.SetError(txtNumber, "The configuration number is not unique within the test group!");
            }
        }

        private void Configuration_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Number")
            {
                txtNumber.Text = Configuration.Number;
            }
            else if (e.PropertyName == "Name")
            {
                txtName.Text = Configuration.Name;
            }
            else if (e.PropertyName == "Description")
            {
                txtDescription.Text = Configuration.Description;
            }
        }

        protected override void UpdateUI()
        {
            if (Configuration == null)
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
            Configuration.Number = txtNumber.Text;
            CheckUniqueNumber();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Configuration.Name = txtName.Text;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            Configuration.Description = txtDescription.Text;
        }

        private void lblInitScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(Configuration.InitScript);
        }

        private void lblCleanUpScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(Configuration.CleanUpScript);
        }

        private void lblTestGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnNavigateBenchmarkObject(Configuration.TestGroup);
        }
    }
}
