Feature: UserDetailsPage

It is used to see the details of a user

Background:
	Given I am on the Login Page
	And I use Admin credentials
	When I press the login button

@HappyPath
Scenario: I wish to go to the User Edit Page
	Given I am on the User Details Page
	When I press the Edit Button
	Then I am on the User Edit Page

@HappyPath
Scenario: I wish to go to the Index Page
	Given I am on the User Details Page
	When I press the Back Button
	Then I am on the Index Page
