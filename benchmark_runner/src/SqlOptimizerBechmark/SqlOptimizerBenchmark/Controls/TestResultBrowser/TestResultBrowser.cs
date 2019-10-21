using SqlOptimizerBenchmark.Benchmark;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.TestResultBrowser
{
    public class TestResultsBrowser: DataGridViewEx
    {
        private TestRun testRun;
        private DataGridViewColumn nameColumn;
        private DataGridViewColumn[] extraColumns;


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestRun TestRun
        {
            get => testRun;
            set
            {
                if (testRun != value)
                {
                    testRun = value;
                    PrepareGrid();
                }
            }
        }

        public event BenchmarkObjectEventHandler NavigateBenchmarkObject;

        protected virtual void OnNavigateBenchmarkObject(Benchmark.BenchmarkObject benchmarkObject)
        {
            if (NavigateBenchmarkObject != null)
            {
                NavigateBenchmarkObject(this, new BenchmarkObjectEventArgs(benchmarkObject));
            }
        }
               
        public TestResultsBrowser()
        {
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.None;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
        }

        private int GetPlanEquivalenceTestColumnCount(PlanEquivalenceTestResult planEquivalenceTestResult)
        {
            return planEquivalenceTestResult.QueryVariantResults.Count + 1;
        }        

        private void SetPlanEquivalenceTestRow(int rowIndex, PlanEquivalenceTestResult planEquivalenceTestResult)
        {
            PlanEquivalenceTestDataGridViewCell planEquivalenceTestCell = new PlanEquivalenceTestDataGridViewCell();
            planEquivalenceTestCell.PlanEquivalenceTestResult = planEquivalenceTestResult;
            this[nameColumn.Index, rowIndex] = planEquivalenceTestCell;

            int extraColumnIndex = 0;

            DistinctPlansDataGridViewCell distinctPlansCell = new DistinctPlansDataGridViewCell();
            distinctPlansCell.PlanEquivalenceTestResult = planEquivalenceTestResult;
            this[extraColumns[extraColumnIndex++].Index, rowIndex] = distinctPlansCell;

            foreach (QueryVariantResult queryVariantResult in planEquivalenceTestResult.QueryVariantResults)
            {
                QueryVariantDataGridViewCell queryVariantCell = new QueryVariantDataGridViewCell();
                queryVariantCell.QueryVariantResult = queryVariantResult;
                this[extraColumns[extraColumnIndex++].Index, rowIndex] = queryVariantCell;
            }
        }

        public void NotifyNavigateBenchmarkObject(Benchmark.BenchmarkObject benchmarkObject)
        {
            if (!Executor.Executor.Instance.Testing)
            {
                OnNavigateBenchmarkObject(benchmarkObject);
            }
        }

        private void InitColumns()
        {
            Font font = new Font("Calibri", 9);

            Columns.Clear();

            nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Test name";
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            nameColumn.Width = 200;
            nameColumn.DefaultCellStyle.Font = font;
            Columns.Add(nameColumn);

            // Determine the maximum number of extra columns needed by individual tests.
            int extraColumnCount = 0;
            foreach (TestResult testResult in testRun.TestResults)
            {
                if (testResult is PlanEquivalenceTestResult planEquivalenceTestResult)
                {
                    int columnCount = GetPlanEquivalenceTestColumnCount(planEquivalenceTestResult);
                    if (columnCount > extraColumnCount)
                    {
                        extraColumnCount = columnCount;
                    }
                }
            }

            extraColumns = new DataGridViewColumn[extraColumnCount];
            for (int i = 0; i < extraColumnCount; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = string.Empty;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 150;
                column.DefaultCellStyle.Font = font;
                extraColumns[i] = column;
                Columns.Add(column);
            }
        }

        private void SetTestGroupRowStyle(DataGridViewRow gridViewRow)
        {
            gridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(0xFF, 0xA5, 0xF4, 0xED);
            gridViewRow.DefaultCellStyle.Font = new Font(gridViewRow.InheritedStyle.Font, FontStyle.Bold);
        }

        private void SetConfigurationRowStyle(DataGridViewRow gridViewRow)
        {
            gridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(0xFF, 0xE0, 0xFC, 0xE9);
            gridViewRow.DefaultCellStyle.Font = new Font(gridViewRow.InheritedStyle.Font, FontStyle.Bold);
        }

        private void SetTestRowStyle(DataGridViewRow gridViewRow)
        {
            gridViewRow.Height = 32;
        }

        public void PrepareGrid()
        {
            InitColumns();

            Dictionary<int, int> testGroupOrder = new Dictionary<int, int>();
            Dictionary<int, int> configurationOrder = new Dictionary<int, int>();

            int index;

            index = 0;
            foreach (Benchmark.TestGroupResult testGroupResult in testRun.TestGroupResults)
            {
                testGroupOrder.Add(testGroupResult.TestGroupId, index++);
            }

            index = 0;
            foreach (Benchmark.ConfigurationResult configurationResult in testRun.ConfigurationResults)
            {
                configurationOrder.Add(configurationResult.ConfigurationId, index++);
            }

            RowCount = testRun.TestResults.Count;
            int rowIndex = 0;
            int prevTestGroupId = 0;
            int prevConfigurationId = 0;
            foreach (Benchmark.TestResult testResult in testRun.TestResults.
                OrderBy(t => testGroupOrder[t.TestGroupId]).
                ThenBy(t => configurationOrder[t.ConfigurationId]))
            {
                if (prevTestGroupId != testResult.TestGroupId)
                {
                    TestGroupResult testGroupResult = testRun.GetTestGroupResult(testResult.TestGroupId);

                    this[nameColumn.Index, rowIndex].Value =
                        Helpers.GetTitle(testGroupResult.TestGroupNumber, testGroupResult.TestGroupName);

                    SetTestGroupRowStyle(Rows[rowIndex]);
                    rowIndex++;
                    if (rowIndex >= RowCount)
                    {
                        RowCount += 100;
                    }
                    prevTestGroupId = testResult.TestGroupId;
                }
                if (prevConfigurationId != testResult.ConfigurationId)
                {
                    ConfigurationDataGridViewCell cell = new ConfigurationDataGridViewCell();
                    cell.ConfigurationResult = testRun.GetConfigurationResult(testResult.ConfigurationId);
                    this[nameColumn.Index, rowIndex] = cell;

                    SetConfigurationRowStyle(Rows[rowIndex]);
                    rowIndex++;
                    if (rowIndex >= RowCount)
                    {
                        RowCount += 100;
                    }
                    prevConfigurationId = testResult.ConfigurationId;
                }
                SetTestRowStyle(Rows[rowIndex]);

                this[nameColumn.Index, rowIndex].Value = testResult.TestName;

                if (testResult is PlanEquivalenceTestResult planEquivalenceTestResult)
                {
                    SetPlanEquivalenceTestRow(rowIndex, planEquivalenceTestResult);
                }

                rowIndex++;
                if (rowIndex >= RowCount)
                {
                    RowCount += 100;
                }
            }

            RowCount = rowIndex;
        }

        

        /// <summary>
        /// Copies SQL queries of all selected cells into the clipboard.
        /// </summary>
        public void CopySelectedQueries()
        {
            string sql = string.Empty;

            foreach (DataGridViewCell cell in SelectedCells)
            {
                if (cell is QueryVariantDataGridViewCell qvCell)
                {
                    string code = qvCell.QueryVariantResult.GetCode();                    
                    string query = qvCell.QueryVariantResult.Query;

                    sql += "--" + code + Environment.NewLine + Environment.NewLine;
                    sql += query + Environment.NewLine;
                    sql += "-----------------------------------------------------------------------------------------------" + Environment.NewLine;
                }
            }

            Clipboard.SetText(sql);
        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            //
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, e.PaintParts);

                bool borderLeft = false;
                bool borderTop = false;
                bool borderRight = false;
                bool borderBottom = false;

                if (this[e.ColumnIndex, e.RowIndex] is BenchmarkDataGridViewCell benchmarkCell)
                {
                    borderRight = benchmarkCell.BorderRight;
                    borderBottom = benchmarkCell.BorderBottom;

                    if (e.ColumnIndex == 0)
                    {
                        borderLeft = benchmarkCell.BorderLeft;
                    }
                    if (e.RowIndex == 0)
                    {
                        borderTop = benchmarkCell.BorderTop;
                    }
                }

                if (e.ColumnIndex < ColumnCount - 1 && this[e.ColumnIndex + 1, e.RowIndex] is BenchmarkDataGridViewCell rightCell)
                {
                    if (rightCell.BorderLeft)
                    {
                        borderRight = true;
                    }
                }

                if (e.RowIndex < RowCount - 1 && this[e.ColumnIndex, e.RowIndex + 1] is BenchmarkDataGridViewCell bottomCell)
                {
                    if (bottomCell.BorderTop)
                    {
                        borderBottom = true;
                    }
                }

                // Borders.
                Pen borderPen = new Pen(Color.FromArgb(30, 0, 0, 0));

                if (borderLeft)
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
                if (borderTop)
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                }
                if (borderRight)
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                }
                if (borderBottom)
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TestResultsBrowser
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle1;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
