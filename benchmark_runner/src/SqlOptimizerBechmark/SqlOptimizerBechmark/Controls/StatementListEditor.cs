using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace SqlOptimizerBechmark.Controls
{
    public partial class StatementListEditor : UserControl
    {
        private string statementSeparator = "GO";
        private TextStyle separatorStyle;
        private Benchmark.StatementList statementList = new Benchmark.StatementList(null);
        bool ready = true;

        [DefaultValue("GO")]
        public string StatementSeparator
        {
            get => statementSeparator;
            set => statementSeparator = value;
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benchmark.StatementList StatementList
        {
            get => statementList;
            set => statementList = value;
        }

        public event EventHandler ScriptChanged;

        protected virtual void OnScriptChanged()
        {
            if (ScriptChanged != null)
            {
                ScriptChanged(this, EventArgs.Empty);
            }
        }

        public StatementListEditor()
        {
            InitializeComponent();
            separatorStyle = new TextStyle(Brushes.Blue, Brushes.Transparent, FontStyle.Bold);
        }

        private bool IsSeparatorLine(string text)
        {
            return string.Compare(text, statementSeparator, true) == 0;
        }

        private void UpdateScript()
        {
            if (statementList == null)
            {
                return;
            }

            List<string> statementCommands = new List<string>();
            string currentStatementCommand = string.Empty;

            foreach (string line in fctb.Lines)
            {
                if (IsSeparatorLine(line))
                {
                    statementCommands.Add(currentStatementCommand);
                    currentStatementCommand = string.Empty;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentStatementCommand))
                    {
                        currentStatementCommand += Environment.NewLine;
                    }
                    currentStatementCommand += line;
                }
            }

            if (!string.IsNullOrEmpty(currentStatementCommand))
            {
                statementCommands.Add(currentStatementCommand);
            }


            while (statementList.Statements.Count < statementCommands.Count)
            {
                statementList.Statements.Add(new Benchmark.Statement(statementList));
            }
            while (statementCommands.Count < statementList.Statements.Count)
            {
                statementList.Statements.RemoveAt(statementList.Statements.Count - 1);
            }

            for (int i = 0; i < statementList.Statements.Count; i++)
            {
                statementList.Statements[i].CommandText = statementCommands[i];
            }
        }

        public void UpdateText()
        {
            ready = false;

            if (statementList != null)
            {

                string str = string.Empty;
                foreach (Benchmark.Statement statement in statementList.Statements)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        str += Environment.NewLine;
                        str += statementSeparator;
                        str += Environment.NewLine;
                        str += Environment.NewLine;
                    }

                    str += statement.CommandText;
                }

                fctb.BeginUpdate();
                fctb.Text = str;

                for (int line = 0; line < fctb.Lines.Count; line++)
                {
                    string lineText = fctb.GetLineText(line);
                    if (IsSeparatorLine(lineText))
                    {
                        Range range = fctb.GetRange(new Place(0, line), new Place(lineText.Length, line));
                        range.SetStyle(separatorStyle);
                    }
                }

                fctb.EndUpdate();
            }
            else
            {
                fctb.Text = string.Empty;
            }

            fctb.ClearUndo();

            ready = true;
        }


        private void fctb_PaintLine(object sender, PaintLineEventArgs e)
        {
            string lineText = fctb.GetLineText(e.LineIndex);

            if (IsSeparatorLine(lineText))
            {
                Rectangle rect = e.LineRect;

                int x1 = rect.Left + fctb.CharWidth * (statementSeparator.Length + 1);
                int x2 = rect.Right;
                int y = rect.Top + rect.Height / 2;

                Pen pen = new Pen(Color.Silver, 1);

                e.Graphics.DrawLine(pen, x1, y, x2, y);
            }
        }

        private void fctb_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return && (ModifierKeys & Keys.Control) != 0)
            {
                fctb.InsertText(Environment.NewLine);
                fctb.InsertText(statementSeparator);
                fctb.InsertText(Environment.NewLine);
                e.IsInputKey = false;
            }
        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ready)
            {
                //clear old styles of chars
                e.ChangedRange.ClearStyle(separatorStyle);
                //append style for word 'Babylon'
                for (int line = e.ChangedRange.FromLine; line <= e.ChangedRange.ToLine; line++)
                {
                    string lineText = fctb.GetLineText(line);
                    if (IsSeparatorLine(lineText))
                    {
                        Range range = fctb.GetRange(new Place(0, line), new Place(lineText.Length, line));
                        range.SetStyle(separatorStyle);
                    }
                }
            }
        }

        private void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            if (ready)
            {
                UpdateScript();
                OnScriptChanged();
            }
        }
    }
}
