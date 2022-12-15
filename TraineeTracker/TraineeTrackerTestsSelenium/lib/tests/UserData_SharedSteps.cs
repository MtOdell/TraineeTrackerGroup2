using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    public class UserData_SharedSteps
    {
        public Website<FirefoxDriver> Website { get; } = new Website<FirefoxDriver>();

        [Given(@"I am on the Login Page")]
        public void GivenIAmOnTheLoginPage()
        {
            Website.SL_LoginPage.VisitLoginPage();
        }

        [Given(@"I use Admin credentials")]
        public void GivenIUseAdminCredentials()
        {
            Website.SL_LoginPage.EnterEmail("Admin@SpartaGlobal.com");
            Website.SL_LoginPage.EnterPassword("Password1!");
        }

        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            Website.SL_LoginPage.ClickLoginButton();
        }

        [AfterScenario]
        public void DiposeWebDriver()
        {
            Website.SeleniumDriver.Quit();
        }
    }
}
