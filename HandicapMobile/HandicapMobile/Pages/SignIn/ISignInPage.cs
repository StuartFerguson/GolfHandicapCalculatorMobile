using System;
using System.Collections.Generic;
using System.Text;
using HandicapMobile.ViewModels.Signup;

namespace HandicapMobile.Pages.SignIn
{
    public interface ISignInPage : IPage
    {
        /// <summary>
        /// Occurs when [sign in button click].
        /// </summary>
        event EventHandler SignInButtonClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        void Init(SignInPageViewModel viewModel);
    }
}
