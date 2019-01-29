using HandicapMobile.MockAPI.Database;
using HandicapMobile.MockAPI.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace HandicapMobile.IntegrationTests.Common
{
    [Binding]
    [Scope(Tag = "base")]
    public class FeatureBase
    {
        protected readonly MockDatabaseDbContext MockDatabase;

        public FeatureBase()
        {
            String connectionString = "server=192.168.1.132;database=MockDatabase;user id=root;password=Pa55word";
            this.MockDatabase = new MockDatabaseDbContext(connectionString);
        }

        [BeforeScenario]
        public void BeforeEachTest ()
        {
            IApp app = AppInitializer.StartApp(Platform.Android);
            ScenarioContext.Current.Add("App", app);
        }

        [Given(@"There are no administrators signed up")]
        public void GivenThereAreNoAdministratorsSignedUp()
        {
            var context = this.MockDatabase;
            
            var usersToRemove = context.RegisteredUsers.Where(u => u.UserType == 0).ToList();
            context.RemoveRange(usersToRemove);

            context.SaveChanges();
        }

        [Given(@"I have signed up as a golf club administrator with the following details")]
        public void GivenIHaveSignedUpAsAGolfClubAdministratorWithTheFollowingDetails(Table table)
        {
            // Get the first row
            TableRow row = table.Rows.First();

            var context = this.MockDatabase;

            context.RegisteredUsers.Add(new RegisteredUsers
            {
                UserType = 0,
                EmailAddress = row["EmailAddress"],
                Password = row["Password"],
                UserId = Guid.NewGuid()
            });

            context.SaveChanges();
        }

        [Given(@"I am on the Home Screen")]
        public void GivenIAmOnTheHomeScreen()
        {
            
        }
    }


}
