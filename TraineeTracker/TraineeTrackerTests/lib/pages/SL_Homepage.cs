using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTrackerTests.lib.driver_config;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_Homepage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _homePageUrl = AppConfigReader.BaseUrl;

        private IWebElement _loginButton => SeleniumDriver.FindElement(By.Id("login_button"));
        private IWebElement _navBar => SeleniumDriver.FindElement(By.Id("navbar_button"));
        private IWebElement _navBarUser => SeleniumDriver.FindElement(By.Id("navbar_user"));
        private IWebElement _navBarPrivacy => SeleniumDriver.FindElement(By.Id("navbar_privacy"));
        private IWebElement _navBarRegister => SeleniumDriver.FindElement(By.Id("register_button"));

        public SL_Homepage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitHomePage() => SeleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void ClickLoginButton() => _loginButton.Click();

        public void ClickRegisterButton() 
        {
            _navBar.Click();
            _navBarRegister.Click();
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
    } 
}
