// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace LevelManagerEx.Shell.Views
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Commands;
    using Interfaces;

    /// <summary>The button view.</summary>
    public partial class ButtonView : UserControl, IButtonView
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonView"/> class.</summary>
        public ButtonView()
        {
            this.InitializeComponent();
        }

        /// <summary>The set commands.</summary>
        /// <param name="commands">The commands.</param>
        public void SetCommands(List<IButtonsCommand> commands)
        {
            this.Controls.Clear();

            foreach (var command in commands)
            {
                var button = new Button
                {
                    Text = command.ToolTip, 
                    Enabled = command.CanExecute, 
                    Margin = new Padding(2), 
                    Location = command.Location, 
                    Anchor = command.Anchor
                };

                var c = command; // Create a closure around the command
                command.PropertyChanged += (s, e) =>
                {
                    button.Text = c.ToolTip;
                    button.Enabled = c.CanExecute;
                };

                button.Click += (s, e) => c.Execute();

                this.Controls.Add(button);
            }
        }
    }
}
