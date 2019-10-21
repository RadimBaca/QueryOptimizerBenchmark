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
    public class ConfigurationDataGridViewCell : BenchmarkDataGridViewCell
    {
        private ConfigurationResult configurationResult;

        public ConfigurationResult ConfigurationResult
        {
            get => configurationResult;
            set
            {
                configurationResult = value;
                configurationResult.PropertyChanged += PlanEquivalenceTestResult_PropertyChanged;
                UpdateCell();
            }
        }

        public ConfigurationDataGridViewCell()
        {
            BorderLeft = false;
            BorderTop = false;
            BorderRight = false;
            BorderBottom = false;
        }

        private void UpdateCell()
        {
            if (configurationResult == null)
            {
                return;
            }

            if (configurationResult.InitScriptStarted && !configurationResult.InitScriptCompleted)
            {
                this.Value = "initializing ...";
            }
            else if (configurationResult.CleanUpScriptStarted && !configurationResult.CleanUpScriptCompleted)
            {
                this.Value = "cleaning ...";
            }
            else
            {
                this.Value = configurationResult.ConfigurationName;
            }

            if (!string.IsNullOrEmpty(configurationResult.InitScriptErrorMessage))
            {
                this.ToolTipText = "Init script: " + configurationResult.InitScriptErrorMessage;
            }
            
            if (!string.IsNullOrEmpty(configurationResult.CleanUpScriptErrorMessage))
            {
                this.ToolTipText = "Clean-up script: " + configurationResult.CleanUpScriptErrorMessage;
            }

            if (DataGridView != null && !this.Displayed)
            {
                DataGridView.FirstDisplayedScrollingRowIndex = this.RowIndex;
            }

            if (DataGridView != null)
            {
                DataGridView.InvalidateCell(this);
            }
        }


        private void PlanEquivalenceTestResult_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (DataGridView == null)
            {
                configurationResult.PropertyChanged -= PlanEquivalenceTestResult_PropertyChanged;
                return;
            }

            if (e.PropertyName == "InitScriptStarted" || e.PropertyName == "InitScriptCompleted" || e.PropertyName == "InitScriptErrorMessage" ||
                e.PropertyName == "CleanUpScriptStarted" || e.PropertyName == "CleanUpScriptCompleted" || e.PropertyName == "CleanUpScriptErrorMessage")
            {
                DataGridView.Invoke(new MethodInvoker(UpdateCell));
            }
        }

        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            DataGridView.Cursor = Cursors.WaitCursor;
            base.OnDoubleClick(e);
            if (configurationResult != null)
            {
                Benchmark.Configuration configuration = configurationResult.Owner.FindObjectById(configurationResult.ConfigurationId) as Benchmark.Configuration;
                if (configuration != null)
                {
                    NavigateBenchmarkObject(configuration);
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
                        
            Image icon = null;

            if (!string.IsNullOrEmpty(configurationResult.InitScriptErrorMessage) ||
                !string.IsNullOrEmpty(configurationResult.CleanUpScriptErrorMessage))
            {
                icon = Properties.Resources.WarningFlat_16;
                foreColor = Color.Red;
            }
            else if (
                configurationResult.InitScriptStarted && !configurationResult.InitScriptCompleted ||
                configurationResult.CleanUpScriptStarted && !configurationResult.CleanUpScriptCompleted)
            {
                icon = Properties.Resources.RunningBlue_16;
                foreColor = Color.SteelBlue;
            }
            else if (configurationResult.InitScriptCompleted && !configurationResult.CleanUpScriptStarted)
            {
                icon = Properties.Resources.OkBlueFlat_16;
                foreColor = Color.SteelBlue;
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

            string title = Helpers.GetTitle(configurationResult.ConfigurationNumber, configurationResult.ConfigurationName);

            graphics.DrawString(title, fontBold, foreBrush, areaName, format);

            graphics.Restore(state);
        }
    }
}
