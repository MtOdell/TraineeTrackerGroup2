using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;
using TraineeTrackerTestsSelenium.lib.tests;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class Tracker_DetailsStepDefinitions : Tracker_Shared
    {
        private int _id = 113;

        [Scope(Feature = "Tracker_Details")]
        [AfterScenario]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        [Scope(Feature = "Tracker_Details")]
        [Given(@"I am a valid user")]
        public void GivenIAmAValidUser()
        {
            _credentials.Email = "Phil@SpartaGlobal.com";
            _credentials.Password = "Password1!";
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterCredentials(_credentials);
            Website.LoginPage.ClickLoginButton();
        }

        [Given(@"I am on the Details page for a tracker")]
        public void GivenIAmOnTheDetailsPageForATracker()
        {
            Website.Tracker_Details.VisitDetailsPage(_id);
        }

        [Then(@"the details for that tracker should be shown")]
        public void ThenTheDetailsForThatTrackerShouldBeShown()
        {
            Assert.That(Website.Tracker_Details.CheckStopData(), Is.Not.Null);
            Assert.That(Website.Tracker_Details.CheckStartData(), Is.Not.Null);
            Assert.That(Website.Tracker_Details.CheckContinueData(), Is.Not.Null);
            Assert.That(Website.Tracker_Details.CheckTechnicalSkillData(), Is.Not.Null);
            Assert.That(Website.Tracker_Details.CheckContinueData(), Is.Not.Null);
        }

        [When(@"I click the Edit button")]
        public void WhenIClickTheEditButton()
        {
            Website.Tracker_Details.ClickEditBtn();
        }

        [Then(@"I should be taken to the Edit page")]
        public void ThenIShouldBeTakenToTheEditPage()
        {
            Assert.That(Website.Tracker_Edit.CheckOnEditPage());
        }

        [When(@"I click the Back button on the Details page")]
        public void WhenIClickTheBackButtonOnTheDetailsPage()
        {
            Website.Tracker_Details.ClickBackBtn();
        }

        [Scope(Feature = "Tracker_Details")]
        [Then(@"I should be taken to the Tracker Index page")]
        public void ThenIShouldBeTakenToTheIndexPage()
        {
            Assert.That(Website.Tracker_Index.CheckOnIndexPage());
        }

        [When(@"I go to the URL of the Details page for a tracker that does not exist")]
        public void WhenIGoToAURLOfTheDetailsPageForATrackerThatDoesNotExist()
        {
            Website.Tracker_Details.VisitDetailsPage(-1);
        }

        [Scope(Feature = "Tracker_Details")]
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
