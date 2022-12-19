using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    [Scope(Feature = "UserDeletePage")]
    public class UserDeletePageStepDefinitions : UserData_SharedSteps
    {
        [Given(@"I am on the User Delete Page")]
        public void GivenIAmOnTheUserDeletePage()
        {
            Website.UserDeletePage.VisitUserDeletePage();
        }

        [Given(@"I press the login button")]
        public void GivenIPressTheLoginButton()
        {
            Website.LoginPage.ClickLoginButton();
        }


        [When(@"I click on the Delete Button")]
        public void WhenIClickOnTheDeleteButton()
        {
            Website.UserIndexPage.ClickDeleteButton();
        }

        [When(@"I click on the Back Button")]
        public void WhenIClickOnTheBackButton()
        {
            Website.UserDeletePage.ClickBackButton();
        }

        [Given(@"I am on the User Index Page")]
        public void GivenIAmOnTheUserIndexPage()
        {
            Website.Homepage.ClickUserButton();
        }

        [Then(@"I am redirected to the delete user page")]
        public void ThenIAmRedirectedToTheDeleteUserPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Does.Contain("https://localhost:7166/UserDatas/Delete"));
        }
        [Then(@"I am on the Index Page")]
        public void ThenIAmOnTheIndexPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Does.Contain("https://localhost:7166/UserDatas/Index/"));
        }
    }
}
