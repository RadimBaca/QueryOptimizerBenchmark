using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace SqlOptimizerBenchmark.Controls.BenchmarkListView
{
    public partial class BenchmarkListView<T> : UserControl
        where T : Benchmark.IBenchmarkObject
    {
        #region Fields

        private ObservableCollection<T> collection;

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObservableCollection<T> Collection
        {
            get => collection;
            set
            {
                if (collection != null)
                {
                    collection.CollectionChanged -= Collection_CollectionChanged;
                }
                collection = value;
                if (collection != null)
                {
                    collection.CollectionChanged += Collection_CollectionChanged;
                }
                listView.SmallImageList = Helpers.CreateBenchmarkImageList();
                BindListView();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benchmark.IBenchmarkObject SelectedBenchmarkObject
        {
            get
            {
                if (listView.SelectedItems.Count == 1)
                {
                    return GetBenchmarkObject(listView.SelectedItems[0]);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ListViewItem item = GetListViewItem(value);
                if (item != null)
                {
                    listView.SelectedItems.Clear();
                    item.Selected = true;
                }
            }
        }

        #endregion

        #region Events

        public event EventHandler SelectionChanged;

        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }

        public event BenchmarkObjectEventHandler BenchmarkObjectDoubleClick;

        protected virtual void OnBenchmarkObjectDoubleClick(Benchmark.IBenchmarkObject benchmarkObject)
        {
            if (BenchmarkObjectDoubleClick != null)
            {
                BenchmarkObjectDoubleClick(this, new BenchmarkObjectEventArgs(benchmarkObject));
            }
        }

        #endregion

        #region Constructors

        public BenchmarkListView()
        {
            InitializeComponent();
        }

        #endregion

        #region Misc methods

        public ListViewItem GetListViewItem(Benchmark.IBenchmarkObject benchmarkObject)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item is BenchmarkObjectListViewItem benchmarkObjectListViewItem)
                {
                    if (benchmarkObjectListViewItem.BenchmarkObject == benchmarkObject)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public Benchmark.IBenchmarkObject GetBenchmarkObject(ListViewItem item)
        {
            if (item is BenchmarkObjectListViewItem benchmarkObjectListViewItem)
            {
                return benchmarkObjectListViewItem.BenchmarkObject;
            }
            else
            {
                return null;
            }
        }

        private void BindListView()
        {
            listView.BeginUpdate();
            listView.Items.Clear();

            if (collection != null)
            {
                foreach (T obj in collection)
                {
                    BenchmarkObjectListViewItem item = new BenchmarkObjectListViewItem(obj);
                    BindItem(item);
                    listView.Items.Add(item);
                }
            }

            listView.EndUpdate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                Rename();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void Collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            listView.BeginUpdate();
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Benchmark.IBenchmarkObject obj in e.OldItems)
                {
                    ListViewItem deleteItem = null;
                    foreach (ListViewItem item in listView.Items)
                    {
                        if (item is BenchmarkObjectListViewItem benchmarkObjectListViewItem)
                        {
                            if (benchmarkObjectListViewItem.BenchmarkObject == obj)
                            {
                                deleteItem = item;
                                break;
                            }
                        }
                    }
                    if (deleteItem != null)
                    {
                        listView.Items.Remove(deleteItem);
                    }
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int index = e.NewStartingIndex;
                foreach (Benchmark.IBenchmarkObject obj in e.NewItems)
                {
                    BenchmarkObjectListViewItem item = new BenchmarkObjectListViewItem(obj);
                    BindItem(item);
                    listView.Items.Insert(index++, item);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Move)
            {
                int index1 = e.OldStartingIndex;
                int index2 = e.NewStartingIndex;

                ListViewItem item = listView.Items[index1];
                listView.Items.RemoveAt(index1);
                listView.Items.Insert(index2, item);
            }
            listView.EndUpdate();
        }

        private void UpdateUI()
        {
            btnRemove.Enabled = listView.SelectedItems.Count > 0;
            btnRename.Enabled = listView.SelectedItems.Count == 1;

            List<int> selectedIndexes = new List<int>();
            foreach (int index in listView.SelectedIndices)
            {
                selectedIndexes.Add(index);
            }
            selectedIndexes.Sort();

            btnMoveUp.Enabled = selectedIndexes.Count > 0 && selectedIndexes[0] > 0;
            btnMoveDown.Enabled = selectedIndexes.Count > 0 && selectedIndexes[selectedIndexes.Count - 1] < collection.Count - 1;
        }

        #endregion

        #region Virtual methods

        protected virtual string GetImageKey()
        {
            return string.Empty;
        }

        protected virtual void BindItem(BenchmarkObjectListViewItem item)
        {
            item.ImageKey = GetImageKey();

            if (item.BenchmarkObject is Benchmark.INumberedBenchmarkObject numberedBenchmarkObject &&
                item.BenchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject1)
            {
                item.Text = Helpers.GetTitle(numberedBenchmarkObject, namedBenchmarkObject1);
                numberedBenchmarkObject.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "Number" || e.PropertyName == "Name")
                    {
                        item.Text = Helpers.GetTitle(numberedBenchmarkObject, namedBenchmarkObject1);
                    }
                };
            }
            else if (item.BenchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject2)
            {
                item.Text = namedBenchmarkObject2.Name;
                namedBenchmarkObject2.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "Name")
                    {
                        item.Text = namedBenchmarkObject2.Name;
                    }
                };
            }

            if (item.BenchmarkObject is Benchmark.IDescribedBenchmarkObject describedBenchmarkObject)
            {
                item.SubItems.Add(describedBenchmarkObject.Description);
                describedBenchmarkObject.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "Description")
                    {
                        item.SubItems[1].Text = describedBenchmarkObject.Description;
                    }
                };
            }

        }

        protected virtual bool IsLabelEditable(BenchmarkObjectListViewItem item)
        {
            return item.BenchmarkObject is Benchmark.INamedBenchmarkObject;
        }

        protected virtual void AfterLabelEdit(BenchmarkObjectListViewItem item, string label)
        {
            if (item.BenchmarkObject is Benchmark.INumberedBenchmarkObject numberedBenchmarkObject &&
                item.BenchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject1)
            {
                Helpers.ParseTitle(numberedBenchmarkObject, namedBenchmarkObject1, label);
                item.Text = Helpers.GetTitle(numberedBenchmarkObject, namedBenchmarkObject1);
            }
            else if (item.BenchmarkObject is Benchmark.INamedBenchmarkObject namedBenchmarkObject2)
            {
                namedBenchmarkObject2.Name = label;
            }
        }

        protected virtual T CreateInstance()
        {
            return default(T);
        }

        #endregion

        #region User actions

        private void Add()
        {
            T newInstance = CreateInstance();
            collection.Add(newInstance);

            ListViewItem item = GetListViewItem(newInstance);
            if (item != null)
            {
                listView.SelectedItems.Clear();
                item.Selected = true;
                item.BeginEdit();
            }
        }

        private void Remove()
        {
            List<Benchmark.IBenchmarkObject> benchmarkObjects = new List<Benchmark.IBenchmarkObject>();
            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (item is BenchmarkObjectListViewItem benchmarkObjectListViewItem)
                {
                    benchmarkObjects.Add(benchmarkObjectListViewItem.BenchmarkObject);
                }
            }
            foreach (T benchmarkObject in benchmarkObjects)
            {
                collection.Remove(benchmarkObject);
            }
        }

        private void MoveItemsUp()
        {
            // Unexpected behavior.
            if (listView.Items.Count != collection.Count)
            {
                return;
            }

            List<int> selectedIndexes = new List<int>();
            foreach (int index in listView.SelectedIndices)
            {
                selectedIndexes.Add(index);
            }

            // Cannot move empty list.
            if (selectedIndexes.Count == 0)
            {
                return;
            }

            selectedIndexes.Sort();

            // If the first selected item is the first item in the list, we cannot do the move up.
            if (selectedIndexes[0] == 0)
            {
                return;
            }

            foreach (int index1 in selectedIndexes)
            {
                int index2 = index1 - 1;
                collection.Move(index1, index2);
            }
        }

        private void MoveItemsDown()
        {
            // Unexpected behavior.
            if (listView.Items.Count != collection.Count)
            {
                return;
            }

            List<int> selectedIndexes = new List<int>();
            foreach (int index in listView.SelectedIndices)
            {
                selectedIndexes.Add(index);
            }

            // Cannot move empty list.
            if (selectedIndexes.Count == 0)
            {
                return;
            }

            selectedIndexes.Sort();
            selectedIndexes.Reverse();

            // Cannot move down if the last item in the list is selected.
            if (selectedIndexes[0] == collection.Count - 1)
            {
                return;
            }


            foreach (int index1 in selectedIndexes)
            {
                int index2 = index1 + 1;
                collection.Move(index1, index2);
            }
        }

        private void Rename()
        {
            if (listView.SelectedItems.Count == 1)
            {
                listView.SelectedItems[0].BeginEdit();
            }
        }

        #endregion

        #region Event handlers

        private void listView_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = listView.Items[e.Item];
            if (item is BenchmarkObjectListViewItem benchmarkObjectListViewItem)
            {
                if (!IsLabelEditable(benchmarkObjectListViewItem))
                {
                    e.CancelEdit = true;
                }
            }
            else
            {
                e.CancelEdit = true;
            }
        }

        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = listView.Items[e.Item];
            if (item is BenchmarkObjectListViewItem benchmarkObjectListViewItem)
            {
                if (e.Label != null)
                {
                    item.Text = e.Label;
                    AfterLabelEdit(benchmarkObjectListViewItem, e.Label);
                    e.CancelEdit = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveItemsUp();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveItemsDown();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
            OnSelectionChanged();
        }

        private void BenchmarkListView_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedBenchmarkObject != null)
            {
                OnBenchmarkObjectDoubleClick(SelectedBenchmarkObject);
            }
        }

        #endregion
    }
}
