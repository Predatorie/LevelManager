﻿namespace LevelManagerEx.Shell.Views
{
    partial class ToolbarView
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
            this.ToolBarButtonsCollection = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // ToolBarButtonsCollection
            // 
            this.ToolBarButtonsCollection.Location = new System.Drawing.Point(0, 0);
            this.ToolBarButtonsCollection.MinimumSize = new System.Drawing.Size(0, 50);
            this.ToolBarButtonsCollection.Name = "ToolBarButtonsCollection";
            this.ToolBarButtonsCollection.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolBarButtonsCollection.Size = new System.Drawing.Size(521, 50);
            this.ToolBarButtonsCollection.TabIndex = 1;
            // 
            // ToolbarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ToolBarButtonsCollection);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(0, 50);
            this.Name = "ToolbarView";
            this.Size = new System.Drawing.Size(521, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBarButtonsCollection;
    }
}
