using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls
{
    public class AnnotationCheckListBox: CheckedListBox
    {
        private class AnnotationWrapper
        {
            private AnnotationCheckListBox owner;
            private Benchmark.Annotation annotation;
            private Benchmark.SelectedAnnotation selectedAnnotation;

            public AnnotationCheckListBox Owner => owner;
                

            public Benchmark.Annotation Annotation
            {
                get => annotation;
                set => annotation = value;
            }

            public Benchmark.SelectedAnnotation SelectedAnnotation
            {
                get => selectedAnnotation;
                set => selectedAnnotation = value;
            }

            public AnnotationWrapper(AnnotationCheckListBox owner)
            {
                this.owner = owner;
            }

            public override string ToString()
            {
                return Helpers.GetTitle(annotation, annotation);
            }
        }

        private ObservableCollection<Benchmark.SelectedAnnotation> selectedAnnotations;
        private Benchmark.BenchmarkObject parentBenchmarkObject;
        private bool ready = true;

        public ObservableCollection<Benchmark.SelectedAnnotation>  SelectedAnnotations
        {
            get => selectedAnnotations;
            set
            {
                if (selectedAnnotations != null)
                {
                    selectedAnnotations.CollectionChanged -= SelectedAnnotations_CollectionChanged;
                }

                selectedAnnotations = value;

                if (selectedAnnotations != null)
                {
                    selectedAnnotations.CollectionChanged += SelectedAnnotations_CollectionChanged;
                }
            }
        }
            
        public Benchmark.BenchmarkObject ParentBenchmarkObject
        {
            get => parentBenchmarkObject;
            set => parentBenchmarkObject = value;
        }

        public void BindAnnotations()
        {
            ready = false;

            BeginUpdate();
            Items.Clear();
            foreach (Benchmark.Annotation annotation in parentBenchmarkObject.Owner.Annotations)
            {
                AnnotationWrapper wrapper = new AnnotationWrapper(this);
                wrapper.Annotation = annotation;
                wrapper.SelectedAnnotation = selectedAnnotations.Where(a => a.AnnotationId == annotation.Id).FirstOrDefault();
                bool isChecked = wrapper.SelectedAnnotation != null;
                Items.Add(wrapper, isChecked);
            }
            EndUpdate();

            ready = true;
        }

        private void UpdateCheckStatus()
        {
            ready = false;

            int index = 0;
            foreach (AnnotationWrapper wrapper in this.Items)
            {
                wrapper.SelectedAnnotation = selectedAnnotations.Where(a => a.AnnotationId == wrapper.Annotation.Id).FirstOrDefault();
                bool isChecked = wrapper.SelectedAnnotation != null;
                this.SetItemChecked(index, isChecked);
                index++;
            }

            ready = true;
        }

        private void SelectedAnnotations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ready)
            {
                UpdateCheckStatus();
            }
        }

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            base.OnItemCheck(ice);

            if (!ready)
            {
                return;
            }

            ready = false;

            if (this.Items[ice.Index] is AnnotationWrapper wrapper)
            {
                if (ice.NewValue == CheckState.Checked)
                {
                    if (selectedAnnotations.Where(a => a.AnnotationId == wrapper.Annotation.Id).Count() == 0)
                    {
                        Benchmark.SelectedAnnotation selectedAnnotation = new Benchmark.SelectedAnnotation(parentBenchmarkObject);
                        selectedAnnotation.AnnotationId = wrapper.Annotation.Id;
                        selectedAnnotations.Add(selectedAnnotation);
                        wrapper.SelectedAnnotation = selectedAnnotation;
                    }
                }
                else if (ice.NewValue == CheckState.Unchecked)
                {
                    List<Benchmark.SelectedAnnotation> annotationsToRemove =
                        selectedAnnotations.Where(a => a.AnnotationId == wrapper.Annotation.Id).ToList();
                    foreach (Benchmark.SelectedAnnotation selectedAnnotation in annotationsToRemove)
                    {
                        selectedAnnotations.Remove(selectedAnnotation);
                    }
                    wrapper.SelectedAnnotation = null;
                }
            }

            ready = true;
        }
    }
}
