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
    using System.IO;
    using System.Linq;

    using Events;

    using FunctionTable;

    using Localization;

    using Mastercam.IO.Types;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The create folder message.</summary>
    public class CreateFolderCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The file browser service.</summary>
        private readonly IMessageBoxService messageBoxService;

        /// <summary>Initializes a new instance of the <see cref="CreateFolderCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="messageBox">The message Box.</param>
        public CreateFolderCommand(IEventAggregator eventAggregator, IMessageBoxService messageBox)
        {
            this.eventAggregator = eventAggregator;
            this.messageBoxService = messageBox;

            this.Icon = Resource.FileOpen32;
            this.ToolTip = LocalizationStrings.CreateFolder;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            var name = string.Empty;
            if (this.messageBoxService.AskForString(LocalizationStrings.SetFolderName, ref name) != DialogReturnType.Okay)
            {
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            // Sanity Check
            var invalids = Path.GetInvalidFileNameChars();
            name = invalids.Aggregate(name, (current, c) => current.Replace(c.ToString(), "_"));

            this.eventAggregator.Publish(new CreateFolderMessage { Name = name });
        }
    }
}