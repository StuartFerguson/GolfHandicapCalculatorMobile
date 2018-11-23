using System;
using System.Threading;
using System.Threading.Tasks;
using HandicapMobile.Common;
using HandicapMobile.ManagementAPI;
using HandicapMobile.ManagementAPI.DataTransferObjects;
using HandicapMobile.Pages;
using HandicapMobile.ViewModels;

namespace HandicapMobile.Presenters
{
    public class RegisterClubPresenter : IRegisterClubPresenter
    {
        #region Fields

        /// <summary>
        /// The navigation service
        /// </summary>
        private readonly INavigationService NavigationService;

        /// <summary>
        /// The register club page1
        /// </summary>
        private readonly IRegisterClubPage1 RegisterClubPage1;

        /// <summary>
        /// The register club page2
        /// </summary>
        private readonly IRegisterClubPage2 RegisterClubPage2;

        /// <summary>
        /// The register club page3
        /// </summary>
        private readonly IRegisterClubPage3 RegisterClubPage3;

        /// <summary>
        /// The register club page4
        /// </summary>
        private readonly IRegisterClubPage4 RegisterClubPage4;

        /// <summary>
        /// The register club page1 view model
        /// </summary>
        private readonly RegisterClubPage1ViewModel RegisterClubPage1ViewModel;

        /// <summary>
        /// The register club page2 view model
        /// </summary>
        private readonly RegisterClubPage2ViewModel RegisterClubPage2ViewModel;

        /// <summary>
        /// The register club page3 view model
        /// </summary>
        private readonly RegisterClubPage3ViewModel RegisterClubPage3ViewModel;

        /// <summary>
        /// The register club page4 view model
        /// </summary>
        private readonly RegisterClubPage4ViewModel RegisterClubPage4ViewModel;

        /// <summary>
        /// The management API service
        /// </summary>
        private readonly IManagementAPIService ManagementApiService;

        /// <summary>
        /// The address lookup service
        /// </summary>
        private readonly IAddressLookupService AddressLookupService;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterClubPresenter" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="registerClubPage1">The register club page1.</param>
        /// <param name="page1ViewModel">The page1 view model.</param>
        /// <param name="registerClubPage2">The register club page2.</param>
        /// <param name="page2ViewModel">The page2 view model.</param>
        /// <param name="registerClubPage3">The register club page3.</param>
        /// <param name="page3ViewModel">The page3 view model.</param>
        /// <param name="registerClubPage4">The register club page4.</param>
        /// <param name="page4ViewModel">The page4 view model.</param>
        /// <param name="managementApiService">The management API service.</param>
        /// <param name="addressLookupService">The address lookup service.</param>
        public RegisterClubPresenter(INavigationService navigationService, 
            IRegisterClubPage1 registerClubPage1, RegisterClubPage1ViewModel page1ViewModel, 
            IRegisterClubPage2 registerClubPage2, RegisterClubPage2ViewModel page2ViewModel, 
            IRegisterClubPage3 registerClubPage3, RegisterClubPage3ViewModel page3ViewModel, 
            IRegisterClubPage4 registerClubPage4, RegisterClubPage4ViewModel page4ViewModel, 
            IManagementAPIService managementApiService,
            IAddressLookupService addressLookupService)
        {
            this.NavigationService = navigationService;
            this.RegisterClubPage1 = registerClubPage1;
            this.RegisterClubPage2 = registerClubPage2;
            this.RegisterClubPage3 = registerClubPage3;
            this.RegisterClubPage4 = registerClubPage4;
            this.RegisterClubPage1ViewModel = page1ViewModel;
            this.RegisterClubPage2ViewModel = page2ViewModel;
            this.RegisterClubPage3ViewModel = page3ViewModel;
            this.RegisterClubPage4ViewModel = page4ViewModel;
            this.ManagementApiService = managementApiService;
            this.AddressLookupService = addressLookupService;
        }
        #endregion

        #region Public Methods

        #region public async Task Start()        
        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            this.RegisterClubPage1.NextButtonClick += RegisterClubPage1_NextButtonClick;
            this.RegisterClubPage1.Init(this.RegisterClubPage1ViewModel);            
            await this.NavigationService.Push(this.RegisterClubPage1);
        }
        #endregion

        #endregion

