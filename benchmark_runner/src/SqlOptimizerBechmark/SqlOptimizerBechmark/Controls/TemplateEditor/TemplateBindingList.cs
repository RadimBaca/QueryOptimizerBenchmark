using SqlOptimizerBechmark.Benchmark;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls.TemplateEditor
{
    public class TemplateBindingList: BindingList<Template>, ITypedList
    {
        private PlanEquivalenceTest planEquivalenceTest;

        public PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
        }

        public TemplateBindingList(PlanEquivalenceTest planEquivalenceTest)
            : base(planEquivalenceTest.Templates)
        {
            this.planEquivalenceTest = planEquivalenceTest;

            this.AddingNew += TemplateBindingList_AddingNew;
        }

        private void TemplateBindingList_AddingNew(object sender, AddingNewEventArgs e)
        {
            Template template = new Template(planEquivalenceTest);
            template.Number = Helpers.GetNumber(planEquivalenceTest.Templates.Count + 1, NumeralStyle.RomanLower);

            // Prepare value for each parameter.
            foreach (Parameter parameter in planEquivalenceTest.Parameters)
            {
                ParameterValue parameterValue = new ParameterValue(planEquivalenceTest);
                parameterValue.ParameterId = parameter.Id;
                parameterValue.TemplateId = template.Id;
                planEquivalenceTest.ParameterValues.Add(parameterValue);
            }

            e.NewObject = template;
        }

        
        protected override void RemoveItem(int index)
        {
            Template template = this[index];

            // Delete all values for the template.
            List<ParameterValue> valuesToRemove = new List<ParameterValue>();
            foreach (ParameterValue parameterValue in planEquivalenceTest.ParameterValues)
            {
                if (parameterValue.TemplateId == template.Id)
                {
                    valuesToRemove.Add(parameterValue);
                }
            }
            foreach (ParameterValue parameterValue in valuesToRemove)
            {
                planEquivalenceTest.ParameterValues.Remove(parameterValue);
            }

            base.RemoveItem(index);
        }


        protected override void ClearItems()
        {
            planEquivalenceTest.ParameterValues.Clear();
            base.ClearItems();
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Templates";
        }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            List<PropertyDescriptor> properties = new List<PropertyDescriptor>();
            properties.Add(new TemplateNumberDescriptor());
            properties.Add(new TemplateResultSizeDescriptor());
            foreach (Parameter parameter in planEquivalenceTest.Parameters)
            {
                TemplateParameterDescriptor pd = new TemplateParameterDescriptor(parameter.Name);
                properties.Add(pd);
            }
            return new PropertyDescriptorCollection(properties.ToArray());
        }
    }
}
