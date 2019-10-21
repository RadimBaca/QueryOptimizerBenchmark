using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SqlOptimizerBenchmark.DbProviders.Firebird
{
    public partial class FirebirdSettingsControl : DbProviderSettingsControl
    {
        private bool ready = true;

        public FirebirdProvider FirebirdProvider
        {
            get => (FirebirdProvider)Provider;
        }

        public FirebirdSettingsControl()
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

            FirebirdProvider provider = FirebirdProvider;

            lblUserName.Enabled = !provider.UseConnectionString;
            txtUserName.Enabled = !provider.UseConnectionString;

            lblPassword.Enabled = !provider.UseConnectionString;
            txtPassword.Enabled = !provider.UseConnectionString;

            lblHostName.Enabled = !provider.UseConnectionString;
            txtHostName.Enabled = !provider.UseConnectionString;

            lblDatabase.Enabled = !provider.UseConnectionString;
            lblDatabase.Enabled = !provider.UseConnectionString;

            cbxAdminRole.Enabled = !provider.UseConnectionString;

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

            FirebirdProvider provider = FirebirdProvider;

            rbtnBasicSettings.Checked = !provider.UseConnectionString;

            txtUserName.Text = provider.UserName;
            txtPassword.Text = provider.Password;
            txtHostName.Text = provider.HostName;
            txtDatabase.Text = provider.Database;
            cbxAdminRole.Checked = provider.AdminRole;

            rbtnUseConnectionString.Checked = provider.UseConnectionString;
            txtConnectionString.Text = provider.ConnectionString;

            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);

            UpdateUI();

            ready = true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider.UserName = txtUserName.Text;
                NotifyChanged();
            }
        }

        private void cbxAdminRole_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider.AdminRole = cbxAdminRole.Checked;
                NotifyChanged();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider.Password = txtPassword.Text;
                NotifyChanged();
            }
        }

        private void txtHostName_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider.HostName = txtHostName.Text;
                NotifyChanged();
            }
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider.Database = txtDatabase.Text;
                NotifyChanged();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider.ConnectionString = txtConnectionString.Text;
                NotifyChanged();
            }
        }

        private void rbtnBasicSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider provider = FirebirdProvider;
                provider.UseConnectionString = !rbtnBasicSettings.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void rbtnUseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                FirebirdProvider provider = FirebirdProvider;
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
                FirebirdProvider provider = FirebirdProvider;
                FbConnection connection = new FbConnection();
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
            FirebirdProvider provider = FirebirdProvider;
            int i;
            if (int.TryParse(txtCommandTimeout.Text, out i))
            {
                provider.CommandTimeout = i;
            }
            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);
        }
    }
}
