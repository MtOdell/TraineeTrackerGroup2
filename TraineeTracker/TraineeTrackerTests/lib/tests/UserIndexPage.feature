Feature: SL_UserIndexPage

It is used to view multiple users and select options for them

@HappyPath
Scenario: I wish to go to the Edit Page
	Given I am on the User Index Page
	When I click on the Edit Button
	Then I am on the User Edit Page

@HappyPath
Scenario: I wish to go to the User Details Page
	Given I am on the User Index Page
	When I click on the Profile Button
	Then I am on the User Details Page

@HappyPath
Scenario: I wish to go to the Trackers Page
	Given I am on the User Index Page
	When I click on the Trackers Button
	Then I am on the Trackers Page

@HappyPath
Scenario: I wish to go to the User Delete Page
	Given I am on the User Index Page
	When I click on the Delete Button
	Then I am on the User Delete Page