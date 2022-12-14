Feature: SL_UserCreatePage

Is used to create a user

@HappyPath
Scenario: I wish to create a user with valid inputs
	Given I am on the User Create Page
	And I input valid information
	When I click on the create button
	Then The user is created

@SadPath
Scenario: I wish to create a user with invalid inputs
	Given I am on the User Create Page
	And I input invalid information
	When I click on the create button
	Then The error messages are shown

@HappyPath
Scenario: I wish to go back to the index page
	Given I am on the User Create Page
	When I click on the Back To List button
	Then I am on the Index Page
