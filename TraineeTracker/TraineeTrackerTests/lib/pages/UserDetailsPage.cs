using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class UserDetailsPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _userDetailsPageUrl = "https://localhost:7166/UserDatas/Details/";
        private IWebElement _editButton => SeleniumDriver.FindElement(By.Id("edit_button"));
        private IWebElement _backButton => SeleniumDriver.FindElement(By.Id("back_button"));

        public UserDetailsPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitUserDetailsPage() => SeleniumDriver.Navigate().GoToUrl(_userDetailsPageUrl);
        public void ClickEditButton() => _editButton.Click();
        public void ClickBackButton() => _backButton.Click();
    }
}
