// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateFolderCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the CreateFolderCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Commands
{
    using Events;

    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    /// <summary>The create folder message.</summary>
    public class CreateFolderCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>Initializes a new instance of the <see cref="CreateFolderCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public CreateFolderCommand(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.Icon = Resource.Run24;
            this.ToolTip = LocalizationStrings.CreateFolder;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            this.eventAggregator.Publish(new CreateFolderMessage());
        }
    }
}