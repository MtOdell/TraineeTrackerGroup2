using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V106.Browser;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class Homepage_FeatureStepDefinitions
    {
        private Website<ChromeDriver> Website;
        private Exception exceptionCatch;
        [Given(@"I have a browser open")]
        public void GivenIHaveABrowserOpen()
        {
            Website = new Website<ChromeDriver>();
            Website.SeleniumDriver.Manage().Window.Maximize();
        }

        [Given(@"I am on a homepage")]
        public void GivenIAmOnAHomepage()
        {
            Website.Homepage.VisitHomePage();
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            Website.Homepage.ClickLoginButton();
        }

        [Then(@"I am redirected to the login page")]
        public void ThenIAmRedirectedToTheLoginPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Does.Contain("https://localhost:7166/Identity/Account/Login"));
        }

        [When(@"I press register button")]
        public void WhenIPressRegisterButton()
        {
            try
            {
                Website.Homepage.ClickRegisterButton();
            } catch (Exception e)
            {
                exceptionCatch = e;
            }
        }

        [Then(@"I am redirected to the register page")]
        public void ThenIAmRedirectedToTheRegisterPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/Register"));
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            Website.LoginPage.VisitLoginPage();
            Website.LoginPage.EnterEmail("Phil@SpartaGlobal.com");
            Website.LoginPage.EnterPassword("Password1!");
            Website.LoginPage.ClickLoginButton();
        }

        [Then(@"Error is thrown")]
        public void ThenErrorIsThrown()
        {
            Assert.That(exceptionCatch, Is.TypeOf<Exception>());
        }


        [When(@"I press user button")]
        public void WhenIPressUserButton()
        {
            Website.Homepage.ClickUserButton();
        }

        [Then(@"I am redirected to the user page")]
        public void ThenIAmRedirectedToTheUserPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas"));
        }

        [When(@"I press privacy button")]
        public void WhenIPressPrivacyButton()
        {
            Website.Homepage.ClickPrivacyButton();
        }

        [Then(@"I am redirected to the privacy page")]
        public void ThenIAmRedirectedToThePrivacyPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Home/Privacy"));
        }

        [When(@"I press logout")]
        public void WhenIPressLogout()
        {
            Website.Homepage.ClickLogoutButton();
        }

        [Then(@"I am logged out")]
        public void ThenIAmLoggedOut()
        {
            Assert.That(Website.Homepage.CheckLoginButtonText(), Is.EqualTo("Sign-in"));
        }

        [Then(@"I am redirected the home page")]
        public void ThenIAmRedirectedTheHomePage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/"));
        }


        [AfterTestRun]
        public static void AfterTestRun(Website<ChromeDriver> Website)
        {
            Website.SeleniumDriver.Quit();
            Website.SeleniumDriver.Dispose();
        }
    }
}
