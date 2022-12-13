using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTests.lib.tests
{

    [Binding]
    public class SL_LoginPageStepDefinitions
    {
        public SL_Website<ChromeDriver> SL_Website { get; } = new SL_Website<ChromeDriver>();
        [Given(@"I am on the Loginpage")]
        public void GivenIAmOnTheLoginpage()
        {
            SL_Website.SL_LoginPage.VisitLoginPage();
        }

        [Given(@"I enter a valid email")]
        public void GivenIEnterAValidEmail()
        {
            SL_Website.SL_LoginPage.EnterEmail("Nish@SpartaGlobal.com");
        }

        [Given(@"I enter a valid password")]
        public void GivenIEnterAValidPassword()
        {
            SL_Website.SL_LoginPage.EnterPassword("Password1!");
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            SL_Website.SL_LoginPage.ClickLoginButton();
        }

        [Then(@"I am taken to the home page")]
        public void ThenIAmTakenToTheHomePage()
        {
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/"));
        }
    }
}
