// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IButtonView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IButtonView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Interfaces
{
    using System.Collections.Generic;

    using Commands;

    /// <summary>The ButtonView interface.</summary>
    public interface IButtonView
    {
        /// <summary>The set commands.</summary>
        /// <param name="commands">The commands.</param>
        void SetCommands(List<IButtonsCommand> commands);
    }
}