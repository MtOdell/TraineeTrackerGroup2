using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_UserDetailsPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _userDetailsPageUrl = AppConfigReader.UserDetailsUrl;
        private IWebElement _editButton => SeleniumDriver.FindElement(By.Id("edit_button"));
        private IWebElement _backButton => SeleniumDriver.FindElement(By.Id("back_button"));

        public SL_UserDetailsPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitUserDetailsPage() => SeleniumDriver.Navigate().GoToUrl(_userDetailsPageUrl);
        public void ClickEditButton() => _editButton.Click();
        public void ClickBackButton() => _backButton.Click();
    }
}
