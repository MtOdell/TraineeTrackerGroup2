Feature: SL_UserDeletePage

Is used to delete a user

Background:
	Given A test user is created

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
