// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellModules.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the ShellModules type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Models
{
    using Commands;

    using Interfaces;

    using Ninject.Modules;

    using Reactive.EventAggregator;

    using Services;

    using Views;

    /// <summary>The shell modules.</summary>
    public class ShellModules : NinjectModule
    {
        /// <summary>The load.</summary>
        public override void Load()
        {
            this.Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            this.Kernel.Bind<IMessageBoxService>().To<MessageBoxService>().InSingletonScope();
            this.Kernel.Bind<IFileManagerService>().To<FileManagerService>().InSingletonScope();
            this.Kernel.Bind<ISystemInformationService>().To<SystemInformationService>().InSingletonScope();

            // Bottom buttons
            this.Kernel.Bind<IButtonsCommand>().To<CloseShellCommand>().InSingletonScope();

            // Toolbars
            this.Kernel.Bind<IToolbarCommand>().To<CreateFolderCommand>().InSingletonScope();

            this.Kernel.Bind<IButtonView>().To<ButtonView>().InSingletonScope();
            this.Kernel.Bind<ILevelsView>().To<LevelsView>().InSingletonScope();
            this.Kernel.Bind<IToolbarView>().To<ToolbarView>().InSingletonScope();
            this.Kernel.Bind<IShellView>().To<Shell>().InSingletonScope();

            this.Kernel.Bind<ILevel>().To<Level>();
        }
    }
}