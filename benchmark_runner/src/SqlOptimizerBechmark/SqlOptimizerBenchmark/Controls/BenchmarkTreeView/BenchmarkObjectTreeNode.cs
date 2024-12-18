﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls.BenchmarkTreeView
{
    public abstract class BenchmarkObjectTreeNode : TreeNode
    {
        private Benchmark.IBenchmarkObject benchmarkObject;
        private BenchmarkTreeView benchmarkTreeView;
        private bool childrenBound = false;

        public Benchmark.IBenchmarkObject BenchmarkObject
        {
            get => benchmarkObject;
        }
        
        public BenchmarkTreeView BenchmarkTreeView
        {
            get => benchmarkTreeView;
        }

        public bool ChildrenBound
        {
            get => childrenBound;
            set => childrenBound = true;
        }

        public BenchmarkObjectTreeNode(Benchmark.IBenchmarkObject benchmarkObject, BenchmarkTreeView benchmarkTreeView)
        {
            this.benchmarkObject = benchmarkObject;
            this.benchmarkTreeView = benchmarkTreeView;
            BindNode();
            if (HasChildren())
            {
                FakeTreeNode fakeNode = new FakeTreeNode();
                this.Nodes.Add(fakeNode);
            }
        }              

        public abstract void BindNode();

        public abstract void BindChildren();

        public abstract bool HasChildren();

        protected void BindNamedObjectText()
        {
            if (benchmarkObject is Benchmark.INumberedBenchmarkObject numberedBenchmarkObject1 &&
                benchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject1)
            {
                this.Text = Helpers.GetTitle(numberedBenchmarkObject1, namedBenchmarkObject1);
                benchmarkObject.PropertyChanged += BenchmarkObject_PropertyChanged;
            }
            else if (benchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject2)
            {
                this.Text = namedBenchmarkObject2.Name;
                namedBenchmarkObject2.PropertyChanged += BenchmarkObject_PropertyChanged;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void BenchmarkObject_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (benchmarkObject is Benchmark.INumberedBenchmarkObject numberedBenchmarkObject &&
                benchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject1)
            {
                if (e.PropertyName == "Number" || e.PropertyName == "Name")
                {
                    this.Text = Helpers.GetTitle(numberedBenchmarkObject, namedBenchmarkObject1);
                }
            }
            else if (benchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject)
            {
                if (e.PropertyName == "Name")
                {
                    this.Text = namedBenchmarkObject.Name;
                }
            }
        }

        protected void BindCollection<T>(TreeNode node, ObservableCollection<T> collection)
            where T : Benchmark.IBenchmarkObject
        {
            foreach (T obj in collection)
            {
                BenchmarkObjectTreeNode childNode = BenchmarkTreeView.CreateNodeForObject(obj);
                node.Nodes.Add(childNode);
            }

            collection.CollectionChanged += delegate (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                TreeView.BeginUpdate();

                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    // Delete old.
                    foreach (T obj in e.OldItems)
                    {
                        TreeNode deleteNode = null;
                        foreach (TreeNode child in node.Nodes)
                        {
                            if (child is BenchmarkObjectTreeNode benchmarkObjectTreeNode &&
                                benchmarkObjectTreeNode.BenchmarkObject == (Benchmark.IBenchmarkObject)obj)
                            {
                                deleteNode = child;
                            }
                        }
                        if (deleteNode != null)
                        {
                            node.Nodes.Remove(deleteNode);
                        }
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    // Add new.
                    int index = e.NewStartingIndex;
                    foreach (T obj in e.NewItems)
                    {
                        BenchmarkObjectTreeNode childNode = BenchmarkTreeView.CreateNodeForObject(obj);
                        node.Nodes.Insert(index++, childNode);
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Move)
                {
                    int index1 = e.OldStartingIndex;
                    int index2 = e.NewStartingIndex;

                    TreeNode moveNode = node.Nodes[index1];
                    node.Nodes.RemoveAt(index1);
                    node.Nodes.Insert(index2, moveNode);
                }

                TreeView.EndUpdate();
            };
        }

        public virtual bool IsLabelEditable() { return false; }

        public virtual void AfterLabelEdit(string newLabel)
        {
            if (benchmarkObject is Benchmark.INumberedBenchmarkObject numberedBenchmarkObject &&
                benchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject1)
            {
                Helpers.ParseTitle(numberedBenchmarkObject, namedBenchmarkObject1, newLabel);
                this.Text = Helpers.GetTitle(numberedBenchmarkObject, namedBenchmarkObject1);
            }
            else if (benchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject)
            {
                namedBenchmarkObject.Name = newLabel;
            }
        }
    }
}
