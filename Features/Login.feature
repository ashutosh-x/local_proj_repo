Feature: 01Login Feature

Background:
		Given I have navigated to the portal

@mytag
Scenario Outline: 01Validate the login functionality
	When I login to the OrangHRM portal as <UserType>

	Examples: 
	| UserType |
	| admin    |