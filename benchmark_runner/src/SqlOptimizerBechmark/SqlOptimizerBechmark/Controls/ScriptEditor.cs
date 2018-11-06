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
    public partial class ScriptEditor : UserControl
    {
        private string statementSeparator = "GO";
        private TextStyle separatorStyle;
        private Benchmark.Script script = new Benchmark.Script(null);
        bool ready = true;

        [DefaultValue("GO")]
        public string StatementSeparator
        {
            get => statementSeparator;
            set => statementSeparator = value;
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benchmark.Script Script
        {
            get => script;
            set => script = value;
        }

        public event EventHandler ScriptChanged;

        protected virtual void OnScriptChanged()
        {
            if (ScriptChanged != null)
            {
                ScriptChanged(this, EventArgs.Empty);
            }
        }

        public ScriptEditor()
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


            while (script.Statements.Count < statementCommands.Count)
            {
                script.Statements.Add(new Benchmark.Statement(script));
            }
            while (statementCommands.Count < script.Statements.Count)
            {
                script.Statements.RemoveAt(script.Statements.Count - 1);
            }

            for (int i = 0; i < script.Statements.Count; i++)
            {
                script.Statements[i].CommandText = statementCommands[i];
            }
        }

        public void UpdateText()
        {
            ready = false;

            string str = string.Empty;
            foreach (Benchmark.Statement statement in script.Statements)
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
