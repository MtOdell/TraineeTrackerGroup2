using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.tests
{
    [Scope(Feature = "RegisterPage_Feature")]
    [Binding]
    public class RegisterPage_FeatureStepDefinitions
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        protected RegisterInfo _registerInfo;
        [AfterScenario]
        public void DisposeWebDriver()
        {
            Website.SeleniumDriver.Quit();
        }
        [Given(@"I am on the register page")]
        public void GivenIAmOnTheRegisterPage()
        {
            Website.RegisterPage.VisitRegisterPage();
        }

        [Given(@"I input valid info to register")]
        public void GivenIInputValidInfoToRegister(Table table)
        {
            _registerInfo = table.CreateInstance<RegisterInfo>();
        }
        [Given(@"enter these registerInfo")]
        public void GivenEnterTheseRegisterInfo()
        {
            Website.RegisterPage.EnterRegisterInfo(_registerInfo);
        }

        [When(@"I press the register button")]
        public void WhenIPressTheRegisterButton()
        {
            Website.RegisterPage.ClickRegisterButton();
        }
        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            Website.RegisterPage.ClickLoginPageButton();
        }

        [Then(@"I am on the login page")]
        public void ThenIAmOnTheLoginPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/Login"));
        }

        [Then(@"I am on the edit page")]
        public void ThenIAmOnTheEditPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/UserDatas/Edit/25"));
        }

        [Then(@"I get an error (.*)")]
        public void ThenIGetAnError(string error)
        {
            Assert.That(Website.RegisterPage.CheckEmailErrorMessage(), Does.Contain(error));
        }
        [Then(@"I get the passwords dont match error")]
        public void ThenIGetThePasswordsDontMatchError()
        {
            Assert.That(Website.RegisterPage.CheckConfirmPasswordErrorMessage(), Does.Contain("The password and confirmation password do not match"));
        }
        [Then(@"I get the password is invalid error")]
        public void ThenIGetThePasswordIsInvalidError()
        {
            Assert.That(Website.RegisterPage.CheckPasswordErrorMessage(), Does.Contain("Must have 6 letters, 1 Capital, 1 Number, 1 Special character.")); ;
        }


    }
}
