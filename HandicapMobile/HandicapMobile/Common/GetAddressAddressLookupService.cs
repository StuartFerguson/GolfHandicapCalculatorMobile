using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using getAddress.Sdk;
using getAddress.Sdk.Api.Requests;

namespace HandicapMobile.Common
{
    public class GetAddressAddressLookupService : IAddressLookupService
    {
        #region Fields
        
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration Configuration;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAddressAddressLookupService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public GetAddressAddressLookupService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Public Methods

        #region public async Task<List<Address>> GetAddress(String postCode, String houseNumber = "")
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="postCode">The post code.</param>
        /// <param name="houseNumber">The house number.</param>
        /// <returns></returns>
        public async Task<List<Address>> GetAddress(String postCode, String houseNumber = "")
        {
            List<Address> result = new List<Address>();

            var apiKey = new ApiKey(this.Configuration.AddressLookupAPIKey);

            using (var api = new GetAddesssApi(apiKey))
            {
                var apiResult = await api.Address.Get(new GetAddressRequest(postCode, houseNumber));

                if (apiResult.IsSuccess)
                {                    
                    foreach (var address in apiResult.SuccessfulResult.Addresses)
                    {
                        result.Add(new Address
                        {
                            AddressLine1 = address.Line1,
                            AddressLine2 = address.Line2,
                            County = address.County,
                            Locality = address.Locality,
                            TownOrCity = address.TownOrCity,
                            PostalCode = postCode
                        });
                    }
                }
                else if (apiResult.StatusCode == 429)
                {
                    // Handle daily limit breach
                    result.Add(new Address
                    {
                        AddressLine1 = "Address Line 1",
                        AddressLine2 = "Address Line 2",
                        County = "County",
                        Locality = "Locality",
                        TownOrCity = "Town",
                        PostalCode = postCode
                    });
                }
            }

            return result;
        }
        #endregion

        #endregion
    }
}