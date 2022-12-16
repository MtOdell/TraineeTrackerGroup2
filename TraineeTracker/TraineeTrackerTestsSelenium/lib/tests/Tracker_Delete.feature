Feature: Tracker_Delete

As a trainer or admin, I want to be able to delete a tracker

@TrackerDelete
@Happy
Scenario: I press the Delete button
	//Given I am a valid trainer
	Given I am on the Delete page for a tracker
	When I click the Delete button
	Then the tracker should be deleted

@TrackerDelete
@Happy
Scenario: I press the Back button
	Given I am on the Delete page for a tracker
	When I click the Back button on the Delete page
	Then I should be taken to the Tracker Index page

@TrackerDelete
@Happy
Scenario: The correct details for the tracker are displayed
	//Given I am a valid trainer
	And I am on the Delete page for a tracker
	Then the correct details for that tracker should be shown

@TrackerDelete
@Sad
Scenario: I try to access the Delete page as a trainee
	Given I am a valid trainee
	When I try to go to the Delete page for a tracker
	Then I should be blocked from accessing the page
	And an access denied message should appear
