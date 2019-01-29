using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HandicapMobile.ViewModels.Signup
{
    public class SignInPageViewModel : BindableObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPageViewModel"/> class.
        /// </summary>
        public SignInPageViewModel()
        {
            EmailAddress=String.Empty;
            Password=String.Empty;
        }

        #endregion

        #region Fields

        /// <summary>
        /// The email address
        /// </summary>
        private String emailAddress;

        /// <summary>
        /// The password
        /// </summary>
        private String password;
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                OnPropertyChanged(emailAddress);
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(password);
            }
        }

        #endregion
    }
}
