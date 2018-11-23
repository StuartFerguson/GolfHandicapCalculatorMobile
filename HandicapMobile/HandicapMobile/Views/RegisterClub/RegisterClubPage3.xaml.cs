using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandicapMobile.Common;
using HandicapMobile.Pages;
using HandicapMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandicapMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterClubPage3 : ContentPage, IRegisterClubPage3
	{
        /// <summary>
        /// The view model
        /// </summary>
        private RegisterClubPage3ViewModel ViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterClubPage3"/> class.
        /// </summary>
        public RegisterClubPage3 ()
		{
			InitializeComponent ();
		}

        /// <summary>
        /// Occurs when [address selected click].
        /// </summary>
        public event EventHandler AddressSelectedClick;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(RegisterClubPage3ViewModel viewModel)
        {
            this.ViewModel = viewModel;
            listAddress.ItemsSource = viewModel.Addresses;
            listAddress.ItemTapped += ListAddress_ItemTapped;
        }

        /// <summary>
        /// Handles the ItemTapped event of the ListAddress control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemTappedEventArgs"/> instance containing the event data.</param>
        private void ListAddress_ItemTapped(Object sender, ItemTappedEventArgs e)
        {
            this.ViewModel.SelectedAddress = e.Item as Address;
            AddressSelectedClick(sender, e);
        }
    }
}