using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    public class Tracker_EditStepDefinitions : Tracker_Shared
    {
        private int _trackerId = 178;
        private string _stopData;
        private string _startData;
        private string _continueData;
        private string _commentsData;

        [Scope(Feature = "Tracker_Edit")]
        [BeforeScenario(Order = 0)]
        public void SetTrainerCredentials()
        {
            _credentials.Email = "Phil@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        [Scope(Feature = "Tracker_Edit")]
        [BeforeScenario(Order = 2)]
        public void Login()
        {
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterCredentials(_credentials);
            Website.LoginPage.ClickLoginButton();
        }

        [Scope(Feature = "Tracker_Edit")]
        [AfterScenario]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        [Given(@"I am on the Edit page for a tracker")]
        public void GivenIAmOnTheEditPageForATracker()
        {
            Website.Tracker_Edit.VisitEditPage(_trackerId);
            if (!Website.Tracker_Edit.CheckOnEditPage())
            {
                Assert.Fail("Not on Edit page");
            }
        }

        [When(@"I change the data in the input fields:")]
        public void WhenIChangeTheDataInTheInputFields(Table table)
        {
            Dictionary<string, string> inputData = new();
            foreach (var row in table.Rows)
            {
                inputData.Add(row[0], row[1]);
            }
            Website.Tracker_Create.GiveStopInput(inputData["stop_input"]);
            _stopData = inputData["stop_input"];
            Website.Tracker_Create.GiveStartInput(inputData["start_input"]);
            _startData = inputData["start_input"];
            Website.Tracker_Create.GiveContinueInput(inputData["continue_input"]);
            _continueData = inputData["continue_input"];
            Website.Tracker_Create.GiveCommentsInput(inputData["comments_input"]);
            _commentsData = inputData["comments_input"];
            Website.Tracker_Create.SelectTechnicalDropDownOption("Skilled");
            Website.Tracker_Create.SelectConsultantDropDownOption("Skilled");
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

            Assert.That(Website.Tracker_Details.CheckStopData(), Is.EqualTo(_stopData));
            Assert.That(Website.Tracker_Details.CheckStartData(), Is.EqualTo(_startData));
            Assert.That(Website.Tracker_Details.CheckContinueData(), Is.EqualTo(_continueData));
            Assert.That(Website.Tracker_Details.CheckCommentsData(), Is.EqualTo(_commentsData));
            Assert.That(Website.Tracker_Details.CheckTechnicalSkillData(), Is.EqualTo("Skilled"));
            Assert.That(Website.Tracker_Details.CheckConsultantSkillData(), Is.EqualTo("Skilled"));
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

        [Scope(Feature = "Tracker_Edit")]
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
    }
}
