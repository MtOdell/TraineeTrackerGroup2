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
    [Binding]
    public class UserData_SharedSteps
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();

        [Given(@"I am on the Login Page")]
        public void GivenIAmOnTheLoginPage()
        {
            Website.LoginPage.VisitLoginPage();
        }

        [Given(@"I use Admin credentials")]
        public void GivenIUseAdminCredentials()
        {
            Website.LoginPage.EnterEmail("Admin@SpartaGlobal.com");
            Website.LoginPage.EnterPassword("Password1!");
        }

        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            Website.LoginPage.ClickLoginButton();
        }

        [AfterScenario]
        public void DiposeWebDriver()
        {
            Website.SeleniumDriver.Quit();
        }
    }
}
