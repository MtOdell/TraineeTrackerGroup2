Feature: Tracker_Create

As a trainer or admin, I want to be able to create a tracker

@TrackerCreate
@Happy
Scenario: I enter details about a tracker and click Save
	Given I am a valid trainer
	And I am on the edit page
	When I enter data into the input fields
	And I click the Save button
	Then my changes should be saved

@TrackerCreate
@Happy
Scenario: I click the Back button
	Given I am on the Create page
	When I click the Back button on the Create page
	Then I should be taken to the Tracker Index page

@TrackerCreate
@Sad
Scenario: Trying to access the Create page for a tracker that does not exist
	Given I am logged in
	When I go to the URL of the Create page for a tracker that does not exist
	Then I should get a 404 status code