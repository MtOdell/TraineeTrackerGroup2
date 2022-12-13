using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_UserIndexPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _userIndexPageUrl = AppConfigReader.UserIndexUrl;
        private IWebElement _editButton => SeleniumDriver.FindElement(By.Id("edit_button"));
        private IWebElement _profileButton => SeleniumDriver.FindElement(By.Id("profile_button"));
        private IWebElement _trackersButton => SeleniumDriver.FindElement(By.Id("trackers_button"));
        private IWebElement _deleteButton => SeleniumDriver.FindElement(By.Id("delete_button"));

        public SL_UserIndexPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitUserIndexPage() => SeleniumDriver.Navigate().GoToUrl(_userIndexPageUrl);
        public void ClickEditButton() => _editButton.Click();
        public void ClickProfileButton() => _profileButton.Click();
        public void ClickTrackersButton() => _trackersButton.Click();
        public void ClickDeleteButton() => _deleteButton.Click();
    }
}
