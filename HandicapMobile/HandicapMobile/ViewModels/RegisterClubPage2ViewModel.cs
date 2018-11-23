using System;
using Xamarin.Forms;

namespace HandicapMobile.ViewModels
{
    public class RegisterClubPage2ViewModel : BindableObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterClubPage2ViewModel"/> class.
        /// </summary>
        public RegisterClubPage2ViewModel()
        {
            PostalCode = string.Empty;
        }
        #endregion

        #region Fields

        /// <summary>
        /// The postal code
        /// </summary>
        private String postalCode;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public String PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                OnPropertyChanged(postalCode);
            }
        }
        #endregion
    }
}