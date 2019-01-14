﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class AnnotationResult : BenchmarkObject
    {
        private TestRun testRun;
        private int annotationId = 0;
        private string annotationNumber = string.Empty;
        private string annotationName = string.Empty;

        public override IBenchmarkObject ParentObject => testRun;

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

        public string AnnotationNumber
        {
            get => annotationNumber;
            set
            {
                if (annotationNumber != value)
                {
                    annotationNumber = value;
                    OnPropertyChanged("AnnotationNumber");
                }
            }
        }

        public string AnnotationName
        {
            get => annotationName;
            set
            {
                if (annotationName != value)
                {
                    annotationName = value;
                    OnPropertyChanged("AnnotationName");
                }
            }
        }

        public AnnotationResult(TestRun testRun)
        {
            this.testRun = testRun;
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("anntation_id", ref annotationId);
            serializer.ReadString("anntation_number", ref annotationNumber);
            serializer.ReadString("anntation_name", ref annotationName);
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("anntation_id", annotationId);
            serializer.WriteString("anntation_number", annotationNumber);
            serializer.WriteString("anntation_name", annotationName);
        }
    }
}
