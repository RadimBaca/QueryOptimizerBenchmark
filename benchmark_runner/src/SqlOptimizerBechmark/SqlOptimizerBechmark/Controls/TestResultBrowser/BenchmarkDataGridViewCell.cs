using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.TestResultBrowser
{
    public class BenchmarkDataGridViewCell : DataGridViewTextBoxCell
    {
        private bool borderLeft = true;
        private bool borderTop = true;
        private bool borderRight = true;
        private bool borderBottom = true;

        public bool BorderLeft
        {
            get => borderLeft;
            set => borderLeft = value;
        }

        public bool BorderTop
        {
            get => borderTop;
            set => borderTop = value;
        }

        public bool BorderRight
        {
            get => borderRight;
            set => borderRight = value;
        }

        public bool BorderBottom
        {
            get => borderBottom;
            set => borderBottom = value;
        }

        protected void PaintBackground(Graphics graphics, Rectangle cellBounds, DataGridViewElementStates cellState, DataGridViewCellStyle cellStyle)
        {
            Color backColor;

            if ((cellState & DataGridViewElementStates.Selected) != 0)
            {
                backColor = cellStyle.SelectionBackColor;
            }
            else
            {
                backColor = cellStyle.BackColor;
            }
            Brush brush = new SolidBrush(backColor);
            graphics.FillRectangle(brush, cellBounds);
        }

        protected void NavigateBenchmarkObject(Benchmark.BenchmarkObject benchmarkObject)
        {
            TestResultsBrowser testResultsBrowser = (TestResultsBrowser)DataGridView;
            testResultsBrowser.NotifyNavigateBenchmarkObject(benchmarkObject);
        }
    }
}
