namespace LevelManagerEx.Shell.Views
{
    partial class LevelsView
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
            this.Tree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.Location = new System.Drawing.Point(0, 0);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(402, 280);
            this.Tree.TabIndex = 0;
            // 
            // LevelsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Tree);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LevelsView";
            this.Size = new System.Drawing.Size(402, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree;
    }
}
