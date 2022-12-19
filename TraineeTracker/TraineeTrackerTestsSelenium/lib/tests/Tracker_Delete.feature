Feature: Tracker_Delete

As a trainer or admin, I want to be able to delete a tracker

@TrackerDelete
@Happy
@Trainer
@DeleteDummyTracker
Scenario: I press the Delete button
	Given there is a tracker to delete
	Given I am on the Delete page for a tracker
	When I click the Delete button
	Then the tracker should be deleted

@TrackerDelete
@Happy
@Trainer
Scenario: I press the Back button
	Given I am on the Delete page for a tracker
	When I click the Back button on the Delete page
	Then I should be taken to the Tracker Index page

@TrackerDelete
@Sad
@Trainee
Scenario: I try to access the Delete page as a trainee
	Given I am a valid trainee
	When I try to go to the Delete page for a tracker
	Then I should be blocked from accessing the page
	And an access denied message should appear

@TrackerDelete
@Sad
@Trainer
Scenario: I try to Delete a tracker when there are no trackers
	Given I go to a Trainee's tracker page
	And there are no tracker's to delete
	When I try and click the Delete button
	Then nothing should happen