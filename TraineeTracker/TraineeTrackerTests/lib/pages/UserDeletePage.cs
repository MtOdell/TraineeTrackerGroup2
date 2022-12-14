using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class UserDeletePage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _userDeletePageUrl = "https://localhost:7166/UserDatas/Delete/";
        private IWebElement _deleteButton => SeleniumDriver.FindElement(By.Id("delete_button"));
        private IWebElement _backButton => SeleniumDriver.FindElement(By.Id("back_button"));

        public UserDeletePage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitUserDeletePage() => SeleniumDriver.Navigate().GoToUrl(_userDeletePageUrl);
        public void ClickDeleteButton() => _deleteButton.Click();
        public void ClickBackButton() => _backButton.Click();
    }
}
