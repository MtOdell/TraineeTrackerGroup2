using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class Tracker_Edit
    {
        private IWebDriver SeleniumDriver { get; }
        public IWebElement GetStopInput => SeleniumDriver.FindElement(By.Id("stop_input"));
        public IWebElement GetStartInput => SeleniumDriver.FindElement(By.Id("start_input"));
        public IWebElement GetContinueInput => SeleniumDriver.FindElement(By.Id("continue_input"));
        public IWebElement GetTechnicalDropDown => SeleniumDriver.FindElement(By.Id("technical_dropdown"));
        public IWebElement GetConsultantDropDown => SeleniumDriver.FindElement(By.Id("consultant_dropdown"));
        private IWebElement GetSaveBtn => SeleniumDriver.FindElement(By.Id("submit_btn"));
        private IWebElement GetBackBtn => SeleniumDriver.FindElement(By.Id("back_btn"));

        private string _editUrl = "https://localhost:7166/Trackers/Edit";

        public Tracker_Edit(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitEditPage(int id) => SeleniumDriver.Navigate().GoToUrl($@"{_editUrl}/{id}");
        public bool CheckOnEditPage() => SeleniumDriver.Url.Contains("https://localhost:7166/Trackers/Edit");
        public void GiveStopInput(string input) => GetStopInput.SendKeys(input);
        public string CheckStopValue() => GetStopInput.Text;
        public void GiveStartInput(string input) => GetStartInput.SendKeys(input);
        public string CheckStartValue() => GetStartInput.Text;
        public void GiveContinueInput(string input) => GetContinueInput.SendKeys(input);
        public string CheckContinueValue() => GetContinueInput.Text;
        public void ClickSaveBtn() => GetSaveBtn.Click();
        public void ClickBackBtn() => GetBackBtn.Click();
    }
}
