using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls
{
    public partial class QueryResultPreviewDialog : Form
    {
        private DbProviders.DbProvider dbProvider;

        public string Query
        {
            get { return fctb.Text; }
            set { fctb.Text = value; }
        }

        public DbProviders.DbProvider DbProvider
        {
            get { return dbProvider; }
            set { dbProvider = value; }
        }

        public QueryResultPreviewDialog()
        {
            InitializeComponent();
        }

        private string GetSelectedText()
        {
            if (fctb.SelectionLength == 0)
            {
                return fctb.Text;
            }
            else
            {
                return fctb.SelectedText;
            }
        }

        public void Execute()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dbProvider.Connect();
                string query = GetSelectedText(); 
                DataTable table = dbProvider.ExecuteQuery(query);
                gridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbProvider.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void QueryResultPreviewDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Execute();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void gridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object val = gridView[e.ColumnIndex, e.RowIndex].Value;
                string str = $"{val}: {val.GetType()}";
                e.ToolTipText = str;
            }
        }
    }
}
