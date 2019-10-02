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
    public partial class FormattingGuideDialog : Form
    {
        private class TokenStats
        {
            private int count;
            private List<Benchmark.QueryVariant> queryVariants = new List<Benchmark.QueryVariant>();

            public int Count
            {
                get => count;
                set => count = value;
            }

            public IList<Benchmark.QueryVariant> QueryVariants
            {
                get => queryVariants;
            }

            public void AddQueryVariant(Benchmark.QueryVariant queryVariant)
            {
                if (!queryVariant.Contains(queryVariant))
                {
                    queryVariants.Add(queryVariant);
                }
            }

            public TokenStats(Benchmark.QueryVariant queryVariant)
            {
                count = 1;
                queryVariants.Add(queryVariant);
            }
        }

        private Benchmark.Benchmark benchmark;
        private Dictionary<string, TokenStats> dict = new Dictionary<string, TokenStats>();


        public Benchmark.Benchmark Benchmark
        {
            get => benchmark;
            set => benchmark = value;
        }

        private void AddMessage(string str)
        {
            txtOutput.Text += str + Environment.NewLine;
        }

        private void ScanCommandText(string commandText, Benchmark.QueryVariant queryVariant)
        {
            try
            {
                Classes.SqlScanner scanner = new Classes.SqlScanner(commandText);
                scanner.Scan();
                foreach (Classes.SqlToken token in scanner.Tokens)
                {
                    if (token.Type == Classes.SqlTokenType.IDENTIFIER_OR_KEYWORD)
                    {
                        if (dict.ContainsKey(token.Value))
                        {
                            dict[token.Value].AddQueryVariant(queryVariant);
                            dict[token.Value].Count++;
                        }
                        else
                        {
                            dict.Add(token.Value, new TokenStats(queryVariant));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
        }

        private string GetQueryVariantNumberStr(Benchmark.QueryVariant queryVariant)
        {
            return string.Format("{0}/{1}/{2}",
                queryVariant.PlanEquivalenceTest.TestGroup.Number,
                queryVariant.PlanEquivalenceTest.Number,
                queryVariant.Number);
        }

        private void ScanTokens()
        {
            txtOutput.Text = string.Empty;

            dict.Clear();
            foreach (Benchmark.TestGroup group in benchmark.TestGroups)
            {
                foreach (Benchmark.PlanEquivalenceTest test in group.Tests)
                {
                    foreach (Benchmark.QueryVariant variant in test.Variants)
                    {
                        ScanCommandText(variant.DefaultStatement.CommandText, variant);

                        foreach (Benchmark.SpecificStatement specificStatement in variant.SpecificStatements)
                        {
                            ScanCommandText(specificStatement.CommandText, variant);
                        }
                    }
                }
            }

            HashSet<string> upperTokens = new HashSet<string>();
            foreach (KeyValuePair<string, TokenStats> pair in dict)
            {
                string upperToken = pair.Key.ToUpper();
                if (!upperTokens.Contains(upperToken))
                {
                    upperTokens.Add(upperToken);
                }
            }

            List<KeyValuePair<string, TokenStats>> list = new List<KeyValuePair<string, TokenStats>>();
            foreach (string upperToken in upperTokens)
            {
                list.Clear();

                foreach (KeyValuePair<string, TokenStats> pair in dict)
                {
                    if (pair.Key.ToUpper() == upperToken)
                    {
                        list.Add(pair);
                    }
                }

                if (list.Count > 1)
                {
                    string msg = string.Empty;
                    foreach (KeyValuePair<string, TokenStats> pair in list)
                    {
                        if (!string.IsNullOrEmpty(msg))
                        {
                            msg += " | ";
                        }
                        msg += string.Format("'{0}': {1}x ({2})", pair.Key, pair.Value.Count,
                            GetQueryVariantNumberStr(pair.Value.QueryVariants.FirstOrDefault()));
                    }
                    AddMessage(msg);
                }
            }
        }

        public FormattingGuideDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(665, 499);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtOutput.Location = new System.Drawing.Point(12, 12);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(728, 481);
            this.txtOutput.TabIndex = 2;
            // 
            // FormattingGuideDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 534);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnClose);
            this.Name = "FormattingGuideDialog";
            this.Text = "Formatting guide";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormattingGuideDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FormattingGuideDialog_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ScanTokens();
            Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
