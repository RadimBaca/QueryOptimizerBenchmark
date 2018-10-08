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

            txtName.Text = Configuration.Name;
            txtDescription.Text = Configuration.Description;

            Configuration.PropertyChanged -= Configuration_PropertyChanged;
            Configuration.PropertyChanged += Configuration_PropertyChanged;
        }

        private void Configuration_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
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
