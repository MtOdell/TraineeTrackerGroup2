using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    [Scope(Feature = "UserDetailsPage")]
    public class UserDetailsPageStepDefinitions : UserData_SharedSteps
    {
        [Given(@"I am on the User Data Page")]
        public void GivenIAmOnTheUserDataPage()
        {
            Website.Homepage.ClickUserButton();
        }
        [Given(@"I press Details")]
        public void GivenIPressDetails()
        {
            Website.UserIndexPage.ClickProfileButton();
        }
        [When(@"I press the Details")]
        public void WhenIPressTheDetails()
        {
            Website.UserIndexPage.ClickProfileButton();
        }
        [Then(@"I am on the User Details Page")]
        public void ThenIAmOnTheUserDetailsPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Does.Contain("https://localhost:7166/UserDatas/Details"));
        }

        [When(@"I press the Edit Button")]
        public void WhenIPressTheEditButton()
        {
            Website.UserDetailsPage.ClickEditButton();
        }

        [Then(@"I am on the User Edit Page")]
        public void ThenIAmOnTheUserEditPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Does.Contain("https://localhost:7166/UserDatas/Edit/"));
        }
    }
}
