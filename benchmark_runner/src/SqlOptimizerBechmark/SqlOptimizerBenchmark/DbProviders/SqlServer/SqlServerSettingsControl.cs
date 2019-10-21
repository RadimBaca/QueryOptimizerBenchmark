using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlOptimizerBenchmark.DbProviders.SqlServer
{
    public partial class SqlServerSettingsControl : DbProviderSettingsControl
    {
        private const int windowsAuthenticationItemIndex = 0;
        private const int sqlServerAuthenticationItemIndex = 1;

        private bool ready = true;
        
        private SqlServerProvider SqlServerProvider
        {
            get => (SqlServerProvider)Provider;
        }

        public SqlServerSettingsControl()
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
            
            SqlServerProvider provider = SqlServerProvider;

            lblDataSource.Enabled = !provider.UseConnectionString;
            txtDataSource.Enabled = !provider.UseConnectionString;

            txtInitialCatalog.Enabled = !provider.UseConnectionString;
            lblInitialCatalog.Enabled = !provider.UseConnectionString;

            lblAuthenticationMode.Enabled = !provider.UseConnectionString;
            comboAuthenticationMode.Enabled = !provider.UseConnectionString;

            lblUserId.Enabled = !provider.UseConnectionString && !provider.IntegratedSecurity;
            txtUserId.Enabled = !provider.UseConnectionString && !provider.IntegratedSecurity;

            lblPassword.Enabled = !provider.UseConnectionString && !provider.IntegratedSecurity;
            txtPassword.Enabled = !provider.UseConnectionString && !provider.IntegratedSecurity;

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

            SqlServerProvider provider = SqlServerProvider;

            rbtnBasicSettings.Checked = !provider.UseConnectionString;
            txtDataSource.Text = provider.DataSource;
            txtInitialCatalog.Text = provider.InitialCatalog;

            if (provider.IntegratedSecurity)
            {
                comboAuthenticationMode.SelectedIndex = windowsAuthenticationItemIndex;
            }
            else
            {
                comboAuthenticationMode.SelectedIndex = sqlServerAuthenticationItemIndex;
            }

            txtUserId.Text = provider.UserId;
            txtPassword.Text = provider.Password;

            rbtnUseConnectionString.Checked = provider.UseConnectionString;
            txtConnectionString.Text = provider.ConnectionString;

            cbxDisableParallelQueryProcessing.Checked = provider.DisableParallelQueryProcessing;

            UpdateUI();

            ready = true;
        }

        private void txtDataSource_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider.DataSource = txtDataSource.Text;
                NotifyChanged();
            }
        }

        private void txtInitialCatalog_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider.InitialCatalog = txtInitialCatalog.Text;
                NotifyChanged();
            }

        }

        private void comboAuthenticationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider.IntegratedSecurity = comboAuthenticationMode.SelectedIndex == windowsAuthenticationItemIndex;
                UpdateUI();
                NotifyChanged();
            }

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider.UserId = txtUserId.Text;
                NotifyChanged();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider.Password = txtPassword.Text;
                NotifyChanged();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider.ConnectionString = txtConnectionString.Text;
                NotifyChanged();
            }
        }

        private void rbtnBasicSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider provider = SqlServerProvider;
                provider.UseConnectionString = !rbtnBasicSettings.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void rbtnUseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider provider = SqlServerProvider;
                provider.UseConnectionString = rbtnUseConnectionString.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void cbxDisableParallelQueryProcessing_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                SqlServerProvider.DisableParallelQueryProcessing = cbxDisableParallelQueryProcessing.Checked;
                NotifyChanged();
            }
        }


        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                SqlServerProvider provider = SqlServerProvider;
                SqlConnection connection = new SqlConnection();
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
    }
}
