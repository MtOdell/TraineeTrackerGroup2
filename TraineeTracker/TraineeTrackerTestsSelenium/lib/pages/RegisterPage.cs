using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.pages
{
    public class RegisterPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _registerPageUrl = "https://localhost:7166/Identity/Account/Register";
        private IWebElement _passwordField => SeleniumDriver.FindElement(By.Id("Input_Password"));
        private IWebElement _confirmPasswordField => SeleniumDriver.FindElement(By.Id("Input_ConfirmPassword"));
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("Input_Email"));
        private IWebElement _registerButton => SeleniumDriver.FindElement(By.Id("registerSubmit"));
        private IWebElement _loginPageButton => SeleniumDriver.FindElement(By.Id("login_page_button"));
        public RegisterPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }
        public void VisitRegisterPage() => SeleniumDriver.Navigate().GoToUrl(_registerPageUrl);
        public void EnterEmail(string email) => _emailField.SendKeys(email);
        public void EnterPassword(string password) => _passwordField.SendKeys(password);
        public void EnterConfirmPassword(string confirmPassword) => _confirmPasswordField.SendKeys(confirmPassword);
        public void ClickRegisterButton() => _registerButton.Click();
        public void ClickLoginPageButton() => _loginPageButton.Click();

        public void EnterRegisterInfo(RegisterInfo registerInfo)
        {
            EnterEmail(registerInfo.Email);
            EnterPassword(registerInfo.Password);
            EnterConfirmPassword(registerInfo.ConfirmPassword);
        }
    }
}
