using System;
using System.Threading;
using System.Threading.Tasks;
using HandicapMobile.Common;
using HandicapMobile.Pages.SignIn;
using HandicapMobile.Services;
using HandicapMobile.ViewModels.Signup;

namespace HandicapMobile.Presenters.SignIn
{
    public class SignInPresenter : ISignInPresenter
    {
        #region Fields

        /// <summary>
        /// The navigation service
        /// </summary>
        private readonly INavigationService NavigationService;

        /// <summary>
        /// The sign in page
        /// </summary>
        private readonly ISignInPage SignInPage;

        /// <summary>
        /// The sign in page view model
        /// </summary>
        private readonly SignInPageViewModel SignInPageViewModel;

        /// <summary>
        /// The signed in golf club adminstrator page
        /// </summary>
        private readonly ISignedInGolfClubAdministratorPage SignedInGolfClubAdministratorPage;

        /// <summary>
        /// The security service client
        /// </summary>
        private readonly ISecurityServiceClient SecurityServiceClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPresenter" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="signInPage">The sign in page.</param>
        /// <param name="signInPageViewModel">The sign in page view model.</param>
        /// <param name="securityServiceClient">The security service client.</param>
        public SignInPresenter(INavigationService navigationService, 
            ISignInPage signInPage, SignInPageViewModel signInPageViewModel, 
            ISignedInGolfClubAdministratorPage signedInGolfClubAdministratorPage,
            ISecurityServiceClient securityServiceClient)
        {
            this.NavigationService = navigationService;
            this.SignInPage = signInPage;
            this.SignInPageViewModel = signInPageViewModel;
            this.SignedInGolfClubAdministratorPage = signedInGolfClubAdministratorPage;
            this.SecurityServiceClient = securityServiceClient;
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
            this.SignInPage.SignInButtonClick += SignInPage_SignInButtonClick;
            this.SignInPage.Init(this.SignInPageViewModel);
            await this.NavigationService.Push(this.SignInPage);
        }
        #endregion

        #region private async void SignInPage_SignInButtonClick(object sender, System.EventArgs e)        
        /// <summary>
        /// Handles the SignInButtonClick event of the SignInPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private async void SignInPage_SignInButtonClick(Object sender, System.EventArgs e)
        {
            // TODO: Move from here
            String clientId = "golfhandicap.mobile";
            String clientSecret = "golfhandicap.mobile";

            // Get a token
            var token = await this.SecurityServiceClient.GetPasswordToken(clientId, clientSecret,
                this.SignInPageViewModel.EmailAddress,
                this.SignInPageViewModel.Password, CancellationToken.None);

            // Store the token
            App.AccessToken = token;

            // Get the users information
            var userInformation = await this.SecurityServiceClient.GetUserInfo(token, CancellationToken.None);

            // TODO: Navigate to the next page (based on user type)
            if (userInformation.RoleName == RoleNames.GolfClubAdministrator)
            {
                await this.NavigationService.Push(this.SignedInGolfClubAdministratorPage);
            }

            
        }
        #endregion

        #endregion
    }
}