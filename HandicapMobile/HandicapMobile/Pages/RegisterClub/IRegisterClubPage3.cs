using System;
using HandicapMobile.ViewModels;

namespace HandicapMobile.Pages
{
    public interface IRegisterClubPage3 : IPage
    {
        /// <summary>
        /// Occurs when [address selected click].
        /// </summary>
        event EventHandler AddressSelectedClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(RegisterClubPage3ViewModel viewModel);
    }
}