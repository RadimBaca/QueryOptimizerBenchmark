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
    public class PlanEquivalenceTestDataGridViewCell : BenchmarkDataGridViewCell
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

        public PlanEquivalenceTestDataGridViewCell()
        {
            BorderRight = false;
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

            const int iconSpace = 20;

            Rectangle areaIcon = new Rectangle(cellBounds.Left, cellBounds.Top, iconSpace, cellBounds.Height);
            Rectangle areaName = new Rectangle(cellBounds.Left + iconSpace, cellBounds.Top, cellBounds.Width - iconSpace, cellBounds.Height);

            Font fontBold = new Font(cellStyle.Font.FontFamily, 8, FontStyle.Bold);

            Color foreColor = cellStyle.ForeColor;

            string text = string.Empty;

            if (planEquivalenceTestResult.Started && !planEquivalenceTestResult.Completed)
            {
                foreColor = Color.SteelBlue;
            }

            Image icon = null;

            if (!string.IsNullOrEmpty(planEquivalenceTestResult.ErrorMessage))
            {
                icon = Properties.Resources.WarningFlat_16;
            }
            else if (planEquivalenceTestResult.Started && !planEquivalenceTestResult.Completed)
            {
                icon = Properties.Resources.RunningBlue_16;
            }
            else if (planEquivalenceTestResult.Success)
            {
                icon = Properties.Resources.OkGreenFlat_16;
            }
            else if (planEquivalenceTestResult.Completed)
            {
                icon = Properties.Resources.ErrorFlat_16;
            }

            if (icon != null)
            {
                Rectangle rectIcon = new Rectangle(areaIcon.Left + (areaIcon.Width - icon.Width) / 2, areaIcon.Top + (areaIcon.Height - icon.Height) / 2,
                    icon.Width, icon.Height);
                graphics.DrawImage(icon, rectIcon);
            }

            GraphicsState state = graphics.Save();

            // Content.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisWord;
            format.FormatFlags = StringFormatFlags.NoWrap;

            Brush foreBrush = new SolidBrush(foreColor);

            string str = planEquivalenceTestResult.TestNumber;
            if (!string.IsNullOrEmpty(planEquivalenceTestResult.TemplateNumber))
            {
                str += "/" + planEquivalenceTestResult.TemplateNumber;
            }

            string title = Helpers.GetTitle(str, planEquivalenceTestResult.TestName);
            graphics.DrawString(title, fontBold, foreBrush, areaName, format);

            graphics.Restore(state);
        }
    }
}
