using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    public class UserEditPageStepDefinitions : UserData_SharedSteps
    {
        [Given(@"I am on the User Edit Page")]
        public void GivenIAmOnTheUserEditPage()
        {
            Website.UserEditPage.VisitUserEditPage();
        }

        [When(@"I click on the save button")]
        public void WhenIClickOnTheSaveButton()
        {
            throw new PendingStepException();
        }

        [When(@"I click on the Back button")]
        public void WhenIClickOnTheBackButton()
        {
            throw new PendingStepException();
        }

        [Then(@"The user is edited")]
        public void ThenTheUserIsEdited()
        {
            throw new PendingStepException();
        }

        [Then(@"The error messages are shown")]
        public void ThenTheErrorMessagesAreShown()
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
