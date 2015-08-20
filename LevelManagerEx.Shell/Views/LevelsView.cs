// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelsView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Views
{
    using System;
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The levels view.</summary>
    public partial class LevelsView : UserControl, ILevelsView
    {
        /// <summary>Initializes a new instance of the <see cref="LevelsView"/> class.</summary>
        public LevelsView()
        {
            this.InitializeComponent();

            this.Tree.AfterSelect += (s, e) => this.OnSelectionChanged();
            this.Tree.ItemDrag += (s, e) => this.OnLevelDrag();
            this.Tree.DragDrop += (s, e) => this.OnLevelDragDrop();
            this.Tree.DragEnter += (s, e) => this.OnLevelDragEnter();

            this.Load += (s, e) => this.OnViewLoad();
        }

        #region Public Events

        /// <summary>The selection changed.</summary>
        public event EventHandler SelectionChanged;

        /// <summary>The view load.</summary>
        public event EventHandler ViewLoad;

        /// <summary>The level drag enter.</summary>
        public event EventHandler LevelDragEnter;

        /// <summary>The level drag drop.</summary>
        public event EventHandler LevelDragDrop;

        /// <summary>The level drag.</summary>
        public event EventHandler LevelDrag;

        #endregion

        #region Public Methods

        /// <summary>The select node.</summary>
        /// <param name="key">The key.</param>
        public void SelectNode(string key)
        {
            this.Tree.SelectedNode = this.Tree.Nodes[key];
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the selected node.</summary>
        public TreeNode SelectedNode => this.Tree.SelectedNode;

        /// <summary>
        /// Gets the levels treeview (used to set images list)
        /// </summary>
        public TreeView LevelsTree => this.Tree;

        #endregion

        #region Protected Methods

        /// <summary>The on selection changed.</summary>
        protected virtual void OnSelectionChanged()
        {
            var handler = this.SelectionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnViewLoad()
        {
            var handler = this.ViewLoad;
            handler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLevelDragEnter()
        {
            var handler = this.LevelDragEnter;
            handler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLevelDragDrop()
        {
            var handler = this.LevelDragDrop;
            handler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLevelDrag()
        {
            var handler = this.LevelDrag;
            handler?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
