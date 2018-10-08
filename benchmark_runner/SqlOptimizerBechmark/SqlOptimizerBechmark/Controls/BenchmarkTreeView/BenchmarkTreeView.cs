using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlOptimizerBechmark.Benchmark;

namespace SqlOptimizerBechmark.Controls.BenchmarkTreeView
{
    public partial class BenchmarkTreeView : UserControl
    {
        #region Fields

        private Benchmark.Benchmark benchmark;

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benchmark.Benchmark Benchmark
        {
            get => benchmark;
            set
            {
                this.benchmark = value;

                BenchmarkTreeNode benchmarkNode = new BenchmarkTreeNode(benchmark, this);
                treeView.ImageList = Helpers.CreateBenchmarkImageList();
                treeView.Nodes.Clear();
                treeView.Nodes.Add(benchmarkNode);
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benchmark.IBenchmarkObject SelectedBenchmarkObject
        {
            get
            {
                if (treeView.SelectedNode != null)
                {
                    return GetBenchmarkObject(treeView.SelectedNode);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                // Expand all nodes on the path between the benchmark object and the root.
                if (value != null)
                {
                    Cursor = Cursors.WaitCursor;
                    List<IBenchmarkObject> path = new List<IBenchmarkObject>();
                    IBenchmarkObject obj = value;
                    while (obj != null)
                    {
                        path.Add(obj);
                        obj = obj.ParentObject;
                    }
                    for (int i = path.Count - 1; i > 0; i--)
                    {
                        TreeNode nodePath = GetTreeNode(path[i]);
                        if (nodePath != null)
                        {
                            nodePath.Expand();
                        }
                    }
                    Cursor = Cursors.Default;
                }

                TreeNode node = GetTreeNode(value);
                if (node != null)
                {
                    treeView.SelectedNode = node;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeView TreeView
        {
            get => treeView;
        }

        #endregion

        #region Events

        public event EventHandler SelectionChanged;

        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Constructors
        public BenchmarkTreeView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public BenchmarkObjectTreeNode GetTreeNode(Benchmark.IBenchmarkObject benchmarkObject)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            foreach (TreeNode node in treeView.Nodes)
            {
                stack.Push(node);
            }
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if (node is BenchmarkObjectTreeNode benchmarkObjectTreeNode &&
                    benchmarkObjectTreeNode.BenchmarkObject == benchmarkObject)
                {
                    return benchmarkObjectTreeNode;
                }
                foreach (TreeNode child in node.Nodes)
                {
                    stack.Push(child);
                }
            }
            return null;
        }

        public Benchmark.IBenchmarkObject GetBenchmarkObject(TreeNode node)
        {
            if (node is BenchmarkObjectTreeNode benchmarkObjectTreeNode)
            {
                return benchmarkObjectTreeNode.BenchmarkObject;
            }
            else
            {
                return null;
            }
        }

        public BenchmarkObjectTreeNode CreateNodeForObject(Benchmark.IBenchmarkObject benchmarkObject)
        {
            if (benchmarkObject is Benchmark.Benchmark benchmark)
            {
                return new BenchmarkTreeNode(benchmark, this);
            }
            else if (benchmarkObject is Benchmark.Configuration configuration)
            {
                return new ConfigurationTreeNode(configuration, this);
            }
            else if (benchmarkObject is Benchmark.PlanEquivalenceTest planEquivalenceTest)
            {
                return new PlanEquivalenceTestTreeNode(planEquivalenceTest, this);
            }
            else if (benchmarkObject is Benchmark.QueryVariant queryVariant)
            {
                return new QueryVariantTreeNode(queryVariant, this);
            }
            else if (benchmarkObject is Benchmark.Script script)
            {
                return new ScriptTreeNode(script, this);
            }
            else if (benchmarkObject is Benchmark.Statement statement)
            {
                return new StatementTreeNode(statement, this);
            }
            else if (benchmarkObject is Benchmark.TestGroup testGroup)
            { 
                return new TestGroupTreeNode(testGroup, this);
            }
            else if (benchmarkObject is Benchmark.TestRun testRun)
            {
                return new TestRunTreeNode(testRun, this);
            }

            throw new ArgumentException("Invalid benchmark object type");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                if (treeView.SelectedNode != null)
                {
                    treeView.SelectedNode.BeginEdit();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Event handlers

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnSelectionChanged();
        }

        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node is BenchmarkObjectTreeNode benchmarkObjectTreeNode)
            {
                if (!benchmarkObjectTreeNode.IsLabelEditable())
                {
                    e.CancelEdit = true;
                }
            }
            else
            {
                e.CancelEdit = true;
            }
        }

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node is BenchmarkObjectTreeNode benchmarkObjectTreeNode &&
                e.Label != null)
            {
                benchmarkObjectTreeNode.AfterLabelEdit(e.Label);
            }
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView.BeginUpdate();
            Cursor = Cursors.WaitCursor;
            TreeNode node = e.Node;
            if (node.Nodes.Count == 1 && node.Nodes[0] is FakeTreeNode &&
                node is BenchmarkObjectTreeNode benchmarkObjectTreeNode)
            {
                benchmarkObjectTreeNode.Nodes.Clear();
                benchmarkObjectTreeNode.BindChildren();
            }
            Cursor = Cursors.Default;
            treeView.EndUpdate();
        }

        #endregion
    }
}
