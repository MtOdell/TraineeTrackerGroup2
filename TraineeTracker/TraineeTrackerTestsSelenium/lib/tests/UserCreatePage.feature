Feature: UserCreatePage

Is used to create a user

Background:
	Given I am on the Login Page
	And I use Admin credentials
	When I press the login button

@HappyPath
Scenario: I wish to create a user with valid information
	Given I am on the User Create Page
	And I input valid information with an "<id>"
	When I click on the create button
	Then The user is created
	Examples: 
	| id  |
	| 279 |

@SadPath
Scenario: I wish to create a user with invalid information
	Given I am on the User Create Page
	And I input invalid information with an "<id>"
	When I click on the create button
	Then The user is not created
	Examples: 
	| id  |
	| 279 |

@HappyPath
Scenario: I wish to go back to the index page
	Given I am on the User Create Page
	When I click on the Back To List button
	Then I am on the Index Page
