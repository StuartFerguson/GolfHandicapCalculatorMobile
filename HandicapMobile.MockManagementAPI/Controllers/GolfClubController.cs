using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HandicapMobile.MockAPI.Database;
using HandicapMobile.MockAPI.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandicapMobile.MockManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolfClubController : ControllerBase
    {
        private readonly Func<MockDatabaseDbContext> MockDatabaseDbContextResolver;

        public GolfClubController(Func<MockDatabaseDbContext> mockDatabaseDbContextResolver)
        {
            this.MockDatabaseDbContextResolver = mockDatabaseDbContextResolver;
        }

        [HttpPost]
        [Route("RegisterGolfClubAdministrator")]
        public async Task<IActionResult> RegisterGolfClubAdministrator([FromBody] RegisterClubAdministratorRequest request, CancellationToken cancellationToken)
        {
            var emailAddress = request.EmailAddress;

            using (var context = this.MockDatabaseDbContextResolver())
            {
                Boolean isDuplicate = context.RegisteredUsers.Where(u => u.EmailAddress == request.EmailAddress && u.UserType == 0).Any();

                if (isDuplicate)
                {
                    return this.BadRequest("Duplicate Golf Club Administrator User");
                }

                context.RegisteredUsers.Add(new RegisteredUsers
                {
                    EmailAddress = request.EmailAddress,
                    UserType = 0,
                    Password = request.Password,
                    UserId = Guid.NewGuid()
                });

                await context.SaveChangesAsync(cancellationToken);

                return this.Ok();
            }
        }        
    }

    public class RegisterClubAdministratorRequest
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public String Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        public String ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        public String TelephoneNumber { get; set; }
    }
}