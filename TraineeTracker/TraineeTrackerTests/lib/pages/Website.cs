
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTrackerTests.lib.driver_config;

namespace TraineeTrackerTests.lib.pages
{
    public class Website<T> where T : IWebDriver, new()
    {
        #region Accessible Page Objects and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }
        public LoginPage SL_LoginPage { get; set; }
        public Homepage Homepage { get; set; }
        public RegisterPage SL_RegisterPage { get; set; }
        public Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            Homepage = new Homepage(SeleniumDriver);
            SL_LoginPage = new LoginPage(SeleniumDriver);
            SL_RegisterPage = new RegisterPage(SeleniumDriver);
        }
        #endregion
    }
}
