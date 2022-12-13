using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_Tracker_Edit
    {
        private IWebDriver SeleniumDriver { get; }
        private IWebElement GetStopInput => SeleniumDriver.FindElement(By.Id("stop_input"));
        private IWebElement GetStartInput => SeleniumDriver.FindElement(By.Id("start_input"));
        private IWebElement GetContinueInput => SeleniumDriver.FindElement(By.Id("continue_input"));
        private IWebElement GetTechnicalDropDown => SeleniumDriver.FindElement(By.Id("technical_dropdown"));
        private IWebElement GetConsultantDropDown => SeleniumDriver.FindElement(By.Id("consultant_dropdown"));
        private IWebElement GetSaveBtn => SeleniumDriver.FindElement(By.Id("submit_btn"));
        private IWebElement GetBackBtn => SeleniumDriver.FindElement(By.Id("back_btn"));

        private string _editUrl = AppConfigReader.TrackerEditUrl;

        public SL_Tracker_Edit(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitEditUrl(int id) => SeleniumDriver.Navigate().GoToUrl($@"{_editUrl}/{id}");
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
