namespace LevelManagerEx.Shell.Views
{
    partial class Shell
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonPanelRegion = new System.Windows.Forms.Panel();
            this.ToolbarRegion = new System.Windows.Forms.Panel();
            this.ShellContentRegion = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ShellContentRegion)).BeginInit();
            this.ShellContentRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanelRegion
            // 
            this.ButtonPanelRegion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanelRegion.Location = new System.Drawing.Point(0, 605);
            this.ButtonPanelRegion.Name = "ButtonPanelRegion";
            this.ButtonPanelRegion.Size = new System.Drawing.Size(956, 40);
            this.ButtonPanelRegion.TabIndex = 1;
            // 
            // ToolbarRegion
            // 
            this.ToolbarRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarRegion.Location = new System.Drawing.Point(0, 0);
            this.ToolbarRegion.Name = "ToolbarRegion";
            this.ToolbarRegion.Size = new System.Drawing.Size(956, 44);
            this.ToolbarRegion.TabIndex = 2;
            // 
            // ShellContentRegion
            // 
            this.ShellContentRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShellContentRegion.Location = new System.Drawing.Point(0, 44);
            this.ShellContentRegion.Name = "ShellContentRegion";
            this.ShellContentRegion.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ShellContentRegion.Size = new System.Drawing.Size(956, 561);
            this.ShellContentRegion.SplitterDistance = 362;
            this.ShellContentRegion.TabIndex = 3;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 645);
            this.Controls.Add(this.ShellContentRegion);
            this.Controls.Add(this.ToolbarRegion);
            this.Controls.Add(this.ButtonPanelRegion);
            this.Name = "Shell";
            this.Text = "Shell";
            ((System.ComponentModel.ISupportInitialize)(this.ShellContentRegion)).EndInit();
            this.ShellContentRegion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonPanelRegion;
        private System.Windows.Forms.Panel ToolbarRegion;
        private System.Windows.Forms.SplitContainer ShellContentRegion;
    }
}