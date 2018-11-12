using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace SqlOptimizerBechmark.DbProviders.PostgreSql
{
    public partial class PostgreSqlSettingsControl : DbProviderSettingsControl
    {
        private bool ready = true;

        public PostgreSqlProvider PostgreSqlProvider
        {
            get => (PostgreSqlProvider)Provider;
        }

        public PostgreSqlSettingsControl()
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

            PostgreSqlProvider provider = PostgreSqlProvider;

            lblHost.Enabled = !provider.UseConnectionString;
            txtHost.Enabled = !provider.UseConnectionString;

            lblUserName.Enabled = !provider.UseConnectionString;
            txtUserName.Enabled = !provider.UseConnectionString;

            lblPassword.Enabled = !provider.UseConnectionString;
            txtPassword.Enabled = !provider.UseConnectionString;

            lblDatabase.Enabled = !provider.UseConnectionString;
            txtDatabase.Enabled = !provider.UseConnectionString;

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

            PostgreSqlProvider provider = PostgreSqlProvider;

            rbtnBasicSettings.Checked = !provider.UseConnectionString;
            txtHost.Text = provider.Host;
            txtUserName.Text = provider.UserName;
            txtPassword.Text = provider.Password;
            txtDatabase.Text = provider.Database;
            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);

            rbtnUseConnectionString.Checked = provider.UseConnectionString;
            txtConnectionString.Text = provider.ConnectionString;
            
            UpdateUI();

            ready = true;
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                PostgreSqlProvider.Host = txtHost.Text;
                NotifyChanged();
            }
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                PostgreSqlProvider.Database = txtDatabase.Text;
                NotifyChanged();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                PostgreSqlProvider.UserName = txtUserName.Text;
                NotifyChanged();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                PostgreSqlProvider.Password = txtPassword.Text;
                NotifyChanged();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                PostgreSqlProvider.ConnectionString = txtConnectionString.Text;
                NotifyChanged();
            }
        }

        private void rbtnBasicSettings_CheckedChanged(object sender, EventArgs e)
        {
            PostgreSqlProvider provider = PostgreSqlProvider;
            provider.UseConnectionString = !rbtnBasicSettings.Checked;
            UpdateUI();
        }

        private void rbtnUseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            PostgreSqlProvider provider = PostgreSqlProvider;
            provider.UseConnectionString = rbtnUseConnectionString.Checked;
            UpdateUI();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                PostgreSqlProvider provider = PostgreSqlProvider;
                NpgsqlConnection connection = new NpgsqlConnection();
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
            PostgreSqlProvider provider = PostgreSqlProvider;
            int i;
            if (int.TryParse(txtCommandTimeout.Text, out i))
            {
                provider.CommandTimeout = i;
            }
            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);
        }
    }
}
