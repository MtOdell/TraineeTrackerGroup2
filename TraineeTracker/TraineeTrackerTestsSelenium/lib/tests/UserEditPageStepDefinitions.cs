using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    [Scope(Feature = "UserEditPage")]
    public class UserEditPageStepDefinitions : UserData_SharedSteps
    {
        [Given(@"I am on the User Edit Page")]
        public void GivenIAmOnTheUserEditPage()
        {
            Website.UserEditPage.VisitUserEditPage();
        }

        [Given(@"I input valid information")]
        public void GivenIInputValidInformation()
        {
            Website.UserEditPage.EnterFirstName("Walter");
            Website.UserEditPage.EnterLastName("White");
            Website.UserEditPage.EnterTitle("Prof.");
            Website.UserEditPage.EnterEducation("MSc Chemistry");
            Website.UserEditPage.EnterExperience("20 years");
            Website.UserEditPage.EnterActivity("Cooking");
            Website.UserEditPage.EnterBiography("6 Seasons");
            Website.UserEditPage.EnterSkills("Chemistry");
        }

        [Given(@"I input invalid information")]
        public void GivenIInputInvalidInformation()
        {
            Website.UserEditPage.EnterFirstName("rthbtsbgh");
            Website.UserEditPage.EnterLastName("gfsbtrhbrst");
            Website.UserEditPage.EnterTitle("fgshtsrrth");
            Website.UserEditPage.EnterEducation("tsrghrtg");
            Website.UserEditPage.EnterExperience("dsthtrsgrt");
            Website.UserEditPage.EnterActivity("sthrsttfd");
            Website.UserEditPage.EnterBiography("htrshsfghfg");
            Website.UserEditPage.EnterSkills("dfhttdtn");
        }

        [When(@"I click on the save button")]
        public void WhenIClickOnTheSaveButton()
        {
            Website.UserEditPage.VisitUserEditPage();
        }

        [When(@"I click on the Back button")]
        public void WhenIClickOnTheBackButton()
        {
            Website.UserEditPage.VisitUserEditPage();
        }

        [Then(@"The user is edited")]
        public void ThenTheUserIsEdited()
        {
            throw new PendingStepException();
        }

        [Then(@"The error messages are shown")]
        public void ThenTheErrorMessagesAreShown()
        {
            throw new PendingStepException();
        }

        [Then(@"I am on the Index Page")]
        public void ThenIAmOnTheIndexPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Index/"));
        }
    }
}
