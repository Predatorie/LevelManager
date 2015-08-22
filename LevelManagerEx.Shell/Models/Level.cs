// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the Level type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Models
{
    /// <summary>The level.</summary>
    public class Level : ILevel
    {
        /// <summary>Gets or sets the number.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets a value indicating whether visible.</summary>
        public bool Visible { get; set; }

        /// <summary>Gets or sets the entities.</summary>
        public long Entities { get; set; }

        /// <summary>Gets or sets the set name.</summary>
        public string SetName { get; set; }

        /// <summary>Gets or sets a value indicating whether is main level.</summary>
        public bool IsMainLevel { get; set; }
    }
}