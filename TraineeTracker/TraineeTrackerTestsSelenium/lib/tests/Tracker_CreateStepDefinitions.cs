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
        public void Login()
        {
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterCredentials(_credentials);
            Website.LoginPage.ClickLoginButton();
        }

        [Scope(Feature = "Tracker_Create")]
        [AfterScenario]
        public void CleanUp()
        {
            Website.SeleniumDriver.Quit();
        }

        [Scope(Feature = "Tracker_Create")]
        [Given(@"I am a valid trainer")]
        
        public void GivenIAmAValidTrainer()
        {
            _credentials.Email = "Phil@SpartaGlobal.com";
            _credentials.Password = "Password1!";
            Login();
        }

        [Scope(Feature = "Tracker_Create")]
        [Given(@"I am a valid trainee")]
        public void GivenIAmAValidTrainee()
        {
            _credentials.Email = "Adam@SpartaGlobal.com";
            _credentials.Password = "Password1!";
            Login();
        }


        [Given(@"I am on the Create page")]
        public void GivenIAmOnTheCreatePage()
        {
            Website.Tracker_Index.VisitIndexPage(17);
            _trackerCount = Website.Tracker_Index.CountRows();
            Website.Tracker_Create.VisitCreatePage(_traineeId);
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
            Website.Tracker_Index.ClickDetailsBtn(newCount - 1);

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

        [Scope(Feature = "Tracker_Create")]
        [Then(@"I should be blocked from accessing the page")]
        public void ThenIShouldBeBlockedFromAccessingThePage()
        {
            Assert.That(Website.Tracker_Create.CheckOnCreatePage(), Is.False);
        }

        [Scope(Feature = "Tracker_Create")]
        [Then(@"an access denied message should appear")]
        public void ThenAnAccessDeniedMessageShouldAppear()
        {
            string accessDeniedMessage = String.Empty;
            try
            {
                accessDeniedMessage = Website.Tracker_Delete.GetAccessDeniedParagraphText();
            }
            catch (NoSuchElementException e)
            {

            }

            Assert.That(accessDeniedMessage.Contains("You do not have access to this resource."));
        }
    }
}
