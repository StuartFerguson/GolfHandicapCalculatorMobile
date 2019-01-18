using System;
using HandicapMobile.IntegrationTests.Common;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace HandicapMobile.IntegrationTests.Signup
{
    [Binding]
    public class SignupSteps : FeatureBase
    {
        public SignupSteps() : base(Platform.Android, true)
        {

        }

        [Given(@"I am on the Home Screen")]
        public void GivenIAmOnTheHomeScreen()
        {
            
        }
        
        [When(@"I tap on the Sign Up button")]
        public void WhenITapOnTheSignUpButton()
        {
            app.WaitForElement(c => c.Marked("Sign Up"));
            app.Tap(c=> c.Marked("Sign Up"));
        }
        
        [When(@"I then tap on the Golf Club Administrator button")]
        public void WhenIThenTapOnTheGolfClubAdministratorButton()
        {
            app.WaitForElement(c => c.Marked("Golf Club Administrator >>"));
            app.Tap(c=> c.Marked("Golf Club Administrator >>"));
        }
        
        [When(@"I enter my details")]
        public void WhenIEnterMyDetails()
        {
            //app.Repl();
            app.WaitForElement(x=>x.Marked("txtEmailAddress"));
            app.EnterText("txtEmailAddress", "testclubadmin@golfclub1.com");
            app.EnterText("txtTelephoneNumber", "123456");
            app.EnterText("txtPassword", "123456");
            app.DismissKeyboard();            
        }
        
        [When(@"I click on the Signup button")]
        public void WhenIClickOnTheSignupButton()
        {
            app.WaitForElement(c => c.Marked("Signup >>"));
            app.Tap(c=> c.Marked("Signup >>"));
        }
        
        [Then(@"I should be presented with a Registration Success message")]
        public void ThenIShouldBePresentedWithARegistrationSuccessMessage()
        {
            app.WaitForElement(c => c.Marked("Registration Successful"));
            app.Tap(x => x.Text("OK"));
        }
        
        [Then(@"returned to the Home Screen")]
        public void ThenReturnedToTheHomeScreen()
        {
            app.WaitForElement(c => c.Marked("Sign Up"));
        }
    }
}

