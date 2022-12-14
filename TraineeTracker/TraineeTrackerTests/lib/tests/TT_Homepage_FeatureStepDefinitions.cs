using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class TT_Homepage_FeatureStepDefinitions
    {
        private SL_Website<ChromeDriver> SL_Website;
        [Given(@"I have a browser open")]
        public void GivenIHaveABrowserOpen()
        {
            SL_Website = new SL_Website<ChromeDriver>();
            SL_Website.SeleniumDriver.Manage().Window.Maximize();
        }

        [Given(@"I am on a homepage")]
        public void GivenIAmOnAHomepage()
        {
            SL_Website.SL_HomePage.VisitHomePage();
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            SL_Website.SL_HomePage.ClickLoginButton();
        }

        [Then(@"I am redirected to the login page")]
        public void ThenIAmRedirectedToTheLoginPage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.LoginUrl));
        }

        [When(@"I press register button")]
        public void WhenIPressRegisterButton()
        {
            SL_Website.SL_HomePage.ClickRegisterButton();
        }

        [Then(@"I am redirected to the register page")]
        public void ThenIAmRedirectedToTheRegisterPage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.RegisterUrl));
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            SL_Website.SL_LoginPage.VisitLoginPage();
            SL_Website.SL_LoginPage.EnterEmail("Phil@SpartaGlobal.com");
            SL_Website.SL_LoginPage.EnterPassword("Password1!");
            SL_Website.SL_LoginPage.ClickLoginButton();
        }

        [Then(@"Nothing happens")]
        public void ThenNothingHappens()
        {
            throw new PendingStepException();
        }

        [When(@"I press user button")]
        public void WhenIPressUserButton()
        {
            SL_Website.SL_HomePage.ClickUserButton();
        }

        [Then(@"I am redirected to the user page")]
        public void ThenIAmRedirectedToTheUserPage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.UserUrl));
        }

        [When(@"I press privacy button")]
        public void WhenIPressPrivacyButton()
        {
            SL_Website.SL_HomePage.ClickPrivacyButton();
        }

        [Then(@"I am redirected to the privacy page")]
        public void ThenIAmRedirectedToThePrivacyPage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.PrivacyUrl));
        }
    }
}
