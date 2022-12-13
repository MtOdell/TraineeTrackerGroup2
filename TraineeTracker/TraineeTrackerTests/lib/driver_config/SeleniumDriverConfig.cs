using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.driver_config
{
    public class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        public IWebDriver Driver { get; set; }
        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs, bool isHeadless)
        {
            Driver = new T();
            DriverSetUp(pageLoadInSecs, implicitWaitInSecs, isHeadless);
        }



        private void DriverSetUp(int pageLoadInSecs, int implicitWaitInSecs, bool isHeadless)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
            if (isHeadless) SetHeadless();
        }

        private void SetHeadless()
        {
            if (Driver is ChromeDriver)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("headless");
                Driver = new ChromeDriver(options);
            }
            else if (Driver is FirefoxDriver)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArgument("--headless");
                Driver = new FirefoxDriver(options);
            }
            else
            {
                throw new ArgumentException("Driver not supported by framewwork");
            }
        }
    }
}
