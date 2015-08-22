// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelsViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Presenters
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using Events;
    using FunctionTable;
    using Interfaces;
    using Localization;
    using Models;
    using Services;

    using Mastercam.IO;
    using Mastercam.Support;

    using Reactive.EventAggregator;

    /// <summary>The levels view presenter.</summary>
    internal class LevelsViewPresenter
    {
        /// <summary>The levels tree view.</summary>
        private readonly ILevelsView view;

        /// <summary>The msg box service.</summary>
        private IMessageBoxService msgBoxService;

        private readonly IEventAggregator eventAggregator;

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
            view.LevelDrag += this.OnLevelItemDrag;
            view.LevelDragDrop += this.OnLevelDragDrop;
            view.LevelDragEnter += this.OnLevelDragEnter;
            view.AfterLabelEdit += this.OnAfterLabelEdit;

            this.eventAggregator.GetEvent<CreateFolderMessage>().Subscribe(this.OnCreateFolderMessage);
        }

        #region Event Handlers      

        private void OnAfterLabelEdit(object sender, EventArgs arg)
        {
            var e = arg as NodeLabelEditEventArgs;

            if (e?.Node?.Tag.GetType() == typeof(Level) || e?.Node?.Level == 0)
            {
                e.CancelEdit = true;
            }
        }

        private void OnCreateFolderMessage(CreateFolderMessage e)
        {
            // TODO: Check for duplicate
            var folder = new TreeNode(e.Name, (int)TreeIconIndex.Folder, (int)TreeIconIndex.Folder) { Tag = Globals.NodeTypeFolder };
            this.view.LevelsTree.Nodes[0].Nodes.Add(folder);
            folder.EnsureVisible();
        }

        /// <summary>The on level drag drop.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="arg"></param>
        private void OnLevelDragDrop(object sender, EventArgs arg)
        {
            var e = arg as DragEventArgs;

            // Retrieve the node that was dragged.
            var draggedNode = (TreeNode)e?.Data.GetData(typeof(TreeNode));

            if (draggedNode?.Tag == null)
            {
                return;
            }

            // Retrieve the client coordinates of the drop location.
            var targetPoint = this.view.LevelsTree.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            var targetNode = this.view.LevelsTree.GetNodeAt(targetPoint);

            // Confirm that the node at the drop location is not the dragged node 
            // and that target node isn't null (for example if you drag outside the control)
            if (draggedNode.Equals(targetNode) || targetNode == null)
            {
                return;
            }

            var clone = (TreeNode)draggedNode.Clone();

            // A Level
            if (draggedNode.Tag.GetType() == typeof(Level))
            {
                // Can only drop on a Folder node
                if (targetNode.Tag.GetType() == typeof(Level))
                {
                    return;
                }
            }

            draggedNode.Remove();
            targetNode.Nodes.Add(clone);
            targetNode.Expand();
        }

        /// <summary>The on level drag enter.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="arg">The payload.</param>
        private void OnLevelDragEnter(object sender, EventArgs arg)
        {
            var e = arg as DragEventArgs;
            var draggedNode = (TreeNode)e?.Data.GetData(typeof(TreeNode));

            if (draggedNode?.Tag != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>The on level item drag.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="arg">The payload.</param>
        private void OnLevelItemDrag(object sender, EventArgs arg)
        {
            var e = arg as ItemDragEventArgs;
            var item = (TreeNode)e?.Item;

            if (item?.Parent != null)
            {
                if (item.Parent?.Text != LocalizationStrings.LEVELS)
                {
                    this.view.LevelsTree.DoDragDrop(e.Item, DragDropEffects.Move);
                }
            }
        }

        /// <summary>The levels view on selection changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            var node = this.view.SelectedNode;
            this.eventAggregator.Publish(new NodeSelectedMessage(node));
        }

        /// <summary>The levels view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnViewLoad(object sender, EventArgs eventArgs)
        {
            this.LoadImages();

            var levelNumbers = LevelsManager.GetActiveLevelNumbers();

            if (levelNumbers.Any())
            {
                Array.Sort(levelNumbers);

                // Cache enities
                var cacheEntities = SearchManager.GetGeometry();
                var main = LevelsManager.GetMainLevel();

                var drawing = FileManager.CurrentFileName;

                drawing = string.IsNullOrEmpty(drawing) ? LocalizationStrings.LEVELS : Path.GetFileName(drawing);

                // Top most node
                var mainLevel = new TreeNode(drawing, (int)TreeIconIndex.MainLevel, (int)TreeIconIndex.MainLevel);

                for (var i = 0; i < levelNumbers.Count(); i++)
                {
                    // Query the cached data
                    var entities = cacheEntities.Where(e => e.Level == i).ToList().Count;

                    var level = new Level
                    {
                        Entities = entities,
                        Name = LevelsManager.GetLevelName(i),
                        Number = i,
                        SetName = LevelsManager.GetLevelSetName(i),
                        Visible = LevelsManager.IsLevelVisible(i),
                        IsMainLevel = i == main
                    };

                    // Level node
                    var node = new TreeNode($"{level.Number.ToString().PadRight(5)} {level.Name}", (int)TreeIconIndex.Level, (int)TreeIconIndex.Level) { Tag = level };
                    mainLevel.Nodes.Add(node);
                }

                this.view.LevelsTree.Nodes.Add(mainLevel);
                this.view.LevelsTree.Nodes[0].Expand();
            }
        }

        private void LoadImages()
        {
            var list = new ImageList();

            list.Images.Add(Resource.LevelManager16);
            list.Images.Add(Resource.FileOpen16);
            list.Images.Add(Resource.Level);

            this.view.LevelsTree.ImageList = list;
        }

        #endregion
    }
}