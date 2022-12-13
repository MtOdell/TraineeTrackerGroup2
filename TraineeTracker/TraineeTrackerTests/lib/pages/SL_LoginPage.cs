using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_LoginPage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _homePageUrl = AppConfigReader.LoginUrl;
    }
}
