// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeSelectedMessage.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LevelManagerEx.Shell.Presenters
{
    using System.Windows.Forms;

    /// <summary>The node selected message.</summary>
    public class NodeSelectedMessage
    {
        /// <summary>Initializes a new instance of the <see cref="NodeSelectedMessage"/> class.</summary>
        /// <param name="node">The node.</param>
        public NodeSelectedMessage(TreeNode node)
        {
            this.Node = node;
        }

        /// <summary>Gets the level.</summary>
        public TreeNode Node { get; private set; }
    }
}