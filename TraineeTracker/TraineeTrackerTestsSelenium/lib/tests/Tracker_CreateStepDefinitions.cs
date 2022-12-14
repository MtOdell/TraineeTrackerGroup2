using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    public class Tracker_CreateStepDefinitions
    {
        [When(@"I enter data into the input fields")]
        public void WhenIEnterDataIntoTheInputFields()
        {
            throw new PendingStepException();
        }

        [Given(@"I am on the Create page")]
        public void GivenIAmOnTheCreatePage()
        {
            throw new PendingStepException();
        }

        [When(@"I click the Back button on the Create page")]
        public void WhenIClickTheBackButtonOnTheCreatePage()
        {
            throw new PendingStepException();
        }

        [When(@"I go to the URL of the Create page for a tracker that does not exist")]
        public void WhenIGoToTheURLOfTheCreatePageForATrackerThatDoesNotExist()
        {
            throw new PendingStepException();
        }
    }
}
