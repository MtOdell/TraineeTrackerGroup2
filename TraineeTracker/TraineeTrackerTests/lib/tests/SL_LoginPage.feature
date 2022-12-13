Feature: SL_LoginPage

As a user I want to be able to log in to my account
Background:
	Given I am on the Loginpage
@Login
@Happy
Scenario: I am a valid user and I log in with my email and password
	Given And I have the following credentials:
        | Email                  | Password   | 
        | Nish@SpartaGlobal.com  | Password1! |
        | Adam@SpartaGlobal.com  | Password1! |
        | Admin@SpartaGlobal.com | Password1! |
	When I click the login button
	Then I am taken to the home page
@Login
@Sad
Scenario: I am an invalid user and I try to log in
	Given And I have the following credentials:
	| Email                        | Password        | 
	| Nish@SpartaGlobal.com        | InvalidPassword |
	| InvalidUser@SpartaGlobal.com | Password1!      |
	When I click the login button
	Then I am given an error message Invalid login attempt

@Login
@Happy
Scenario: I click on registe button im taken to register page
	When I click the register button
	Then I am taken to the register page