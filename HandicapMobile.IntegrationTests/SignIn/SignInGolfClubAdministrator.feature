@base @signin
Feature: SignInGolfClubAdministrator
	As a golf club administrator
	In order to register my club 
	I require to be able to sign in

Background: 
	Given There are no administrators signed up
	And I have signed up as a golf club administrator with the following details
	| EmailAddress                | Password | TelephoneNumber |
	| testemail@testgolfclub.co.uk | 123456   | 123456789        |

Scenario: Sign In As Golf Club Administrator
	Given I am on the Home Screen
	When I tap on the Sign In button
	And I enter the username 'testemail@testgolfclub.co.uk' and password '123456'
	And I click on the Sign In button
	Then I should be presented with the Club Administrator Signed In Page
	
	