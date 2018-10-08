using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.Benchmark
{
    public abstract class BenchmarkObject : IBenchmarkObject
    {
        public abstract IBenchmarkObject ParentObject { get; }

        public virtual Benchmark Owner => ParentObject.Owner;

        public virtual IEnumerable<IBenchmarkObject> ChildObjects => Enumerable.Empty<IBenchmarkObject>();


        public event PropertyChangedEventHandler PropertyChanged;
                
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            NotifyChange();
        }

        public event EventHandler Changed;

        protected virtual void OnChanged()
        {
            if (Changed != null)
            {
                Changed(this, EventArgs.Empty);
            }
        }

        public abstract void SaveToXml(BenchmarkXmlSerializer serializer);

        public abstract void LoadFromXml(BenchmarkXmlSerializer serializer);

        public void NotifyChange()
        {
            OnChanged();
            if (ParentObject != null)
            {
                ParentObject.NotifyChange();
            }
        }

        public virtual bool Contains(IBenchmarkObject benchmarkObject)
        {
            Stack<IBenchmarkObject> stack = new Stack<IBenchmarkObject>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                IBenchmarkObject obj = stack.Pop();
                if (obj == benchmarkObject)
                {
                    return true;
                }
                foreach (IBenchmarkObject child in obj.ChildObjects)
                {
                    stack.Push(child);
                }
            }
            return false;
        }
    }
}
