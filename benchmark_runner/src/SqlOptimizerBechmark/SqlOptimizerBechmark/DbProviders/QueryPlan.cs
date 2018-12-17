using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.DbProviders
{
    public class QueryPlan
    {
        private QueryPlanNode root;

        public QueryPlanNode Root
        {
            get => root;
            set => root = value;
        }

        public void SaveToXml(XElement element)
        {
            if (root != null)
            {
                XElement eRootNode = new XElement("node");
                root.SaveToXml(eRootNode);
                element.Add(eRootNode);
            }
        }

        public void LoadFromXml(XElement element)
        {
            XElement eRootNode = element.Element("node");
            if (eRootNode != null)
            {
                root = new QueryPlanNode();
                root.LoadFromXml(eRootNode);
            }
        }

        public override string ToString()
        {
            if (root == null)
            {
                return base.ToString();
            }
            else
            {
                return root.ToString();
            }
        }

        public override bool Equals(object obj)
        {
            QueryPlan other = obj as QueryPlan;
            if (other == null)
            {
                return false;
            }

            if (this.root == null && other.root == null)
            {
                return true;
            }
            else if (this.root != null && other.root != null)
            {
                return this.root.Equals(other.root);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return root.GetHashCode();
            }
        }
    }

    public class QueryPlanNode
    {
        private QueryPlanNode parent;
        private IList<QueryPlanNode> childNodes = new List<QueryPlanNode>();

        private string opName;
        private double estimatedRows;
        private double estimatedCost;
        private int actualRows;
        private TimeSpan actualTime;

        public QueryPlanNode Parent
        {
            get => parent;
            set => parent = value;
        }

        public IList<QueryPlanNode> ChildNodes
        {
            get => childNodes;
        }

        public string OpName
        {
            get => opName;
            set => opName = value;
        }

        public double EstimatedRows
        {
            get => estimatedRows;
            set => estimatedRows = value;
        }

        public int ActualRows
        {
            get => actualRows;
            set => actualRows = value;
        }

        public double EstimatedCost
        {
            get => estimatedCost;
            set => estimatedCost = value;
        }

        public TimeSpan ActualTime
        {
            get => actualTime;
            set => actualTime = value;
        }

        public void SaveToXml(XElement element)
        {
            element.Add(new XAttribute("op_name", opName));
            element.Add(new XAttribute("estimated_rows", Convert.ToString(estimatedRows, System.Globalization.CultureInfo.InvariantCulture)));
            element.Add(new XAttribute("estimated_cost", Convert.ToString(estimatedCost, System.Globalization.CultureInfo.InvariantCulture)));
            element.Add(new XAttribute("actual_rows", actualRows));
            element.Add(new XAttribute("actual_time", Convert.ToString(actualTime.TotalSeconds, System.Globalization.CultureInfo.InvariantCulture)));

            XElement eChildNodes = new XElement("child_nodes");
            foreach (QueryPlanNode childNode in childNodes)
            {
                XElement eChildNode = new XElement("node");
                childNode.SaveToXml(eChildNode);
                eChildNodes.Add(eChildNode);
            }

            element.Add(eChildNodes);
        }

        public void LoadFromXml(XElement element)
        {
            opName = Convert.ToString(element.Attribute("op_name").Value);
            estimatedRows = Convert.ToDouble(element.Attribute("estimated_rows").Value, System.Globalization.CultureInfo.InvariantCulture);
            estimatedCost = Convert.ToDouble(element.Attribute("estimated_cost").Value, System.Globalization.CultureInfo.InvariantCulture);
            actualRows = Convert.ToInt32(element.Attribute("actual_rows").Value);
            actualTime = TimeSpan.FromSeconds(Convert.ToDouble(element.Attribute("actual_time").Value, System.Globalization.CultureInfo.InvariantCulture));

            childNodes.Clear();
            XElement eChildNodes = element.Element("child_nodes");
            foreach (XElement eChildNode in eChildNodes.Elements("node"))
            {
                QueryPlanNode childNode = new QueryPlanNode();
                childNode.LoadFromXml(eChildNode);
                childNodes.Add(childNode);
                childNode.Parent = this;
            }
        }

        public void Write(int level, TextWriter writer)
        {
            string prefix = new string(' ', 2 * level);
            string line = prefix + string.Format("|-- {0} (estimated rows: {1}, estimated cost: {2}, actual rows: {3}, actual elapsed time: {4})",
                opName, estimatedRows, estimatedCost, actualRows, actualTime);

            writer.WriteLine(line);
            foreach (QueryPlanNode childNode in childNodes)
            {
                childNode.Write(level + 1, writer);
            }
        }

        public override string ToString()
        {
            StringWriter writer = new StringWriter();
            Write(0, writer);
            return writer.ToString();
        }

        public override bool Equals(object obj)
        {
            QueryPlanNode other = obj as QueryPlanNode;
            if (other == null)
            {
                return false;
            }

            if (this.opName != other.opName ||
                this.childNodes.Count != other.childNodes.Count)
            {
                return false;
            }

            for (int i = 0; i < this.childNodes.Count; i++)
            {
                if (!this.childNodes[i].Equals(other.childNodes[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int ret = opName.GetHashCode();

            foreach (QueryPlanNode childNode in childNodes)
            {
                ret &= childNode.GetHashCode();
            }

            return ret;
        }
    }
}
