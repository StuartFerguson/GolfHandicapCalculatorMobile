using System;
using System.Collections.Generic;
using System.Text;

namespace HandicapMobile.Pages.Signup
{
    public interface ISignupPage1 : IPage
    {
        /// <summary>
        /// Occurs when [golf club administrator button click].
        /// </summary>
        event EventHandler GolfClubAdministratorButtonClick;

        /// <summary>
        /// Occurs when [player button click].
        /// </summary>
        event EventHandler PlayerButtonClick;
    }
}
