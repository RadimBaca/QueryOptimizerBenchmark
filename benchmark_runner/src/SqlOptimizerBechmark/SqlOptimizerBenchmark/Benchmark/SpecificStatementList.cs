﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class SpecificStatementList: StatementList
    {
        private string providerName = string.Empty;

        public string ProviderName
        {
            get => providerName;
            set
            {
                if (value != providerName)
                {
                    providerName = value;
                    OnPropertyChanged("ProviderName");
                }
            }
        }

        public SpecificStatementList(Script script)
            : base(script)
        {
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteString("provider_name", providerName);
            base.SaveToXml(serializer);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadString("provider_name", ref providerName);
            base.LoadFromXml(serializer);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "SpecificStatementList";

            ret.DbColumns.Add(new DbColumnInfo("ProviderName", "provider_name", System.Data.DbType.String, 50));

            return ret;
        }
    }
}
