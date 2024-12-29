Feature: Calculator

Scenario: Complete a webform
	Given I am on webform page
	When I complete the form
	And I click the submit button
	Then my form is submitted
	And I close the browser