using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Benchmark
{
    public class SelectedAnnotationResult : BenchmarkObject
    {
        private BenchmarkObject parentObject;
        private int annotationId;
        private bool isTemplateAnnotation = false;

        public override IBenchmarkObject ParentObject => parentObject; 

        public int AnnotationId
        {
            get => annotationId;
            set
            {
                if (annotationId != value)
                {
                    annotationId = value;
                    OnPropertyChanged("AnnotationId");
                }
            }
        }

        public bool IsTemplateAnnotation
        {
            get => isTemplateAnnotation;
            set
            {
                if (isTemplateAnnotation != value)
                {
                    isTemplateAnnotation = value;
                    OnPropertyChanged("IsTemplateAnnotation");
                }
            }
        }

        public SelectedAnnotationResult(BenchmarkObject parentObject)
        {
            this.parentObject = parentObject;
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("annotation_id", annotationId);
            serializer.WriteBool("is_template_annotation", isTemplateAnnotation);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("annotation_id", ref annotationId);
            serializer.ReadBool("is_template_annotation", ref isTemplateAnnotation);
        }

        public override DbTableInfo GetTableInfo()
        {
            DbTableInfo ret = base.GetTableInfo();

            ret.TableName = "SelectedAnnotationResult";

            ret.DbColumns.Add(new DbColumnInfo("selected_annotation_result_id", true, true)); // PK
            ret.DbColumns.Add(new DbColumnInfo(null, "test_run_id", System.Data.DbType.Int32, true, "TestRun", "test_run_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo(null, "test_result_id", System.Data.DbType.Int32, true, "TestResult", "test_result_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo(null, "query_variant_result_id", System.Data.DbType.Int32, true, "QueryVariantResult", "query_variant_result_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo(null, "template_result_id", System.Data.DbType.Int32, true, "TemplateResult", "template_result_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo("AnnotationId", "annotation_id", System.Data.DbType.Int32, true, "Annotation", "annotation_id")); // FK
            ret.DbColumns.Add(new DbColumnInfo("IsTemplateAnnotation", "is_template_annotation", System.Data.DbType.Boolean));

            return ret;
        }
    }
}
