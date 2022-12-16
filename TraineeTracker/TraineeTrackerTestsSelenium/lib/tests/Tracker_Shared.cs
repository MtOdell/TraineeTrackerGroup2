using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTestsSelenium.lib.tests
{
    public class Tracker_Shared
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        protected Credentials _credentials = new();
    }
}
