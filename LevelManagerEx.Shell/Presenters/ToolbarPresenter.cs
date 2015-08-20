// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LevelManagerEx.Shell.Presenters
{
    using System.Collections.Generic;

    using Commands;
    using Interfaces;

    /// <summary>The toolbar presenter.</summary>
    public class ToolbarPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IToolbarView view;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ToolbarPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="commands">The commands.</param>
        public ToolbarPresenter(IToolbarView view, List<IToolbarCommand> commands)
        {
            this.view = view;
            view.SetCommands(commands);
        }

        #endregion

    }
}