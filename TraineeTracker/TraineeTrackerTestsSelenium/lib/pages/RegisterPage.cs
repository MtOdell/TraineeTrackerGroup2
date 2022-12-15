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
        private IWebElement _emailErrorMessage => SeleniumDriver.FindElement(By.Id("email_field")).FindElement(By.CssSelector("span[class='text-danger field-validation-error']"));
        private IWebElement _passwordErrorMessage => SeleniumDriver.FindElement(By.Id("password_field")).FindElement(By.CssSelector("span[class='text-danger field-validation-error']"));
        private IWebElement _confirmPasswordErrorMessage => SeleniumDriver.FindElement(By.Id("confirm_password_field")).FindElement(By.CssSelector("span[class='text-danger field-validation-error']"));
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
        public string CheckEmailErrorMessage() => _emailErrorMessage.Text;
        public string CheckPasswordErrorMessage() => _passwordErrorMessage.Text;
        public string CheckConfirmPasswordErrorMessage() => _confirmPasswordErrorMessage.Text;
        public void EnterRegisterInfo(RegisterInfo registerInfo)
        {
            EnterEmail(registerInfo.Email);
            EnterPassword(registerInfo.Password);
            EnterConfirmPassword(registerInfo.ConfirmPassword);
        }
    }
}
