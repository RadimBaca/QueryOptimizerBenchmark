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
    public partial class ScriptDetail : BenchmarkObjectDetail
    {
        public ScriptDetail()
        {
            InitializeComponent();
        }

        private Benchmark.Script Script
        {
            get => (Benchmark.Script)BenchmarkObject;
        }

        protected override void BindControls()
        {
            if (Script == null)
            {
                return;
            }

            scriptEditor.Script = Script;
            scriptEditor.UpdateText();
        }

        protected override void UpdateUI()
        {
            if (Script == null)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }
        }
    }
}
