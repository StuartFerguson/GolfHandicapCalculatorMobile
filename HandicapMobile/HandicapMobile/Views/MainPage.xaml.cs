using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandicapMobile.Pages;
using HandicapMobile.Presenters;
using Xamarin.Forms;

namespace HandicapMobile
{
    public partial class MainPage : ContentPage, IMainPage, IPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            this.btnSignIn.Clicked += BtnSignIn_Clicked;
            this.btnSignUp.Clicked += BtnSignUp_Clicked;
        }

        /// <summary>
        /// Occurs when [sign in button click].
        /// </summary>
        public event EventHandler SignInButtonClick;

        /// <summary>
        /// Occurs when [sign up button click].
        /// </summary>
        public event EventHandler SignUpButtonClick;

        private void BtnSignUp_Clicked(Object sender, EventArgs e)
        {
            SignUpButtonClick(sender, e);
        }

        private void BtnSignIn_Clicked(Object sender, EventArgs e)
        {
            SignInButtonClick(sender, e);
        }
    }
}
