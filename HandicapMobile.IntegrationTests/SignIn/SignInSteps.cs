using System;
using System.Linq;
using HandicapMobile.IntegrationTests.Common;
using HandicapMobile.MockAPI.Database;
using HandicapMobile.MockAPI.Database.Models;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace HandicapMobile.IntegrationTests.SignIn
{
    [Binding]
    [Scope(Tag = "signin")]
    public class SignInSteps
    {
        private readonly IApp App;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            this.App = scenarioContext.Get<IApp>("App");
        }        
        
        [When(@"I tap on the Sign In button")]
        public void WhenITapOnTheSignInButton()
        {
            this.App.WaitForElement(c => c.Marked("Sign In"));
            this.App.Tap(c=> c.Marked("Sign In"));
        }
        
        [When(@"I enter the username '(.*)' and password '(.*)'")]
        public void WhenIEnterTheUsernameAndPassword(String userName, String password)
        {
            this.App.WaitForElement(x=>x.Marked("txtEmailAddress"));
            this.App.EnterText("txtEmailAddress", userName);
            this.App.EnterText("txtPassword", password);
            this.App.DismissKeyboard();
        }
        
        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {
            this.App.WaitForElement(c => c.Marked("Sign In >>"));
            this.App.Tap(c=> c.Marked("Sign In >>"));
        }

        [Then(@"I should be presented with the Club Administrator Signed In Page")]
        public void ThenIShouldBePresentedWithTheClubAdministratorSignedInPage()
        {
            //this.App.Repl();
            this.App.WaitForElement(c => c.Marked("Welcome"));
        }
    }
}
