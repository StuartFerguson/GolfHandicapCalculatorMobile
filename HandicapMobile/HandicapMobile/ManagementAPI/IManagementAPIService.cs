using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HandicapMobile.ManagementAPI.DataTransferObjects;

namespace HandicapMobile.ManagementAPI
{
    public interface IManagementAPIService
    {
        /// <summary>
        /// Creates the club configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<CreateClubConfigurationResponse> CreateClubConfiguration(CreateClubConfigurationRequest request, CancellationToken cancellationToken);
    }
}
