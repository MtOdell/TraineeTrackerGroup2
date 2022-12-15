using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class Tracker_DetailsStepDefinitions
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        protected Credentials _credentials = new();

        [Given(@"I am on the Details page for a tracker")]
        public void GivenIAmOnTheDetailsPageForATracker()
        {
            throw new PendingStepException();
        }

        [Then(@"the correct details for that tracker should be shown")]
        public void ThenTheDetailsForThatTrackerShouldBeShown()
        {
            throw new PendingStepException();
        }

        [When(@"I click the Edit button")]
        public void WhenIClickTheEditButton()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be taken to the Edit page")]
        public void ThenIShouldBeTakenToTheEditPage()
        {
            throw new PendingStepException();
        }

        [When(@"I click the Back button on the Details page")]
        public void WhenIClickTheBackButtonOnTheDetailsPage()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be taken to the Tracker Index page")]
        public void ThenIShouldBeTakenToTheIndexPage()
        {
            Assert.That(Website.Tracker_Index.CheckOnIndexPage());
        }

        [When(@"I go to the URL of the Details page for a tracker that does not exist")]
        public void WhenIGoToAURLOfTheDetailsPageForATrackerThatDoesNotExist()
        {
            throw new PendingStepException();
        }

        [Then(@"I should get a (.*) status code")]
        public void ThenIShouldGetAStatusCode(int p0)
        {
            throw new PendingStepException();
        }
    }
}
