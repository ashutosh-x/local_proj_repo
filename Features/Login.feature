Feature: 01Login Feature

Background:
		Given I have navigated to the portal

@mytag
Scenario Outline: 01Validate the login functionality
	When I login to the OrangHRM portal as <UserType>
	And I should be redirected to the homepage of the OrangeHRM portal
	And I click on Logout

	Examples: 
	| UserType |
	| admin    |