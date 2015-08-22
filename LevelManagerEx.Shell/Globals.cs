// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Globals.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the Globals type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell
{
    /// <summary>The tree icon index.</summary>
    public enum TreeIconIndex
    {
        /// <summary>The operations.</summary>
        MainLevel = 0,

        /// <summary>The folder.</summary>
        Folder ,

        Level
    }

    /// <summary>The globals.</summary>
    public static class Globals
    {
        /// <summary>The folder id.</summary>
        public const string NodeTypeFolder = "FOLDER";
    }
}