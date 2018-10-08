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
    public partial class BenchmarkObjectDetail : UserControl
    {
        private Benchmark.IBenchmarkObject benchmarkObject;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benchmark.IBenchmarkObject BenchmarkObject
        {
            get => benchmarkObject;
            set
            {
                benchmarkObject = value;
                BindControls();
                UpdateUI();
            }
        }

        public event BenchmarkObjectEventHandler NavigateBenchmarkObject;

        protected virtual void OnNavigateBenchmarkObject(Benchmark.IBenchmarkObject benchmarkObject)
        {
            if (NavigateBenchmarkObject != null)
            {
                NavigateBenchmarkObject(this, new BenchmarkObjectEventArgs(benchmarkObject));
            }
        }

        public BenchmarkObjectDetail()
        {
            InitializeComponent();
        }

        protected virtual void BindControls()
        {

        }
        protected virtual void UpdateUI()
        {

        }
    }
}
