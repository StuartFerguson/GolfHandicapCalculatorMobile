using System;
using HandicapMobile.Pages.SignIn;
using HandicapMobile.ViewModels.Signup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandicapMobile.Views.SignIn
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="HandicapMobile.Pages.SignIn.ISignInPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage, ISignInPage
    {
        /// <summary>
        /// The view model
        /// </summary>
        private SignInPageViewModel ViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPage" /> class.
        /// </summary>
        public SignInPage()
        {
            InitializeComponent();

            btnSignIn.Clicked += BtnSignIn_Clicked;
        }

        /// <summary>
        /// Occurs when [sign in button click].
        /// </summary>
        public event EventHandler SignInButtonClick;

        /// <summary>
        /// Handles the Clicked event of the BtnSignIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void BtnSignIn_Clicked(Object sender, EventArgs e)
        {
            SignInButtonClick(sender, e);
        }

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(SignInPageViewModel viewModel)
        {
            this.ViewModel = viewModel;
            txtEmailAddress.TextChanged += TxtEmailAddress_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        /// <summary>
        /// Handles the TextChanged event of the TxtPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void TxtPassword_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.Password = e.NewTextValue;
        }

        /// <summary>
        /// Handles the TextChanged event of the TxtEmailAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void TxtEmailAddress_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.EmailAddress = e.NewTextValue;
        }
    }
}