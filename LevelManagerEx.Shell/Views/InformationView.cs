// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InformationView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LevelManagerEx.Shell.Views
{
    using System.Windows.Forms;

    using LevelManagerEx.Shell.Interfaces;

    /// <summary>The information view.</summary>
    public partial class InformationView : UserControl, IInformationView
    {
        /// <summary>Initializes a new instance of the <see cref="InformationView"/> class.</summary>
        public InformationView()
        {
            this.InitializeComponent();
        }
    }
}
