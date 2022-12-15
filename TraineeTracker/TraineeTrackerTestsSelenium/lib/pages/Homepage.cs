using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTrackerTests.lib.driver_config;

namespace TraineeTrackerTests.lib.pages
{
    public class Homepage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _homePageUrl = "https://localhost:7166/";

        private IWebElement _loginButtonHomepage => SeleniumDriver.FindElement(By.Id("login_button_homepage"));
        private IWebElement _navBar => SeleniumDriver.FindElement(By.Id("navbar_button"));
        private IWebElement _navBarUser => SeleniumDriver.FindElement(By.Id("navbar_user"));
        private IWebElement _navBarPrivacy => SeleniumDriver.FindElement(By.Id("navbar_privacy"));
        private IWebElement _navBarRegister => SeleniumDriver.FindElement(By.Id("register_button"));

        private IWebElement _navBarLogOut;

        public Homepage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitHomePage() => SeleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void ClickLoginButton() => _loginButtonHomepage.Click();

        public string CheckLoginButtonText() => _loginButtonHomepage.Text;

        public void ClickRegisterButton() 
        {
            if (_navBarRegister is null)
                throw new Exception("User already logged in");
            else
            {
                _navBar.Click();
                _navBarRegister.Click();
            }
        }

        public void ClickPrivacyButton()
        {
            _navBar.Click();
            _navBarPrivacy.Click();
        }

        public void ClickUserButton()
        {
            _navBar.Click();
            _navBarUser.Click();
        }

        internal void ClickLogoutButton()
        {
            _navBarLogOut = SeleniumDriver.FindElement(By.Id("logout_button"));
            _navBar.Click();
            _navBarLogOut.Click();
        }
    } 
}
