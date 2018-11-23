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
	public partial class RegisterClubPage2 : ContentPage, IRegisterClubPage2
	{
	    /// <summary>
	    /// The view model
	    /// </summary>
	    private RegisterClubPage2ViewModel ViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterClubPage2"/> class.
        /// </summary>
        public RegisterClubPage2 ()
		{
			InitializeComponent ();

		    txtPostCode.Focus();
            btnLookupAddress.Clicked += BtnLookupAddress_Clicked;
		}

        /// <summary>
        /// Handles the Clicked event of the BtnLookupAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnLookupAddress_Clicked(Object sender, EventArgs e)
        {
            LookupAddressButtonClick(sender, e);
        }

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(RegisterClubPage2ViewModel viewModel)
	    {
	        this.ViewModel = viewModel;

            txtPostCode.TextChanged += TxtPostCode_TextChanged;	        
	    }

        /// <summary>
        /// Handles the TextChanged event of the TxtPostCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void TxtPostCode_TextChanged(Object sender, TextChangedEventArgs e)
        {
            this.ViewModel.PostalCode = e.NewTextValue;
        }

        /// <summary>
        /// Occurs when [lookup address button click].
        /// </summary>
        public event EventHandler LookupAddressButtonClick;
    }
}