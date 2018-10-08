using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class Statement : BenchmarkObject
    {
        private BenchmarkObject parentObject;
        private string commandText = string.Empty;
        
        public override IBenchmarkObject ParentObject => parentObject;

        public string CommandText
        {
            get => commandText;
            set
            {
                if (commandText != value)
                {
                    commandText = value;
                    OnPropertyChanged("CommandText");
                }
            }
        }

        public Statement(BenchmarkObject parentObject)
        {
            this.parentObject = parentObject;
        }
        
        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteString("command_text", commandText);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadString("command_text", ref commandText);
        }
    }
}
