using System;
using HandicapMobile.ViewModels;

namespace HandicapMobile.Pages
{
    public interface IRegisterClubPage2 : IPage
    {
        /// <summary>
        /// Occurs when [lookup address button click].
        /// </summary>
        event EventHandler LookupAddressButtonClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(RegisterClubPage2ViewModel viewModel);
    }
}