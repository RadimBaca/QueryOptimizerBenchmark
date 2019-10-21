using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBenchmark.Controls
{
    public class DbProviderComboBox: ComboBox
    {
        private class DbProviderItem
        {
            private DbProviders.DbProvider dbProvider;

            public DbProviders.DbProvider DbProvider
            {
                get => dbProvider;
                set => dbProvider = value;
            }

            public override string ToString()
            {
                if (dbProvider != null)
                {
                    return dbProvider.Name;
                }
                else
                {
                    return "(default)";
                }
            }
        }

        public class ProviderImplementedEventArgs: EventArgs
        {
            private DbProviders.DbProvider dbProvider;
            private bool isImplemented;

            public DbProviders.DbProvider DbProvider
            {
                get => dbProvider;
            }

            public bool IsImplemented
            {
                get => isImplemented;
                set => isImplemented = value;
            }

            public ProviderImplementedEventArgs(DbProviders.DbProvider dbProvider)
            {
                this.dbProvider = dbProvider;
                this.isImplemented = false;
            }
        }

        public DbProviders.DbProvider SelectedDbProvider
        {
            get
            {
                if (SelectedItem is DbProviderItem item)
                {
                    return item.DbProvider;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                foreach (DbProviderItem item in Items)
                {
                    if (item.DbProvider == value)
                    {
                        this.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        

        public delegate void ProviderImplementedEventHandler(object sender, ProviderImplementedEventArgs e);

        public event ProviderImplementedEventHandler ProviderImplemented;

        protected virtual void OnProviderImplemented(DbProviders.DbProvider dbProvider, out bool isImplemented)
        {
            if (ProviderImplemented != null)
            {
                ProviderImplementedEventArgs e = new ProviderImplementedEventArgs(dbProvider);
                ProviderImplemented(this, e);
                isImplemented = e.IsImplemented;
            }
            else
            {
                isImplemented = false;
            }
        }

        public DbProviderComboBox()
        {
            InitializeComponent();
        }

        public void LoadProviders()
        {
            this.BeginUpdate();

            this.Items.Clear();

            DbProviderItem defaultItem = new DbProviderItem();
            this.Items.Add(defaultItem);

            if (DbProviders.DbProvider.Providers != null)
            {
                foreach (DbProviders.DbProvider dbProvider in DbProviders.DbProvider.Providers)
                {
                    this.Items.Add(new DbProviderItem() { DbProvider = dbProvider });
                }
            }

            this.EndUpdate();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DbProviderComboBox
            // 
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DbProviderComboBox_DrawItem);
            this.ResumeLayout(false);

        }

        private void DbProviderComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                DbProviderItem item = Items[e.Index] as DbProviderItem;

                if (item != null)
                {
                    Font font = this.Font;
                    Color color = this.ForeColor;

                    if (item.DbProvider != null)
                    {
                        OnProviderImplemented(item.DbProvider, out bool isImplemented);

                        if (isImplemented)
                        {
                            font = new Font(this.Font, FontStyle.Bold);
                        }
                    }
                    else
                    {
                        color = Color.Silver;
                        font = new Font(this.Font, FontStyle.Italic);
                    }

                    if ((e.State & DrawItemState.Selected) != 0)
                    {
                        color = SystemColors.HighlightText;
                    }

                    e.DrawBackground();

                    TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                    TextRenderer.DrawText(e.Graphics, item.ToString(), font, e.Bounds, color, flags);

                    if ((e.State & DrawItemState.Focus) != 0)
                    {
                        ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
                    }
                }
            }
        }
    }
}
