using System;
using HandicapMobile.ViewModels;

namespace HandicapMobile.Pages
{
    public interface IRegisterClubPage4 : IPage
    {
        /// <summary>
        /// Occurs when [complete registration].
        /// </summary>
        event EventHandler CompleteRegistration;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(RegisterClubPage4ViewModel viewModel);
    }
}