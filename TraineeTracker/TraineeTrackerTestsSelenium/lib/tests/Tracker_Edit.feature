Feature: Tracker_Edit

As a user, I want to be able to edit a tracker

@TrackerEdit
@Happy
Scenario: I edit details about a tracker and click Save
	Given I am logged in
	And I am on the Edit page for a tracker
	When I change the data in the input fields
	And I click the Save button
	Then my changes should be saved

@TrackerEdit
@Happy
Scenario: I click the Back button
	Given I am logged in
	And I am on the Edit page for a tracker
	When I click the Back button on the Edit page
	Then I should be taken to the Tracker Index page

@TrackerEdit
@Sad
Scenario: Trying to access the Edit page for a tracker that does not exist
	Given I am logged in
	When I go to the URL of the Edit page for a tracker that does not exist
	Then I should get a 404 status code
