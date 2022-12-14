
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTrackerTests.lib.driver_config;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_Website<T> where T : IWebDriver, new()
    {
        #region Accessible Page Objects and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }
        public SL_LoginPage SL_LoginPage { get; set; }
        public SL_Homepage SL_HomePage { get; set; }
        public Tracker_Index SL_Tracker_Index { get; set; }
        public Tracker_Create SL_Tracker_Create { get; set; }
        public Tracker_Details SL_Tracker_Details { get; set; }
        public Tracker_Edit SL_Tracker_Edit { get; set; }
        public Tracker_Delete SL_Tracker_Delete { get; set; }
        public SL_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            SL_HomePage = new SL_Homepage(SeleniumDriver);
            SL_LoginPage = new SL_LoginPage(SeleniumDriver);
            SL_Tracker_Index = new Tracker_Index(SeleniumDriver);
            SL_Tracker_Create = new Tracker_Create(SeleniumDriver);
            SL_Tracker_Details = new Tracker_Details(SeleniumDriver);
            SL_Tracker_Edit = new Tracker_Edit(SeleniumDriver);
            SL_Tracker_Delete = new Tracker_Delete(SeleniumDriver);
        }
        #endregion
    }
}
