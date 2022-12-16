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
        private string _forgottenPasswordPageUrl = "https://localhost:7166/Identity/Account/ForgotPassword";
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("email_field"));
        private IWebElement _resetPasswordButton => SeleniumDriver.FindElement(By.Id("submit_button"));
        private IWebElement _emailErrorMessage => SeleniumDriver.FindElement(By.CssSelector("span[class='text-danger field-validation-error']"));
        public ForgottenPasswordPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }
        public void VisitForgottenPasswordPage() => SeleniumDriver.Navigate().GoToUrl(_forgottenPasswordPageUrl);
        public void EnterEmail(string email) => _emailField.SendKeys(email);
        public void ClickResetPasswordButton() => _resetPasswordButton.Click();
        public string CheckEmailErrorMessage() => _emailErrorMessage.Text;
    }
}
