using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class Tracker_DetailsStepDefinitions
    {
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
            throw new PendingStepException();
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
