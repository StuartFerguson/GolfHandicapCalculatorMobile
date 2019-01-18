using System;
using System.Threading;
using System.Threading.Tasks;
using HandicapMobile.Common;
using HandicapMobile.Pages.Signup;
using HandicapMobile.ViewModels.Signup;
using ManagementAPI.Service.Client;
using ManagementAPI.Service.DataTransferObjects;
using Xamarin.Forms;

namespace HandicapMobile.Presenters.Signup
{
    public class SignupPresenter : ISignupPresenter
    {
        #region Fields

        /// <summary>
        /// The navigation service
        /// </summary>
        private readonly INavigationService NavigationService;

        /// <summary>
        /// The signup page1
        /// </summary>
        private readonly ISignupPage1 SignupPage1;

        /// <summary>
        /// The signup page golf club administrator1
        /// </summary>
        private readonly ISignupPageGolfClubAdministrator1 SignupPageGolfClubAdministrator1;

        /// <summary>
        /// The signup page golf club administrator1 view model
        /// </summary>
        private readonly SignupPageGolfClubAdministrator1ViewModel SignupPageGolfClubAdministrator1ViewModel;

        /// <summary>
        /// The golf club client
        /// </summary>
        private readonly IGolfClubClient GolfClubClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupPresenter" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="signupPage1">The signup page1.</param>
        /// <param name="signupPageGolfClubAdministrator1">The signup page golf club administrator1.</param>
        /// <param name="signupPageGolfClubAdministrator1ViewModel">The signup page golf club administrator1 view model.</param>
        /// <param name="golfClubClient">The golf club client.</param>
        public SignupPresenter(INavigationService navigationService, ISignupPage1 signupPage1,
            ISignupPageGolfClubAdministrator1 signupPageGolfClubAdministrator1, 
            SignupPageGolfClubAdministrator1ViewModel signupPageGolfClubAdministrator1ViewModel,
            IGolfClubClient golfClubClient)
        {
            this.NavigationService = navigationService;
            this.SignupPage1 = signupPage1;
            this.SignupPageGolfClubAdministrator1 = signupPageGolfClubAdministrator1;
            this.SignupPageGolfClubAdministrator1ViewModel = signupPageGolfClubAdministrator1ViewModel;
            this.GolfClubClient = golfClubClient;
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
            this.SignupPage1.GolfClubAdministratorButtonClick += SignupPage1_GolfClubAdministratorButtonClick;
            this.SignupPage1.PlayerButtonClick += SignupPage1_PlayerButtonClick;
            await this.NavigationService.Push(this.SignupPage1);
        }
        #endregion

        #endregion

        #region Private Methods

        #region private void SignupPage1_PlayerButtonClick(Object sender, EventArgs e)        
        /// <summary>
        /// Handles the PlayerButtonClick event of the SignupPage1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void SignupPage1_PlayerButtonClick(Object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region private async void SignupPage1_GolfClubAdministratorButtonClick(Object sender, EventArgs e)        
        /// <summary>
        /// Handles the GolfClubAdministratorButtonClick event of the SignupPage1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SignupPage1_GolfClubAdministratorButtonClick(Object sender, EventArgs e)
        {
            this.SignupPageGolfClubAdministrator1.SignUpButtonClick += SignupPageGolfClubAdministrator1_SignUpButtonClick;
            this.SignupPageGolfClubAdministrator1.Init(this.SignupPageGolfClubAdministrator1ViewModel);
            await this.NavigationService.Push(this.SignupPageGolfClubAdministrator1);
        }
        #endregion

        #region private void SignupPageGolfClubAdministrator1_SignUpButtonClick(Object sender, EventArgs e)        
        /// <summary>
        /// Handles the SignUpButtonClick event of the SignupPageGolfClubAdministrator1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SignupPageGolfClubAdministrator1_SignUpButtonClick(Object sender, EventArgs e)
        {
            try
            {
                RegisterClubAdministratorRequest request = new RegisterClubAdministratorRequest
                {
                    EmailAddress = this.SignupPageGolfClubAdministrator1ViewModel.EmailAddress,
                    TelephoneNumber = this.SignupPageGolfClubAdministrator1ViewModel.TelephoneNumber,
                    Password = this.SignupPageGolfClubAdministrator1ViewModel.Password,
                    ConfirmPassword = this.SignupPageGolfClubAdministrator1ViewModel.Password
                };

                await this.GolfClubClient.RegisterGolfClubAdministrator(request, CancellationToken.None);

                await App.Current.MainPage.DisplayAlert("Success",
                    $"Registration Successful", "OK");

                await this.NavigationService.PopToRootPage();
            }
            catch (Exception ex)
            {
                // TODO: log the error
                await App.Current.MainPage.DisplayAlert("Failure",
                    $"Registration Failed", "OK");
            }
        }
        #endregion

        #endregion
    }
}