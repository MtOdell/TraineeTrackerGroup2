Feature: UserEditPage

Is used to edit the user detail

Background:
	Given I am on the Login Page
	And I use Admin credentials
	When I press the login button

@HappyPath
Scenario: I wish to edit a user with valid inputs
	Given I am on the User Edit Page
	And I input valid information
	When I click on the save button
	Then The user is edited

@SadPath
Scenario: I wish to edit a user with invalid inputs
	Given I am on the User Edit Page
	And I input invalid information
	When I click on the save button
	Then The error messages are shown

@HappyPath
Scenario: I wish to go back to the index page
	Given I am on the User Edit Page
	When I click on the Back button
	Then I am on the Index Page
