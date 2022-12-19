using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Scope(Feature = "Tracker_Delete")]
    [Binding]
    public class Tracker_DeleteStepDefinitions
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        protected Credentials _credentials = new();
        private int _traineeId = 17;
        private int _trackerId = 113;
        private int _trackerCount;

        //[Scope(Feature = "Tracker_Delete")]
        [BeforeScenario(Order = 0)]
        public void SetTrainerCredentials()
        {
            _credentials.Email = "Phil@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        //[Scope(Feature = "Tracker_Delete")]
        [BeforeScenario("Trainer", Order = 2)]
        public void Login()
        {
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterCredentials(_credentials);
            Website.LoginPage.ClickLoginButton();
        }

        //[Scope(Feature = "Tracker_Delete")]
        [AfterScenario]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        //[Scope(Feature = "Tracker_Delete")]
        [Given(@"I am a valid trainee")]
        public void GivenIAmAValidTrainee()
        {
            _credentials.Email = "Adam@SpartaGlobal.com";
            _credentials.Password = "Password1!";
            Login();
        }

        [Given(@"there is a tracker to delete")]
        public void GivenThereIsATrackerToDelete()
        {
            Website.Tracker_Create.VisitCreatePage(_traineeId);
            Website.Tracker_Create.GiveStopInput("New data 1");
            Website.Tracker_Create.GiveStartInput("New data 2");
            Website.Tracker_Create.GiveContinueInput("New data 3");
            Website.Tracker_Create.GiveCommentsInput("New data 4");
            Website.Tracker_Create.SelectTechnicalDropDownOption("Skilled");
            Website.Tracker_Create.SelectConsultantDropDownOption("Skilled");
            Website.Tracker_Create.ClickCreateBtn();
            _trackerCount = Website.Tracker_Index.CountRows();
        }

        [Given(@"I am on the Delete page for a tracker")]
        public void GivenIAmOnTheDeletePageForATracker()
        {
            Website.Tracker_Index.ClickTrackerDeleteButton(_trackerCount);
        }

        [When(@"I click the Delete button")]
        public void WhenIClickTheDeleteButton()
        {
            Website.Tracker_Delete.ClickDeleteBtn();
        }

        [Then(@"the tracker should be deleted")]
        public void ThenTheTrackerShouldBeDeleted()
        {
            int newCount = Website.SeleniumDriver.FindElements(By.Id("table_row")).Count;
            Assert.That(newCount, Is.EqualTo(_trackerCount - 1));
        }

        [When(@"I click the Back button on the Delete page")]
        public void WhenIClickTheBackButtonOnTheDeletePage()
        {
            Website.Tracker_Delete.ClickBackBtn();
        }

        [When(@"I try to go to the Delete page for a tracker")]
        public void WhenITryToGoToTheDeletePageForATracker()
        {
            Website.Tracker_Delete.VisitDeletePage(_trackerId);
        }

        [Then(@"I should be blocked from accessing the page")]
        public void ThenIShouldBeBlockedFromAccessingThePage()
        {
            Assert.That(Website.Tracker_Delete.CheckOnDeletePage(), Is.False);
        }

        [Then(@"an access denied message should appear")]
        public void ThenAnAccessDeniedMessageShouldAppear()
        {
            Assert.That(Website.Tracker_Delete.GetAccessDeniedParagraphText().Contains("You do not have access to this resource."));
        }
    }
}
