using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkObjectControls
{
    public partial class ScriptDetail : BenchmarkObjectDetail
    {
        private bool ready = true;

        public ScriptDetail()
        {
            InitializeComponent();
        }

        private Benchmark.Script Script
        {
            get => (Benchmark.Script)BenchmarkObject;
        }

        protected override void BindControls()
        {
            if (Script == null)
            {
                return;
            }

            ready = false;

            dbProviderComboBox.LoadProviders();
            
            DbProviders.DbProvider dbProvider = Script.Owner.ConnectionSettings.DbProvider;
            if (dbProvider != null && Script.HasSpecificStatementList(dbProvider.Name))
            {
                dbProviderComboBox.SelectedDbProvider = dbProvider;
            }
            else
            {
                dbProviderComboBox.SelectedDbProvider = null;
            }

            BindStatementList();

            ready = true;
        }

        private void BindStatementList()
        {
            DbProviders.DbProvider dbProvider = dbProviderComboBox.SelectedDbProvider;
            if (dbProvider == null)
            {
                statementListEditor.StatementList = Script.DefaultStatementList;
                statementListEditor.UpdateText();
                statementListEditor.Enabled = true;
                btnChangeImplementation.Enabled = false;
            }
            else
            {
                if (Script.HasSpecificStatementList(dbProvider.Name))
                {
                    statementListEditor.StatementList = Script.GetStatementList(dbProvider.Name);
                    statementListEditor.UpdateText();
                    statementListEditor.Enabled = true;

                    btnChangeImplementation.Text = "Remove";
                    btnChangeImplementation.Enabled = true;
                }
                else
                {
                    statementListEditor.StatementList = null;
                    statementListEditor.UpdateText();
                    statementListEditor.Enabled = false;

                    btnChangeImplementation.Text = "Implement";
                    btnChangeImplementation.Enabled = true;
                }
            }
        }

        private void CreateImplementation(DbProviders.DbProvider dbProvider)
        {
            Benchmark.SpecificStatementList specificStatementList = new Benchmark.SpecificStatementList(Script);
            specificStatementList.ProviderName = dbProvider.Name;
            Script.SpecificStatementLists.Add(specificStatementList);
            BindStatementList();
            dbProviderComboBox.Invalidate();
        }

        private void RemoveImplementation(DbProviders.DbProvider dbProvider)
        {
            Benchmark.StatementList statementList = Script.GetStatementList(dbProvider.Name);
            if (statementList is Benchmark.SpecificStatementList specificStatementList)
            {
                Script.SpecificStatementLists.Remove(specificStatementList);
            }
            dbProviderComboBox.SelectedDbProvider = null;
        }

        protected override void UpdateUI()
        {
            if (Script == null)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }
        }

        private void dbProviderComboBox_ProviderImplemented(object sender, DbProviderComboBox.ProviderImplementedEventArgs e)
        {
            if (Script != null)
            {
                if (e.DbProvider != null)
                {
                    e.IsImplemented = Script.HasSpecificStatementList(e.DbProvider.Name);
                }
                else
                {
                    // Default implementation.
                    e.IsImplemented = true;
                }
            }
        }

        private void dbProviderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                BindStatementList();
            }
        }

        private void btnChangeImplementation_Click(object sender, EventArgs e)
        {
            DbProviders.DbProvider dbProvider = dbProviderComboBox.SelectedDbProvider;
            if (dbProvider != null)
            {
                if (Script.HasSpecificStatementList(dbProvider.Name))
                {
                    RemoveImplementation(dbProvider);
                }
                else
                {
                    CreateImplementation(dbProvider);
                }
            }
        }
    }
}
