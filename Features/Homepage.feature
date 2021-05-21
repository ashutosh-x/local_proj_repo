Feature: 02Homepage Feature

Background:
		Given I have navigated to the portal

@Regression
Scenario Outline: 01Validate the UI for the homepage of OrangeHRM portal
	When I login to the OrangHRM portal as <UserType>
	And I should be redirected to the homepage of the OrangeHRM portal
	And I validate the main menu options displayed on the left side of the homepage
	And I click on Logout

	Examples: 
	| UserType |
	| admin    |