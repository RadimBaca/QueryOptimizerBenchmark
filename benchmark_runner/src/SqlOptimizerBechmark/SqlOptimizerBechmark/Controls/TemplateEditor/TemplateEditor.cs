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

namespace SqlOptimizerBechmark.Controls.TemplateEditor
{
    public partial class TemplateEditor : UserControl
    {
        private PlanEquivalenceTest planEquivalenceTest;
        private TemplateBindingList bindingList;

        public PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
            set
            {
                planEquivalenceTest = value;
                PrepareGrid();
            }
        }

        public Template SelectedTemplate
        {
            get => GetSelectedTemplate();
        }

        public Parameter SelectedParameter
        {
            get => GetSelectedParameter();
        }

        public event EventHandler SelectionChanged;
        
        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }

        public TemplateEditor()
        {
            InitializeComponent();
        }

        private void PrepareGrid()
        {
            if (planEquivalenceTest != null)
            {
                bindingList = new TemplateBindingList(planEquivalenceTest);
                gridTemplates.DataSource = null;
                gridTemplates.Columns.Clear();
                gridTemplates.DataSource = bindingList;
                gridTemplates.AllowUserToAddRows = true;

                gridTemplates.Columns[0].Width = 50;
                gridTemplates.Columns[0].HeaderText = "Number";
                gridTemplates.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(0xFF, 0xE0, 0xFC, 0xE9);

                foreach (DataGridViewColumn gridColumn in gridTemplates.Columns)
                {
                    gridColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else
            {
                gridTemplates.Rows.Clear();
                gridTemplates.Columns.Clear();
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            Parameter selectedParameter = GetSelectedParameter();
            btnRemoveParameter.Enabled = selectedParameter != null;
            btnRenameParameter.Enabled = selectedParameter != null;

            Template selectedTemplate = GetSelectedTemplate();
            btnRemoveTemplate.Enabled = selectedTemplate != null;

            if (selectedTemplate != null)
            {
                int index = bindingList.IndexOf(selectedTemplate);
                btnMoveTemplateUp.Enabled = index > 0;
                btnMoveTemplateDown.Enabled = index < bindingList.Count - 1;
            }
            else
            {
                btnMoveTemplateUp.Enabled = false;
                btnMoveTemplateDown.Enabled = false;
            }
        }

        private Parameter GetSelectedParameter()
        {
            if (gridTemplates.CurrentCell != null)
            {
                DataGridViewColumn column = gridTemplates.Columns[gridTemplates.CurrentCell.ColumnIndex];
                string parameterName = column.DataPropertyName;
                return planEquivalenceTest.Parameters.Where(p => p.Name == parameterName).FirstOrDefault();
            }
            return null;
        }

        private Template GetSelectedTemplate()
        {
            if (gridTemplates.SelectedRows.Count == 1)
            {
                DataGridViewRow gridRow = gridTemplates.SelectedRows[0];
                if (gridRow.DataBoundItem is Template ret)
                {
                    return ret;
                }
            }

            if (gridTemplates.CurrentRow != null)
            {
                if (gridTemplates.CurrentRow.DataBoundItem is Template ret)
                {
                    return ret;
                }
            }

            if (gridTemplates.CurrentCell != null)
            {
                DataGridViewRow gridRow = gridTemplates.Rows[gridTemplates.CurrentCell.RowIndex];
                if (gridRow.DataBoundItem is Template ret)
                {
                    return ret;
                }
            }

            return null;
        }

        private void AddParameter()
        {
            Parameter parameter = new Parameter(planEquivalenceTest);
            ParameterDialog dialog = new ParameterDialog();
            dialog.Parameter = parameter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                planEquivalenceTest.Parameters.Add(parameter);
                foreach (Template template in planEquivalenceTest.Templates)
                {
                    ParameterValue parameterValue = new ParameterValue(planEquivalenceTest);
                    parameterValue.ParameterId = parameter.Id;
                    parameterValue.TemplateId = template.Id;
                    planEquivalenceTest.ParameterValues.Add(parameterValue);
                }

                PrepareGrid();
            }
        }
        
        private void RemoveParameter()
        {
            Parameter parameter = GetSelectedParameter();
            if (parameter != null)
            {
                // Check whether the parameter is not used in a statement.
                bool used = false;
                List<string> statements = new List<string>();
                foreach (QueryVariant variant in planEquivalenceTest.Variants)
                {
                    statements.Add(variant.DefaultStatement.CommandText);
                    foreach (SpecificStatement specificStatement in variant.SpecificStatements)
                    {
                        statements.Add(specificStatement.CommandText);
                    }
                }
                foreach (string statement in statements)
                {
                    if (statement.Contains(parameter.Name))
                    {
                        used = true;
                        break;
                    }
                }
                if (used)
                {
                    DialogResult res = MessageBox.Show("The parameter is used in a statement. Do you really want to remove it?", Application.ProductName,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (res != DialogResult.Yes)
                    {
                        return;
                    }
                }

                planEquivalenceTest.Parameters.Remove(parameter);
                List<ParameterValue> valuesToRemove = new List<ParameterValue>();
                foreach (ParameterValue parameterValue in planEquivalenceTest.ParameterValues)
                {
                    if (parameterValue.ParameterId == parameter.Id)
                    {
                        valuesToRemove.Add(parameterValue);
                    }
                }
                foreach (ParameterValue parameterValue in valuesToRemove)
                {
                    planEquivalenceTest.ParameterValues.Remove(parameterValue);
                }

                PrepareGrid();
            }
        }

        private void EditParameter()
        {
            Parameter parameter = GetSelectedParameter();
            if (parameter != null)
            {
                ParameterDialog dialog = new ParameterDialog();
                dialog.Parameter = parameter;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PrepareGrid();
                }
            }
        }

        private void AddTemplate()
        {
            gridTemplates.CurrentCell = gridTemplates[0, gridTemplates.NewRowIndex];
            gridTemplates.BeginEdit(true);
        }

        private void RemoveTemplate()
        {
            Template selectedTemplate = GetSelectedTemplate();
            if (selectedTemplate != null)
            {
                bindingList.Remove(selectedTemplate);
            }
        }

        private void MoveTemplateUp()
        {
            Template selectedTemplate = GetSelectedTemplate();
            int index = bindingList.IndexOf(selectedTemplate);
            if (index > 0)
            {
                int newIndex = index - 1;
                Template t = bindingList[newIndex];
                bindingList[newIndex] = bindingList[index];
                bindingList[index] = t;

                gridTemplates.ClearSelection();
                gridTemplates.Rows[newIndex].Selected = true;
            }
        }

        private void MoveTemplateDown()
        {
            Template selectedTemplate = GetSelectedTemplate();
            int index = bindingList.IndexOf(selectedTemplate);
            if (index < bindingList.Count - 1)
            {
                int newIndex = index + 1;
                Template t = bindingList[newIndex];
                bindingList[newIndex] = bindingList[index];
                bindingList[index] = t;

                gridTemplates.ClearSelection();
                gridTemplates.Rows[newIndex].Selected = true;
            }
        }


        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            AddParameter();
        }

        private void btnRemoveParameter_Click(object sender, EventArgs e)
        {
            RemoveParameter();
        }

        private void btnRenameParameter_Click(object sender, EventArgs e)
        {
            EditParameter();
        }

        private void gridTemplates_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUI();
            OnSelectionChanged();
        }

        private void gridTemplates_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateUI();
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            AddTemplate();
        }

        private void btnRemoveTemplate_Click(object sender, EventArgs e)
        {
            RemoveTemplate();
        }

        private void btnMoveTemplateUp_Click(object sender, EventArgs e)
        {
            MoveTemplateUp();
        }

        private void btnMoveTemplateDown_Click(object sender, EventArgs e)
        {
            MoveTemplateDown();
        }

        private void gridTemplates_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn gridColumn = gridTemplates.Columns[e.ColumnIndex];
                Parameter parameter = planEquivalenceTest.Parameters.Where(p => p.Name == gridColumn.DataPropertyName).FirstOrDefault();
                if (parameter != null)
                {
                    e.PaintBackground(e.ClipBounds, true);
                    string str = Helpers.GetParamStr(parameter.Name);
                    TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    TextRenderer.DrawText(e.Graphics, str, e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, flags);
                    e.Handled = true;
                }
            }
        }
    }
}
