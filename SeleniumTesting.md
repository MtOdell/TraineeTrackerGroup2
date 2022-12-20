# Selenium Testing

## Introduction

The Selenium Testing add-on project was undertaken to further test the Trainee Tracker app by simulating user input and interaction with automated Selenium tests. The tests were also BDD oriented using the SpecFlow .NET framework.

## Additional Packages Used

- Selenium.Webdriver
- Selenium.Webdriver.ChromeDriver
- Selenium.Webdriver.GeckoDriver
- SpecFlow
- SpecFlow.NUnit
- SpecFlow.Plus.LivingDocPlugin
- System.Configuration.ConfigurationManager

## Structure

For this add-on testing project we decided to separate it from the rest of the previous work, so we created a separate Test Project, along with an API Test Project and framework. In the Test Project, there are two main directories, "lib" and "Utils".

lib holds the child directories "driver_config", "pages", and "tests".

- driver_config contains the Selenium Driver config file that sets up the driver for use in all of the automated tests that use Selenium.
- pages contains all of the Page Object Model files that contain the testing framework that helps with testing
- tests contains all of the website tests that were written using Selenium and Specflow

Utils contains additional utilities that interact with the tests.

## What Was Tested

Before the project was undertaken, a plan was devised so that all testers knew exactly what was to be tested. We came up with several epics, user stories and test cases that were used to gauge testing completion. After these were completed, some Exploratory Testing was undertaken to find bugs in the software and Issues/Defects were noted.

### Epics

- Epic 1 - As a Trainee I want to view and edit my trainee tracker so that I may keep track of my progress
- Epic 2 - As a Trainer, I want to be able to view and edit trainee profiles, so that I may show them to clients
- Epic 3 - As a trainee I want to View and edit my Profile so that it may be sent to clients
- Epic 4 - As a trainer, I want to be able to view changes to all of my trainees' trackers so that I may track their progress
- Epic 5 - As an admin I want to be able to track and update trainers and trainees so that I can manage the organsiation
- Epic 6 - As a user I would like to be able to log in to my account and update my details.
- Epic 7 - As a User, I want to be able to navigate the page through main menu

### User Stories

- 1.1 - As a Trainee I want to be able to have access to my own tracker
- 1.2 - As a Trainee I want to be able to update my tracker
- 2.1 - As A Trainer I want to access Trainee's profiles
- 2.2 - As a trainee I want to see my profile so that I can make sure my profile is up to date
- 4.1 - As a new user i should be able to register as a trainer so I can manage my trainees
- 4.2 - As a trainer I want to be able to delete a Trainees Tracker
- 4.3 - As a new user I want to be able to register a new account
- 5.1 - As an Admin, I want to be able to create and remove accounts, and view all information regarding those accounts.
- 5.2 - As the Admin, I should be able to Delete Trainers and Trainees
- 5.3 - As the Admin, I should be able to Update Trainers and Trainees using the forum UI
- 5.4 - As the Admin, I should be able to Assign Trainers and Trainees
- 6.1 - As a user I want to be able to log into my account
- 6.2 - As a user if I can't remember my password I should be able to have a forgot password link so I can change my password.
- 7.1 As a user I want to be able to browse the website from the main menu

### Test Cases

- 1.1.1 - As a trainee I want to be able to access my trackers. (Happy)
- 1.2.1 - As a valid trainee, I should be able to update my trackers. (Happy)
- 1.2.2 - As a valid trainee with no trackers I shouldn't be able to update my trackers. (Sad)
- 1.2.3 - As an invalid trainee I shouldn't be able to update my trackers. (Sad)
- 2.1.1: Given a valid Trainee I can access their profile (Happy)
- 2.1.2: Given an invalid Trainee I can't access their profile (Sad)
- 2.2.1: As a valid trainee I want to be able to edit my profile (Happy)
- 2.2.2: As an invalid trainee I cant access a profile (Sad)
- 4.1.1: As a new user I should be able to select trainer as my role (Happy)
- 4.1.2: As a new user if I don't change my role I should be a trainee (Happy)
- 4.2.1: When there is a tracker to delete it is deleted (Happy)
- 4.2.2: When there is no tracker to delete it doesn't delete it (Sad)
- 4.3.1 When I input valid information then I am registered as a new user. (Happy)
- 4.3.2: When I input invalid information then I am given an error. (Sad)
- 5.1.2: Unsuccessfully Create an Account  (Sad)
- 5.2.1: As an admin when given a valid trainer/trainee I delete them (Happy)
- 5.2.2: As an admin when given an invalid trainee or trainer I can't delete them. (Sad)
- 5.3.1: As an admin given a valid trainer/trainee I can update their profile with valid information. (Happy)
- 5.3.3: As an admin given an invalid trainer/trainee I can access their profile. (Sad)
- 5.4.1:  As a admin, given a valid trainer I can change them to trainee (Happy)
- 5.4.2: As an admin given a valid trainer I can keep them as a trainer (Happy)
- 5.4.3: As an admin, given a valid trainee I can change them to a trainer (Happy)
- 5.4.4:  As an admin, given a valid trainee I can keep them as a trainee (Happy)
- 5.4.5: As an admin, given an invalid trainer/trainee I can't access their role. (Sad)
- 6.1.1: As a valid user I can log in (Happy)
- 6.1.2:  As an invalid user I cannot log in (Sad)
- 6.2.1: If I enter a valid email, when I click forgotten password I am taken to the email confirmation sent page. (Happy)
- 6.2.2: If I enter an invalid email, when i click forgotten password I am given the Email field is not a valid email error. (Sad)
- 7.1.1 As a user given I am on the main menu I can go to login page (Happy)
- 7.1.2 As a user given I am on the main page I can go to privacy page (Happy)
- 7.1.3 As a user given I am on the main page and I am logged in I can log out (Happy)
- 7.1.4 As a user When I am not logged in and I go to user page Then I am redirected to login page
- 7.1.5 As a user When I am logged in and I can go to user page

### Exploratory Testing

- e1.1 - As a Trainee can I access the Create page?
- e1.2 - As a user can I access the Create page for a Trainee that does not exist?
- e1.3 - As a Trainee can I access the Delete page?
- e1.4 - As a user can I access the Details page for a tracker that does not exist?

### Issues/Defects

From some of the exploratory tests and also one of the test cases, Issues/Defects were found and tickets were created.

- e1.1 Trainee can access Create page
- e1.2 Can access Create page for a Trainee that does not exist
- 1.2.3 Can access another Trainee's trackers as a Trainee