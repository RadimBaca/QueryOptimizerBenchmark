using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.DbProviders.H2
{
    public partial class H2SettingsControl : DbProviderSettingsControl
    {
        private bool ready = true;
        
        public H2Provider H2Provider
        {
            get => (H2Provider)Provider;
        }

        public H2SettingsControl()
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

            H2Provider provider = H2Provider;

            lblUrl.Enabled = !provider.UseConnectionString;
            txtUrl.Enabled = !provider.UseConnectionString;

            lblUser.Enabled = !provider.UseConnectionString;
            txtUser.Enabled = !provider.UseConnectionString;

            lblPassword.Enabled = !provider.UseConnectionString;
            txtPassword.Enabled = !provider.UseConnectionString;

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

            H2Provider provider = H2Provider;

            rbtnBasicSettings.Checked = !provider.UseConnectionString;

            txtUrl.Text = provider.Url;
            txtUser.Text = provider.User;
            txtPassword.Text = provider.Password;

            rbtnUseConnectionString.Checked = provider.UseConnectionString;
            txtConnectionString.Text = provider.ConnectionString;

            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);

            UpdateUI();

            ready = true;
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                H2Provider.Url = txtUrl.Text;
                NotifyChanged();
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                H2Provider.User = txtUser.Text;
                NotifyChanged();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                H2Provider.Password = txtPassword.Text;
                NotifyChanged();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                H2Provider.ConnectionString = txtConnectionString.Text;
                NotifyChanged();
            }
        }

        private void rbtnBasicSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                H2Provider provider = H2Provider;
                provider.UseConnectionString = !rbtnBasicSettings.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void rbtnUseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                H2Provider provider = H2Provider;
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
                H2Provider provider = H2Provider;
                System.Data.H2.H2Connection connection = new System.Data.H2.H2Connection();
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
            H2Provider provider = H2Provider;
            int i;
            if (int.TryParse(txtCommandTimeout.Text, out i))
            {
                provider.CommandTimeout = i;
            }
            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);
        }
    }
}
