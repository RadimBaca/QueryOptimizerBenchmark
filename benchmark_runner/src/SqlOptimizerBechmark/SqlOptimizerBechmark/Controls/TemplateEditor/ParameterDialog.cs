using SqlOptimizerBechmark.Benchmark;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.TemplateEditor
{
    public partial class ParameterDialog : Form
    {
        private Parameter parameter;

        public Parameter Parameter
        {
            get => parameter;
            set
            {
                parameter = value;
                UpdateControls();
            }
        }

        public ParameterDialog()
        {
            InitializeComponent();
        }

        private void ParameterDialog_Shown(object sender, EventArgs e)
        {
            txtParameterName.SelectAll();
            txtParameterName.Focus();
        }

        private void UpdateControls()
        {
            txtParameterName.Text = parameter.Name;
        }

        /// <summary>
        /// Checks whether a string can be a name of a parameter.
        /// It must start with a letter and it may cosists of letters and digits.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool CheckParameterName(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (i == 0)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool UpdateParameter()
        {
            if (string.IsNullOrWhiteSpace(txtParameterName.Text))
            {
                MessageBox.Show(TemplateEditorResources.MsgParameterNameMissing, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (Parameter parameter in this.parameter.PlanEquivalenceTest.Parameters)
            {
                if (parameter != this.parameter &&
                    string.Compare(parameter.Name, txtParameterName.Text, true) == 0)
                {
                    MessageBox.Show(TemplateEditorResources.MsgParameterNameNotUnique, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (!CheckParameterName(txtParameterName.Text))
            {
                MessageBox.Show(TemplateEditorResources.MsgInvalidParameterName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.parameter.Name = txtParameterName.Text;

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (UpdateParameter())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
