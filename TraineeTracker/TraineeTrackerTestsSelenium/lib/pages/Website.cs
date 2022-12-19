
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
        public ForgottenPasswordPage ForgottenPasswordPage { get; set; }
        public LoginPage LoginPage { get; set; }
        public Homepage Homepage { get; set; }
        public RegisterPage RegisterPage { get; set; }
        public Tracker_Index Tracker_Index { get; set; }
        public Tracker_Create Tracker_Create { get; set; }
        public Tracker_Details Tracker_Details { get; set; }
        public Tracker_Edit Tracker_Edit { get; set; }
        public Tracker_Delete Tracker_Delete { get; set; }
        public UserCreatePage UserCreatePage { get; set; }
        public UserDeletePage UserDeletePage { get; set; }
        public UserDetailsPage UserDetailsPage { get; set; }
        public UserEditPage UserEditPage { get; set; }
        public UserIndexPage UserIndexPage { get; set; }
        public Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            ForgottenPasswordPage = new ForgottenPasswordPage(SeleniumDriver);
            Homepage = new Homepage(SeleniumDriver);
            LoginPage = new LoginPage(SeleniumDriver);
            RegisterPage = new RegisterPage(SeleniumDriver);
            Tracker_Index = new Tracker_Index(SeleniumDriver);
            Tracker_Create = new Tracker_Create(SeleniumDriver);
            Tracker_Details = new Tracker_Details(SeleniumDriver);
            Tracker_Edit = new Tracker_Edit(SeleniumDriver);
            Tracker_Delete = new Tracker_Delete(SeleniumDriver);
            UserCreatePage = new UserCreatePage(SeleniumDriver);
            UserDeletePage = new UserDeletePage(SeleniumDriver);
            UserDetailsPage = new UserDetailsPage(SeleniumDriver);
            UserEditPage = new UserEditPage(SeleniumDriver);
            UserIndexPage = new UserIndexPage(SeleniumDriver);
        }
        #endregion
    }
}
