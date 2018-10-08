using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls
{
    public partial class NewTestRunDialog : Form
    {
        public string TestRunName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        public bool RunInitScript
        {
            get => cbxRunInitScript.Checked;
            set => cbxRunInitScript.Checked = value;
        }

        public bool RunCleanUpScript
        {
            get => cbxRunCleanUpScript.Checked;
            set => cbxRunCleanUpScript.Checked = value;
        }

        public NewTestRunDialog()
        {
            InitializeComponent();
        }

        private void NewTestRunDialog_Shown(object sender, EventArgs e)
        {
            txtName.SelectAll();
            txtName.Focus();
        }
    }
}
