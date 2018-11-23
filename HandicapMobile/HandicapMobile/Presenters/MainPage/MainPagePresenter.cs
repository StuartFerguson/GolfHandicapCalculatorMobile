using System;
using System.Threading.Tasks;
using HandicapMobile.Pages;

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
        /// The register club presenter resolver
        /// </summary>
        private readonly Func<IRegisterClubPresenter> RegisterClubPresenterResolver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPagePresenter"/> class.
        /// </summary>
        /// <param name="mainPage">The main page.</param>
        /// <param name="registerClubPresenterResolver">The register club presenter resolver.</param>
        public MainPagePresenter(IMainPage mainPage, Func<IRegisterClubPresenter> registerClubPresenterResolver)
        {
            this.MainPage = mainPage;
            this.RegisterClubPresenterResolver = registerClubPresenterResolver;

            this.MainPage.RegisterClubButtonClick += MainPage_RegisterClubButtonClick;
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

        #region private async void MainPage_RegisterClubButtonClick(object sender, EventArgs e)        
        /// <summary>
        /// Handles the RegisterClubButtonClick event of the MainPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MainPage_RegisterClubButtonClick(Object sender, EventArgs e)
        {
            var registerClubPresenter = this.RegisterClubPresenterResolver();
            await registerClubPresenter.Start();
        }
        #endregion

        #endregion

        
    }
}