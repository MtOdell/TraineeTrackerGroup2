using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        private IWebElement GetCommentsInput => SeleniumDriver.FindElement(By.Id("comments_input"));
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
        public void GiveCommentsInput(string input) => GetCommentsInput.SendKeys(input);
        public void SelectTechnicalDropDownOption(string option)
        {
            var options = GetTechnicalDropDown.FindElements(By.TagName("option"));
            GetTechnicalDropDown.Click();

            switch (option)
            {
                case "Skilled":
                    options[1].Click();
                    break;
                case "Partially_Skilled":
                    options[2].Click();
                    break;
                case "Low_Skilled":
                    options[3].Click();
                    break;
                case "Unskilled":
                    options[4].Click();
                    break;
                default:
                    throw new ArgumentException("Invalid option selected");
            }
        }
        public string GetTechnicalDropDownText() => GetTechnicalDropDown.Text;
        public void SelectConsultantDropDownOption(string option)
        {
            var options = GetConsultantDropDown.FindElements(By.TagName("option"));

            switch (option)
            {
                case "Skilled":
                    options[1].Click();
                    break;
                case "Partially_Skilled":
                    options[2].Click();
                    break;
                case "Low_Skilled":
                    options[3].Click();
                    break;
                case "Unskilled":
                    options[4].Click();
                    break;
                default:
                    throw new ArgumentException("Invalid option selected");
            }
        }
        public string GetConsultantDropDownText() => GetConsultantDropDown.Text;
        public void ClickCreateBtn() => GetCreateBtn.Click();
        public void ClickBackBtn() => GetBackBtn.Click();
    }
}
