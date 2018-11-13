using SqlOptimizerBechmark.Benchmark;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.TestResultBrowser
{
    public class QueryVariantDataGridViewCell : BenchmarkDataGridViewCell
    {
        private QueryVariantResult queryVariantResult;

        public QueryVariantResult QueryVariantResult
        {
            get => queryVariantResult;
            set
            {
                queryVariantResult = value;
                queryVariantResult.PropertyChanged += QueryVariantResult_PropertyChanged;
                UpdateCell();
            }
        }

        private void UpdateCell()
        {
            if (queryVariantResult == null)
            {
                return;
            }

            if (!queryVariantResult.Started)
            {
                this.Value = null;
            }

            if (queryVariantResult.Started && !queryVariantResult.Completed)
            {
                this.Value = "...";
            }

            if (queryVariantResult.Completed)
            {
                this.Value = queryVariantResult.QueryProcessingTime;
            }

            if (queryVariantResult.ErrorMessage == string.Empty)
            {
                this.ToolTipText = queryVariantResult.Query;
            }
            else
            {
                this.ToolTipText = queryVariantResult.ErrorMessage;
            }
        }

        private void QueryVariantResult_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (DataGridView == null)
            {
                queryVariantResult.PropertyChanged -= QueryVariantResult_PropertyChanged;
                return;
            }

            if (e.PropertyName == "Started" || e.PropertyName == "Completed" || e.PropertyName == "ErrorMessage")
            {
                DataGridView.Invoke(new MethodInvoker(UpdateCell));
            }
        }

        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            DataGridView.Cursor = Cursors.WaitCursor;
            base.OnDoubleClick(e);
            if (queryVariantResult != null)
            {
                Benchmark.QueryVariant queryVariant =
                    queryVariantResult.Owner.FindObjectById(queryVariantResult.QueryVariantId) as Benchmark.QueryVariant;
                if (queryVariant != null)
                {
                    NavigateBenchmarkObject(queryVariant);
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
            Rectangle areaQueryVariantName = new Rectangle(cellBounds.Left + iconSpace, cellBounds.Top, cellBounds.Width - iconSpace, cellBounds.Height / 2);
            Rectangle areaQueryProcessingTime = new Rectangle(cellBounds.Left + iconSpace, cellBounds.Top + cellBounds.Height / 2, (cellBounds.Width - iconSpace) / 2, cellBounds.Height / 2);
            Rectangle areaResultSize = new Rectangle(cellBounds.Left + iconSpace + (cellBounds.Width - iconSpace) / 2, cellBounds.Top + cellBounds.Height / 2, (cellBounds.Width - iconSpace) / 2 - 5, cellBounds.Height / 2);

            Font fontRegular = new Font(cellStyle.Font.FontFamily, 8, FontStyle.Regular);
            Font fontBold = new Font(cellStyle.Font.FontFamily, 8, FontStyle.Bold);

            Image icon = null;
            Color foreColor = cellStyle.ForeColor;

            if (queryVariantResult.ErrorMessage != string.Empty)
            {
                icon = Properties.Resources.WarningFlat_16;
                foreColor = Color.Red;
            }
            else if (queryVariantResult.Started && !queryVariantResult.Completed)
            {
                icon = Properties.Resources.RunningBlue_16;
                foreColor = Color.SteelBlue;
            }
            else if (queryVariantResult.Completed)
            {
                icon = Properties.Resources.OkBlueFlat_16;
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

            string title = Helpers.GetTitle(queryVariantResult.QueryVariantNumber, queryVariantResult.QueryVariantName);
            graphics.DrawString(title, fontBold, foreBrush, areaQueryVariantName, format);

            if (queryVariantResult.Completed)
            {
                if (queryVariantResult.ErrorMessage == string.Empty)
                {
                    string timeSpanStr = queryVariantResult.QueryProcessingTime.TotalSeconds.ToString("#,0.000") + " s";
                    graphics.DrawString(timeSpanStr, fontRegular, foreBrush, areaQueryProcessingTime, format);

                    string resultSizeStr = queryVariantResult.ResultSize.ToString() + " rows";
                    format.Alignment = StringAlignment.Far;
                    graphics.DrawString(resultSizeStr, fontRegular, foreBrush, areaResultSize, format);
                }
                else
                {
                    string errorStr = "error";
                    graphics.DrawString(errorStr, fontRegular, foreBrush, areaQueryProcessingTime, format);
                }
            }

            graphics.Restore(state);

        }
    }
}
