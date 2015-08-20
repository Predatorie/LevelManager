// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LevelManagerEx.Shell.Views
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Commands;
    using Interfaces;

    /// <summary>The toolbar view.</summary>
    public partial class ToolbarView : UserControl, IToolbarView
    {
        /// <summary>Initializes a new instance of the <see cref="ToolbarView"/> class.</summary>
        public ToolbarView()
        {
            this.InitializeComponent();
        }

        /// <summary>The set commands.</summary>
        /// <param name="commands">The commands.</param>
        public void SetCommands(List<IToolbarCommand> commands)
        {
            this.ToolBarButtonsCollection.Items.Clear();
            foreach (var command in commands)
            {
                var button = new ToolStripButton
                {
                    Text = command.ToolTip, 
                    Image = command.Icon, 
                    Enabled = command.CanExecute, 
                    ImageScaling = ToolStripItemImageScaling.None, 
                    DisplayStyle = ToolStripItemDisplayStyle.ImageAndText, 
                    TextImageRelation = TextImageRelation.ImageAboveText, 
                    Margin = new Padding(2)
                };

                var c = command; // Create a closure around the command
                command.PropertyChanged += (s, e) =>
                {
                    button.Text = c.ToolTip;
                    button.Image = c.Icon;
                    button.Enabled = c.CanExecute;
                };

                button.Click += (s, e) => c.Execute();

                this.ToolBarButtonsCollection.Items.Add(button);
            }
        }
    }
}
