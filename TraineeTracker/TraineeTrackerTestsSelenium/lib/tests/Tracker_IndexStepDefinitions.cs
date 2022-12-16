using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;
using TraineeTrackerTestsSelenium.lib.tests;

namespace TraineeTrackerTests.lib.tests
{
    //[Scope(Feature = "Tracker_Index")]
    [Binding]
    public class Tracker_IndexStepDefinitions : Tracker_Shared
    {
        //public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        //protected Credentials _credentials = new();

        [Scope(Feature = "Tracker_Index")]
        [BeforeScenario(Order = 0)]
        public void SetTrainerCredentials()
        {
            _credentials.Email = "Phil@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        [BeforeScenario("Trainee", Order = 1)]
        public void SetTraineeCredentials()
        {
            _credentials.Email = "Adam@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        [Scope(Feature = "Tracker_Index")]
        [BeforeScenario(Order = 2)]
        public void Login()
        {
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterCredentials(_credentials);
            Website.LoginPage.ClickLoginButton();
        }

        [Scope(Feature = "Tracker_Index")]
        [AfterScenario]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        [Scope(Feature = "Tracker_Index")]
        [Given(@"I am a valid trainer")]
        public void GivenIAmAValidTrainer()
        {
            Website.SeleniumDriver.FindElement(By.CssSelector("span[class=navbar-toggler-icon]")).Click();
            if (!Website.SeleniumDriver.FindElement(By.LinkText("Hello, Phil@SpartaGlobal.com")).Text.Contains("Phil@SpartaGlobal.com"))
            {
                Assert.Fail("Not a valid trainer");
            }
        }

        [Scope(Feature = "Tracker_Index")]
        [Given(@"I am a valid trainee")]
        public void GivenIAmAValidTrainee()
        {
            _credentials.Email = "Adam@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        [Given(@"I am on the View Trainees page")]
        public void GivenIAmOnTheViewTraineesPage()
        {
            Website.SeleniumDriver.Navigate().GoToUrl("https://localhost:7166/UserDatas");
            if (Website.SeleniumDriver.Url != "https://localhost:7166/UserDatas")
            {
                Assert.Fail("Not on the View Trainees page");
            }
        }

        [When(@"I click the Tracker button for one of the trainees listed")]
        public void WhenIClickTheTrackerButtonForOneOfTheTraineesListed()
        {
            var btn = Website.SeleniumDriver.FindElements(By.Id("trackers_button"));
            Website.SeleniumDriver.Navigate().GoToUrl("https://localhost:7166/Trackers/Index/17");
        }

        [Then(@"I am taken to that trainee's Tracker page")]
        public void ThenIAmTakenToThatTraineesTrackerPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Trackers/Index/17"));
        }

        [Then(@"I can see a list of trackers for that particular trainee")]
        public void ThenICanSeeAListOfTrackersForThatParticularTrainee()
        {
            Assert.That(Website.SeleniumDriver.FindElements(By.Id("row_heading")), Is.Not.Null);
        }

        [Given(@"I am on the trainee Tracker page")]
        public void GivenIAmOnTheTraineeTrackerPage()
        {
            Website.SeleniumDriver.Navigate().GoToUrl("https://localhost:7166/Trackers/Index/17");
        }

        [When(@"I click the Back button")]
        public void WhenIClickTheBackButton()
        {
            Website.Tracker_Index.ClickBackButton();
        }

        [Then(@"I should be taken to the View Trainees page")]
        public void ThenIShouldBeTakenToTheViewTraineesPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas"));
        }

        [When(@"I click the Create New button")]
        public void WhenIClickTheCreateNewButton()
        {
            Website.Tracker_Index.ClickCreateButton();
        }

        [Then(@"I should be taken to the Create page")]
        public void ThenIShouldBeTakenToTheCreatePage()
        {
            Assert.That(Website.Tracker_Create.CheckOnCreatePage());
        }

        [When(@"I click the Details button on a tracker in the list")]
        public void WhenIClickTheDetailsButtonOnATrackerInTheList()
        {
            Website.Tracker_Index.ClickDetailsButton(0);
        }

        [Then(@"I should be taken to the Details page for that tracker")]
        public void ThenIShouldBeTakenToTheDetailsPageForThatTracker()
        {
            Assert.That(Website.Tracker_Details.CheckOnDetailsPage());
        }

        [When(@"I click the Delete button on a tracker in the list")]
        public void WhenIClickTheDeleteButtonOnATrackerInTheList()
        {
            Website.Tracker_Index.ClickDeleteButton(0);
        }

        [Then(@"I should be taken to the Delete page for that tracker")]
        public void ThenIShouldBeTakenToTheDeletePageForThatTracker()
        {
            Assert.That(Website.Tracker_Delete.CheckOnDeletePage());
        }

        [When(@"I go to the URL of the tracker page for a trainee that does not exist")]
        public void WhenIGoToTheURLOfTheTrackerPageForATraineeThatDoesNotExist()
        {
            Website.Tracker_Index.VisitIndexPage(-1);
        }

        [Then(@"no trackers should be displayed")]
        public void ThenNoTrackersShouldBeDisplayed()
        {
            try
            {
                Website.SeleniumDriver.FindElements(By.Id("row_heading"));
            }
            catch (NoSuchElementException e)
            {
                Assert.That(e, Is.Not.Null);
            }
        }

        [Then(@"the only button I can see should be the Details buttons for my trackers")]
        public void ThenTheOnlyButtonICanSeeShouldBeTheDetailsButtonsForMyTrackers()
        {
            try
            {
                Website.SeleniumDriver.FindElement(By.Id("create_btn"));
            }
            catch (NoSuchElementException e)
            {
                Assert.That(e, Is.Not.Null);
            }

            try
            {
                Website.SeleniumDriver.FindElements(By.Id("delete_btn"));
            }
            catch (NoSuchElementException e)
            {
                Assert.That(e, Is.Not.Null);
            }

            Website.Tracker_Index.ClickDetailsButton(0);

            Assert.That(Website.Tracker_Details.CheckOnDetailsPage());
        }

        [When(@"I go to my tracker page")]
        public void WhenIGoToMyTrackerPage()
        {
            Website.Tracker_Index.VisitIndexPage(17);
        }

        [Then(@"I can see my trackers")]
        public void ThenICanSeeMyTrackers()
        {
            Assert.That(Website.Tracker_Index.CountRows(), Is.Not.Zero);
        }

    }
}
