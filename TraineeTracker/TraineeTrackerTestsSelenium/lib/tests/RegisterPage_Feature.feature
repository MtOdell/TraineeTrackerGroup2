Feature: RegisterPage_Feature

As  new user I want to be access the register page
So that I can enter my details
And register as a new user

Background:
	Given I am on the register page
@Register
@Happy
Scenario: When I input valid details then I am registered as a user
	Given I input valid info to register
		| Email                    | Password   | ConfirmPassword |
		| NewUser@SpartaGlobal.com | Password1! | Password1!      |
	And enter these registerInfo
	When I press the register button
	Then I am on the edit page
@Register
@Sad
Scenario: When I input invalid details then I am registered as a user
	Given I input valid info to register
		| Email                    | Password        | ConfirmPassword |
		| InvalidEmail             | Password1!      | Password1!       |
	And enter these registerInfo
	When I press the register button
	Then I get an error The Email field is not a valid e-mail address 

@Register
@Sad
Scenario: When I input two different passwords then I am given the passwords dont match error
	Given I input valid info to register
		| Email                     | Password   | ConfirmPassword   |
		| NewEmail@SpartaGlobal.com | Password1! | DifferentPassword | 
	And enter these registerInfo
	When I press the register button
	Then I get the passwords dont match error

@Register
@Sad
Scenario: When I input an invalid passwords then I am given the passwords must be 6 letter long and have a number and special charachter error
	Given I input valid info to register
		| Email                     | Password | ConfirmPassword |
		| NewEmail@SpartaGlobal.com | wrong    | wrong           | 
	And enter these registerInfo
	When I press the register button
	Then I get the password is invalid error 
