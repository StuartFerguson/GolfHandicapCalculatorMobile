using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandicapMobile.Pages.SignIn;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandicapMobile.Views.SignIn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignedInGolfClubAdministratorPage : ContentPage, ISignedInGolfClubAdministratorPage
    {
        public SignedInGolfClubAdministratorPage()
        {
            InitializeComponent();
        }
    }
}