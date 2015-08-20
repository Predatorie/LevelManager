// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IButtonsCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IButtonsCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Commands
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>The ButtonsCommand interface.</summary>
    public interface IButtonsCommand : ICommandBase
    {
        /// <summary>Gets or sets the location.</summary>
        Point Location { get; set; }

        /// <summary>Gets or sets the anchor.</summary>
        AnchorStyles Anchor { get; set; }
    }
}