Feature: UserDataFeature

As a programmer, I want to have access to UserData API

@HappyPath
Scenario: Creating UserData Controller object
	Given I have mockUser and mockTracker created
	When I create userdata controller 
	Then userdata is created

@SadPath
Scenario: Calling Get UserData Controller with Invalid Data returns?
	Given I have mockUser and mockTracker created
	And mockUser findasync method is setup to give back null
	When I create userdata controller 
	And I get result from userdata
	Then mockUser used findasync once
	And result is not null
	And result is of not found result

@HappyPath
Scenario: Calling Get UserData Controller object with valid data returns?
	Given I have mockUser and mockTracker created
	And mockUser findasync method is setup to give back new userdata
	When I create userdata controller
	And I get result from userdata
	Then mockUser used findasync once
	And result is not null
	And result is of UserDataViewModel

@SadPath
Scenario: Calling Update UserData with mismatched id 
	Given I have mockUser and mockTracker created
	And mockUser findasync method is setup to give back new userdata
	And mockUser update method is setup to using userdata
	And mockUser savechangesasync is setup
	When I create userdata controller
	And I get result from userdata
	Then mockUser used findasync once
	And result is not null
	And result is of BadRequestResult

@HappyPath
Scenario: Calling Update UserData with valid data
	Given [context]
	When [action]
	Then [outcome]

@SadPath
Scenario: Calling Update UserData, SaveChangesAsync throws catches
	Given [context]
	When [action]
	Then [outcome]

@tag1
Scenario: Calling Update UserData, SaveChangesAsync throws
	Given [context]
	When [action]
	Then [outcome]

@tag1
Scenario: Scenario name
	Given [context]
	When [action]
	Then [outcome]