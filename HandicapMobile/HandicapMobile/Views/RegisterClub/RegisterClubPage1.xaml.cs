using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandicapMobile.Pages;
using HandicapMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandicapMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterClubPage1 : ContentPage, IRegisterClubPage1
	{
        /// <summary>
        /// The view model
        /// </summary>
        private RegisterClubPage1ViewModel ViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterClubPage"/> class.
        /// </summary>
        public RegisterClubPage1()
		{
			InitializeComponent();

		    txtClubName.Focus();
            btnNext.Clicked += BtnNext_Clicked;
		}

        /// <summary>
        /// Occurs when [register club button click].
        /// </summary>
        public event EventHandler NextButtonClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(RegisterClubPage1ViewModel viewModel)
	    {
	        this.ViewModel = viewModel;

            txtClubName.TextChanged += TxtClubName_TextChanged;
            txtTelephoneNumber.TextChanged += TxtTelephoneNumber_TextChanged;
            txtWebsite.TextChanged += TxtWebsite_TextChanged;
            txtEmailAddress.TextChanged += TxtEmailAddress_TextChanged;
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

        /// <summary>
        /// Handles the TextChanged event of the TxtWebsite control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void TxtWebsite_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.Website = e.NewTextValue;
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
        /// Handles the TextChanged event of the TxtClubName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void TxtClubName_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.ClubName = e.NewTextValue;
        }

        /// <summary>
        /// Handles the Clicked event of the BtnNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnNext_Clicked(Object sender, EventArgs e)
        {
            NextButtonClick(sender, e);
        }
    }
}