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

        [When(@"I click on the Delete Button")]
        public void WhenIClickOnTheDeleteButton()
        {
            Website.UserDeletePage.ClickDeleteButton();
        }

        [When(@"I click on the Back Button")]
        public void WhenIClickOnTheBackButton()
        {
            Website.UserDeletePage.ClickBackButton();
        }

        [Then(@"The user is deleted")]
        public void ThenTheUserIsDeleted()
        {
            throw new PendingStepException();
        }

        [Then(@"I am on the Index Page")]
        public void ThenIAmOnTheIndexPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Index/"));
        }
    }
}
