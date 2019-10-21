using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkTreeView
{
    public class QueryVariantTreeNode : BenchmarkObjectTreeNode
    {
        private ContextMenuStrip queryVariantContextMenu;

        public QueryVariantTreeNode(Benchmark.QueryVariant queryVariant, BenchmarkTreeView benchmarkTreeView)
            : base(queryVariant, benchmarkTreeView)
        {
        }

        public override void BindNode()
        {
            BindNamedObjectText();

            this.ImageKey = "Variant";
            this.SelectedImageKey = "Variant";

            queryVariantContextMenu = new ContextMenuStrip();
            queryVariantContextMenu.Items.Add("Rename", Properties.Resources.Rename_16, Rename_Click);
            queryVariantContextMenu.Items.Add("Remove", Properties.Resources.Remove_16, Remove_Click);
            this.ContextMenuStrip = queryVariantContextMenu;
        }

        public override void BindChildren()
        {

            ChildrenBound = true;
        }

        public override bool HasChildren()
        {
            return false;
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            this.BeginEdit();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Benchmark.QueryVariant queryVariant = (Benchmark.QueryVariant)BenchmarkObject;
            queryVariant.PlanEquivalenceTest.Variants.Remove(queryVariant);
        }

        public override bool IsLabelEditable()
        {
            return true;
        }
    }
}
