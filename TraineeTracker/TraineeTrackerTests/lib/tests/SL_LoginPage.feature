Feature: SL_LoginPage

As a user I want to be able to log in to my account
Background:
	Given I am on the Loginpage
@Login
@Happy
Scenario: I am a trainer and I log in with my email and password
	Given I enter a valid email
	And I enter a valid password
	When I click the login button
	Then I am taken to the home page
