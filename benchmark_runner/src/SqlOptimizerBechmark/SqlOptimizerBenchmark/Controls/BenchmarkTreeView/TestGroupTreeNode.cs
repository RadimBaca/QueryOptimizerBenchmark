using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkTreeView
{
    public class TestGroupTreeNode : BenchmarkObjectTreeNode
    {
        private FolderTreeNode configurationsNode;
        private FolderTreeNode testsNode;
        private ContextMenuStrip testGroupContextMenu;
        private ContextMenuStrip configurationsContextMenu;
        private ContextMenuStrip testsContextMenu;

        public TestGroupTreeNode(Benchmark.TestGroup testGroup, BenchmarkTreeView benchmarkTreeView)
            : base(testGroup, benchmarkTreeView)
        {
        }

        public override void BindNode()
        {
            BindNamedObjectText();

            Benchmark.TestGroup testGroup = (Benchmark.TestGroup)BenchmarkObject;

            this.ImageKey = "TestGroup";
            this.SelectedImageKey = "TestGroup";

            testGroupContextMenu = new ContextMenuStrip();
            testGroupContextMenu.Items.Add("Rename", Properties.Resources.Rename_16, Rename_Click);
            testGroupContextMenu.Items.Add("Remove", Properties.Resources.Remove_16, Remove_Click);
            this.ContextMenuStrip = testGroupContextMenu;
        }

        public override void BindChildren()
        {
            Benchmark.TestGroup testGroup = (Benchmark.TestGroup)BenchmarkObject;

            this.Nodes.Clear();

            configurationsNode = new FolderTreeNode(BenchmarkTreeView);
            configurationsNode.Text = "Configurations";
            configurationsNode.ImageKey = "Folder";
            configurationsNode.SelectedImageKey = "Folder";
            BindCollection<Benchmark.Configuration>(configurationsNode, testGroup.Configurations);
            this.Nodes.Add(configurationsNode);

            testsNode = new FolderTreeNode(BenchmarkTreeView);
            testsNode.Text = "Tests";
            testsNode.ImageKey = "Folder";
            testsNode.SelectedImageKey = "Folder";
            BindCollection<Benchmark.Test>(testsNode, testGroup.Tests);
            this.Nodes.Add(testsNode);

            configurationsContextMenu = new ContextMenuStrip();
            configurationsContextMenu.Items.Add("Add", Properties.Resources.Add_16, AddConfiguration_Click);
            configurationsNode.ContextMenuStrip = configurationsContextMenu;

            testsContextMenu = new ContextMenuStrip();
            testsContextMenu.Items.Add("Add", Properties.Resources.Add_16, AddTest_Click);
            testsContextMenu.Items.Add(new ToolStripSeparator());
            testsContextMenu.Items.Add("Activate all tests in group", Properties.Resources.CheckAll_16, ActivateAllTests_Click);
            testsContextMenu.Items.Add("Deactivate all tests in group", Properties.Resources.UncheckAll_16, DeactivateAllTests_Click);

            testsNode.ContextMenuStrip = testsContextMenu;

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

        private void Remove_Click(object sender, EventArgs e)
        {
            Benchmark.TestGroup testGroup = (Benchmark.TestGroup)BenchmarkObject;
            testGroup.Benchmark.TestGroups.Remove(testGroup);
        }

        private void AddConfiguration_Click(object sender, EventArgs e)
        {
            Benchmark.TestGroup testGroup = (Benchmark.TestGroup)BenchmarkObject;
            Benchmark.Configuration configuration = new Benchmark.Configuration(testGroup);
            configuration.Name = Helpers.GetNewName(testGroup.Configurations.Select(c => c.Name), "new configuration", NumeralStyle.Guess);
            configuration.Number = Helpers.GetNewName(testGroup.Configurations.Select(c => c.Number), null, NumeralStyle.AlphabeticUpper);
            testGroup.Configurations.Add(configuration);

            TreeNode newNode = BenchmarkTreeView.GetTreeNode(configuration);
            if (newNode != null)
            {
                BenchmarkTreeView.TreeView.SelectedNode = newNode;
                newNode.BeginEdit();
            }
        }

        private void AddTest_Click(object sender, EventArgs e)
        {
            Benchmark.TestGroup testGroup = (Benchmark.TestGroup)BenchmarkObject;
            Benchmark.PlanEquivalenceTest planEquivalenceTest =
                new Benchmark.PlanEquivalenceTest(testGroup);
            planEquivalenceTest.Name = Helpers.GetNewName(testGroup.Tests.Select(t => t.Name), "new test", NumeralStyle.Guess);
            planEquivalenceTest.Number = Helpers.GetNewName(testGroup.Tests.Select(t => t.Number), null, NumeralStyle.Arabic);
            testGroup.Tests.Add(planEquivalenceTest);

            TreeNode newNode = BenchmarkTreeView.GetTreeNode(planEquivalenceTest);
            if (newNode != null)
            {
                BenchmarkTreeView.TreeView.SelectedNode = newNode;
                newNode.BeginEdit();
            }
        }

        private void ActivateAllTests_Click(object sender, EventArgs e)
        {
            Benchmark.TestGroup testGroup = (Benchmark.TestGroup)BenchmarkObject;
            foreach (Benchmark.Test test in testGroup.Tests)
            {
                test.Active = true;
            }
        }

        private void DeactivateAllTests_Click(object sender, EventArgs e)
        {
            Benchmark.TestGroup testGroup = (Benchmark.TestGroup)BenchmarkObject;
            foreach (Benchmark.Test test in testGroup.Tests)
            {
                test.Active = false;
            }
        }

        public override bool IsLabelEditable()
        {
            return true;
        }
    }
}
