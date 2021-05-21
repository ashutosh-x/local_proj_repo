Feature: 03Users Feature

Background:
		Given I have navigated to the portal

@Regression
Scenario Outline: 01Validate the Add user functionality
	When I login to the OrangHRM portal as <UserType>
	And I should be redirected to the homepage of the OrangeHRM portal
	And I click on module "Admin"
	And I click on module "User Management"
	And I click on module "Users"
	Then I assert that the user is redirected to the users list page
	And I click on Logout

	Examples: 
	| UserType |
	| admin    |