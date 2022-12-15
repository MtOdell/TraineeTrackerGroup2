
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
        public LoginPage LoginPage { get; set; }
        public Homepage Homepage { get; set; }
        public RegisterPage RegisterPage { get; set; }
        public Tracker_Index SL_Tracker_Index { get; set; }
        public Tracker_Create SL_Tracker_Create { get; set; }
        public Tracker_Details SL_Tracker_Details { get; set; }
        public Tracker_Edit SL_Tracker_Edit { get; set; }
        public Tracker_Delete SL_Tracker_Delete { get; set; }
        public Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            Homepage = new Homepage(SeleniumDriver);
            LoginPage = new LoginPage(SeleniumDriver);
            RegisterPage = new RegisterPage(SeleniumDriver);
            SL_Tracker_Index = new Tracker_Index(SeleniumDriver);
            SL_Tracker_Create = new Tracker_Create(SeleniumDriver);
            SL_Tracker_Details = new Tracker_Details(SeleniumDriver);
            SL_Tracker_Edit = new Tracker_Edit(SeleniumDriver);
            SL_Tracker_Delete = new Tracker_Delete(SeleniumDriver);
        }
        #endregion
    }
}
