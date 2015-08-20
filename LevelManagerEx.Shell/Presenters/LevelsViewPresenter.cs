// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelsViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LevelManagerEx.Shell.Presenters
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using LevelManagerEx.Shell.Interfaces;
    using LevelManagerEx.Shell.Services;

    using Mastercam.IO;
    using Mastercam.Operations;
    using Mastercam.Support;

    using Reactive.EventAggregator;

    /// <summary>The levels view presenter.</summary>
    internal class LevelsViewPresenter
    {
        /// <summary>The levels tree view.</summary>
        private readonly ILevelsView view;

        /// <summary>The event aggregator.</summary>
        private IEventAggregator eventAggregator;

        /// <summary>The msg box service.</summary>
        private IMessageBoxService msgBoxService;

        /// <summary>Initializes a new instance of the <see cref="LevelsViewPresenter"/> class.</summary>
        /// <param name="view">The levels tree view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public LevelsViewPresenter(ILevelsView view, IMessageBoxService msgBoxService, IEventAggregator eventAggregator)
        {
            this.msgBoxService = msgBoxService;
            this.eventAggregator = eventAggregator;

            this.view = view;
            view.ViewLoad += this.LevelsViewOnViewLoad;
            view.SelectionChanged += this.LevelsViewOnSelectionChanged;
            view.LevelsTree.ItemDrag += this.OnLevelItemDrag;
            view.LevelsTree.DragDrop += this.OnLevelDragDrop;
            view.LevelsTree.DragEnter += this.OnLevelDragEnter;
            view.LevelsTree.AllowDrop = true;
        }

        #region Event Handlers

        /// <summary>The on level drag drop.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnLevelDragDrop(object sender, DragEventArgs e)
        {
        }

        /// <summary>The on level drag enter.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnLevelDragEnter(object sender, DragEventArgs e)
        {
        }

        /// <summary>The on level item drag.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnLevelItemDrag(object sender, ItemDragEventArgs e)
        {
        }

        /// <summary>The levels view on selection changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
        }

        /// <summary>The levels view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnViewLoad(object sender, EventArgs eventArgs)
        {
            var levelNumbers = LevelsManager.GetActiveLevelNumbers();

            if (levelNumbers.Any())
            {
                Array.Sort(levelNumbers);

                var mainLevel = new TreeNode("Levels");

                for (var i = 0; i < levelNumbers.Count(); i++)
                {
                    var levelNumber = i;
                    var levelName = LevelsManager.GetLevelName(levelNumber);
                    var levelIsVisible = LevelsManager.IsLevelVisible(levelNumber);
                    var levelSetName = LevelsManager.GetLevelSetName(levelNumber);
                    var entities = SearchManager.GetGeometry(levelNumber);

                    var display = levelNumber.ToString();

                    if (!string.IsNullOrEmpty(levelName))
                    {
                        display += "   [" + levelName + "]";
                    }

                    if (!string.IsNullOrEmpty(levelSetName))
                    {
                        display += "  [" + levelSetName + "]";
                    }

                    if (entities.Any())
                    {
                        display += "  [" + entities.Count() + "]";
                    }

                    var node = new TreeNode(display) { Tag = levelIsVisible };
                    mainLevel.Nodes.Add(node);
                }

                this.view.LevelsTree.Nodes.Add(mainLevel);
                this.view.LevelsTree.Nodes[0].Expand();
            }
        }

        #endregion
    }
}