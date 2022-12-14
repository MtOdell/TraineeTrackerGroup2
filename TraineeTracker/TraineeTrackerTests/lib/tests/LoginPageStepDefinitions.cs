using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.tests
{

    [Binding]
    public class LoginPageStepDefinitions
    {
        public Website<ChromeDriver> SL_Website { get; } = new Website<ChromeDriver>();
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
        [When(@"I click the forgot password button")]
        public void WhenIClickTheForgotPasswordButton()
        {
            SL_Website.SL_LoginPage.ClickForgotPasswordButton();
        }
        [Then(@"I am taken to the (.*) page")]
        public void ThenIAmTakenToTheRegisterPage(string url)
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(url));
        }

        [Then(@"I am on the home page")]
        public void ThenIAmTakenToTheHomePage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/"));
        }
    }
}
