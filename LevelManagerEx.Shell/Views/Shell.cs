// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Shell.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Commands;
    using Events;
    using Interfaces;
    using Presenters;
    using Services;

    using Reactive.EventAggregator;

    /// <summary>The shell.</summary>
    public partial class Shell : Form, IShellView
    {
        #region Fields

        /// <summary>The button bar view.</summary>
        private readonly ButtonView buttonView;

        /// <summary>The toolbar view.</summary>
        private readonly ToolbarView toolbarView;

        /// <summary>The levels view.</summary>
        private readonly LevelsView levelsView;

        /// <summary>The operations view.</summary>
        private readonly InformationView informationView;

        /// <summary>
        /// The Event Aggregator singleton
        /// </summary>
        private readonly IEventAggregator aggregator;

        #endregion

        /// <summary>Initializes a new instance of the <see cref="Shell"/> class.</summary>
        /// <param name="msgBoxService">The msg Box Service.</param>
        /// <param name="eventAggregator"></param>
        /// <param name="commands">The commands.</param>
        /// <param name="fileManagerService">The file Manager Service.</param>
        /// <param name="buttonsCommands">The buttons Commands.</param>
        public Shell(
            IMessageBoxService msgBoxService,
            IEventAggregator eventAggregator,
            List<IToolbarCommand> commands,
            IFileManagerService fileManagerService,
            List<IButtonsCommand> buttonsCommands)
        {
            this.InitializeComponent();

            // Wire up our view presenters
            var toolbarButtonsView = new ToolbarView { Dock = DockStyle.Top };
            var toolbarViewPresenter = new ToolbarPresenter(toolbarButtonsView, commands);

            var buttonCommandView = new ButtonView { Dock = DockStyle.Bottom };
            var buttonCommandViewPresenter = new ButtonsPresenter(buttonCommandView, buttonsCommands);

            var levelsTreeView = new LevelsView { Dock = DockStyle.Fill };
            var levelsTreeViewPresenter = new LevelsViewPresenter(levelsTreeView, msgBoxService, eventAggregator);

            var infoView = new InformationView { Dock = DockStyle.Fill };
            var inforViewPresenter = new InformationViewPresenter(infoView);

            // Wire up our views
            this.toolbarView = toolbarButtonsView;
            this.buttonView = buttonCommandView;
            this.levelsView = levelsTreeView;
            this.informationView = infoView;

            // Wire up our event messaging
            this.aggregator = eventAggregator;
            this.aggregator.GetEvent<CloseShellMessage>().Subscribe(this.OnCloseShell);

            // Place the views in the correct regions
            this.InjectViews();
        }

        public IButtonView ButtonView => this.buttonView;

        public ILevelsView LevelsView => this.levelsView;

        public IInformationView InformationView => this.informationView;

        public IToolbarView ToolbarView => this.toolbarView;

        public IWin32Window WindowHandle => FromHandle(this.Handle);

        private void InjectViews()
        {
            this.ToolbarRegion.Controls.Add(this.toolbarView);
            this.ShellContentRegion.Panel1.Controls.Add(this.levelsView);
            this.ShellContentRegion.Panel2.Controls.Add(this.informationView);
            this.ButtonPanelRegion.Controls.Add(this.buttonView);
        }

        /// <summary>
        /// Closes the main view, called from the button close
        /// </summary>
        /// <param name="e"></param>
        private void OnCloseShell(CloseShellMessage e)
        {
            this.Close();
        }
    }
}
