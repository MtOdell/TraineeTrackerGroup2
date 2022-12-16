Feature: ForgottenPasswordPageFetaure

As a user I want to be able to change my password if ive fogotten it so I can still access my account
Background:
	Given I am on the ForgottenPasswordPage
@ForgottenPassword
@Happy
Scenario: When i enter a valid email I am takne to the change password page
	Given I enter a email <email>
	When I press reset password
	Then I am on the confirmation page
Examples:
	| email                  |
	| Nish@SpartaGlobal.com  |
	| Adam@SpartaGlobal.com  |
	| Admin@SpartaGlobal.com |
@ForgottenPassword
@Sad
Scenario: When i enter a invalid email I am given the 
	Given I enter a email <email>
	When I press reset password
	Then I am given the not valid email address error
Examples:
	| email        |
	| InvalidEmail | 
	
