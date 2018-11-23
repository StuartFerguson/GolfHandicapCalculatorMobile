using System;
using HandicapMobile.Common;

namespace HandicapMobile.ViewModels
{
    public class RegisterClubPage4ViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the club.
        /// </summary>
        /// <value>
        /// The name of the club.
        /// </value>
        public String ClubName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        public String TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public String Website { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public Address Address { get; set; }

        #endregion
    }
}