using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HandicapMobile.ViewModels.Signup
{
    public class SignupPageGolfClubAdministrator1ViewModel : BindableObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupPageGolfClubAdministrator1ViewModel"/> class.
        /// </summary>
        public SignupPageGolfClubAdministrator1ViewModel()
        {
            EmailAddress=string.Empty;
            Password=string.Empty;
            TelephoneNumber=string.Empty;
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

        /// <summary>
        /// The telephone number
        /// </summary>
        private String telephoneNumber;

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

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        public String TelephoneNumber
        {
            get { return telephoneNumber; }
            set
            {
                telephoneNumber = value;
                OnPropertyChanged(telephoneNumber);
            }
        }

        #endregion
    }
}
