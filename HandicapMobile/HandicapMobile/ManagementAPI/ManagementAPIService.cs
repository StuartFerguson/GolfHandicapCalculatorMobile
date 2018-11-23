using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandicapMobile.Common;
using HandicapMobile.ManagementAPI.DataTransferObjects;
using Newtonsoft.Json;

namespace HandicapMobile.ManagementAPI
{
    public class ManagementAPIService : IManagementAPIService
    {
        #region Fields

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration Configuration;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementAPIService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ManagementAPIService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        #endregion

        #region Public Methods

        #region public async Task<CreateClubConfigurationResponse> CreateClubConfiguration(CreateClubConfigurationRequest request, CancellationToken cancellationToken)        
        /// <summary>
        /// Creates the club configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error during POST</exception>
        public async Task<CreateClubConfigurationResponse> CreateClubConfiguration(CreateClubConfigurationRequest request, CancellationToken cancellationToken)
        {
            CreateClubConfigurationResponse result = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Configuration.ManagementAPI);

                String requestSerialised = JsonConvert.SerializeObject(request);
                StringContent httpContent = new StringContent(requestSerialised, Encoding.UTF8, "application/json");

                var response= await client.PostAsync("/api/ClubConfiguration", httpContent, CancellationToken.None);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error during POST");
                }

                var responseContest = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<CreateClubConfigurationResponse>(responseContest);
            }

            return result;
        }
        #endregion

        #endregion
    }
}