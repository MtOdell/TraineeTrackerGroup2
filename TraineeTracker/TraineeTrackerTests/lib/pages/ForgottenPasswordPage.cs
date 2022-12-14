using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class ForgottenPasswordPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _forgottenPasswordPageUrl = AppConfigReader.ForgotPasswordUrl;
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("email_field"));
        private IWebElement _resetPasswordButton => SeleniumDriver.FindElement(By.Id("submit_button"));
        public ForgottenPasswordPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }
        public void VisitLoginPage() => SeleniumDriver.Navigate().GoToUrl(_forgottenPasswordPageUrl);
        public void EnterEmail(string email) => _emailField.SendKeys(email);
        public void ClickLoginButton() => _resetPasswordButton.Click();
    }
}
