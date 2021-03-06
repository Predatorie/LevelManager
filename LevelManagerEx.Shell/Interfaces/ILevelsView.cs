﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILevelsView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the ILevelsView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Interfaces
{
    using System;
    using System.Windows.Forms;

    /// <summary>The LevelsView interface.</summary>
    public interface ILevelsView
    {
        /// <summary>The selection changed.</summary>
        event EventHandler SelectionChanged;

        /// <summary>The view loaded.</summary>
        event EventHandler ViewLoad;

        /// <summary>The drag drop.</summary>
        event EventHandler LevelDragEnter;

        /// <summary>The item drag.</summary>
        event EventHandler LevelDragDrop;

        /// <summary>The drag enter.</summary>
        event EventHandler LevelDrag;

        /// <summary>The after label edit.</summary>
        event EventHandler AfterLabelEdit;

        /// <summary>Gets the selected node.</summary>
        TreeNode SelectedNode { get; }

        /// <summary>Gets the tree.</summary>
        TreeView LevelsTree { get; }

        /// <summary>The select level node.</summary>
        /// <param name="key">The key.</param>
        void SelectNode(string key);
    }
}