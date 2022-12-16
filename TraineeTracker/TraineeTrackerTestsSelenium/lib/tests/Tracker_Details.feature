﻿Feature: Tracker_Details

As a user, I want to be able to view details about a tracker

@TrackerDetails
@Happy
Scenario: Tracker details are shown
	Given I am a valid user
	And I am on the Details page for a tracker
	Then the details for that tracker should be shown

@TrackerDetails
@Happy
Scenario: I click the Edit button
	Given I am a valid user
	And I am on the Details page for a tracker
	When I click the Edit button
	Then I should be taken to the Edit page

@TrackerDetails
@Happy
Scenario: I click the Back button
	Given I am a valid user
	And I am on the Details page for a tracker
	When I click the Back button on the Details page
	Then I should be taken to the Tracker Index page

@TrackerDetails
@Sad
Scenario: Trying to access a details page for a tracker that does not exist
	Given I am a valid user
	When I go to the URL of the Details page for a tracker that does not exist
	Then nothing should be displayed
