using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls
{
    public class DataGridViewEx: DataGridView
    {
        public DataGridViewEx()
        {
            DoubleBuffered = true;
        }
    }
}
