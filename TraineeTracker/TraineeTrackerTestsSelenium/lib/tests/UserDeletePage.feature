Feature: UserDeletePage

Is used to delete a user

Background:
	Given I am on the Login Page
	And I use Admin credentials
	And I press the login button

@HappyPath
Scenario: I wish to delete a user
	Given I am on the User Index Page
	When I click on the Delete Button
	Then I am redirected to the delete user page
