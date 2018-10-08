using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SqlOptimizerBechmark.Controls
{
    internal static class Helpers
    {
        public static int ExtractTrailingNumber(string str)
        {
            int firstIndex = str.Length;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(str[i]))
                {
                    firstIndex = i;
                }
                else
                {
                    break;
                }
            }

            if (firstIndex < str.Length)
            {
                string numberStr = str.Substring(firstIndex);
                return int.Parse(numberStr);
            }
            else
            {
                return -1;
            }
        }

        public static string ExtractStrWithoutTrailingNumber(string str)
        {
            int firstIndex = str.Length;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(str[i]))
                {
                    firstIndex = i;
                }
                else
                {
                    break;
                }
            }

            if (firstIndex < str.Length)
            {
                string ret = str.Substring(0, firstIndex);
                return ret;
            }
            else
            {
                return str;
            }
        }

        public static string GuessNewName(IEnumerable<string> names, string defaultName)
        {
            string name1 = string.Empty;
            string name2 = string.Empty;
            foreach (string name in names)
            {
                name1 = name2;
                name2 = name;
            }

            int n1 = ExtractTrailingNumber(name1);
            int n2 = ExtractTrailingNumber(name2);

            if (n1 >= 0 && n2 >= 0 && n2 == n1 + 1)
            {
                string str1 = ExtractStrWithoutTrailingNumber(name1);
                string str2 = ExtractStrWithoutTrailingNumber(name2);

                if (str1 == str2)
                {
                    int n3 = n2 + 1;
                    string ret = str1 + n3.ToString();
                    return ret;
                }
            }

            if (n2 >= 0)
            {
                int n3 = n2 + 1;
                string str = ExtractStrWithoutTrailingNumber(name2);
                string ret = str + n3.ToString();
                return ret;
            }

            return defaultName;
        }

        public static ImageList CreateBenchmarkImageList()
        {
            ImageList ret = new ImageList();

            ret.ColorDepth = ColorDepth.Depth32Bit;

            ret.Images.Add("Benchmark", Properties.Resources.Benchmark_16);
            ret.Images.Add("TestGroup", Properties.Resources.TestGroup_16);
            ret.Images.Add("Folder", Properties.Resources.Folder_16);
            ret.Images.Add("Configuration", Properties.Resources.Configuration_16);
            ret.Images.Add("InitScript", Properties.Resources.InitScript_16);
            ret.Images.Add("CleanUpScript", Properties.Resources.CleanUpScript_16);
            ret.Images.Add("Test", Properties.Resources.Test_16);
            ret.Images.Add("TestInactive", Properties.Resources.TestInactive_16);
            ret.Images.Add("Variant", Properties.Resources.Sql_16);
            ret.Images.Add("Connection", Properties.Resources.DbConnection_16);
            ret.Images.Add("TestRun", Properties.Resources.TestRun_16);
            ret.Images.Add("TestRuns", Properties.Resources.TestRuns_16);
            
            return ret;
        }
    }
}
