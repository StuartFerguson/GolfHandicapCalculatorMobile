using System;
using HandicapMobile.ViewModels.Signup;

namespace HandicapMobile.Pages.Signup
{
    public interface ISignupPageGolfClubAdministrator1 : IPage
    {
        /// <summary>
        /// Occurs when [next button click].
        /// </summary>
        event EventHandler SignUpButtonClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(SignupPageGolfClubAdministrator1ViewModel viewModel);
    }
}