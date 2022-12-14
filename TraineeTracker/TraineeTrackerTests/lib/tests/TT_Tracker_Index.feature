Feature: SL_Tracker_Index

As a user, I want to be able to see a list of trackers, so I can access them

@TrackerIndex
@Happy
Scenario: I am a valid trainer and visit a trainee's tracker page
	Given I am a valid trainer
	And I am on the View Trainees page
	When I click the Tracker button for one of the trainees listed
	Then I am taken to that trainee's Tracker page

@TrackerIndex
@Happy
Scenario: A list of trainee trackers is displayed for that particular trainee
	Given I am a valid trainer
	And I am on the View Trainees page
	When I click the Tracker button for one of the trainees listed
	Then I can see a list of trackers for that particular trainee

@TrackerIndex
@Happy
Scenario: I click the Back button
	Given I am a valid trainer
	And I am on the trainee Tracker page
	When I click the Back button
	Then I should be taken to the View Trainees page

@TrackerIndex
@Happy
Scenario: I click the Create New button
	Given I am a valid trainer
	And I am on the trainee Tracker page
	When I click the Create New button
	Then I should be taken to the Create page

@TrackerIndex
@Happy
Scenario: I click the Details button on a tracker in the list
	Given I am a valid trainer
	And I am on the trainee Tracker page
	When I click the Details button on a tracker in the list
	Then I should be taken to the Details page for that tracker

@TrackerIndex
@Happy
Scenario: I click the Delete button on a tracker in the list
	Given I am a valid trainer
	And I am on the trainee Tracker page
	When I click the Delete button on a tracker in the list
	Then I should be taken to the Delete page for that tracker

@TrackerIndex
@Sad
Scenario: I try to access a trainee Tracker page for a trainee that does not exist
	Given I am a valid trainer
	When I go to a URL of a tracker page for a trainee that does not exist
	Then no trackers should be displayed