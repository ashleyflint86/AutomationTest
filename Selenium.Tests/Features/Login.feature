Feature: Register & Login
	I can successfully register on https://www.nopcommerce.com,
	And can then login in successfully

@Registration @Selenium
Scenario: Register Successfully
	Given I navigate to the registration page
	And I enter my details
	When I press register button
	Then my registration should be successful
	And I should be logged in

@Login @Selenium
Scenario: Login Successfully
	Given I navigate to the login page
	And I enter my login details
	When I press login button
	Then I should be logged in
	
