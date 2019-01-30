@base @signup
Feature: SignupGolfClubAdministrator
	As a golf club administrator
	In order to register my club 
	I require to be able to sign up

Background: 
	Given There are no administrators signed up

Scenario: Signup Golf Club Administrator
	Given I am on the Home Screen
	When I tap on the Sign Up button
	And I then tap on the Golf Club Administrator button
	And I enter the following details
	| EmailAddress                | Password | TelephoneNumber |
	| testemail@testgolfclub.co.uk | 123456   | 123456789        |
	And I click on the Signup button
	Then I should be presented with a Registration Success message
	And returned to the Home Screen

