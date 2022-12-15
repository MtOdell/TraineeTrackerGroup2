using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.pages
{
    public class LoginPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _loginPageUrl = "https://localhost:7166/Identity/Account/Login";
        private IWebElement _passwordField => SeleniumDriver.FindElement(By.Id("Input_Password"));
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("Input_Email"));
        private IWebElement _loginButton => SeleniumDriver.FindElement(By.Id("login_submit"));
        private IWebElement _registerButton => SeleniumDriver.FindElement(By.Id("register_page_button"));
        private IWebElement _forgotPasswordButton => SeleniumDriver.FindElement(By.Id("forgot_password"));
        private IWebElement _errorMessage => SeleniumDriver.FindElement(By.CssSelector("div[class='text-danger validation-summary-errors']"));
        public LoginPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }
        public void VisitLoginPage() => SeleniumDriver.Navigate().GoToUrl(_loginPageUrl);
        public void EnterEmail(string email) => _emailField.SendKeys(email);
        public void EnterPassword(string password) => _passwordField.SendKeys(password);
        public void ClickLoginButton() => _loginButton.Click();
        public void ClickRegisterButton() => _registerButton.Click();
        public void ClickForgotPasswordButton() => _forgotPasswordButton.Click();
        public string CheckErrorMessage() => _errorMessage.Text;
        internal void EnterCredentials(Credentials cred)
        {
            EnterEmail(cred.Email);
            EnterPassword(cred.Password);
        }
    }
}
