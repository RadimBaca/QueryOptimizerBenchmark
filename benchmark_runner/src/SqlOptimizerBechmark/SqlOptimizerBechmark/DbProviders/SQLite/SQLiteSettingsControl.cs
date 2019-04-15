using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SqlOptimizerBechmark.DbProviders.SQLite
{
    public partial class SQLiteSettingsControl : DbProviderSettingsControl
    {
        private bool ready = true;

        public SQLiteProvider SQLiteProvider
        {
            get => (SQLiteProvider)Provider;
        }
        
        public SQLiteSettingsControl()
        {
            InitializeComponent();
        }

        private void UpdateUI()
        {
            if (Provider == null)
            {
                Enabled = false;
                return;
            }

            SQLiteProvider provider = SQLiteProvider;

            lblFileName.Enabled = !provider.UseConnectionString && !provider.InMemory;
            txtFileName.Enabled = !provider.UseConnectionString && !provider.InMemory;
            btnSelectFileName.Enabled = !provider.UseConnectionString && !provider.InMemory;
            cbxInMemory.Enabled = !provider.UseConnectionString;

            txtConnectionString.Enabled = provider.UseConnectionString;
            Enabled = true;
        }

        public override void BindSettings()
        {
            if (Provider == null)
            {
                return;
            }

            ready = false;

            SQLiteProvider provider = SQLiteProvider;


            rbtnBasicSettings.Checked = !provider.UseConnectionString;
            txtFileName.Text = provider.FileName;
            cbxInMemory.Checked = provider.InMemory;

            rbtnUseConnectionString.Checked = provider.UseConnectionString;
            txtConnectionString.Text = provider.ConnectionString;

            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);

            UpdateUI();

            ready = true;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SQLiteProvider.FileName = txtFileName.Text;
                NotifyChanged();
            }
        }

        private void cbxInMemory_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SQLiteProvider.InMemory = cbxInMemory.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SQLiteProvider.ConnectionString = txtConnectionString.Text;
                NotifyChanged();
            }
        }

        private void rbtnBasicSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SQLiteProvider provider = SQLiteProvider;
                provider.UseConnectionString = !rbtnBasicSettings.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void rbtnUseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SQLiteProvider provider = SQLiteProvider;
                provider.UseConnectionString = rbtnUseConnectionString.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                SQLiteProvider provider = SQLiteProvider;
                SQLiteConnection connection = new SQLiteConnection();
                connection.ConnectionString = provider.GetConnectionString();
                connection.Open();
                connection.Close();
                MessageBox.Show("Connection OK.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCommandTimeout_Validating(object sender, CancelEventArgs e)
        {
            SQLiteProvider provider = SQLiteProvider;
            int i;
            if (int.TryParse(txtCommandTimeout.Text, out i))
            {
                provider.CommandTimeout = i;
            }
            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);
        }

        private void btnSelectFileName_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = false;
            dialog.FileName = txtFileName.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dialog.FileName;
            }
        }
    }
}
