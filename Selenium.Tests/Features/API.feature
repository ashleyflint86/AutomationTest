Feature: API
	If I fetch the public API,
	I should recieve the expected results

@mytag
Scenario: Verify Public API
	Given I request the public API
	When I compare the results
	Then they should be as expected
