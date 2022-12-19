Feature: UserDetailsPage

It is used to see the details of a user

Background:
	Given I am on the Login Page
	And I use Admin credentials
	When I press the login button

@HappyPath
Scenario: I wish to go to the User Details Page
	Given I am on the User Data Page
	When I press the Details
	Then I am on the User Details Page

@HappyPath
Scenario: I wish to got o the User Edit Page
Given I am on the User Data Page
And I press Details
When I press the Edit Button
Then I am on the User Edit Page