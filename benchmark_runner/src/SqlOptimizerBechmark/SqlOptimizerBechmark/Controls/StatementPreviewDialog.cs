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
    public partial class StatementPreviewDialog : Form
    {
        public string Statement
        {
            get => fctb.Text;
            set => fctb.Text = value;
        }

        public StatementPreviewDialog()
        {
            InitializeComponent();
        }
    }
}
