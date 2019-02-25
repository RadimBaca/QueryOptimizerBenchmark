﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Benchmark
{
    public class SelectedAnnotationResult : BenchmarkObject
    {
        private BenchmarkObject parentObject;
        private int annotationId;

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

        public SelectedAnnotationResult(BenchmarkObject parentObject)
        {
            this.parentObject = parentObject;
        }

        public override void SaveToXml(BenchmarkXmlSerializer serializer)
        {
            serializer.WriteInt("annotation_id", annotationId);
        }

        public override void LoadFromXml(BenchmarkXmlSerializer serializer)
        {
            serializer.ReadInt("annotation_id", ref annotationId);
        }
    }
}
