using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Scope(Feature = "Tracker_Edit")]
    [Binding]
    public class Tracker_EditStepDefinitions
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        protected Credentials _credentials = new();
        private int _trackerId = 178;
        private string _stopData;
        private string _startData;
        private string _continueData;
        private string _commentsData;

        [AfterScenario("ChangeTrackerDetails", Order = 1)]
        public void UndoTrackerChanges()
        {
            Website.Tracker_Edit.VisitEditPage(_trackerId);
            Website.Tracker_Edit.GetStopInput.Clear();
            Website.Tracker_Create.GiveStopInput("New data 1");
            Website.Tracker_Edit.GetStartInput.Clear();
            Website.Tracker_Create.GiveStartInput("New data 2");
            Website.Tracker_Edit.GetContinueInput.Clear();
            Website.Tracker_Create.GiveContinueInput("New data 3");
            Website.Tracker_Edit.ClickSaveBtn();
        }

        [AfterScenario(Order = 2)]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        [Given(@"I am a valid trainee")]
        public void GivenIAmAValidTrainee()
        {
            _credentials.Email = "Adam@SpartaGlobal.com";
            _credentials.Password = "Password1!";
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterCredentials(_credentials);
            Website.LoginPage.ClickLoginButton();
        }

        [Given(@"I am on the Edit page for a tracker")]
        public void GivenIAmOnTheEditPageForATracker()
        {
            Website.Tracker_Edit.VisitEditPage(_trackerId);
        }

        [When(@"I change the data in the input fields:")]
        public void WhenIChangeTheDataInTheInputFields(Table table)
        {
            Dictionary<string, string> inputData = new();
            foreach (var row in table.Rows)
            {
                inputData.Add(row[0], row[1]);
            }
            Website.Tracker_Edit.GetStopInput.Clear();
            Website.Tracker_Create.GiveStopInput(inputData["stop_input"]);
            _stopData = inputData["stop_input"];
            Website.Tracker_Edit.GetStartInput.Clear();
            Website.Tracker_Create.GiveStartInput(inputData["start_input"]);
            _startData = inputData["start_input"];
            Website.Tracker_Edit.GetContinueInput.Clear();
            Website.Tracker_Create.GiveContinueInput(inputData["continue_input"]);
            _continueData = inputData["continue_input"];
        }

        [When(@"I click the Save button")]
        public void WhenIClickTheSaveButton()
        {
            Website.Tracker_Edit.ClickSaveBtn();
        }

        [Then(@"my changes should be saved")]
        public void ThenMyChangesShouldBeSaved()
        {
            Website.Tracker_Details.VisitDetailsPage(_trackerId);
            Thread.Sleep(2000);
            var newStopData = Website.Tracker_Details.CheckStopData();
            var newStartData = Website.Tracker_Details.CheckStartData();
            var newContinueData = Website.Tracker_Details.CheckContinueData();

            Assert.That(newStopData, Is.EqualTo(_stopData));
            Assert.That(newStartData, Is.EqualTo(_startData));
            Assert.That(newContinueData, Is.EqualTo(_continueData));
        }

        [When(@"I click the Back button on the Edit page")]
        public void WhenIClickTheBackButtonOnTheEditPage()
        {
            Website.Tracker_Edit.ClickBackBtn();
        }

        [When(@"I go to the URL of the Edit page for a tracker that does not exist")]
        public void WhenIGoToTheURLOfTheEditPageForATrackerThatDoesNotExist()
        {
            Website.Tracker_Edit.VisitEditPage(-1);
        }

        [Then(@"nothing should be displayed")]
        public void ThenNothingShouldBeDisplayed()
        {
            bool exceptionIsNotNull = false;
            try
            {
                Website.Tracker_Details.CheckStopData();
            }
            catch (NoSuchElementException e)
            {
                if (e != null)
                {
                    exceptionIsNotNull = true;
                }
            }

            Assert.That(exceptionIsNotNull);
        }

        [Then(@"I should be taken to the Tracker Index page")]
        public void ThenIShouldBeTakenToTheIndexPage()
        {
            Assert.That(Website.Tracker_Index.CheckOnIndexPage());
        }
    }
}
