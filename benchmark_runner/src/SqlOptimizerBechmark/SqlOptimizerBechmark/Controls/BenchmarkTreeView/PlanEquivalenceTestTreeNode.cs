using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.BenchmarkTreeView
{
    public class PlanEquivalenceTestTreeNode : BenchmarkObjectTreeNode
    {
        private ContextMenuStrip planEquivalenceTestContextMenu;
        private ToolStripItem itmActivate;

        public PlanEquivalenceTestTreeNode(Benchmark.PlanEquivalenceTest planEquivalenceTest, BenchmarkTreeView benchmarkTreeView)
            : base(planEquivalenceTest, benchmarkTreeView)
        {
        }

        public override void BindNode()
        {
            BindNamedObjectText();

            UpdateImageKey();

            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;

            planEquivalenceTestContextMenu = new ContextMenuStrip();
            planEquivalenceTestContextMenu.Items.Add("Rename", Properties.Resources.Rename_16, Rename_Click);
            planEquivalenceTestContextMenu.Items.Add("Add variant", Properties.Resources.Add_16, AddQueryVariant_Click);
            planEquivalenceTestContextMenu.Items.Add("Remove", Properties.Resources.Remove_16, Remove_Click);
            planEquivalenceTestContextMenu.Items.Add(new ToolStripSeparator());
            itmActivate = planEquivalenceTestContextMenu.Items.Add("Activate", null, Activate_Click);
            UpdateActivateMenuItem();

            this.ContextMenuStrip = planEquivalenceTestContextMenu;

            planEquivalenceTest.PropertyChanged += PlanEquivalenceTest_PropertyChanged;
            planEquivalenceTest.Variants.CollectionChanged += Variants_CollectionChanged;
        }

        private void Variants_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!ChildrenBound)
            {
                BindChildren();
            }
        }

        public override void BindChildren()
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            this.Nodes.Clear();

            BindCollection<Benchmark.QueryVariant>(this, planEquivalenceTest.Variants);
            ChildrenBound = true;
        }

        public override bool HasChildren()
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            return planEquivalenceTest.Variants.Count > 0;
        }

        private void UpdateActivateMenuItem()
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            if (planEquivalenceTest.Active)
            {
                itmActivate.Text = "Deactivate";
            }
            else
            {
                itmActivate.Text = "Activate";
            }
        }

        private void UpdateImageKey()
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            if (planEquivalenceTest.Active)
            {
                this.ImageKey = "Test";
                this.SelectedImageKey = "Test";
            }
            else
            {
                this.ImageKey = "TestInactive";
                this.SelectedImageKey = "TestInactive";
            }
        }

        private void PlanEquivalenceTest_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Active")
            {
                UpdateImageKey();
                UpdateActivateMenuItem();
            }
        }

        private void Activate_Click(object sender, EventArgs e)
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            planEquivalenceTest.Active = !planEquivalenceTest.Active;
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            this.BeginEdit();
        }

        private void AddQueryVariant_Click(object sender, EventArgs e)
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            Benchmark.QueryVariant queryVariant = new Benchmark.QueryVariant(planEquivalenceTest);
            queryVariant.Name = Helpers.GuessNewName(planEquivalenceTest.Variants.Select(v => v.Name), "new variant");
            planEquivalenceTest.Variants.Add(queryVariant);

            TreeNode newNode = BenchmarkTreeView.GetTreeNode(queryVariant);
            if (newNode != null)
            {
                BenchmarkTreeView.TreeView.SelectedNode = newNode;
                newNode.BeginEdit();
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            planEquivalenceTest.TestGroup.Tests.Remove(planEquivalenceTest);
        }

        public override bool IsLabelEditable()
        {
            return true;
        }

        public override void AfterLabelEdit(string newLabel)
        {
            Benchmark.PlanEquivalenceTest planEquivalenceTest = (Benchmark.PlanEquivalenceTest)BenchmarkObject;
            planEquivalenceTest.Name = newLabel;
        }
    }
}
