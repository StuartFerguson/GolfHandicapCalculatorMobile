using getAddress.Sdk.Api.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HandicapMobile.Common
{
    public interface IAddressLookupService
    {
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="postCode">The post code.</param>
        /// <param name="houseNumber">The house number.</param>
        /// <returns></returns>
        Task<List<Address>> GetAddress(String postCode, String houseNumber = "");
    }

    public class Address
    {
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String Locality { get; set; }
        public String TownOrCity { get; set; }
        public String County { get; set; }
        public String PostalCode { get; set; }
    }
}
