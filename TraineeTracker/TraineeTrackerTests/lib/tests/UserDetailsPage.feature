Feature: SL_UserDetailsPage

It is used to see the details of a user

Background:
	Given A test user is created

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
