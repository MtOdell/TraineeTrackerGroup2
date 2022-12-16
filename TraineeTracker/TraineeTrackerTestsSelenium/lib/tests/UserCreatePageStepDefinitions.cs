using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    [Scope(Feature = "UserCreatePage")]
    public class UserCreatePageStepDefinitions : UserData_SharedSteps
    {   
        [Given(@"I am on the User Create Page")]
        public void GivenIAmOnTheUserCreatePage()
        {
            Website.UserCreatePage.VisitUserCreatePage();
        }

        [Given(@"I input valid information with an ""([^""]*)""")]
        public void GivenIInputValidInformationWithAn(string id)
        {
            Website.UserCreatePage.EnterUserId(id);
            Website.UserCreatePage.EnterFirstName("Walter");
            Website.UserCreatePage.EnterLastName("White");
            Website.UserCreatePage.EnterTitle("Prof.");
            Website.UserCreatePage.EnterEducation("MSc Chemistry");
            Website.UserCreatePage.EnterExperience("20 years");
            Website.UserCreatePage.EnterActivity("Cooking");
            Website.UserCreatePage.EnterBiography("6 Seasons");
            Website.UserCreatePage.EnterSkills("Chemistry");
        }

        [Given(@"I input invalid information with an ""([^""]*)""")]
        public void GivenIInputInvalidInformationWithAn(string id)
        {
            Website.UserCreatePage.EnterUserId(id);
            Website.UserCreatePage.EnterFirstName("fdsbreasb");
            Website.UserCreatePage.EnterLastName("afdbrtfdab");
            Website.UserCreatePage.EnterTitle("afbrfegbdarf");
            Website.UserCreatePage.EnterEducation("fbrteahgrethrea");
            Website.UserCreatePage.EnterExperience("fdagfba");
            Website.UserCreatePage.EnterActivity("fsdbtdsfa");
            Website.UserCreatePage.EnterBiography("drgbtdar");
            Website.UserCreatePage.EnterSkills("dahgrdgdar");
        }

        [When(@"I click on the create button")]
        public void WhenIClickOnTheCreateButton()
        {
            Website.UserCreatePage.ClickCreateButton();
        }

        [When(@"I click on the Back To List button")]
        public void WhenIClickOnTheBackToListButton()
        {
            Website.UserCreatePage.ClickBackToListButton();
        }

        [Then(@"The user is created")]
        public void ThenTheUserIsCreated()
        {
            Website.UserDetailsPage.VisitUserDetailsPage();
        }

        [Then(@"The user is not created")]
        public void ThenTheUserIsNotCreated()
        {
            throw new PendingStepException();
        }

        [Then(@"I am on the Index Page")]
        public void ThenIAmOnTheIndexPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Does.Contain("https://localhost:7166/UserDatas/Index/"));
        }
    }
}
