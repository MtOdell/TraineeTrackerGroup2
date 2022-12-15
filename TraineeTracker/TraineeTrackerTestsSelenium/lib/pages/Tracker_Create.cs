using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class Tracker_Create
    {
        private IWebDriver SeleniumDriver { get; }
        private IWebElement GetStopInput => SeleniumDriver.FindElement(By.Id("stop_input"));
        private IWebElement GetStartInput => SeleniumDriver.FindElement(By.Id("start_input"));
        private IWebElement GetContinueInput => SeleniumDriver.FindElement(By.Id("continue_input"));
        private IWebElement GetTechnicalDropDown => SeleniumDriver.FindElement(By.Id("technical_dropdown"));
        private IWebElement GetConsultantDropDown => SeleniumDriver.FindElement(By.Id("consultant_dropdown"));
        private IWebElement GetCreateBtn => SeleniumDriver.FindElement(By.Id("submit_btn"));
        private IWebElement GetBackBtn => SeleniumDriver.FindElement(By.Id("back_btn"));

        private string _createUrl = "https://localhost:7166/Trackers/Create";

        public Tracker_Create(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitCreatePage(int id) => SeleniumDriver.Navigate().GoToUrl($@"{_createUrl}/{id}");
        public bool CheckOnCreatePage() => SeleniumDriver.Url.Contains("https://localhost:7166/Trackers/Create");
        public void GiveStopInput(string input) => GetStopInput.SendKeys(input);
        public void GiveStartInput(string input) => GetStartInput.SendKeys(input);
        public void GiveContinueInput(string input) => GetContinueInput.SendKeys(input);
        // Tech dropdown
        //public void SelectTechnicalDropDownOption() => GetTechnicalDropDown.
        // Consult dropdown
        public void ClickCreateBtn() => GetCreateBtn.Click();
        public void ClickBackBtn() => GetBackBtn.Click();
    }
}
