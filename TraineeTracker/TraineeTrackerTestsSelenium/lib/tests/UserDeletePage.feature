Feature: UserDeletePage

Is used to delete a user

Background:
	Given I am on the Login Page
	And I use Admin credentials
	When I press the login button

@HappyPath
Scenario: I wish to delete a user
	Given I am on the User Delete Page
	When I click on the Delete Button
	Then The user is deleted

@HappyPath
Scenario: I wish to go back to the Index Page
	Given I am on the User Delete Page
	When I click on the Back Button
	Then I am on the Index Page
