using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls
{
    public partial class CsvExportSettingsDialog : Form
    {
        public bool DistinctPlans
        {
            get => rbtnDistinctPlans.Checked;
        }

        public bool QueryVariants
        {
            get => rbtnQueryVariants.Checked;
        }

        public string FileName
        {
            get => txtFileName.Text;
        }

        public CsvExportSettingsDialog()
        {
            InitializeComponent();
        }

        private void UpdateUI()
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(txtFileName.Text);
        }

        private void btnSelectFileName_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV file (*.csv)|*.csv|All files|*";
            dialog.FileName = txtFileName.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dialog.FileName;   
            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void CsvExportSettingsDialog_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
