using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.DbProviders.MySql
{
    public partial class MySqlSettingsControl : DbProviderSettingsControl
    {
        private bool ready = true;

        public MySqlProvider MySqlProvider
        {
            get => (MySqlProvider)Provider;
        }
        
        public MySqlSettingsControl()
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

            MySqlProvider provider = MySqlProvider;

            lblUserName.Enabled = !provider.UseConnectionString;
            txtUserName.Enabled = !provider.UseConnectionString;

            lblPassword.Enabled = !provider.UseConnectionString;
            txtPassword.Enabled = !provider.UseConnectionString;

            lblHostName.Enabled = !provider.UseConnectionString;
            txtHostName.Enabled = !provider.UseConnectionString;

            lblDefaultSchema.Enabled = !provider.UseConnectionString;
            txtDefaultSchema.Enabled = !provider.UseConnectionString;

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

            MySqlProvider provider = MySqlProvider;

            rbtnBasicSettings.Checked = !provider.UseConnectionString;

            txtUserName.Text = provider.UserName;
            txtPassword.Text = provider.Password;
            txtHostName.Text = provider.HostName;
            txtDefaultSchema.Text = provider.DefaultSchema;

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
                MySqlProvider.UserName = txtUserName.Text;
                NotifyChanged();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                MySqlProvider.Password = txtPassword.Text;
                NotifyChanged();
            }
        }

        private void txtHostName_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                MySqlProvider.HostName = txtHostName.Text;
                NotifyChanged();
            }
        }

        private void txtDefaultSchema_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                MySqlProvider.DefaultSchema = txtDefaultSchema.Text;
                NotifyChanged();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                MySqlProvider.DefaultSchema = txtConnectionString.Text;
                NotifyChanged();
            }
        }

        private void rbtnBasicSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                MySqlProvider provider = MySqlProvider;
                provider.UseConnectionString = !rbtnBasicSettings.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void rbtnUseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                MySqlProvider provider = MySqlProvider;
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
                MySqlProvider provider = MySqlProvider;
                global::MySql.Data.MySqlClient.MySqlConnection connection = new global::MySql.Data.MySqlClient.MySqlConnection();
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
            MySqlProvider provider = MySqlProvider;
            int i;
            if (int.TryParse(txtCommandTimeout.Text, out i))
            {
                provider.CommandTimeout = i;
            }
            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);
        }
    }
}
