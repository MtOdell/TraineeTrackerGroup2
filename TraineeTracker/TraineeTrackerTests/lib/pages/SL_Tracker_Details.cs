using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_Tracker_Details
    {
        private IWebDriver SeleniumDriver { get; }
        private IWebElement GetStopData => SeleniumDriver.FindElement(By.Id("stop_data"));
        private IWebElement GetStartData => SeleniumDriver.FindElement(By.Id("start_data"));
        private IWebElement GetContinueData => SeleniumDriver.FindElement(By.Id("continue_data"));
        private IWebElement GetTechnicalSkillData => SeleniumDriver.FindElement(By.Id("technical_data"));
        private IWebElement GetConsultantSkillData => SeleniumDriver.FindElement(By.Id("consultant_data"));
        private IWebElement GetEditBtn => SeleniumDriver.FindElement(By.Id("edit_btn"));
        private IWebElement GetBackBtn => SeleniumDriver.FindElement(By.Id("back_btn"));

        private string _detailsUrl = AppConfigReader.TrackerDetailsUrl;

        public SL_Tracker_Details(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitDetailsPage(int id) => SeleniumDriver.Navigate().GoToUrl($@"{_detailsUrl}/{id}");
        public string CheckStopData() => GetStopData.Text;
        public string CheckStartData() => GetStartData.Text;
        public string CheckContinueData() => GetContinueData.Text;
        public string CheckTechnicalSkillData() => GetTechnicalSkillData.Text;
        public string CheckConsultantSkillData() => GetConsultantSkillData.Text;
        public void ClickEditBtn() => GetEditBtn.Click();
        public void ClickBackBtn() => GetBackBtn.Click();
    }
}
