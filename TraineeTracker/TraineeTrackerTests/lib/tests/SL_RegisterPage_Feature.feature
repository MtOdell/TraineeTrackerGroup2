Feature: SL_RegisterPage_Feature

As  new user I want to be access the register page
So that I can enter my details
And register as a new user

Background:
	Given I am on the register page
@Register
@Happy
Scenario: When I input valid details then I am registered as a user
	Given I input valid info to register
		| Email                    | Password   | Confirm Password |
		| NewUser@SpartaGlobal.com | Password1! | Password1!       |
	When I press the register button
	Then I am on the home page
@Register
@Happy
Scenario: When I input vinalid details then I am registered as a user
	Given I input valid info to register
		| Email                    | Password        | Confirm Password |
		| InvalidEmail             | Password1!      | Password1!       |
		| newuser@SpartaGlobal.com | InvalidPassword | InvalidPassword  |
		| newuser@SpartaGlobal.com | Password1!      | PasswordNotSame  |
	When I press the register button
	Then I get an error <error>
	Examples: 
	| error |
	|       |
	|       |
	|       |