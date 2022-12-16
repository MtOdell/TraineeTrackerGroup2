using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    public class Tracker_EditStepDefinitions : Tracker_Shared
    {
        private int _id = 113;

        [Scope(Feature = "Tracker_Edit")]
        [BeforeScenario(Order = 0)]
        public void SetTrainerCredentials()
        {
            _credentials.Email = "Phil@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        [Scope(Feature = "Tracker_Index")]
        [BeforeScenario(Order = 2)]
        public void Login()
        {
            Website.SL_LoginPage.VisitLoginPage();
            Website.SL_LoginPage.EnterCredentials(_credentials);
            Website.SL_LoginPage.ClickLoginButton();
        }

        [Scope(Feature = "Tracker_Index")]
        [AfterScenario]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        [Given(@"I am on the Edit page for a tracker")]
        public void GivenIAmOnTheEditPageForATracker()
        {
            Website.Tracker_Edit.VisitEditPage(_id);
            if (!Website.Tracker_Edit.CheckOnEditPage())
            {
                Assert.Fail("Not on Edit page");
            }
        }

        [When(@"I change the data in the input fields:")]
        public void WhenIChangeTheDataInTheInputFields(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"I click the Save button")]
        public void WhenIClickTheSaveButton()
        {
            throw new PendingStepException();
        }

        [Then(@"my changes should be saved")]
        public void ThenMyChangesShouldBeSaved()
        {
            throw new PendingStepException();
        }

        [When(@"I click the Back button on the Edit page")]
        public void WhenIClickTheBackButtonOnTheEditPage()
        {
            throw new PendingStepException();
        }

        [When(@"I go to the URL of the Edit page for a tracker that does not exist")]
        public void WhenIGoToTheURLOfTheEditPageForATrackerThatDoesNotExist()
        {
            throw new PendingStepException();
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
