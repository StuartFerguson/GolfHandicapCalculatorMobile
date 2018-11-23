using System.Collections.Generic;
using HandicapMobile.Common;

namespace HandicapMobile.ViewModels
{
    public class RegisterClubPage3ViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>
        /// The addresses.
        /// </value>
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the selected address.
        /// </summary>
        /// <value>
        /// The selected address.
        /// </value>
        public Address SelectedAddress { get; set; }

        #endregion
    }
}