Feature: Tracker_Create

As a trainer or admin, I want to be able to create a tracker

@TrackerCreate
@Happy
Scenario: I enter details about a tracker and click Create
	Given I am a valid trainer
	And I am on the Create page
	When I enter data into the input fields:
		| Field          | Value      |
		| stop_input     | New data 1 |
		| start_input    | New data 2 |
		| continue_input | New data 3 |
		| comments_input | New data 4 |
	And I click the Save button on the Create page
	Then a new tracker is created with the details I entered

@TrackerCreate
@Happy
Scenario: I click the Back button
	Given I am a valid trainer
	And I am on the Create page
	When I click the Back button on the Create page
	Then I should be taken to the Tracker Index page

@TrackerCreate
@Sad
Scenario: Trying to access the Create page for a tracker that does not exist
	Given I am a valid trainer
	When I go to the URL of the Create page for a tracker that does not exist
	Then nothing should be displayed

@TrackerCreate
@Sad
Scenario: Trying to access the Create page when logged in as a trainee
	Given I am a valid trainee
	When I try to access the Create page for a tracker of a valid trainee
	Then I should be blocked from accessing the page
	And an access denied message should appear