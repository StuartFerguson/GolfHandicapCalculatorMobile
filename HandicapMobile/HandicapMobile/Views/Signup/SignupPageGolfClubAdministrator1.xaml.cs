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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignupPageGolfClubAdministrator1 : ContentPage, ISignupPageGolfClubAdministrator1
	{
        /// <summary>
        /// The view model
        /// </summary>
        private SignupPageGolfClubAdministrator1ViewModel ViewModel;

		public SignupPageGolfClubAdministrator1 ()
		{
			InitializeComponent ();
            txtEmailAddress.Focus();
            btnSignup.Clicked += BtnSignup_Clicked;
        }

        private void BtnSignup_Clicked(Object sender, EventArgs e)
        {
            SignUpButtonClick(sender, e);
        }

        public event EventHandler SignUpButtonClick;

        public void Init(SignupPageGolfClubAdministrator1ViewModel viewModel)
        {
            this.ViewModel = viewModel;
            txtEmailAddress.TextChanged += TxtEmailAddress_TextChanged;
            txtTelephoneNumber.TextChanged += TxtTelephoneNumber_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        private void TxtPassword_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.Password = e.NewTextValue;
        }

        private void TxtTelephoneNumber_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.TelephoneNumber = e.NewTextValue;
        }

        private void TxtEmailAddress_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.EmailAddress = e.NewTextValue;
        }
    }
}