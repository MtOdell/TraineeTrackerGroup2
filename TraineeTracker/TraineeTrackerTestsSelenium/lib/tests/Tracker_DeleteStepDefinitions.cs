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
            Website.Tracker_Index.VisitIndexPage(_traineeId);
            Website.Tracker_Index.ClickTrackerDeleteBtn(1);
            Thread.Sleep(2000);
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

        [Scope(Feature = "Tracker_Delete")]
        [Then(@"I should be taken to the Tracker Index page")]
        public void ThenIShouldBeTakenToTheIndexPage()
        {
            Assert.That(Website.Tracker_Index.CheckOnIndexPage());
        }

        [Given(@"I go to a Trainee's tracker page")]
        public void GivenIGoToATraineesTrackerPage()
        {
            Website.Tracker_Index.VisitIndexPage(25);
        }

        [Given(@"there are no tracker's to delete")]
        public void GivenThereAreNoTrackersToDelete()
        {
            if (Website.Tracker_Index.CountRows() > 0)
            {
                for (int i = 1; i <= Website.Tracker_Index.CountRows(); i++)
                {
                    Website.Tracker_Index.ClickTrackerDeleteBtn(i);
                    Website.Tracker_Delete.ClickDeleteBtn();
                    Thread.Sleep(1000);
                }
            }
        }

        [When(@"I try and click the Delete button")]
        public void WhenITryAndClickTheDeleteButton()
        {
            try
            {
                Website.Tracker_Index.ClickTrackerDeleteBtn(1);
            }
            catch (ArgumentOutOfRangeException e)
            {

            }
            catch (NoSuchElementException e)
            {

            }
        }

        [Then(@"nothing should happen")]
        public void ThenNothingShouldHappen()
        {
            Assert.That(Website.Tracker_Index.CheckOnIndexPage());
        }
    }
}
