using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandicapMobile.Pages.Signup;
using HandicapMobile.ViewModels.Signup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandicapMobile.Views.Signup
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    /// <seealso cref="HandicapMobile.Pages.Signup.ISignupPageGolfClubAdministrator1" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignupPageGolfClubAdministrator1 : ContentPage, ISignupPageGolfClubAdministrator1
	{
        /// <summary>
        /// The view model
        /// </summary>
        private SignupPageGolfClubAdministrator1ViewModel ViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupPageGolfClubAdministrator1"/> class.
        /// </summary>
        public SignupPageGolfClubAdministrator1 ()
		{
			InitializeComponent ();
            txtEmailAddress.Focus();
            btnSignup.Clicked += BtnSignup_Clicked;
        }

        /// <summary>
        /// Handles the Clicked event of the BtnSignup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnSignup_Clicked(Object sender, EventArgs e)
        {
            SignUpButtonClick(sender, e);
        }

        /// <summary>
        /// Occurs when [next button click].
        /// </summary>
        public event EventHandler SignUpButtonClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(SignupPageGolfClubAdministrator1ViewModel viewModel)
        {
            this.ViewModel = viewModel;
            txtEmailAddress.TextChanged += TxtEmailAddress_TextChanged;
            txtTelephoneNumber.TextChanged += TxtTelephoneNumber_TextChanged;
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
        /// Handles the TextChanged event of the TxtTelephoneNumber control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void TxtTelephoneNumber_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.TelephoneNumber = e.NewTextValue;
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