using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.tests
{

    [Binding]
    public class TT_LoginPageStepDefinitions
    {
        public SL_Website<ChromeDriver> SL_Website { get; } = new SL_Website<ChromeDriver>();
        protected Credentials _credentials;
        [Given(@"I am on the Loginpage")]
        public void GivenIAmOnTheLoginpage()
        {
            SL_Website.SL_LoginPage.VisitLoginPage();
        }
        [Given(@"And I have the following credentials:")]
        public void GivenAndIHaveTheFollowingCredentials(Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
        }
        [Given(@"enter these credentials")]
        public void GivenEnterTheseCredentials()
        {
            SL_Website.SL_LoginPage.EnterCredentials(_credentials);
        }

        [Then(@"I am given an error message Invalid login attempt")]
        public void ThenIAmGivenAnErrorMessageInvalidLoginAttempt()
        {
            Assert.That(SL_Website.SL_LoginPage.CheckErrorMessage(), Does.Contain("Invalid login attempt"));
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            SL_Website.SL_LoginPage.ClickLoginButton();
        }
        [When(@"I click the register button")]
        public void WhenIClickTheRegisterButton()
        {
            SL_Website.SL_LoginPage.ClickRegisterButton();
        }

        [Then(@"I am taken to the register page")]
        public void ThenIAmTakenToTheRegisterPage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/Register"));
        }

        [Then(@"I am taken to the home page")]
        public void ThenIAmTakenToTheHomePage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/"));
        }
    }
}
