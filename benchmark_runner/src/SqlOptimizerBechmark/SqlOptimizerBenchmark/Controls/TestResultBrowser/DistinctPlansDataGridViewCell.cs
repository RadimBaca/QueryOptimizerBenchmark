using SqlOptimizerBenchmark.Benchmark;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.TestResultBrowser
{
    public class DistinctPlansDataGridViewCell: BenchmarkDataGridViewCell
    {
        private PlanEquivalenceTestResult planEquivalenceTestResult;

        public PlanEquivalenceTestResult PlanEquivalenceTestResult
        {
            get => planEquivalenceTestResult;
            set
            {
                planEquivalenceTestResult = value;
                planEquivalenceTestResult.PropertyChanged += PlanEquivalenceTestResult_PropertyChanged;
                UpdateCell();
            }
        }

        public DistinctPlansDataGridViewCell()
        {
            BorderLeft = false;
        }

        private void UpdateCell()
        {
            if (planEquivalenceTestResult == null)
            {
                return;
            }

            if (!planEquivalenceTestResult.Started)
            {
                this.Value = null;
            }

            if (planEquivalenceTestResult.Started && !planEquivalenceTestResult.Completed)
            {
                this.Value = "...";
            }

            if (planEquivalenceTestResult.Completed)
            {
                this.Value = planEquivalenceTestResult.DistinctQueryPlans;
            }

            if (DataGridView != null && !this.Displayed)
            {
                DataGridView.FirstDisplayedScrollingRowIndex = this.RowIndex;
            }
        }

        private void InvalidateCell()
        {
            if (DataGridView != null)
            {
                DataGridView.InvalidateCell(this);
            }
        }

        private void PlanEquivalenceTestResult_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (DataGridView == null)
            {
                planEquivalenceTestResult.PropertyChanged -= PlanEquivalenceTestResult_PropertyChanged;
                return;
            }

            if (e.PropertyName == "Started" || e.PropertyName == "Completed")
            {
                DataGridView.Invoke(new MethodInvoker(UpdateCell));
            }

            if (e.PropertyName == "ErrorMessage")
            {
                this.ToolTipText = planEquivalenceTestResult.ErrorMessage;
                DataGridView.Invoke(new MethodInvoker(InvalidateCell));
            }
        }

        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            DataGridView.Cursor = Cursors.WaitCursor;
            base.OnDoubleClick(e);
            if (planEquivalenceTestResult != null)
            {
                Benchmark.PlanEquivalenceTest test = planEquivalenceTestResult.Owner.FindObjectById(planEquivalenceTestResult.TestId) as Benchmark.PlanEquivalenceTest;
                if (test != null)
                {
                    NavigateBenchmarkObject(test);
                }
            }
            DataGridView.Cursor = Cursors.Default;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if ((paintParts & DataGridViewPaintParts.Background) > 0)
            {
                PaintBackground(graphics, cellBounds, cellState, cellStyle);
            }

            Rectangle areaTestResult1 = new Rectangle(cellBounds.Left, cellBounds.Top, cellBounds.Width, cellBounds.Height / 2);
            Rectangle areaTestResult2 = new Rectangle(cellBounds.Left, cellBounds.Top + cellBounds.Height / 2, cellBounds.Width, cellBounds.Height / 2);

            Font fontRegular = new Font(cellStyle.Font.FontFamily, 8, FontStyle.Regular);
            Font fontBold = new Font(cellStyle.Font.FontFamily, 8, FontStyle.Bold);

            Color foreColor = cellStyle.ForeColor;

            string text = string.Empty;

            if (planEquivalenceTestResult.Started && !planEquivalenceTestResult.Completed)
            {
                foreColor = Color.SteelBlue;
                text = "Running ...";
            }
            else if (planEquivalenceTestResult.Success)
            {
                text = "Passed";
            }
            else if (planEquivalenceTestResult.Completed)
            {
                text = "Failed";
            }

            GraphicsState state = graphics.Save();

            // Content.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisWord;
            format.FormatFlags = StringFormatFlags.NoWrap;

            Brush foreBrush = new SolidBrush(foreColor);

            graphics.DrawString(text, fontBold, foreBrush, areaTestResult1, format);

            if (planEquivalenceTestResult.Completed)
            {
                string distinctQueryPlans = string.Format("unique plans: {0}", planEquivalenceTestResult.DistinctQueryPlans);
                graphics.DrawString(distinctQueryPlans, fontRegular, foreBrush, areaTestResult2, format);
            }

            graphics.Restore(state);
        }
    }
}
