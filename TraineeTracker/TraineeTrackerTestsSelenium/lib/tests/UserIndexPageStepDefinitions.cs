using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    [Scope(Feature = "UserIndexPage")]
    public class UserIndexPageStepDefinitions : UserData_SharedSteps
    {
        [Given(@"I am on the User Index Page")]
        public void GivenIAmOnTheUserIndexPage()
        {
            Website.UserIndexPage.VisitUserIndexPage();
        }

        [When(@"I click on the Edit Button")]
        public void WhenIClickOnTheEditButton()
        {
            Website.UserIndexPage.ClickEditButton();
        }

        [When(@"I click on the Profile Button")]
        public void WhenIClickOnTheProfileButton()
        {
            Website.UserIndexPage.ClickProfileButton();
        }

        [When(@"I click on the Trackers Button")]
        public void WhenIClickOnTheTrackersButton()
        {
            Website.UserIndexPage.ClickTrackersButton();
        }

        [When(@"I click on the Delete Button")]
        public void WhenIClickOnTheDeleteButton()
        {
            Website.UserIndexPage.ClickDeleteButton();
        }

        [Then(@"I am on the User Edit Page")]
        public void ThenIAmOnTheUserEditPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Edit/"));
        }

        [Then(@"I am on the User Details Page")]
        public void ThenIAmOnTheUserDetailsPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Details/"));
        }

        [Then(@"I am on the Trackers Page")]
        public void ThenIAmOnTheTrackersPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Trackers"));
        }

        [Then(@"I am on the User Delete Page")]
        public void ThenIAmOnTheUserDeletePage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Delete/"));
        }
    }
}
