using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_LoginPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _loginPageUrl = AppConfigReader.LoginUrl;
        private IWebElement _passwordField => SeleniumDriver.FindElement(By.Id("password_field"));
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("email_field"));
        private IWebElement _loginButton => SeleniumDriver.FindElement(By.Id("login_submit"));
        private IWebElement _registerButton => SeleniumDriver.FindElement(By.Id("register_button"));
        private IWebElement _forgotPasswordButton => SeleniumDriver.FindElement(By.Id("forgot_password"));
        private IWebElement _errorMessage => SeleniumDriver.FindElement(By.CssSelector("[data-test=\"error\"]"));
        public SL_LoginPage(IWebDriver seleniumDriver)
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
        internal void EnterCredentials(Credentials credentials)
        {
            EnterEmail(credentials.Email);
            EnterPassword(credentials.Password);
        }
    }
}
