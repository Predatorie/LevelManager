// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInformationService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Services
{
    using System.Windows.Forms;

    /// <summary>The system information service.</summary>
    class SystemInformationService : ISystemInformationService
    {
        /// <summary>The is high contrast colour scheme.</summary>
        public bool IsHighContrastColourScheme => SystemInformation.HighContrast;
    }
}