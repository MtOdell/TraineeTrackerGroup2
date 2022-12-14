using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class Tracker_Delete
    {
        private IWebDriver SeleniumDriver { get; }
        private IWebElement GetStopData => SeleniumDriver.FindElement(By.Id("stop_data"));
        private IWebElement GetStartData => SeleniumDriver.FindElement(By.Id("start_data"));
        private IWebElement GetContinueData => SeleniumDriver.FindElement(By.Id("continue_data"));
        private IWebElement GetTechnicalSkillData => SeleniumDriver.FindElement(By.Id("technical_data"));
        private IWebElement GetConsultantSkillData => SeleniumDriver.FindElement(By.Id("consultant_data"));
        private IWebElement GetDeleteBtn => SeleniumDriver.FindElement(By.Id("delete_btn"));
        private IWebElement GetBackBtn => SeleniumDriver.FindElement(By.Id("back_btn"));

        private string _deleteUrl = "https://localhost:7166/UserDatas/Delete/";

        public Tracker_Delete(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitDeletePage(int id) => SeleniumDriver.Navigate().GoToUrl($@"{_deleteUrl}/{id}");
        public string CheckStopData() => GetStopData.Text;
        public string CheckStartData() => GetStartData.Text;
        public string CheckContinueData() => GetContinueData.Text;
        public string CheckTechnicalSkillData() => GetTechnicalSkillData.Text;
        public string CheckConsultantSkillData() => GetConsultantSkillData.Text;
        public void ClickDeleteBtn() => GetDeleteBtn.Click();
        public void ClickBackBtn() => GetBackBtn.Click();
    }
}
