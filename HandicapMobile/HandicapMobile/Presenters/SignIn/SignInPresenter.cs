using System.Threading.Tasks;
using HandicapMobile.Common;

namespace HandicapMobile.Presenters.SignIn
{
    public class SignInPresenter : ISignInPresenter
    {
        #region Fields

        /// <summary>
        /// The navigation service
        /// </summary>
        private readonly INavigationService NavigationService;

        #endregion

        #region Constructors

        public SignInPresenter(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
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
            //this.RegisterClubPage1.NextButtonClick += RegisterClubPage1_NextButtonClick;
            //this.RegisterClubPage1.Init(this.RegisterClubPage1ViewModel);            
            //await this.NavigationService.Push(this.RegisterClubPage1);
        }
        #endregion

        #endregion
    }
}