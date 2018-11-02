using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOptimizerBechmark.Controls
{
    public class LogBrowser: DataGridViewEx
    {
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colMessage;
        private DataGridViewTextBoxColumn colStatement;

        public LogBrowser()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // colDateTime
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDateTime.HeaderText = "Time";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Width = 120;
            // 
            // colMessage
            // 
            this.colMessage.FillWeight = 50F;
            this.colMessage.HeaderText = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.Width = 200;
            // 
            // colStatement
            // 
            this.colStatement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatement.FillWeight = 50F;
            this.colStatement.HeaderText = "Statement";
            this.colStatement.MinimumWidth = 200;
            this.colStatement.Name = "colStatement";
            this.colStatement.ReadOnly = true;
            // 
            // LogBrowser
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColumnHeadersVisible = false;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateTime,
            this.colMessage,
            this.colStatement});
            this.ReadOnly = true;
            this.RowTemplate.Height = 18;
            this.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogBrowser_CellDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void SetGridRow(DataGridViewRow gridRow, Executor.ExecutorMessage message)
        {
            Color color = SystemColors.WindowText;
            string messageTypeStr = string.Empty;

            switch (message.MessageType)
            {
                case Executor.ExecutorMessageType.Info:
                    color = Color.RoyalBlue;
                    messageTypeStr = "Info";
                    break;
                case Executor.ExecutorMessageType.Warning:
                    color = Color.Orange;
                    messageTypeStr = "Warning";
                    break;
                case Executor.ExecutorMessageType.Error:
                    color = Color.Red;
                    messageTypeStr = "Error";
                    break;
            }

            gridRow.DefaultCellStyle.ForeColor = color;

            gridRow.Cells[colDateTime.Index].Value = message.DateTime;
            gridRow.Cells[colMessage.Index].Value = message.Message;
            gridRow.Cells[colStatement.Index].Value = message.Statement;

            gridRow.Tag = message;
        }

        public void AddMessage(Executor.ExecutorMessage message)
        {
            RowCount++;

            int lastRowIndex = RowCount - 1;
            SetGridRow(Rows[lastRowIndex], message);

            if (!Rows[lastRowIndex].Displayed)
            {
                FirstDisplayedScrollingRowIndex = lastRowIndex;
            }
        }

        public void Clear()
        {
            RowCount = 0;
        }

        private void LogBrowser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (Rows[e.RowIndex].Tag is Executor.ExecutorMessage message)
                {
                    if (e.ColumnIndex == colStatement.Index)
                    {
                        StatementPreviewDialog dialog = new StatementPreviewDialog();
                        dialog.Statement = message.Statement;
                        dialog.ShowDialog();
                    }
                    else if (e.ColumnIndex == colMessage.Index)
                    {
                        MessageBox.Show(message.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
