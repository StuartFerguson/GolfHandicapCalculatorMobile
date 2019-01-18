using System;
using System.Threading.Tasks;
using HandicapMobile.Pages;
using HandicapMobile.Presenters.SignIn;
using HandicapMobile.Presenters.Signup;

namespace HandicapMobile.Presenters
{
    public class MainPagePresenter : IMainPagePresenter
    {
        #region Fields

        /// <summary>
        /// The main page
        /// </summary>
        private readonly IMainPage MainPage;

        /// <summary>
        /// The signup presenter resolver
        /// </summary>
        private readonly Func<ISignupPresenter> SignupPresenterResolver;

        /// <summary>
        /// The sign in presenter resolver
        /// </summary>
        private readonly Func<ISignInPresenter> SignInPresenterResolver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPagePresenter" /> class.
        /// </summary>
        /// <param name="mainPage">The main page.</param>
        /// <param name="signupPresenterResolver">The signup presenter resolver.</param>
        /// <param name="signInPresenterResolver">The sign in presenter resolver.</param>
        public MainPagePresenter(IMainPage mainPage, Func<ISignupPresenter> signupPresenterResolver, Func<ISignInPresenter> signInPresenterResolver)
        {
            this.MainPage = mainPage;
            this.SignupPresenterResolver = signupPresenterResolver;
            this.SignInPresenterResolver = signInPresenterResolver;

            this.MainPage.SignUpButtonClick += MainPage_SignUpButtonClick;
            this.MainPage.SignInButtonClick += MainPage_SignInButtonClick;
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
            
        }
        #endregion

        #endregion

        #region Private Methods

        //#region private async void MainPage_RegisterClubButtonClick(object sender, EventArgs e)        
        ///// <summary>
        ///// Handles the RegisterClubButtonClick event of the MainPage control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //private async void MainPage_RegisterClubButtonClick(Object sender, EventArgs e)
        //{
        //    var registerClubPresenter = this.RegisterClubPresenterResolver();
        //    await registerClubPresenter.Start();
        //}
        //#endregion

        #region private async void MainPage_SignInButtonClick(object sender, EventArgs e)            
        /// <summary>
        /// Handles the SignInButtonClick event of the MainPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private async void MainPage_SignInButtonClick(Object sender, EventArgs e)
        {
            var signInPresenter = this.SignInPresenterResolver();
            await signInPresenter.Start();
        }
        #endregion

        #region private async void MainPage_SignUpButtonClick(object sender, EventArgs e)        
        /// <summary>
        /// Handles the SignUpButtonClick event of the MainPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private async void MainPage_SignUpButtonClick(Object sender, EventArgs e)
        {
            var signupPresenter = this.SignupPresenterResolver();
            await signupPresenter.Start();
        }
        #endregion

        #endregion
    }
}