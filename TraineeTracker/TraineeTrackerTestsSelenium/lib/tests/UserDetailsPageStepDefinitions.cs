using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    [Scope(Feature = "UserDetailsPage")]
    public class UserDetailsPageStepDefinitions : UserData_SharedSteps
    {
        [Given(@"I am on the User Details Page")]
        public void GivenIAmOnTheUserDetailsPage()
        {
            Website.UserDetailsPage.VisitUserDetailsPage();
        }

        [When(@"I press the Edit Button")]
        public void WhenIPressTheEditButton()
        {
            Website.UserDetailsPage.ClickEditButton();
        }

        [When(@"I press the Back Button")]
        public void WhenIPressTheBackButton()
        {
            Website.UserDetailsPage.ClickBackButton();
        }

        [Then(@"I am on the User Edit Page")]
        public void ThenIAmOnTheUserEditPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Edit/"));
        }

        [Then(@"I am on the Index Page")]
        public void ThenIAmOnTheIndexPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Index/"));
        }
    }
}
