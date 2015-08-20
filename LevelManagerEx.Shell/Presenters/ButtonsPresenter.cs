// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonsPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LevelManagerEx.Shell.Presenters
{
    using System.Collections.Generic;

    using Commands;
    using Interfaces;

    /// <summary>The buttons presenter.</summary>
    public class ButtonsPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IButtonView view;

        #endregion
        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ButtonsPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="commands">The commands.</param>
        public ButtonsPresenter(
            IButtonView view, 
            List<IButtonsCommand> commands)
        {
            this.view = view;
            view.SetCommands(commands);
        }

        #endregion
    }
}