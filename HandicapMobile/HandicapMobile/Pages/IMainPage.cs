using System;
using System.Collections.Generic;
using System.Text;

namespace HandicapMobile.Pages
{
    public interface IMainPage : IPage
    {        
        event EventHandler SignInButtonClick;

        event EventHandler SignUpButtonClick;
    }
}
