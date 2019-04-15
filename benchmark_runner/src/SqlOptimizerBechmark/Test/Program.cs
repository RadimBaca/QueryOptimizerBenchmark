using System;
using System.Collections.Generic;
using System.Data.H2;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SqlOptimizerBechmark.DbProviders;

namespace Test
{
    class Program
    {
        private double ReadCostInfo(JsonReader reader)
        {
            double ret = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return ret;
                }
                if (reader.TokenType == JsonToken.PropertyName &&
                    Convert.ToString(reader.Value) == "query_cost")
                {
                    reader.Read();
                    ret = Convert.ToDouble(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return  ret;
        }

        private QueryPlanNode ReadNode(JsonReader reader, QueryPlanNode parentNode, string parentPropertyName)
        {
            QueryPlanNode ret = new QueryPlanNode();
            ret.OpName = parentPropertyName;

            int level = 1;
            string propertyName = null;

            while (level > 0 && reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    if (propertyName != null)
                    {
                        QueryPlanNode queryPlanNode = ReadNode(reader, ret, propertyName);
                        ret.ChildNodes.Add(queryPlanNode);
                        queryPlanNode.Parent = ret;
                    }
                    else
                    {
                        level++;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    level--;
                }

                if (reader.TokenType == JsonToken.StartArray)
                {
                    if (propertyName != null)
                    {
                        QueryPlanNode queryPlanNode = ReadNode(reader, ret, propertyName);
                        ret.ChildNodes.Add(queryPlanNode);
                        queryPlanNode.Parent = ret;
                    }
                    else
                    {
                        level++;
                    }
                }
                else if (reader.TokenType == JsonToken.EndArray)
                {
                    level--;

                }

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    propertyName = Convert.ToString(reader.Value);


                    if (propertyName == "rows_produced_per_join")
                    {
                        reader.Read();
                        int rows = Convert.ToInt32(reader.Value);
                        ret.EstimatedRows = rows;

                        propertyName = null;
                    }
                    if (propertyName == "cost_info")
                    {
                        ret.EstimatedCost = ReadCostInfo(reader);
                        propertyName = null;
                    }
                    if (propertyName == "access_type")
                    {
                        reader.Read();
                        string accessTypeStr = Convert.ToString(reader.Value);
                        ret.OpName += "_" + accessTypeStr.ToLower();
                        propertyName = null;
                    }

                    // Ignored properties.
                    if (propertyName == "used_columns")
                    {
                        propertyName = null;
                    }
                }
                else
                {
                    propertyName = null;
                }
            }

            return ret;
        }

        private QueryPlanNode ParsePlan(string jsonStr)
        {
            QueryPlanNode ret = null;
            System.IO.StringReader stringReader = new System.IO.StringReader(jsonStr);
            JsonTextReader jsonTextReader = new JsonTextReader(stringReader);
            if (jsonTextReader.Read())
            {
                if (jsonTextReader.TokenType == JsonToken.StartObject)
                {
                    ret =  ReadNode(jsonTextReader, null, null);
                }
            }
            jsonTextReader.Close();
            return ret;
        }

        private void Test()
        {
            QueryPlanNode node = ParsePlan(Properties.Resources.TestMySQLQueryPlan);
            Console.WriteLine(node);
        }

        static void Main(string[] args)
        {
            H2Connection connection = new H2Connection();
            connection.ConnectionString = "jdbc:h2:tcp://dbsys.cs.vsb.cz/~/test;USER=sa;PASSWORD=n3cUmubsbo";
            connection.Open();

            Console.WriteLine("start...");
            H2Command cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT a, b, c FROM Test";
            H2DataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int a = reader.GetInt32(0);
                int b = reader.GetInt32(1);
                int c = reader.GetInt32(2);

                Console.WriteLine("{0} {1} {2}", a, b, c);
            }
            reader.Close();
            Console.WriteLine("stop...");

            connection.Close();
        }
    }
}
