using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class Tracker_Index
    {
        private IWebDriver SeleniumDriver { get; }
        private IWebElement GetCreateBtn => SeleniumDriver.FindElement(By.Id("create_btn"));
        private IWebElement GetBackBtn => SeleniumDriver.FindElement(By.Id("back_btn"));
        private ReadOnlyCollection<IWebElement> GetDetailsBtns => SeleniumDriver.FindElements(By.Id("details_btn"));
        private IWebElement GetPieChartElement1 => SeleniumDriver.FindElement(By.Id("piechart"));
        private IWebElement GetPieChartElement2 => SeleniumDriver.FindElement(By.Id("piechart_two"));

        private string _indexUrl = "https://localhost:7166/Trackers/Index";

        public Tracker_Index(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitIndexPage(int id) => SeleniumDriver.Navigate().GoToUrl($@"{_indexUrl}/{id}");
        public bool CheckOnIndexPage() => SeleniumDriver.Url.Contains("https://localhost:7166/Trackers/Index");
        public void ClickCreateBtn() => GetCreateBtn.Click();
        public void ClickBackBtn() => GetBackBtn.Click();
        public void ClickDetailsBtn(int index) => GetDetailsBtns[index].Click();
        public void ClickTrackerDeleteBtn(int week)
        {
            SeleniumDriver.FindElement(By.Id($"Delete{week}")).Click();
        }
        public ReadOnlyCollection<IWebElement> GetAllSectionsOfPieChart(int pieChartNumber)
        {
            if (pieChartNumber == 1)
            {
                return GetPieChartElement1.FindElements(By.TagName("g"));
            }
            else if (pieChartNumber == 2)
            {
                return GetPieChartElement2.FindElements(By.TagName("g"));
            }
            else
            {
                throw new ArgumentException("Piechart number must be either 1 or 2");
            }
        }
        public int CountRows() => SeleniumDriver.FindElements(By.Id("table_row")).Count();
        public IWebElement GetTableOfTrackers() => SeleniumDriver.FindElement(By.Id("table"));
    }
}
