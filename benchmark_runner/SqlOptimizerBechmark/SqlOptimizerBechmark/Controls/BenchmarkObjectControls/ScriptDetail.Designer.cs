namespace SqlOptimizerBechmark.Controls.BenchmarkObjectControls
{
    partial class ScriptDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scriptEditor = new SqlOptimizerBechmark.Controls.ScriptEditor();
            this.SuspendLayout();
            // 
            // scriptEditor
            // 
            this.scriptEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptEditor.Location = new System.Drawing.Point(0, 0);
            this.scriptEditor.Name = "scriptEditor";
            this.scriptEditor.Size = new System.Drawing.Size(457, 538);
            this.scriptEditor.TabIndex = 0;
            // 
            // ScriptDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scriptEditor);
            this.Name = "ScriptDetail";
            this.Size = new System.Drawing.Size(457, 538);
            this.ResumeLayout(false);

        }

        #endregion

        private ScriptEditor scriptEditor;
    }
}
