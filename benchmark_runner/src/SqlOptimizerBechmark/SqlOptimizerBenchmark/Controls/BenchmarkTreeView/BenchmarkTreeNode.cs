using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkTreeView
{
    public class BenchmarkTreeNode: BenchmarkObjectTreeNode
    {
        private ScriptTreeNode initScriptNode;
        private ScriptTreeNode cleanUpScriptNode;
        private FolderTreeNode testGroupsNode;
        private ConnectionSettingsNode connectionSettingsNode;
        private TestRunsTreeNode testRunsNode;

        private ContextMenuStrip testGroupsContextMenu;
        private ContextMenuStrip benchmarkContextMenu;

        public BenchmarkTreeNode(Benchmark.Benchmark benchmark, BenchmarkTreeView benchmarkTreeView)
            : base(benchmark, benchmarkTreeView)
        {
        }

        public override void BindNode()
        {
            BindNamedObjectText();

            Benchmark.Benchmark benchmark = (Benchmark.Benchmark)BenchmarkObject;

            this.ImageKey = "Benchmark";
            this.SelectedImageKey = "Benchmark";

            benchmarkContextMenu = new ContextMenuStrip();
            benchmarkContextMenu.Items.Add("Rename", Properties.Resources.Rename_16, Rename_Click);
            this.ContextMenuStrip = benchmarkContextMenu;
        }

        public override void BindChildren()
        {
            Benchmark.Benchmark benchmark = (Benchmark.Benchmark)BenchmarkObject;

            initScriptNode = new ScriptTreeNode(benchmark.InitScript, BenchmarkTreeView);
            initScriptNode.Text = "Init script";
            initScriptNode.ImageKey = "InitScript";
            initScriptNode.SelectedImageKey = "InitScript";
            this.Nodes.Add(initScriptNode);

            cleanUpScriptNode = new ScriptTreeNode(benchmark.CleanUpScript, BenchmarkTreeView);
            cleanUpScriptNode.Text = "Clean-up script";
            cleanUpScriptNode.ImageKey = "CleanUpScript";
            cleanUpScriptNode.SelectedImageKey = "CleanUpScript";
            this.Nodes.Add(cleanUpScriptNode);

            testGroupsNode = new FolderTreeNode(BenchmarkTreeView);
            testGroupsNode.Text = "Groups";
            testGroupsNode.ImageKey = "Folder";
            testGroupsNode.SelectedImageKey = "Folder";

            BindCollection<Benchmark.TestGroup>(testGroupsNode, benchmark.TestGroups);

            this.Nodes.Add(testGroupsNode);

            connectionSettingsNode = new ConnectionSettingsNode(benchmark.ConnectionSettings, BenchmarkTreeView);
            connectionSettingsNode.Text = "Connection";
            connectionSettingsNode.ImageKey = "Connection";
            connectionSettingsNode.SelectedImageKey = "Connection";
            this.Nodes.Add(connectionSettingsNode);

            testRunsNode = new TestRunsTreeNode(benchmark, BenchmarkTreeView);
            testRunsNode.Text = "Results";
            this.Nodes.Add(testRunsNode);

            BindCollection<Benchmark.TestRun>(testRunsNode, benchmark.TestRuns);

            testGroupsContextMenu = new ContextMenuStrip();
            testGroupsContextMenu.Items.Add("Add", Properties.Resources.Add_16, AddTestGroup_Click);
            testGroupsNode.ContextMenuStrip = testGroupsContextMenu;

            ChildrenBound = true;
        }

        public override bool HasChildren()
        {
            return true;
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            this.BeginEdit();
        }

        private void AddTestGroup_Click(object sender, EventArgs e)
        {
            Benchmark.Benchmark benchmark = (Benchmark.Benchmark)BenchmarkObject;
            Benchmark.TestGroup testGroup = new Benchmark.TestGroup(benchmark);

            testGroup.Name = Helpers.GetNewName(benchmark.TestGroups.Select(g => g.Name), "new test group", NumeralStyle.Guess);
            testGroup.Number = Helpers.GetNewName(benchmark.TestGroups.Select(g => g.Number), null, NumeralStyle.RomanUpper);

            benchmark.TestGroups.Add(testGroup);

            TreeNode newNode = BenchmarkTreeView.GetTreeNode(testGroup);
            if (newNode != null)
            {
                BenchmarkTreeView.TreeView.SelectedNode = newNode;
                newNode.BeginEdit();
            }
        }

        public override bool IsLabelEditable()
        {
            return true;
        }
    }
}
