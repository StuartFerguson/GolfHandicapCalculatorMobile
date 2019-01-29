using System;
using System.Linq;
using HandicapMobile.IntegrationTests.Common;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace HandicapMobile.IntegrationTests.Signup
{
    [Binding]
    [Scope(Tag = "signup")]
    public class SignupSteps 
    {
        private readonly IApp App;

        public SignupSteps(ScenarioContext scenarioContext)
        {
            this.App = scenarioContext.Get<IApp>("App");
        }        
        
        [When(@"I tap on the Sign Up button")]
        public void WhenITapOnTheSignUpButton()
        {
            this.App.WaitForElement(c => c.Marked("Sign Up"));
            this.App.Tap(c=> c.Marked("Sign Up"));
        }
        
        [When(@"I then tap on the Golf Club Administrator button")]
        public void WhenIThenTapOnTheGolfClubAdministratorButton()
        {
            this.App.WaitForElement(c => c.Marked("Golf Club Administrator >>"));
            this.App.Tap(c=> c.Marked("Golf Club Administrator >>"));
        }
        
        [When(@"I enter the following details")]
        public void WhenIEnterTheFollowingDetails(Table table)
        {
            // Get the first row
            TableRow row = table.Rows.First();

            this.App.WaitForElement(x=>x.Marked("txtEmailAddress"));
            this.App.EnterText("txtEmailAddress", row["EmailAddress"]);
            this.App.EnterText("txtTelephoneNumber", row["TelephoneNumber"]);
            this.App.EnterText("txtPassword", row["Password"]);
            this.App.DismissKeyboard();
        }
        
        [When(@"I click on the Signup button")]
        public void WhenIClickOnTheSignupButton()
        {
            this.App.WaitForElement(c => c.Marked("Signup >>"));
            this.App.Tap(c=> c.Marked("Signup >>"));
        }
        
        [Then(@"I should be presented with a Registration Success message")]
        public void ThenIShouldBePresentedWithARegistrationSuccessMessage()
        {
            this.App.WaitForElement(c => c.Marked("Registration Successful"));
            this.App.Tap(x => x.Text("OK"));
        }
        
        [Then(@"returned to the Home Screen")]
        public void ThenReturnedToTheHomeScreen()
        {
            this.App.Repl();
            this.App.WaitForElement(c => c.Marked("Sign Up"));
        }
    }
}

