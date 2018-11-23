using System;
using System.Text;
using Xamarin.Forms;

namespace HandicapMobile.ViewModels
{ 
    public class RegisterClubPage1ViewModel : BindableObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterClubPage1ViewModel"/> class.
        /// </summary>
        public RegisterClubPage1ViewModel()
        {
            ClubName = string.Empty;
            TelephoneNumber= string.Empty;
            EmailAddress= string.Empty;
            Website= string.Empty;
        }
        
        #endregion

        #region Fields

        /// <summary>
        /// The club name
        /// </summary>
        private String clubName;

        /// <summary>
        /// The telephone number
        /// </summary>
        private String telephoneNumber;

        /// <summary>
        /// The website
        /// </summary>
        private String website;

        /// <summary>
        /// The email address
        /// </summary>
        private String emailAddress;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the club.
        /// </summary>
        /// <value>
        /// The name of the club.
        /// </value>
        public String ClubName
        {
            get { return clubName; }
            set
            {
                clubName = value;
                OnPropertyChanged(clubName);
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

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public String Website
        {
            get { return website; }
            set
            {
                website = value;
                OnPropertyChanged(website);
            }
        }

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
        #endregion
    }
}
