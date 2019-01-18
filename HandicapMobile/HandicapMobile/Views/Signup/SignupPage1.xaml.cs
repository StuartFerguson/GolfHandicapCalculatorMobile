using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandicapMobile.Pages.Signup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandicapMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignupPage1 : ContentPage, ISignupPage1
	{
        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="SignupPage1"/> class.
        /// </summary>
        public SignupPage1 ()
		{
			InitializeComponent();
            this.btnGolfClubAdministrator.Clicked += BtnGolfClubAdministrator_Clicked;
            this.btnPlayer.Clicked += BtnPlayer_Clicked;
		}
        #endregion

        /// <summary>
        /// Occurs when [golf club administrator button click].
        /// </summary>
        public event EventHandler GolfClubAdministratorButtonClick;

        /// <summary>
        /// Occurs when [player button click].
        /// </summary>
        public event EventHandler PlayerButtonClick;

        #region private void BtnPlayer_Clicked(object sender, EventArgs e)        
        /// <summary>
        /// Handles the Clicked event of the BtnPlayer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnPlayer_Clicked(object sender, EventArgs e)
        {
            PlayerButtonClick(sender, e);
        }
        #endregion

        #region private void BtnGolfClubAdministrator_Clicked(object sender, EventArgs e)        
        /// <summary>
        /// Handles the Clicked event of the BtnGolfClubAdministrator control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnGolfClubAdministrator_Clicked(object sender, EventArgs e)
        {
            GolfClubAdministratorButtonClick(sender, e);
        }
        #endregion
    }
}