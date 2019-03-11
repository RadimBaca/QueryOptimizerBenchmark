using System.Collections.Generic;
using System.ComponentModel;

namespace SqlOptimizerBechmark.Benchmark
{
    public interface IBenchmarkObject: INotifyPropertyChanged
    {
        Benchmark Owner { get; }
        IBenchmarkObject ParentObject { get; }
        IEnumerable<IBenchmarkObject> ChildObjects { get; }
        bool Contains(IBenchmarkObject benchmarkObject);
        void LoadFromXml(BenchmarkXmlSerializer serializer);
        void SaveToXml(BenchmarkXmlSerializer serializer);
        void NotifyChange();

        DbTableInfo GetTableInfo();
    }
}