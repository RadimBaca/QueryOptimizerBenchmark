using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.Benchmark
{
    public class BenchmarkXmlSerializer
    {
        private const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        private XDocument document = new XDocument();
        private XElement currentElement;

        public BenchmarkXmlSerializer()
        {
        }

        public void WriteString(string name, string value)
        {
            XElement element = new XElement(name);
            element.Value = value;
            currentElement.Add(element);
        }

        public void WriteInt(string name, int value)
        {
            XElement element = new XElement(name);
            element.Value = Convert.ToString(value);
            currentElement.Add(element);
        }

        public void WriteBool(string name, bool value)
        {
            XElement element = new XElement(name);
            element.Value = Convert.ToString(value);
            currentElement.Add(element);
        }

        public void WriteDouble(string name, double value)
        {
            XElement element = new XElement(name);
            element.Value = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
            currentElement.Add(element);
        }

        public void WriteDateTime(string name, DateTime value)
        {
            XElement element = new XElement(name);
            element.Value = value.ToString(dateTimeFormat);
        }

        public void WriteTimeSpan(string name, TimeSpan value)
        {
            double seconds = value.TotalSeconds;
            WriteDouble(name, seconds);
        }

        public void WriteObject(string name, BenchmarkObject benchmarkObject)
        {
            XElement oldCurrent = currentElement;
            currentElement = new XElement(name);
            benchmarkObject.SaveToXml(this);
            oldCurrent.Add(currentElement);
            currentElement = oldCurrent;
        }

        public void WriteXml(XElement element)
        {
            currentElement.Add(element);
        }

        public void WriteCollection<T>(string collectionName, string itemName, ObservableCollection<T> collection)
            where T : BenchmarkObject
        {
            XElement oldCurrent = currentElement;
            XElement eCollection = new XElement(collectionName);
            foreach (T benchmarkObject in collection)
            {
                XElement eItem = new XElement(itemName);
                currentElement = eItem;
                benchmarkObject.SaveToXml(this);
                eCollection.Add(eItem);
            }
            oldCurrent.Add(eCollection);
            currentElement = oldCurrent;
        }

        public bool ReadString(string name, ref string value)
        {
            XElement element = currentElement.Element(name);
            if (element != null)
            {
                value = element.Value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadInt(string name, ref int value)
        {
            XElement element = currentElement.Element(name);
            if (element != null)
            {
                if (int.TryParse(element.Value, out value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ReadBool(string name, ref bool value)
        {
            XElement element = currentElement.Element(name);
            if (element != null)
            {
                if (bool.TryParse(element.Value, out value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ReadDouble(string name, ref double value)
        {
            XElement element = currentElement.Element(name);
            if (element != null)
            {
                if (double.TryParse(element.Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ReadDateTime(string name, ref DateTime value)
        {
            XElement element = currentElement.Element(name);
            if (element != null)
            {
                if (DateTime.TryParseExact(element.Value, dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ReadTimeSpan(string name, ref TimeSpan value)
        {
            double seconds = 0;
            if (ReadDouble(name, ref seconds))
            {
                value = TimeSpan.FromSeconds(seconds);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadObject(string name, BenchmarkObject benchmarkObject)
        {
            if (currentElement.Element(name) != null)
            {
                XElement oldCurrent = currentElement;
                currentElement = currentElement.Element(name);
                benchmarkObject.LoadFromXml(this);
                currentElement = oldCurrent;
                return true;
            }

            return false;
        }

        public bool ReadCollection<T>(string collectionName, string itemName, ObservableCollection<T> collection, InstantiateBenchmarkObjectDelegate<T> instantiateBenchmarkObject)
            where T: BenchmarkObject
        {
            if (currentElement.Element(collectionName) != null)
            {
                collection.Clear();
                XElement eCollection = currentElement.Element(collectionName);
                foreach (XElement eItem in eCollection.Elements(itemName))
                {
                    XElement oldCurrent = currentElement;
                    currentElement = eItem;
                    T obj = instantiateBenchmarkObject();
                    obj.LoadFromXml(this);
                    collection.Add(obj);
                    currentElement = oldCurrent;
                }
                return true;
            }
            return false;
        }

        public void SaveBenchmark(Benchmark benchmark, string fileName)
        {
            XDocument document = new XDocument();
            XElement root = new XElement("sql_benchmark");
            document.Add(root);

            currentElement = root;
            benchmark.SaveToXml(this);

            document.Save(fileName);
        }

        public void LoadBenchmark(Benchmark benchmark, string fileName)
        {
            XDocument document = XDocument.Load(fileName);
            XElement root = document.Root;

            currentElement = root;
            benchmark.LoadFromXml(this);
        }

        public XElement ReadXml(string name)
        {
            return currentElement.Element(name);
        }
    }

    public delegate T InstantiateBenchmarkObjectDelegate<T>() where T: BenchmarkObject;
}
