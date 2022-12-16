using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    [Binding]
    public class ForgottenPasswordPageFetaureStepDefinitions
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        [AfterScenario]
        public void DisposeWebDriver()
        {
            Website.SeleniumDriver.Quit();
        }
        [Given(@"I am on the ForgottenPasswordPage")]
        public void GivenIAmOnTheForgottenPasswordPage()
        {
            Website.ForgottenPasswordPage.VisitForgottenPasswordPage();
        }

        [Given(@"I enter a email (.*)")]
        public void GivenIEnterAValidEmail(string email)
        {
            Website.ForgottenPasswordPage.EnterEmail(email);
        }

        [When(@"I press reset password")]
        public void WhenIPressResetPassword()
        {
            Website.ForgottenPasswordPage.ClickResetPasswordButton();
        }

        [Then(@"I am on the confirmation page")]
        public void ThenIAmTakneToTheConfirmationPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7166/Identity/Account/ForgotPasswordConfirmation"));
        }
        [Then(@"I am given the not valid email address error")]
        public void ThenIAmGivenTheNotValidEmailAddressError()
        {
            Assert.That(Website.ForgottenPasswordPage.CheckEmailErrorMessage(), Does.Contain("The Email field is not a valid e-mail address"));
        }

    }
}
