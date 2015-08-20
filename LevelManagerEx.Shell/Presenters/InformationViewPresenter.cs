// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InformationViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the InformationViewPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Presenters
{
    using Views;

    /// <summary>The information view presenter.</summary>
    internal class InformationViewPresenter
    {
        /// <summary>The info view.</summary>
        private InformationView infoView;

        /// <summary>Initializes a new instance of the <see cref="InformationViewPresenter"/> class.</summary>
        /// <param name="infoView">The info view.</param>
        public InformationViewPresenter(InformationView infoView)
        {
            this.infoView = infoView;
        }
    }
}