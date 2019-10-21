using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls
{
    public partial class StatementPreviewDialog : Form
    {
        private DbProviders.QueryPlan queryPlan;
        private int tokenCount = 0;

        public string Statement
        {
            get => fctb.Text;
            set => fctb.Text = value;
        }

        public int TokenCount
        {
            get => tokenCount;
            set
            {
                tokenCount = value;
                lblTokens.Text = $"Query consists of {tokenCount} tokens.";
            }
        }

        public DbProviders.QueryPlan QueryPlan
        {
            get => queryPlan;
            set
            {
                this.queryPlan = value;
                SetPlanGrid();
            }
        }

        public StatementPreviewDialog()
        {
            InitializeComponent();
        }


        private void UpdateUI()
        {
            bool planIsAvailable = queryPlan != null && queryPlan.Root != null;

            if (!planIsAvailable && tabControl.TabPages.Contains(tabQueryPlan))
            {
                tabControl.TabPages.Remove(tabQueryPlan);
            }
            else if (planIsAvailable && !tabControl.TabPages.Contains(tabQueryPlan))
            {
                tabControl.TabPages.Add(tabQueryPlan);
            }

            pnlTokens.Visible = tokenCount > 0;
        }

        private string GetPrefix(DbProviders.QueryPlanNode node, bool initCall = true)
        {
            string ret = string.Empty;
            
            if (node.Parent != null)
            {
                bool isLastSibling = object.ReferenceEquals(node.Parent.ChildNodes[node.Parent.ChildNodes.Count - 1], node);
                if (isLastSibling)
                {
                    if (initCall)
                    {
                        ret += "   └─ ";
                    }
                    else
                    {
                        ret += "    ";
                    }
                }
                else
                {
                    if (initCall)
                    {
                        ret += "   ├─ ";
                    }
                    else
                    {
                        ret += "   │";
                    }
                }
            }

            string parentPrefix = string.Empty;
            if (node.Parent != null)
            {
                parentPrefix = GetPrefix(node.Parent, false);
            }

            return parentPrefix + ret;
        }

        private void SetPlanGrid()
        {
            gridPlan.Rows.Clear();
            if (queryPlan == null || queryPlan.Root == null)
            {
                return;
            }

            Stack<DbProviders.QueryPlanNode> stack = new Stack<DbProviders.QueryPlanNode>();
            stack.Push(queryPlan.Root);

            while (stack.Count > 0)
            {
                DbProviders.QueryPlanNode node = stack.Pop();
                gridPlan.RowCount += 1;
                DataGridViewRow gridRow = gridPlan.Rows[gridPlan.RowCount - 1];

                gridRow.Cells[colOpName.Index].Value = GetPrefix(node) + node.OpName;
                gridRow.Cells[colEstimatedCost.Index].Value = node.EstimatedCost;
                gridRow.Cells[colActualTime.Index].Value = node.ActualTime;
                gridRow.Cells[colEstimatedRows.Index].Value = node.EstimatedRows;
                gridRow.Cells[colActualRows.Index].Value = node.ActualRows;

                for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
                {
                    DbProviders.QueryPlanNode child = node.ChildNodes[i];
                    stack.Push(child);
                }
            }
            
            foreach (DataGridViewColumn column in gridPlan.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        
        private void StatementPreviewDialog_Shown(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StatementPreviewDialog_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
