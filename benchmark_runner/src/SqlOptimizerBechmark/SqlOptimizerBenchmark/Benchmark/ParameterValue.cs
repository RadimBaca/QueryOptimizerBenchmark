﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class ParameterValue : BenchmarkObject
    {
        private PlanEquivalenceTest planEquivalenceTest;
        private int templateId = 0;
        private int parameterId = 0;
        private string value = string.Empty;

        public override IBenchmarkObject ParentObject => planEquivalenceTest;

        public PlanEquivalenceTest PlanEquivalenceTest
        {
            get => planEquivalenceTest;
        }
        public int TemplateId
        {
            get => templateId;
            set
            {
                if (templateId != value)
                {
                    templateId = value;
                    OnPropertyChanged("TemplateId");
                }
            }
        }

        public int ParameterId
        {
            get => parameterId;
            set
            {
                if (parameterId != value)
                {
                    parameterId = value;
                    OnPropertyChanged("ParameterId");
                }
            }
        }

        public string Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        public ParameterValue(PlanEquivalenceTest planEquivalenceTest)
        {
            this.planEquivalenceTest = planEquivalenceTest;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("template_id", ref templateId);
            serializer.ReadInt("parameter_id", ref parameterId);
            serializer.ReadString("value", ref value);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("template_id", templateId);
            serializer.WriteInt("parameter_id", parameterId);
            serializer.WriteString("value", value);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = GetTableInfo();

            ret.TableName = "ParameterValue";

            ret.DbColumns.Add(new DbColumnInfo("TemplateId", "template_id", System.Data.DbType.Int32, true, "Template", "template_id"));
            ret.DbColumns.Add(new DbColumnInfo("ParameterId", "parameter_id", System.Data.DbType.Int32, true, "Parameter", "parameter_id"));
            ret.DbColumns.Add(new DbColumnInfo("Value", "value", System.Data.DbType.String, 100));

            return ret;
        }
    }
}
