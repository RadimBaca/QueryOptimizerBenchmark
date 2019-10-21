using SqlOptimizerBenchmark.Benchmark;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Controls.TemplateEditor
{
    public class TemplateNumberDescriptor : PropertyDescriptor
    {
        public TemplateNumberDescriptor()
            : base("TemplateNumberDescriptor", new Attribute[] { })

        {
        }

        public override object GetValue(object component)
        {
            Template template = (Template)component;
            return template.Number;
        }

        public override void SetValue(object component, object value)
        {
            Template template = (Template)component;
            template.Number = Convert.ToString(value);
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
