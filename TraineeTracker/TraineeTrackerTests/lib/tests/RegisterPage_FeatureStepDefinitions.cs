using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class SL_RegisterPage_FeatureStepDefinitions
    {
        public SL_Website<ChromeDriver> SL_Website { get; } = new SL_Website<ChromeDriver>();
        protected RegisterInfo _registerInfo;
        [Given(@"I am on the register page")]
        public void GivenIAmOnTheRegisterPage()
        {
            SL_Website.SL_RegisterPage.VisitRegisterPage();
        }

        [Given(@"I input valid info to register")]
        public void GivenIInputValidInfoToRegister(Table table)
        {
            _registerInfo = table.CreateInstance<RegisterInfo>();
        }

        [When(@"I press the register button")]
        public void WhenIPressTheRegisterButton()
        {
            SL_Website.SL_RegisterPage.ClickRegisterButton();
        }
    }
}
