﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IToolbarCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IToolbarCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Commands
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>The ToolbarCommand interface.</summary>
    public interface IToolbarCommand : ICommandBase
    {
        /// <summary>Gets or sets the parent.</summary>
        IWin32Window Parent { get; set; }

        /// <summary>Gets or sets the icon.</summary>
        Image Icon { get; set; }
    }
}