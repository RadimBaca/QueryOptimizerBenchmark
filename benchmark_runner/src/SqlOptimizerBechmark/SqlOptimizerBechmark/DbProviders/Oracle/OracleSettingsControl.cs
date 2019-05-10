using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace SqlOptimizerBechmark.DbProviders.Oracle
{
    public partial class OracleSettingsControl : DbProviderSettingsControl
    {
        private bool ready = true;

        public OracleProvider OracleProvider
        {
            get => (OracleProvider)Provider;
        }

        public OracleSettingsControl()
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

            OracleProvider provider = OracleProvider;

            lblUserName.Enabled = !provider.UseConnectionString;
            txtUserName.Enabled = !provider.UseConnectionString;

            lblPassword.Enabled = !provider.UseConnectionString;
            txtPassword.Enabled = !provider.UseConnectionString;

            lblHostName.Enabled = !provider.UseConnectionString;
            txtHostName.Enabled = !provider.UseConnectionString;

            lblPort.Enabled = !provider.UseConnectionString;
            txtPort.Enabled = !provider.UseConnectionString;

            lblSID.Enabled = !provider.UseConnectionString;
            txtSID.Enabled = !provider.UseConnectionString;

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

            OracleProvider provider = OracleProvider;

            rbtnBasicSettings.Checked = !provider.UseConnectionString;
            txtUserName.Text = provider.UserName;
            txtPassword.Text = provider.Password;
            txtHostName.Text = provider.HostName;
            txtPort.Text = Convert.ToString(provider.Port);
            txtSID.Text = provider.SID;

            rbtnUseConnectionString.Checked = provider.UseConnectionString;
            txtConnectionString.Text = provider.ConnectionString;

            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);
            cbxDisableParallelQueryProcessing.Checked = provider.DisableParallelQueryProcessing;

            UpdateUI();

            ready = true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider.UserName = txtUserName.Text;
                NotifyChanged();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider.Password = txtPassword.Text;
                NotifyChanged();
            }
        }

        private void txtHostName_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider.HostName = txtHostName.Text;
                NotifyChanged();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider.ConnectionString = txtConnectionString.Text;
                NotifyChanged();
            }
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider.SID = txtSID.Text;
                NotifyChanged();
            }
        }

        private void txtPort_Validating(object sender, CancelEventArgs e)
        {
            OracleProvider provider = OracleProvider;
            int i;
            if (int.TryParse(txtPort.Text, out i))
            {
                provider.Port = i;
            }
            txtPort.Text = Convert.ToString(provider.Port);
        }

        private void rbtnBasicSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider provider = OracleProvider;
                provider.UseConnectionString = !rbtnBasicSettings.Checked;
                UpdateUI();
                NotifyChanged();
            }
        }

        private void rbtnUseConnectionString_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider provider = OracleProvider;
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
                OracleProvider provider = OracleProvider;
                OracleConnection connection = new OracleConnection();
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
            OracleProvider provider = OracleProvider;
            int i;
            if (int.TryParse(txtCommandTimeout.Text, out i))
            {
                provider.CommandTimeout = i;
            }
            txtCommandTimeout.Text = Convert.ToString(provider.CommandTimeout);
        }

        private void cbxDisableParallelQueryProcessing_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                OracleProvider.DisableParallelQueryProcessing = cbxDisableParallelQueryProcessing.Checked;
                NotifyChanged();
            }
        }
    }
}
