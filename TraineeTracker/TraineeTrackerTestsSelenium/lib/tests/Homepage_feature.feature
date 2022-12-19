Feature: Homepage_Feature

As a User, I want to be able to navigate Home page

@HappyPath
Scenario: Going to login page
	Given I have a browser open
	And I am on a homepage
	When I press login button
	Then I am redirected to the login page

@HappyPath
Scenario: Going to register page
	Given I have a browser open
	And I am on a homepage
	When I press register button
	Then I am redirected to the register page

@HappyPath
Scenario: Going to user page while logged in
	Given I have a browser open
	And I am logged in
	And I am on a homepage
	When I press user button
	Then I am redirected to the user page

@SadPath
Scenario: Going to user page without logging in
	Given I have a browser open
	And I am on a homepage
	When I press user button
	Then I am redirected to the login page

@HappyPath
Scenario: Going to privacy page
	Given I have a browser open
	And I am on a homepage
	When I press privacy button
	Then I am redirected to the privacy page

@HappyPath
Scenario: Logging out when logged in
	Given I have a browser open
	And I am logged in
	When I press logout
	Then I am logged out
	And I am redirected the home page