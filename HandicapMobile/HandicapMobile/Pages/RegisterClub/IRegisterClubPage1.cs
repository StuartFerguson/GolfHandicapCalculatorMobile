using System;
using HandicapMobile.ViewModels;

namespace HandicapMobile.Pages
{
    public interface IRegisterClubPage1 : IPage
    {
        /// <summary>
        /// Occurs when [next button click].
        /// </summary>
        event EventHandler NextButtonClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(RegisterClubPage1ViewModel viewModel);
    }
}