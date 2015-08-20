// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IToolbarView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IToolbarView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Interfaces
{
    using System.Collections.Generic;

    using Commands;

    /// <summary>The ToolbarView interface.</summary>
    public interface IToolbarView
    {
        /// <summary>The set commands.</summary>
        /// <param name="commands">The commands.</param>
        void SetCommands(List<IToolbarCommand> commands);
    }
}