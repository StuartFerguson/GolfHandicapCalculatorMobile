using System;
using System.Collections.Generic;
using System.Text;

namespace HandicapMobile.Common
{
    public interface IConfiguration
    {
        /// <summary>
        /// Gets or sets the management API.
        /// </summary>
        /// <value>
        /// The management API.
        /// </value>
        String ManagementAPI { get; set; }
    }
}
