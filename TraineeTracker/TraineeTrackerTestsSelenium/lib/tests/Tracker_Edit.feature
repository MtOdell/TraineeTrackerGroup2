Feature: Tracker_Edit

As a user, I want to be able to edit a tracker

@TrackerEdit
@Happy
@ChangeTrackerDetails
Scenario: I edit details about a tracker and click Save
	Given I am a valid trainee
	And I am on the Edit page for a tracker
	When I change the data in the input fields:
		| Field          | Value            |
		| stop_input     | Different data 1 |
		| start_input    | Different data 2 |
		| continue_input | Different data 3 |
		| comments_input | Different data 4 |
	And I click the Save button
	Then my changes should be saved

@TrackerEdit
@Happy
Scenario: I click the Back button
	Given I am a valid trainee
	And I am on the Edit page for a tracker
	When I click the Back button on the Edit page
	Then I should be taken to the Tracker Index page

@TrackerEdit
@Sad
Scenario: Trying to access the Edit page for a tracker that does not exist
	Given I am a valid trainee
	When I go to the URL of the Edit page for a tracker that does not exist
	Then nothing should be displayed
