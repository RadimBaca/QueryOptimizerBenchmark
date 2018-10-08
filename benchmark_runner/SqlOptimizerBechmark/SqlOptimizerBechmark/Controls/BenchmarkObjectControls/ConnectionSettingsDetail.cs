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
    public partial class ConnectionSettingsDetail : BenchmarkObjectDetail
    {
        private DbProviders.DbProviderSettingsControl activeSettingsControl;

        private Benchmark.ConnectionSettings ConnectionSettings
        {
            get { return (Benchmark.ConnectionSettings)BenchmarkObject; }
        }

        public ConnectionSettingsDetail()
        {
            InitializeComponent();
        }

        protected override void BindControls()
        {
            Benchmark.ConnectionSettings connectionSettings = ConnectionSettings;

            comboProviders.BeginUpdate();
            comboProviders.Items.Clear();

            foreach (DbProviders.DbProvider provider in DbProviders.DbProvider.Providers)
            {
                comboProviders.Items.Add(provider);
            }

            comboProviders.EndUpdate();

            comboProviders.SelectedItem = connectionSettings.DbProvider;
        }

        private void comboProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Benchmark.ConnectionSettings connectionSettings = ConnectionSettings;

            if (comboProviders.SelectedItem is DbProviders.DbProvider selectedProvider)
            {
                DbProviders.DbProviderSettingsControl settingsControl = selectedProvider.GetSettingsControl();
                if (activeSettingsControl != settingsControl)
                {
                    gpxProviderSettings.Controls.Clear();
                    activeSettingsControl = settingsControl;
                    gpxProviderSettings.Controls.Add(activeSettingsControl);
                    activeSettingsControl.Dock = DockStyle.Fill;

                    activeSettingsControl.Changed -= ActiveSettingsControl_Changed;
                    activeSettingsControl.Changed += ActiveSettingsControl_Changed;

                    connectionSettings.NotifyChange();
                }
                connectionSettings.DbProvider = selectedProvider;
            }
            else
            {
                gpxProviderSettings.Controls.Clear();
                connectionSettings.DbProvider = null;
            }
        }

        private void ActiveSettingsControl_Changed(object sender, EventArgs e)
        {
            Benchmark.ConnectionSettings connectionSettings = ConnectionSettings;
            connectionSettings.NotifyChange();
        }
    }
}
