using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_UserCreatePage
    {
        private IWebDriver SeleniumDriver { get; }
        private string _userCreatePageUrl = AppConfigReader.UserCreateUrl;
        private IWebElement _userIdInput => SeleniumDriver.FindElement(By.Id("user_id_input"));
        private IWebElement _firstNameInput => SeleniumDriver.FindElement(By.Id("first_name_input"));
        private IWebElement _lastNameInput => SeleniumDriver.FindElement(By.Id("last_name_input"));
        private IWebElement _titleInput => SeleniumDriver.FindElement(By.Id("title_input"));
        private IWebElement _educationInput => SeleniumDriver.FindElement(By.Id("education_input"));
        private IWebElement _experienceInput => SeleniumDriver.FindElement(By.Id("experience_input"));
        private IWebElement _activityInput => SeleniumDriver.FindElement(By.Id("activity_input"));
        private IWebElement _biologyInput => SeleniumDriver.FindElement(By.Id("biology_input"));
        private IWebElement _skillsInput => SeleniumDriver.FindElement(By.Id("skills_input"));
        private IWebElement _createButton => SeleniumDriver.FindElement(By.Id("create_button"));

        public SL_UserCreatePage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitUserCreatePage() => SeleniumDriver.Navigate().GoToUrl(_userCreatePageUrl);
        public void EnterUserId(string userId) => _userIdInput.SendKeys(userId);
        public void EnterFirstName(string firstName) => _firstNameInput.SendKeys(firstName);
        public void EnterLastName(string lastName) => _lastNameInput.SendKeys(lastName);
        public void EnterTitle(string title) => _titleInput.SendKeys(title);
        public void EnterEducation(string education) => _educationInput.SendKeys(education);
        public void EnterExperience(string experience) => _experienceInput.SendKeys(experience);
        public void EnterActivity(string activity) => _activityInput.SendKeys(activity);
        public void EnterBiology(string biology) => _biologyInput.SendKeys(biology);
        public void EnterSkills(string skills) => _skillsInput.SendKeys(skills);
        public void ClickCreateButton() => _createButton.Click();
    }
}
