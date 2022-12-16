using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist.ValueRetrievers;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    //[Scope(Feature = "Tracker_Create")]
    [Binding]
    public class Tracker_CreateStepDefinitions : Tracker_Shared
    {
        private int _traineeId = 17;
        private int _trackerCount;
        private string _stopData;
        private string _startData;
        private string _continueData;
        private string _commentsData;

        [Scope(Feature = "Tracker_Create")]
        [BeforeScenario(Order = 0)]
        public void SetTrainerCredentials()
        {
            _credentials.Email = "Phil@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        [BeforeScenario("Trying to access the Create page when logged in as a trainee", Order = 1)]
        public void SetTraineeCredentials()
        {
            _credentials.Email = "Adam@SpartaGlobal.com";
            _credentials.Password = "Password1!";
        }

        [Scope(Feature = "Tracker_Create")]
        [BeforeScenario(Order = 2)]
        public void Login()
        {
            Website.SL_LoginPage.VisitLoginPage();
            Website.SL_LoginPage.EnterCredentials(_credentials);
            Website.SL_LoginPage.ClickLoginButton();
        }

        [Scope(Feature = "Tracker_Create")]
        [BeforeScenario("a new tracker is created with the details I entered")]
        public void GetTrackerCount()
        {
            Website.Tracker_Index.VisitIndexPage(17);
            _trackerCount = Website.SeleniumDriver.FindElements(By.Id("table_row")).Count;
        }

        [Scope(Feature = "Tracker_Create")]
        [AfterScenario]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        //[Scope(Feature = "Tracker_Create")]
        //[AfterScenario("a new tracker is created with the details I entered")]
        //public void DeleteNewTracker()
        //{
        //    Website.Tracker_Index.VisitIndexPage(_traineeId);
        //    Website.SeleniumDriver.FindElements(By.Id("delete_btn"))[^1].Click();
        //    Website.Tracker_Delete.ClickDeleteBtn();
        //}

        [Scope(Feature = "Tracker_Create")]
        [Given(@"I am a valid trainer")]
        public void GivenIAmAValidTrainer()
        {
            Website.SeleniumDriver.FindElement(By.CssSelector("span[class=navbar-toggler-icon]")).Click();
            if (!Website.SeleniumDriver.FindElement(By.LinkText("Hello, Phil@SpartaGlobal.com")).Text.Contains("Phil@SpartaGlobal.com"))
            {
                Assert.Fail("Not a valid trainer");
            }
            //Thread.Sleep(5000);
        }

        [Given(@"I am on the Create page")]
        public void GivenIAmOnTheCreatePage()
        {
            Website.Tracker_Create.VisitCreatePage(_traineeId);
            //Website.Tracker_Index.ClickCreateButton();
            //Thread.Sleep(5000);
        }

        [When(@"I enter data into the input fields:")]
        public void WhenIEnterDataIntoTheInputFields(Table table)
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

        [When(@"I click the Back button on the Create page")]
        public void WhenIClickTheBackButtonOnTheCreatePage()
        {
            Website.Tracker_Create.ClickBackBtn();
        }

        [When(@"I go to the URL of the Create page for a tracker that does not exist")]
        public void WhenIGoToTheURLOfTheCreatePageForATrackerThatDoesNotExist()
        {
            Website.Tracker_Create.VisitCreatePage(-1);
        }

        [When(@"I try to access the Create page for a tracker of a valid trainee")]
        public void WhenITryToAccessTheCreatePageForATrackerOfAValidTrainee()
        {
            Website.Tracker_Create.VisitCreatePage(_traineeId);
        }

        [When(@"I click the Save button on the Create page")]
        public void WhenIClickTheSaveButtonOnTheCreatePage()
        {
            Website.Tracker_Create.ClickCreateBtn();
        }

        [Then(@"a new tracker is created with the details I entered")]
        public void ThenANewTrackerIsCreatedWithTheDetailsIEntered()
        {
            int newCount = Website.SeleniumDriver.FindElements(By.Id("table_row")).Count;
            Website.Tracker_Index.ClickDetailsButton(newCount - 1);

            Assert.That(newCount, Is.EqualTo(_trackerCount + 1));
            Assert.That(Website.Tracker_Details.CheckStopData(), Is.EqualTo(_stopData));
            Assert.That(Website.Tracker_Details.CheckStartData(), Is.EqualTo(_startData));
            Assert.That(Website.Tracker_Details.CheckContinueData(), Is.EqualTo(_continueData));
            Assert.That(Website.Tracker_Details.CheckCommentsData(), Is.EqualTo(_commentsData));
            Assert.That(Website.Tracker_Details.CheckTechnicalSkillData(), Is.EqualTo("Skilled"));
            Assert.That(Website.Tracker_Details.CheckConsultantSkillData(), Is.EqualTo("Skilled"));
        }

        [Scope(Feature = "Tracker_Create")]
        [Then(@"I should be taken to the Tracker Index page")]
        public void ThenIShouldBeTakenToTheIndexPage()
        {
            Assert.That(Website.Tracker_Index.CheckOnIndexPage());
        }

        [Scope(Feature = "Tracker_Create")]
        [Then(@"nothing should be displayed")]
        public void ThenNothingShouldBeDisplayed()
        {
            bool exceptionIsNotNull = false;
            try
            {
                Website.Tracker_Create.GetTechnicalDropDownText();
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
