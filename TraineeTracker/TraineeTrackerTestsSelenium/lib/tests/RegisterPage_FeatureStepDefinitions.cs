using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TraineeTrackerTests.lib.pages;
using TraineeTrackerTests.Utils;

namespace TraineeTrackerTests.lib.tests
{
    [Binding]
    public class RegisterPage_FeatureStepDefinitions
    {
        public Website<ChromeDriver> Website { get; } = new Website<ChromeDriver>();
        protected RegisterInfo _registerInfo;
        [Given(@"I am on the register page")]
        public void GivenIAmOnTheRegisterPage()
        {
            Website.RegisterPage.VisitRegisterPage();
        }

        [Given(@"I input valid info to register")]
        public void GivenIInputValidInfoToRegister(Table table)
        {
            _registerInfo = table.CreateInstance<RegisterInfo>();
        }
        [Given(@"enter these registerInfo")]
        public void GivenEnterTheseRegisterInfo()
        {
            Website.RegisterPage.EnterRegisterInfo(_registerInfo);
        }

        [When(@"I press the register button")]
        public void WhenIPressTheRegisterButton()
        {
            Website.RegisterPage.ClickRegisterButton();
        }
    }
}
