// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILevel.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LevelManagerEx.Shell.Models
{
    /// <summary>The Level interface.</summary>
    public interface ILevel
    {
        /// <summary>Gets or sets the number.</summary>
        int Number { get; set; }

        /// <summary>Gets or sets the name.</summary>
        string Name { get; set; }

        /// <summary>Gets or sets a value indicating whether visible.</summary>
        bool Visible { get; set; }

        /// <summary>Gets or sets the entities.</summary>
        long Entities { get; set; }

        /// <summary>Gets or sets the set name.</summary>
        string SetName { get; set; }

        /// <summary>Gets or sets a value indicating whether is main level.</summary>
        bool IsMainLevel { get; set; }
    }
}