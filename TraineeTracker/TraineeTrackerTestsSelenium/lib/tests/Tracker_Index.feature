Feature: Tracker_Index

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
@Happy
@Trainee
Scenario: I am logged in as a trainee and I can access my trackers
	Given I am a valid trainee
	When I go to my tracker page
	Then I can see my trackers

@TrackerIndex
@Happy
@Trainee
Scenario: I am logged in as a trainee and I am on the Tracker Index page
	Given I am a valid trainee
	And I am on the trainee Tracker page
	Then the only button I can see should be the Details buttons for my trackers

@TrackerIndex
@Sad
Scenario: I try to access a trainee Tracker page for a trainee that does not exist
	Given I am a valid trainer
	When I go to the URL of the tracker page for a trainee that does not exist
	Then no trackers should be displayed

@TrackerIndex
@Sad
@Trainee
Scenario: I try to access a trainee Tracker page for another trainee other than myself
	Given I am a valid trainee
	When I try to navigate to another trainee's Tracker Index page
	Then I should not be allowed to access the page