        #region Private Methods

        #region private async void RegisterClubPage1_NextButtonClick(object sender, EventArgs e)        
        /// <summary>
        /// Handles the NextButtonClick event of the RegisterClubPage1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RegisterClubPage1_NextButtonClick(Object sender, EventArgs e)
        {
            this.RegisterClubPage2.LookupAddressButtonClick += RegisterClubPage2_LookupAddressButtonClick; 
            this.RegisterClubPage2.Init(this.RegisterClubPage2ViewModel);
            await this.NavigationService.Push(this.RegisterClubPage2);

        }
        #endregion

        #region private async void RegisterClubPage2_LookupAddressButtonClick(object sender, EventArgs e)        
        /// <summary>
        /// Handles the LookupAddressButtonClick event of the RegisterClubPage2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RegisterClubPage2_LookupAddressButtonClick(Object sender, EventArgs e)
        {
            var addresses = await this.AddressLookupService.GetAddress(this.RegisterClubPage2ViewModel.PostalCode);
            this.RegisterClubPage3ViewModel.Addresses = addresses;
            this.RegisterClubPage3.AddressSelectedClick += RegisterClubPage3_AddressSelectedClick;
            this.RegisterClubPage3.Init(this.RegisterClubPage3ViewModel);
            await this.NavigationService.Push(this.RegisterClubPage3);
        }
        #endregion

        #region private async void RegisterClubPage3_AddressSelectedClick(object sender, EventArgs e)        
        /// <summary>
        /// Handles the AddressSelectedClick event of the RegisterClubPage3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RegisterClubPage3_AddressSelectedClick(Object sender, EventArgs e)
        {
            this.RegisterClubPage4ViewModel.ClubName = this.RegisterClubPage1ViewModel.ClubName;
            this.RegisterClubPage4ViewModel.TelephoneNumber = this.RegisterClubPage1ViewModel.TelephoneNumber;
            this.RegisterClubPage4ViewModel.Website = this.RegisterClubPage1ViewModel.Website;
            this.RegisterClubPage4ViewModel.EmailAddress = this.RegisterClubPage1ViewModel.EmailAddress;

            this.RegisterClubPage4ViewModel.Address = this.RegisterClubPage3ViewModel.SelectedAddress;
            this.RegisterClubPage4.Init(this.RegisterClubPage4ViewModel);
            this.RegisterClubPage4.CompleteRegistration += RegisterClubPage4_CompleteRegistration;
            await this.NavigationService.Push(this.RegisterClubPage4);
        }
        #endregion

        #region private async void RegisterClubPage4_CompleteRegistration(object sender, EventArgs e)        
        /// <summary>
        /// Handles the CompleteRegistration event of the RegisterClubPage4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void RegisterClubPage4_CompleteRegistration(Object sender, EventArgs e)
        {
            try
            {
                CreateClubConfigurationRequest request = new CreateClubConfigurationRequest
                {
                    Name = this.RegisterClubPage4ViewModel.ClubName,
                    AddressLine1 = this.RegisterClubPage4ViewModel.Address.AddressLine1,
                    EmailAddress = this.RegisterClubPage4ViewModel.EmailAddress,
                    PostalCode = this.RegisterClubPage4ViewModel.Address.PostalCode,
                    Town = this.RegisterClubPage4ViewModel.Address.TownOrCity,
                    Website = this.RegisterClubPage4ViewModel.Website,
                    Region = this.RegisterClubPage4ViewModel.Address.County,
                    TelephoneNumber = this.RegisterClubPage4ViewModel.TelephoneNumber,
                    AddressLine2 = this.RegisterClubPage4ViewModel.Address.AddressLine2
                };

                var response = await this.ManagementApiService.CreateClubConfiguration(request, CancellationToken.None);

                await App.Current.MainPage.DisplayAlert("Success",
                    $"Club {this.RegisterClubPage4ViewModel.ClubName} Registered Successfully", "OK");

                await this.NavigationService.PopToRootPage();
            }
            catch (Exception ex)
            {
                // TODO: log the error
                await App.Current.MainPage.DisplayAlert("Failure",
                    $"Club {this.RegisterClubPage4ViewModel.ClubName} Registration Failed", "OK");
            }
        }
        #endregion

        #endregion        
    }
}