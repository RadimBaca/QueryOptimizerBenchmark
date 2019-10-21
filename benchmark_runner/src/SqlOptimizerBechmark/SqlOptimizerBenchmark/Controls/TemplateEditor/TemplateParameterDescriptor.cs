using SqlOptimizerBenchmark.Benchmark;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Controls.TemplateEditor
{
    public class TemplateParameterDescriptor: PropertyDescriptor
    {
        public TemplateParameterDescriptor(string name)
            : base(name, new Attribute[] { })

        {
        }

        private Parameter FindParameter(PlanEquivalenceTest planEquivalenceTest, string parameterName)
        {
            return planEquivalenceTest.Parameters.Where(p => p.Name == parameterName).FirstOrDefault();
        }

        private ParameterValue FindValue(PlanEquivalenceTest planEquivalenceTest, int templateId, int parameterId)
        {
            return planEquivalenceTest.ParameterValues.Where(pv => pv.TemplateId == templateId && pv.ParameterId == parameterId).FirstOrDefault();
        }

        public override object GetValue(object component)
        {
            Template template = (Template)component;
            PlanEquivalenceTest planEquivalenceTest = template.PlanEquivalenceTest;
            string parameterName = Name;

            Parameter parameter = FindParameter(planEquivalenceTest, parameterName);
            if (parameter != null)
            {
                ParameterValue parameterValue = FindValue(planEquivalenceTest, template.Id, parameter.Id);
                if (parameterValue != null)
                {
                    return parameterValue.Value;
                }
            }

            return null;
        }

        public override void SetValue(object component, object value)
        {
            Template template = (Template)component;
            PlanEquivalenceTest planEquivalenceTest = template.PlanEquivalenceTest;
            string parameterName = Name;

            Parameter parameter = FindParameter(planEquivalenceTest, parameterName);
            if (parameter != null)
            {
                ParameterValue parameterValue = FindValue(planEquivalenceTest, template.Id, parameter.Id);
                if (parameterValue != null)
                {
                    parameterValue.Value = Convert.ToString(value);
                }
            }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }
        
        public override void ResetValue(object component)
        {
        }

        public override Type ComponentType
        {
            get => typeof(Template);
        }

        public override bool IsReadOnly
        {
            get => false;
        }

        public override Type PropertyType
        {
            get => typeof(string);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
