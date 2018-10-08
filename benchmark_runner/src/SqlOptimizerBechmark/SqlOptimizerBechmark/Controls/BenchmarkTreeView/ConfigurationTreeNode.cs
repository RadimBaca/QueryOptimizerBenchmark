using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.BenchmarkTreeView
{
    public class ConfigurationTreeNode : BenchmarkObjectTreeNode
    {
        private ScriptTreeNode initScriptNode;
        private ScriptTreeNode cleanUpScriptNode;

        private ContextMenuStrip configurationContextMenu;

        public ConfigurationTreeNode(Benchmark.Configuration configuration, BenchmarkTreeView benchmarkTreeView)
            : base(configuration, benchmarkTreeView)
        {
        }

        public override void BindNode()
        {
            BindNamedObjectText();
            this.ImageKey = "Configuration";
            this.SelectedImageKey = "Configuration";

            configurationContextMenu = new ContextMenuStrip();
            configurationContextMenu.Items.Add("Rename", Properties.Resources.Rename_16, Rename_Click);
            configurationContextMenu.Items.Add("Remove", Properties.Resources.Remove_16, Remove_Click);
            this.ContextMenuStrip = configurationContextMenu;
        }

        public override void BindChildren()
        {
            this.Nodes.Clear();

            Benchmark.Configuration configuration = (Benchmark.Configuration)BenchmarkObject;

            initScriptNode = new ScriptTreeNode(configuration.InitScript, BenchmarkTreeView);
            initScriptNode.Text = "Init script";
            initScriptNode.ImageKey = "InitScript";
            initScriptNode.SelectedImageKey = "InitScript";
            this.Nodes.Add(initScriptNode);

            cleanUpScriptNode = new ScriptTreeNode(configuration.CleanUpScript, BenchmarkTreeView);
            cleanUpScriptNode.Text = "Clean-up script";
            cleanUpScriptNode.ImageKey = "CleanUpScript";
            cleanUpScriptNode.SelectedImageKey = "CleanUpScript";
            this.Nodes.Add(cleanUpScriptNode);
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
            Benchmark.Configuration configuration = (Benchmark.Configuration)BenchmarkObject;
            configuration.TestGroup.Configurations.Remove(configuration);
        }

        public override bool IsLabelEditable()
        {
            return true;
        }

        public override void AfterLabelEdit(string newLabel)
        {
            Benchmark.Configuration configuration = (Benchmark.Configuration)BenchmarkObject;
            configuration.Name = newLabel;
        }
    }
}
