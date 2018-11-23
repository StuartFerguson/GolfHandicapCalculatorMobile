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
	public partial class RegisterClubPage4 : ContentPage,IRegisterClubPage4
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterClubPage4"/> class.
        /// </summary>
        public RegisterClubPage4 ()
		{
			InitializeComponent ();

            btnComplete.Clicked += BtnComplete_Clicked;
		}

        /// <summary>
        /// Handles the Clicked event of the BtnComplete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnComplete_Clicked(Object sender, EventArgs e)
        {
            CompleteRegistration(sender, e);
        }

        /// <summary>
        /// Occurs when [complete registration].
        /// </summary>
        public event EventHandler CompleteRegistration;

        /// <summary>
        /// Initializes the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Init(RegisterClubPage4ViewModel viewModel)
        {
            lblClubName.Text = $"Club Name: {viewModel.ClubName}";
            lblEmailAddress.Text = $"Email: {viewModel.EmailAddress}";
            lblTelephoneNumber.Text = $"Telephone: {viewModel.TelephoneNumber}";
            lblWebSite.Text = $"Website: {viewModel.Website}";
            StringBuilder addressBuilder = new StringBuilder();
            addressBuilder.AppendLine("Address:");
            addressBuilder.AppendLine(viewModel.Address.AddressLine1);
            addressBuilder.AppendLine(viewModel.Address.AddressLine2);
            addressBuilder.AppendLine(viewModel.Address.TownOrCity);
            addressBuilder.AppendLine(viewModel.Address.County);
            addressBuilder.AppendLine(viewModel.Address.PostalCode);
            lblAddress.Text = addressBuilder.ToString();
        }
    }
}